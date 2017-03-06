using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace 首页开发
{
    public partial class Index : System.Web.UI.Page
    {
        //public static int k = 0;
        public List<Goods> goodslist_JYJ { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GoodsServer server = new GoodsServer();
                goodslist_JYJ = server.GetGoodsList("JYJ");
                JsApiPay jsApiPay = new JsApiPay(this);
                jsApiPay.GetOpenidAndAccessToken();
                Session["openid"] = jsApiPay.openid;
            }
            
        }
    }
}