<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="TDOSf002U3.aspx.cs" Inherits="TDOSf002_TDOSf002U3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
 
        .auto-style1 {
            color: #222a68;
            text-align: right;
            font-weight: normal;
            border-bottom: 1px dotted #d0d0bf;
            border-right: 1px dotted #d0d0bf;
            padding-right: 5px;
            height: 54px;
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
            height: 54px;
        }
 
    </style>
      <script type="text/javascript">

          function setRepairData() {
              var item = "";
            //彈跳視窗確定不能執行修正wenny_20171117
 <%--           item += "<%=notify_item.SelectedValue%>" + "|";
            item +="<%=component_no.SelectedValue%>" + "|";
            item +="<%=component_name.Text%>" + "|"; 
            item += "<%=count.Text%>" + "|";
            item += "<%=unit_price.Text%>" + "|";--%>
              /*   item = myTrim(document.getElementById("MasterPage2_ContentPlaceHolder1_notify_item").value) + "|";
                 item += myTrim(document.getElementById("MasterPage2_ContentPlaceHolder1_component_no").value) + "|";
                 item += myTrim(document.getElementById("MasterPage2_ContentPlaceHolder1_hfCarType").value) + "|";
                 item += myTrim(document.getElementById("MasterPage2_ContentPlaceHolder1_count").value) + "|";
                 item += myTrim(document.getElementById("MasterPage2_ContentPlaceHolder1_unit_price").innerHTML.replace(',', '')) + "|";*/
              item = (document.getElementById('<%=notify_item.ClientID%>').value) + "|";
              item += (document.getElementById('<%=component_no.ClientID%>').value) + "|";
              item += (document.getElementById('<%=component_name.ClientID%>').innerText) + "|";
              item += (document.getElementById('<%=count.ClientID%>').value) + "|";
              item += (document.getElementById('<%=unit_price.ClientID%>').innerHTML.replace(',', '')) + "|";

            //if (hasJunk() == "Y") {
            //彈跳視窗確定不能執行修正wenny_20171117
<%--            item += "<%=junk_name.Text%>" + "|";
            item += "<%=junk_count.Text%>" + "|";--%>
           <%-- //alert("<%=junk_count.Text%>");--%>
              /* item += myTrim(document.getElementById("MasterPage2_ContentPlaceHolder1_junk_name").value) + "|";
            item += myTrim(document.getElementById("MasterPage2_ContentPlaceHolder1_junk_count").value) + "|";*/

              //1080513修改

              if (document.getElementById('<%=junk_name.ClientID%>') == null) {
                  item += "" + "|";
              } else {
                  item += (document.getElementById('<%=junk_name.ClientID%>').value) + "|";
              }
              if (document.getElementById('<%=junk_count.ClientID%>') == null) {
                  item += "" + "|";
              } else {
                  item += (document.getElementById('<%=junk_count.ClientID%>').value) + "|";
              }
 //原始碼

<%--      item += (document.getElementById('<%=junk_name.ClientID%>').value) + "|";

            
      item += (document.getElementById('<%=junk_count.ClientID%>').value) + "|";--%>




            //原始碼

            //item += myTrim(document.getElementById("MasterPage2_ContentPlaceHolder1_notified").textContent);//加註已報修過_wenny_1061207
            item += (document.getElementById('<%=notified.ClientID%>').innerText);//加註已報修過_wenny_1061207
     <%--       item += "<%=notified.Text%>";--%>//加註已報修過_wenny_1061207
            window.parent.addRow(item);
            window.parent.TINY.box.hide();
        }
          function setRepairData1() {
              var item = "";
           

    

            item += (document.getElementById('<%=notified.ClientID%>').innerText);//加註已報修過_wenny_1061207
  
                  window.parent.addRow(item);
                  window.parent.TINY.box.hide();
              }

        function closeJS() {
            window.parent.TINY.box.hide();
        }

        //$('.txtHint').hint();

        function myTrim(x) {
            return x.replace(/^\s+|\s+$/gm, '');
        }


        function validateJunkCheck(sender, args) {

            var check_value = hasJunk();

            if (check_value == "Y" && myTrim(args.Value) == "")
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        function hasJunk() {
            //彈跳視窗確定不能執行修正wenny_20171117
<%--            var check = <%=has_junk.Items.Count%>;
            var checkindex =<%=has_junk.SelectedIndex%>;--%>
            //alert(checkindex);
            //for (i = 0; i < check; i++) {
            //    if (checkindex == 0)
            //        check_value = "Y";
            //    else if (checkindex == 1) check_value = "N";
            //}
            //原始碼
            //var check = document.getElementById("MasterPage2_ContentPlaceHolder1_has_junk");
            var check = document.getElementById('<%=has_junk.ClientID%>');
            var check_value = "";
            for (var i = 0; i < check.rows.length; i++) {
                if (check.rows[0].cells[i].childNodes[0].checked) {
                   check_value = "Y";
                }
            }
                <%--var checkindex =<%=has_junk.SelectedIndex%>;--%>
             //for (i = 0; i < check; i++) {
             //   if (checkindex == 0)
             //       check_value = "Y";
             //   else if (checkindex == 1) check_value = "N";


            //var check_value = "";

            //for (i = 0; i < check; i++) {
            //    if (check.rows[0].cells[i].childNodes[0].checked == true)
            //        check_value = check.rows[0].cells[i].childNodes[0].value;
            //}

            return check_value;
        }

        function clearJunk() {

            var check_value = hasJunk();

            if (check_value == "" || check_value == "N") {
                //彈跳視窗確定不能執行修正wenny_20171117
                      //原始碼
                //document.getElementById("ContentPlaceHolder1_junk_name").value = "";
                //document.getElementById("ContentPlaceHolder1_junk_count").value = "";
            <%--    <%=junk_name.Equals("")%> ;
                  <%=junk_count.Equals("")%>;--%>
         <%--         <%junk_name.Text = "";%>;
                  <%junk_count.Text = "";%>;--%>
          

                /*document.getElementById("MasterPage2_ContentPlaceHolder1_junk_name").value = "";
                document.getElementById("MasterPage2_ContentPlaceHolder1_junk_count").value = "";*/
                document.getElementById('<%=junk_name.ClientID%>'.value) = "";
                document.getElementById('<%=junk_count.ClientID%>').value = "";
              }

          }
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">&nbsp;
            </td>
        </tr>
        <tr>
            <td width="12"></td>
            <td valign="top">
                <!-- 內容 -->
                <table width="100%" class="table_sn table_border" border="0" cellpadding="0" cellspacing="1">
                    <tr class="td_center td_headhrz">
                        <td class="td_head td_center" colspan="5">報修內容
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head" width="15%">
                            <span class="td_must">*</span>報修內容
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:DropDownList ID="notify_item" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="td_must"
                                InitialValue="" ErrorMessage="必填" ControlToValidate="notify_item" ValidationGroup="save"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        &nbsp;
                            <asp:Label ID="Car" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="Date" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="crs_org" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head" rowspan="2">
                            <span class="td_must">*</span>零件編號
                        </td>
                        <td class="td_head" style="width: 6%">年度
                        </td>
                        <td class="td_cont" style="width: 8%">
                            <asp:DropDownList ID="year" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="year_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="td_head" style="width: 8%">適用車種
                        </td>
                        <td class="td_cont" style="width: 20%">
                            <asp:TextBox ID="car_type_keyword" runat="server" OnTextChanged="car_type_keyword_TextChanged"
                                AutoPostBack="true" Width="50px" ToolTip="可輸入關鍵字過濾" Height="19px"></asp:TextBox>
                            <asp:DropDownList ID="car_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="car_type_SelectedIndexChanged"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="td_head" style="width: 6%">代碼</td>
                        <td class="td_cont" style="width: 8%">

                            <asp:DropDownList ID="component_code" runat="server" AutoPostBack="true" OnSelectedIndexChanged="component_code_SelectedIndexChanged">
                            </asp:DropDownList>

                        </td>
                        <td class="td_head" style="width: 8%">項目</td>
                        <td class="td_cont" style="width: 20%">
                            <asp:TextBox ID="component_keyword" runat="server" OnTextChanged="component_keyword_TextChanged"
                                AutoPostBack="true" Width="50px" ToolTip="可輸入關鍵字過濾"></asp:TextBox>
                            <%-- <td class="td_cont" style="width:20%">&nbsp;<asp:TextBox ID="component_filter" runat="server" OnTextChanged="component_filter_TextChanged"
                            AutoPostBack="true" Width="50px" ToolTip="可輸入關鍵字過濾"></asp:TextBox>--%><!--新增"適用車種排序"_wenny1061212_原始碼-->

                            <asp:DropDownList ID="component_no" runat="server" AutoPostBack="true" OnSelectedIndexChanged="component_no_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="td_must"
                                InitialValue="" ErrorMessage="必填" ControlToValidate="component_no" ValidationGroup="save"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head">重複報修日</td>
                        <td class="td_cont" colspan="4">
                            <asp:Label ID="notified" runat="server" ForeColor="Red"></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td class="td_head">項目名稱
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:Label ID="component_name" runat="server" Text=""></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                InitialValue="" ErrorMessage="必填" ControlToValidate="junk_count" ValidationGroup="save"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>--%>
                        </td>

                    </tr>

                    <tr>
                        <td class="td_head">規格
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:Label ID="component_spec" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <span class="td_must">*</span>數量
                        </td>
                        <td class="auto-style2" colspan="4">
                            <asp:TextBox ID="count" runat="server" OnTextChanged="count_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="td_must"
                                InitialValue="" ErrorMessage="必填" ControlToValidate="count" ValidationGroup="save"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="td_must"
                                runat="server" ErrorMessage="整數或小數" ValidationExpression="^[0-9]+\.{0,1}[0-9]{0,2}$"
                                ControlToValidate="count" ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                     <tr>
                        <td class="td_head">
                            <span class="td_must">*</span>進入庫存數量
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:TextBox ID="count1" runat="server" OnTextChanged="count_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head">
                            <span class="td_must">*</span>使用庫存數量
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:TextBox ID="count2" runat="server" AutoPostBack="true"></asp:TextBox>
                               <asp:Label ID="Stock" runat="server" Text="有多少庫存" Visible="true"></asp:Label>
                        <asp:Label ID="Stock1" runat="server" Text="0" Visible="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head">單價
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:Label ID="unit_price" runat="server" Text=""></asp:Label><asp:Label ID="budget_memo"
                                runat="server" Text="" CssClass="td_memo"></asp:Label>
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head">
                            <span class="td_must">*</span>有廢品
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:RadioButtonList ID="has_junk" runat="server" RepeatDirection="Horizontal"    onselectedindexchanged="has_junk_SelectedIndexChanged" AutoPostBack="True">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head">
                            <span class="td_may">*</span>廢品名稱
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:TextBox ID="junk_name" runat="server" Width="300px" AutoPostBack="true" ></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="td_must" ErrorMessage="必填"
                               OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="junk_name"   ClientValidationFunction="validateJunkCheck"
                                ValidationGroup="save" Display="Dynamic" EnableClientScript="true" ValidateEmptyText="true"></asp:CustomValidator>

                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                InitialValue="" ErrorMessage="必填" ControlToValidate="junk_count" ValidationGroup="save"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_head">
                            <span class="td_may">*</span>廢品數量
                        </td>
                        <td class="td_cont" colspan="4">
                            <asp:TextBox ID="junk_count" runat="server" AutoPostBack="true" ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="td_must"
                                InitialValue="" ErrorMessage="必填" ControlToValidate="junk_count" ValidationGroup="save"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>--%> 
                            <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="td_must" ErrorMessage="必填"  
                               ControlToValidate="junk_count"  ClientValidationFunction="validateJunkCheck" OnServerValidate="CustomValidator1_ServerValidate"
                                ValidationGroup="save" Display="Dynamic" EnableClientScript="true" ValidateEmptyText="true"></asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="td_must"
                                runat="server" Text="整數" ErrorMessage="整數" ValidationExpression="^[0-9]{1,}$"
                                ControlToValidate="junk_count" ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="確定" CssClass="btn_grey" ValidationGroup="save"
                                OnClientClick="if(Page_ClientValidate()) setRepairData()" CausesValidation="false" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn_grey" OnClientClick="closeJS()" />
<%--                            <asp:Button ID="yes" runat="server" Text="是否加入庫存" CssClass="btn_grey" OnClientClick="closeJS()" OnClick="yes_Click" Width="120px"   />--%>
                        
                            <asp:Button ID="btnStock" runat="server" Text="使用庫存" CssClass="btn_grey" ValidationGroup="save"
                                   OnClientClick="if(Page_ClientValidate()) setRepairData()" CausesValidation="false" OnClick="btnStock_Click" Width="124px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="12"></td>
        </tr>
    </table>

    <asp:HiddenField ID="hfCarType" runat="server" />
    <!--//新增"適用車種排序"_wenny1061212-->
    <asp:HiddenField ID="hfComponetCode" runat="server" />
    <!--//新增"適用車種排序"_wenny1061212-->
    <asp:HiddenField ID="hfWorkNo" runat="server" />
    <asp:HiddenField ID="hfCRSArea" runat="server" />
    <asp:HiddenField ID="hfRepairItem" runat="server" />
    <asp:HiddenField ID="hfYear" runat="server" />
 

</asp:Content>
