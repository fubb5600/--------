<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc001U1.aspx.cs" Inherits="TDOSc001_TDOSc001U1" %>

<%@ Register Src="../Common/car_status.ascx" TagName="car_status" TagPrefix="uc1" %>
<%@ Register Src="../Common/car_inspection.ascx" TagName="car_inspection" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <table width="900">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>保管單位
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:DropDownList ID="keep_org" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="keep_org" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="old_keep_org" runat="server" />     
                                        <asp:HiddenField ID="old_car_no" runat="server" />                                   
                                        <asp:HiddenField ID="card_id" runat="server" />
                                        <asp:HiddenField ID="keep_id" runat="server" />
                                        <asp:HiddenField ID="possess_id" runat="server" />
                                        <asp:HiddenField ID="exec_id" runat="server" />
                                        <asp:HiddenField ID="keep_start" runat="server" />
                                        <asp:HiddenField ID="old_buy_date" runat="server" />
                                    </td>
                                    <%--<td class="td_head">
                                        <span class="td_must">*</span>車隊卡卡號
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="card_id" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="card_id" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>                                        
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>局編號
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                                        <asp:HiddenField ID="car_id" runat="server" />
                                    </td>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>車牌號碼
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>車輛種類
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="car_type" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" InitialValue="" ControlToValidate="car_type" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>狀態
                                    </td>
                                    <td class="td_cont">
                                        <asp:RadioButtonList ID="status" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="O">使用中</asp:ListItem>
                                            <asp:ListItem Value="C">停用</asp:ListItem>
                                            <asp:ListItem>報廢</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="status" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="status_desc" runat="server" CssClass="td_memo" Text=""></asp:Label>
                                        <asp:HiddenField ID="old_status" runat="server" />
                                        <asp:HiddenField ID="old_chg_rsn" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>年份
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="car_year" runat="server" MaxLength="4"></asp:TextBox>
                                        <span class="td_memo">(西元年)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="car_year" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效年份" CssClass="td_must"
                                            ClientValidationFunction="ADYear_Validate" ControlToValidate="car_year" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="ADYearValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>購置日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="buy_date" runat="server" CssClass="date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="buy_date" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="buy_date" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>廠牌型號
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="brand_no" runat="server" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="brand_no" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>引擎號碼
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="engine_no" runat="server" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="engine_no" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>噸數
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="tonnage" runat="server"></asp:TextBox>
                                        <span class="td_memo">噸</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="tonnage" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="td_must"
                                            runat="server" ErrorMessage="整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"
                                            ControlToValidate="tonnage" ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>排氣量
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="displacement" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="displacement" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="td_must"
                                            runat="server" ErrorMessage="整數" ValidationExpression="^[0-9]*$" ControlToValidate="displacement"
                                            ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>油品類型
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="fuel_type" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>油耗量標準值
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="fuel_std" runat="server"></asp:TextBox>
                                        <span class="td_memo">(公里/公升)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="fuel_std" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" CssClass="td_must"
                                            runat="server" ErrorMessage="整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"
                                            ControlToValidate="fuel_std" ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>發照日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="licensing_date" runat="server" CssClass="date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="licensing_date" ValidationGroup="save" Display="Dynamic"> </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="無效日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="licensing_date" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>下次定檢日
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="next_inspection" runat="server" CssClass="date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="next_inspection" ValidationGroup="save"
                                            Display="Dynamic"> </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="無效日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="next_inspection"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                </tr>
                                  <tr>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>車輛屬性
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="CAR" runat="server">
                                       
 <asp:ListItem Value="">無</asp:ListItem>    
 <asp:ListItem Value="A1:特種汽車">A1:特種汽車</asp:ListItem>
 <asp:ListItem Value="A2:特業汽車">A2:特業汽車</asp:ListItem>
 <asp:ListItem Value="A3:業務汽車">A3:業務汽車</asp:ListItem>
 <asp:ListItem Value="A4:公務汽車">A4:公務汽車</asp:ListItem>
<asp:ListItem Value="A5:專用車">A5:專用車</asp:ListItem>
 <asp:ListItem Value="B1:特種機車">B1:特種機車</asp:ListItem>
 <asp:ListItem Value="B2:特業機車">B2:特業機車</asp:ListItem>
 <asp:ListItem Value="B3:業務機車">B3:業務機車</asp:ListItem>
 <asp:ListItem Value="B4:公務機車">B4:公務機車</asp:ListItem>
 <asp:ListItem Value="C1:拖車1">C1:拖車1</asp:ListItem>
 <asp:ListItem Value="C2:行駛道路之動力機械">C2:行駛道路之動力機械</asp:ListItem>
 <asp:ListItem Value="C3:其他1">C3:其他1</asp:ListItem>




                                        </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="CAR" ValidationGroup="save"
                                            Display="Dynamic"> </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                
                                    </td>
                                    <td class="td_cont">
                                      
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlCRS" runat="server">
                                    <tr>
                                        <td class="td_head">
                                            加裝設備
                                        </td>
                                        <td class="td_cont">
                                            <asp:TextBox ID="add_device" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="td_head">
                                            行車紀錄器定檢時間
                                        </td>
                                        <td class="td_cont">
                                            <asp:TextBox ID="check_date" runat="server" CssClass="date"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>







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
                                    ValidationGroup="save" />
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CssClass="btn_grey" OnClientClick="return confirm('確定刪除?')"
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" OnClientClick="GetNotifyMsg();"   />

                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <br />
                <div id="tabs" style="width:900px">
                    <ul>
                        <li><a href="#tabs-1">車輛狀態</a></li>
                        <li><a href="#tabs-2">定期檢驗</a></li>
                    </ul>
                    <div id="tabs-1">
                        <uc1:car_status ID="car_status1" runat="server" />
                    </div>
                    <div id="tabs-2">
                        <uc2:car_inspection ID="car_inspection" runat="server" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <script>
        $(function () {
            $("#tabs").tabs();
        });
    </script>       
    <!--提醒託修作業資料未建置完整_WENNY_1061206-->
     <script type="text/javascript" language="javascript">

         function GetNotifyMsg() {
             var str ="<%= Session["NOTIFYMSG"].ToString()%>";
             if (str != "")
                 alert(str);
             //console.log(str+"11111");
             return true;
         }
    </script>

</asp:Content>
