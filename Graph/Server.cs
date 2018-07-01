//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Sockets;
//using System.Text;

//namespace Graph
//{
//    class Server
//    {
//        public void start()
//        {
//            TcpClient clientSocket = default(TcpClient);
//            int counter = 0;

//            serverSocket.Start();
//            counter = 0;
//            while (true)
//            {
//                counter += 1;
//                clientSocket = serverSocket.AcceptTcpClient();
//                Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
//                SerializeClass client = new SerializeClass();
//                client.startClient(clientSocket, Convert.ToString(counter));
//            }

//            clientSocket.Close();
//            serverSocket.Stop();
//            Console.WriteLine(" >> " + "exit");
//            Console.ReadLine();
//        }
//    }
        
//    }
//}
