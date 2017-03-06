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
    public partial class Detail : System.Web.UI.Page
    {
        public Goods goods { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Id"] != null&&Session["openid"]!=null)
            {
                GoodsServer server = new GoodsServer();
                string Id = Request["Id"].ToString();
                goods = server.GetGoods(Id);
            }
            else
            {
                Response.Redirect("./Index.aspx");
            }
        }
    }
}