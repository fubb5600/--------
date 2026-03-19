<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSb001U2.aspx.cs" Inherits="TDTSb001_TDTSb001U2" %>

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
                                <tr>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>管理單位
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="mng_id" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>交易日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="deal_date" runat="server" Width="60px" CssClass="date" AutoPostBack="true"
                                            OnTextChanged="deal_date_TextChanged"></asp:TextBox>
                                        <asp:TextBox ID="deal_HH" runat="server" Width="20px" MaxLength="2"></asp:TextBox>&nbsp;:
                                        <asp:TextBox ID="deal_mm" runat="server" Width="20px" MaxLength="2"></asp:TextBox>&nbsp;
                                        <span class="td_memo">(時間格式如：14:30) </span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="日期必填" ControlToValidate="deal_date" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="td_must"
                                            ErrorMessage="時必填" ControlToValidate="deal_HH" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="td_must"
                                            ErrorMessage="分必填" ControlToValidate="deal_mm" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="deal_date" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="td_must" ErrorMessage="0~23"
                                            ControlToValidate="deal_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" CssClass="td_must" ErrorMessage="0~59"
                                            ControlToValidate="deal_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer">
                                        </asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>加油卡卡號
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:DropDownList ID="card_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="card_type_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="card_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="card_id_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="card_id" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="oil_id" runat="server" />
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>加油站名稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="stand_name" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="stand_name" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>油品類型
                                    </td>
                                    <td class="td_cont">
                                        <asp:RadioButtonList ID="fuel_type" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                    <td class="td_head">
                                        油品名稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="fuel_name" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="fuel_name" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>數量
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="fuel_count" runat="server"></asp:TextBox>
                                        <span class="td_memo">公升</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="fuel_count" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>參考金額
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="fuel_amount" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="fuel_amount" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>報表年月
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="report_ym" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="report_ym" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                     <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="年月無效" CssClass="td_must"
                    ClientValidationFunction="YM_Validate" ControlToValidate="report_ym" ValidationGroup="save" 
                    Display="Dynamic" OnServerValidate="YMValidator_ServerValidate"></asp:CustomValidator>

                                    </td>
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
                                        勤務記錄
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <div style="float: left;">
                                            <asp:CheckBoxList ID="work_id" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"
                                                RepeatLayout="Flow">
                                            </asp:CheckBoxList>
                                        </div>
                                        <div style="float: left; margin-left: 10px">
                                            <asp:ImageButton ID="ibWork" runat="server" ImageUrl="~/images/update.png" AlternateText="更新勤務記錄"
                                                OnClick="ibWork_Click" Style="height: 16px" />
                                            <span class="td_memo">(交易日期當月及下月的勤務記錄)</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        備註
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" Width="600px" Rows="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        資料審核
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        審核狀態
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:RadioButtonList ID="adt_status" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                        <asp:HiddenField ID="old_status" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        資料審核說明
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="adt_desc" runat="server" TextMode="MultiLine" Rows="3" Width="600px" MaxLength="1000"></asp:TextBox>
                                        <asp:HiddenField ID="old_desc" runat="server" />
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlAdt" runat="server">
                                    <tr>
                                        <td class="td_head">
                                            審核人員
                                        </td>
                                        <td class="td_cont">
                                            <asp:Label ID="adt_user" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="td_head">
                                            審核時間
                                        </td>
                                        <td class="td_cont">
                                            <asp:Label ID="adt_date" runat="server" Text=""></asp:Label>
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
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CssClass="btn_grey" 
                                    onclick="btnDelete_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="重設狀態" CssClass="btn_grey" OnClick="btnReset_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
