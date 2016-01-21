using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lmxIpos.Services
{
    /// <summary>
    /// Summary description for ProductSearchForSalebySCID
    /// </summary>
    public class ProductSearchForSalebySCID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}