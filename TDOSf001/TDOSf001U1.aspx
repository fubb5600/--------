<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TDOSf001U1.aspx.cs" Inherits="TDOSf001_TDOSf001U1" %>

<%@ Register Src="../Common/car_status.ascx" TagName="car_status" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 440px;
        }
    </style>
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
                                    <td class="td_head">
                                        <span class="td_must">*</span>報修類型
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:RadioButtonList ID="notify_type" runat="server" AutoPostBack="true"
                                            RepeatDirection="Horizontal" 
                                            onselectedindexchanged="notify_type_SelectedIndexChanged">
                                        </asp:RadioButtonList>
                                    </td>
                                 </tr>
                                  <asp:Panel ID="pnlCar" runat="server">
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        車輛資料
                                    </td>
                                </tr>
                                <tr>
                                    <td width="12%" class="td_head">
                                        <span class="td_must">*</span>輸入方式
                                    </td>
                                    <td width="38%" class="td_cont">
                                        <asp:RadioButtonList ID="key_type" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="K">手動輸入</asp:ListItem>
                                            <asp:ListItem Value="D">下拉選單</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td width="12%" class="td_head">
                                        <span class="td_must">*</span>車牌號碼
                                    </td>
                                    <td width="38%" class="td_cont">
                                        <div id="div_K">
                                            <asp:TextBox ID="car_no" runat="server"></asp:TextBox>
                                            <asp:Button ID="btnToilet" runat="server" Text="確定" CssClass="btn_grey" OnClick="btnCar_Click"
                                                ValidationGroup="car" /><span class="td_memo">(或局編號)</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="td_must"
                                                ErrorMessage="必填" ControlToValidate="car_no" ValidationGroup="car" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div id="div_D">
                                            <asp:DropDownList ID="mng_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mng_id_SelectedIndexChanged"
                                                onchange="getNotifyItemValue();">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="car_id" runat="server" AutoPostBack="true" OnSelectedIndexChanged="car_id_SelectedIndexChanged"
                                                onchange="getNotifyItemValue();">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                                InitialValue="" ErrorMessage="必填" ControlToValidate="car_id" ValidationGroup="save"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        局編號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="dep_no" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="notify_id" runat="server" />
                                        <asp:HiddenField ID="hfKeepOrg" runat="server" />
                                    </td>
                                    <td class="td_head">
                                        車輛種類
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="car_type" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        廠牌型號
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="brand_no" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="td_head">
                                        年份 / 噸數
                                    </td>
                                    <td class="td_cont">
                                        <asp:Label ID="car_year_tonnage" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                </asp:Panel>
                                <asp:Panel ID="pnlMachine" runat="server">
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        機具資料
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head" width="12%">
                                        <span class="td_must">*</span>機具類型
                                    </td>
                                    <td class="td_cont" width="38%">
                                        <asp:DropDownList ID="machine_type" runat="server">
                                        </asp:DropDownList> 
                                    </td>
                                    <td class="td_head" width="12%">
                                        <span class="td_must">*</span>所屬單位
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="machine_org" runat="server" AutoPostBack="true" OnSelectedIndexChanged="machine_org_SelectedIndexChanged">
                                        </asp:DropDownList>                                         
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>局編號
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <asp:DropDownList ID="machine_no" runat="server">
                                        </asp:DropDownList>&nbsp;或自行輸入
                                        <asp:TextBox ID="machine_no_ins" runat="server" Width="60px"></asp:TextBox>
                                        <span class="td_memo">(下拉式選單不存在時請自行輸入)</span>
                                    </td>
                                     </tr>
                                </asp:Panel>       
                                <tr class="td_center td_headhrz">
                                    <td class="td_head td_center" colspan="4">
                                        報修資料
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>派工單號
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="work_no" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="work_no" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>報修日期
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="notify_date" runat="server" CssClass="date" Width="60px"></asp:TextBox>
                                        <asp:TextBox ID="notify_HH" runat="server" Width="18px" MaxLength="2"></asp:TextBox>
                                        :
                                        <asp:TextBox ID="notify_mm" runat="server" Width="18px" MaxLength="2"></asp:TextBox>
                                        <span class="td_memo">(如：15:30)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="notify_date" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="報修日期無效日期"
                                            CssClass="td_must" ClientValidationFunction="Date_Validate" ControlToValidate="notify_date"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"
                                            Text="無效日期"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator3" runat="server" CssClass="td_must" ErrorMessage="報修日期小時範圍0~23"
                                            ControlToValidate="notify_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~23">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator4" runat="server" CssClass="td_must" ErrorMessage="報修日期分鐘範圍0~59"
                                            ControlToValidate="notify_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~59">
                                        </asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>派工人員
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="ddlWorkMan" runat="server" AutoPostBack="true" onchange="getNotifyItemValue();"
                                            OnSelectedIndexChanged="ddlWorkMan_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="work_man" runat="server" Width="60px"></asp:TextBox>
                                        <span class="td_memo">(自行輸入請設「請選擇」)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="work_man" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must"></span>里程數
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="mileage" runat="server"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="mileage" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="td_must"
                                            runat="server" Text="整數或小數" ErrorMessage="里程數整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"
                                            ControlToValidate="mileage" ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:Label ID="unit" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>報修內容
                                    </td>
                                    <td class="td_cont" colspan="3">
                                        <table style="line-height: 180%" id="notify_table" class="auto-style1">
                                            <tr>
                                                <td width="410px">
                                                    <input id="txtNotifyItem" type="text" size="65" />
                                                </td>
                                                <td width="30px" align="left">
                                                    <img alt="刪除" src="../images/delete.png" id="btnDelRow_0" onclick="deleteRow(this.parentNode.parentNode.rowIndex);" />
                                                </td>
                                            </tr>
                                        </table>
                                        <input id="btnAddRow" type="button" value="新增一列" onclick="addRow('')" />
                                        <asp:HiddenField ID="notify_item" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="必填" CssClass="td_must"
                                            ClientValidationFunction="IsHasContent" ValidationGroup="save" Display="Dynamic"
                                            OnServerValidate="NotifyItemValidator_ServerValidate"></asp:CustomValidator>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        維修廠商
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="repair_vender" runat="server" Width="250px"></asp:TextBox>
                                    </td>
                                    <td class="td_head">
                                        <span class="td_must">*</span>維修方式
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="repair_type1" Visible="false" runat="server" AutoPostBack="true" 
                                            onchange="getNotifyItemValue();">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="repair_type2"  Visible="false" runat="server" AutoPostBack="true" 
                                            onchange="getNotifyItemValue();">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="repair_type3"  Visible="false" runat="server">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="repair_type4"   runat="server" AutoPostBack="True" >
                                            <asp:ListItem Value="">請選擇</asp:ListItem>
                                            <asp:ListItem Value="IN">合約內</asp:ListItem>
                                            <asp:ListItem Value="OUT">合約外</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="repair_type5"  runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="">請選擇</asp:ListItem>
                                            <asp:ListItem Value="OUT">委外</asp:ListItem>
                                            <asp:ListItem value="SELF">自修</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CheckBoxList ID="CheckBoxList1"   runat="server"  RepeatDirection="Horizontal">
                                            <asp:ListItem Value="MAINTENANCE">保養</asp:ListItem>
                                            <asp:ListItem Value="MATERIAL">須換料</asp:ListItem>
                                            <asp:ListItem Value="REPAIR">維修</asp:ListItem>
                                            <asp:ListItem Value="TUNE">調校</asp:ListItem>
                                        </asp:CheckBoxList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="repair_type2" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="repair_type1" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="repair_type3" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>維修狀態
                                    </td>
                                    <td class="td_cont">
                                        <asp:RadioButtonList ID="repair_status" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                    <td class="td_head">
                                        完工時間
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="finish_date" runat="server" CssClass="date" Width="60px"></asp:TextBox>
                                        <asp:TextBox ID="finish_HH" runat="server" Width="18px" MaxLength="2"></asp:TextBox>
                                        :
                                        <asp:TextBox ID="finish_mm" runat="server" Width="18px" MaxLength="2"></asp:TextBox>
                                        <span class="td_memo">(如：15:30)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="td_must"
                                            InitialValue="" ErrorMessage="必填" ControlToValidate="notify_date" ValidationGroup="save"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="完工時間無效日期"
                                            CssClass="td_must" ClientValidationFunction="Date_Validate" ControlToValidate="finish_date"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"
                                            Text="無效日期"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator5" runat="server" CssClass="td_must" ErrorMessage="完工時間小時範圍0~23"
                                            ControlToValidate="finish_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~23">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator6" runat="server" CssClass="td_must" ErrorMessage="完工時間分鐘範圍0~59"
                                            ControlToValidate="finish_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~59">
                                        </asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_head">
                                        <span class="td_must">*</span>駕駛
                                    </td>
                                    <td class="td_cont">
                                        <asp:DropDownList ID="ddlDriver" runat="server" AutoPostBack="true" onchange="getNotifyItemValue();"
                                            OnSelectedIndexChanged="ddlDriver_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:TextBox ID="driver" runat="server" Width="60px">
                                            </asp:TextBox>
                                            <span class="td_memo">(自行輸入請設「請選擇」)</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                                ErrorMessage="必填" ControlToValidate="driver" ValidationGroup="save" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="td_head">
                                        駕駛接車時間
                                    </td>
                                    <td class="td_cont">
                                        <asp:TextBox ID="pickup_date" runat="server" CssClass="date" Width="60px"></asp:TextBox>
                                        <asp:TextBox ID="pickup_HH" runat="server" Width="18px" MaxLength="2"></asp:TextBox>
                                        :
                                        <asp:TextBox ID="pickup_mm" runat="server" Width="18px" MaxLength="2"></asp:TextBox>
                                        <span class="td_memo">(如：15:30)</span>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="接車時間無效日期"
                                            CssClass="td_must" ClientValidationFunction="Date_Validate" ControlToValidate="pickup_date"
                                            ValidationGroup="save" Display="Dynamic" OnServerValidate="DateValidator_ServerValidate"
                                            Text="無效日期"></asp:CustomValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="td_must" ErrorMessage="接車時間小時範圍0~23"
                                            ControlToValidate="pickup_HH" Display="Dynamic" MaximumValue="23" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~23">
                                        </asp:RangeValidator>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" CssClass="td_must" ErrorMessage="接車時間分鐘範圍0~59"
                                            ControlToValidate="pickup_mm" Display="Dynamic" MaximumValue="59" MinimumValue="0"
                                            ValidationGroup="save" Type="Integer" Text="0~59">
                                        </asp:RangeValidator>
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
                                    ValidationGroup="save" Visible="false" />
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CssClass="btn_grey" OnClientClick="return confirm('確定刪除?')"
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn_grey" OnClick="btnBack_Click" />
                                <asp:Button ID="btnPrint" runat="server" Text="車輛派修單" CssClass="btn_grey" OnClick="btnPrint_Click" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        var notify_items = document.getElementById("<%=notify_item.ClientID %>").value;
        var table = document.getElementById('notify_table');
        var items = notify_items.split("|");
        for (var i = 0; i < items.length; i++) {
            if (i < items.length - 1)
                addRow("");
            table.rows[i].cells[0].children[0].value = items[i];
        }


       //var txtNotifyItem= $('input[name="txtNotifyItem"]').val();
       // alert(txtNotifyItem)
        function addRow(input) {
            var rowCount = table.rows.length;
            var row = table.insertRow(rowCount);
            var colCount = table.rows[0].cells.length;

            for (var i = 0; i < colCount; i++) {
                var newcell = row.insertCell(i);
                newcell.innerHTML = table.rows[0].cells[i].innerHTML;
                switch (newcell.children[0].type) {
                    case "text":
                        newcell.children[0].value = input;
                        break;
                }
            }
        }

        function deleteRow(input) {
            var rowCount = table.rows.length;
            if (rowCount <= 1) {
                alert("不能刪除所有列資料！");
            }
            else
                table.deleteRow(input);
        }

        function getNotifyItemValue() {

            notify_items = "";
            var rowCount = table.rows.length;

            for (var i = 0; i < rowCount; i++) {
                var val = table.rows[i].cells[0].children[0].value;
                if (val != "")
                    notify_items += val + "|";
            }

            document.getElementById("<%=notify_item.ClientID %>").value = notify_items;
        }

        function IsHasContent(source, args) {

            getNotifyItemValue();

            notify_items = document.getElementById("<%=notify_item.ClientID %>").value;

            if (notify_items.length == 0) {
                args.IsValid = false;
            } else
                args.IsValid = true;

            return;
        }

        function getKeyType() {
            var selValue;
            var table = document.getElementById("MasterPage_ContentPlaceHolder1_key_type");

            for (i = 0; i < table.rows[0].cells.length; i++)
                if (table.rows[0].cells[i].childNodes[0].checked == true)
                    selValue = table.rows[0].cells[i].childNodes[0].value;

            if (selValue == "K") {
                document.getElementById("div_K").style.display = "";
                document.getElementById("div_D").style.display = "none";
            }
            else {
                document.getElementById("div_K").style.display = "none";
                document.getElementById("div_D").style.display = "";
            }
        }

        getKeyType();
    </script>
</asp:Content>
