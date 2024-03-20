using M0LTE.WsjtxUdpLib.Messages.Out;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
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
        private static string _session = string.Empty;
        private static HttpClient _client = new HttpClient();
        private static XNamespace _ns;
        const string QrzQueryUrl = "https://xmldata.qrz.com/xml/current/?";
        const string QrzLogUrl = "https://logbook.qrz.com/api";
        public static void LookupCallsign(string callsign, out string state, out string DXCC, out string country)
        {
            if (string.IsNullOrEmpty(_session))
            {
                string url = QrzQueryUrl + string.Format("username={0};password={1}", WsjtxResource.QrzUser, WsjtxResource.QrzPassword);
                var response = _client.GetAsync(url).Result;
                var xmlText = response.Content.ReadAsStringAsync().Result;
                XElement qrzEle = XElement.Parse(xmlText);
                _ns = qrzEle.GetDefaultNamespace();
                _session = qrzEle.Element(_ns + "Session").Element(_ns + "Key").Value;
            }
            string lookupUrl = QrzQueryUrl + string.Format("s={0};callsign={1}", _session, callsign);
            var lookupResponse = _client.GetAsync(lookupUrl).Result;
            var lookupText = lookupResponse.Content.ReadAsStringAsync().Result;
            XElement lookupEle = XElement.Parse(lookupText);
            XElement callsignEle = lookupEle.Element(_ns + "Callsign");
            state = DXCC = country = string.Empty;
            if (callsignEle != null)
            {
                XElement stateEle = callsignEle.Element(_ns + "state");
                if (stateEle is not null)
                {
                    state = stateEle.Value;
                }

                XElement dXCCEle = callsignEle.Element(_ns + "dxcc");
                if (dXCCEle is not null)
                {
                    DXCC = dXCCEle.Value;
                }
                XElement landEle = callsignEle.Element(_ns + "land");
                if (landEle is not null)
                {
                    country = landEle.Value;
                }
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
    }
}
