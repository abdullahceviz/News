using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.Loging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> logParameters { get; set; }
        public string RemoteIpAddress { get; set; }
        public int? UserId { get; set; }
        public DateTime LogDate { get; set; }
    }
}
