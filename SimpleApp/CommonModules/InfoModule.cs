using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonModules
{
    public class InfoModule:IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += (src, args) =>
            {
                HttpContext ctx = HttpContext.Current;
                ctx.Response.Write(
                    $"<div class='alert alert-success'>URL: {ctx.Request.RawUrl} Status: {ctx.Response.StatusCode}</div>");
            };
        }

        public void Dispose()
        {
            // do nothing - no resources to release
        }
    }
}
