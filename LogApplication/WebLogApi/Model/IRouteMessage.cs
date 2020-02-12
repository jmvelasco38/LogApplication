using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLogApi.Model
{
    public interface IRouteMessage
    {
        IEnumerable<LoggerResponse> ManaggeMessage(Message message);

    }
}
