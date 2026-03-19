<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSd008Q1.aspx.cs" Inherits="TDOSd008_TDOSd008Q1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            font-weight: normal;
            border-bottom: 1px dotted #d0d0bf;
            border-right: 1px solid #d0d0bf;
            padding-left: 5px;
            width: 22%;
        }
        </style>
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
                            <td width="10%" class="td_head">車牌號碼
                            </td>
                            <td class="td_cont">
                                <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%" class="td_head">派工單號
                            </td>
                            <td class="td_cont">
                                   <!-- //2018/08/31測試查驗結果Checkbox-->
                                <asp:TextBox ID="work_no" runat="server"></asp:TextBox>
                            </td>
                              <td class="td_head">庫存
                            </td>
                            <td class="td_cont">
                                   <!-- //2018/08/31測試查驗結果Checkbox-->
                                <asp:TextBox ID="Thing1" runat="server"></asp:TextBox>
                                   </td>
                             <td width="10%" class="td_head">零件編號
                            </td>
                            <td class="td_cont">
                                   <!-- //2018/08/31測試查驗結果Checkbox-->
                                <asp:TextBox ID="No" runat="server"></asp:TextBox>
                                   </td>
                        </tr>
                      
                                         <tr>
                            <td class="td_head"><span style="color: rgb(34, 42, 104); font-family: Arial, Helvetica, sans-serif; font-size: small; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(222, 235, 254); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">新增庫存日期</span>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="Update_Time_start" runat="server" Width="70px" CssClass="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="Update_Time_end" runat="server" Width="70px" CssClass="date"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="無效開始日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="Update_Time_start" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="無效結束日期" CssClass="td_must"
                                    ClientValidationFunction="Date_Validate" ControlToValidate="Update_Time_end" ValidationGroup="save"
                                    Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td class="td_head"><span style="color: rgb(34, 42, 104); font-family: Arial, Helvetica, sans-serif; font-size: small; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(222, 235, 254); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">使用庫存日期</span></td>
                            <td class="td_cont">
                                <%--<asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                                </asp:DropDownList>--%>
                                 <asp:TextBox ID="Use_Time_start" runat="server" Width="70px" CssClass="date"></asp:TextBox>
                                ~
                                <asp:TextBox ID="Use_Time_end" runat="server" Width="70px" CssClass="date"></asp:TextBox>
                                
                            </td>
                            <td class="td_head">使用車牌號碼</td>
                            <td class="td_cont">
                                <asp:TextBox ID="Use_Car" runat="server"></asp:TextBox>
                            </td>

                                                <td class="td_head">使用派工單號</td>
                            <td class="td_cont">
                                <asp:TextBox ID="Use_No" runat="server"></asp:TextBox>
                            </td>
                        </tr>     
                          <tr>
                            <td class="td_head">使用者</td>
                            <td class="td_cont">
                                <%--<asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged">
                                </asp:DropDownList>--%>
                                    <asp:DropDownList ID="User" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged" Height="19px" Width="156px">
                                </asp:DropDownList>
                            </td>
                            <td class="td_head">新舊資料</td>
                            <td class="td_cont">
                                <asp:RadioButtonList ID="NeworOld" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="X">舊</asp:ListItem>
                                    <asp:ListItem Value="O">即時</asp:ListItem>
                                </asp:RadioButtonList>
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
                                    ValidationGroup="save" TabIndex="0" Width="77px" />
                                <%--UseSubmitBehavior="false"--%>
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
                                 BorderWidth="1px" CellPadding="0" Width="1600px"
                                EnableModelValidation="True"   RowStyle-Height="50"  style="margin-top: 0" OnSelectedIndexChanged="gvMain_SelectedIndexChanged" OnRowEditing="gvMain_RowEditing"  DataKeyNames="ID">
                                <Columns>
                                
                                    <asp:TemplateField HeaderText="使用者">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="User" runat="server" Text='<%# Bind("User2") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                          <HeaderTemplate>
                                            <asp:Label ID="User" runat="server" Height="20px" Text="使用者"></asp:Label>
                                           
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="User" runat="server" Text='<%# Bind("User2") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                
                                    <asp:TemplateField HeaderText="車牌號碼">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Car" runat="server" Text='<%# Bind("Car") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Car" runat="server" Height="20px" Text="車牌號碼"></asp:Label>
                                         
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Car" runat="server" Text='<%# Bind("Car") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="物料">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Thing" runat="server" Text='<%# Bind("Thing") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Thing" runat="server" Height="20px" Text="物料"></asp:Label>
                                          
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Thing" runat="server" Text='<%# Bind("Thing") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="零件編號">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="No" runat="server" Text='<%# Bind("No") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="No" runat="server" Height="20px" Text="零件編號"></asp:Label>
                                           
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="No" runat="server" Text='<%# Bind("No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle CssClass="td_cont3 td_left" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="數量">
                                        <HeaderTemplate>
                                            <asp:Label ID="Count" runat="server" Height="20px" Text="數量"></asp:Label>
                                           

                                        </HeaderTemplate>

                                        <EditItemTemplate>
                                            <asp:TextBox ID="Count" runat="server" Text='<%# Bind("Count") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Count" runat="server" Text='<%# Bind("Count") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" />
                                    </asp:TemplateField>
                                  

                                  
                                    
                                      

                                  
                                    
                                    <asp:TemplateField HeaderText="Update_Time">
                                        <HeaderTemplate>
                                            <asp:Label ID="Update_Time" runat="server" Height="20px" Text="新增庫存日期"></asp:Label>
                                          

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Update_Time" runat="server" Text='<%# Bind("Update_Time") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Update_Time" runat="server" Text='<%# Bind("Update_Time") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                         


                                     <asp:TemplateField HeaderText="Use_Time">
                                        <HeaderTemplate>
                                            <asp:Label ID="Use_Time" runat="server" Height="20px" Text="使用庫存日期 "></asp:Label>
                                          

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Use_Time" runat="server" Text='<%# Bind("Use_Time") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Use_Time" runat="server" Text='<%# Bind("Use_Time") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                         


                                         <asp:TemplateField HeaderText="Use_Car">
                                        <HeaderTemplate>
                                            <asp:Label ID="Use_Car" runat="server" Height="20px" Text="使用車牌號碼"></asp:Label>
                                          

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Use_Car" runat="server" Text='<%# Bind("Use_Car") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Use_Car" runat="server" Text='<%# Bind("Use_Car") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                         
                                    
                                    <asp:TemplateField HeaderText="Use_No">
                                        <HeaderTemplate>
                                            <asp:Label ID="Use_No" runat="server" Height="20px" Text="使用派工單號 "></asp:Label>
                                          

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Use_No" runat="server" Text='<%# Bind("Use_No") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Use_No" runat="server" Text='<%# Bind("Use_No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                         





                                    
                                    <asp:TemplateField HeaderText="敘述">
                                        <HeaderTemplate>
                                            <asp:Label ID="Memo" runat="server" Height="20px" Text="敘述"></asp:Label>
                                  

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Memo" runat="server" Text='<%# Bind("Memo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Memo" runat="server" Text='<%# Bind("Memo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                      
                                    
                                    <asp:TemplateField HeaderText="派工單號">
                                        <HeaderTemplate>
                                            <asp:Label ID="Work_no" runat="server" Height="20px" Text="派工單號"></asp:Label>
                                          

                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Work_no" runat="server" Text='<%# Bind("Work_no") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Work_no" runat="server" Text='<%# Bind("Work_no") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle CssClass="td_cont3 td_center" HorizontalAlign="Center" />
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
