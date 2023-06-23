using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.Logging.Log4Net
{
    [Serializable]
    public class SerailizableLogEvent
    {
        private LoggingEvent _loggingEvent;
        public SerailizableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public object Message => _loggingEvent.MessageObject;
    }
}
