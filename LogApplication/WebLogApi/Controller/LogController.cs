using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebLogApi.Model;

namespace WebLogApi.Controller
{
    public class LogController : ApiController
    {
        private IRouteMessage routeMessage = null;

        public LogController(IRouteMessage route)
        {
            routeMessage = route;
        }
        public string Get()
        {
            return "ola ke ase";
        }

        public IHttpActionResult Post(Message message)
        {
            IEnumerable<LoggerResponse> loggerResponses = routeMessage.ManaggeMessage(message);
            if(loggerResponses.Count() <= 0)
            {
                return InternalServerError(new Exception("Invalid Configuration"));
            }
            else
            {
                return Ok(loggerResponses);
            }
        }
    }
}
