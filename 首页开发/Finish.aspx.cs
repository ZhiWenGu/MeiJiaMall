using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace 首页开发
{
    public partial class Finish : System.Web.UI.Page
    {
        public List<FinalOrder> fin { get; set; }
        public List<Goods> GoodsList { get; set; }
        wxorderserver server = new wxorderserver();
        protected void Page_Load(object sender, EventArgs e)
        {
            SinglePayServer sserver = new SinglePayServer();
            GoodsServer gserver = new GoodsServer();
            if (Session["openid"] != null)
            {

                string openid = Session["openid"].ToString();
                List<FinalOrder> fin1 = server.QueryFinalOrderList(openid);
                fin = fin1;
                for (int i = 0; i < fin.Count; i++)
                {
                    string trade = fin[i].orderId;
                    string gid = sserver.QueryOrderGidByTrade(trade);
                    Goods g = gserver.GetGoods(gid);
                    GoodsList = new List<Goods>();
                    GoodsList.Add(g);
                }
            }
            else
            {
                Response.Write("./index.aspx");
            }
        }
    }
}