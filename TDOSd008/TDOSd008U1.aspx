<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSd008U1.aspx.cs" Inherits="TDOSd008_TDOSd008U1" %>

<%@ Register Src="../Common/car_data_CRS.ascx" TagName="car_data_CRS" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 12px;
        }
        .auto-style2 {
            height: 26px;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="auto-style1"></td>
            <td valign="top">
                <!-- 內容 -->
                <table width="900">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="2">庫存</td>
                                </tr>
                                <tr>
                                    <td class="td_head" width="15%">


                                        派工單號(舊)
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="work_no" runat="server" Enabled = "False"></asp:TextBox>
                                        <asp:Label ID="Label1" runat="server" Text="" Visible="false" 　></asp:Label>
                                    </td>
                                </tr>
                                    <tr>
                                    <td class="td_head" width="15%">
                                        車牌號碼(舊)</td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="Car" runat="server" Enabled = "False"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td class="td_head" width="15%">


                                        使用派工單號
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="UseNo" runat="server" ></asp:TextBox>
                                    </td>
                                </tr>
                                    <tr>
                                    <td class="td_head" width="15%">
                                         使用車牌號碼</td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="UseCar" runat="server" ></asp:TextBox>
                                    </td>
                                </tr>



                                <tr>
                                    <td class="td_head" width="15%">
                                        物料</td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="Thing" runat="server" Enabled = "False" Width="727px"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="td_head" width="15%">
                                        零件編碼</td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="No" runat="server" Enabled = "False" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head" width="15%">
                                        數量</td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="Count" runat="server" Enabled = "False"></asp:TextBox>
                                    </td>
                                </tr>
                                   <tr>
                                    <td class="td_head" width="15%">
                                        使用數量</td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="Count1" runat="server"  ></asp:TextBox>
                                    </td>
                                </tr>
                                    <tr>
                                    <td class="td_head" width="15%">
                                        使用者	</td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="User" runat="server" Enabled = "False"></asp:TextBox>
                                        <asp:TextBox ID="User2" runat="server"  Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                    <tr>
                                    <td class="td_head">新增庫存日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="InsertTime" runat="server"  Width="209px" Enabled = "False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">使用庫存日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="UseTime" runat="server" CssClass="date" Width="209px" class="date" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">備註+(說明)
                                    </td>
                                    <td class="td_cont">
                                                                             <asp:TextBox ID="Memo" runat="server" TextMode="MultiLine" Width="600px" Rows="3" ></asp:TextBox>
</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td class="auto-style2">
                            <div>       
                                
                                
                                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click"
                                    ValidationGroup="save"    />
<%--                                <asp:Button ID="btndelete" runat="server" Text="刪除" CssClass="btn_grey" OnClick="btnBack_Click" Visible="false" />--%>

                            </div>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
