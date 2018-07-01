using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Drawing;
using Graph;

namespace Client
{
    class SocketClient
    {
        public  void StartClient()
        {

            byte[] bytes = new byte[1024];
            try
            {
                // Establish the remote endpoint for the socket.  

                // This example uses port 11000 on the local computer.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    int bytesRec = sender.Receive(bytes);
                    using (MemoryStream ms = new MemoryStream(bytesRec))
                    {
                        IFormatter br = new BinaryFormatter();
                        Edge edge= (Edge)br.Deserialize(ms);
                        Console.WriteLine("Edges {0}", edge);
                        }
                }
                catch (Exception e)
                {

                }
               }
                 catch (Exception e)
            {

            }
        }
    } 
 
}
