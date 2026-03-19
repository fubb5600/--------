<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc006Q1.aspx.cs" Inherits="TDOSc001_TDOSc001Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <!--提醒託修作業資料未建置完整_WENNY_1061206-->
    <script type="text/javascript" language="javascript">
      
        function GetNotifyMsg() {
            var str = '<%= Session["NOTIFYMSG"].ToString()%>';
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
                <!-- 內容 -->
                <table class="table_sn" id="num_1">
                    <tr>
                        <td>
                            <!-- 分頁處理 -->                            
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1000px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="car_id">
                                <Columns>
                                    <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="8%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="局編號" DataField="dep_no">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="11%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="士林區清潔隊" DataField="car_no">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="11%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="車隊卡號" DataField="card_no">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="11%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="車輛種類" DataField="car_type" ItemStyle-CssClass="td_cont3 td_left">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="油品" DataField="fuel_type" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="9%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="保管單位" DataField="org_name" ItemStyle-CssClass="td_cont3 td_left">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="狀態" DataField="status">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="編輯">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="7%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
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
                </table>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click" OnClientClick="GetNotifyMsg();" />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" OnClientClick="GetNotifyMsg();" />
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
