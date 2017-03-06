using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 首页开发
{
    public partial class LotteryDraw : System.Web.UI.Page
    {
        bool IsLoad = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                IsLoad = false;
                JsApiPay jsApiPay = new JsApiPay(this);
                try
                {
                    //定义一个回调地址 
                    //ViewState["callbackurl"] = "http://keaideyibaobao.com/charactertest.aspx";

                    //调用【网页授权获取用户信息】接口获取用户的openid和access_token
                    jsApiPay.GetOpenidAndAccessToken();

                    //获取收货地址js函数入口参数
                    //wxEditAddrParam = jsApiPay.GetEditAddressParameters();
                    ViewState["openid"] = jsApiPay.openid;
                    //ViewState["access_token"] = jsApiPay.access_token;
                    string resToken = HttpService.Get("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxcaf17959e7a40461&secret=d6e05480d9cebeecd672e08d84dd3737");

                    LitJson.JsonData jdata = LitJson.JsonMapper.ToObject(resToken);

                    WxPayData data = new WxPayData();
                    data.SetValue("access_token", jdata["access_token"]);
                    data.SetValue("openid", jsApiPay.openid);

                    string url = "https://api.weixin.qq.com/cgi-bin/user/info?" + data.ToUrl();
                    string result = HttpService.Get(url);
                    jdata = LitJson.JsonMapper.ToObject(result);
                    if (!string.IsNullOrEmpty(jdata["subscribe"].ToString()))
                    {
                        if (jdata["subscribe"].ToString() == "1")
                        {
                            Session["openid"] = jsApiPay.openid;
                            //关注该公众账号，进行推荐处理
                            if (Request["reference"] != null)
                            {                                
                                string reference = Request["reference"].ToString();

                            }
                            //Response.Write("<span style='color:#FF0000;font-size:20px'>" + "您已关注本公众号" + "</span>");
                        }
                        else
                        {
                            Response.Write("<script>alert('您尚未关注该公众号')</script>");
                            // Response.Write("<script>window.location.href='weixin://weixin.qq.com/r/dz8fB6zE8fGOrehk92pl';</script>");
                            Server.Transfer("./pic.aspx");
                            return;
                        }
                    }

                    //Response.Write("<span style='color:#FF0000;font-size:20px'>" + result + jsApiPay.openid + "</span>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('系统出了点小问题，请您稍后再试')");

                }
            }
            
        }
    }
}