using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Xml;
using System.Web;
using System.Runtime.Serialization.Json;

namespace Graph
{
   public  class TcpClient
{
        System.Net.Sockets.TcpClient newClient;
        Creator creator = new Creator();
        List<Node> newNodes;
        List<Edge> newEdges;
        private TcpListener _server;
        private Boolean _isRunning;
        int pck_number = 0;
        int clients = 0;
        List<Node> divided_list = new List<Node>();
        int x = 0;
        int y = 300;
        public void StartServer(int port )
        {

            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();

            _isRunning = true;
        }
       
        public void Ser(List<Node> o1, List<Edge>o2)
        {

            newNodes = o1;
            newEdges = o2;
        }

        public void LoopClients()
        {
            while (_isRunning)
            {
                
                 newClient = _server.AcceptTcpClient();
                clients++;
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);

            }
        }

        public void HandleClient(object obj)
        {
            try
            {
                
                    System.Net.Sockets.TcpClient client = (System.Net.Sockets.TcpClient)obj;
                    BinaryFormatter formatter = new BinaryFormatter();
                    NetworkStream stream = newClient.GetStream();
                    formatter.Serialize(stream, clients);
                    formatter.Serialize(stream, newEdges);
                    var bin = new BinaryFormatter();
                    int ile  = newNodes.Count();
                    formatter.Serialize(stream, ile);

                    do
                    {
                        pck_number++;
                        Console.WriteLine("Wysyłam paczkę nr: "+pck_number);
                        divided_list = newNodes.GetRange(x, y);
                        formatter.Serialize(stream, divided_list);
                        x += y;
                        var zmienna = bin.Deserialize(stream);

                    }
                    while (x+y <= newNodes.Count());
                    stream.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }

            
        }
    }
}

