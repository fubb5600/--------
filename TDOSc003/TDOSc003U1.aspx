<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc003U1.aspx.cs" Inherits="TDOSc003_TDOSc003U1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .auto-style1 {
            width: 13px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="auto-style1">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <script language="javascript">
                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(DatePicker);                   
                </script>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div style="float: left">
                                        <table width="700px" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                            <tr class="td_center td_headhrz">
                                                <td class="td_head td_center" colspan="2">
                                                    勤務記錄
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>勤務類型
                                                </td>
                                                <td class="td_cont">
                                                    <asp:RadioButtonList ID="work_type" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                                        OnSelectedIndexChanged="work_type_SelectedIndexChanged" RepeatLayout="Flow">
                                                    </asp:RadioButtonList>
                                                    <asp:HiddenField ID="hfWorkType" runat="server" />
                                                    <asp:HiddenField ID="hfLastMileage" runat="server" />
                                                    <asp:HiddenField ID="work_id" runat="server" />
                                                    <asp:Panel ID="pnlMachine" runat="server" CssClass="table_panel">
                                                        ：<asp:DropDownList ID="work_machine" runat="server">
                                                        </asp:DropDownList>
                                                    </asp:Panel>
                                                    &nbsp;&nbsp;<asp:Button ID="btnLoad" runat="server" Text="載入前次" CssClass="btn_grey"
                                                        OnClick="btnLoad_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>保管單位
                                                </td>
                                                <td class="td_cont">
                                                    <asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span><asp:Label ID="car_id_title" runat="server" Text="加油卡"></asp:Label>
                                                </td>
                                                <td class="td_cont">
                                                    <asp:DropDownList ID="card_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="card_type_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="card_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="card_id_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="td_must"
                                                        ErrorMessage="加油卡必填" Text="必填" ControlToValidate="card_id" ValidationGroup="save"
                                                        InitialValue="" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <asp:Panel ID="Panel1" runat="server">
                                           
                                              <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>是否行駛至外縣市
                                                </td>
                                                   
                                                <td class="td_cont">
                                                   
                                                 
                                                    <asp:DropDownList ID="yesno" runat="server" AutoPostBack="true" >
                                                        <asp:ListItem Value="N">否</asp:ListItem>
                                                       
                                                        <asp:ListItem Value="Y">是</asp:ListItem>
                                                        
                                                    </asp:DropDownList>
                                                 
                                                </td>
                                            </tr>   
											
											<tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>外縣市地點
                                                </td>
                                                 <td class="td_cont">
                                                

<asp:DropDownList ID="location" runat="server" AutoPostBack="true" >
                                                       
                                                        <asp:ListItem Value="">無</asp:ListItem>
                                                        <asp:ListItem Value="基隆市">基隆</asp:ListItem>
                                                        <asp:ListItem Value="臺北市">臺北</asp:ListItem>
                                                        <asp:ListItem Value="新北市">新北</asp:ListItem>
                                                        <asp:ListItem Value="桃園市">桃園</asp:ListItem>
                                                    </asp:DropDownList>
                                                 
                                                    
                                                 
                                                </td>
                                            </tr>
                                           
                                                     </asp:Panel>
                                            <tr>
                                                <td class="td_head" width="21%">
                                                    <span class="td_must">*</span>勤務日期(起)
                                                </td>
                                                <td class="td_cont">
                                                    <asp:TextBox ID="work_start" runat="server" CssClass="date" Width="60px"></asp:TextBox>
                                                    <asp:TextBox ID="start_HH" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                                    :
                                                    <asp:TextBox ID="start_mm" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                                    <span class="td_memo">(如：15:30)</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                                        ErrorMessage="勤務日期(起)日期必填" ControlToValidate="work_start" ValidationGroup="save"
                                                        Display="Dynamic" Text="日期必填">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                                        ErrorMessage="勤務日期(起)小時必填" ControlToValidate="start_HH" ValidationGroup="save"
                                                        Display="Dynamic" Text="時必填">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                                        ErrorMessage="勤務日期(起)分鐘必填" ControlToValidate="start_mm" ValidationGroup="save"
                                                        Display="Dynamic" Text="分必填">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="勤務日期(起)無效日期"
                                                        CssClass="td_must" ControlToValidate="work_start" ValidationGroup="save" Display="Dynamic"
                                                        OnServerValidate="DateValidator_ServerValidate" Text="無效日期"></asp:CustomValidator>
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="td_must" ErrorMessage="勤務日期(起)小時範圍0~23"
                                                        ControlToValidate="start_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                                        ValidationGroup="save" Type="Integer" Text="0~23">
                                                    </asp:RangeValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" CssClass="td_must" ErrorMessage="勤務日期(起)分鐘範圍0~59"
                                                        ControlToValidate="start_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                                        ValidationGroup="save" Type="Integer" Text="0~59">
                                                    </asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>勤務日期(迄)
                                                </td>
                                                <td class="td_cont">
                                                    <asp:TextBox ID="work_end" runat="server" CssClass="date" Width="60px"></asp:TextBox>
                                                    <asp:TextBox ID="end_HH" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                                    :
                                                    <asp:TextBox ID="end_mm" runat="server" Width="16px" MaxLength="2"></asp:TextBox>
                                                    <span class="td_memo">(如：15:30)</span>
                                                    <asp:ImageButton ID="ibUpdate" runat="server" ImageUrl="~/images/update.png" AlternateText="更新統計資訊"
                                                        OnClick="ibUpdate_Click" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="td_must"
                                                        ErrorMessage="勤務日期(迄)日期必填" ControlToValidate="work_end" ValidationGroup="save"
                                                        Display="Dynamic" Text="日期必填">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="td_must"
                                                        ErrorMessage="勤務日期(迄)小時必填" ControlToValidate="end_HH" ValidationGroup="save"
                                                        Display="Dynamic" Text="時必填">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="td_must"
                                                        ErrorMessage="勤務日期(迄)分鐘必填" ControlToValidate="end_mm" ValidationGroup="save"
                                                        Display="Dynamic" Text="分必填">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="勤務日期(迄)無效日期"
                                                        CssClass="td_must" ControlToValidate="work_end" ValidationGroup="save" Display="Dynamic"
                                                        OnServerValidate="DateValidator_ServerValidate" Text="無效日期"></asp:CustomValidator>
                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" CssClass="td_must" ErrorMessage="勤務日期(迄)小時範圍0~23"
                                                        ControlToValidate="end_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                                        ValidationGroup="save" Type="Integer" Text="0~23">
                                                    </asp:RangeValidator>
                                                    <asp:RangeValidator ID="RangeValidator4" runat="server" CssClass="td_must" ErrorMessage="勤務日期(迄)分鐘範圍0~59"
                                                        ControlToValidate="end_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                                        ValidationGroup="save" Type="Integer" Text="0~59">
                                                    </asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>報表作業日期
                                                </td>
                                                <td class="td_cont">
                                                    <asp:TextBox ID="work_date" runat="server" CssClass="date" Width="60px"></asp:TextBox>
                                                    <span class="td_memo">(統計報表依此日期計算)</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                                        ErrorMessage="報表作業日期必填" ControlToValidate="work_date" ValidationGroup="save"
                                                        Display="Dynamic" Text="必填">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="報表作業日期無效"
                                                        CssClass="td_must" ControlToValidate="work_end" ValidationGroup="save" Display="Dynamic"
                                                        OnServerValidate="DateValidator_ServerValidate" Text="無效日期"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                            <%--<tr style="display: none">
                                            <td class="td_head">
                                                實際加油公升
                                            </td>
                                            <td class="td_cont">
                                                <asp:TextBox ID="gasoline_litre" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="td_head">
                                                實際加油金額
                                            </td>
                                            <td class="td_cont">
                                                <asp:TextBox ID="gasoline_amount" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                            <asp:Panel ID="pnlMileage" runat="server">
                                                <tr>
                                                    <td class="td_head">
                                                        <span class="td_must">*</span>里程數(起~迄)
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:TextBox ID="mileage_start" runat="server" AutoPostBack="true" Width="80px" OnTextChanged="mileage_TextChanged"
                                                            ValidationGroup="cal"></asp:TextBox>
                                                        ~
                                                        <asp:TextBox ID="mileage_end" runat="server" AutoPostBack="true" Width="80px" OnTextChanged="mileage_TextChanged"
                                                            ValidationGroup="cal"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" CssClass="td_must"
                                                            runat="server" Text="整數或小數" ErrorMessage="里程數(起)整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"
                                                            ControlToValidate="mileage_start" ValidationGroup="cal" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" CssClass="td_must"
                                                            runat="server" Text="整數或小數" ErrorMessage="里程數(迄)整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"
                                                            ControlToValidate="mileage_end" ValidationGroup="cal" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        <span class="td_must">*</span>里程數
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:TextBox ID="mileage" runat="server" Width="80px"></asp:TextBox>&nbsp;公里
                                                        <asp:CheckBox ID="cbKeyMileage" runat="server" Text="自行修正" AutoPostBack="true" OnCheckedChanged="cbKeyMileage_CheckedChanged" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="td_must"
                                                            runat="server" Text="整數或小數" ErrorMessage="里乘數整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"
                                                            ControlToValidate="mileage" ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        <span class="td_must">*</span>車次
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:TextBox ID="car_count" runat="server" Width="80px" Text="1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                                            ErrorMessage="車次必填" ControlToValidate="car_count" ValidationGroup="save" Display="Dynamic"
                                                            Text="必填">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" CssClass="td_must"
                                                            runat="server" Text="整數" ErrorMessage="車次格式為整數" ValidationExpression="^[0-9]{1,}$"
                                                            ControlToValidate="car_count" ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="pnlMileageKeyRsn" runat="server">
                                                    <tr>
                                                        <td class="td_head">
                                                            <span class="td_must">*</span>里程數自行修正原因
                                                        </td>
                                                        <td class="td_cont">
                                                            <asp:TextBox ID="mileage_key" runat="server" Width="400px" MaxLength="200"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlMileageRsn" runat="server">
                                                    <tr>
                                                        <td class="td_head">
                                                            <span class="td_must">*</span>里程數不連續原因
                                                        </td>
                                                        <td class="td_cont">
                                                            <asp:TextBox ID="mileage_rsn" runat="server" Width="400px" MaxLength="200"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                            </asp:Panel>
                                            <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>作業人員
                                                </td>
                                                <td class="td_cont">
                                                    <asp:TextBox ID="work_man" runat="server" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="td_must"
                                                        ErrorMessage="作業人員必填" ControlToValidate="work_man" ValidationGroup="save" Display="Dynamic"
                                                        Text="必填">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    作業面積
                                                </td>
                                                <td class="td_cont">
                                                    <asp:TextBox ID="work_area" runat="server"></asp:TextBox>
                                                    <span class="td_memo">(平方公尺)</span>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="td_must"
                                                        runat="server" Text="整數或小數" ErrorMessage="作業面積整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"
                                                        ControlToValidate="work_area" ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>作業地點
                                                </td>
                                                <td class="td_cont">
                                                    <asp:TextBox ID="work_location" runat="server" Width="400px" MaxLength="200"></asp:TextBox>
                                                    <span class="td_memo">(或工作路線)</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="td_must"
                                                        ErrorMessage="作業地點必填" ControlToValidate="work_location" ValidationGroup="save"
                                                        Display="Dynamic" Text="必填">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    <span class="td_must">*</span>作業項目
                                                </td>
                                                <td class="td_cont">
                                                    <asp:DropDownList ID="work_item_lvl1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="work_item_lvl1_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="work_item_lvl2" runat="server">
                                                    </asp:DropDownList>
                                                    <input id="btnAddRow" type="button" value="加入" class="btn_grey" onclick="javascript:addWorkItem()" />
                                                    <br />
                                                    <table style="width: 100%;" id="item_dtl" class="table_mt table_border" border="1">
                                                    </table>
                                                    <%-- <asp:TextBox ID="selected_item" runat="server" TextMode="MultiLine" Rows="2" Width="400px"></asp:TextBox>--%>
                                                    <asp:HiddenField ID="car_witem" runat="server" />
                                                    <asp:HiddenField ID="mchn_witem" runat="server" />
                                                    <asp:HiddenField ID="work_item" runat="server" />
                                                    <asp:HiddenField ID="work_item_text" runat="server" />
                                                    <%--<input id="btnWorkItem" type="button" value="選擇" class="btn_grey" onclick="javascript:openWorkItem()" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="td_must"
                                                        ErrorMessage="作業項目必填" ControlToValidate="selected_item" ValidationGroup="save"
                                                        Display="Dynamic" Text="必填">
                                                    </asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_head">
                                                    備註
                                                </td>
                                                <td class="td_cont">
                                                    <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" Width="400px" Rows="3"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="float: right">
                                        <asp:Panel ID="pnlMSum" runat="server">
                                            <table width="300px" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                                <tr class="td_center td_headhrz">
                                                    <td class="td_head td_center" colspan="2">
                                                        當月累計
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        油品類型
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="machine_fuel" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head" width="30%">
                                                        加油量
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="machine_fuel_count" runat="server" Text=""></asp:Label>
                                                        <span class="td_memo">公升 (報表作業日期當月統計)</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        加油金額
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="machine_fuel_amount" runat="server" Text=""></asp:Label>
                                                        <span class="td_memo">元 (報表作業日期當月統計)</span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlCar" runat="server">
                                            <table width="300px" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                                <tr class="td_center td_headhrz">
                                                    <td class="td_head td_center" colspan="2">
                                                        車輛資料
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head" width="30%">
                                                        局編號
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="dep_no" runat="server" Text=""></asp:Label>
                                                        <asp:HiddenField ID="car_id" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        車輛種類
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="car_type" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td class="td_head">
                                                        車輛屬性</td>
                                                    <td class="td_cont">

                                                        <asp:Label ID="car_type2" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>



                                                <tr>
                                                    <td class="td_head">
                                                        狀態
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="car_status" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        油品類型
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="fuel_type" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        油耗量標準值
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="fuel_std" runat="server" Text=""></asp:Label>
                                                        <span class="td_memo">(公里/公升)</span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="300px" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                                <tr class="td_center td_headhrz">
                                                    <td class="td_head td_center" colspan="2">
                                                        當月累計
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head" width="30%">
                                                        作業天數
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:Label ID="sum_days" runat="server" Text=""></asp:Label>
                                                        <span class="td_memo">天 </span>
                                                    </td>
                                                    <tr>
                                                        <td class="td_head">
                                                            車次
                                                        </td>
                                                        <td class="td_cont">
                                                            <asp:Label ID="sum_times" runat="server" Text=""></asp:Label>
                                                            <span class="td_memo">次 </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="td_head">
                                                            累積里程數
                                                        </td>
                                                        <td class="td_cont">
                                                            <asp:Label ID="sum_mileage" runat="server" Text=""></asp:Label>
                                                            <span class="td_memo">公里 </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="td_head">
                                                            加油量
                                                        </td>
                                                        <td class="td_cont">
                                                            <asp:Label ID="car_fuel_count" runat="server" Text=""></asp:Label>
                                                            <span class="td_memo">公升 (報表作業日期當月統計)</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="td_head">
                                                            加油金額
                                                        </td>
                                                        <td class="td_cont">
                                                            <asp:Label ID="car_fuel_amount" runat="server" Text=""></asp:Label>
                                                            <span class="td_memo">元 (報表作業日期當月統計)</span>
                                                        </td>
                                                    </tr>
                                            </table>
                                           <table border="0" cellpadding="0" cellspacing="1" class="table_sn table_border" width="300px">
                                                <tr class="td_center td_headhrz">
                                                    <td class="td_head td_center" colspan="2">行車紀錄資訊</td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head" width="30%">出車事由 </td>
                                                    <td class="td_cont"><span class="td_memo">&nbsp;<asp:TextBox ID="DSPH_CAUSE" runat="server" MaxLength="50" Width="220px"  Enabled="false" ></asp:TextBox>
                                                        </span></td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">行經行政區 </td>
                                                    <td class="td_cont">
                                                        <asp:TextBox ID="ADM_DISTRICT" runat="server" MaxLength="50" Width="220px" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">行駛公里 </td>
                                                    <td class="td_cont">
                                                        <asp:TextBox ID="MILS" runat="server" MaxLength="50" Width="220px" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">搭乘人數(不含駕駛） </td>
                                                    <td class="td_cont">
                                                        <asp:TextBox ID="PASSENGERS" runat="server" MaxLength="50" Width="220px"  Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">主要實際用車人</td>
                                                    <td class="td_cont">
                                                        <asp:TextBox ID="ATU_USER" runat="server" MaxLength="50" Width="220px" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="save"
                    ShowMessageBox="true" ShowSummary="false" />
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click"
                                    ValidationGroup="save" />
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CssClass="btn_grey" OnClientClick="return confirm('確定刪除?')"
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script language="JavaScript" type="text/JavaScript">
        function end_mmTabNext() {
            var selValue = document.getElementById("MasterPage_ContentPlaceHolder1_hfWorkType").value;
            if (selValue == "C") {
                document.getElementById('MasterPage_ContentPlaceHolder1_mileage_start').focus();
            }
            else {
                document.getElementById('MasterPage_ContentPlaceHolder1_work_man').focus();
            }
        }

        function openWorkItem() {
            var work_type = document.getElementById("MasterPage_ContentPlaceHolder1_hfWorkType").value;
            var car_witem = document.getElementById("MasterPage$ContentPlaceHolder1$car_witem").value;
            var mchn_witem = document.getElementById("MasterPage$ContentPlaceHolder1$mchn_witem").value;
            TINY.box.show({ iframe: '../Common/work_item.aspx?work_type=' + work_type + '&car_witem=' + car_witem + '&mchn_witem=' + mchn_witem, boxid: 'frameless', width: 800, height: 600, fixed: false, maskid: 'bluemask', maskopacity: 40, closejs: function () { } })
        }

        function changeWorkDate(obj) {

            if (obj == document.getElementById("MasterPage_ContentPlaceHolder1_work_start") && obj.value.length == 9) {

                if (document.getElementById("MasterPage_ContentPlaceHolder1_work_end").value.length == 0
                     && document.getElementById("MasterPage_ContentPlaceHolder1_work_date").value.length == 0) {

                    document.getElementById("MasterPage_ContentPlaceHolder1_work_end").value = obj.value;
                    document.getElementById("MasterPage_ContentPlaceHolder1_work_date").value = obj.value;
                }
            }            


            if (document.getElementById("MasterPage_ContentPlaceHolder1_work_start").value.lenght > 0
                && document.getElementById("MasterPage_ContentPlaceHolder1_work_end").value.length > 0 
                && document.getElementById("MasterPage_ContentPlaceHolder1_work_date").value.length > 0) {
                    var start_dt = document.getElementById("MasterPage_ContentPlaceHolder1_work_start").value;
                    var end_dt = document.getElementById("MasterPage_ContentPlaceHolder1_work_end").value;
                    var work_dt = document.getElementById("MasterPage_ContentPlaceHolder1_work_date").value;
                
                    if ((Date.parse(work_dt)).valueOf() < (Date.parse(start_dt)).valueOf() || (Date.parse(work_dt)).valueOf() > (Date.parse(end_dt)).valueOf()) {
                        document.getElementById('MasterPage_ContentPlaceHolder1_work_date').value = start_dt;
                }
            }
        }

        function setDefulatFocus(obj) {
            var triggerIndex = -1;
            var tagetIndex = -1;
            var isDate = false;

            var arrCrtls = ["MasterPage_ContentPlaceHolder1_work_start", "MasterPage_ContentPlaceHolder1_start_HH", "MasterPage_ContentPlaceHolder1_start_mm",
                "MasterPage_ContentPlaceHolder1_work_end", "MasterPage_ContentPlaceHolder1_end_HH", "MasterPage_ContentPlaceHolder1_end_mm", 
                "MasterPage_ContentPlaceHolder1_work_date"];

            for (var i = 0; i < arrCrtls.length; i++) {

                if (document.getElementById(arrCrtls[i]) == obj)
                    triggerIndex = i;              

                //目前ctrl的ID長度
                var idLen = arrCrtls[i].length;
                //目前ctrl的值的長度
                var valueLen = document.getElementById(arrCrtls[i]).value.length;
                //目前的ctrl是否是日期
                if (arrCrtls[i].substr(idLen - 2, 2) != "HH" && arrCrtls[i].substr(idLen - 2, 2) != "mm")
                    isDate = true;                

                if ((isDate && valueLen == 9) || (!isDate && valueLen == 2)) {                    

                    if (tagetIndex == -1){
                        if (document.getElementById(arrCrtls[i + 1]).value.length == 0) {
                            tagetIndex = (i + 1);    
                            break;
                        }
                    }
               }
           }

           if(tagetIndex != -1)
                document.getElementById(arrCrtls[tagetIndex]).focus();

            alert("triggerIndex = " + triggerIndex + ", tagetIndex = " + tagetIndex);
//            var i = -1;
//            do {
//                i += 1;
//               
//            } while (document.getElementById(arrCrtls[i]).value.length == 0);

           // alert(obj.value +"\n"+ i);


            /*
            //勤務日期(起) 
            if (obj == document.getElementById("MasterPage_ContentPlaceHolder1_work_start")) {
                if (obj.value.length == 9 && document.getElementById('MasterPage_ContentPlaceHolder1_start_HH').value.length == 0)
                    document.getElementById('MasterPage_ContentPlaceHolder1_start_HH').focus();
            }

            //勤務日期(起) 小時
            if (obj == document.getElementById("MasterPage_ContentPlaceHolder1_start_HH")) {
              if(obj.value.length==2)
                  document.getElementById('MasterPage_ContentPlaceHolder1_start_mm').focus();
            }

            //勤務日期(起) 分鐘
            if (obj == document.getElementById("MasterPage_ContentPlaceHolder1_start_mm")) {
                if (obj.value.length == 2 && document.getElementById('MasterPage_ContentPlaceHolder1_work_end').value.length == 9)
                    document.getElementById('MasterPage_ContentPlaceHolder1_work_end').focus();
            }

            //勤務日期(迄) 
            if (obj == document.getElementById("MasterPage_ContentPlaceHolder1_work_end")) {
                if(obj.value.length==9 && document.getElementById('MasterPage_ContentPlaceHolder1_end_HH').value.length==0){
                    if(document.getElementById('MasterPage_ContentPlaceHolder1_start_HH').value.length==0 && document.getElementById('MasterPage_ContentPlaceHolder1_work_start').value.length > 0)
                        document.getElementById('MasterPage_ContentPlaceHolder1_start_HH').focus();
                    else
                        document.getElementById('MasterPage_ContentPlaceHolder1_end_HH').focus(); 
                    }
            }

            //勤務日期(迄) 小時
             if (obj == document.getElementById("MasterPage_ContentPlaceHolder1_end_HH")) {
                if(obj.value.length==2)
                    document.getElementById('MasterPage_ContentPlaceHolder1_end_mm').focus();
            }

            //勤務日期(迄) 分鐘
             if (obj == document.getElementById("MasterPage_ContentPlaceHolder1_end_mm")) {
                 if (obj.value.length == 2)
                    end_mmTabNext();
            }
        */
        }

        function addWorkItem() {

            var table = document.getElementById("item_dtl");

            var work_items = document.getElementById("<%=work_item.ClientID %>").value;

            var work_items_text = document.getElementById("<%=work_item_text.ClientID %>").value;

            var tblBody = document.createElement("tbody");

            var work_type = document.getElementById("<%=hfWorkType.ClientID %>").value;

            var witem_lvl1 = document.getElementById("<%=work_item_lvl1.ClientID %>");

            var witem_lvl2 = document.getElementById("<%=work_item_lvl2.ClientID %>");

            var type = witem_lvl1.options[witem_lvl1.selectedIndex];
            var item = witem_lvl2.options[witem_lvl2.selectedIndex];

            var arrItems = work_items.split(',');
            var flag = false;

            for (var i = 0; i < arrItems.length; i++) {
                if (arrItems[i] == item.value) {
                    flag = true;
                }
            }

            if (item.value != "" && type.value != "" && !flag) {

                var row = document.createElement("tr");

                var cell = document.createElement("td");
                var cellText = document.createTextNode("");
                cell.className = "td_cont3 td_center";
                cell.appendChild(cellText);
                row.appendChild(cell);

                var cell = document.createElement("td");
                var cellText = document.createTextNode(type.text + '-' + item.text);
                cell.className = "td_cont3 td_left";
                cell.appendChild(cellText);
                row.appendChild(cell);


                var celDel = document.createElement("td");
                celDel.innerHTML = "<img alt=\"刪除\" src=\"../images/delete.png\" id=\"btnDelRow_0\" onclick=\"deleteRow(this.parentNode.parentNode.rowIndex);\" />";
                celDel.className = "td_cont3 td_center";
                row.appendChild(celDel);


                tblBody.appendChild(row);
                table.appendChild(tblBody);

                renewIndex();

                if (work_items.length == 0) {
                    document.getElementById("<%=work_item.ClientID %>").value = work_items += item.value;
                    document.getElementById("<%=work_item_text.ClientID %>").value = type.text + '-' + item.text;
                }
                else {
                    document.getElementById("<%=work_item.ClientID %>").value = work_items += "," + item.value;
                    document.getElementById("<%=work_item_text.ClientID %>").value = work_items_text + "," + type.text + '-' + item.text;
                }
            } else
                alert('請選擇作業項目！(不可重複)')
        }

        function deleteRow(input) {

            var table = document.getElementById("item_dtl");
            var rowCount = table.rows.length;
            var work_items = document.getElementById("<%=work_item.ClientID %>").value;
            var work_items_text = document.getElementById("<%=work_item_text.ClientID %>").value;
            var arrItems = work_items.split(',');
            var arrItemTexts = work_items_text.split(',');



            if (rowCount <= 1) {
                alert("不能刪除所有列資料！");
            }
            else {

                var items = "";
                var itemTexts = "";

                for (var i = 0; i < arrItems.length; i++) {
                    if (i != input) {
                        items += arrItems[i] + ",";
                        itemTexts += arrItemTexts[i] + ",";
                    }
                }

                document.getElementById("<%=work_item.ClientID %>").value = items.substring(0, items.length - 1);
                document.getElementById("<%=work_item_text.ClientID %>").value = itemTexts.substring(0, itemTexts.length - 1);

                table.deleteRow(input);
                renewIndex();
            }            
        }


        //序號欄
        function renewIndex() {

            var table = document.getElementById("item_dtl");

            for (var i = 0; i < table.rows.length; i++) {
                table.rows[i].cells[0].innerHTML = (i + 1);
            }
        }


        function tableCreate() {

            var table = document.getElementById("item_dtl");

            var repair_item = document.getElementById("<%=work_item_text.ClientID %>").value;

            var arrList = repair_item.split(",");

            var tblBody = document.createElement("tbody");

            if (repair_item != "") {

                if (arrList.length >= 1) {

                    for (var j = 0; j < arrList.length; j++) {

                        var row = document.createElement("tr");

                        var cell = document.createElement("td");
                        var cellText = document.createTextNode("");
                        cell.className = "td_cont3 td_center";
                        cell.appendChild(cellText);
                        row.appendChild(cell);

                        var cell = document.createElement("td");
                        var cellText = document.createTextNode(arrList[j]);
                        cell.className = "td_cont3 td_left";
                        cell.appendChild(cellText);
                        row.appendChild(cell);


                        var celDel = document.createElement("td");
                        celDel.innerHTML = "<img alt=\"刪除\" src=\"../images/delete.png\" id=\"btnDelRow_0\" onclick=\"deleteRow(this.parentNode.parentNode.rowIndex);\" />";
                        celDel.className = "td_cont3 td_center";
                        row.appendChild(celDel);

                        tblBody.appendChild(row);
                    }
                }

                table.appendChild(tblBody);
            }

            renewIndex();
        }

    </script>
</asp:Content>
