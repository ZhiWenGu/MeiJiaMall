using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 首页开发
{
    /// <summary>
    /// UpdateAdd 的摘要说明
    /// </summary>
    public class UpdateAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Request["name"] != null && context.Request["tel"] != null && context.Request["address"] != null && context.Request["glid"] != null)
            {
                try
                {
                    BLL.CartOrderServer server = new BLL.CartOrderServer();
                    server.UpdateCartOrder(context.Request["glid"].ToString(), context.Request["address"].ToString(), context.Request["tel"].ToString(), context.Request["name"].ToString());
                    context.Response.Write(1);
                }
                catch
                {
                    context.Response.Write(0);
                }
            }
            else
            {
                context.Response.Write(-1);//this mean lack params
            }
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