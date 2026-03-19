<%@ Control Language="C#" AutoEventWireup="true" CodeFile="car_status.ascx.cs" Inherits="Common_car_status" %>
<asp:HiddenField ID="car_id" runat="server" />
<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                    BorderWidth="1px" CellPadding="0" Width="500px" EnableModelValidation="True"
                    DataKeyNames="exec_id,status" OnRowDataBound="gvMain_RowDataBound" 
                    onrowcommand="gvMain_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="序號" DataField="row_num" ItemStyle-CssClass="td_cont3 td_center">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="保管時間" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="狀態" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti"
                                Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="修改時間" ItemStyle-CssClass="td_cont3 td_center" DataField="update_date">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Width="30%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="變更狀態">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnChange" runat="server" Text="變更"  ForeColor="#0000FF"  CommandName="Change" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    CausesValidation="False"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="15%" />
                            <ItemStyle CssClass="td_cont3 td_center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
                    <HeaderStyle CssClass="td_headmulti" />
                    <RowStyle CssClass="td_cont3" />
                    <EmptyDataTemplate>
                        無資料</EmptyDataTemplate>
                </asp:GridView>