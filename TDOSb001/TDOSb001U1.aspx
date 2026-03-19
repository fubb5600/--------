<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSb001U1.aspx.cs" Inherits="TDOSb001_TDOSb001U1" %>

<%@ Register Src="../Common/Card_Data.ascx" TagName="Card_Data" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        中油資料
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" class="td_head">
                                        資料來源
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:Label ID="data_source" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>報表年月
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:TextBox ID="report_ym" runat="server"></asp:TextBox>
                                        <span class="td_memo">(格式如：101/01)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="report_ym" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效年月" CssClass="td_must"
                                            ClientValidationFunction="YM_Validate" ControlToValidate="report_ym" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="YMValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        匯入時間[序號]
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="imp_date" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        交易日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="deal_date" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        直銷中心代號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="seller_id" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="fuel_id" runat="server" />
                                    </td>
                                    <td class="td_head">
                                        中心名稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="seller_name" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        客戶代號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="custom_id" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        客戶名稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="custom_name" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        結帳單位代號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="biller_id" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        結帳單位名稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="biller_name" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        管理單位代號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="mng_id" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        管理單位名稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="mng_name" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        加油卡卡號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="imp_card" runat="server" Text=""></asp:Label>
                                    </td>
                                    <%-- <td class="td_head">
                                        變更加油卡
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="card_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="card_type_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="card_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="card_id_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>--%>
                                    <td class="td_head">
                                        車牌號碼
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="car_no" runat="server" Width="100px"></asp:TextBox>
                                        <span class="td_memo">(臨時卡或罐桶卡補登車牌)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        加油站
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="stand" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        油品名稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="fuel_name" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        數量
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="fuel_count" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        參考金額
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="fuel_amount" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        勤務記錄
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:CheckBoxList ID="work_id" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"
                                            RepeatLayout="Flow">
                                        </asp:CheckBoxList>
                                        <span class="td_memo">(交易日期當月及下月的勤務記錄)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        備註1
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="memo1" runat="server" TextMode="MultiLine" Rows="3" Width="600px"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        備註2
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="memo2" runat="server" TextMode="MultiLine" Rows="3" Width="600px"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        資料確認
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        資料確認
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:RadioButtonList ID="cfm_status" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                        <asp:HiddenField ID="old_status" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        資料確認說明
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="cfm_desc" runat="server" TextMode="MultiLine" Rows="3" Width="600px"></asp:TextBox>
                                        <asp:HiddenField ID="old_desc" runat="server" />
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlCfm" runat="server">
                                    <tr>
                                        <td class="td_head">
                                            資料確認人員
                                        </td>
                                        <td class="td_cont">
                                            <asp:Label ID="cfm_user" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="td_head">
                                            資料確認時間
                                        </td>
                                        <td class="td_cont">
                                            <asp:Label ID="cfm_date" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </table>
                            <uc1:Card_Data ID="Card_Data1" runat="server" />
                        </td>
                    </tr>
                </table>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click"
                                    ValidationGroup="save" />
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CssClass="btn_grey" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
