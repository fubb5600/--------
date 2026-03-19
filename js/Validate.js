//日期驗證
function Date_Validate(sender, e) {
    e.IsValid = task_date(e.Value);
}

//年月驗證
function YM_Validate(sender, e) {
    var value = e.Value;

    if (value != "") {
        value = value + "/01";
    }

    e.IsValid = task_date(value);
}

//西元年驗證
function ADYear_Validate(sender, e) {
    if (!isNaN(e.Value)) {
        var value = e.Value - 1911;

        if (value.toString() != "") {
            value = padLeft(value.toString(), 3) + "/01/01";
        }

        e.IsValid = task_date(value.toString());
    } else
        e.IsValid = false;
}

//民國年驗證
function CHYear_Validate(sender, e) {
    var value = e.Value;

    if (value != "") {
        value = value + "/01/01";
    }

    e.IsValid = task_date(value);
}

function task_date(value) {
    var flag = true;

    //空值不進行驗證
    if (value == "")
        return true;

    //取得日期格式
    var dateFormat = 3;
    if (document.getElementById("dateFormat") != null) {
        dateFormat = document.getElementById("dateFormat").value;
    }

    var dateTag = "/";
    if (document.getElementById("dateTag") != null) {
        dateTag = document.getElementById("dateTag").value;
    }

    if (value.length == 8) {
        value = "0" + value;
    }

    //初始設定
    var dLen = dateTag.length;
    var strFormat = "";
    if (dateFormat == 3) {
        dLen = dLen * 2 + 7;
        strFormat = "097" + dateTag + "01" + dateTag + "01";
    }
    else {
        dLen = dLen * 2 + 8;
        strFormat = "2008" + dateTag + "01" + dateTag + "01";
    }

    //長度不符
    if (value.length != dLen) {
        flag = false
        return flag;
    }

    //從字串取得年、月、日
    var yyyy = "", mm = "", dd = "";
    if (dateTag == '') {
        if (dateFormat == 3) {
            yyyy = SourceDate.substring(0, 3);
            mm = SourceDate.substring(3, 5);
            dd = SourceDate.substring(5, 7);
        }
        else {
            yyyy = SourceDate.substring(0, 4);
            mm = SourceDate.substring(4, 6);
            dd = SourceDate.substring(6, 8);
        }
    }
    else {
        var temp = value.split(dateTag);
        yyyy = temp[0];
        mm = temp[1];
        dd = temp[2];

        if (dateFormat == 3) {
            //民國年，年、月、日長度不符3、2、2
            if (yyyy.length != 3 || mm.length != 2 || dd.length != 2) {
                flag = false
                return flag;
            }
        }
        else {
            //西元年，年、月、日長度不符4、2、2
            if (yyyy.length != 4 || mm.length != 2 || dd.length != 2) {
                flag = false
                return flag;
            }
        }
    }

    if (dateFormat == 3) {
        yyyy = yyyy - 0 + 1911;
    }

    //驗證實際輸入是否正確
    if (((mm - 0) > 12) || ((mm - 0) < 1)) {
        flag = false
        return flag;
    }
    if ((dd - 0) < 1) {
        flag = false
        return flag;
    }
    if ((((mm - 0) == 1) || ((mm - 0) == 3) || ((mm - 0) == 5) || ((mm - 0) == 7) || ((mm - 0) == 8) || ((mm - 0) == 10) || ((mm - 0) == 12)) && ((dd - 0) > 31)) {
        flag = false
        return flag;
    }
    if ((((mm - 0) == 4) || ((mm - 0) == 6) || ((mm - 0) == 9) || ((mm - 0) == 11)) && ((dd - 0) > 30)) {
        flag = false
        return flag;
    }
    if ((mm - 0) == 2) {
        if (((yyyy - 0) % 4) == 0) {
            if ((dd - 0) > 29) {
                flag = false
                return flag;
            }
        } else {
            if ((dd - 0) > 28) {
                flag = false
                return flag;
            }
        }
    }

    return flag;
}

function padLeft(str, lenght) {
    if (str.length >= lenght)
        return str;
    else
        return padLeft("0" + str, lenght);
}
