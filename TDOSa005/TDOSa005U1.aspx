<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa005U1.aspx.cs" Inherits="TDTSa005_TDTSa005U1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
    <table width="100%" border="0" cellpadding="0" cellspacing="0" >
       <tr>
           <td width="12">
           </td>
           <td valign="top">
        <!-- 內容 -->
               <table width="600">
                   <tr>
                       <td>
                          <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                           <tr>
                                  <td class="td_head td_right" style="width:65%">修改修車廠狀態exec_end改為null    車牌號碼</td>
                                  <td class="td_cont">
                                    <asp:TextBox ID="car_no_1" runat="server"></asp:TextBox>
                                  </td>
                                  </tr>
                                <tr>
                                  <td class="td_head td_center"><span class="td_must">*</span>輸入新密碼</td>
                                  <td class="td_cont">
                                    <asp:TextBox ID="passwd" runat="server" MaxLength="20"></asp:TextBox>
                                   </td>
                                  </tr>
                                  <tr>
                                  <td class="td_head td_center"><span class="td_must">*</span>新密碼確認</td>
                                  <td class="td_cont">
                                    <asp:TextBox ID="passwd_check" runat="server" MaxLength="20"></asp:TextBox>
                                    </td>
                              </tr>
                          </table>
                       </td>
                   </tr>
               </table>
        <!-- BUTTON -->
               <table>
                   <tr>
                       <td>
                           <asp:Panel ID="buttonPanel" runat="server">
                               <asp:Button ID="btnSave" runat="server" Text="執行" CssClass="btn_grey" onclick="btnSave_Click" ValidationGroup="save"/>
                           </asp:Panel>
                       </td>
                   </tr>
               </table>
           </td>
       </tr>
</table>
</asp:Content>
