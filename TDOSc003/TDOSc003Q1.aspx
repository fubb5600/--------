<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc003Q1.aspx.cs" Inherits="TDOSc003_TDOSc003Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
              

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <tr>
                                    <td width="10%" class="td_head">
                                        勤務類型
                                    </td>
                                    <td width="20%" class="td_cont">
                                        <asp:CheckBoxList ID="work_type" runat="server" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                    </td>
                                    <td class="td_head">
                                        勤務日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="work_str" runat="server" size="10" class="date"></asp:TextBox>
                                        ~
                                        <asp:TextBox ID="work_end" runat="server" size="10" class="date"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="work_str" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="work_end" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                    <td class="td_head">
                                        報表作業日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="work_date_str" runat="server" size="10" class="date"></asp:TextBox>
                                        ~
                                        <asp:TextBox ID="work_date_end" runat="server" size="10" class="date"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="work_date_str" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                            ClientValidationFunction="Date_Validate" ControlToValidate="work_date_end" ValidationGroup="save"
                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                </tr>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <tr>
                            <td width="10%" class="td_head">
                                車牌號碼
                            </td>
                            <td width="20%" class="td_cont">
                                <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">
                                局編號
                            </td>
                            <td width="25%" class="td_cont">
                                <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">
                                加油卡卡號
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="card_no" runat="server"></asp:TextBox>
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
<%--                            2019.07.29--%>
                            <td width="10%" class="td_head">
                                作業機具   (
                    <input id="chkAllMachine" type="checkbox" /><label for="chkAllMachine">全選</label>
                                )
                            </td>
                            <td class="td_cont" colspan="5">
                                <asp:CheckBoxList ID="work_machine" runat="server" RepeatDirection="Horizontal" RepeatColumns="9"
                                    CssClass="cbl_fieldset">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                             <td class="td_head">保管單位(<input id="chkAllunit" type="checkbox" /><label for="chkAllunit">全選</label>
                                )
                            </td>
                            <td class="td_cont" colspan="5">
                                <asp:CheckBoxList ID="keep_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="8"
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
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click" ValidationGroup="save" />
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" />
                                <asp:Button ID="btnO1" runat="server" Text="產出報表" CssClass="btn_grey" OnClick="btnO1_Click" />
                                <%--<asp:Button ID="EXE" runat="server" CssClass="btn_grey"  Text="開啟檔案" OnClick="EXE_Click" />--%>
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
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                    OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="98%"
                    EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="work_id">
                    <Columns>
                        <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Width="8%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="報表作業日期" DataField="work_date">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                            <HeaderStyle HorizontalAlign="Center" Width="9%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="勤務日期(起)" DataField="work_start">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                            <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="勤務日期(迄)" DataField="work_end" ItemStyle-CssClass="td_cont3 td_center">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="勤務類型" DataField="work_type">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                            <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="加油卡號" DataField="card_no" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                            <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="車號 / 機具" DataField="work_object" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                            <HeaderStyle HorizontalAlign="Center" Width="13%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="里程起訖" DataField="mileage" ItemStyle-CssClass="td_cont3 td_left">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作業單位" DataField="work_org">
                            <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                            <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="td_center td_headhrz td_headmulti" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="編輯">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="5%" />
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
        <!-- 留下空行的位置　-->
        <tr>
            <td height="10" colspan="2">
            </td>
        </tr>
    </table>
        <script type="text/javascript" src="../js/Michael/Ccbselect.js"></script>

</asp:Content>
