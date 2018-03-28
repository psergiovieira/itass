using System.Collections.Generic;

namespace ITass.Interface
{
    public interface ILogWriter
    {
        void Write(IList<LogFile> logs);
    }
}
