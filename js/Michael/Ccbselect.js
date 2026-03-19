$(function () {
    ChkAllSelctFunc(); //點一個ccb全選其他
    elChkAllFunc(); // 如果元素一個 ccb 沒選到，全選鈕false
});

function ChkAllSelctFunc() {

    $("#chkAllCar").click(function () {
        var chkCar = $(this).prop("checked");
        if (!chkCar) {
            $(this).parent().parent().eq(0).find("tbody").find("[type='checkbox']").prop("checked", false);
        }
        else {
            $(this).parent().parent().eq(0).find("tbody").find("[type='checkbox']").prop("checked", true);
        }
    });

    $("#chkAllunit").click(function () {
        var chkunit = $(this).prop("checked");
        if (!chkunit) {
            $(this).parent().parent().eq(0).find("tbody").find("[type='checkbox']").prop("checked", false);
        }
        else {
            $(this).parent().parent().eq(0).find("tbody").find("[type='checkbox']").prop("checked", true);
        }
    });

    $("#chkAllMachine").click(function () {
        var chkMachine = $(this).prop("checked");
        if (!chkMachine) {
            $(this).parent().parent().eq(0).find("tbody").find("[type='checkbox']").prop("checked", false);
        }
        else {
            $(this).parent().parent().eq(0).find("tbody").find("[type='checkbox']").prop("checked", true);
        }
    });
    //wenny
    $("#chkAllcrs").click(function () {
        var chkcrs = $(this).prop("checked");
        if (!chkcrs) {
            $(this).parent().parent().eq(0).find("tbody").find("[type='checkbox']").prop("checked", false);
        }
        else {
            $(this).parent().parent().eq(0).find("tbody").find("[type='checkbox']").prop("checked", true);
        }
    });
}

function elChkAllFunc() {

    var CarAll = $("#chkAllCar").parent().parent().eq(0).find("tbody").find("[type='checkbox']");
    $.each(CarAll, function (i, data) {
        $("#chkAllCar").parent().parent().eq(0).find("tbody").find("[type='checkbox']").eq(i)
            .click(function () {
                var elCar = $(this).prop("checked");
                if (!elCar) {
                    $("#chkAllCar").prop("checked", false);
                }
            });
    });

    var unitAll = $("#chkAllunit").parent().parent().eq(0).find("tbody").find("[type='checkbox']");
    $.each(unitAll, function (i, data) {
        $("#chkAllunit").parent().parent().eq(0).find("tbody").find("[type='checkbox']").eq(i)
            .click(function () {
                var elCar = $(this).prop("checked");
                if (!elCar) {
                    $("#chkAllunit").prop("checked", false);
                }
            });
    });

    var machineAll = $("#chkAllMachine").parent().parent().eq(0).find("tbody").find("[type='checkbox']");
    $.each(machineAll, function (i, data) {
        $("#chkAllMachine").parent().parent().eq(0).find("tbody").find("[type='checkbox']").eq(i)
            .click(function () {
                var elCar = $(this).prop("checked");
                if (!elCar) {
                    $("#chkAllMachine").prop("checked", false);
                }
            });
    });
    //wenny
    var crsAll = $("#chkAllcrs").parent().parent().eq(0).find("tbody").find("[type='checkbox']");
    $.each(crsAll, function (i, data) {
        $("#chkAllcrs").parent().parent().eq(0).find("tbody").find("[type='checkbox']").eq(i)
            .click(function () {
                var elCar = $(this).prop("checked");
                if (!elCar) {
                    $("#chkAllcrs").prop("checked", false);
                }
            });
    });

}