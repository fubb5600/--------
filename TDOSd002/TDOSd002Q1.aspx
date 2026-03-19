<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSd002Q1.aspx.cs" Inherits="TDOSd002_TDOSd002Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td width="10%" class="td_head">
                                <span class="td_must">*</span>統計年份
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="year" runat="server" size="10" MaxLength="3"></asp:TextBox>
                                <span class="td_memo">(如：101)</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                    ErrorMessage="必填" ControlToValidate="year" ValidationGroup="save" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                 <%--  <asp:DropDownList ID="report_year" runat="server">
                                </asp:DropDownList>
                                --%>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效民國年" CssClass="td_must"
                                    ClientValidationFunction="CHYear_Validate" ControlToValidate="year" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="CHYearValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td width="10%" class="td_head">
                                車牌號碼
                            </td>
                            <td width="22%" class="td_cont">
                                <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">
                                局編號
                            </td>
                            <td width="22%" class="td_cont">
                                <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">
                                <span class="td_must">*</span>保管單位
                            </td>
                            <td class="td_cont" colspan="5">
                                <asp:RadioButtonList ID="keep_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="8"
                                    CssClass="cbl_fieldset">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
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
