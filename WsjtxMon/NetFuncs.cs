using M0LTE.WsjtxUdpLib.Messages.Out;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WsjtxMon;

namespace WSJTXMon
{
    public static class NetFuncs
    {
        private static string? _session = string.Empty;
        private static HttpClient _client = new HttpClient();
        private static XNamespace? _ns;
        const string QrzQueryUrl = "https://xmldata.qrz.com/xml/current/?";
        const string QrzLogUrl = "https://logbook.qrz.com/api";
        private static SQLiteConnection _connection;
        public static Dictionary<string,string> CountryDict = new Dictionary<string, string>();

        public static void LookupCallsign(string callsign, out string state, out string DXCC, out string country)
        {
            if (string.IsNullOrEmpty(_session))
            {
                string url = QrzQueryUrl + string.Format("username={0};password={1}", WsjtxResource.QrzUser, WsjtxResource.QrzPassword);
                var response = _client.GetAsync(url).Result;
                var xmlText = response.Content.ReadAsStringAsync().Result;
                XElement qrzEle = XElement.Parse(xmlText);
                _ns = qrzEle.GetDefaultNamespace();
                if (_ns == null)
                {
                    throw new ApplicationException("Invalid response from QRZ - no namespace");
                }
                var sessEle = qrzEle.Element(_ns + "Session");
                if (sessEle == null) 
                {
                    throw new ApplicationException("Invalid response from QRZ - no session");
                }
                var keyEle = sessEle.Element(_ns + "Key");
                if (keyEle == null)
                {
                    throw new ApplicationException("Invalid response from QRZ - no key");
                }
                _session = keyEle.Value;
            }
            string lookupUrl = QrzQueryUrl + string.Format("s={0};callsign={1}", _session, callsign);
            var lookupResponse = _client.GetAsync(lookupUrl).Result;
            var lookupText = lookupResponse.Content.ReadAsStringAsync().Result;
            XElement lookupEle = XElement.Parse(lookupText);
            if (_ns == null)
            {
                throw new ApplicationException("Invalid response from QRZ - no namespace");
            }
            XElement? callsignEle = lookupEle.Element(_ns + "Callsign");
            state = DXCC = country = string.Empty;
            if (callsignEle != null)
            {
                XElement? stateEle = callsignEle.Element(_ns + "state");
                if (stateEle is not null)
                {
                    state = stateEle.Value;
                }

                XElement? dXCCEle = callsignEle.Element(_ns + "dxcc");
                if (dXCCEle is not null)
                {
                    DXCC = dXCCEle.Value;
                }
                XElement? landEle = callsignEle.Element(_ns + "land");
                if (landEle is not null)
                {
                    country = landEle.Value;
                }
            }
            else
            {
                _session = null;
            }
        }

        public static void SendUdp(IPAddress host, int port, byte[] datagram)
        {
            using (UdpClient udpClient = new UdpClient(new IPEndPoint( host, port)))
            {
                udpClient.Send(datagram);
            }
        }

        public static void LogToQrz(LoggedAdifMessage msg)
        {
            string encAdif = HttpUtility.UrlEncode(msg.AdifText);
            string logData = string.Format("KEY={0}&ACTION=INSERT&ADIF={1}", WsjtxResource.QrzApiKey, encAdif);
            HttpContent encContent = new StringContent( logData, Encoding.UTF8, "application/x-www-form-urlencoded");
            var task = _client.PostAsync(QrzLogUrl, encContent);
            task.Wait();
            var result = task.Result;
            var respTask = result.Content.ReadAsStringAsync();
            respTask.Wait();
            var resp = respTask.Result;
            if (!resp.Contains("RESULT=OK"))
            {
                MessageBox.Show("Error logging to QRZ: " + resp);
            }
        }

        public static void LogToTQsl(LoggedAdifMessage msg)
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, msg.AdifText);
            string tqslParams = string.Format(
                "-c {0} -u -x -a compliant {1}",
                WsjtxResource.Callsign,
                tempFile);
            Directory.SetCurrentDirectory(WsjtxResource.TqslDirectory);
            Process start = new Process();
            start.StartInfo.Arguments = tqslParams;
            start.StartInfo.FileName = "tqsl.exe";
            start.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            start.StartInfo.RedirectStandardOutput = true;
            start.StartInfo.RedirectStandardError = true;
            start.Start();
            List<string?> output = new List<string?>();
            while (!(start.HasExited || start.StandardOutput.EndOfStream))
            {
                output.Add(start.StandardOutput.ReadLine());
            }
            start.WaitForExit();
            if (start.ExitCode != 0)
            {
                MessageBox.Show($"Error logging to TQSL: {start.ExitCode}");
            }
        }
        public static byte[] GenerateReply(DecodeMessage decodeMessage)
        {
            byte[] decodeDg = decodeMessage.Datagram;
            byte[] replyDg = new byte[decodeDg.Length - 1];
            for (int i = 0; i < 11; i++)
            {
                replyDg[i] = decodeDg[i];
            }
            replyDg[11] = 4;
            for (int i = 12; i < 22; i++)
            {
                replyDg[i] = decodeDg[i];
            }
            for (int i = 22; i < replyDg.Length; i++)
            {
                replyDg[i] = decodeDg[i + 1];
            }
            return replyDg;
        }

        public static void InitWorkedDb(Dictionary<string, List<QsoLogEntry>> workedList)
        {
            const string createTable = "Create Table WorkedLocations (" +
                "Callsign varchar(20), StateCountry varchar(64))";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string workedDb = Path.Combine(appDataPath, "CountryState.db");
            string connString = "Data Source = " + workedDb;
            if (!File.Exists(workedDb))
            {
                SQLiteConnection.CreateFile(workedDb);
                _connection = new SQLiteConnection(connString);
                _connection.Open();
                SQLiteCommand createCmd = new SQLiteCommand(createTable, _connection);
                createCmd.ExecuteNonQuery();
            }
            const string getCount = "SELECT COUNT(*) FROM WorkedLocations";
            if (_connection is null)
            {
                _connection = new SQLiteConnection(connString);
                _connection.Open();
            }
            //SQLiteCommand cntCmd = new SQLiteCommand(getCount, _connection);
            //long dbCount = (long)cntCmd.ExecuteScalar();
            string loadCountries = "SELECT * FROM WorkedLocations";
            SQLiteCommand loadCountriesCmd = new SQLiteCommand(loadCountries, _connection);
            SQLiteDataReader reader = loadCountriesCmd.ExecuteReader();
            DataTable countryTable = new DataTable();
            countryTable.Load(reader);
            List<DataRow> countryList = countryTable.AsEnumerable().ToList();
            foreach (DataRow countryStateRow in countryList) 
            {
                string callsign = countryStateRow[0].ToString();
                string countryState = countryStateRow[1].ToString();
                if (!CountryDict.ContainsKey(callsign))
                {
                    CountryDict.Add(callsign, countryState);
                }
                if (countryState.Length > 1)
                {
                    PopulateCountry(callsign, workedList);
                }
            }
            if (CountryDict.Count < workedList.Count)
            {
                string insertCmd =
                    "INSERT INTO WorkedLocations (Callsign, StateCountry) VALUES ";
                foreach (string callsign in workedList.Keys)
                {
                    if (!CountryDict.ContainsKey(callsign))
                    {
                        insertCmd += string.Format(" ('{0}', ','), ", callsign);
                        CountryDict.Add(callsign, ",");
                    }
                }
                insertCmd = insertCmd.Substring(0, insertCmd.Length - 2) + ";";
                SQLiteCommand insCmd = new SQLiteCommand(insertCmd, _connection);
                insCmd.ExecuteNonQuery();
            }
        }

        public static void PopulateCountry(string callsign, Dictionary<string, List<QsoLogEntry>> workedList )
        {

            if (!CountryDict.ContainsKey(callsign)) 
            {
                return;
            }
            string[] stateCountry = CountryDict[callsign].Split(',');
            if (stateCountry.Length == 0)
            {
                return;
            }
            if (!workedList.ContainsKey(callsign))
            {
                return;
            }
            List<QsoLogEntry> logEntries = workedList[callsign];
            if (!string.IsNullOrEmpty(logEntries[0].Country)) 
            {
                return;
            }
            foreach (QsoLogEntry logEntry in logEntries)
            {
                logEntry.State = stateCountry[0];
                logEntry.Country = stateCountry.Length > 1 ? stateCountry[1] : string.Empty;
            }
        }

        public static bool UpdateCountryBatch(Dictionary<string, List<QsoLogEntry>> workedList)
        {
            int numUpdated = 0;
            const int batchsize = 5;
            string updateCmdStr = string.Empty;
            Dictionary<string, string> updateDict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> pair in CountryDict)
            {
                if (pair.Value.Length > 1)
                {
                    continue;
                }
                updateDict.Add(pair.Key, pair.Value);
                if (numUpdated++ >= batchsize)
                {
                    break;
                }
            }
            foreach (KeyValuePair<string, string> pair in updateDict)
            {
                updateCmdStr = UpdateCountryDict(pair.Key, pair.Value, workedList, updateCmdStr);
            }
            if (string.IsNullOrEmpty(updateCmdStr))
            {
                return false;
            }
            using (SQLiteCommand cmdUpdate = new SQLiteCommand(updateCmdStr, _connection))
            {
                cmdUpdate.ExecuteNonQuery();
            }
            return true;
        }

        public static string UpdateCountryDict(
            string callsign, 
            string stateCountry, 
            Dictionary<string, List<QsoLogEntry>> workedList,
            string updateCmdStr)
        {
            if (stateCountry.Length <= 1)
            {
                LookupCallsign(callsign, out string state, out string DXCC, out string country);
                stateCountry = state + ',' + country;
                if (stateCountry.Length <= 1)
                {
                    stateCountry = "?,?";
                }
                CountryDict[callsign] = stateCountry;
                updateCmdStr += string.Format(
                    "UPDATE WorkedLocations SET StateCountry = '{0}' WHERE Callsign = '{1}'; ",
                    stateCountry, callsign);
                foreach (QsoLogEntry entry in workedList[callsign])
                {
                    entry.Country = country;
                    entry.State = state;
                }
            }
            return updateCmdStr;
        }

        public static void UpdateCountryDictEntry(string callsign, Dictionary<string, List<QsoLogEntry>> workedList)
        {
            string updateCmdStr = string.Empty;
            string stateCountry = string.Empty;
            updateCmdStr = UpdateCountryDict(callsign, stateCountry, workedList, updateCmdStr);
            if (!string.IsNullOrEmpty(updateCmdStr)) 
            {
                using (SQLiteCommand cmdUpdate = new SQLiteCommand(updateCmdStr, _connection))
                {
                    cmdUpdate.ExecuteNonQuery();
                }
            }
        }
    }
}
