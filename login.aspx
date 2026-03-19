<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
<link rel="stylesheet" href="css/login.css"  type="text/css"/>

    <title></title>
</head>
<style type="text/css">
        .login_btn_grey
        {
           background:url(images/btn-bg_grey.jpg) repeat-x; padding:3px; color:#333333; width:80px; height:26px; border:1px solid #adadad;
        }
        
        body
        {background-color:#c3e9ff; }
        
    .auto-style1 {
        height: 147px;
    }
        
</style>
<script type="text/javascript" src="js/buttonAction.js"></script> 
<script type="text/javascript">
    function getScreen() {
        document.getElementById("Screen_w").value = screen.width;
        document.getElementById("Screen_h").value = screen.height;
    }
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="949" align="center" cellpadding="0" cellspacing="0" >
            <asp:TextBox ID="Screen_w" runat="server" style="display:none"></asp:TextBox>
            <asp:TextBox ID="Screen_h" runat="server" style="display:none"></asp:TextBox>
          <tr>
            <td height="117" colspan="3" >
            <div style="float: left; display: block; margin: 0px;">
            <div style="float: left">
                <img alt="圖示" src="images/top_title_logo.jpg" /></div>
            <div class="font_title_r" style="float: left; padding-top: 20px;">
                <asp:Label ID="lblWebName" runat="server" Text=""></asp:Label></div>
            
        </div>
            </td>
          </tr>
          <tr>
          	  <td colspan="3" class="auto-style1" ><img src="images/loginbg2.jpg" width="949" height="147" /></td>
       	  </tr>
        	<tr>
            	<td width="25" class="frameleft"></td>
            	<td width="492" height="200" class="framecenter">	  
                  <div style="margin-left:300px;">
                    <table width="400" border="0" align="center" cellpadding="0" cellspacing="0" >
                      <tr>
                        <td height="35" align="right">&#x5E33;&#x865F;&#xFF1A;</td>
                        <td>
                            <asp:TextBox ID="txtUserId" runat="server" Width="150px" MaxLength="16"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <td height="35" align="right">&#x5BC6;&#x78BC;&#xFF1A;</td>
                        <td>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="150px" MaxLength="16"></asp:TextBox>   
                        </td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td height="35">
                          <asp:Button ID="btnLogin" runat="server" CssClass="login_btn_grey" Text="Login" OnClick="btnLogin_Click" OnClientClick="getScreen();" />                         
                        </td>
                      </tr>
                    </table>                    
                    </div>            	  
                </td>
           	  <td width="432" class="frameright"></td>                                
            </tr>
        	<tr>
            	<td class="frameleftfoot"></td>
            	<td class="framefoot"></td>
            	<td class="framerightfoot"></td>                                
            </tr> 
          <tr>
            <td class="font_footer" colspan="3"><div id="font_footer" style="clear: both">
        最佳瀏覽環境：IE 7 / 8 / 9．螢幕解析度 1024*768．<br />
        臺北市政府環境保護局版權所有 2015 &copy; Copyright All Rights Reserved</div></td>
          </tr>                                   
        </table>

    </div>
    </form>
</body>
</html>
