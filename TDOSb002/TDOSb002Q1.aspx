<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSb002Q1.aspx.cs" Inherits="TDOSb002_TDOSb002Q1" %>

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
                            <td class="td_head" width="10%">
                                報表年月
                            </td>
                            <td class="td_cont" width="25%">
                              <%--  <asp:TextBox ID="report_y" runat="server" Width="50px"></asp:TextBox>&nbsp;年&nbsp;
                                <asp:TextBox ID="report_m" runat="server" Width="50px"></asp:TextBox>&nbsp;月  --%>
                                    <asp:DropDownList ID="report_y" runat="server">
                                </asp:DropDownList>&nbsp;年&nbsp;
                                <asp:DropDownList ID="report_m" runat="server">
                                </asp:DropDownList>&nbsp;月 
                            </td>
                            <td class="td_head" width="10%">
                                匯入日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="import_start" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                ~
                                <asp:TextBox ID="import_end" runat="server" CssClass="date" Width="70px"></asp:TextBox>
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
                                    ValidationGroup="save" />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" style="margin-top: 0" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="sortedfield" runat="server" />
                <p>
                    &nbsp;</p>
                <!-- 瀏覽頁, 進入時先隱藏 -->
                <table class="table_sn" id="num_1">
                    <tr>
                        <td>
                            <!-- 分頁處理 -->
                            <asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1000px"
                                EnableModelValidation="True" DataKeyNames="import_id" OnRowDeleting="gvMain_RowDeleting">
                                <Columns>
                                    <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="匯入序號" DataField="import_id">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="報表年月" DataField="report_ym">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="匯入時間" DataField="import_date">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="匯入人員" DataField="import_user">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="匯入筆數" DataField="count" ItemStyle-CssClass="td_cont3 td_right"
                                        DataFormatString="{0:0,0}">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="8%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="備註" DataField="memo" ItemStyle-CssClass="td_cont3 td_left">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="刪除">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" OnClientClick="return confirm('確定刪除?')"
                                                ImageUrl="~/images/del.png" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
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
