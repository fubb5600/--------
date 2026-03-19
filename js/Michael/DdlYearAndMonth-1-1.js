
$(function () {
    DdlEventFunc();
    DdlNoValue();

   
});

function DdlEventFunc() {
    $("#ddlreport_y").change(function () {
        var T = $("#ddlreport_y [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_report_y").val("");//在IIS執行會出錯,因為ID的關係
            //$("document.getElementById('<%=report_y.ClientID%>'").val("");//在IIS執行會出錯,因為ID的關係
            //$("#PlaceHolder1_report_y").val("");//在MVS執行會出錯,因為ID的關係
             }
        else {
            //$("#ContentPlaceHolder1_report_y").val(T);
            //$("document.getElementById('<%= report_y.ClientID%>'").val(T);
            $("#MasterPage_ContentPlaceHolder1_report_y").val(T);
        }
    });
    $("#ddlreport_m").change(function () {
        var T = $("#ddlreport_m [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_report_m").val("");
            //$("#ContentPlaceHolder1_report_m").val("");

        }
        else {
            //$("#ContentPlaceHolder1_report_m").val(T);
            $("#MasterPage_ContentPlaceHolder1_report_m").val(T);
        }
    });

    //$("#ddlreport_y").append("<option value='0' selected='selected'>請選擇...</option>");
    //$("#ddlreport_m").append("<option value='0' selected='selected'>請選擇...</option>");

    $("#ddlreport_y").append("<option value='0' >請選擇...</option>");
    $("#ddlreport_m").append("<option value='0' >請選擇...</option>");

    var today = new Date();
    var year = today.getFullYear() - 1911;
    var month = today.getMonth() + 1; 
    for (var i = 0; i < 10; i++) {
        $("#ddlreport_y").append("<option value='" + (i + 1) + "'>" + (year - i) + "</option>");
    }
    
    for (var i = 1; i < 13; i++) {
        $("#ddlreport_m").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }


    //第二類時間 : 特定幾個才用到

    $("#ddlreport_y2").change(function () {
        var T = $("#ddlreport_y2 [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            //$("#ContentPlaceHolder1_report_y2").val("");
            $("#MasterPage_ContentPlaceHolder1_report_y2").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_report_y2").val(T);
            //$("#ContentPlaceHolder1_report_y2").val(T);
        }
    });
    $("#ddlreport_m2").change(function () {
        var T = $("#ddlreport_m2 [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            //$("#ContentPlaceHolder1_report_m2").val("");
            $("#MasterPage_ContentPlaceHolder1_report_m2").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_report_m2").val(T);
            //$("#ContentPlaceHolder1_report_m2").val(T);
        }
    });

    $("#ddlreport_y2").append("<option value='0' >請選擇...</option>");
    $("#ddlreport_m2").append("<option value='0' select='selected' >請選擇...</option>");

    for (var i = 0; i < 10; i++) {
        $("#ddlreport_y2").append("<option value='" + (i + 1) + "'>" + (year - i) + "</option>");
    }

    for (var i = 1; i < 13; i++) {
        $("#ddlreport_m2").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }

    $("#PlaceHolder1_report_y").val(year);
    $('select#ddlreport_y')[0].selectedIndex = 1;
}

function DdlHHmm() {

    // 開始時間
    $("#startHHddl").change(function () {
        var T = $("#startHHddl [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            //$("#ContentPlaceHolder1_start_HH").val("");
            $(document.getElementById('<%=start_HH.ClientID%>')).val("");
            $("#MasterPage_ContentPlaceHolder1_start_HH").val("");
        }
        else {
            //$("#ContentPlaceHolder1_start_HH").val(T);
            $("#MasterPage_ContentPlaceHolder1_start_HH").val(T);
        }
    });

    $("#startmmddl").change(function () {
        var T = $("#startmmddl [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            //$("#ContentPlaceHolder1_start_mm").val("");
            $("#MasterPage_ContentPlaceHolder1_start_mm").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_start_mm").val(T);
            //$("#ContentPlaceHolder1_start_mm").val(T);
        }
    });

    $("#startHHddl").append("<option value='0' >請選擇...</option>");
    $("#startmmddl").append("<option value='0' >請選擇...</option>");

    for (var i = 0; i < 24; i++) {
        $("#startHHddl").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }

    for (var i = 0; i < 60; i++) {
        $("#startmmddl").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }

    // 結束時間

    $("#endHHDdl").change(function () {
        var T = $("#endHHDdl [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            //$("#ContentPlaceHolder1_end_HH").val("");
            $("#MasterPage_ContentPlaceHolder1_end_HH").val("");

        }
        else {
            //$("#ContentPlaceHolder1_end_HH").val(T);
            $("#MasterPage_ContentPlaceHolder1_end_HH").val(T);
        }
    });

    $("#endmmDdl").change(function () {
        var T = $("#endmmDdl [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            //$("#ContentPlaceHolder1_end_mm").val("");
            $("#MasterPage_ContentPlaceHolder1_end_mm").val("");
        }
        else {
            //$("#ContentPlaceHolder1_end_mm").val(T);
            $("#MasterPage_ContentPlaceHolder1_end_mm").val(T);
        }
    });

    $("#endHHDdl").append("<option value='0' >請選擇...</option>");
    $("#endmmDdl").append("<option value='0'>請選擇...</option>");

    for (var i = 0; i < 24; i++) {
        $("#endHHDdl").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }

    for (var i = 0; i < 60; i++) {
        $("#endmmDdl").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }
}
function DdlNoValue() {
    var today = new Date();
    var year = today.getFullYear - 1911;
    var month = today.getMonth() + 1;
    var VY = document.getElementById('ddlreport_y').selectedIndex;
    if (VY == 0) {
        $('select#ddlreport_y')[0].selectedIndex = 1;
        $("#PlaceHolder1_report_y").val(year);
        //alert("必選");
        return false;
    }
    else {
        return true;
    }
   
    var VM = document.getElementById('ddlreport_m').selectedIndex;
    if (VM == 0) {
        //$('select#ddlreport_m')[0].selectedIndex = month;
    }
    var VY2 = document.getElementById('ddlreport_y2').selectedIndex;
    if (VY2 == 0) {
        //$('select#ddlreport_y2')[0].selectedIndex = 1;
    }
    var VM2 = document.getElementById('ddlreport_m2').selectedIndex;
    if (VM2 == 0) {
        //$('select#ddlreport_m2')[0].selectedIndex = month;
    }
   
}

