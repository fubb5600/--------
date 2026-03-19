<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSd001Q1.aspx.cs" Inherits="TDOSd001_TDOSd001Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12">
            </td>
            <td valign="top">

             <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>                   
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td width="10%" class="td_head">
                                        <span class="td_must">*</span>勤務類型
                                    </td>
                                    <td class="td_cont">
                                        <asp:RadioButtonList ID="work_type" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                            OnSelectedIndexChanged="work_type_SelectedIndexChanged">
                                        </asp:RadioButtonList>
                                    </td>
                                    <td width="10%" class="td_head">
                                        <span class="td_must">*</span>統計年月
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="reportYM_start" runat="server" size="10" MaxLength="6" CssClass="date1"></asp:TextBox> ~
                                        <asp:TextBox ID="reportYM_end" runat="server" size="10" MaxLength="6"></asp:TextBox>
                                        <span class="td_memo">(如：101/01)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="reportYM_start" ValidationGroup="save" Display="Dynamic"> </asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="reportYM_end" ValidationGroup="save" Display="Dynamic"> </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="無效年月" CssClass="td_must"
                                            ClientValidationFunction="YM_Validate" ControlToValidate="reportYM_start" ValidationGroup="print"
                                            Display="Dynamic" OnServerValidate="YMValidator_ServerValidate"></asp:CustomValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="無效年月" CssClass="td_must"
                                            ClientValidationFunction="YM_Validate" ControlToValidate="reportYM_end" ValidationGroup="print"
                                            Display="Dynamic" OnServerValidate="YMValidator_ServerValidate"></asp:CustomValidator>
                                    </td>
                                    <td width="10%" class="td_head">
                                        油品分類
                                    </td>
                                    <td class="td_cont" width="20%">
                                        <asp:CheckBoxList ID="fuel_type" runat="server" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="10%" class="td_head">
                                        單位
                                    </td>
                                    <td class="td_cont" colspan="5">
                                        <asp:CheckBoxList ID="keep_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="8" CssClass="cbl_fieldset">
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
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" ValidationGroup="save"
                                    OnClick="btnQuery_Click" />
                                <asp:Button ID="btnReport" runat="server" Text="匯出報表" CssClass="btn_grey" ValidationGroup="save"
                                    OnClick="btnReport_Click" />                                
                                <asp:HiddenField ID="multi_ym" runat="server" /> <!-- 跨月不可儲存 -->                               
                            </asp:Panel>
                        </td>
                    </tr>                    
                </table>
                <%--</ContentTemplate>
                    </asp:UpdatePanel>  --%>      
            </td>
        </tr>
        <!-- 留下空行的位置　-->
        <tr>
            <td width="12">           
            </td>
            <td style="padding-right:20px">
             <p>
                    &nbsp;</p>
                <!-- 瀏覽頁, 進入時先隱藏 -->
                <asp:Panel ID="panelTable" runat="server">
                <table class="table_sn" id="num_1" width="100%">
                    <tr>
                        <td>
                               <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                                OnRowDataBound="gvMain_RowDataBound" BorderWidth="1px" CellPadding="0" Width="100%"
                                EnableModelValidation="True" DataKeyNames="car_id, memo" 
                                onrowcreated="gvMain_RowCreated">
                                <Columns>
                                    <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Height="25" Width="4%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="保管單位" DataField="keep_org" ItemStyle-CssClass="td_cont3 td_left">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="局編號" DataField="dep_no" ItemStyle-CssClass="td_cont3 td_left">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="車牌" DataField="car_no">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="6%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="車型" DataField="car_type">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="車次" DataField="car_count">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_right" />
                                        <HeaderStyle HorizontalAlign="Center" Width="6%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="天數" DataField="work_day">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="5%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="起" DataField="mileage_start">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="5%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="迄" DataField="mileage_end">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="里程數" DataField="sum_mileage">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="上月里程數" DataField="lastmonth_mileage">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="去年里程數" DataField="lastyear_mileage">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="實際加油公升" DataField="sum_count">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="實際加油金額" DataField="sum_amount" DataFormatString="{0:0,0}">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="油耗量實際值(公里/公升)" DataField="fuel_real">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="油耗量標準值(公里/公升)" DataField="fuel_std">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="載重量" DataField="net_weight">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="6%" />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField HeaderText="行駛里程異常備註說明" DataField="memo">
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti"  />
                                        <ItemStyle CssClass="td_cont3 td_right" />
                                    </asp:BoundField> --%>
                                    <asp:TemplateField HeaderText="行駛里程異常備註說明">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMemo" runat="server" Width="200" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="210" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>                                   
                                    </Columns>
                                <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
                                <HeaderStyle CssClass="td_headmulti" />
                                <RowStyle CssClass="td_cont3" />
                                <EmptyDataTemplate>
                                    無資料</EmptyDataTemplate>
                            </asp:GridView>
                            <br />
                            <!-- BUTTON -->
                <table>
                    <tr>
                        <td>

                            <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" ValidationGroup="save"
                                    OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>         
                            </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
