<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSf001Q1.aspx.cs" Inherits="TDOSf001_TDOSf001Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">




    <table  width="100%" border="0" cellpadding="0" cellspacing="0" >
        <tr>
            <td width="12"></td>
            <td valign="top"  width="1080px">
                <!-- 內容 -->
      <%--          <div style="width: 1080px">--%>
                    <fieldset class="color_fieldset">
                        <legend class="font_fieldset">查詢條件</legend>
                        <table class="table_sn table_border" border="0" cellpadding="0" cellspacing="1" width="100%">
                            <tr>
                                <td width="9%" class="td_head">報修類型
                                </td>
                                <td width="25%" class="td_cont">
                                    <asp:CheckBoxList ID="notify_type" runat="server" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                </td>
                                <td width="9%" class="td_head">車牌號碼
                                </td>
                                <td width="25%" class="td_cont">
                                    <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                                </td>
                                <td width="9%" class="td_head">局編號
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_head">報修日期
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="start_date" runat="server" size="10" class="date"></asp:TextBox>
                                    ~
                                    <asp:TextBox ID="end_date" runat="server" size="10" class="date"></asp:TextBox>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                        ClientValidationFunction="Date_Validate" ControlToValidate="start_date" ValidationGroup="save"
                                        Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                        ClientValidationFunction="Date_Validate" ControlToValidate="end_date" ValidationGroup="save"
                                        Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                </td>
                                <td class="td_head">派工單號
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="work_no" runat="server"></asp:TextBox>
                                </td>
                                <td class="td_head">維修方式
                                </td>
                                <td class="td_cont">
                                    <asp:DropDownList ID="repair_type1" runat="server" AutoPostBack="true"  Visible="false" OnSelectedIndexChanged="repair_type1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="repair_type2" runat="server" AutoPostBack="true"  Visible="false" OnSelectedIndexChanged="repair_type2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="repair_type3"  Visible="false" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_head">完工時間
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="finish_start" runat="server" size="10" class="date"></asp:TextBox>
                                    ~
                                    <asp:TextBox ID="finish_end" runat="server" size="10" class="date"></asp:TextBox>
                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                        ClientValidationFunction="Date_Validate" ControlToValidate="finish_start" ValidationGroup="save"
                                        Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                        ClientValidationFunction="Date_Validate" ControlToValidate="finish_end" ValidationGroup="save"
                                        Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                </td>
                                <td class="td_head">維修狀態
                                </td>
                                <td class="td_cont">
                                    <asp:CheckBoxList ID="repair_status" runat="server" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                </td>
                                <td width="9%" class="td_head">維修廠商
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="repair_vender" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <!--//2018/09/03新增報修內容關鍵字查詢-->
                            <tr>  <td width="9%" class="td_head">報修內容</td> 
                                <td class="td_cont" colspan="5">
                                    <asp:TextBox ID="notify_item" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                               <!--//2018/09/03新增報修內容關鍵字查詢-->
                            <tr>
                                <td class="td_head">報修單位<br />
                                    ( <input id="chkAllcrs" type="checkbox" /><label for="chkAllcrs">全選</label> )
                                </td>
                                <td class="td_cont" colspan="5">
                                    <asp:CheckBoxList ID="crs_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="8"
                                        CssClass="cbl_fieldset">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                <%--</div>--%>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click"
                                    ValidationGroup="save" />
                                <asp:Button ID="btnExport" runat="server" Text="匯出" CssClass="btn_grey"
                                    OnClick="btnExport_Click" TabIndex="1" />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" TabIndex="2" />
                                <asp:HiddenField ID="sortedfield" runat="server" />
                            </asp:Panel>
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
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="notify_id">
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
                                            <asp:Button ID="ROW_NUM_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click"  UseSubmitBehavior="false"/>
                                            <asp:Button ID="ROW_NUM_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ROW_NUM_l" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="局編號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="dep_no_t" runat="server" Text='<%# Bind("dep_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="dep_no_h" runat="server" Height="20px" Text="局編號"></asp:Label>
                                            <asp:Button ID="dep_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="dep_no_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="dep_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="dep_no_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="dep_no_l" runat="server" Text='<%# Bind("dep_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="車牌號碼">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_not_" runat="server" Text='<%# Bind("car_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_no_h" runat="server" Height="20px" Text="車牌號碼"></asp:Label>
                                            <asp:Button ID="car_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="car_no_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="car_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="car_no_sd_Click" UseSubmitBehavior="false"/>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_no_l" runat="server" Text='<%# Bind("car_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="保管單位">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="keep_org_t" runat="server" Text='<%# Bind("keep_org") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="keep_org_h" runat="server" Height="20px" Text="保管單位"></asp:Label>
                                            <asp:Button ID="keep_org_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="keep_org_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="keep_org_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="keep_org_sd_Click" UseSubmitBehavior="false"/>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="keep_org_l" runat="server" Text='<%# Bind("keep_org") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="車型 / 機具">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_type_t" runat="server" Text='<%# Bind("car_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_type_h" runat="server" Height="20px" Text="車型/機具"></asp:Label>
                                            <asp:Button ID="car_type_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="car_type_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="car_type_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="car_type_sd_Click" UseSubmitBehavior="false"/>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_type_l" runat="server" Text='<%# Bind("car_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="派工單號">
                                        <HeaderTemplate>
                                            <asp:Label ID="work_no_h" runat="server" Height="20px" Text="派工單號"></asp:Label>
                                            <asp:Button ID="work_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="work_no_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="work_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="work_no_sd_Click" UseSubmitBehavior="false"/>

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="work_no_t" runat="server" Text='<%# Bind("work_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="work_no_l" runat="server" Text='<%# Bind("work_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="報修日期">
                                        <HeaderTemplate>
                                            <asp:Label ID="notify_date_h" runat="server" Height="20px" Text="報修日期"></asp:Label>
                                            <asp:Button ID="notify_date_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="notify_date_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="notify_date_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="notify_date_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="notify_date_t" runat="server" Text='<%# Bind("notify_date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="notify_date_l" runat="server" Text='<%# Bind("notify_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="完工日期">
                                        <HeaderTemplate>
                                            <asp:Label ID="finish_date_h" runat="server" Height="20px" Text="完工日期"></asp:Label>
                                            <asp:Button ID="finish_date_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="finish_date_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="finish_date_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="finish_date_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="finish_date_t" runat="server" Text='<%# Bind("finish_date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="finish_date_l" runat="server" Text='<%# Bind("finish_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="報修內容">
                                        <HeaderTemplate>
                                            <asp:Label ID="notify_item_h" runat="server" Height="20px" Text="報修內容"></asp:Label>
                                            <asp:Button ID="notify_item_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="notify_item_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="notify_item_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="notify_item_sd_Click" UseSubmitBehavior="false"/>

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="notify_item_t" runat="server" Text='<%# Bind("notify_item") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="notify_item_l" runat="server" Text='<%# Bind("notify_item") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="報修方式">
                                        <HeaderTemplate>
                                            <asp:Label ID="repair_type_h" runat="server" Height="20px" Text="報修方式"></asp:Label>
                                            <asp:Button ID="repair_type_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="repair_type_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="repair_type_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="repair_type_sd_Click" UseSubmitBehavior="false"/>

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="報修狀態">
                                        <HeaderTemplate>
                                            <asp:Label ID="repair_status_h" runat="server" Height="20px" Text="報修狀態"></asp:Label>
                                            <asp:Button ID="repair_status_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="repair_status_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="repair_status_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="repair_status_sd_Click" UseSubmitBehavior="false"/>

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="編輯">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="10%" />
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
                                <asp:Button ID="btnPrint" runat="server" Text="車輛派修單" CssClass="btn_grey" OnClick="btnPrint_Click" />

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
