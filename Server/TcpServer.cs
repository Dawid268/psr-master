﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class TcpServer
    {
        private TcpListener _server;
        private Boolean _isRunning;

        public TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();

            _isRunning = true;

            LoopClients();
        }

        public void LoopClients()
        {
            while (_isRunning)
            {
                List<Thread> tcpClients = new List<Thread>();
                // wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();
                // client found.
                // create a thread to handle communication
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
                tcpClients.Add(t);
                

                foreach (Thread ttt in tcpClients)
                {
                    for (int i = 0; i > tcpClients.Capacity; i++)
                    {
                        Console.WriteLine(ttt + "i");
                    }
                }
            }
        }

        public void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;

            // sets two streams
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested

            Boolean bClientConnected = true;
            String sData = null;

            while (bClientConnected)
            {
                // reads from stream
                sData = sReader.ReadLine();

                // shows content on the console.
                Console.WriteLine("Client &gt; " + sData);

                // to write something back.
                // sWriter.WriteLine("Meaningfull things here");
                // sWriter.Flush();
            }
        }
    }
}
