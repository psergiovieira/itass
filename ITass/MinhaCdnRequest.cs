using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITass
{
    public class MinhaCdnRequest
    {
        private int _responseSize;
        private int _statusCode;
        private string _cacheStatus;
        private string _httpMethod;
        private string _uriPath;
        private int _timeTaken;
        private const string _provider = "MINHA CDN";


        public MinhaCdnRequest(string responseSize, string statusCode, string cacheStatus, string httpMethod,
                                string uriPath, string timeTaken)
        {
            _responseSize = Convert.ToInt32(responseSize);
            _statusCode = Convert.ToInt32(statusCode);
            _cacheStatus = cacheStatus;
            _httpMethod = httpMethod;
            _uriPath = uriPath;
            _timeTaken = Convert.ToInt32(timeTaken);
        }

        public string AgoraFormat()
        {
            return $"\"{_provider}\" {_httpMethod} {_statusCode} {_uriPath} {_timeTaken} {_responseSize} {_cacheStatus}";
        }
    }
}
