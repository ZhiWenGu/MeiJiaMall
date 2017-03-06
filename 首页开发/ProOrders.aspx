<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProOrders.aspx.cs" Debug="true" Inherits="首页开发.PrcOrders" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/> 
    <title>微信支付样例-JSAPI支付</title>
    <script src="js/jquery.min.js"></script>
</head>

       <script type="text/javascript">
           //获取共享地址
           function editAddress()
           {
               WeixinJSBridge.invoke(
                   'editAddress',
                   <%=wxEditAddrParam%>,//josn串
                   function (res)
                   {
                       var name = res.userName;
                       var addr1 = res.proviceFirstStageName;
                       var addr2 = res.addressCitySecondStageName;
                       var addr3 = res.addressCountiesThirdStageName;
                       var addr4 = res.addressDetailInfo;
                       var tel = res.telNumber;
                       var addr = addr1+ addr2 + addr3 + addr4;
                       $("#addr").html(addr);
                       $("#name").html(name);
                       $("#phone").html(tel);
                       $.post("./updateadd1.ashx",{
                           'tel':tel,
                           'name':name,
                           'address':addr,
                           'sid':'<%=Session["sid"].ToString()%>'
                       },function(data){
                           if(data!=1){
                               alert('出现未知错误');
                           }
                           
                       })
                   }
               );
         }

         window.onload = function ()
         {
             if (typeof WeixinJSBridge == "undefined")
             {
                 if (document.addEventListener)
                 {
                     document.addEventListener('WeixinJSBridgeReady', editAddress, false);
                 }
                 else if (document.attachEvent)
                 {
                     document.attachEvent('WeixinJSBridgeReady', editAddress);
                     document.attachEvent('onWeixinJSBridgeReady', editAddress);
                 }
             }
             else
             {
                 editAddress();
             }

             
         };

	    </script>

<body>
    <form runat="server">
        <br/>
        <div>
            <asp:Label ID="Label1" runat="server" style="color:#00CD00;"><b><%=ViewState["name"].ToString() %>：价格为<span style="color:#f00;font-size:50px"><%=ViewState["goodsprice"].ToString() %> *<%=ViewState["count"].ToString() %>=<%=Convert.ToDouble(ViewState["goodsprice"])*Convert.ToInt32(ViewState["count"]) %>
                </span>钱</b></asp:Label><br/><br/>
        </div>
	    <div align="center">
            <asp:Button ID="Button1" runat="server" Text="立即购买" style="width:210px; height:50px; border-radius: 15px;background-color:#00CD00; border:0px #FE6714 solid; cursor: pointer;  color:white;  font-size:16px;" OnClick="Button1_Click" />
	    </div>
        <br/><br/><br/>
        <hr style="width:100%;" />
        <label>姓名：</label><label id="name"></label><br />
        <label>地址：</label><label id="addr"></label><br />
        <label>电话：</label><label id="phone"></label><br />
    </form>
</body>
</html>
