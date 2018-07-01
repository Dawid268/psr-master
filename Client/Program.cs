using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
           
                Console.WriteLine("Client");
                SocketClient socketClient = new SocketClient();
                socketClient.StartClient();
                Console.ReadLine();
            
          

           
        }
    }
}
