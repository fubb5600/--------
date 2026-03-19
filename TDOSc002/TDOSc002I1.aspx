<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc002I1.aspx.cs" Inherits="TDTSc002_TDTSc002I1" %>

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
                                        車輛資料
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>車牌號碼
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="car_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="car_id_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="car_id" ValidationGroup="car"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" class="td_head">
                                        局編號
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:Label ID="dep_no" runat="server" Text=""></asp:Label>                                        
                                        <asp:HiddenField ID="keep_id" runat="server" />
                                        <asp:HiddenField ID="keep_start" runat="server" />
                                        <asp:HiddenField ID="keep_end" runat="server" />
                                        <asp:HiddenField ID="possess_id" runat="server" />
                                        <asp:HiddenField ID="exec_id" runat="server" />
                                        <asp:HiddenField ID="card_id" runat="server" />     
                                        <asp:HiddenField ID="fuel_type" runat="server" />  
                                        <asp:HiddenField ID="new_card" runat="server" />                                    
                                    </td>
                                    <td width="15%" class="td_head">
                                        車輛種類
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="car_type" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        車隊卡卡號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="card_no" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        狀態
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="status" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="car_status" runat="server" />
                                    </td>
                                </tr>
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        異動記錄
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>異動日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="chg_date" runat="server" CssClass="date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="chg_date" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="chg_date" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>異動原因
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="chg_rsn" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chg_rsn_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="chg_rsn" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlR1" runat="server" Visible="false">
                                    <tr>
                                        <td class="td_head">
                                            <span class="td_must">*</span>移撥單位
                                        </td>
                                        <td class="td_cont" colspan="3">
                                            <asp:DropDownList ID="r1_org" runat="server">
                                            </asp:DropDownList>
                                            <span class="td_memo">(自異動日期起車輛保管單位將轉移至此單位)</span>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="pnlR5" runat="server" Visible="false">
                                    <tr>
                                        <td class="td_head">
                                            <span class="td_must">*</span>變更車牌號碼
                                        </td>
                                        <td class="td_cont" colspan="3">
                                            <asp:TextBox ID="r5_license" runat="server"></asp:TextBox>
                                            <span class="td_memo">(自異動日期起使用此車牌號碼，舊的加油記錄、勤務記錄顯示舊車牌)</span>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td class="td_head">
                                        異動說明
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="chg_desc" runat="server" TextMode="MultiLine" Width="600px" Rows="3"></asp:TextBox>
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
                                    ValidationGroup="save" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click"  />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
</asp:Content>
