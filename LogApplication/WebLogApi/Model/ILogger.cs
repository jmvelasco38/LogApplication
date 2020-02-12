using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLogApi.Model
{
    interface ILogger
    {
        LoggerResponse LogMessage(Message message);
    }
}
