<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="首页开发.Index" %>

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
        

        <h1 class="am-header-title">
            <a href="#title-link" class="">美甲美睫商城
            </a>
        </h1>

        
    </header>

    <div data-am-widget="slider" class="am-slider am-slider-c2" data-am-slider='{"directionNav":false}' style="margin-top: 49px;">
        <ul class="am-slides">
            <li>
                <img src="pic/LN1.jpg" />
                
                <div class="am-slider-desc">雷尼原创</div>

            </li>
            <li>
                <img src="pic/LN2.jpg" />
                
                <div class="am-slider-desc">某天 也许会相遇 相遇在这个好地方</div>

            </li>
            <li>
                <img src="pic/LN3.jpg" />
                
                <div class="am-slider-desc">不要太担心 只因为我相信 终会走过这条遥远的道路</div>

            </li>
            <li>
                <img src="pic/LN4.jpg" />
               
                <div class="am-slider-desc">OH PARA PARADISE 是否那么重要 你是否那么地遥远</div>

            </li>
        </ul>
    </div>

    <!----------------------内容--------------------------->
    <div data-am-widget="list_news" class="am-list-news am-list-news-default" style="margin-bottom: 37px;">
        <!--列表标题-->
        <div class="am-list-news-hd am-cf">
            <!--带更多链接-->
            <a href="###" class="">
                <h2>最新甲油胶</h2>
                <span class="am-list-news-more am-fr">更多 &raquo;</span>
            </a>
        </div>

        <div class="am-list-news-bd">
            <ul class="am-list">
                <!--缩略图在标题左边-->
                <%foreach (Model.Goods item in goodslist_JYJ)
                  { %>
                <li class="am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-left">
                    <div class="am-u-sm-4 am-list-thumb">
                        <a href="detail.aspx?ID=<%= item.GID %>" class="">
                            <img src="<%=item.Gpicture %>" alt="<%=item.Gdescription %>"" />
                        </a>
                    </div>

                    <div class=" am-u-sm-8 am-list-main" style="float:left;">
                        <h3 class="am-list-item-hd" style="float:left;" ><a href="detail.aspx?ID=<%= item.GID %>" class=""><%=item.GName %></a></h3>

                        <div class="am-list-item-text" style="float:left;clear:left"><%=item.Gdescription %></div>
                        <div class="am-list-item-text" style="float:right;color:#FF0033;font-size:25px;"><%=item.GPrice %></div>
                    </div>
                    
                </li>

                <%} %>

            </ul>
        </div>

    </div>
    <div class="am-btn-group am-btn-group-justify" style="position: fixed; bottom: 0px; width: 100%; height: 45px; margin-top: 45px;">
        <a class="am-btn am-btn-default" role="button"><span class="am-icon-home "></span>&nbsp 首页</a>
        <a class="am-btn am-btn-default" role="button" href="./ShoppingCar.aspx"><span class=" am-icon-cart-plus "></span>&nbsp 购物车</a>
        <a class="am-btn am-btn-default" role="button" href="Finish.aspx"><span class=" am-icon-user "></span>&nbsp 我的</a>
    </div>


    <!--在这里编写你的代码-->

    <!--[if (gte IE 9)|!(IE)]><!-->
    <script src="js/jquery.min.js"></script>

    <script src="http://cdn.amazeui.org/amazeui/2.7.1/js/amazeui.min.js"></script>
</body>
</html>


