<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa004U1.aspx.cs" Inherits="TDTSa004_TDTSa004U1" %>

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
                                  <td class="td_head td_center" style="width:35%"><span class="td_must">*</span>輸入舊密碼</td>
                                  <td class="td_cont">
                                    <asp:TextBox ID="old_passwd" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must" ErrorMessage="必填"
                                        ControlToValidate="old_passwd" ValidationGroup="save" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                  </td>
                                  </tr>
                                <tr>
                                  <td class="td_head td_center"><span class="td_must">*</span>輸入新密碼</td>
                                  <td class="td_cont">
                                    <asp:TextBox ID="passwd" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must" ErrorMessage="必填"
                                        ControlToValidate="passwd" ValidationGroup="save" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                  </td>
                                  </tr>
                                  <tr>
                                  <td class="td_head td_center"><span class="td_must">*</span>新密碼確認</td>
                                  <td class="td_cont">
                                    <asp:TextBox ID="passwd_check" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must" ErrorMessage="必填"
                                        ControlToValidate="passwd_check" ValidationGroup="save" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="td_must" ErrorMessage="確認不符"
                                        ControlToValidate="passwd_check" ControlToCompare="passwd" Operator="Equal" Type="String"
                                        ValidationGroup="save" Display="Dynamic">
                                    </asp:CompareValidator>
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
                               <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" onclick="btnSave_Click" ValidationGroup="save"/>
                           </asp:Panel>
                       </td>
                   </tr>
               </table>
           </td>
       </tr>
</table>
</asp:Content>
