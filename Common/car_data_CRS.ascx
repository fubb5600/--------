<%@ Control Language="C#" AutoEventWireup="true" CodeFile="car_data_CRS.ascx.cs"
    Inherits="Common_car_data_CRS" %>
<asp:Panel ID="pnlCar" runat="server">
<tr class="td_center td_headhrz">
    <td class="td_head td_center" colspan="4">
        車輛資料
    </td>
</tr>
<tr>
    <td class="td_head">
        車牌號碼
    </td>
    <td class="td_cont">
        <asp:Label ID="car_no" runat="server" Text=""></asp:Label>
    </td>
    <td class="td_head">
        局編號
    </td>
    <td class="td_cont">
        <asp:Label ID="dep_no" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td class="td_head">
        保管單位
    </td>
    <td class="td_cont">
        <asp:Label ID="keep_org" runat="server" Text=""></asp:Label>
    </td>
    <td class="td_head">
        廠牌型號
    </td>
    <td class="td_cont">
        <asp:Label ID="brand_no" runat="server" Text=""></asp:Label>
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
        里程數
    </td>
    <td class="td_cont">
        <asp:Label ID="mileage" runat="server" Text=""></asp:Label>
    </td>
    <td class="td_head">
        駕駛
    </td>
    <td class="td_cont">
        <asp:Label ID="driver" runat="server" Text=""></asp:Label>
    </td>
</tr>
</asp:Panel>
<asp:Panel ID="pnlMachine" runat="server">
<tr class="td_center td_headhrz">
    <td class="td_head td_center" colspan="4">
        機具資料
    </td>
</tr>
<tr>
    <td class="td_head">
        局編號
    </td>
    <td class="td_cont">
        <asp:Label ID="machine_no" runat="server" Text=""></asp:Label>
    </td>
    <td class="td_head">
        所屬單位
    </td>
    <td class="td_cont">
        <asp:Label ID="machine_org" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td class="td_head">
        機具類型
    </td>
    <td class="td_cont" colspan="3">
        <asp:Label ID="machine_type" runat="server" Text=""></asp:Label>
    </td>
</tr>
</asp:Panel>
