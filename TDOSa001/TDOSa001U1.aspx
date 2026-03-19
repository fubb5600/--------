<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa001U1.aspx.cs" Inherits="TDOSa001_TDOSa001U1" %>

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
                <table width="800">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td width="15%" class="td_head">
                                        使用者帳號
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:Label ID="user_id" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="15%" class="td_head">




                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:Label ID="user_name" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        編號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_no" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        職稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_title" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        單位
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_dep" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        部門
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_department" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        聯絡電話1
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_cont1" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        聯絡電話2
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_cont2" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        傳真
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_fax" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        行動電話
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_mobile" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        聯絡地址
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_address" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        電子郵件
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="user_email" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        本系統設定
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>使用者群組
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="role_id" runat="server" >
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="role_id" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>狀態
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="status" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="status" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator><asp:HiddenField ID="hfAction" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>所屬單位
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="user_org" runat="server"  AutoPostBack="true"
                                            onselectedindexchanged="user_org_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="sub_org" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>資料讀取
                                    </td>
                                    <td class="td_cont">
                                        <asp:RadioButtonList ID="user_read" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="SELF">同單位	</asp:ListItem>
                                            <asp:ListItem Value="ALL">跨單位</asp:ListItem>
                                            <asp:ListItem Value="OUT">多單位</asp:ListItem>
                                        </asp:RadioButtonList>
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
                                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click"
                                    ValidationGroup="save" OnClientClick="GetNotifyMsg();" />
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CssClass="btn_grey" OnClientClick="GetNotifyMsg();return confirm('確定刪除?');"
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" OnClientClick="GetNotifyMsg();" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
