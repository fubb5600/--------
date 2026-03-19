<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings["WebName"] %></title>
    <link type="text/css" href="menu.css" rel="stylesheet" />
    <link type="text/css" href="CommStyle.css" rel="stylesheet" />
    <script type="text/javascript" src="jquery.js"></script>
    <script type="text/javascript" src="menu.js"></script>
</head>
<body>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
        }
        
        body
        {
            /*background-color: #F2F2F2;*/
            overflow: hidden;
        }
        div#menu
        {
        	display:block;
            /*top: 0px;
            left: 0px;*/
            width: 100%;
            background: transparent url(images/header_bg.gif) repeat-x 0 0;
        }
        div#copyright
        {
            display: none;
        }
    </style>
    <form id="form1" runat="server">
    <div style=" display: block; width: 100%; height: 80px; background: transparent url(images/top_title_bg.jpg)">
        <div style="float: left; display: block; margin: 0px;">
            <div style="float: left">
                <img alt="圖示" src="images/top_title_logo.jpg" /></div>
            <div class="font_title_r" style="float: left; padding-top: 20px;">
                秘書室油料管理系統</div>
        </div>
        <div style="float: right; display: block; padding: 5px;">
            <img alt="圖示" src="images/1338985760_id-card.png" align="absmiddle" hspace="5" />
            <span class="font_user">使用者：潘妍蓉
            (sarahyrp)｜</span><a href="#" class="link">登出</a></div>
    </div>
    <div id="menu">
        <ul class="menu">
            <li><a href="#" class="parent"><span>首頁</span></a> </li>
            <li><a href="#" class="parent"><span>中油資料</span></a>
                <div>
                    <ul>
                        <li><a href="#"><span>加油資料查詢</span></a></li>
                        <li><a href="#"><span>加油資料匯入</span></a></li>
                    </ul>
                </div>
            </li>
            <li><a href="#"><span>車輛資料</span></a>
                <div>
                    <ul>
                        <li><a href="#"><span>車輛基本資料</span></a></li>
                        <li><a href="#"><span>車輛異動記錄</span></a></li>
                        <li><a href="#"><span>勤務記錄管理</span></a></li>
                    </ul>
                </div>
            </li>
            <li><a href="#" class="parent"><span>系統管理</span></a>
                <div>
                    <ul>
                        <li><a href="#"><span>加油卡資料</span></a></li>
                        <li><a href="#"><span>系統帳號</span></a></li>
                        <li><a href="#"><span>系統參數</span></a></li>
                        <li><a href="#"><span>基本參數</span></a></li>
                        <li><a href="#"><span>密碼變更</span></a></li>
                    </ul>
                </div>
            </li>
            <li class="last"><a href="#" class="parent"><span>統計報表</span></a>
                <div>
                    <ul>
                        <li><a href="#"><span>加油統計表</span></a></li>
                        <li><a href="#"><span>兩期比較表</span></a></li>
                        <li><a href="#"><span>差異對照表</span></a></li>
                    </ul>
                </div>
            </li>
        </ul>
    </div>
    <div style="padding-top: 5px">
        <div style="float: left;">
            <img src="images/Location-left.jpg" alt="現在位置" width="125" height="32" />
        </div>
        <div style="float: left; display: block; width: 434px; height: 32px; background: transparent url(images/Location-center.jpg)">
            <span class="site_text">首頁</span>
        </div>
    </div>
    <div id="font_footer" style="clear: both">
        最佳瀏覽環境：IE 7 / 8 / 9．螢幕解析度 1024*768．<br />
        臺北市政府環境保護局版權所有 2012 &copy; Copyright All Rights Reserved</div>
    </form>
</body>
</html>
