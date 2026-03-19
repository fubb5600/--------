<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TDOSf002U2.ascx.cs" Inherits="TDOSf002_TDOSf002U2" %>
<script src="../js/fill.js" type="text/javascript"></script>
<script src="../js/buttonAction.js" type="text/javascript"></script>
<script src="../js/Validate.js" type="text/javascript"></script>
<script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
<script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.8.22.custom.min.js" type="text/javascript"></script>
<script src="../js/chineseDatepicker.js" type="text/javascript"></script>
<script type="text/javascript" src="../menu.js"></script>
<link type="text/css" href="../menu.css" rel="stylesheet" />
<link type="text/css" href="../css/CommStyle.css" rel="stylesheet" />
<link type="text/css" href="../css/jquery-ui-1.8.22.custom.css" rel="stylesheet" />
<style type="text/css">
    .auto-style3 {
        margin-left: 0px;
    }
  
</style>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td width="2"></td>
        <td valign="top">

            <asp:HiddenField ID="work_no" runat="server" />
            <asp:HiddenField ID="crs_area" runat="server" />
            <asp:HiddenField ID="repair_item" runat="server" />

            <asp:HiddenField ID="selected_row" runat="server" />
            <asp:HiddenField ID="car_id" runat="server" />

            <%-- 加註已報修過_wenny_1061207 --%>
            <table style="width: 100%;" id="repair_dtl" class="table_mt table_border" border="1">
                <tr>
                    <td class="td_center td_headhrz td_headmulti" width="5%">序號
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="10%">報修內容
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="10%">零件編號
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="10%">零件名稱
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="5%">數量
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="8%">總價
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="15%">廢品名稱
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="10%">廢品數量
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="15%">重複報修日
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="5%">編輯
                    </td>
                    <td class="td_center td_headhrz td_headmulti" width="5%">刪除
                    </td>
                </tr>
            </table>

            <table id="repair_sum" border="0" class="auto-style3" style=" width: 100%">
                <tr>
                    <td style="width: 15%" colspan="2">
                        <input id="btnNewRow" type="button" value="新增一列" class="btn_grey" onclick="javascript: openWindow('')" style="margin-top: 0px" />
                       <%--<asp:HiddenField ID="hfRepairItems" runat="server" />--%>
                    </td>
                    <td  align="right"  style="width:20%" colspan="2">合計</td>
                    <td  align="right"  style="width:5%">&nbsp;</td>
                    <td  align="right" style="width:8%">&nbsp;</td>
                    <td  align="right" style="width:15%"></td>
                    <td  align="right"style="width:10%"></td>
                    <td  align="right"style="width:15%">&nbsp;</td>
                    <td align="right"style="width:5%"></td>
                    <td  align="right"style="width:5%">&nbsp;</td>
                      <td  align="right"style="width:5%">&nbsp;</td>
                </tr>
            </table>
        </td>


    </tr>
</table>
<script type="text/javascript">
    var table = document.getElementById("repair_dtl");
    tableCreate();
   
    function openWindow(input) {
        if (input == "")
            document.getElementById('<%=selected_row.ClientID %>').value = "";

        if (document.getElementById('<%=work_no.ClientID %>').value != "") {
        //if (document.getElementById("ContentPlaceHolder1_TDOSf002U2_work_no").value != "") {////修正彈跳視窗未出現，因ID抓不到_wenny20171116
            //if (document.getElementById("MasterPage_ContentPlaceHolder1_TDOSf002U2_work_no").value != ""){ //原始碼
            //加註已報修過_wenny_1061207
            TINY.box.show({ iframe: 'TDOSf002U3.aspx?work_no=<%=work_no.Value %>&crs_area=<%=crs_area.Value %>&repair_item=' + input, boxid: 'frameless', width: 750, height: 500, fixed: false, maskid: 'bluemask', maskopacity: 40, closejs: function () { } });//原始碼
       } else {
           alert("請輸入派工單號！");
        }
       
    }


    function tableCreate() {
        var repair_item = document.getElementById('<%=repair_item.ClientID %>').value;

        //var repair_item = document.getElementById("ContentPlaceHolder1_TDOSf002U2_repair_item").value;//修正彈跳視窗未出現，因ID抓不到_wenny20171116
        //var repair_item = document.getElementById("MasterPage_ContentPlaceHolder1_TDOSf002U2_repair_item").value;    //原始碼
  
        var arrList = repair_item.split(";");
        //arrList[arrlist.length ] = "";//加註已報修過_wenny_1061207
       
        var tblBody = document.createElement("tbody");
        var repairtItem = "";

        if (repair_item != "") {

            if (arrList.length >= 1) {

                //rows = arrList.length + 1;
                for (var j = 0; j < arrList.length; j++)
                {


                    repairtItem = arrList[j];
                    var row = document.createElement("tr");
                    var cell = document.createElement("td");
                    var cellText = document.createTextNode("");
                    cell.className = "td_cont3 td_center";
                    cell.appendChild(cellText);
                    row.appendChild(cell);

                    var arrColumns = arrList[j].split("|");
                    //console.log(arrColumns);
                    arrColumns[0] = arrColumns[0].replace("aaaaaaa", "&");//20180206修正'&'出錯
                    ////console.log(arrColumns[0]);
                    //加註已報修過_wenny_1061207
                    if (typeof arrColumns[arrColumns.length] == "undefined")
                    { arrColumns[arrColumns.length] = '' }

                    for (var i = 0; i <8; i++) {////加註已報修過_wenny_1061207
                    //for (var i = 0; i <arrColumns.length; i++) {////加註已報修過_wenny_1061207
                        //for (var i = 0; i < arrColumns.length; i++) {//原始碼

                        var cell = document.createElement("td");
                       
                        var cellText = document.createTextNode(arrColumns[i]);
                       
                        //加註已報修過_wenny_1061207
                        if (i == 0 || i == 5 || i == 8) {
                            //if (i == 0 || i == 4) {//原始碼
                            cell.className = "td_cont3 td_left";
                        } else if (i == 4) {
                            cellText = document.createTextNode(colculatePrice(arrColumns[i - 1], arrColumns[i]));
                            cell.className = "td_cont3 td_right";
                        } else {
                            cell.className = "td_cont3 td_center";
                        }

                        if (i == 4) {
                            cellText.data = cellText.data.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
                 
                        }

                        cell.appendChild(cellText);
                        row.appendChild(cell);
                    }

                    var cellEdit = document.createElement("td");
                    cellEdit.innerHTML = "<img alt=\"編輯\" src=\"../images/folder_big.gif\" id=\"btnEditRow_0\" onclick=\"openWindow('" + repairtItem + "');editRow(this.parentNode.parentNode.rowIndex);\"/>";
                    cellEdit.className = "td_cont3 td_center";
                    row.appendChild(cellEdit);

                    var celDel = document.createElement("td");
                    celDel.innerHTML = "<img alt=\"刪除\" src=\"../images/delete.png\" id=\"btnDelRow_0\" onclick=\"deleteRow(this.parentNode.parentNode.rowIndex);\" />";
                    celDel.className = "td_cont3 td_center";
                    row.appendChild(celDel);

                    tblBody.appendChild(row);
                }
            }

            table.appendChild(tblBody);
        }

        renewIndex();
        getRepairItemValue();
        sumTable();
    }


    function deleteRow(input) {
        var rowCount = table.rows.length;

        if (rowCount <= 2) {
            alert("不能刪除所有列資料！");
        }
        else
            table.deleteRow(input);

        renewIndex();
        getRepairItemValue();
        sumTable();
    }


    function addRow(input) {
        //彈跳視窗確定不能執行修正wenny_20171117'
        if (document.getElementById('<%=selected_row.ClientID%>').value.length > 0)
        //if (document.getElementById("ContentPlaceHolder1_TDOSf002U2_selected_row").value.length > 0)
            //原始碼
            //if (document.getElementById("MasterPage_ContentPlaceHolder1_TDOSf002U2_selected_row").value.length > 0)
            editRowData(input);
        else {
            //input = input.replace("&amp;", "aaaaaaa")//20180206修正'&'出錯
            var rowCount = table.rows.length;
            var row = table.insertRow(rowCount);
            var arrColumns = input.split("|");
            //arrColumns[0] = arrColumns[0].replace("aaaaaaa", "&");//20180206修正'&'出錯
            //consol.log(arrColumns[0]);
            var cell = document.createElement("td");
            var cellText = document.createTextNode("");
            cell.className = "td_cont3 td_center";
            cell.appendChild(cellText);
            row.appendChild(cell);




            
            for (var i = 0; i < arrColumns.length; i++) {

                var cell = document.createElement("td");

                var cellText = document.createTextNode(arrColumns[i]);

                //加註已報修過_wenny_1061207
                //if (i == 0 || i == 5 || i == arrColumns-2) {
                 if (i == 0 || i == 5 || i == arrColumns-2) {
                    //if (i == 0 || i == 4) {
                    cell.className = "td_cont3 td_left";
                } else if (i == 4) {
                    cellText = document.createTextNode(colculatePrice(arrColumns[i - 1], arrColumns[i]));
                    cell.className = "td_cont3 td_right";
                } else {
                    cell.className = "td_cont3 td_center";
                }

                cell.appendChild(cellText);
                row.appendChild(cell);
            }

            var cellEdit = document.createElement("td");
            cellEdit.innerHTML = "<img alt=\"編輯\" src=\"../images/folder_big.gif\" id=\"btnEditRow_0\" onclick=\"openWindow('" + input + "');editRow(this.parentNode.parentNode.rowIndex);\"/>";
            cellEdit.className = "td_cont3 td_center";
            row.appendChild(cellEdit);

            var celDel = document.createElement("td");
            celDel.innerHTML = "<img alt=\"刪除\" src=\"../images/delete.png\" id=\"btnDelRow_0\" onclick=\"deleteRow(this.parentNode.parentNode.rowIndex);\" />";
            celDel.className = "td_cont3 td_center";
            row.appendChild(celDel);
        }

        renewIndex();
        getRepairItemValue();
        sumTable();
    }

    function colculatePrice(inputCount, inputPrice) {
       //修正單價為小數點兩位_wennyh_1229
        //var count = parseInt(inputCount);
        //var price = parseInt(inputPrice);
        //return (price * count).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
        var count = parseFloat(inputCount);
        var price = parseFloat(inputPrice);
        //return Math.round(price * count).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");

        return Math.round(price * count);
    }

    function getRepairItemValue() {

        var items = "";

        for (var i = 1; i < table.rows.length; i++) {

            for (var j = 1; j < (table.rows[i].cells.length - 2); j++) {

                var val = table.rows[i].cells[j].innerHTML;

                items += val + "|";
            }

            if (items != "")
                items = items.substring(0, items.length - 1) + ";";
        }

        if (items != "")
            items = items.substring(0, items.length - 1);
        items = items.replace('&amp;', 'aaaaaaa')//20180206修正'&'出錯
        document.getElementById("<%=repair_item.ClientID %>").value = items;
       

    }

    function renewIndex() {

        for (var i = 1; i < table.rows.length; i++) {
            table.rows[i].cells[0].innerHTML = i;
        }
    }

    function sumTable() {

        var sumTable = document.getElementById("repair_sum");
        var sumCount = 0;
        var sumAmount = 0;
        var sumJunkCount = 0;
        var row = table.rows.length - 1;

        for (var i = 1; i < (table.rows.length); i++) {

            sumCount += parseInt(table.rows[i].cells[4].innerHTML);//原始碼

            var junkCount = table.rows[i].cells[7].innerHTML;//原始碼
            if (junkCount == "")
                junkCount = 0;

            sumJunkCount += parseInt(junkCount);

            var amt = table.rows[i].cells[5].innerHTML.toString();//原始碼
            sumAmount += parseInt(amt.replace(',', ''));

        }


        sumTable.rows[0].cells[2].innerHTML = sumCount;//原始碼
        sumTable.rows[0].cells[3].innerHTML = sumAmount.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
        sumTable.rows[0].cells[5].innerHTML = sumJunkCount;
    }

    function editRow(input) {
        document.getElementById('<%=selected_row.ClientID%>').value = input;
        //document.getElementById("ContentPlaceHolder1_TDOSf002U2_selected_row").value = input;//修正彈跳視窗未出現，因ID抓不到_wenny20171116
        //document.getElementById("MasterPage_ContentPlaceHolder1_TDOSf002U2_selected_row").value = input;// 原始碼
    }

    function editRowData(input) {

        input = input.replace("&amp;", "aaaaaaa")//20180206修正'&'出錯
        var arrColumns = input.split("|");
         
        arrColumns[0] = arrColumns[0].replace("aaaaaaa", " &amp;")//20180206修正'&'出錯

        var rowIndex = parseInt(document.getElementById('<%=selected_row.ClientID%>').value);
        //var rowIndex = parseInt(document.getElementById("ContentPlaceHolder1_TDOSf002U2_selected_row").value);//修正彈跳視窗未出現，因ID抓不到_wenny20171116
        //var rowIndex = parseInt(document.getElementById("MasterPage_ContentPlaceHolder1_TDOSf002U2_selected_row").value);// 原始碼
        for (var i = 0; i < arrColumns.length; i++) {
            if (i == 4) {
                table.rows[rowIndex].cells[i + 1].innerHTML = colculatePrice(arrColumns[i - 1], arrColumns[i]);
            } else
                table.rows[rowIndex].cells[i + 1].innerHTML = arrColumns[i];
        }

        table.rows[rowIndex].cells[9].innerHTML = "<img alt=\"編輯\" src=\"../images/folder_big.gif\" id=\"btnEditRow_0\" onclick=\"openWindow('" + input + "');editRow(this.parentNode.parentNode.rowIndex);\"/>";
        //table.rows[rowIndex].cells[9].innerHTML = "<img alt=\"編輯\" src=\"../images/folder_big.gif\" id=\"btnEditRow_0\" onclick=\"openWindow('" + input + "');editRow(this.parentNode.parentNode.rowIndex);\"/>";
      //  table.rows[rowIndex].cells[7].innerHTML = "<img alt=\"編輯\" src=\"../images/folder_big.gif\" id=\"btnEditRow_0\" onclick=\"openWindow('" + input + "');editRow(this.parentNode.parentNode.rowIndex);\"/>";//原始碼
    }

    function deleteAllRows() {

        var table = document.getElementById("repair_dtl");

        while (table.rows[0]) table.deleteRow(0);
    }
</script>
