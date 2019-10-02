using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomad.Filters
{
    public class LogHttpHandler: IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
            string RequestedPage = context.Request.Url.Segments[1].ToString().ToLower();
            string queriedRequest = "category1-page";
            bool doesUrlContain = RequestedPage.Equals(queriedRequest);

            if (doesUrlContain)
            {
                context.Response.Redirect(context.Request.Url.Segments[0] + "production" + context.Request.Url.Segments[2]);
            }
        }
    }
}