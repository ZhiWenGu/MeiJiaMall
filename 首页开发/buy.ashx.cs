using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using BLL;

namespace 首页开发
{
    /// <summary>
    /// buy 的摘要说明
    /// </summary>
    public class buy : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Request["count"] != null && context.Request["openid"] != null && context.Request["GId"] != null)
            {
                Model.ShoppingCar car = new Model.ShoppingCar();
                car.SCount = Convert.ToInt32(context.Request["count"]);
                car.UID= context.Request["openid"].ToString();
                car.GID = context.Request["GId"].ToString();
                car.SPay = 0;
                ShoppingCarServer server = new ShoppingCarServer();
                try
                {
                    server.AddShoppingCar(car);
                    context.Response.Write(1);
                }
                catch (Exception )
                {

                    context.Response.Write(0);
                }
            }
            else
            {
                context.Response.Write(-1);
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