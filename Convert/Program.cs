using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ITass;

namespace Convert
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logs = new List<LogFile>();
            var url = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split('|');
                    var responseSize = data[0];
                    var statusCode = data[1];
                    var cacheStatus = data[2];
                    var uriWithHttpVerb = data[3].Split(' ');
                    var httpMethod = uriWithHttpVerb[0].Remove(0, 1);
                    var uri = uriWithHttpVerb[1];
                    var timeTaken = data[4].Split('.')[0];

                    logs.Add(new MinhaCDNLog(responseSize, statusCode, cacheStatus, httpMethod, uri, timeTaken));
                    Console.WriteLine(line);
                }

                var converter = new LogConverter(logs);
                converter.Write(new AgoraLogWriter(@"d:\agora.txt"));
            }

            Console.ReadLine();
        }
    }
}
