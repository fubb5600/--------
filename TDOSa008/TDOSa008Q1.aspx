<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa008Q1.aspx.cs" Inherits="TDOSa008_TDOSa008Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <!--提醒託修作業資料未建置完整_WENNY_1061206-->
    <script type="text/javascript" language="javascript">

        function GetNotifyMsg() {
            var str = '<%= Session["NOTIFYMSG"].ToString()%>';
            if (str != "")
                alert(str);
            return true;
        }
    </script>
        <tr>
            <td width="12"></td>
            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td class="td_head">使用者群組</td>
                            <td class="td_cont">
                                <asp:DropDownList ID="user_role" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btndelete" runat="server" Text="刪除" CssClass="btn_grey" Visible="true" OnClick="btndelete_Click"  />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;
                </p>
                <!-- 瀏覽頁, 進入時先隱藏 -->
                <table class="table_sn" id="num_1">
                    <tr>
                        <td>
                            <!-- 分頁處理 -->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!-- 留下空行的位置　-->
        <tr>
            <td height="10" colspan="2"></td>
        </tr>
    </table>
</asp:Content>
