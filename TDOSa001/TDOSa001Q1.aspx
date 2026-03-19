<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa001Q1.aspx.cs" Inherits="TDOSa001_TDOSa001Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <!--提醒託修作業資料未建置完整_WENNY_1061206-->
    <script type="text/javascript" language="javascript">

        function GetNotifyMsg() {
            var str = '<%= Session["NOTIFYMSG"].ToString()%>';
            if (str != "")
                alert(str);
            return true;
        }
    </script>
        <tr>
            <td width="12"></td>
            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td width="10%" class="td_head">單位
                            </td>
                            <td class="td_cont">
                                <asp:DropDownList ID="user_dep" runat="server" OnSelectedIndexChanged="user_dep_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                -
                                <asp:DropDownList ID="sub_dep" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="td_head">使用者群組</td>
                            <td class="td_cont">
                                <asp:DropDownList ID="user_role" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="10%" class="td_head">職稱
                            </td>
                            <td class="td_cont">
                                <asp:DropDownList ID="user_title" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" class="td_head">使用者帳號
                            </td>
                            <td width="20%" class="td_cont">
                                <asp:TextBox ID="user_id" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">使用者姓名
                            </td>
                            <td width="20%" class="td_cont">
                                <asp:TextBox ID="user_name" runat="server" MaxLength="12"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">狀態
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="status" runat="server" RepeatDirection="Horizontal">
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
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click" UseSubmitBehavior="false" OnClientClick="GetNotifyMsg();" />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" Visible="false" OnClick="btnInsert_Click" OnClientClick="GetNotifyMsg();" />
                                <asp:HiddenField ID="sortedfield" runat="server" />
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
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1200px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="user_id">
                                <Columns>
                                    <asp:TemplateField HeaderText="序號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="ROW_NUM_t" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="ROW_NUM_h" runat="server" Height="20px" Text="序號"></asp:Label>
                                            <asp:Button ID="ROW_NUM_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false"/>
                                             <asp:Button ID="ROW_NUM_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ROW_NUM_l" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="使用者帳號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="user_id_t" runat="server" Text='<%# Bind("user_id") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="user_id_h" runat="server" Height="20px" Text="使用者帳號"></asp:Label>
                                            <asp:Button ID="user_id_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="user_id_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="user_id_l" runat="server" Text='<%# Bind("user_id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="使用者姓名">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="user_name_t" runat="server" Text='<%# Bind("user_name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="user_name_h" runat="server" Height="20px" Text="使用者姓名"></asp:Label>
                                            <asp:Button ID="user_name_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="user_name_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="user_name_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="user_name_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="user_name_l" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="使用者狀態">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="status_t" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="status_h" runat="server" Height="20px" Text="使用者狀態"></asp:Label>
                                            <asp:Button ID="status_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="status_s_Click" UseSubmitBehavior="false"/>
                                             <asp:Button ID="status_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="status_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="status_l" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="單位">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="DepName_t" runat="server" Text='<%# Bind("DepName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="DepName_h" runat="server" Height="20px" Text="單位"></asp:Label>
                                            <asp:Button ID="DepName_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="DepName_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="DepName_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="DepName_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="DepName_l" runat="server" Text='<%# Bind("DepName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="部門">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Department_t" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Department_h" runat="server" Height="20px" Text="部門"></asp:Label>
                                            <asp:Button ID="Department_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="Department_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="Department_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="Department_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Department_l" runat="server" Text='<%# Bind("Department") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="職稱">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Professional_t" runat="server" Text='<%# Bind("Professional") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Professional_h" runat="server" Height="20px" Text="職稱"></asp:Label>
                                            <asp:Button ID="Professional_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="Professional_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="Professional_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="Professional_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Professional_l" runat="server" Text='<%# Bind("Professional") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="使用者群組">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="role_name_l" runat="server" Text='<%# Bind("role_name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="role_name_h" runat="server" Height="20px" Text="使用者群組"></asp:Label>
                                            <asp:Button ID="role_name_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="role_name_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="role_name_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="role_name_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="role_name_l" runat="server" Text='<%# Bind("role_name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="編輯">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                        </ItemTemplate>

                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" />
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
</asp:Content>
