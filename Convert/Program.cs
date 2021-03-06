﻿using ITass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Convert
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var logs = new List<LogFile>();
                var url = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
                var path = @"d:\agora.txt";

                if (args != null && args.Length == 2)
                {
                    url = args[0];
                    path = args[1];
                }


                var client = new WebClient();
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        ConvertLineToLog(line, logs);
                        Console.WriteLine(line);
                    }

                    var converter = new LogConverter(logs);
                    converter.Write(new AgoraLogWriter(path));
                }

                Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadKey();
            }
        }

        private static void ConvertLineToLog(string line, List<LogFile> logs)
        {
            if (string.IsNullOrEmpty(line))
                throw new Exception("Error reading log file: Invalid line.");

            var data = line.Split('|');
            var responseSize = data[0];
            var statusCode = data[1];
            var cacheStatus = data[2];
            var uriWithHttpVerb = data[3].Split(' ');
            var httpMethod = uriWithHttpVerb[0].Remove(0, 1);
            var uri = uriWithHttpVerb[1];
            var timeTaken = data[4].Split('.')[0];

            logs.Add(new MinhaCDNLog(responseSize, statusCode, cacheStatus, httpMethod, uri, timeTaken));
        }
    }
}
