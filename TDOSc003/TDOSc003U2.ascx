<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TDOSc003U2.ascx.cs" Inherits="TDOSc003_TDOSc003U2" %>
<asp:DropDownList ID="work_item_lvl1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="work_item_lvl1_SelectedIndexChanged">
</asp:DropDownList>
<asp:DropDownList ID="work_item_lvl2" runat="server">
</asp:DropDownList>
<input id="btnAddRow" type="button" value="加入" class="btn_grey" onclick="javascript:addItem()" />
<br />
<table style="width: 100%;" id="item_dtl" class="table_mt table_border" border="1">
<tbody></tbody>
</table>
<asp:HiddenField ID="work_item" runat="server" />
<asp:HiddenField ID="work_type" runat="server" />
    <script type="text/javascript">
        var table = document.getElementById("item_dtl");
        var tblBody = document.getElementById("tbody");

        tableCreate();

        function tableCreate() {

            var work_item = document.getElementById("<%=work_item.ClientID %>").value;
            var arrList = work_item.split(";");

            //var tblBody = document.createElement("tbody");

            if (work_item != "") {
                
                if (arrList.length >= 1) {

                    for (var j = 0; j < arrList.length; j++) {                      

                        var row = document.createElement("tr");
                        var cell = document.createElement("td");
                        var cellText = document.createTextNode(arrList[j]);
                        cell.className = "td_cont3 td_center";                        
                        cell.appendChild(cellText);
                        row.appendChild(cell);       

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
            getItemsValue();
        }


        function deleteRow(input) {
            var rowCount = table.rows.length;

            if (rowCount <= 2) {
                alert("不能刪除所有列資料！");
            }
            else
                table.deleteRow(input);

            renewIndex();
            getItemsValue();
        }


        function addRow(input) {

            var tblBody = document.createElement("tbody");

            //var tblBody = document.createElement("tbody");
            var row = document.createElement("tr");

            var cell = document.createElement("td");
            var cellText = document.createTextNode("");
            cell.className = "td_cont3 td_center";
            cell.appendChild(cellText);
            row.appendChild(cell);
            alert(cellText.nodeValue.toString());

            var cell = document.createElement("td");
            var cellText = document.createTextNode(input);
            cell.className = "td_cont3 td_center";
            cell.appendChild(cellText);
            row.appendChild(cell);
            alert(cellText.nodeValue.toString());

            var celDel = document.createElement("td");
            celDel.innerHTML = "<img alt=\"刪除\" src=\"../images/delete.png\" id=\"btnDelRow_0\" onclick=\"deleteRow(this.parentNode.parentNode.rowIndex);\" />";
            celDel.className = "td_cont3 td_center";
            row.appendChild(celDel);
            alert(celDel.innerHTML);

            alert(tblBody);
            tblBody.appendChild(row);

            table.appendChild(tblBody);




//            var rowCount = table.rows.length;
//            var row = table.insertRow(rowCount);           

//            var cell = document.createElement("td");
//            var cellText = document.createTextNode("");
//            cell.className = "td_cont3 td_center";
//            cell.appendChild(cellText);
//            row.appendChild(cell);           

//            var celDel = document.createElement("td");
//            celDel.innerHTML = "<img alt=\"刪除\" src=\"../images/delete.png\" id=\"btnDelRow_0\" onclick=\"deleteRow(this.parentNode.parentNode.rowIndex);\" />";
//            celDel.className = "td_cont3 td_center";
//            row.appendChild(celDel);

            renewIndex();
            alert('finish');
             //getItemsValue();
        }


        function getItemsValue() {

            var items = "";

            for (var i = 1; i < table.rows.length; i++) {                

                if (items != "")
                    items = items.substring(0, items.length - 1) + ";";
            }

            if (items != "")
                items = items.substring(0, items.length - 1);

            document.getElementById("<%=work_item.ClientID %>").value = items;
        }

        function renewIndex() {
            alert('renewIndex');
            for (var i = 1; i < table.rows.length; i++) {
                table.rows[i].cells[0].innerHTML = i;
            }
        }

        function addItem() {

            var work_items = document.getElementById("<%=work_item.ClientID %>").value;                

            var witem_lvl1 = document.getElementById("<%=work_item_lvl1.ClientID %>");

            var witem_lvl2 = document.getElementById("<%=work_item_lvl2.ClientID %>");

            var item = witem_lvl2.options[witem_lvl2.selectedIndex].value;           

            if (work_items.indexOf(item) == -1) {
                addRow(item);
            }
        }
       
</script>
