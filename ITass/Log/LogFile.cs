using System;

namespace ITass
{
    public abstract class LogFile
    {
        public int ResponseSize { get; }

        public int StatusCode { get; }

        public string CacheStatus { get; }

        public string HttpMethod { get; }

        public string UriPath { get; }

        public int TimeTaken { get; }

        public string Provider { get; }

        protected LogFile(string responseSize, string statusCode, string cacheStatus, string httpMethod,
            string uriPath, string timeTaken, string provider)
        {
            ResponseSize = Convert.ToInt32(responseSize);
            StatusCode = Convert.ToInt32(statusCode);
            CacheStatus = cacheStatus;
            HttpMethod = httpMethod;
            UriPath = uriPath;
            TimeTaken = Convert.ToInt32(timeTaken);
            Provider = provider;
        }
    }
}