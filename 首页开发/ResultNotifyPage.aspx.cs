using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace 首页开发
{
    public partial class ResultNotifyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ResultNotify resultNotify = new ResultNotify(this);
            resultNotify.ProcessNotify();
            //wxorderserver server = new wxorderserver();
            //server.AddWxOrder("1", "1", "1", "1", "1", "1", "1", "1", "1", "1, "1", "1", "1");
        }
    }
}