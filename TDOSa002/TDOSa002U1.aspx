<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa002U1.aspx.cs" Inherits="TDOSa002_TDOSa002U1" %>

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
            <td width="12"></td>
            <td valign="top">
                <!-- 內容 -->
                <table width="1000">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td class="td_head td_right" style="width: 12%">參數代碼
                                    </td>
                                    <td class="td_cont" style="width: 15%">
                                        <asp:Label ID="param_type" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head td_right" style="width: 12%">
                                        <span class="td_must">*</span>參數名稱
                                    </td>
                                    <td class="td_cont" style="width: 20%">
                                        <asp:TextBox ID="param_name" runat="server" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="param_name" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head td_right" style="width: 12%">
                                        <span class="td_must">*</span>狀態
                                    </td>
                                    <td class="td_cont" style="width: 20%">
                                        <asp:RadioButtonList ID="status" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head td_right">備註
                                    </td>
                                    <td class="td_cont" colspan="5">
                                        <asp:TextBox ID="memo" runat="server" MaxLength="1000" Width="800"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Panel ID="pnlMain" runat="server">
                    <div class="table_title">
                        系統參數屬性列表
                    </div>
                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                        OnRowDataBound="gvMain_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1000px"
                        EnableModelValidation="True" DataKeyNames="param_id" OnRowEditing="gvMain_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="序號">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <asp:Label ID="ROW_NUM_h" runat="server" Height="20px" Text="序號"></asp:Label>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center"  />
                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="td_cont3 td_center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="屬性代碼">
                                <EditItemTemplate>
                                    <asp:TextBox ID="param_id_t" runat="server" Text='<%# Bind("param_id") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:Label ID="param_id_h" runat="server" Height="20px" Text="屬性代碼"></asp:Label>
                                    <asp:Button ID="param_id_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click"  />
                                    <asp:Button ID="param_id_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuery_Click" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="param_id_s_l" runat="server" Text='<%# Bind("param_id") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="15%" />
                                <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="屬性名稱">
                                <EditItemTemplate>
                                    <asp:TextBox ID="id_name_t" runat="server" Text='<%# Bind("id_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:Label ID="id_name_h" runat="server" Height="20px" Text="屬性名稱"></asp:Label>
                                    <asp:Button ID="id_name_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click"  />
                                    <asp:Button ID="id_name_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuery_Click"  />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="id_name_l" runat="server" Text='<%# Bind("id_name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="20%" />
                                <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="狀態">
                                <EditItemTemplate>
                                    <asp:TextBox ID="status_t" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:Label ID="status_h" runat="server" Height="20px" Text="狀態"></asp:Label>
                                    <asp:Button ID="status_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click"  />
                                    <asp:Button ID="status_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuery_Click"  />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="排序值">
                                <EditItemTemplate>
                                    <asp:TextBox ID="id_order_by_t" runat="server" Text='<%# Bind("id_order_by") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:Label ID="id_order_by_h" runat="server" Height="20px" Text="排序值"></asp:Label>
                                    <asp:Button ID="id_order_by_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click"  />
                                    <asp:Button ID="id_order_by_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuery_Click"  />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("id_order_by") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="10%" />
                                <ItemStyle CssClass="td_cont3 td_center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註">
                                <EditItemTemplate>
                                    <asp:TextBox ID="memo_t" runat="server" Text='<%# Bind("memo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:Label ID="memo_h" runat="server" Height="20px" Text="備註"></asp:Label>
                                    <asp:Button ID="memo_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click"  />
                                    <asp:Button ID="memo_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQuery_Click"  />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="memo_l" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" />
                                <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="編輯">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
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
                    <!-- BUTTON -->
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="buttonPanel" runat="server" Width="422px">
                                    <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click" OnClientClick="GetNotifyMsg();"
                                        ValidationGroup="save" />
                                    <asp:Button ID="btnInsert" runat="server" Text="新增屬性" CssClass="btn_grey" OnClick="btnInsert_Click" OnClientClick="GetNotifyMsg();"
                                        ValidationGroup="save" />
                                    <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" OnClientClick="GetNotifyMsg();" />
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlEdit" runat="server" Visible="false">
                    <div style="text-align: center; width: 1000px;">
                        <div class="table_title" style="width: 700px">
                            系統參數屬性編輯
                        </div>
                        <table width="700px" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <td class="td_head td_right" style="width: 20%">
                                    <span class="td_must">*</span>屬性代碼
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="param_id" runat="server" MaxLength="20"></asp:TextBox>
                                    <asp:HiddenField ID="original_id" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                        ErrorMessage="必填" ControlToValidate="param_id" ValidationGroup="id_save" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="td_must"
                                        ErrorMessage="英文字母或數字" ControlToValidate="param_id" ValidationGroup="id_save" Display="Dynamic"
                                        ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                                    <asp:HiddenField ID="hfAction" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_head td_right">
                                    <span class="td_must">*</span>屬性名稱
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="id_name" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                        ErrorMessage="必填" ControlToValidate="id_name" ValidationGroup="id_save" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="original_id_name" runat="server" /><!--修正維修廠商沒有資料_wenny1061218-->
                                </td>
                            </tr>
                            <tr>
                                <td class="td_head td_right">
                                    <span class="td_must">*</span>狀態
                                </td>
                                <td class="td_cont">
                                    <asp:RadioButtonList ID="id_status" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_head td_right">
                                    <span class="td_must">*</span>排序值
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="id_order_by" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="td_must"
                                        ErrorMessage="數字" ControlToValidate="id_order_by" ValidationGroup="id_save" Display="Dynamic"
                                        ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_head td_right">備註
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="id_memo" runat="server" MaxLength="1000" Width="500"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <!-- BUTTON -->
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:Button ID="btnIdSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnIdSave_Click" OnClientClick="GetNotifyMsg();"
                                            ValidationGroup="id_save" />
                                        <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn_grey" OnClick="btnCancel_Click" OnClientClick="GetNotifyMsg();" />
                                        <asp:Button ID="btnIdDelete" runat="server" Text="刪除" CssClass="btn_grey" OnClick="btnIdDelete_Click" OnClientClick="GetNotifyMsg();" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
