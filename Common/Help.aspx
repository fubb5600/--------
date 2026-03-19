<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Help.aspx.cs" Inherits="Common_Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../css/jquery-ui-1.9.2.custom.css" rel="stylesheet" />
    <script src="..js/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
    <style>
        body
        {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Accordion -->
    <div style="width: 80%; margin-left: 50px;">
        <div style="float: left; width: 35%">
            <h2 class="demoHeaders">
                <img alt="圖示" src="../images/Manual.png" align="absmiddle" />
                操作手冊</h2>
            <br />
            <div style="margin-left: 45px; margin-bottom: 10px;">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/1355333830_001_52.gif" OnClick="lbManual_Click" ImageAlign="AbsMiddle" AlternateText="下載操作手冊" />            
                <asp:LinkButton ID="lbManual" runat="server" OnClick="lbManual_Click">點選下載</asp:LinkButton>
              <%--  (版本：1.0，更新時間：2012/09/12)--%>
                 (版本：2.0，更新時間：2016/07/20)
            </div>
        </div>
        <div style="float: right; width: 55%">
            <h2 class="demoHeaders">
                <img alt="圖示" src="../images/Phone.png" align="absmiddle" width="32px" />
                聯繫窗口</h2>
            <div style="margin: 10px; margin-left: 45px; ">
                系統操作問題、資料問題或系統發生錯誤請聯繫台北市政府環境保護局。
            </div>
        </div>
        <br style="clear:both" />
        <h2 class="demoHeaders">
            <img alt="圖示" src="../images/help-faq.png" align="absmiddle" />
            常見問題</h2>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
</asp:Content>
