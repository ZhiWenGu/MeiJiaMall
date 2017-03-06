<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPro.aspx.cs" Inherits="首页开发.CartPro" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="http://cdn.amazeui.org/amazeui/2.7.1/css/amazeui.css" rel="stylesheet" />
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
                       $.post("./updateadd.ashx",{
                           'tel':tel,
                           'name':name,
                           'address':addr,
                           'glid':'<%=Session["glid"].ToString()%>'
                       },function(data){
                           if(data!=1){
                               alert('出现未知错误');
                           }
                           
                        })
                      // alert(addr + ":" + tel);
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
        <br />
        <table class="am-table">
            <thead>
                <tr>
                    <th>商品名称</th>
                    <th>单价</th>
                    <th>数量</th>
                    <th>总计</th>
                </tr>
            </thead>
            <tbody>
                <%
                    if (Goodslist != null && Carlist != null)
                    {
                        
                        for (int i = 0; i < Goodslist.Count; i++)
                        { %>
                <tr>
                    <td><%=Goodslist[i].GName %></td>
                    <td><%=Goodslist[i].GPrice %></td>
                    <td><%=Carlist[i].SCount %></td>
                    <td><%=Goodslist[i].GPrice*Carlist[i].SCount %></td>
                </tr>
                <%
                       
                    }
                    }%>
            </tbody>
        </table>
        <div align="center">
            <asp:Button ID="Button1" runat="server" Text="立即购买" Style="width: 210px; height: 50px; border-radius: 15px; background-color: #00CD00; border: 0px #FE6714 solid; cursor: pointer; color: white; font-size: 16px;" UseSubmitBehavior="false" OnClick="Button1_Click" />
        </div>
        <br />
        <br />
        <br />
        <hr style="width: 100%;" />
        <label>姓名：</label><label id="name"></label><br />
        <label>地址：</label><label id="addr"></label><br />
        <label>电话：</label><label id="phone"></label><br />
    </form>
</body>
</html>
