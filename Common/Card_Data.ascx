<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Card_Data.ascx.cs" Inherits="Common_Card_Data" %>
<table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
    <tr class="td_center td_headhrz">
        <td class="td_head td_center" colspan="4">
            加油卡資料
        </td>
    </tr>
    <asp:Panel ID="pnlEdit" runat="server">
        <tr>
            <td class="td_head" width="15%">
                <span class="td_must">*</span>加油卡卡號
            </td>
            <td class="td_cont">
                <asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="card_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="card_type_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="card_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="card_id_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="td_head" width="15%">
                狀態
            </td>
            <td class="td_cont" width="35%">
                <asp:Label ID="card_status" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </asp:Panel>
    <asp:Panel ID="pnlShow" runat="server">
        <tr>
            <td class="td_head" width="15%">
                加油卡卡別
            </td>
            <td class="td_cont">
                <asp:Label ID="lblCardType" runat="server" Text=""></asp:Label>
            </td>
            <td class="td_head" width="15%">
                加油卡卡號
            </td>
            <td class="td_cont" width="35%">
                <asp:Label ID="lblCardNo" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="td_head">
                保管單位
            </td>
            <td class="td_cont">
                <asp:Label ID="lblCardOrg" runat="server" Text=""></asp:Label>
            </td>
            <td class="td_head">
                狀態
            </td>
            <td class="td_cont">
                <asp:Label ID="lblCardStatus" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </asp:Panel>
    <asp:Panel ID="pnlCar" runat="server">
        <tr class="td_center td_headhrz">
            <td class="td_head td_center" colspan="4">
                車輛資料
            </td>
        </tr>
        <tr>
            <td class="td_head" width="15%">
                車牌號碼
            </td>
            <td class="td_cont">
                <asp:Label ID="car_no" runat="server" Text=""></asp:Label>
            </td>
            <td width="15%" class="td_head">
                局編號
            </td>
            <td width="35%" class="td_cont">
                <asp:Label ID="dep_no" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="td_head">
                車輛種類
            </td>
            <td class="td_cont">
                <asp:Label ID="car_type" runat="server" Text=""></asp:Label>
            </td>
            <td class="td_head">
                狀態
            </td>
            <td class="td_cont">
                <asp:Label ID="car_status" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="td_head">
                油品類型
            </td>
            <td class="td_cont">
                <asp:Label ID="fuel_type" runat="server" Text=""></asp:Label>
            </td>
            <td class="td_head">
                油耗量標準值
            </td>
            <td class="td_cont">
                <asp:Label ID="fuel_std" runat="server" Text=""></asp:Label>
                <span class="td_memo">(公里/公升)</span>
            </td>
        </tr>
    </asp:Panel>
</table>
