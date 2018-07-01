using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Client2
{
    class ClientDemo
    {
        private TcpClient _client;

        private StreamReader _sReader;
        private StreamWriter _sWriter;
        private Boolean _isConnected;
        String ipAddress;
        int port;
        int odp = 0;
        int bWartosc;
        public ClientDemo()
        {
            Console.ReadLine();
            //Console.WriteLine("Podaj addres ip:  ");
            //ipAddress = Console.ReadLine();
            //Console.WriteLine("Podaj port:  ");
            //port = int.Parse(Console.ReadLine());
            //Console.WriteLine("Podaj przedział list:");


            _client = new TcpClient();
            _client.Connect("127.0.0.1", 5000);

            HandleCommunication();
        }

        public void HandleCommunication()
        {
            _sReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
            _sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);

            _isConnected = true;

            NetworkStream stream = _client.GetStream();
            BinaryFormatter formatter = new BinaryFormatter();
            var bin = new BinaryFormatter();
            var list3 = bin.Deserialize(stream);
            Console.WriteLine(list3);
            Console.ReadLine();
            var list2 = (List<Graph.Edge>)bin.Deserialize(stream);
            List<Graph.Edge> edgeList = new List<Graph.Edge>();
            edgeList = list2;
            List<Graph.Node> nodeList = new List<Graph.Node>();
            var ile = bin.Deserialize(stream);
            int znacznik = (int)ile;
            string result;
            Dijkstra dijkstra = new Dijkstra();
            try
            {
                do
                {
                    var list = (List<Graph.Node>)bin.Deserialize(stream);
                    nodeList = list;

                    //List<Graph.Node> rangeNode = nodeList.GetRange(aWartosc, bWartosc);

                    foreach (Graph.Node e in nodeList)
                    {
                        Console.WriteLine(e);
                    }

                    result = dijkstra.shortestPath(nodeList, edgeList);

                    Console.WriteLine(result);
                    formatter.Serialize(stream, result);
                    //Console.ReadLine();

                    //odp = 1;
                    //Console.WriteLine(odp);
                    //formatter.Serialize(stream, odp);
                } while (true);
                var m = bin.Deserialize(stream);
                Console.WriteLine(m);
                stream.Close();

            }
            catch (SystemException e)
            {
                Console.WriteLine(e);
            }



            //foreach (Graph.Edge e in edgeList)
            //{
            //    Console.WriteLine(e);
            //}



        }

    }
}
