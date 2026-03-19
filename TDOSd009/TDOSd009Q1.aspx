<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSd009Q1.aspx.cs" Inherits="TDOSd009_TDOSd009Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            text-align: left;
            font-weight: normal;
            border-bottom: 1px dotted #d0d0bf;
            border-right: 1px solid #d0d0bf;
            padding-left: 5px;
            width: 24%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12"></td>
            <td valign="top" width="1080px">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td width="10%" class="td_head">庫存
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="Thing" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">&nbsp;使用者</td>
                            <td class="td_cont">
                                   <!-- //2018/08/31測試查驗結果Checkbox-->
                                    <asp:DropDownList ID="User" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                              <td width="10%" class="td_head">&nbsp;</td>
                            <td class="td_cont">
                                   <!-- //2018/08/31測試查驗結果Checkbox-->
                            </td>
                        </tr>
                                                                     
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click"
                                    ValidationGroup="save" TabIndex="0" />
                                <%--UseSubmitBehavior="false"--%>
                                <asp:HiddenField ID="sortedfield" runat="server" />
                                <asp:Button ID="btnQuery1" runat="server" CssClass="btn_grey"  TabIndex="0" Text="產出報表" ValidationGroup="save" OnClick="btnQuery1_Click" style="margin-top: 0" Width="123px" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;
                </p>
                <!-- 瀏覽頁, 進入時先隱藏 -->
                <table class="table_sn" id="num_1">
                    <tr>
                        <td>
                            <!-- 分頁處理 -->
                            <asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                 BorderWidth="1px" CellPadding="0" Width="1600px"
                                EnableModelValidation="True"   RowStyle-Height="50"  style="margin-top: 0" >
                                <Columns>
                                
                                    <asp:TemplateField HeaderText="使用者">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="User" runat="server" Text='<%# Bind("User1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                          <HeaderTemplate>
                                            <asp:Label ID="User" runat="server" Height="20px" Text="使用者"></asp:Label>
                                           
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="User" runat="server" Text='<%# Bind("User1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                           
                                    <asp:TemplateField HeaderText="庫存">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Thing" runat="server" Text='<%# Bind("Thing") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Thing" runat="server" Height="20px" Text="庫存"></asp:Label>
                                           
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Thing" runat="server" Text='<%# Bind("Thing") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="數量">
                                        <HeaderTemplate>
                                            <asp:Label ID="Count" runat="server" Height="20px" Text="數量"></asp:Label>
                                           

                                        </HeaderTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="Count" runat="server" Text='<%# Bind("Count") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Count" runat="server" Text='<%# Bind("Count") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                             
                                </Columns>
                                <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
                                <HeaderStyle CssClass="td_headmulti" />
                                <RowStyle CssClass="td_cont3" />
                                <EmptyDataTemplate>
                                    無資料
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Panel ID="pnlPrint" runat="server">
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!-- 留下空行的位置　-->
        <tr>
            <td height="10" colspan="2"></td>
        </tr>
    </table>
    <script type="text/javascript" src="../js/Michael/Ccbselect-1.js"></script>
</asp:Content>
