<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSb001Q2.aspx.cs" Inherits="TDOSb001_TDOSb001Q2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function SelectedChange(oSpan) {

            var grid = document.getElementById("MasterPage_ContentPlaceHolder1_gvMain");

            for (i = 1; i < grid.rows.length; i++) {
                var checkBox = grid.rows[i].cells[13].getElementsByTagName("input")[0];
                checkBox.checked = oSpan.checked;
                colorselected('row' + (i-1), checkBox);
            }
        }

        function Validate(sender, args) {
            var grid = document.getElementById("<%=gvMain.ClientID %>");
            var checkBoxes = grid.getElementsByTagName("input");
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

        function colorselected(rowID, oSpan) {
            
            if (oSpan.checked) {
                document.getElementById(rowID).style.backgroundColor = '#efefef';
            } else {
                document.getElementById(rowID).style.backgroundColor = 'ffffff';
            }
        }

        function colorSeleted2() {
            var grid = document.getElementById("MasterPage_ContentPlaceHolder1_gvMain");

            for (i = 1; i < grid.rows.length; i++) {
                var checkBox = grid.rows[i].cells[13].getElementsByTagName("input")[0];
               
                    colorselected('row' + (i - 1), checkBox);

            }
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
                            <td class="td_head">
                                資料來源
                            </td>
                            <td class="td_cont">
                                <%--<asp:CheckBoxList ID="data_source" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>--%>
                                <asp:RadioButtonList ID="data_source" runat="server" 
                                    RepeatDirection="Horizontal" AutoPostBack="true" onselectedindexchanged="data_source_SelectedIndexChanged">
                                        </asp:RadioButtonList>
                            </td>
                            <td class="td_head">
                                交易日期
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="deal_start" runat="server" CssClass="date" Width="70px"></asp:TextBox>~
                                <asp:TextBox ID="deal_end" runat="server" CssClass="date" Width="70px"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">
                                車牌號碼
                            </td>
                            <td width="25%" class="td_cont">
                                <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">
                                保管單位
                            </td>
                            <td class="td_cont">
                                <asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                                </asp:DropDownList>
                                <td width="10%" class="td_head">
                                    加油卡號
                                </td>
                                <td class="td_cont">
                                    <asp:DropDownList ID="card_type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="card_type_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="card_id" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td width="10%" class="td_head">
                                    局編號
                                </td>
                                <td class="td_cont">
                                    <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                                </td>
                        </tr>
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click"
                                    CausesValidation="False" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click"
                                    CausesValidation="False" />
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
                            <%--<asp:Label ID="pbLabel" runat="server" Text=""></asp:Label>--%>
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1200px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="fuel_id,data_source,deal_date">
                                <Columns>
                                    <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Height="25" Width="4%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="資料來源" DataField="source_name" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="匯入序號" DataField="import_id" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="6%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="管理單位" DataField="mng_name" ItemStyle-CssClass="td_cont3 td_left">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="11%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="卡別" DataField="card_type_name">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="6%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="加油卡號" DataField="card_no">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="交易日期" DataField="deal_date">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="加油站" DataField="stand_name">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" />
                                        <ItemStyle CssClass="td_cont3 td_left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="油品類型" DataField="fuel_name">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="5%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="數量" DataField="fuel_count">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="參考金額" DataField="fuel_amount" DataFormatString="{0:0,0}">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="確認 / 審核" DataField="">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="補登車號">
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbCardNo" runat="server" Width="65"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cbAll" runat="server" onclick="javascript:SelectedChange(this);"
                                                Text="" ToolTip="按一次全選，再按一次取消全選" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbAdt" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="4%" />
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
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="請至少勾選一筆資料！"
                    ClientValidationFunction="Validate" Display="None"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="td_must"
                    ErrorMessage="請輸入報表年月！" ControlToValidate="tbReportYM" Display="None">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="報表年月無效" CssClass="td_must"
                    ClientValidationFunction="YM_Validate" ControlToValidate="tbReportYM" 
                    Display="None" OnServerValidate="YMValidator_ServerValidate"></asp:CustomValidator>
                <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                    runat="server" DisplayMode="BulletList" />
                <asp:Panel ID="pnlAdt" runat="server">
                    <table width="1200px" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr class="td_center td_headhrz">
                            <td class="td_head td_center td_highh2" colspan="4">
                                資料審核 / 確認
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head" width="10%">
                                報表年月
                            </td>
                            <td class="td_cont" width="15%">
                                <asp:TextBox ID="tbReportYM" runat="server" Width="60"></asp:TextBox>
                            </td>
                            <td class="td_head" width="10%">
                                審核 / 確認狀態
                            </td>
                            <td class="td_cont">
                                <asp:RadioButtonList ID="adt_status" runat="server" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">
                                資料審核說明
                            </td>
                            <td class="td_cont " colspan="3">
                                <asp:TextBox ID="adt_desc" runat="server" TextMode="MultiLine" Rows="3" Width="600px"  MaxLength="1000"></asp:TextBox>
                                <asp:Button ID="btnAdt" runat="server" Text="審核 / 確認" CssClass="btn_grey" OnClick="btnAdt_Click" />
                                <asp:HiddenField ID="old_desc" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <!-- 留下空行的位置　-->
        <tr>
            <td height="10" colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
