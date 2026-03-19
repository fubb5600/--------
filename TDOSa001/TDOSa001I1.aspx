<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa001I1.aspx.cs" Inherits="TDTSa001_TDTSa001I1" %>

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
    <table width="100%" border="0" cellpadding="0" cellspacing="0" >
       <tr>
           <td width="12">
           </td>
           <td valign="top">
        <!-- 內容 -->
               <table width="800">
                   <tr>
                       <td>
                          <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                  <tr>
        <tr>
     <td width="15%" class="td_head">
         使用者帳號
     </td>
     <td width="35%" class="td_cont">
         <asp:TextBox ID="user_id" runat="server" Text=""></asp:TextBox>
     </td>
     <td width="15%" class="td_head">
         使用者姓名
     </td>
     <td width="35%" class="td_cont">
         <asp:TextBox ID="user_name" runat="server" Text=""></asp:TextBox>
     </td>
 </tr>
 <tr>
     <td class="td_head">
         編號
     </td>
     <td class="td_cont">
         <asp:TextBox ID="user_no" runat="server" Text=""></asp:TextBox>
     </td>
     <td class="td_head">
         職稱
     </td>
     <td class="td_cont">
 <asp:DropDownList ID="user_title" runat="server">
 </asp:DropDownList>     </td>
 </tr>
 <tr>
     <td class="td_head">
         單位
     </td>
     <td class="td_cont">
           <asp:DropDownList ID="user_dep" runat="server" OnSelectedIndexChanged="user_dep_SelectedIndexChanged"
      AutoPostBack="True">
  </asp:DropDownList>
  -
  <asp:DropDownList ID="sub_dep" runat="server">
  </asp:DropDownList>
     </td>
     <td class="td_head">
         部門
     </td>
     <td class="td_cont">
         <asp:TextBox ID="user_department" runat="server" Text=""></asp:TextBox>
     </td>
 </tr>
 <tr>
     <td class="td_head">
         聯絡電話1

     </td>
     <td class="td_cont">
         <asp:TextBox ID="user_cont1" runat="server" Text=""></asp:TextBox>
         
     </td>
     <td class="td_head">
         聯絡電話2
     </td>
     <td class="td_cont">
         <asp:TextBox ID="user_cont2" runat="server" Text=""></asp:TextBox>
 </tr>


                                       <tr>
     <td class="td_head">
        分機1

     </td>
     <td class="td_cont">
        <asp:TextBox ID="ExPhone" runat="server" Text=""></asp:TextBox>
     </td>
     <td class="td_head">
         分機2
     </td>
     <td class="td_cont">
          <asp:TextBox ID="ExPhone2" runat="server" Text=""></asp:TextBox>

 </tr>
 <tr>
     <td class="td_head">
         傳真
     </td>
     <td class="td_cont">
         <asp:TextBox ID="user_fax" runat="server" Text=""></asp:TextBox>
     </td>
     <td class="td_head">
         行動電話
     </td>
     <td class="td_cont">
         <asp:TextBox ID="user_mobile" runat="server" Text=""></asp:TextBox>
     </td>
 </tr>
 <tr>
     <td class="td_head">
         聯絡地址
     </td>
     <td class="td_cont">
         <asp:TextBox ID="user_address" runat="server" Text=""></asp:TextBox>
     </td>
     <td class="td_head">
         電子郵件
     </td>
     </td>
     <td class="td_cont">
         <asp:TextBox ID="user_email" runat="server" Text=""></asp:TextBox>
     </td>
 </tr>
                              <tr>
                                  <td class="td_head"><span class="td_must">*</span>使用者群組</td>
                                  <td class="td_cont">
                                    <asp:DropDownList ID="role_id" runat="server" >
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must" ErrorMessage="必填" 
                                        ControlToValidate="role_id" ValidationGroup="save" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                  </td>
                                  <td class="td_head"><span class="td_must">*</span>狀態</td>
                                  <td class="td_cont">
                                      <asp:DropDownList ID="status" runat="server" >
                                      </asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="td_must" ErrorMessage="必填" 
                                        ControlToValidate="status" ValidationGroup="save" Display="Dynamic">
                                      </asp:RequiredFieldValidator>
                                   </td>      
                              </tr>
                              <tr class="td_center td_headhrz">
                                  <td class="td_head td_center" colspan="4">使用者密碼

                                  </td>
                              </tr>
                                <tr>
                                  <td class="td_head td_center"><span class="td_must">*</span>使用者密碼</td>
                                  <td class="td_cont">
                                    <asp:TextBox ID="passwd" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must" ErrorMessage="必填"
                                        ControlToValidate="passwd" ValidationGroup="save" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                  </td>
                                  <td class="td_head td_center">密碼確認</td>
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
                               <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" onclick="btnSave_Click" ValidationGroup="save" OnClientClick="GetNotifyMsg();"/>     
                               <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" onclick="btnBack_Click" OnClientClick="GetNotifyMsg();"/>     
                           </asp:Panel>
                       </td>
                   </tr>
               </table>
           </td>
       </tr>
</table>
</asp:Content>
