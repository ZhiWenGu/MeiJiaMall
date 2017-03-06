using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 首页开发
{
    public partial class Charactertest : System.Web.UI.Page
    {
        public static bool IsLoad = false;
        public int[] list { get; set; }
        public int sum;
        public int[] list1 = new int[9];
        //public static string wxEditAddrParam { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info(this.GetType().ToString(), "page load");
            #region 预加载处理
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
                    //Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面加载出错，请重试" + ex.Message + "</span>");

                }

            }
            #endregion
            else
            {
                Random r = new Random();
                if (Request["user-sex"] == null || Request["user-name"] == null)
                {
                    // Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面加载出错~~~" + "</span>");
                    return;
                }
                string test = "";
                if (!string.IsNullOrEmpty(Request["user-sex"]) || !string.IsNullOrEmpty(Request["user-name"]))
                {
                    string sex = Request["user-sex"];
                    string name = Request["user-name"];
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (business.SqlServer.IsContain(name[i] + sex))
                        {
                            business.SqlServer.Search(name[i] + sex);
                            int[] temp = business.SqlServer.Search(name[i] + sex);
                            for (int j = 0; j < list1.Length; j++)
                            {
                                list1[j] += temp[j];

                            }
                        }
                        else
                        {

                            int[] temp = new int[9];
                            for (int j = 0; j < list1.Length; j++)
                            {
                                temp[j] = r.Next(40, 120);
                                if (temp[j] >= 100)
                                    temp[j] = 100;
                                list1[j] += temp[j];

                            }
                            business.SqlServer.Add(name[i] + sex, temp);

                        }
                    }

                    sum = 0;
                    list = list1;
                    for (int j = 0; j < list1.Length; j++)
                    {
                        list[j] = list1[j] / name.Length;
                        sum += list[j];
                    }
                    sum = sum / 9;
                    IsLoad = true;
                    if (name == "纪春光")
                    {
                        for (int j = 0; j < list.Length; j++)
                        {
                            list[j] = r.Next(98, 101);
                            sum = 99;
                        }
                    }
                }

            }
        }
    }
}