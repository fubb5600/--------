<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSe002Q1.aspx.cs" Inherits="TDOSe002_TDOSe002Q1" %>

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
                            <td class="td_head" width="10%">年度
                            </td>
                            <td class="td_cont" width="25%">
                                <%--原程式碼--%>
                                <%--<asp:TextBox ID="report_y" runat="server" Width="50px"></asp:TextBox>&nbsp;年度--%>
                                <%--wenny_年改下拉式選單--%>
<%--                                <asp:HiddenField ID="report_y" runat="server" Value="" />
                                <select id="ddlreport_y"></select> 年度--%>
                                 <asp:DropDownList ID="report_year" runat="server"></asp:DropDownList>
                                年度</td>
                            </td>
                            <td class="td_head" width="10%">匯入日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="import_start" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                ~
                                <asp:TextBox ID="import_end" runat="server" CssClass="date" Width="70px"></asp:TextBox>

                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="import_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="import_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click"  OnClientClick=" GetNotifyMsg();"
                                    UseSubmitBehavior="false" ValidationGroup="save" />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click"  OnClientClick=" GetNotifyMsg();"/>
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
                                EnableModelValidation="True" DataKeyNames="import_id" OnRowDeleting="gvMain_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="序號">
                                        <HeaderTemplate>
                                            <asp:Label ID="ROW_NUM_h" runat="server" Height="20px" Text='序號'></asp:Label>
                                            <asp:Button ID="ROW_NUM_s" runat="server" Height="18px" Width="24px" Text="▼" OnClick="btnQuery_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="ROW_NUM_sd" runat="server" Height="18px" Width="24px" Text="▲" OnClick="btnQueryd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="ROW_NUM_t" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ROW_NUM_l" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="匯入序號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="import_id_t" runat="server" Text='<%# Bind("import_id") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="import_id_h" runat="server" Height="20px" Text="匯入序號"></asp:Label>
                                            <asp:Button ID="import_id_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="import_id_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="import_id_l" runat="server" Text='<%# Bind("import_id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="年度">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="report_y_t" runat="server" Text='<%# Bind("report_y") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="report_y_h" runat="server" Height="20px" Text="年度"></asp:Label>
                                            <asp:Button ID="report_y_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="report_y_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="report_y_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="report_y_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="report_y_l" runat="server" Text='<%# Bind("report_y") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="匯入時間">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="import_date_t" runat="server" Text='<%# Bind("import_date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="import_date_h" runat="server" Height="20px" Text="匯入時間"></asp:Label>
                                            <asp:Button ID="import_date_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="import_date_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="import_date_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="import_date_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="import_date_l" runat="server" Text='<%# Bind("import_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="匯入人員">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="import_user_t" runat="server" Text='<%# Bind("import_user") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="import_user_h" runat="server" Height="20px" Text="匯入人員"></asp:Label>
                                            <asp:Button ID="import_user_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="import_user_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="import_user_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="import_user_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="import_user_l" runat="server" Text='<%# Bind("import_user") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="匯入筆數">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="count_t" runat="server" Text='<%# Bind("count") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="count_h" runat="server" Height="20px" Text="匯入筆數"></asp:Label>
                                            <asp:Button ID="count_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="count_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="count_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="count_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="count_l" runat="server" Text='<%# Bind("count", "{0:0,0}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_right" HorizontalAlign="Left" />
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
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="刪除">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" OnClientClick="return confirm('確定刪除?')"
                                                ImageUrl="~/images/delete.png" />
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
        <%--wenny_年改下拉式選單--%>
        <%--<script type="text/javascript" src="../js/Michael/DdlYearAndMonth-2.js"></script>--%> 
</asp:Content>
