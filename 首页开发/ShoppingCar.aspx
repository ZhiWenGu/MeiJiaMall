<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCar.aspx.cs" Inherits="首页开发.ShoppingCar" %>

<!doctype html>
<html class="no-js">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="viewport"
        content="width=device-width, initial-scale=1">
    <title>杰森美甲商城</title>

    <!-- Set render engine for 360 browser -->
    <meta name="renderer" content="webkit">

    <!-- No Baidu Siteapp-->
    <meta http-equiv="Cache-Control" content="no-siteapp" />

    <link rel="icon" type="image/png" href="i/favicon.png">

    <!-- Add to homescreen for Chrome on Android -->
    <meta name="mobile-web-app-capable" content="yes">
    <link rel="icon" sizes="192x192" href="i/app-icon72x72@2x.png">

    <!-- Add to homescreen for Safari on iOS -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="apple-mobile-web-app-title" content="Amaze UI" />
    <link rel="apple-touch-icon-precomposed" href="i/app-icon72x72@2x.png">

    <!-- Tile icon for Win8 (144x144 + tile color) -->
    <meta name="msapplication-TileImage" content="i/app-icon72x72@2x.png">
    <meta name="msapplication-TileColor" content="#0e90d2">
   <%-- http://cdn.amazeui.org/amazeui/2.7.1/css/amazeui.css
http://cdn.amazeui.org/amazeui/2.7.1/css/amazeui.min.css
http://cdn.amazeui.org/amazeui/2.7.1/js/amazeui.js
http://cdn.amazeui.org/amazeui/2.7.1/js/amazeui.min.js
http://cdn.amazeui.org/amazeui/2.7.1/js/amazeui.ie8polyfill.js
http://cdn.amazeui.org/amazeui/2.7.1/js/amazeui.ie8polyfill.min.js
http://cdn.amazeui.org/amazeui/2.7.1/js/amazeui.widgets.helper.js
http://cdn.amazeui.org/amazeui/2.7.1/js/amazeui.widgets.helper.min.js--%>
    <link rel="stylesheet" href="http://cdn.amazeui.org/amazeui/2.7.1/css/amazeui.css">
    <link rel="stylesheet" href="css/app.css">
    <style>
        [class*='am-icon-']:before {
            display: inline-block;
            font: normal normal normal 14px/1 FontAwesome;
            font-size: inherit;
            text-rendering: auto;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }
    </style>
</head>
<body>
    <header data-am-widget="header"
        class="am-header am-header-default" style="position: fixed; top: 0px; z-index: 66;">
        <div class="am-header-left am-header-nav">
            <a href="Index.aspx" class="">

                <i class="am-header-icon am-icon-home"></i>
            </a>
        </div>

        <h1 class="am-header-title">
            <a href="#title-link" class="">美甲美睫商城
            </a>
        </h1>

        
    </header>
    <!----------------------内容--------------------------->
    <div data-am-widget="list_news" class="am-list-news am-list-news-default" style="margin-bottom: 37px;">
        <!--列表标题-->
        <div class="am-list-news-hd am-cf">
            <!--带更多链接-->
            <a href="###" class="">
                <h2>左图 + 摘要</h2>
                <span class="am-list-news-more am-fr">更多 &raquo;</span>
            </a>
        </div>

        <div class="am-list-news-bd">
            <ul class="am-list">
                <!--缩略图在标题左边-->
                <%
                    double sum = 0;
                    for (int i = 0; i < Goodslist.Count; i++)
                    { %>
                <li class="am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-left">
                    <div class="am-u-sm-4 am-list-thumb">
                        <a href="detail.aspx?ID=<%= Goodslist[i].GID%>" class="">
                            <img src="<%=Goodslist[i].Gpicture%>" alt="<%=Goodslist[i].Gdescription%>"" />
                        </a>
                    </div>

                    <div class=" am-u-sm-8 am-list-main" style="float:left;">
                        <h3 class="am-list-item-hd" style="float:left;" ><a href="detail.aspx?ID=<%= Goodslist[i].GID%>" class=""><%=Goodslist[i].GName%></a></h3>

                        <div class="am-list-item-text" style="float:left;clear:left"><%=Goodslist[i].Gdescription%></div>
                        <div class="am-list-item-text" style="float:right;color:#FF0033;font-size:25px;"><%=Goodslist[i].GPrice%>*<%=Carlist[i].SCount%>=<%=Goodslist[i].GPrice*Carlist[i].SCount %></div>
                        <% sum += Goodslist[i].GPrice * Carlist[i].SCount; %>
                    </div>
                    <hr />

                    
                </li>
                <%} %>

            </ul>
            
            <button class="am-btn-warning" style="position:fixed;bottom:45px;margin-top: 90px;clear:both;left:0px;width:100%;height:40px;" onclick="transFer()"><span>总价：</span><span><%=sum %></span></button>
            <script>
                function transFer() {
                    window.location.href = './cartpro.aspx';
                }
            </script>
        </div>

    </div>
    <div class="am-btn-group am-btn-group-justify" style="position: fixed; bottom: 0px; width:100%; height: 45px; margin-top: 90px;">
        <a class="am-btn am-btn-default" href="Index.aspx" role="button"><span class="am-icon-home "></span>&nbsp 首页</a>
        <a class="am-btn am-btn-default" href="#" role="button"><span class=" am-icon-cart-plus "></span>&nbsp 购物车</a>
        <a class="am-btn am-btn-default" href="Finish.aspx" role="button"><span class=" am-icon-user "></span>&nbsp 我的</a>
    </div>


    <!--在这里编写你的代码-->

    <!--[if (gte IE 9)|!(IE)]><!-->
    <script src="js/jquery.min.js"></script>

    <script src="http://cdn.amazeui.org/amazeui/2.7.1/js/amazeui.min.js"></script>
</body>
</html>
