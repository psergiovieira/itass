using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITass.Interfaces;

namespace ITass
{
    public abstract class LogFile
    {
        private int _responseSize;
        private int _statusCode;
        private string _cacheStatus;
        private string _httpMethod;
        private string _uriPath;
        private int _timeTaken;
        private string _provider;

        protected LogFile(string responseSize, string statusCode, string cacheStatus, string httpMethod,
                            string uriPath, string timeTaken, string provider)
        {
            _responseSize = Convert.ToInt32(responseSize);
            _statusCode = Convert.ToInt32(statusCode);
            _cacheStatus = cacheStatus;
            _httpMethod = httpMethod;
            _uriPath = uriPath;
            _timeTaken = Convert.ToInt32(timeTaken);
            _provider = provider;
        }

        public int ResponseSize
        {
            get { return _responseSize; }
        }

        public int StatusCode
        {
            get { return _statusCode; }
        }

        public string CacheStatus
        {
            get { return _cacheStatus; }
        }

        public string HttpMethod
        {
            get { return _httpMethod; }
        }

        public string UriPath
        {
            get { return _uriPath; }
        }

        public int TimeTaken
        {
            get { return _timeTaken; }
        }

        public string Provider
        {
            get { return _provider; }
        }
    }
}
