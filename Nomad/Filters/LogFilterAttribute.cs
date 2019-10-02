using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Nomad.Filters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Properties.ContainsKey("MS_HttpContext"))
            {
                var result = ((HttpContextBase)actionContext.Request.Properties["MS_HttpContext"]).Request;
                string ip = result.UserHostAddress;
                string hostname = result.UserHostName;
                string url = result.Url.ToString();
            }
            base.OnActionExecuting(actionContext);
        }
    }
}