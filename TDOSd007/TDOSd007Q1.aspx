<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSd007Q1.aspx.cs" Inherits="TDOSd007_TDOSd007Q1" %>

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
    <table width="1200px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <script language="javascript">
                        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(DatePicker);
                    </script>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td width="10%" class="td_head">
                                        <span class="td_must">*</span>統計期間
                                    </td>
                                    <td class="td_cont" >
                                        <asp:TextBox ID="start_date" runat="server" size="10" class="date"></asp:TextBox>
                                        ~
                                        <asp:TextBox ID="end_date" runat="server" size="10" class="date"></asp:TextBox>
                                        <asp:Button ID="btnLastMonth" runat="server" Text="上月" CssClass="Button" 
                                            onclick="btnLastMonth_Click" />
                                        <asp:Button ID="btnThisMonth" runat="server" Text="本月" CssClass="Button" 
                                            onclick="btnThisMonth_Click" />                                        
                                        <span class="td_memo">(格式如：101/01/01)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                            ErrorMessage="開始日期必填" ControlToValidate="start_date" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="結束日期必填" ControlToValidate="end_date" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="start_date" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="end_date" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    </td>                                   
                                </tr>                                
                                <tr>
                                    <td class="td_head">
                                        保管單位<br /> (
                                        <input id="chkAllunit" type="checkbox" />
                                        <label for="chkAllunit">全選</label> )
                                    </td>
                                    <td class="td_cont">
                                        <asp:CheckBoxList ID="keep_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="7"
                                            CssClass="cbl_fieldset">
                                        </asp:CheckBoxList>
                                        <input id="Hidden1" type="hidden" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="產出報表" CssClass="btn_grey" OnClick="btnQuery_Click" OnClientClick=" GetNotifyMsg();"
                                    ValidationGroup="save" Width="191px" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;</p>
            </td>
        </tr>
        <!-- 留下空行的位置　-->
        <tr>
            <td height="10" colspan="2">
            </td>
        </tr>
    </table>
    <script type="text/javascript" src="../js/Michael/Ccbselect.js"></script>
</asp:Content>
