<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="首页开发.Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/main.css" rel="stylesheet" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="viewport"
        content="width=device-width, initial-scale=1">
    <title>商品名称</title>

    <!-- Set render engine for 360 browser -->
    <meta name="renderer" content="webkit" />

    <!-- No Baidu Siteapp-->
    <meta http-equiv="Cache-Control" content="no-siteapp" />

    <link rel="icon" type="image/png" href="i/favicon.png" />

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

    <link rel="stylesheet" href="css/amazeui.min.css">
    <link rel="stylesheet" href="css/app.css">
</head>
<body>
     <header data-am-widget="header"
        class="am-header am-header-default" style="position: fixed; top: 0px; z-index: 66;background-color:#FF6600">
        <div class="am-header-left am-header-nav">
            <a href="./index.aspx" class="">

                <i class="am-header-icon am-icon-chevron-circle-left"></i>
            </a>
        </div>

        <h1 class="am-header-title">
            <a href="#title-link" class=""><%=goods.GName %>
            </a>
        </h1>

        
    </header>
    <div>
        <div data-am-widget="slider" class="am-slider am-slider-default" style="margin-bottom: 5px;" data-am-slider='{"animation":"slide","controlNav":"thumbnails"}'>
            <ul class="am-slides">
                <li data-thumb="pic/LN1.jpg">
                    <img src="pic/LN1.jpg">
                </li>
                <li data-thumb="pic/LN2.jpg">
                    <img src="pic/LN2.jpg">
                </li>
                <li data-thumb="pic/LN3.jpg">
                    <img src="pic/LN3.jpg">
                </li>
                <li data-thumb="pic/LN4.jpg">
                    <img src="pic/LN4.jpg">
                </li>
            </ul>
        </div>

        <!-----------------上面是轮播的内容----------->

        <!-----------------下面开始写商品的详情-------------------------->

        <div class="goods">
            <span><strong>韩国韩苏hansu甲油胶批发正品美甲 免洗封层底胶持久 有彩绘胶s</strong> </span>
        </div>
        <hr />
        <!---------------商品价格-------------------->
        <div style="font-size: 25px; color: #FF0033;height:60px;line-height:60px;">
            <div  style="float:left"><span>￥：</span><label style="font-size: 30px;"><%=goods.GPrice %></label></div>
            <div style="float:right;margin-right:20px;"><button class="" type="button" onclick="minus()"><span class="am-icon-minus"></span></button><label id="count" style="font-size: 30px;width:40px;text-align:center;height:30px;line-height:30px;">1</label><button class="" type="button" onclick="add()"><span class="am-icon-plus"></span></button></div>
            <script>
                function add() {
                    var count = parseInt($('#count').html());
                    count++;
                    $('#count').html(count)
                }
                function minus() {
                    var count = parseInt($('#count').html());
                    if(count>=1)
                        count--;
                    $('#count').html(count);
                }
            </script>
        </div>
        <hr />
        <!---------------商品评价-------------------->
        <div data-am-widget="list_news" class="am-list-news am-list-news-default" style="position:relative">
            <!--列表标题-->
            <div class="am-list-news-hd am-cf">
                <!--带更多链接-->
                <a href="###" class="">
                    <h2>评论</h2>
                    <span class="am-list-news-more am-fr">更多 &raquo;</span>
                </a>
            </div>

            <div class="am-list-news-bd">
                <ul class="am-list">

                    <li class="am-g am-list-item-desced">
                        <a href="http://www.douban.com/online/11614662/" class="am-list-item-hd ">我很囧，你保重....晒晒旅行中的那些囧！</a>


                        <div class="am-list-item-text">囧人囧事囧照，人在囧途，越囧越萌。标记《带你出发，陪我回家》http://book.douban.com/subject/25711202/为“想读”“在读”或“读过”，有机会获得此书本活动进行3个月，每月送出三本书。会有不定期bonus！</div>

                    </li>
                    <li class="am-g am-list-item-desced">
                        <a href="http://www.douban.com/online/11624755/" class="am-list-item-hd ">我最喜欢的一张画</a>


                        <div class="am-list-item-text">你最喜欢的艺术作品，告诉大家它们的------名图画，色彩，交织，撞色，线条雕塑装置当代古代现代作品的照片美我最喜欢的画群296795413进群发画，少说多发图，</div>

                    </li>
                    
                </ul>
            </div>

        </div>

        <hr />
        <!---------------商品描述-------------------->
        <div style="margin-bottom:45px;">
              <article data-am-widget="paragraph"
           class="am-paragraph am-paragraph-default"
           
           data-am-paragraph="{ tableScrollable: true, pureview: true }">

      <img src=http://s.amazeui.org/media/i/demos/bing-1.jpg><p class=paragraph-default-p>南极洲又称<a href=http://zh.wikipedia.org/w/index.php?title=%E7%AC%AC%E4%B8%83%E5%A4%A7%E9%99%86&redirect=no>第七大陆</a>，是地球上最后一个被发现、唯一没有土著人居住的大陆。</p><p>南极大陆为通常所说的南大洋（太平洋、印度洋和大西洋的南部水域）所包围，它与南美洲最近的距离为965公里，距新西兰2000公里、距澳大利亚2500公里、距南非3800公里、距中国北京的距离约有12000公里。南极大陆的总面积为1390万平方公里，相当于中国和印巴次大陆面积的总和，居世界各洲第五位。</p><img src=http://s.amazeui.org/media/i/demos/bing-2.jpg /><p>整个南极大陆被一个巨大的冰盖所覆盖，平均海拔为2350米。南极洲是由冈瓦纳大陆分离解体而成，是世界上最高的大陆。南极横断山脉将南极大陆分成东西两部分。这两部分在地理和地质上差别很大。</p><img src=http://s.amazeui.org/media/i/demos/bing-3.jpg /><p>东南极洲是一块很古老的大陆，据科学家推算,已有几亿年的历史。它的中心位于难接近点，从任何海边到难接近点的距离都很远。东南极洲平均海拔高度2500米，最大高度4800 米。在东南极洲有南极大陆最大的活火山，即位于罗斯岛上的埃里伯斯火山，海拔高度3795米，有四个喷火口</p>
  </article>

        </div>
        <!---------------底部按钮-------------------->
        <div class="btn-group">
            <button class="am-btn btn" style="background-color: #FF0033;width:35%;" onclick="TransFer()">立即购买</button>
            <button class="am-btn btn" type="button" onclick="AddCart()" style="background-color: #FF6600;width:45%;"><span class=" am-icon-cart-plus "></span>&nbsp 加入购物车</button>
            
        </div>
    </div>
    <script>
        function TransFer() {
            window.location.href = './proOrders.aspx?GoodId=<%=goods.GID %>&count=' + $('#count').html();
        }

        function AddCart() {
            $.post("./buy.ashx", {
                'openid':'<%=Session["openid"].ToString()%>',
                'count': $('#count').html(),
                'GId':'<%=goods.GID%>'
            }, function (data) {
                if (data == 1)
                    alert('添加购物车成功');
                else if (data == 0)
                    alert('添加失败');
                else
                    alert('参数传递异常');
            })
        }
    </script>
    <script src="js/jquery.min.js"></script>

    <script src="js/amazeui.min.js"></script>
</body>
</html>
