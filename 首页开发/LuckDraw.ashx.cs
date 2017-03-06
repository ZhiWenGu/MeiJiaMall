using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace 首页开发
{
    /// <summary>
    /// LuckDraw 的摘要说明
    /// </summary>
    public class LuckDraw : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            if (context.Session["openid"] != null)
            {
                Random r = new Random();
                int k = r.Next(1, 101);
                if (k <= 5)
                {
                    context.Response.Write(1);
                }
                else if (k <= 10)
                    context.Response.Write(2);
                else if (k <= 15)
                    context.Response.Write(3);
                else if (k <= 20)
                    context.Response.Write(4);
                else if (k <= 25)
                    context.Response.Write(5);
                else if (k <= 30)
                    context.Response.Write(6);
                else if (k <= 35)
                    context.Response.Write(7);
                else if (k <= 40)
                    context.Response.Write(8);
                else if (k <= 45)
                    context.Response.Write(8);
                else if (k <= 50)
                    context.Response.Write(10);
                else if (k <= 75)
                    context.Response.Write(11);
                else
                    context.Response.Write(12);
            }
            else
            {
                context.Response.Write(-1);
            }
            
        }


        void InsertData(string openid,string price)
        {

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