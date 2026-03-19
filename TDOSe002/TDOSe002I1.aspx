<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSe002I1.aspx.cs" Inherits="TDTSe002_TDTSe002I1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <!--提醒託修作業資料未建置完整_WENNY_1061206-->
    <script type="text/javascript" language="javascript">
  
        function GetNotifyMsg() {
            var str = '<%= Session["NOTIFYMSG"].ToString()%>';
            if (str != "")
                alert(str);
            return true;
        }
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <table width="900">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">                               
                                <tr style="height:55px">
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>檔案來源
                                    </td>
                                    <td class="td_cont">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="600px" /><br />
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="項目明細.xls" Font-Size="Small">範例檔案下載</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr style="height:55px">
                                    <td class="td_head">
                                        備註
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" Width="600px" Rows="3"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click" OnClientClick=" GetNotifyMsg();"
                                    ValidationGroup="save" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" OnClientClick=" GetNotifyMsg();"/>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <div style="margin:10px;"><asp:Label ID="err_msg" runat="server" Text="" CssClass="td_must"></asp:Label></div>
            </td>
        </tr>
    </table>   
</asp:Content>
