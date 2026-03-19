<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSe001Q1.aspx.cs" Inherits="TDOSe001_TDOSe001Q1" %>

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
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td class="td_head">零件編號
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="component_no" runat="server"></asp:TextBox>
                            </td>
                            <td class="td_head">項目名稱
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="component_name" runat="server"></asp:TextBox>
                            </td>
                            <td class="td_head">規格
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="component_spec" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">報表年度
                            </td>
                            <td class="td_cont">
                                <%--原程式碼--%>
                                <%--<asp:TextBox ID="report_year" runat="server"></asp:TextBox>--%>
                                <%--年改下拉式選單--%>
                                <%--<asp:HiddenField ID="report_y" runat="server" Value="" />
                                <select id="ddlreport_y"></select> 年度--%>
                                <asp:DropDownList ID="report_year" runat="server"></asp:DropDownList>
                                年度</td>
                            <td class="td_head">代碼
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="component_code" runat="server"></asp:TextBox>
                            </td>
                            <td class="td_head">適用車種
                            </td>
                            <td class="td_cont">
                                <asp:DropDownList ID="car_type" runat="server">
                                </asp:DropDownList>
                            </td>
                            <%--<td class="td_head">
                                預算單價
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="budget_start" runat="server"  Width="70px"></asp:TextBox>~
                                <asp:TextBox ID="budget_end" runat="server"  Width="70px"></asp:TextBox>
                            </td>--%>
                        </tr>
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click" OnClientClick=" GetNotifyMsg();"
                                    UseSubmitBehavior="false"  />
                                <asp:Button ID="btnExport" runat="server" Text="匯出" CssClass="btn_grey" OnClick="btnExport_Click" OnClientClick=" GetNotifyMsg();"  />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" OnClientClick=" GetNotifyMsg();" />
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
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1500px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="component_no">
                                <Columns>
                                    <asp:TemplateField HeaderText="序號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="ROW_NUM_t" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="ROW_NUM_h" runat="server" Text="序號" Height="20px"></asp:Label>
                                            <asp:Button ID="ROW_NUM_s" runat="server" Text="▼" Height="18px" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="ROW_NUM_sd" runat="server" Text="▲" Height="18px" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ROW_NUM_l" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Height="25px" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="零件編號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="component_no_t" runat="server" Text='<%# Bind("component_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="component_no_h" runat="server" Text="零件編號"></asp:Label>
                                            <asp:Button ID="component_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="component_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="component_no_l" runat="server" Text='<%# Bind("component_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Height="25px" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="項目名稱">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="component_name_t" runat="server" Text='<%# Bind("component_name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="component_name_h" runat="server" Text="項目名稱"></asp:Label>
                                            <asp:Button ID="component_name_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="component_name_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="component_name_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="component_name_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="component_name_l" runat="server" Text='<%# Bind("component_name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="規格">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="component_spec_t" runat="server" Text='<%# Bind("component_spec") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="component_spec_h" runat="server" Height="20px" Text="規格"></asp:Label>
                                            <asp:Button ID="component_spec_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="component_spec_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="component_spec_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="component_spec_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="component_spec_l" runat="server" Text='<%# Bind("component_spec") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="單位">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="unit_t" runat="server" Text='<%# Bind("unit") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="unit_h" runat="server" Text="單位"></asp:Label>
                                            <asp:Button ID="unit_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="unit_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="unit_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="unit_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="unit_l" runat="server" Text='<%# Bind("unit") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="預算單價(第2區)">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="budget2_t" runat="server" Text='<%# Bind("budget2") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="budget2_h" runat="server" Height="20px" Text="預算單價"></asp:Label>
                                            <asp:Button ID="budget2_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="budget2_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="budget2_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="budget2_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="budget2_l" runat="server" Text='<%# Bind("budget2", "{0:N0}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="代碼">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="component_code_t" runat="server" Text='<%# Bind("component_code") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="component_code_h" runat="server" Text="代碼"></asp:Label>
                                            <asp:Button ID="component_code_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="component_code_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="component_code_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="component_code_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="component_code_l" runat="server" Text='<%# Bind("component_code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="適用車種">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_type_t" runat="server" Text='<%# Bind("car_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_type_h" runat="server" Height="20px" Text="適用車種"></asp:Label>
                                            <asp:Button ID="car_type_s" runat="server" Text="▼" Height="18px" Width="24px" OnClick="car_type_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="car_type_sd" runat="server" Text="▲" Height="18px" Width="24px" OnClick="car_type_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_type_l" runat="server" Text='<%# Bind("car_type") %>'></asp:Label>
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
                                            <asp:Button ID="memo_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="memo_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="memo_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="memo_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="memo_l" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="編輯">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="40px" />
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
      <%--年改下拉式選單--%>
      <%--<script type="text/javascript" src="../js/Michael/DdlYearAndMonth-2.js"></script>--%>
</asp:Content>
