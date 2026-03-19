<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="select_work.aspx.cs" Inherits="Common_select_work" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin: 20px">
        <table class="table_sn" id="num_1">
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                        GridLines="None" DataKeyNames="work_id" CssClass="table_mt table_border" OnRowCommand="GridView1_RowCommand"
                        OnRowDataBound="GridView1_RowDataBound" Width="540px">
                        <Columns>
                            <asp:TemplateField HeaderText="序號">
                                <ItemTemplate>
                                    <asp:Label ID="lbNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="9%" />
                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="勤務時間" DataField="">
                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                <HeaderStyle HorizontalAlign="Center" Width="45%" CssClass="td_center td_headhrz td_headmulti" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="作業機具" DataField="mchn_name">
                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="編號" DataField="work_id">
                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="選擇">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbSelect" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="td_center td_headhrz td_headmulti" />
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
                        <HeaderStyle CssClass="td_headmulti" />
                        <RowStyle CssClass="td_cont3" />
                        <EmptyDataTemplate>
                            無資料</EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="確定加入" CssClass="btn_grey" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
