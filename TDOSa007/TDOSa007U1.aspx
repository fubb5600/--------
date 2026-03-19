<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa007U1.aspx.cs" Inherits="TDTSa007_TDTSa007U1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 12px;
        }
        .auto-style2 {
            width: 18%;
        }
        .auto-style3 {
            margin-right: 698px;
        }
        .auto-style4 {
            text-align: left;
            font-weight: normal;
            border-bottom: 1px dotted #d0d0bf;
            border-right: 1px solid #d0d0bf;
            padding-left: 5px;
            width: 1374px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
    <table width="100%" border="0" cellpadding="0" cellspacing="0" >
       <tr>
           <td class="auto-style1">
           </td>
           <td valign="top">
        <!-- 內容 -->
               <table width="600" class="auto-style3">
                   <tr>
                       <td>
                          <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                 <tr>
                                  <td class="auto-style2">群組名稱</td>
                                  <td class="auto-style4">
                                      中文<asp:TextBox ID="name" runat="server"></asp:TextBox>
                                      英文<asp:TextBox ID="name1" runat="server"></asp:TextBox>
                                     </td>
                                  </tr>
                              <tr>
                                  <td class="auto-style2">系統帳號</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSa001_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSa001_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSa001_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSa001_update" runat="server" />
                                  </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">系統參數</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSa002_delete" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSa002_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSa002_update" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">基本參數</td>
                                  <td class="auto-style4">
                                      修改<asp:CheckBox ID="TDOSa003_update" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">密碼變更</td>
                                  <td class="auto-style4">
                                      修改<asp:CheckBox ID="TDOSa004_update" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">群組設定</td>
                                  <td class="auto-style4">
                                      新增<asp:CheckBox ID="TDOSa007_insert" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">刪除群組</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSa008_delete" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">加油資料管理</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSb001_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSb001_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSb001_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSb001_update" runat="server" />
                                      修改<asp:CheckBox ID="TDOSb001_audit" runat="server" />
                                   </td>
                                  </tr>

                           <tr>
                                  <td class="auto-style2">加油資料匯入</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSb002_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSb002_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSb002_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSb002_update" runat="server" />
                                  </td>
                                  </tr>
                                <tr>
                                  <td class="auto-style2">車輛基本資料</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSc001_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSc001_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSc001_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSc001_update" runat="server" />
                                      全部匯出<asp:CheckBox ID="TDOSc001_Allinsert" runat="server" />
                                    </td>
                                  </tr>
                                <tr>
                                  <td class="auto-style2">車輛異動記錄</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSc002_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSc002_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSc002_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSc002_update" runat="server" />
                                    </td>


                                  </tr>
                                  <tr>
                                  <td class="auto-style2">勤務記錄管理</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSc003_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSc003_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSc003_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSc003_update" runat="server" />
                                      </td>
                              </tr>
                                <tr>
                                  <td class="auto-style2">加油卡資料</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSc004_query" runat="server" />
                                      新增<asp:CheckBox ID="TDOSc004_insert" runat="server" />
                                     
                                    </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">載重資料匯入</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSc005_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSc005_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSc005_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSc005_update" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">服勤耗油統計</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd001_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSd001_update" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">車輛服勤記錄</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd002_query" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">總表</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd003_query" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">留廠車輛報表</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd004_query" runat="server" />
                                   </td>
                                  </tr>

                           <tr>
                                  <td class="auto-style2">委外託修報表</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd005_query" runat="server" />
                                  </td>
                                  </tr>
                                <tr>
                                  <td class="auto-style2">車輛定檢月報</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd006_query" runat="server" />
                                    </td>
                                  </tr>
                                <tr>
                                  <td class="auto-style2">廢品報表</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd007_query" runat="server" />
                                    </td>


                                  </tr>
                                  <tr>
                                  <td class="auto-style2">庫存使用紀錄</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd008_query" runat="server" />
                                      刪除<asp:CheckBox ID="TDOSd008_delete" runat="server" />
                                      </td>
                              </tr>

                                </tr>
                                  <tr>
                                  <td class="auto-style2">庫存</td>
                                  <td class="auto-style4">
                                      查詢<asp:CheckBox ID="TDOSd009_query" runat="server" />
                                  
                                      </td>
                              </tr>
                                <tr>
                                  <td class="auto-style2">標案項目管理</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSe001_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSe001_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSe001_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSe001_update" runat="server" />
                                    </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">標案項目匯入</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSe002_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSe002_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSe002_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSe002_update" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">車輛報修作業</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSf001_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSf001_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSf001_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSf001_update" runat="server" />
                                      列印<asp:CheckBox ID="TDOSf001_print" runat="server" />
                                   </td>
                                  </tr>
                               <tr>
                                  <td class="auto-style2">委外託修作業</td>
                                  <td class="auto-style4">
                                      刪除<asp:CheckBox ID="TDOSf002_delete" runat="server" />
                                      新增<asp:CheckBox ID="TDOSf002_insert" runat="server" />
                                      查詢<asp:CheckBox ID="TDOSf002_query" runat="server" />
                                      修改<asp:CheckBox ID="TDOSf002_update" runat="server" />
                                      列印<asp:CheckBox ID="TDOSf002_print" runat="server" />
                                   </td>
                                  </tr>
                             <tr>
                                   <td class="auto-style2">保管單位
                                       )<td class="auto-style4" colspan="5">
                                       <asp:CheckBoxList ID="keep_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="8"
                                        CssClass="cbl_fieldset">
                                           <asp:ListItem Value="TT002I591">士林區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I592">大同區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I593">大安區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I594">中山區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I595">中正區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I596">內湖區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I597">文山區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I598">公廁管理隊</asp:ListItem>
                                            <asp:ListItem Value="TT002I599">北投區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I600">環境檢驗中心</asp:ListItem>
                                           <asp:ListItem Value="TT002I601">松山區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I602">直屬清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I603">信義區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I604">南港區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I605">政風室</asp:ListItem>
                                           <asp:ListItem Value="TT002I606">修車廠</asp:ListItem>
                                           <asp:ListItem Value="TT002I607">秘書室</asp:ListItem>
                                           <asp:ListItem Value="TT002I608">廢棄物處理場</asp:ListItem>
                                           <asp:ListItem Value="TT002I609">清山淨水</asp:ListItem>
                                           <asp:ListItem Value="TT002I610">空污噪音防制科</asp:ListItem>
                                           <asp:ListItem Value="TT002I611">水質病媒管制科</asp:ListItem>
                                           <asp:ListItem Value="TT002I612">溝渠一隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I613">溝渠二隊</asp:ListItem>

                                           <asp:ListItem Value="TT002I614">萬華區清潔隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I615">資源回收隊</asp:ListItem>
                                           <asp:ListItem Value="TT002I617">職業安全管理科</asp:ListItem>

                                         <asp:ListItem Value="TT002I619">氣候變遷管理科</asp:ListItem>
                                            <asp:ListItem Value="TT002I620">綜合企劃科</asp:ListItem>
                                           <asp:ListItem Value="TT002I621">環境清潔管理科</asp:ListItem>
                                           <asp:ListItem Value="TT002I622">廢棄物處理管理科</asp:ListItem>
                                           <asp:ListItem Value="TT002I623">資源循環管理科</asp:ListItem>
                                          

                                       </asp:CheckBoxList>
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
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey"  OnClick="btnInsert_Click" OnClientClick="GetNotifyMsg();" />
                           </asp:Panel>
                       </td>
                   </tr>
               </table>
           </td>
       </tr>
</table>
</asp:Content>
