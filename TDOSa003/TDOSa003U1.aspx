<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa003U1.aspx.cs" Inherits="TDTSa003_TDTSa003U1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">
                <!-- 內容 -->
                <table width="1000">
                    <tr>
                        <td>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td class="td_head td_right" style="width: 30%">
                                        <span class="td_must">*</span>臨時卡補登車號有效天數
                                    </td>
                                    <td class="td_cont">
                                        每月&nbsp;<asp:TextBox ID="key_date" runat="server" Width="50px" OnTextChanged="key_date_TextChanged"
                                            AutoPostBack="True"></asp:TextBox>&nbsp;號前可補登上月1號至本月<asp:Label ID="key_end_date"
                                                runat="server" Text=""></asp:Label>&nbsp;號
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="key_date" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="td_must" ErrorMessage="1~28"
                                            ValidationGroup="save" Display="Dynamic" MaximumValue="28" MinimumValue="1" ControlToValidate="key_date"
                                            Type="Integer"></asp:RangeValidator>
                                        <asp:HiddenField ID="basic_id" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head td_right">
                                        <span class="td_must">*</span>發送資料登打提醒郵件通知的日期
                                    </td>
                                    <td class="td_cont">
                                        每月&nbsp;<asp:TextBox ID="send_date" runat="server" Width="50px"></asp:TextBox>&nbsp;號
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="send_date" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" CssClass="td_must" ErrorMessage="1~28"
                                            ValidationGroup="save" Display="Dynamic" MaximumValue="28" MinimumValue="1" ControlToValidate="send_date"
                                            Type="Integer"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head td_right">
                                        <span class="td_must">*</span>勤務記錄可登打之勤務日期的有效天數
                                    </td>
                                    <td class="td_cont">
                                        每月&nbsp;<asp:TextBox ID="work_date" runat="server" Width="50px" AutoPostBack="True"
                                            OnTextChanged="work_date_TextChanged" Style="height: 17px"></asp:TextBox>&nbsp;號前可補登上月1號至本月&nbsp;<asp:Label
                                                ID="work_end_date" runat="server" Text=""></asp:Label>&nbsp;號
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="work_date" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator3" runat="server" CssClass="td_must" ErrorMessage="1~28"
                                            ValidationGroup="save" Display="Dynamic" MaximumValue="28" MinimumValue="1" ControlToValidate="work_date"
                                            Type="Integer"></asp:RangeValidator>
                                    </td>
                                </tr>
                            </table>
                            <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
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
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="1000">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="2">
                                        解除鎖定資料
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_cont" colspan="2" align="center">
                                        <fieldset class="color_fieldset" style="margin-bottom: 10px; margin-left: 10px;">
                                            <legend class="font_fieldset">新增解除鎖定資料</legend>
                                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                                <tr>
                                                    <td width="20%" class="td_head">
                                                        <span class="td_must">*</span>授權帳號
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:DropDownList ID="dep_org" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dep_org_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="unlock_user" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                                            InitialValue="" ErrorMessage="必填" ControlToValidate="dep_org" ValidationGroup="lock"
                                                            Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        <span class="td_must">*</span>解除鎖定資料類型
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:RadioButtonList ID="unlock_type" runat="server" RepeatDirection="Horizontal"
                                                            AutoPostBack="True" OnSelectedIndexChanged="unlock_type_SelectedIndexChanged">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        <span class="td_must">*</span>解除鎖定資料範圍
                                                    </td>
                                                    <td class="td_cont">
                                                        <asp:TextBox ID="data_str" runat="server" size="10" class="date"></asp:TextBox>
                                                        ~
                                                        <asp:TextBox ID="data_end" runat="server" size="10" class="date"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                                            InitialValue="" ErrorMessage="必填" ControlToValidate="data_str" ValidationGroup="lock"
                                                            Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="td_must"
                                                            InitialValue="" ErrorMessage="必填" ControlToValidate="data_end" ValidationGroup="lock"
                                                            Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                                            ClientValidationFunction="Date_Validate" ControlToValidate="data_str" ValidationGroup="lock"
                                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                                            ClientValidationFunction="Date_Validate" ControlToValidate="data_end" ValidationGroup="lock"
                                                            Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                                        <span class="td_memo">(<asp:Label ID="data_memo" runat="server" Text=""></asp:Label>)</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="td_head">
                                                        <span class="td_must">*</span>授權資料登打時間
                                                    </td>
                                                    <td class="td_cont">
                                                        <div style="float: left">
                                                            <asp:TextBox ID="key_str" runat="server" size="10" class="date"></asp:TextBox>
                                                            ~
                                                            <asp:TextBox ID="key_end" runat="server" size="10" class="date"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="td_must"
                                                                InitialValue="" ErrorMessage="必填" ControlToValidate="key_str" ValidationGroup="lock"
                                                                Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="td_must"
                                                                InitialValue="" ErrorMessage="必填" ControlToValidate="key_end" ValidationGroup="lock"
                                                                Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                                                ClientValidationFunction="Date_Validate" ControlToValidate="key_str" ValidationGroup="lock"
                                                                Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                                                ClientValidationFunction="Date_Validate" ControlToValidate="key_end" ValidationGroup="lock"
                                                                Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                                        </div>
                                                        <div style="float: right; width: 100px; display: inline;">
                                                            <asp:Button ID="btn_Unlock" runat="server" Text="儲存" CssClass="btn_grey" ValidationGroup="lock"
                                                                OnClick="btn_Unlock_Click" /></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                        <!-- 分頁處理 -->
                                        <asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>
                                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                            OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="100%"
                                            EnableModelValidation="True" DataKeyNames="unlock_id" onrowdeleting="gvMain_RowDeleting">
                                            <Columns>
                                                <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Center" Height="25" Width="5%" CssClass="td_center td_headhrz td_headmulti" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="資料類型" DataField="unlock_type" ItemStyle-CssClass="td_cont3 td_center">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="8%" CssClass="td_center td_headhrz td_headmulti" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="授權帳號" DataField="unlock_user" ItemStyle-CssClass="td_cont3 td_left">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="解鎖鎖定資料範圍" DataField="" ItemStyle-CssClass="td_cont3 td_center">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="18%" CssClass="td_center td_headhrz td_headmulti" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="授權登打有效時間" DataField="">
                                                    <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="18%" CssClass="td_center td_headhrz td_headmulti" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="建檔人員" DataField="create_user">
                                                    <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="15%" />
                                                    <ItemStyle CssClass="td_cont3 td_left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="建檔時間" DataField="create_date">
                                                    <HeaderStyle CssClass="td_center td_headhrz td_headmulti" />
                                                    <ItemStyle CssClass="td_cont3 td_center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="刪除">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="DELETE" ImageUrl="~/images/del.png" />
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
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
