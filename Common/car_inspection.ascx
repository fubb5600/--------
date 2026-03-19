<%@ Control Language="C#" AutoEventWireup="true" CodeFile="car_inspection.ascx.cs"
    Inherits="Common_car_inspection" %>
<script type="text/javascript">
    function GetNotifyMsg() {
        var str =<%=Session["NOTIFYMSG"].ToString()%>
            alert(str);
        return true;
    }
</script>
<asp:HiddenField ID="car_id" runat="server" />
<!-- 內容 -->
<table width="100%">
    <tr>
        <td>
            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <td class="td_head">
                        <span class="td_must">*</span>定期檢驗日
                    </td>
                    <td class="td_cont">
                        <asp:TextBox ID="regular_date" runat="server" CssClass="date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                            InitialValue="" ErrorMessage="必填" ControlToValidate="regular_date" ValidationGroup="saveInspection"
                            Display="Dynamic"> </asp:RequiredFieldValidator>
                    </td>
                    <td class="td_head">
                        <span class="td_must">*</span>完成檢驗日
                    </td>
                    <td class="td_cont">
                        <asp:TextBox ID="inspection_date" runat="server" CssClass="date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                            InitialValue="" ErrorMessage="必填" ControlToValidate="inspection_date" ValidationGroup="saveInspection"
                            Display="Dynamic"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td_head">
                        備註
                    </td>
                    <td class="td_cont" colspan="3">
                        <asp:TextBox ID="memo" runat="server" Rows="3" TextMode="MultiLine" Width="600px" ></asp:TextBox>
                    </td>
                </tr>
            </table>
            <!-- BUTTON -->
            <table>
                <tr>
                    <td class="font_normal">
                        <asp:Panel ID="buttonPanel" runat="server">
                            <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click" OnClientClick="GetNotifyMsg();"
                                ValidationGroup="saveInspection" />
                            <asp:Button ID="btnClear" runat="server" Text="清除" CssClass="btn_grey" OnClick="btnClear_Click" OnClientClick="GetNotifyMsg();"/>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<!-- 分頁處理 -->
<asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>
<asp:GridView ID="gvInspection" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
    BorderWidth="1px" CellPadding="0" Width="100%" EnableModelValidation="True"
    DataKeyNames="inspect_id" OnRowDataBound="gvInspection_RowDataBound" 
    onrowdeleting="gvInspection_RowDeleting" >
    <Columns>
        <asp:BoundField HeaderText="序號" ItemStyle-CssClass="td_cont3 td_center" DataField="row_num">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti"
                Width="10%" />
        </asp:BoundField>
        <asp:BoundField HeaderText="定期檢驗日期" ItemStyle-CssClass="td_cont3 td_center" DataField="regular_date">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti"
                Width="15%" />
        </asp:BoundField>
        <asp:BoundField HeaderText="完成檢驗日期" ItemStyle-CssClass="td_cont3 td_center" DataField="inspection_date">
            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti"
                Width="15%" />
        </asp:BoundField>
        <asp:BoundField HeaderText="備註" ItemStyle-CssClass="td_cont3 td_left" DataField="memo">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
        </asp:BoundField>
        <asp:BoundField HeaderText="異動時間" ItemStyle-CssClass="td_cont3 td_center" DataField="update_date">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti"
                Width="15%" />
        </asp:BoundField>
        <asp:BoundField HeaderText="異動人員" ItemStyle-CssClass="td_cont3 td_center" DataField="update_user">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" Width="15%" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="刪除">
            <ItemTemplate>
             <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/images/del.png"  />
                <%--<asp:LinkButton ID="lbtnChange" runat="server" Text="刪除" CommandName="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                    CausesValidation="False"></asp:LinkButton>--%>
            </ItemTemplate>
            <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="10%" />
            <ItemStyle CssClass="td_cont3 td_center"></ItemStyle>
        </asp:TemplateField>
    </Columns>
    <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
    <HeaderStyle CssClass="td_headmulti" />
    <RowStyle CssClass="td_cont3" />
    <EmptyDataTemplate>
        發照日期或下次定檢日無資料</EmptyDataTemplate>
</asp:GridView>
