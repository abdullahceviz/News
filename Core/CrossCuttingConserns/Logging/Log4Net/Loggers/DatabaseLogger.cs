using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.Loging.Log4Net.Loggers
{
    public class DatabaseLogger:LoggerServiceBase
    {
        public DatabaseLogger():base("DatabaseLogger")
        {

        }
    }
}
