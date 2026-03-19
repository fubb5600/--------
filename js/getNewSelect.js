/*
開啟人員選擇視窗
*/
function openStaff(field) {
    //var src = "../Public/SelectUser.aspx?id=user_id1&name=user_name1&group=group1";
    var src = "../Public/SelectUser.aspx?FIELD=" + field;
    var winOpen = window.open(src, 'SelectUser', 'height=620, width=430, top=100, left=30, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=n o, status=no');
    winOpen.focus();
}
/*
開啟補休假選擇視窗
*/
function openDefer(field, user_id) {
    var user_id = document.getElementById("MasterPage$ContentPlaceHolder1$user_id");
    var src = "../Public/SelectDefer.aspx?FIELD=" + field + "&user_id=" + user_id.value;
    var winOpen = window.open(src, 'SelectDefer', 'height=300, width=630, top=100, left=30, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=n o, status=no');
    winOpen.focus();
}
/*
開啟排班選擇視窗
*/
function openSch(field, user_id, user_name) {
    var user_id = document.getElementById("MasterPage$ContentPlaceHolder1$user_id");
    var user_name = encodeURI(document.getElementById("MasterPage$ContentPlaceHolder1$user_name").value);   
    var src = "../Public/Selectshift.aspx?FIELD=" + field + "&user_id=" + user_id.value + "&user_name=" + user_name;
    var winOpen = window.open(src, 'Selectshift', 'height=620, width=430, top=100, left=30, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=n o, status=no');
    winOpen.focus();
}
/*
開啟排休選擇視窗
*/
function openOffSch(field, user_id, user_name) {
    //var src = "../Public/SelectUser.aspx?id=user_id1&name=user_name1";
    var user_id = document.getElementById("MasterPage$ContentPlaceHolder1$user_id");
    var user_name = encodeURI(document.getElementById("MasterPage$ContentPlaceHolder1$user_name").value);
    var src = "../Public/Selectshift2.aspx?FIELD=" + field + "&user_id=" + user_id.value + "&user_name=" + user_name;
    var winOpen = window.open(src, 'Selectshift2', 'height=620, width=430, top=100, left=30, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=n o, status=no');
    winOpen.focus();
}

