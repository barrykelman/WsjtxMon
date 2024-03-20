using M0LTE.WsjtxUdpLib.Messages.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSJTXMon
{
    public interface ICaller
    {
        string CallSign { get; set; }
        string Calling { get; set; }
        string Grid { get; set; }
        string DXCC { get; set; }
        string Country { get; set; }
        string State { get; set; }
        int Db {  get; set; }
        TimeSpan Age { get; set; }
        string AgeText { get; }
        DecodeMessage Message { get; set; }
    }
}
