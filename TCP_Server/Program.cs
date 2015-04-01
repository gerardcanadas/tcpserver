using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_Server.TCP_Server;
using TCP_Server.Logger;

namespace TCP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServer_Logger.ReadLog(1);
        }

        static void InitTCPServer()
        {
            Console.WriteLine("... Starting server...");
            AsyncSocketListener.StartListening();
        }
    }
}
