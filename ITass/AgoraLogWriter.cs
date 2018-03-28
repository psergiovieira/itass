using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITass.Interfaces;

namespace ITass
{
    public class AgoraLogWriter : ILogWriter
    {
        private readonly string _path;
        public AgoraLogWriter(string path)
        {
            _path = path;
        }

        public void Write(List<LogFile> logs)
        {
            var text = new StringBuilder();
            text.AppendLine("#Version: 1.0");
            text.AppendLine($"#Date: {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}");
            text.AppendLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");
            foreach (var log in logs)
            {
                var data = $"\"{log.Provider}\" {log.HttpMethod} {log.StatusCode} {log.UriPath} {log.TimeTaken} {log.ResponseSize} {log.CacheStatus}";
                text.AppendLine(data);
            }

            File.WriteAllText(_path,text.ToString());
        }
    }
}
