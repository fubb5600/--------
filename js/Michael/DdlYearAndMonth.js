$(function () {
    DdlEventFunc();
    DdlHHmm();
});

function DdlEventFunc() {
    $("#ddlreport_y").change(function () {
        var T = $("#ddlreport_y [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_report_y").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_report_y").val(T);
        }
    });
    $("#ddlreport_m").change(function () {
        var T = $("#ddlreport_m [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_report_m").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_report_m").val(T);
        }
    });

    $("#ddlreport_y").append("<option value='0' selected='selected'>請選擇...</option>");
    $("#ddlreport_m").append("<option value='0' selected='selected'>請選擇...</option>");

    var today = new Date();
    var year = today.getFullYear() - 1911;
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
            $("#MasterPage_ContentPlaceHolder1_report_y2").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_report_y2").val(T);
        }
    });
    $("#ddlreport_m2").change(function () {
        var T = $("#ddlreport_m2 [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_report_m2").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_report_m2").val(T);
        }
    });

    $("#ddlreport_y2").append("<option value='0' selected='selected'>請選擇...</option>");
    $("#ddlreport_m2").append("<option value='0' selected='selected'>請選擇...</option>");

    for (var i = 0; i < 10; i++) {
        $("#ddlreport_y2").append("<option value='" + (i + 1) + "'>" + (year - i) + "</option>");
    }
    for (var i = 1; i < 13; i++) {
        $("#ddlreport_m2").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }
}

function DdlHHmm() {

    // 開始時間
    $("#startHHddl").change(function () {
        var T = $("#startHHddl [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_start_HH").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_start_HH").val(T);
        }
    });

    $("#startmmddl").change(function () {
        var T = $("#startmmddl [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_start_mm").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_start_mm").val(T);
        }
    });

    $("#startHHddl").append("<option value='0' selected='selected'>請選擇...</option>");
    $("#startmmddl").append("<option value='0' selected='selected'>請選擇...</option>");

    for (var i = 0; i < 24  ; i++) {
        $("#startHHddl").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }

    for (var i = 0; i < 60 ; i++) {
        $("#startmmddl").append("<option value='"+(i + 1)+"'>"+i+"</option>");
    }

    // 結束時間

    $("#endHHDdl").change(function () {
        var T = $("#endHHDdl [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_end_HH").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_end_HH").val(T);
        }
    });

    $("#endmmDdl").change(function () {
        var T = $("#endmmDdl [value='" + $(this).val() + "']").text()
        if (T == "請選擇...") {
            $("#MasterPage_ContentPlaceHolder1_end_mm").val("");
        }
        else {
            $("#MasterPage_ContentPlaceHolder1_end_mm").val(T);
        }
    });

    $("#endHHDdl").append("<option value='0' selected='selected'>請選擇...</option>");
    $("#endmmDdl").append("<option value='0' selected='selected'>請選擇...</option>");

    for (var i = 0; i < 24; i++) {
        $("#endHHDdl").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }

    for (var i = 0; i < 60; i++) {
        $("#endmmDdl").append("<option value='" + (i + 1) + "'>" + i + "</option>");
    }
}
