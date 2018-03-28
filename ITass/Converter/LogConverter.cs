using ITass.Interface;
using System.Collections.Generic;

namespace ITass
{
    public class LogConverter
    {
        private readonly IList<LogFile> _logFiles;

        public LogConverter(IList<LogFile> logs)
        {
            _logFiles = logs;
        }

        public void Write(ILogWriter logWriter)
        {
            logWriter.Write(_logFiles);
        }
    }
}
