using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITass.Interfaces
{
    public interface ILogWriter
    {
        void Write(List<LogFile> logs);
    }
}
