using System;
using Microsoft.Owin.Hosting;
using System.Net;
using System.Net.Sockets;

namespace ConsoleWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //string baseAddress = "http://" + System.Environment.MachineName + ":9999/";
            string baseAddress = "http://" + GetLocalIPAddress() + ":9999/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("WebAPI hosted at " + baseAddress);
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// get local ip adress
        /// </summary>
        /// <returns>ip address as string</returns>
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
