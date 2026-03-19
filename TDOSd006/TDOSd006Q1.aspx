<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSd006Q1.aspx.cs" Inherits="TDOSd006_TDOSd006Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="1200px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
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
                                        <span class="td_must">*</span>報表年月
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="txtReport_YM" runat="server" size="10" MaxLength="6"></asp:TextBox>
                                        <asp:Button ID="btnLastMonth" runat="server" Text="上月" CssClass="Button" OnClick="btnLastMonth_Click" />
                                        <asp:Button ID="btnThisMonth" runat="server" Text="本月" CssClass="Button" OnClick="btnThisMonth_Click" />
                                        <span class="td_memo">(格式如：101/01)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="報表年月必填" ControlToValidate="txtReport_YM" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效報表年月" CssClass="td_must"
                                            ClientValidationFunction="YM_Validate" ControlToValidate="txtReport_YM" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="YMValidator_ServerValidate"></asp:CustomValidator>
                                            
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        保管單位
                                    </td>
                                    <td class="td_cont">
                                        <asp:CheckBoxList ID="keep_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="7"
                                            CssClass="cbl_fieldset">
                                        </asp:CheckBoxList>
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
                                <asp:Button ID="btnQuery" runat="server" Text="產出報表" CssClass="btn_grey" OnClick="btnQuery_Click"
                                    ValidationGroup="save" />
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
</asp:Content>
