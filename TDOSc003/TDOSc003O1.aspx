<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc003O1.aspx.cs" Inherits="TDOSc003_TDOSc003O1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <script type="text/javascript" language="javascript">
                function GetNotifyMsg() {
                    var str = '<%= Session["NOTIFYMSG"] == null ? "" : Session["NOTIFYMSG"].ToString()%>';
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
                                    <td class="td_cont" width="25%" colspan="3" style="line-height:28px;padding-top:6px;padding-bottom:6px">
                                        <asp:TextBox ID="start_date" runat="server" size="10" class="date"></asp:TextBox>
                                        ~
                                        <asp:TextBox ID="end_date" runat="server" size="10" class="date"></asp:TextBox>
                                        <span class="td_memo">(格式如：101/01/01)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must" ErrorMessage="開始日期必填" ControlToValidate="start_date" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must" ErrorMessage="結束日期必填" ControlToValidate="end_date" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                                  
                                    </td>
                                   
                                <tr>
                                    <td width="10%" class="td_head">車牌號碼</td>
                                    <td width="22%" class="td_cont"><asp:TextBox ID="car_no" runat="server"></asp:TextBox></td>
                                    
                                </tr>
                               
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="產出報表" CssClass="btn_grey" OnClick="btnQuery_Click" OnClientClick="GetNotifyMsg();" ValidationGroup="save" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <p>&nbsp;</p>
            </td>
        </tr>
        <tr>
            <td height="10" colspan="2"></td>
        </tr>
    </table>
    <script type="text/javascript" src="../js/Michael/Ccbselect.js"></script>
</asp:Content>
