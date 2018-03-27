using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITass;

namespace Convert
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader minhaCdnLog = new System.IO.StreamReader(@"D:\Temp\minha-cdn.txt");
            while ((line = minhaCdnLog.ReadLine()) != null)
            {
                var data = line.Split('|');
                var responseSize = data[0];
                var statusCode = data[1];
                var cacheStatus = data[2];
                var uriWithHttpVerb = data[3].Split(' ');
                var httpMethod = uriWithHttpVerb[0];
                var uri = uriWithHttpVerb[1];
                var timeTaken = data[4].Split('.')[0];



                var cdnLog = new MinhaCdnRequest(responseSize, statusCode, cacheStatus, httpMethod, uri, timeTaken);
                System.Console.WriteLine(line);
            }

            minhaCdnLog.Close();
            Console.ReadLine();
        }
    }
}
