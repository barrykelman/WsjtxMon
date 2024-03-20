using ADIFLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsjtxMon
{
    public class QsoLogEntry
    {
        private DateOnly _date;
        private TimeOnly _time;
        public DateTime When
        {
            get
            {
                return new DateTime(_date, _time);
            }
        }
        public string Callsign { get; set; }
        public string Mode { get; set; }
        public string Band { get; set; }
        public float Frequency { get; set; }
        public int Rcvd { get; set; }
        public int Sent { get; set; }
        public string Grid { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

        public QsoLogEntry()
        {
            Callsign = Mode = Band = Grid = Country = State = string.Empty;
        }

        public QsoLogEntry(ADIFQSO qso)
        {  
            Callsign = Mode = Grid = Band = Country = State = string.Empty;
            foreach (Token token in qso)
            {
                switch (token.Name) 
                {
                    case "call":
                        Callsign = token.Data;
                        break;
                    case "gridsquare":
                        Grid = token.Data;
                        break;
                    case "mode":
                        Mode = token.Data;
                        break;
                    case "rst_rcvd":
                        Rcvd = int.Parse(token.Data);
                        break;
                    case "rst_sent":
                        Sent = int.Parse(token.Data);
                        break;
                    case "qso_date":
                        int tokenYear = int.Parse(token.Data.Substring(0, 4));
                        int tokenMonth = int.Parse(token.Data.Substring(4, 2));
                        int tokenDay = int.Parse(token.Data.Substring(6, 2));
                        _date = new DateOnly(tokenYear, tokenMonth, tokenDay);
                        break;
                    case "time_on":
                        int tokenHour = int.Parse(token.Data.Substring(0, 2));
                        int tokenMin = int.Parse(token.Data.Substring(2, 2));
                        int tokenSec = int.Parse(token.Data.Substring(4, 2));
                        _time = new TimeOnly(tokenHour, tokenMin, tokenSec);
                        break;
                    case "band":
                        Band = token.Data;
                        break;
                    case "freq":
                        Frequency = float.Parse(token.Data);
                        break;
                }
            }
        }
    }
}
