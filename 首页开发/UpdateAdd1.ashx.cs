using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 首页开发
{
    /// <summary>
    /// UpdateAdd1 的摘要说明
    /// </summary>
    public class UpdateAdd1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["name"] != null && context.Request["tel"] != null && context.Request["address"] != null && context.Request["sid"] != null)
            {
                try
                {
                    BLL.SinglePayServer server = new BLL.SinglePayServer();
                    server.UpdateSinglePay(context.Request["sid"].ToString(), context.Request["address"].ToString(), context.Request["tel"].ToString(), context.Request["name"].ToString());
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