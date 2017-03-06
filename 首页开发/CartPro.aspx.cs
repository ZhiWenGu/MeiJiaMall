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
    public partial class CartPro : System.Web.UI.Page
    {
        public List<Goods> Goodslist { get; set; }
        public List<Model.ShoppingCar> Carlist { get; set; }
        public string wxEditAddrParam { get; set; }
        string goodlist = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info(this.GetType().ToString(), "page load");
            if (!IsPostBack)
            {
                

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
                    string openid = jsApiPay.openid;
                    ShoppingCarServer server = new ShoppingCarServer();
                    Carlist = server.QueryShoppingCar(openid);
                    Goodslist = server.QueryGoods(openid);
                    //dic.Add(jsApiPay.openid,goodid);
                    CartOrder car = new CartOrder();
                    car.Openid = ViewState["openid"].ToString();
                    CartOrderServer server1 = new CartOrderServer();
                    Session["glid"] = server1.GetGLid(car);
                    

                }
                catch (Exception ex)
                {
                    Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面加载出错，请重试" + ex.Message + "</span>");
                    Button1.Visible = false;
                    //  Button2.Visible = false;
                    //Label1.Visible = false;
                    // Label2.Visible = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CartOrderServer server1 = new CartOrderServer();
            //server.AddCartOrder(car);
            string price = (server1.AddCartOrder(Session["glid"].ToString()) * 100).ToString();
            string url = "http://www.keaideyibaobao.com/JsApiPayPage.aspx?openid=" + ViewState["openid"].ToString() + "&total_fee="+price;
            Response.Redirect(url);
        }
    }
}