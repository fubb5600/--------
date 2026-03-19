<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc004Q1.aspx.cs" Inherits="TDOSc004_TDOSc004Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="1200px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td width="10%" class="td_head">
                                加油卡卡別
                            </td>
                            <td class="td_cont">
                            <asp:CheckBoxList ID="card_type" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                            <td width="10%" class="td_head">
                                加油卡卡號
                            </td>
                            <td width="40%" class="td_cont">
                                <asp:TextBox ID="card_no" runat="server"></asp:TextBox>
                            </td>
                            </tr>
                            <tr> 
                            <td class="td_head">
                                油品類型
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="fuel_type" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>  
                            <td class="td_head">
                                狀態
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="status" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>                                       
                        </tr>
                        <tr>
                            <td class="td_head">
                                保管單位
                            </td>
                            <td class="td_cont" colspan="3">
                                <asp:CheckBoxList ID="keep_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="7" CssClass="cbl_fieldset">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click" />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;</p>
                <asp:HiddenField ID="sortedfield" runat="server" />
                <!-- 瀏覽頁, 進入時先隱藏 -->
                <table class="table_sn" id="num_1">
                    <tr>
                        <td>
                            <!-- 分頁處理 -->
                            <asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="800px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="card_id">
                                <Columns>
                                    <asp:TemplateField HeaderText="序號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="ROW_NUM_t" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="ROW_NUM_h" runat="server" Height="20px" Text="序號"></asp:Label>
                                            <asp:Button ID="ROW_NUM_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="ROW_NUM_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ROW_NUM_l" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="加油卡卡別">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="card_type_t" runat="server" Text='<%# Bind("card_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="card_type_h" runat="server" Height="20px" Text="加油卡卡別"></asp:Label>
                                            <asp:Button ID="card_type_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuerycard_type_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="card_type_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuerydcard_typed_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="card_type_1" runat="server" Text='<%# Bind("card_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="加油卡卡號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="card_type_t" runat="server" Text='<%# Bind("card_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="card_no_h" runat="server" Height="20px" Text="加油卡卡別"></asp:Label>
                                            <asp:Button ID="card_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuerycard_no_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="card_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuerydcard_nod_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="card_no_1" runat="server" Text='<%# Bind("card_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="保管單位">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="keep_org_t" runat="server" Text='<%# Bind("keep_org") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="keep_org_h" runat="server" Height="20px" Text="保管單位"></asp:Label>
                                            <asp:Button ID="keep_org_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuerykeep_org_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="keep_org_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuerykeep_orgd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="keep_org_1" runat="server" Text='<%# Bind("keep_org") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                  
                                     <asp:TemplateField HeaderText="油品類型">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="fuel_type_t" runat="server" Text='<%# Bind("fuel_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="fuel_type_h" runat="server" Height="20px" Text="油品類型"></asp:Label>
                                            <asp:Button ID="fuel_type_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQueryfuel_type_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="fuel_type_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryfuel_typed_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="fuel_type_1" runat="server" Text='<%# Bind("fuel_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="狀態">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="status_t" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="status_h" runat="server" Height="20px" Text="狀態"></asp:Label>
                                            <asp:Button ID="status_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuerystatus_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="status_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuerystatusd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="status_1" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                   
                                    <%--<asp:BoundField HeaderText="保管人" DataField="keep_man">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="23%" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:BoundField>--%>
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
            </td>
        </tr>
        <!-- 留下空行的位置　-->
        <tr>
            <td height="10" colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
