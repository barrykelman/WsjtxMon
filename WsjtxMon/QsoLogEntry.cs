using ADIFLib;
using M0LTE.WsjtxUdpLib.Messages.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSJTXMon;

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

        public QsoLogEntry(QsoLoggedMessage msg)
        {
            Callsign = msg.DxCall;
            Mode = msg.Mode;
            _date = new DateOnly(msg.DateTimeOn.Year, msg.DateTimeOn.Month, msg.DateTimeOn.Day);
            _time = new TimeOnly(msg.DateTimeOn.Hour, msg.DateTimeOn.Minute, msg.DateTimeOn.Second);
            Frequency = msg.TxFrequency;
            Grid = msg.DxGrid;
            Sent = int.Parse(msg.ReportSent);
            Rcvd = int.Parse(msg.ReportReceived);
            ulong freq = msg.TxFrequency/1000000;
            Band = string.Empty;
            switch (freq)
            {
                case 3:
                    Band = "80m";
                    break;
                case 7:
                    Band = "40m";
                    break;
                case 10:
                    Band = "30m";
                    break;
                case 14:
                    Band = "20m";
                    break;
                case 18:
                    Band = "17m";
                    break;
                case 21:
                    Band = "15m";
                    break;
                case 24:
                    Band = "12m";
                    break;
                case 28:
                    Band = "10m";
                    break;
            }

            State = Country = string.Empty;
        }
    }
}
