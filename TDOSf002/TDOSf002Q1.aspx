<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSf002Q1.aspx.cs" Inherits="TDOSf002_TDOSf002Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12"></td>
            <td valign="top" width="1080px">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td width="10%" class="td_head">維修類型
                            </td>
                            <td width="22%" class="td_cont" colspan="5">
                                <asp:CheckBoxList ID="work_type" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" class="td_head">局編號
                            </td>
                            <td width="22%" class="td_cont">
                                <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">車牌號碼
                            </td>
                            <td width="22%" class="td_cont">
                                <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">檢驗結果
                            </td>
                            <td class="td_cont">
                                   <!-- //2018/08/31測試查驗結果Checkbox-->
                                <asp:CheckBoxList ID="check_result" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>   <!-- //2018/08/31測試查驗結果Checkbox  before-->
                             
                                <asp:CheckBox ID="check_result0_chk" Text="合格" runat="server" />
                                <asp:CheckBox ID="check_result1_chk" Text="不合格" runat="server" />
                                <asp:CheckBox ID="check_result2_chk" Text="未填" runat="server" />
                                 <!-- //2018/08/31測試查驗結果Checkbox-->
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">標案號碼
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="case_no" runat="server"></asp:TextBox>
                            </td>
                            <td class="td_head">派工單號
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="work_no" runat="server"></asp:TextBox>
                            </td>
                            <td class="td_head">維修廠商
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="repair_vender" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">報修日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="notify_start" runat="server" Width="70px" CssClass="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="notify_end" runat="server" Width="70px" CssClass="date"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="notify_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="notify_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td class="td_head">完工日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="finish_start" runat="server" Width="70px" CssClass="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="finish_end" runat="server" Width="70px" CssClass="date"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="finish_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="finish_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td class="td_head">維修方式
                            </td>
                            <td class="td_cont">
                                <asp:DropDownList ID="repair_type1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="repair_type1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="repair_type2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="repair_type2_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="repair_type3" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">託修單位
                            (
                    <input id="chkAllcrs" type="checkbox" /><label for="chkAllcrs">全選</label>
                                )
                            </td>
                            <td class="td_cont" colspan="5">
                                <asp:CheckBoxList ID="crs_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="8"
                                    CssClass="cbl_fieldset">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        
                        <%-- <tr>
                            <td class="td_head">
                                履約日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="exec_deadline_start" runat="server" size="10" class="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="exec_deadline_end" runat="server" size="10" class="date"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="exec_deadline_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="exec_deadline_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td class="td_head">
                                完工時間
                            </td>
                            <td class="td_cont">
                                 <asp:TextBox ID="finish_date_start" runat="server" size="10" class="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="finish_date_end" runat="server" size="10" class="date"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="finish_date_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="finish_date_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td class="td_head">
                                查驗日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="check_date_start" runat="server" size="10" class="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="check_date_end" runat="server" size="10" class="date"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator9" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="check_date_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator10" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="check_date_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">
                                查驗合格日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="qualified_date_start" runat="server" size="10" class="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="qualified_date_end" runat="server" size="10" class="date"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="qualified_date_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="qualified_date_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                             <td class="td_head">
                                交貨期限
                            </td>
                            <td class="td_cont" >
                                <asp:TextBox ID="delivery_date_start" runat="server" size="10" class="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="delivery_date_end" runat="server" size="10" class="date"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="delivery_date_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="delivery_date_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                        </tr>--%>
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <%--UseSubmitBehavior="false"--%>
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click"
                                    ValidationGroup="save" TabIndex="0" />
                                <asp:Button ID="btnExport" runat="server" Text="匯出" CssClass="btn_grey" OnClick="btnExport_Click" />
                                   <asp:Button ID="btnIn" runat="server" Text="匯入" CssClass="btn_grey" OnClick="btnIn_Click"  />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" />
                                <asp:HiddenField ID="sortedfield" runat="server" />
                            </asp:Panel>
                            <div style="margin:10px;"><asp:Label ID="err_msg" runat="server" Text="" CssClass="td_must"></asp:Label></div>
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;
                </p>
                <!-- 瀏覽頁, 進入時先隱藏 -->
                <table class="table_sn" id="num_1">
                    <tr>
                        <td>
                            <!-- 分頁處理 -->
                            <asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1600px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="repair_id,crs_org"  RowStyle-Height="50">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-CssClass="td_center td_headhrz td_headmulti" ItemStyle-CssClass="td_cont3 td_center"
                                        HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="40px"></HeaderStyle>
                                        <ItemStyle CssClass="td_cont3 td_center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="ROW_NUM_t" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="ROW_NUM_h" runat="server" Height="20px" Text="序號"></asp:Label>
                                            <asp:Button ID="ROW_NUM_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="ROW_NUM_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ROW_NUM_l" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="90px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="託修單位">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="crs_org_t" runat="server" Text='<%# Bind("crs_org") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="crs_org_h" runat="server" Height="20px" Text="托修單位"></asp:Label>
                                            <asp:Button ID="crs_org_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="crs_org_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="crs_org_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="crs_org_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="crs_org_l" runat="server" Text='<%# Bind("crs_org") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="局編號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="dep_no_t" runat="server" Text='<%# Bind("dep_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="dep_no_h" runat="server" Height="20px" Text="局編號"></asp:Label>
                                            <asp:Button ID="dep_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="dep_no_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="dep_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="dep_no_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="dep_no_l" runat="server" Text='<%# Bind("dep_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="車牌號碼">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_no_t" runat="server" Text='<%# Bind("car_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_no_h" runat="server" Height="20px" Text="車牌號碼"></asp:Label>
                                            <asp:Button ID="car_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="car_no_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="car_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="car_no_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_no_l" runat="server" Text='<%# Bind("car_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="車輛/機具類型">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_type_t" runat="server" Text='<%# Bind("car_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_type_h" runat="server" Height="20px" Text="車輛/機具類型"></asp:Label>
                                            <asp:Button ID="car_type_s" runat="server" Height="18px" Width="24px" Text="▼" OnClick="car_type_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="car_type_sd" runat="server" Height="18px" Width="24px" Text="▲" OnClick="car_type_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_type_l" runat="server" Text='<%# Bind("car_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="標案編號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="case_no_t" runat="server" Text='<%# Bind("case_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="case_no_h" runat="server" Height="20px" Text="標案編號"></asp:Label>
                                            <asp:Button ID="case_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="case_no_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="case_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="case_no_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="case_no_l" runat="server" Text='<%# Bind("case_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="200px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="派工單號">
                                        <HeaderTemplate>
                                            <asp:Label ID="work_no_h" runat="server" Height="20px" Text="派工單號"></asp:Label>
                                            <asp:Button ID="work_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="work_no_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="work_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="work_no_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="work_no_t" runat="server" Text='<%# Bind("work_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="work_no_l" runat="server" Text='<%# Bind("work_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="維修廠商">
                                        <HeaderTemplate>
                                            <asp:Label ID="repair_vender_h" runat="server" Height="20px" Text="維修廠商"></asp:Label>
                                            <asp:Button ID="repair_vender_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="repair_vender_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="repair_vender_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="repair_vender_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="repair_vender_t" runat="server" Text='<%# Bind("repair_vender") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="repair_vender_t" runat="server" Text='<%# Bind("repair_vender") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="220px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="報修日期">
                                        <HeaderTemplate>
                                            <asp:Label ID="notify_date_h" runat="server" Height="20px" Text="報修日期"></asp:Label>
                                            <asp:Button ID="notify_date_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="notify_date_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="notify_date_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="notify_date_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="notify_date_t" runat="server" Text='<%# Bind("notify_date1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="notify_date_l" runat="server" Text='<%# Bind("notify_date1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="通知日期">
                                        <HeaderTemplate>
                                            <asp:Label ID="notify_date_h1" runat="server" Height="20px" Text="通知日期"></asp:Label>
                                            <asp:Button ID="notify_date_s1" runat="server" Height="18px" Text="▼" Width="24px" OnClick="notify_date_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="notify_date_sd1" runat="server" Height="18px" Text="▲" Width="24px" OnClick="notify_date_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="notify_date_t1" runat="server" Text='<%# Bind("notify_date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="notify_date_l1" runat="server" Text='<%# Bind("notify_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="交貨期限">
                                        <HeaderTemplate>
                                            <asp:Label ID="delivery_days_h" runat="server" Height="20px" Text="交貨期限"></asp:Label>
                                            <asp:Button ID="delivery_days_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="delivery_days_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="delivery_days_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="delivery_days_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="delivery_days_t" runat="server" Text='<%# Bind("delivery_days") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="delivery_days_l" runat="server" Text='<%# Bind("delivery_days") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="履約期限">
                                        <HeaderTemplate>
                                            <asp:Label ID="exec_deadline_h" runat="server" Height="20px" Text="履約期限"></asp:Label>
                                            <asp:Button ID="exec_deadline_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="exec_deadline_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="exec_deadline_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="exec_deadline_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="exec_deadline_t" runat="server" Text='<%# Bind("exec_deadline") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="exec_deadline_l" runat="server" Text='<%# Bind("exec_deadline") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="完工日期">
                                        <HeaderTemplate>
                                            <asp:Label ID="finish_date_h" runat="server" Height="20px" Text="完工日期"></asp:Label>
                                            <asp:Button ID="finish_dates" runat="server" Height="18px" Text="▼" Width="24px" OnClick="finish_date_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="finish_datesd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="finish_date_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="finish_date_t" runat="server" Text='<%# Bind("finish_date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="finish_date_l" runat="server" Text='<%# Bind("finish_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="查驗結果">
                                        <HeaderTemplate>
                                            <asp:Label ID="check_result_h" runat="server" Height="20px" Text="查驗結果"></asp:Label>
                                            <asp:Button ID="check_results" runat="server" Height="18px" Text="▼" Width="24px" OnClick="check_results_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="check_resultsd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="check_resultsd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="check_result_t" runat="server" Text='<%# Bind("check_result") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="check_result_l" runat="server" Text='<%# Bind("check_result") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="託修總價">
                                        <HeaderTemplate>
                                            <asp:Label ID="total_price_h" runat="server" Height="20px" Text="託修總價"></asp:Label>
                                            <asp:Button ID="total_price_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="total_price_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="total_price_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="total_price_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="total_price_t" runat="server" Text='<%# Bind("total_price") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="total_price_l" runat="server" Text='<%# Bind("total_price", "${0:N0}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_right" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                   

                                    <asp:TemplateField HeaderText="編輯">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="40px" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
                                <HeaderStyle CssClass="td_headmulti" />
                                <RowStyle CssClass="td_cont3" />
                                <EmptyDataTemplate>
                                    無資料
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Panel ID="pnlPrint" runat="server">
                                <asp:Button ID="btnPrint1" runat="server" Text="查驗記錄單" CssClass="btn_grey" OnClick="btnPrint1_Click" />
                                <asp:Button ID="btnPrint2" runat="server" Text="交車簽收單" CssClass="btn_grey" OnClick="btnPrint2_Click" />
                                <asp:Button ID="btnPrint3" runat="server" Text="完工接車單" CssClass="btn_grey" OnClick="btnPrint3_Click" />
                                <asp:Button ID="True" runat="server" Text="確認" CssClass="btn_grey" OnClick="True_Click" Visible="false"/>
                                <asp:Button ID="False" runat="server" Text="退件" CssClass="btn_grey" OnClick="False_Click" Visible="false"/>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!-- 留下空行的位置　-->
        <tr>
            <td height="10" colspan="2"></td>
        </tr>
    </table>
    <script type="text/javascript" src="../js/Michael/Ccbselect-1.js"></script>
</asp:Content>
