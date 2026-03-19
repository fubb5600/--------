$(function () {
    ChkAllSelctFunc(); //點一個ccb全選其他
    elChkAllFunc(); // 如果元素一個 ccb 沒選到，全選鈕false
});

function ChkAllSelctFunc() {


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