using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 首页开发
{
    public partial class PrcOrders : System.Web.UI.Page
    {
        public string wxEditAddrParam { get; set; }
         string goodid="";
         public Goods goods { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            GoodsServer server = new GoodsServer();
            SinglePayServer sinserver = new SinglePayServer();
           
            //string goodid = "";
            Log.Info(this.GetType().ToString(), "page load");
            if (!IsPostBack)
            {
                
                //if (Request["GoodId"] != null){
                //    goodid=Request["GoodId"];
                //    goods = server.GetGoods(goodid);
                //    string price = goods.GPrice.ToString();
                //    string name = goods.GName;
                //    ViewState["goodsprice"] = price;
                //    ViewState["name"] = name;
                //}
                //string GoodId = Request["GoodId"];
                JsApiPay jsApiPay = new JsApiPay(this);
                //jsApiPay.QueryId = GoodId;
                
                try
                {
                    //调用【网页授权获取用户信息】接口获取用户的openid和access_token
                    jsApiPay.GetOpenidAndAccessToken();
                    
                    //获取收货地址js函数入口参数
                    wxEditAddrParam = jsApiPay.GetEditAddressParameters();
                    ViewState["openid"] = jsApiPay.openid;
                    //dic.Add(jsApiPay.openid,goodid);
                }
                catch (Exception ex)
                {
                    Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面加载出错，请重试"+ ex.Message + "</span>");
                    Button1.Visible = false;
                  //  Button2.Visible = false;
                    Label1.Visible = false;
                   // Label2.Visible = false;
                }
                if (Request["count"] != null && ViewState["openid"] != null && Request["GoodId"] != null)
                {
                    SinglePay sin = new SinglePay();
                    sin.OpenID = ViewState["openid"].ToString();
                    sin.GID = Request["GoodId"].ToString();
                    sin.GCount = Convert.ToInt32(Request["count"].ToString());
                    Session["sid"] = sinserver.AddSinglePay(sin);
                    goodid = Request["GoodId"];
                    ViewState["count"] = Request["count"];
                    goods = server.GetGoods(goodid);
                    string price = goods.GPrice.ToString();
                    string name = goods.GName;
                    ViewState["goodsprice"] = price;
                    ViewState["name"] = name;
                }
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string total_fee = "1";
            if (ViewState["openid"] != null&&ViewState["count"]!=null)
            {
                
                string openid = ViewState["openid"].ToString();
                string price = ( Convert.ToDouble( ViewState["goodsprice"].ToString())*100*Convert.ToInt32(ViewState["count"])).ToString();
                string url = "http://www.keaideyibaobao.com/JsApiPayPage.aspx?openid=" + openid + "&total_fee=" + price;
                Response.Redirect(url);
            }
            else
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面缺少参数，请返回重试" + "</span>");
                Button1.Visible = false;
               // Button2.Visible = false;
                Label1.Visible = false;
                //abel2.Visible = false;
            }
        }
    }
}