<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSc005I1.aspx.cs" Inherits="TDTSc005_TDTSc005I1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                        <span class="td_must">*</span>報表年月
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="report_y" runat="server" Width="50px" MaxLength="3"></asp:TextBox>&nbsp;年&nbsp;
                                        <asp:TextBox ID="report_m" runat="server" Width="50px" MaxLength="2"></asp:TextBox>&nbsp;月 <span
                                            class="td_memo">(如：099年09月)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="年必填" ControlToValidate="report_y" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="月必填" ControlToValidate="report_m" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="1~999" Type="Integer"
                                            MaximumValue="999" MinimumValue="1" ControlToValidate="report_y" CssClass="td_must"
                                            ValidationGroup="save"></asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="1~12" Type="Integer"
                                            MaximumValue="12" MinimumValue="1" ControlToValidate="report_m" CssClass="td_must"
                                            ValidationGroup="save"></asp:RangeValidator>
                                    </td>
                                </tr>                              
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>匯入單位
                                    </td>
                                       <td class="td_cont">
                                           <asp:DropDownList ID="load_org" runat="server" >
                                           </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="load_org" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                           <span class="td_memo">※匯入重複年月及單位系統自動刪除前次資料。</span>
                                   </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>檔案來源
                                    </td>
                                    <td class="td_cont">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="600px" />
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
                            </table>
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
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" />
                                <br />
                                <br />
                                <asp:Label ID="lblErrorMsg" runat="server" Text="" CssClass="TableLableNNull"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
