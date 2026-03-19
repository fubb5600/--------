<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin: 20px;">
        <table border="0" cellspacing="1" bordercolor="#333333" cellpadding="0" width="80%"
            bgcolor="#999999" align="center">
            <tbody>
                <tr>
                    <td height="33" background="../images/title_bg.gif" align="center">
                        <a class="font_table" href="#">系統更新公告</a>
                    </td>
                </tr>
                <tr>
                    <td style="  background-color: #fff; background-repeat: repeat-x;
                        background-position: 50% bottom;" valign="top">
                        <table width="100%">
                            <tr>
                                <td align="left" style="font-size: small; padding-left: 35px; padding-top: 15px;
                                    padding-right: 25px;" class="td_cont">
                                    <ol type="1">
                                        <li><strong>勤務記錄管理</strong>開放跨月的勤務記錄資料登打。</li>
                                    </ol>
                                    <br />
                                    <div style="float: right">
                                        系統更新時間：101/11/01 13:50</div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="33" background="../images/title_bg.gif" align="center">
                        <a class="font_table" href="#">車輛定檢通知</a>
                    </td>
                </tr>
                <tr>
                    <td style=" background-color: #fff; background-repeat: repeat-x;
                        background-position: 50% bottom;" valign="top">
                        <table width="100%">
                            <tr>
                                <td align="left" style="font-size: small; 
                                    padding: 25px;" class="td_cont">
                                    <%--     <ol type="1">
                                        <li><strong>勤務記錄管理</strong>開放跨月的勤務記錄資料登打。</li>
                                    </ol>
                                    <br /> --%>
                                    <asp:GridView ID="gvUnInspected" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                        BorderWidth="1px" CellPadding="0" Width="1000px" EnableModelValidation="True"
                                        DataKeyNames="car_id" OnRowDataBound="gvInspection_RowDataBound"
                                        OnRowEditing="gvInspection_RowEditing">
                                        <Columns>                                           
                                            <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="8%" CssClass="td_center td_headhrz td_headmulti" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="保管單位" DataField="keep_org">
                                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="td_center td_headhrz td_headmulti" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="局編號" DataField="dep_no">
                                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="車牌號碼" DataField="car_no" ItemStyle-CssClass="td_cont3 td_left">
                                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="下次定檢日" DataField="next_inspection">
                                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                                <HeaderStyle HorizontalAlign="Center" Width="15%"  CssClass="td_center td_headhrz td_headmulti" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="可檢驗時間" DataField="next_inspection">
                                                <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                                <HeaderStyle HorizontalAlign="Center"  CssClass="td_center td_headhrz td_headmulti" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="編輯">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="5%" />
                                                <ItemStyle CssClass="td_cont3 td_center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            無資料</EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
