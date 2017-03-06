<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Charactertest.aspx.cs" Inherits="首页开发.Charactertest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap.min.css">

    <!-- 可选的Bootstrap主题文件（一般不用引入） -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap-theme.min.css">

    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="//cdn.bootcss.com/jquery/1.11.3/jquery.min.js"></script>

    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="//cdn.bootcss.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="js/echarts.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="This just a description!!" />
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <style>
        label {
            font-size: 20px;
            color: #00b7e9;
        }

        input {
            height: 35px;
            font-size: 18px;
            vertical-align: bottom;
        }

        button {
            width: 30%;
            height: 40px;
            background-color: #00b7e9;
            color: white;
        }

        .div1 {
            margin-bottom: 5px;
            text-align: center;
        }
    </style>
    <title>我在美甲能力测试中得了<%=sum %>分</title>
</head>
<body style="background-color: #FF9999;">
    <div style='margin: 0 auto; width: 0px; height: 0px; overflow: hidden;'>
        <img src="PIc/qrcode_for_gh_6c5b2f532bfb_430.jpg" width="300px" height="300px" />
    </div>
    <form id="form1" runat="server">

        <!----没有输入参数之前的页面-------->
        <%if (!IsLoad)
          { %>
        <div style="margin-top:50px;">
            <div class="div1">
                <label>姓名：</label>
                <input style="width: 40%;" type="text" name="user-name" />
            </div>
            <div class="div1">
                <label>性别：</label>
                <input type="radio" value="男" name="user-sex" /><label>男</label>
                <input type="radio" value="女" name="user-sex" /><label>女</label>
            </div>
            <div style="text-align: center">
                <button class=" btn btn-toolbar btn-lg">开始测试</button>
            </div>
        </div>

        <%}
          else
          {%>
        <!-------------性格分析图------------------------------>

        <div id="main" style="width: 400px; height: 400px; color: black"></div>
        <script>
            var myChart = echarts.init(document.getElementById('main'));
            var option = {
                title: {
                    text: '美甲技术分析：'
                },
                tooltip: {},
                legend: {
                    data: ['实力', '天赋']
                },
                radar: {
                    // shape: 'circle',
                    indicator: [
                       { name: '排笔彩绘', max: 100 },
                       { name: '手型修饰', max: 100 },
                       { name: '钻饰粘贴', max: 100 },
                       { name: '甲面晕染', max: 100 },
                       { name: '多色渐变', max: 100 },
                       { name: '线条彩绘', max: 100 },
                       { name: '立体雕花', max: 100 },
                       { name: '新款创作', max: 100 },
                       { name: '甲面单色', max: 100 },


                    ]
                },
                series: [{
                    name: '实力 vs 天赋',
                    type: 'radar',
                    // areaStyle: {normal: {}},
                    data: [
                        {
                            value: [<%=list[0] %>, <%=list[1] %>, <%=list[2] %>, <%=list[3] %>, <%=list[4] %>, <%=list[5] %>, <%=list[6] %>, <%=list[7] %>, <%=list[8] %>],
                            name: '实力'
                        },
                         {
                             value: [<%=list[0] %>, <%=list[1] %>, <%=list[2] %>, <%=list[3] %>, <%=list[4] %>, <%=list[5] %>, <%=list[6] %>, <%=list[7] %>, <%=list[8] %>],
                             name: '天赋'
                         }
                    ]
                }]
            };
            myChart.setOption(option);
        </script>
        <div style="text-align: center;">
            <span style="font-size: 15px;">综合评分：</span><span style="color: #0e90d2; font-size: 58px;"><%=sum %></span>
        </div>
        <!-------------------------------------------------------->
        <div id="main1" style="width: 400px; height: 400px; color: black"></div>
        <script>

            var myChart1 = echarts.init(document.getElementById('main1'));
            var option1 = {
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                legend: {
                    data: ['得分']
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: {
                    type: 'value'
                },
                yAxis: {
                    type: 'category',
                    data: ['排笔彩绘', '手型修饰', '钻饰粘贴', '甲面晕染', '多色渐变', '线条彩绘', '立体雕花', '新款创作', '甲面单色']
                },
                series: [
                    {
                        name: '得分',
                        type: 'bar',
                        stack: '总量',
                        label: {
                            normal: {
                                show: true,
                                position: 'insideRight'
                            }
                        },
                        data: [<%=list[0] %>, <%=list[1] %>, <%=list[2] %>, <%=list[3] %>, <%=list[4] %>, <%=list[5] %>, <%=list[6] %>, <%=list[7] %>, <%=list[8] %>]
                    },

                ]
            };
                myChart1.setOption(option1);
        </script>
        <div style="color: #FF0033; font-size: 20px;">
            <%if (sum >= 99)
              { %>
            <span>您已成为真正的美甲宗师，万里无一！！</span>
            <%}
              else if (sum >= 90)
              { %>
            <span>恭喜您，您已成为美甲大师。高处不胜寒啊！！！</span>
            <%}
              else if (sum >= 80)
              { %>
            <span>恭喜你，你已成为资深美甲师。你的灵感会给你带来更多收获！！！</span>
            <%}
              else if (sum >= 70)
              { %>
            <span>恭喜你，你已成为美甲达人。离成功越来越近了！！！</span>
            <%}
              else if (sum >= 60)
              { %>
            <span>你很有天分，基础是你的重中之重!!!</span>
            <%}
              else
              { %>
            <span>理想很丰满，现实很骨感。努力吧骚年！！！</span>
            <%} %>
        </div>
        <div style="text-align:center;">
            <button type="button" class="btn btn-success" style="width:80%;" onclick="alertT()">分享朋友圈</button>
            <button type="button" class="btn btn-success" style="width:80%;margin-top:20px;" onclick="Transfer()">欢迎参观我们的微博，更多福利~~~~</button>

        </div>
        <script>
            function alertT() {
                alert("点击右上角分享到朋友圈，让好友参与进来吧！！")
            }
            function Transfer() {
                window.location.href = "http://weibo.com/u/3153514983?refer_flag=1001030102_&is_hot=1";
            }

        </script>

        <%} %>
    </form>
</body>
</html>