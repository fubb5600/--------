<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attach_Manage.ascx.cs" Inherits="Common_Attach_Manage" %>
<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                    OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0"
                    Width="98%" DataKeyNames="toilet_id" EnableModelValidation="True" OnRowEditing="gvMain_RowEditing">
                    <Columns>
                        <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Width="6%" 
                            CssClass="td_center td_headhrz td_headmulti" Height="20px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="行政區" DataField="toilet_region" ItemStyle-CssClass="td_cont3 td_center">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="管理單位" DataField="mng_org" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_left" />
                            <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="座數" DataField="toilet_number" ItemStyle-CssClass="td_cont3 td_right">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Width="3%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="公廁地址" DataField="toilet_address" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_left" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="特優" DataField="first_level" ItemStyle-CssClass="td_cont3 td_right">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_right" />
                            <HeaderStyle HorizontalAlign="Center" Width="3%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="優等" DataField="second_level" ItemStyle-CssClass="td_cont3 td_right">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_right" />
                            <HeaderStyle HorizontalAlign="Center" Width="3%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="普通" DataField="third_level" ItemStyle-CssClass="td_cont3 td_right">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_right" />
                            <HeaderStyle HorizontalAlign="Center" Width="3%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="加強" DataField="fourth_level" ItemStyle-CssClass="td_cont3 td_right">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_right" />
                            <HeaderStyle HorizontalAlign="Center" Width="3%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="改善" DataField="fifth_level" ItemStyle-CssClass="td_cont3 td_right">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_right" />
                            <HeaderStyle HorizontalAlign="Center" Width="3%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="無障礙" DataField="disabled_toilet" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_center" />
                            <HeaderStyle HorizontalAlign="Center" Width="5%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="修改日期" DataField="update_date" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_left" />
                            <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="狀態" DataField="status" ItemStyle-CssClass="td_cont3 td_center">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                            <HeaderStyle HorizontalAlign="Center" Width="8%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="編輯">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="4%" />
                            <ItemStyle CssClass="td_cont3 td_center" />
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
                    <HeaderStyle CssClass="td_headmulti" />
                    <RowStyle CssClass="td_cont3" />
                    <EmptyDataTemplate>
                        無資料</EmptyDataTemplate>
                </asp:GridView>