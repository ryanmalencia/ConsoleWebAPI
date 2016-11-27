using System;
using Microsoft.Owin.Hosting;
using System.Net;
using System.Net.Sockets;
using NetFwTypeLib;

namespace ConsoleWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //string baseAddress = "http://" + System.Environment.MachineName + ":9999/";
            string baseAddress = "http://" + GetLocalIPAddress() + ":9999/";
            AllowPortAccess();
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

        public static void AllowPortAccess()
        {
            INetFwMgr icfMgr = null;
            try
            {
                Type TicfMgr = Type.GetTypeFromProgID("HNetCfg.FwMgr");
                icfMgr = (INetFwMgr)Activator.CreateInstance(TicfMgr);
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                INetFwProfile profile;
                INetFwOpenPort portClass;
                Type TportClass = Type.GetTypeFromProgID("HNetCfg.FWOpenPort");
                portClass = (INetFwOpenPort)Activator.CreateInstance(TportClass);

                // Get the current profile
                profile = icfMgr.LocalPolicy.CurrentProfile;

                // Set the port properties
                portClass.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
                portClass.Enabled = true;
                portClass.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                portClass.Name = "ConsoleWebAPI";
                portClass.Port = 9999;

                // Add the port to the ICF Permissions List
                profile.GloballyOpenPorts.Add(portClass);
                return;
            }
            catch (Exception)
            {

            }
        }
    }
}
