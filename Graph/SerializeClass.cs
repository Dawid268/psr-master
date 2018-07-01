using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Graph
{

    class SerializeClass
    {

        public  void handle_clients(object o1,object o2)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            // Create a TCP/IP socket.  
            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sender.Connect(localEndPoint);
                Stream stream = new NetworkStream(sender);
                
                var bin = new BinaryFormatter();
                var bin2 = new BinaryFormatter();

                bin.Serialize(stream, o1);
                bin2.Serialize(stream, o2);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }



        }
    }
}













