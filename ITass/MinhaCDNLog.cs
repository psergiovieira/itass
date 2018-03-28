using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITass
{
    public class MinhaCDNLog : LogFile
    {
        private const string _provider = "MINHA CDN";
        public MinhaCDNLog(string responseSize, string statusCode, string cacheStatus, string httpMethod, string uriPath,
            string timeTaken) : base(responseSize, statusCode, cacheStatus, httpMethod, uriPath, timeTaken, _provider)
        {
        }
    }
}
