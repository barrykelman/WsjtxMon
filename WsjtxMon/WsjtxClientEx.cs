using M0LTE.WsjtxUdpLib.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WsjtxMon
{
    public class WsjtxClientEx
    {
        private readonly UdpClient udpClient;
        private readonly Action<WsjtxMessage, IPEndPoint> callback;

        public WsjtxClientEx(Action<WsjtxMessage, IPEndPoint> callback, IPAddress ipAddress, int port = 2237)
        {
             udpClient = new UdpClient(new IPEndPoint(ipAddress, port));

            this.callback = callback;
            _ = Task.Run(UdpLoop);
        }


        private void UdpLoop()
        {
            var from = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] datagram = udpClient.Receive(ref from);

                WsjtxMessage msg;

                try
                {
                    msg = WsjtxMessage.Parse(datagram);
                }
                catch (ParseFailureException ex)
                {
                    Console.WriteLine($"Parse failure for {ex.MessageType}: {ex.InnerException.Message}");
                    continue;
                }

                if (msg != null)
                {
                    callback(msg, from);
                }
            }
        }

        public void Send(byte[] datagram, IPEndPoint from)
        {
            udpClient.Send(datagram, datagram.Length, from);
        }

        public void Dispose()
        {
            udpClient.Dispose();
        }
    }
}
