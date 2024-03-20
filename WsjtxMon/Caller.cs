using M0LTE.WsjtxUdpLib.Messages.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WSJTXMon
{
    public class Caller : ICaller
    {
        private TimeSpan age;
        public string CallSign { get; set; }
        public string Calling { get; set; }
        public string Grid { get; set; }
        public string DXCC { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int Db { get; set; }
        public TimeSpan Age
        {
            get { return age; }
            set { age = value; }
        }
        public string AgeText
        {
            get
            {
                int min = age.Minutes;
                int sec = age.Seconds;
                string ageText = min.ToString() + ":" + sec.ToString("D2");
                return ageText;
            }
        }
        public DecodeMessage Message { get; set; }
        public Caller(string callsign, DecodeMessage message)
        {
            string[] callParams = message.Message.Split(' ');
            NetFuncs.LookupCallsign(callsign, out string state, out string dxcc, out string country);
            CallSign = callsign;
            Calling = message.Message;
            Grid = callParams.Length > 2 ? callParams[callParams.Length-1] : string.Empty;
            State = state;
            DXCC = dxcc;
            Country = country;
            Db = message.Snr;
            Age = new TimeSpan(0);
            Message = message;
        }

        public Caller()
        {
            CallSign = string.Empty;
            Calling = string.Empty;
            Grid = string.Empty;
            State = string.Empty;
            DXCC = string.Empty;
            Country = string.Empty;
            Message = new DecodeMessage();
        }
    }
}
