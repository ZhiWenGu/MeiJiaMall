<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xuanchuan.aspx.cs" Inherits="首页开发.xuanchuan" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="js/jquery.min.js"></script>
    <title></title>
    <style type="text/css">
        .background-div ul li {
            list-style: none;
            width: 100%;
            position: absolute;
            opacity: 0;
            filter: alpha(opacity=0);
            
        }

        body {
            margin: 0px;
            padding: 0px;
        }

        ul {
            margin: 0px;
            padding: 0px;
            
        }
        .background-div{
            width:100%;
           float: left;
           position: relative;
        }
        .bgk-title-bar{
            background-color: gray;
            opacity: 0.4;
            width: 100%;
            height: 100px;
            position: absolute;
            z-index: -1;
        }
        .title-bar{
            width: 100%;
            height: 100px;
            position: absolute;
            z-index: 99;
        }
        .title-bar ul li{
            list-style: none;
            float: left;
            border-bottom: 1px solid gray;
            border-right: 1px solid gray;
            width: 12%;
            height: 98px;
            line-height: 108px;
            text-align: center;
            color: white;
            font-size: 24px;
            opacity: 1;
        }
        .center-show{
            margin:0 auto;
            width:100%;
            text-align:center;
            height:180px;
            position:absolute;
            z-index:9;
            top:300px;
        }
        .center-show table{
            margin:0 auto;
        }
        .center-show table tr td{
            width:150px;
            height:100px;
            font-size:26px;
            position:relative;
            color:white;
        }
        .td-div{
            width:150px;
            height:100px;
            background-color:#0099CC;
            opacity:0.5;
            position:absolute;
            top:0px;
            z-index:-1;
        }
        .table-show{
            position:absolute;
            top:0px;
            height:200px;
            width:450px;
            background-color:white;
            opacity:0.8;
            text-align:left;
        }
        .table-show ul li{
            list-style:none;
            margin-bottom:10px;
            font-size:22px;
            text-decoration:none;
            
        }
        .table-show span{
            color:#0066CC;
            font-size:25px;
        }
        a{
            text-decoration:none;
        }
        .foot{
            position:fixed;
            bottom:0px;
            color:white;
            z-index:999;
            text-align:center;
            margin:0 auto;
            width:100%;
            font-size:18px;
            height:100px;
        }
        body{
            width:100%;
        }
        .bgk-foot{
            width:100%;
            position:absolute;
            height:100px;
            background-color:black;
            z-index:-1;
            opacity:0.7;
        }
    </style>
</head>
<body>
    <div class="title-bar">
        <ul>
            <li>杰森美甲</li>
            <li>业务介绍</li>
            <li>成功案例</li>
            <li>联系我们</li>
        </ul>
        <div class="bgk-title-bar"></div>
    </div>
    <div class="center-show">
        <!-------这是中心的展示框体---------------------->
        <table>
            <tr>
                <td>老师风采<div class="td-div"></div></td>
                <td>&nbsp
                    <div class="table-show">
                        
                        <ul>
                            <li><span>杰森消息:</span></li>
                            <li><a href="#">消息1</a></li>
                            <li><a href="#">消息2</a></li>
                            <li><a href="#">消息3</a></li>
                            <li><a href="#">消息4</a></li>
                        </ul>
                    </div>
                </td>
                <td>&nbsp</td>
                <td>&nbsp</td>
                <td>学习情况<div class="td-div"></div></td>
            </tr>
            <tr>
                <td>学员面貌<div class="td-div"></div></td>
                <td>&nbsp</td>
                <td>&nbsp</td>
                <td>&nbsp</td>
                <td>联系我们<div class="td-div"></div></td>
            </tr>
        </table>
    </div>
    <div class="foot">
        <div class="bgk-foot"></div>
        <p>
            联系电话：郭经理：17734565934 黄经理：18032076660
        </p>
        <br />
        <span>
            版权所有 © 杰森美甲美睫  地址:河北省石家庄市桥东区劝业大厦503室  邮编:50000 
        </span>
    </div>
    <div class="background-div">
        <ul>
            <li style="background: url(./images/m1.jpg) no-repeat center center; opacity: 1; filter: alpha(opacity=0);"></li>
            <li style="background: url(./images/m2.jpg) no-repeat center center;"></li>
            <li style="background: url(./images/m3.jpg) no-repeat center center;"></li>
            <li style="background: url(./images/m4.jpg) no-repeat center center;"></li>
            <li style="background: url(./images/m5.jpg) no-repeat center center;"></li>
        </ul>
    </div>
    
    <script>
        var PageHeight = $(document).height();
        $(".background-div ul li").css("height", PageHeight + "px");
        $(".background-div").css("height", PageHeight + "px");
    </script>
    <script type="text/javascript">
        var aLi = $(".background-div ul li");
        var iNow = 0;

        function move() {
            // body...
            aLi.eq(iNow).siblings().stop().animate({
                opacity: 0

            }, 4000);
            aLi.eq(iNow).stop().animate({
                opacity: 1
            }, 4000);
            ali.eq(iNow)
        }
        function run2() {
            // body...
            iNow++;
            if (iNow > 4)
                iNow = 0;
            move();

        }
        timer = setInterval(run2, 4000);
    </script>
</body>
</html>

