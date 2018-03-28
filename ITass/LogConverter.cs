using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITass.Interfaces;

namespace ITass
{
    public class LogConverter
    {
        private readonly List<LogFile> _logFiles;

        public LogConverter(List<LogFile> logs)
        {
            _logFiles = logs;
        }

        public void Write(ILogWriter logWriter)
        {
            logWriter.Write(_logFiles);
        }
    }
}
