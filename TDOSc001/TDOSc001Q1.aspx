<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc001Q1.aspx.cs" Inherits="TDOSc001_TDOSc001Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: #222a68;
            text-align: right;
            font-weight: normal;
            border-bottom: 1px dotted #d0d0bf;
            border-right: 1px dotted #d0d0bf;
            padding-right: 5px;
            height: 103px;
            padding-left: 2px;
            padding-top: 2px;
            padding-bottom: 2px;
        }
        .auto-style2 {
            text-align: left;
            font-weight: normal;
            border-bottom: 1px dotted #d0d0bf;
            border-right: 1px solid #d0d0bf;
            padding-left: 5px;
            height: 103px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >

 <script type="text/javascript" language="javascript">

        function GetNotifyMsg() {
            var str = '<%= Session["NOTIFYMSG"].ToString()%>';
            if (str != "")
                alert(str);
            return true;
        }
    </script>
    <!--提醒託修作業資料未建置完整_WENNY_1061206-->
    <script type="text/javascript" language="javascript">

       function GetNotifyMsg()
        {
           var str = '<%= Session["NOTIFYMSG"].ToString()%>';
           if (str != "" )
            alert(str);
           return true;
        }
    </script>


    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="12"></td>
            <td valign="top">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td width="10%" class="td_head">車牌號碼
                            </td>
                            <td width="25%" class="td_cont">
                                <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">局編號
                            </td>
                            <td width="25%" class="td_cont">
                                <asp:TextBox ID="dep_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">油品類型
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="fuel_type" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_head">狀態
                            </td>
                            <td class="td_cont">
                                <div style="float: left">
                                    <asp:CheckBoxList ID="status" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Value="O">使用中</asp:ListItem>
                                        <asp:ListItem Value="C">停用</asp:ListItem>
                                        <asp:ListItem>報廢</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                                <div id="divChgRsn" style="float: left; padding-left: 10px; display: none">
                                    (<asp:CheckBoxList ID="chg_rsn" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:CheckBoxList>)
                                </div>
                            </td>
                            <td class="td_cont" colspan="4"></td>
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
                            <td class="auto-style1">保管單位(<input id="chkAllunit" type="checkbox" /><label for="chkAllunit">全選</label>
                                )
                            </td>
                            <td class="auto-style2" colspan="5">
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
                            <asp:Panel ID="buttonPanel" runat="server" Width="337px">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click" UseSubmitBehavior="false" OnClientClick="GetNotifyMsg();" />
                                <asp:Button ID="btnExport" runat="server" CssClass="btn_grey"  Text="匯出" UseSubmitBehavior="false" OnClick="btnExport_Click" OnClientClick="GetNotifyMsg();"/>
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_grey" OnClick="btnInsert_Click" OnClientClick="GetNotifyMsg();"/>
<%--                             1080513新增                             --%>
                                <asp:Button ID="btnExportAll" runat="server" CssClass="btn_grey"  Text="全部匯出" UseSubmitBehavior="false" OnClick="btnExportAll_Click" OnClientClick="GetNotifyMsg();" />
                                <asp:HiddenField ID="sortedfield" runat="server" />
                               <%-- <asp:Button ID="Button1" runat="server" OnClick="btnExport_Click" OnCommand="Button1_Click1" Text="Button" Visible="False" />--%>
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
                                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1500px"
                                EnableModelValidation="True" OnRowEditing="gvMain_RowEditing" DataKeyNames="car_id">
                                <Columns>

                                    <%--   <asp:BoundField HeaderText="車牌號碼" DataField="car_no">
                                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                                        <HeaderStyle HorizontalAlign="Center" Width="11%" CssClass="td_center td_headhrz td_headmulti" />
                                    </asp:BoundField>--%>


                                    <asp:TemplateField HeaderText="序號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="ROW_NUM_t" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="ROW_NUM_h" runat="server" Text="序號"></asp:Label>
                                            <asp:Button ID="ROW_NUM_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false"  />
                                            <asp:Button ID="ROW_NUM_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false" />
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
                                            <asp:Button ID="dep_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="dep_no_s_Click" UseSubmitBehavior="false"  />
                                            <asp:Button ID="dep_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="dep_no_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="dep_no_l" runat="server" Text='<%# Bind("dep_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="車牌號碼">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_no_t" runat="server" Text='<%# Bind("car_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_no_h" runat="server" Text="車牌號碼"></asp:Label>
                                            <asp:Button ID="car_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="car_no_s_Click" UseSubmitBehavior="false"  />
                                            <asp:Button ID="car_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="car_no_sd_Click" UseSubmitBehavior="false" />

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_no_l" runat="server" Text='<%# Bind("car_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="車隊卡號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="card_no_t" runat="server" Text='<%# Bind("card_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Labecard_no_hl2" runat="server" Text="車隊卡號"></asp:Label>
                                            <asp:Button ID="card_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="card_no_s_Click" UseSubmitBehavior="false"  />
                                            <asp:Button ID="card_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="card_no_sd_Click" UseSubmitBehavior="false"  />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="card_no_l" runat="server" Text='<%# Bind("card_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="車輛種類">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="car_type_t" runat="server" Text='<%# Bind("car_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="car_type_h" runat="server" Text="車輛種類"></asp:Label>
                                            <asp:Button ID="car_type_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="car_type_s_Click" UseSubmitBehavior="false"  />
                                            <asp:Button ID="car_type_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="car_type_sd_Click" UseSubmitBehavior="false"  />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="car_type_l" runat="server" Text='<%# Bind("car_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <%--新增廠牌欄位_wenny1061122--%>
                                    <asp:TemplateField HeaderText="廠牌">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="brand_no_t" runat="server" Text='<%#Bind("brand_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="brand_no_h" runat="server" Text="廠牌"></asp:Label>
                                            <asp:Button ID="brand_no_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="brand_no_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="brand_no_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="brand_no_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                             <asp:Label ID="brand_no_l" runat="server" Text='<%# Bind("brand_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <%--新增噸數欄位_wenny1061122--%>
                                    <asp:TemplateField HeaderText="噸數">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tonnage" runat="server" Text='<%#Bind("tonnage") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="tonnage_h" runat="server" Text="噸數"></asp:Label>
                                            <asp:Button ID="tonnage_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="tonnage_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="tonnage_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="tonnage_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                             <asp:Label ID="tonnage_l" runat="server" Text='<%# Bind("tonnage") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="油品">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="fuel_type_t" runat="server" Text='<%# Bind("fuel_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="fuel_type_h" runat="server" Text="油品"></asp:Label>
                                            <asp:Button ID="fuel_type_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="fuel_type_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="fuel_type_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="fuel_type_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="fuel_type_l" runat="server" Text='<%# Bind("fuel_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="9%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="保管單位">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="keep_org_t" runat="server" Text='<%# Bind("keep_org") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="keep_org_h" runat="server" Text="保管單位"></asp:Label>
                                            <asp:Button ID="keep_org_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="keep_org_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="keep_org_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="keep_org_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="keep_org_l" runat="server" Text='<%# Bind("keep_org") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="狀態">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="status_t" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="status_h" runat="server" Text="狀態"></asp:Label>
                                            <asp:Button ID="status_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="status_s_Click" UseSubmitBehavior="false" />
                                            <asp:Button ID="status_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="status_sd_Click" UseSubmitBehavior="false" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="status_l" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="編輯">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EDIT" ImageUrl="~/images/folder_big.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="7%" />
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
    <script type="text/javascript" src="../js/Michael/Ccbselect.js"></script>
</asp:Content>
