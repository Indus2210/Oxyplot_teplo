using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oxyplot_teplo
{
    public interface ILogger
    {
        void Log(LogEntry entry);
    }
}
