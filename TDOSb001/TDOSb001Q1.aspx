<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSb001Q1.aspx.cs" Inherits="TDOSb001_TDOSb001Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td class="td_head">
                                資料來源
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="data_source" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                            <td class="td_head">
                                確認狀態
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="cfm_status" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                            <td class="td_head">
                                審核狀態
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="adt_status" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">
                                報表年月
                            </td>
                            <td class="td_cont">
                               <%-- <asp:TextBox ID="report_y" runat="server" Width="50px"></asp:TextBox>&nbsp;年&nbsp;
                                <asp:TextBox ID="report_m" runat="server" Width="50px"></asp:TextBox>&nbsp;月--%>
                             
                                <asp:DropDownList ID="report_y" runat="server">
                                </asp:DropDownList>
                                年<asp:DropDownList ID="report_m" runat="server">
                                </asp:DropDownList>
                                月</td>
                            <td class="td_head">
                                交易日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="deal_start" runat="server" CssClass="date" Width="70px"></asp:TextBox>~
                                <asp:TextBox ID="deal_end" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="deal_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="deal_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td class="td_head">
                                加油站
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="stand_name" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">
                                匯入序號
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="import_id" runat="server"></asp:TextBox>
                            </td>
                            <td class="td_head">
                                匯入日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="import_start" runat="server" CssClass="date" Width="70px"></asp:TextBox>~
                                <asp:TextBox ID="import_end" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="import_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="import_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td width="10%" class="td_head">
                                油品類型
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="fuel_type" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" class="td_head">
                                局編號
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                            </td>
                            <td class="td_head">
                                管理單位
                            </td>
                            <td class="td_cont">
                                <asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                                </asp:DropDownList>
                                <td width="10%" class="td_head">
                                    加油卡卡號
                                </td>
                                <td class="td_cont">
                                    <asp:DropDownList ID="card_type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="card_type_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="card_id" runat="server">
                                    </asp:DropDownList>
                                </td>
                        </tr>
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" ValidationGroup="save"
                                    OnClick="btnQuery_Click" />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" />
                                <asp:Button ID="btnBatchAudit" runat="server" Text="批次審核" CssClass="btn_grey" OnClick="btnBatchAudit_Click" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;</p>
                <!-- 瀏覽頁, 進入時先隱藏 -->
                <table class="table_sn" id="num_1">
                    <tr>
                        <td>
                            <!-- 分頁處理 -->
                            <asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1100px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="fuel_id,data_source">
                                <Columns>
                                    <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Height="25" Width="8%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="資料來源" DataField="source_name" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="匯入序號" DataField="import_id" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="6%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="管理單位" DataField="mng_name" ItemStyle-CssClass="td_cont3 td_left">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="11%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="加油卡卡號" DataField="card_no">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="9%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="交易日期" DataField="deal_date">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                        <HeaderStyle HorizontalAlign="Center" Width="13%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="加油站" DataField="stand_name">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="油品類型" DataField="fuel_name">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="數量" DataField="fuel_count">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="參考金額" DataField="fuel_amount" DataFormatString="{0:0,0}">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="確認 / 審核" DataField="">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="編輯">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="5%" />
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
