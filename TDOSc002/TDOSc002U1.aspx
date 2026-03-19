<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc002U1.aspx.cs" Inherits="TDOSc002_TDOSc002U1" %>

<%@ Register src="../Common/car_status.ascx" tagname="car_status" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       
    &nbsp;<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <table width="900">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        車輛資料
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>車牌號碼
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:Label ID="car_no" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="15%" class="td_head">
                                        局編號
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:Label ID="dep_no" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="car_id" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" class="td_head">
                                        車輛種類
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="car_type" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        狀態
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="status" runat="server" Text=""></asp:Label>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        保管單位
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:Label ID="keep_org" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="old_chg_org" runat="server" />
                                    &nbsp;&nbsp;
                                        <asp:Label ID="chg_id1" runat="server" Text=""  visible="false" ></asp:Label>
                                     <asp:Label ID="car_id1" runat="server" Text=""  visible="false" ></asp:Label>

                                     <asp:Label ID="keep_id" runat="server" Text=""  visible="false"></asp:Label>

                                     <asp:Label ID="card_id" runat="server" Text=""  visible="false"></asp:Label>

                                     <asp:Label ID="car_id2" runat="server" Text=""  visible="false" ></asp:Label>


                                    </td>
                                    <%--<td class="td_head">
                                        車隊卡卡號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="card_no" runat="server" Text=""></asp:Label>
                                    </td>--%>
                                </tr>
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        異動記錄
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>異動日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="chg_date" runat="server" CssClass="date"></asp:TextBox>
                                        <asp:HiddenField ID="chg_id" runat="server" />
                                        <asp:HiddenField ID="old_chg_date" runat="server" />

                                        <asp:HiddenField ID="new_card" runat="server" />
                                        <asp:HiddenField ID="old_card" runat="server" />    
                                        <asp:HiddenField ID="new_status" runat="server" />
                                        <asp:HiddenField ID="old_status" runat="server" />
                                        <asp:HiddenField ID="new_keep" runat="server" />
                                        <asp:HiddenField ID="old_keep" runat="server" />
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>異動原因
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="chg_rsn" runat="server">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="old_chg_rsn" runat="server" />
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlR1" runat="server" Visible="true">
                                    <tr>
                                        <td class="td_head">
                                            <span class="td_must">*</span>移撥單位
                                        </td>
                                        <td class="td_cont" colspan="3">
                                            <asp:DropDownList ID="r1_org" runat="server">
                                            </asp:DropDownList>
                                            <span class="td_memo">(自異動日期起車輛保管單位將轉移至此單位)</span>
                                            <asp:HiddenField ID="old_r1_org" runat="server" />
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="pnlR5" runat="server" Visible="false">
                                    <tr>
                                        <td class="td_head">
                                            <span class="td_must">*</span>變更車牌號碼
                                        </td>
                                        <td class="td_cont" colspan="3">
                                            <asp:TextBox ID="r5_license" runat="server"></asp:TextBox>
                                            <span class="td_memo">(自異動日期起使用此車牌號碼，舊的加油記錄、勤務記錄顯示舊車牌)</span>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td class="td_head">
                                        異動說明
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="chg_desc" runat="server" TextMode="MultiLine" Width="600px" Rows="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        備註
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" Width="600px" Rows="3"></asp:TextBox>
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
                                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click" 
                                    ValidationGroup="save" Visible="false" />
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CssClass="btn_grey" OnClientClick="return confirm('確定刪除?')"
                                    OnClick="btnDelete_Click" Height="26px"  visble="false"/>
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" OnClientClick="GetNotifyMsg()" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                 <br />
                <uc1:car_status ID="car_status1" runat="server" />   
            </td>
        </tr>
    </table>
         <!--提醒託修作業資料未建置完整_WENNY_1061206-->
    <script type="text/javascript" language="javascript">

        function GetNotifyMsg() {
            var str = '<%= Session["NOTIFYMSG"].ToString()%>';
            if (str != "")
                alert(str);
            return true;
        }
    </script>
</asp:Content>
