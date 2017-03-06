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
    public partial class ShoppingCar : System.Web.UI.Page
    {
        public List<Goods> Goodslist { get; set; }
        public List<Model.ShoppingCar> Carlist { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["openid"] != null)
            {
                string openid = Session["openid"].ToString();
                ShoppingCarServer server = new ShoppingCarServer();
                Carlist = server.QueryShoppingCar(openid);
                Goodslist = server.QueryGoods(openid);
            }
            else
            {
                Response.Redirect("./index.aspx");
            }
        }
    }
}