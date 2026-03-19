<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSf002U1.aspx.cs" Inherits="TDOSf002_TDOSf002U1" %>

<%@ Register Src="../Common/car_data_CRS.ascx" TagName="car_data_CRS" TagPrefix="uc1" %>
<%@ Register Src="TDOSf002U2.ascx" TagName="TDOSf002U2" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function aaa() { alert('<%=TDOSf002U2.RepairItem%>') };
    </script>
    <style type="text/css">
        .auto-style4 {
            color: #222a68;
            text-align: right;
            font-weight: normal;
            height: 40px;
            border-right: 1px dotted #d0d0bf;
            border-bottom: 1px dotted #d0d0bf;
            padding-left: 2px;
            padding-right: 5px;
            padding-top: 2px;
            padding-bottom: 2px;
        }
        .auto-style5 {
            text-align: left;
            font-weight: normal;
            height: 40px;
            border-right: 1px solid #d0d0bf;
            border-bottom: 1px dotted #d0d0bf;
            padding-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12"></td>
            <td valign="top">
                <!-- 內容 -->
                <table width="900">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">託修資料
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head" width="15%">
                                        <span class="td_must">*</span>派工單號
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="work_no" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnWork" runat="server" Text="確定" CssClass="btn_grey" ValidationGroup="work"
                                            OnClick="btnWork_Click" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="work_no" ValidationGroup="work"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="car_id" runat="server"  />
                                        <asp:HiddenField ID="crs_org" runat="server" />
                                        <asp:HiddenField ID="repair_type3" runat="server" />
                                        <%--<asp:HiddenField ID="crs_area" runat="server" />--%>
                                    </td>
                                    <td class="td_head" width="15%">
                                        <span class="td_must">*</span>維修廠商
                                    </td>
                                    <td class="td_cont" width="35%">
                                        <asp:DropDownList ID="repair_vender" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="repair_vender_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <%--<asp:TextBox ID="repair_vender" runat="server" Width="250px"></asp:TextBox>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" InitialValue="" ControlToValidate="repair_vender" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>標案號碼
                                    </td>
                                    <td class="td_cont" colspan="3">年度： 
                                        <asp:TextBox ID="year" runat="server" Width="25px" MaxLength="3"
                                            OnTextChanged="year_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <asp:HiddenField ID="region_year" runat="server" />
                                        <asp:HiddenField ID="region_vender" runat="server" />
                                        <asp:HiddenField ID="region_caseno" runat="server" />
                                        <%--<asp:TextBox ID="case_no_y" runat="server" Width="25px" MaxLength="3"></asp:TextBox>
                                        <asp:Label ID="case_no_1" runat="server" Text="環勞字第"></asp:Label>
                                        <asp:TextBox ID="case_no_v" runat="server" Width="25px" MaxLength="3"></asp:TextBox>
                                        <asp:Label ID="case_no_2" runat="server" Text="-"></asp:Label>--%>
                                        系統編列：
                                         <asp:TextBox ID="case_no" runat="server" Width="200px"></asp:TextBox>
                                        <%--<asp:Label ID="case_no_3" runat="server" Text="號"></asp:Label>--%>
                                        <asp:Label ID="case_no_advise" runat="server" Text="" CssClass="td_must"></asp:Label>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                            ErrorMessage="前3碼必填" ControlToValidate="case_no_y" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                            ErrorMessage="中間3碼必填" ControlToValidate="case_no_v" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="case_no" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="repair_id" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>單價區域
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:DropDownList ID="crs_area" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="crs_area_SelectedIndexChanged" Style="height: 17px">
                                            <asp:ListItem Value="1">第1區</asp:ListItem>
                                            <asp:ListItem Value="2">第2區</asp:ListItem>
                                            <asp:ListItem Value="3">第3區</asp:ListItem>
                                            <asp:ListItem Value="4">第4區</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="budget_area" runat="server" />
                                        <asp:HiddenField ID="repair_item" runat="server" />
                                        <asp:Label ID="area_memo" CssClass="td_must" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>託修內容
                                    </td>
                                    <td class="td_cont" colspan="3" style="padding-top: 5px">
                                        <uc2:TDOSf002U2 ID="TDOSf002U2" runat="server" />
                                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">通知日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="notify_date" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                        <asp:TextBox ID="notify_HH" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        :
                                        <asp:TextBox ID="notify_mm" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        <span class="td_memo">(如：15:30)</span>
                                        <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="通知時間無效日期"
                                            CssClass="td_must" ClientValidationFunction="Date_Validate" ControlToValidate="notify_date"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"
                                            Text="無效日期"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator11" runat="server" CssClass="td_must" ErrorMessage="通知時間小時範圍0~23"
                                            ControlToValidate="notify_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~23">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator12" runat="server" CssClass="td_must" ErrorMessage="通知時間分鐘範圍0~59"
                                            ControlToValidate="notify_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~59">
                                        </asp:RangeValidator>
                                    </td>
                                    <td class="td_head">履約期限
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="exec_deadline" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                        <asp:TextBox ID="exec_HH" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        :
                                        <asp:TextBox ID="exec_mm" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        <span class="td_memo">(如：15:30)</span>
                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="履約期限無效日期"
                                            CssClass="td_must" ClientValidationFunction="Date_Validate" ControlToValidate="exec_deadline"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"
                                            Text="無效日期"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator9" runat="server" CssClass="td_must" ErrorMessage="履約期限小時範圍0~23"
                                            ControlToValidate="exec_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~23">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator10" runat="server" CssClass="td_must" ErrorMessage="履約期限分鐘範圍0~59"
                                            ControlToValidate="exec_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~59">
                                        </asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">完工時間
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="finish_date" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                        <asp:TextBox ID="finish_HH" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        :
                                        <asp:TextBox ID="finish_mm" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        <span class="td_memo">(如：15:30)</span>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="完工時間無效日期"
                                            CssClass="td_must" ClientValidationFunction="Date_Validate" ControlToValidate="finish_date"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"
                                            Text="無效日期"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="td_must" ErrorMessage="完工時間小時範圍0~23"
                                            ControlToValidate="finish_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~23">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" CssClass="td_must" ErrorMessage="完工時間分鐘範圍0~59"
                                            ControlToValidate="finish_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~59">
                                        </asp:RangeValidator>
                                    </td>
                                    <td class="td_head">查驗日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="check_date" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                        <asp:TextBox ID="check_HH" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        :
                                        <asp:TextBox ID="check_mm" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        <span class="td_memo">(如：15:30)</span>
                                        <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="查驗日期無效日期"
                                            CssClass="td_must" ClientValidationFunction="Date_Validate" ControlToValidate="check_date"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"
                                            Text="無效日期"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator3" runat="server" CssClass="td_must" ErrorMessage="查驗日期小時範圍0~23"
                                            ControlToValidate="check_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~23">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator4" runat="server" CssClass="td_must" ErrorMessage="查驗日期分鐘範圍0~59"
                                            ControlToValidate="check_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~59">
                                        </asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">查驗合格日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="qualified_date" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                                        <asp:TextBox ID="qualified_HH" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        :
                                        <asp:TextBox ID="qualified_mm" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                        <span class="td_memo">(如：15:30)</span>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="查驗合格日期無效"
                                            CssClass="td_must" ClientValidationFunction="Date_Validate" ControlToValidate="qualified_date"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"
                                            Text="無效日期"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator5" runat="server" CssClass="td_must" ErrorMessage="查驗合格日期小時範圍0~23"
                                            ControlToValidate="qualified_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~23">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator6" runat="server" CssClass="td_must" ErrorMessage="查驗合格日期分鐘範圍0~59"
                                            ControlToValidate="qualified_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~59">
                                        </asp:RangeValidator>
                                    </td>
                                    <td class="td_head">交貨期限
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="delivery_days" runat="server" Width="70px"></asp:TextBox>
                                        <%--<asp:RadioButtonList ID="time_unit" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        </asp:RadioButtonList>--%>
                                        <asp:CheckBox ID="time_unit1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Text="工作天" OnCheckedChanged="time_unit1_CheckedChanged"></asp:CheckBox><!--RadioButtonList改checkBox-->
                                        <asp:CheckBox ID="time_unit2" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Text="小時" OnCheckedChanged="time_unit2_CheckedChanged"></asp:CheckBox><!--RadioButtonList改checkBox-->

                                        <%-- &nbsp;<span class="td_memo">(工作日)</span>--%>
                                      
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">是否逾期
                                    </td>
                                    <td class="td_cont">
                                        <%-- <asp:RadioButtonList ID="is_late" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>--%><!--//2018/09/01RadioButtonList改成checkBox-->

                                        <asp:CheckBox ID="is_late1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Text="是" OnCheckedChanged="is_late1_CheckedChanged"></asp:CheckBox><!--//2018/09/01RadioButtonList改成checkBox-->
                                        <asp:CheckBox ID="is_late2" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Text="否" OnCheckedChanged="is_late2_CheckedChanged"></asp:CheckBox><!--//2018/09/01RadioButtonList改成checkBox-->

                                    </td>
                                    <td class="td_head">查驗結果
                                    </td>
                                    <td class="td_cont">
                                        <%--<asp:RadioButtonList ID="check_result" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>--%>
                                        <%-- <asp:DropDownList ID="check_result" runat="server">
                                        </asp:DropDownList>--%>
                                        <asp:CheckBox ID="check_result1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="check_result1_SelectedIndexChanged" Text="合格" OnCheckedChanged="check_result1_SelectedIndexChanged"></asp:CheckBox><!--下拉選單改checkBox-->
                                        <asp:CheckBox ID="check_result2" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="check_result2_SelectedIndexChanged" Text="不合格" OnCheckedChanged="check_result2_SelectedIndexChanged"></asp:CheckBox><!--下拉選單改checkBox-->
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">備註
                                    </td>
                                    <td class="td_cont" colspan="3">
                                                                             <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" Width="600px" Rows="3"></asp:TextBox>
</td>
                                </tr>
                                <uc1:car_data_CRS ID="car_data" runat="server" />
                            </table>
                        </td>
                    </tr>
                </table>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <div>       
                                
                                
                                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click"
                                    ValidationGroup="save" Visible="true" />
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CssClass="btn_grey" OnClientClick="return confirm('確定刪除?')"
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" />
                                <asp:Button ID="btnPrint1" runat="server" Text="查驗記錄單" CssClass="btn_grey" OnClick="btnPrint1_Click" />
                                <asp:Button ID="btnPrint2" runat="server" Text="交車簽收單" CssClass="btn_grey" OnClick="btnPrint2_Click" />
                                <asp:Button ID="btnPrint3" runat="server" Text="完工接車單" CssClass="btn_grey" OnClick="btnPrint3_Click" />

                            </div>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
