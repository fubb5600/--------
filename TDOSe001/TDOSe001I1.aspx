<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSe001I1.aspx.cs" Inherits="TDTSe001_TDTSe001I1" %>

<%@ Register Src="../Common/Card_Data.ascx" TagName="Card_Data" TagPrefix="uc1" %>
<%@ Register Src="../Common/fuel_use.ascx" TagName="fuel_use" TagPrefix="uc2" %>
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
                <table width="900">
                    <tr>
                        <td>
                            <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>零件編號
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:TextBox ID="component_no" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="component_no" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td width="15%" class="td_head">
                                        <span class="td_must">*</span>項目名稱
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="component_name" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            ErrorMessage="必填" ControlToValidate="component_name" ValidationGroup="save" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" class="td_head">
                                        規格
                                    </td>
                                    <td width="35%" class="td_cont">
                                        <asp:TextBox ID="component_Spec" runat="server"></asp:TextBox>
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="component_Spec" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td class="td_head">
                                        <span></span>數量
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="count" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="td_must"
                                            runat="server" ErrorMessage="整數" ValidationExpression="^[0-9]*$" ControlToValidate="count"
                                            ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>單位
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="unit" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="unit" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>代碼
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="component_code" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="component_code" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>適用車種
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="car_type" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="car_type" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        產地
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="place_of_origin" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>預算單價(第1區)
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="budget1" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="budget1" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="td_must"
                                            runat="server" ErrorMessage="整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$" ControlToValidate="budget1"
                                            ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>預算單價(第2區)
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="budget2" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="budget2" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" CssClass="td_must"
                                            runat="server" ErrorMessage="整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$" ControlToValidate="budget2"
                                            ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>預算單價(第3區)
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="budget3" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="budget3" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" CssClass="td_must"
                                            runat="server" ErrorMessage="整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$" ControlToValidate="budget3"
                                            ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>預算單價(第4區)
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="budget4" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="budget4" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" CssClass="td_must"
                                            runat="server" ErrorMessage="整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$" ControlToValidate="budget4"
                                            ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        備註
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" Width="600px" Rows="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--                  </table>
                            <uc1:Card_Data ID="Card_Data1" runat="server" />
                        </td>
                    </tr>
                </table>--%>
                                <!-- BUTTON -->
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="buttonPanel" runat="server">
                                                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnSave_Click" OnClientClick=" GetNotifyMsg();"
                                                    ValidationGroup="save" />
                                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" OnClientClick=" GetNotifyMsg();"/>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                        </td>
                    </tr>
                </table>
</asp:Content>
