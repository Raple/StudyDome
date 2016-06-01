using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Easy.Public;
using Easy.Public.MyLog;
using Easy.Rpc.directory;
using Easy.Rpc.Monitor;
using Microsoft.Owin.Hosting;
using System.Configuration;

namespace StudyDome.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = ConfigurationManager.AppSettings["ServiceAddress"];
            using (WebApp.Start<Startup>(new StartOptions(baseUrl)))
            {
                System.Console.WriteLine("服务启动中...");
                while (true)
                {
                    Thread.Sleep(80000012);
                }
            }
        }
    }
}
