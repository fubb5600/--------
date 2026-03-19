<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSa002Q1.aspx.cs" Inherits="TDOSa002_TDOSa002Q1" %>

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
            <td valign="top" width="1000px">
                <!-- 內容 -->
                <fieldset class="color_fieldset">
                    <legend class="font_fieldset">查詢條件</legend>
                    <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">                       
                        <tr>
                            <td class="td_head">
                                參數屬性
                            </td>
                            <td class="td_cont">
                                <asp:DropDownList ID="param_attr" runat="server" >
                                 <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
                                <asp:ListItem Value="1" Text="一般參數" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="2" Text="車輛作業項目"></asp:ListItem>
                                <asp:ListItem Value="3" Text="機具作業項目"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="7%" class="td_head">
                                狀態
                            </td>
                            <td class="td_cont">
                                <asp:CheckBoxList ID="status" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                </asp:CheckBoxList>
                                <span class="td_memo">(本作業僅開放部份參數進行項目內容調整。) </span>
                            </td>
                            </tr>
                            <tr>
                            <td width="10%" class="td_head">
                                參數代碼
                            </td>
                            <td width="17%" class="td_cont">
                                <asp:TextBox ID="param_type" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">
                                參數名稱
                            </td>
                            <td  class="td_cont">
                                <asp:TextBox ID="param_name" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            
                        </tr>
                    </table>
                </fieldset>
                <!-- BUTTON -->
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="buttonPanel" runat="server">
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_grey" OnClick="btnQuery_Click"  UseSubmitBehavior="false" OnClientClick="GetNotifyMsg();"/>
                                <asp:HiddenField ID="sortedfield" runat="server"  />
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
                                OnRowDataBound="gvMain_RowDataBound" BorderWidth="1px" CellPadding="0" Width="1200px"
                                EnableModelValidation="True" DataKeyNames="param_type" OnRowEditing="gvMain_RowEditing">
                                <Columns>
                                    <asp:TemplateField HeaderText="序號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="ROW_NUM_t" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="ROW_NUM_h" runat="server" Height="20px" Text="序號"></asp:Label>
                                            <asp:Button ID="ROW_NUM_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="btnQuery_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="ROW_NUM_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="btnQueryd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ROW_NUM_l" runat="server" Text='<%# Bind("ROW_NUM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="參數代碼">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="param_type_t" runat="server" Text='<%# Bind("param_type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="param_type_h" runat="server" Height="20px" Text="參數代碼"></asp:Label>
                                            <asp:Button ID="param_type_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="param_type_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="param_type_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="param_type_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="param_type_l" runat="server" Text='<%# Bind("param_type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="20%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="參數名稱">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="param_name_t" runat="server" Text='<%# Bind("param_name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="param_name_h" runat="server" Height="20px" Text="參數名稱"></asp:Label>
                                            <asp:Button ID="param_name_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="param_name_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="param_name_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="param_name_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="param_name_l" runat="server" Text='<%# Bind("param_name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="20%" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="狀態">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="status_t" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="status_h" runat="server" Height="20px" Text="狀態"></asp:Label>
                                            <asp:Button ID="status_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="status_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="status_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="status_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="status_l" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="備註">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="memo_t" runat="server" Text='<%# Bind("memo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="memo_h" runat="server" Height="20px" Text="備註"></asp:Label>
                                            <asp:Button ID="memo_s" runat="server" Height="18px" Text="▼" Width="24px" OnClick="memo_s_Click" UseSubmitBehavior="false"/>
                                            <asp:Button ID="memo_sd" runat="server" Height="18px" Text="▲" Width="24px" OnClick="memo_sd_Click" UseSubmitBehavior="false"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="memo_l" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Left" />
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
</asp:Content>
