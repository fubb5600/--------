<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc002Q1.aspx.cs" Inherits="TDOSc002_TDOSc002Q1" %>

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
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td width="10%" class="td_head">
                                車牌號碼
                            </td>
                            <td width="15%" class="td_cont">
                                <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">
                                局編號
                            </td>
                            <td width="50%" class="td_cont">
                                <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                            </td>
                          
                        </tr>
                        <tr>
                            <td width="10%" class="td_head">
                                車輛種類(<input id="chkAllCar" type="checkbox" /><label for="chkAllCar">全選</label> )
                            </td>
                            <td class="td_cont" colspan="5">
                                <asp:CheckBoxList ID="car_type" runat="server" RepeatDirection="Horizontal" CssClass="cbl_fieldset"
                                    RepeatColumns="8">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">
                                異動日期
                            </td>
                            <td width="15%" class="td_cont">
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
                            <td class="td_head">
                                異動原因
                            </td>
                            <td class="td_cont" colspan="3">
                                <asp:CheckBoxList ID="chg_rsn" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">
                                異動單位(<input id="chkAllunit" type="checkbox" /><label for="chkAllunit">全選</label> )
                            </td>
                            <td class="td_cont" colspan="5">
                                <asp:CheckBoxList ID="chg_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="8"
                                    CssClass="cbl_fieldset">
                                </asp:CheckBoxList>
                            </td>
                        </tr>                        
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click " ValidationGroup="save" OnClientClick="GetNotifyMsg();"
                                    UseSubmitBehavior="false"/>
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click"  UseSubmitBehavior="false" OnClientClick="GetNotifyMsg();"/>
                                <asp:HiddenField ID="sortedfield" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;</p>
                <!-- 瀏覽頁, 進入時先隱藏 -->
                <table class="table_sn" id="num_1">
                    <tr>
                        <td>
                            <!-- 分頁處理 -->
                            <asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="900px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="chg_id" >
                                <Columns>
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
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
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
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    

                                    <asp:TemplateField HeaderText="車牌號碼">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_no_t" runat="server" Text='<%# Bind("car_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_no_h" runat="server" Height="20px" Text="車牌號碼"></asp:Label>
                                            <asp:Button ID="car_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="car_no_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="car_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="car_no_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_no_l" runat="server" Text='<%# Bind("car_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="車型">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_type_t" runat="server" Text='<%# Bind("car_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_type_h" runat="server" Height="20px" Text="車型"></asp:Label>
                                            <asp:Button ID="car_type_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="car_type_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="car_type_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="car_type_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_type_l" runat="server" Text='<%# Bind("car_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="20%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="異動單位">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="chg_org_t" runat="server" Text='<%# Bind("chg_org") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="chg_org_h" runat="server" Height="20px" Text="異動單位"></asp:Label>
                                            <asp:Button ID="chg_org_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="chg_org_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="chg_org_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="chg_org_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="chg_org_l" runat="server" Text='<%# Bind("chg_org") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    


                                    <asp:TemplateField HeaderText="異動日期">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="chg_date_t" runat="server" Text='<%# Bind("chg_date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="chg_date_h" runat="server" Height="20px" Text="異動日期"></asp:Label>
                                            <asp:Button ID="chg_date_s" runat="server" Height="18px" Text="▼" UseSubmitBehavior="False" Width="24px" OnClick="chg_date_s_Click"  />
                                            <asp:Button ID="chg_date_sd" runat="server" Height="18px" Text="▲" UseSubmitBehavior="False" Width="24px" OnClick="chg_date_sd_Click" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="chg_date_l" runat="server" Text='<%# Bind("chg_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="異動原因">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="chg_rsn_t" runat="server" Text='<%# Bind("chg_rsn") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="chg_rsn_h" runat="server" Height="20px" Text="異動原因"></asp:Label>
                                            <asp:Button ID="chg_rsn_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="chg_rsn_s_Click"  UseSubmitBehavior="false"/>
                                            <asp:Button ID="chg_rsn_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="chg_rsn_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="chg_rsn_l" runat="server" Text='<%# Bind("chg_rsn") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="12%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="編輯">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
                                <HeaderStyle CssClass="td_headmulti" />
                                <RowStyle CssClass="td_cont3" />
                                <EmptyDataTemplate>
                                    無資料</EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!-- 留下空行的位置　-->
        <tr>
            <td height="10" colspan="2">
            </td>
        </tr>
    </table>
    <script type="text/javascript" src="../js/Michael/Ccbselect.js"></script>
</asp:Content>
