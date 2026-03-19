/*
id="required" = 必填
id="number"  = 數字
id="number_#"  = 數字，且小數不得超過#位
id="integer" = 整數
id="idcheck" = 身份證驗証id="time" = 時間HHMM
id="time_half" = 時間HHMM，且分只能為00or30
id="time_hour" = 時間HHMM，且分只能為00

id="daterange_#" =日期區間 #為第1 or 2日期
id="leagth_#" =字數  #為字數
id="date" =驗證日期格式
id="month" = 驗證月id="percent" =百分比，限定在0~100%之間

id="datevalid_#" =日期時間2是否大於1 #為第1 or 2日期
*/
var doublecheck = false;
var showmsg = "";

function doValidate(){

    //設定form
    var col = document.getElementById("aspnetForm");  
    
    var flag = true;
    var field_id = "";
    var field_alt = "";
    var field_validate = "";

    var field_list_checkbox = new Array();
    var nextCheckbox = "0";

    var field_list = new Array();

    for (var i = 0; i < col.length; i++) {

        var field_type = col.item(i).type;
        field_id = col.item(i).id;
        field_alt = col.item(i).alt;
        field_validate = getValidateType(col.item(i).className);

        if (field_alt=="") {
            field_alt = getAlt(col.item(i).className);
        }

        if (field_id != "" && field_validate!="") {

            if (col.item(i).type == "checkbox" && col.item(i).checked == true) {
                // checked==true
                field_list_checkbox = field_validate.split("-");
                nextCheckbox = field_list_checkbox[1];
                field_list = "";
                // alert(field_list_checkbox[0]+" , "+field_list_checkbox[1]);
            }
            else if (col.item(i).type == "checkbox" && col.item(i).checked == false) {
                nextCheckbox = "";
            }
            else {
                field_list = field_validate.split("+");
                nextCheckbox = "0";
            } //end else


            for (var j = 0; j < field_list.length; j++) {
                // alert("field_list="+field_list[0]+" "+field_list[1]);
                //alert(nextCheckbox);
                if (nextCheckbox != "") {
                    //if(field_list != ""){
                    //  alert("field_list="+field_list[j]+"="+ field_id);
                    // }//end if
                    if (field_list[j].indexOf("daterange") != -1) {

                        if (field_list[j].indexOf("_1") != -1) {
                            var date1_id = field_id;
                        }
                        if (field_list[j].indexOf("_2") != -1) {
                            var date2_id = field_id;
                        }

                        field_list[j] = "daterange";
                    }


                    //id="datevalid_#" =日期時間2是否大於1 #為第1 or 2日期 written by william
                    if (field_list[j].indexOf("datevalid") != -1) {

                        if (field_list[j].indexOf("_1") != -1) {
                            var date1 = field_id;
                            var alt1 = field_alt;
                        }
                        if (field_list[j].indexOf("_2") != -1) {
                            var date2 = field_id;
                            var alt2 = field_alt;
                            field_list[j] = "datevalid";
                        }

                    }

                    if (field_list[j].indexOf("length") != -1) {
                        var field_length = field_list[j].substring(7);
                        field_list[j] = "length"
                    }

                    if (field_list[j].indexOf("number_") != -1) {
                        var decimal_length = field_list[j].substring(7);
                        field_list[j] = "number_"
                    }


                    switch (field_list[j]) {

                        case 'required':   //必填欄位
                            flag = task_required(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'integer':    //須為整數
                            flag = task_integer(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'number':    //須為數字
                            flag = task_number(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;                     
                        case 'number_':  //須為數字，且小數不得超過?位
                            flag = task_number(field_id, field_alt, decimal_length);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'plus':    //須為正整數
                            flag = task_plus(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'percent':  //百分比，限定在0~100%之間
                            flag = task_percent(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'idcheck':    //身分證字號檢查
                            flag = task_idcheck(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'daterange':   //日間區間
                            flag = task_daterange(date1_id, date2_id);
                            if (flag == false) {
                                document.getElementById(date1_id).focus();
                                return flag;
                            }
                            break;
                        case 'length':   //字數
                            flag = task_length(field_id, field_alt, field_length);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'date':
                            flag = task_date(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'month':
                            flag = task_month(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'datevalid':
                            flag = task_datevalid(date1, date2, alt1, alt2);
                            if (flag == false)
                                return flag;
                            break;
                        case 'time':
                            flag = task_time(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'time_half':
                            flag = task_time_half(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;
                        case 'time_hour':
                            flag = task_time_hour(field_id, field_alt);
                            if (flag == false) {
                                document.getElementById(field_id).focus();
                                return flag;
                            }
                            break;                            
                    } //end switch
                } //end if( nextCheckbox != "")
            } //end for (var j=0 ;j<field_list.length;j++)
        }
    }
    return flag;
}

function getValidateType(field_css) {
    var validateType = "";
    var str = field_css.toString().indexOf('{');
    var end = field_css.toString().indexOf('}');
    if(str>-1 && end >-1){
        validateType = field_css.toString().substring(str + 1, end);
    }    
    return validateType;
}

function getAlt(field_css) {
    var validateType = "";
    var str = field_css.toString().indexOf('[');
    var end = field_css.toString().indexOf(']');
    if (str > -1 && end > -1) {
        validateType = field_css.toString().substring(str + 1, end);
    }
    return validateType;
}

function task_required(field_id, field_alt) {    
    var flag = true;
    //判斷欄位是否為空值(can't use (document.form1.all(field_name).value=NULL))
    if (document.getElementById(field_id).value == "") {
        flag = false;
        alert(field_alt + " 為必填");
        return flag;
    } //end if
    return flag;
} //end function


function task_datevalid(date1, date2, alt1, alt2) {
    var flag = false;
    if (document.getElementById(date1).value > document.getElementById(date2).value) {
        alert(alt1 + "'" + document.getElementById(date1).value + "' 不可大於 " + alt2 + "'" + document.getElementById(date2).value + "'");
    } else {
        flag = true;
    }
    return flag;
}


//id=number 欄為需為為數字
function task_number(field_id, field_alt) {
    var flag = true;
    //判斷欄位是否為空值(can't use NULL)
    if (isNaN(document.getElementById(field_id).value)) {
        flag = false;
        alert(field_alt + " 須為數字");
        return flag;
    } //end if
    return flag;
} //end function


//id=number2 欄為需為為數字，且小數不得超過兩位
function task_number(field_id, field_alt, decimal_length) {
    var flag = true;
    var value = document.getElementById(field_id).value;

    if (isNaN(value)) {

        flag = false;
        alert(field_alt + " 須為數字");

    } else if (value.indexOf('.') != -1) {
        if (value.indexOf('.') < value.length - decimal_length - 1 || value.indexOf('.') == value.length - 1) {
            if (decimal_length == 0) {
                alert(field_alt + " 須為整數");
            } else {
                alert(field_alt + " 小數不得超" + decimal_length + "位");
            }
            flag = false;
        }
    }

    return flag;
} //end function


//id=required 欄位必須為整數
function task_integer(field_id, field_alt) {
    var flag = true;
    if (document.getElementById(field_id).value == "") {
        return flag;
    }
    //mask 比照string裡是否有0-9以外的字元存在
    var anum = /^\d+$/;
    //判斷欄位是否為空值(can't use (document.form1.all(field_name).value=NULL))
    if (!anum.test(document.getElementById(field_id).value)) {
        flag = false;
        alert(field_alt + " 須為整數");
        return flag;
    } //end if
    return flag;
} //end function



//id=idcheck 檢驗欄位是否為標準的身分證字號
function task_idcheck(field_id, field_alt) {
    var code = new Array(10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33);
    var n = new Array();
    var flag = true;
    var id = document.getElementById(field_id).value;

    if (document.getElementById(field_id).value == "") {
        return flag;
    }

    if (id.charCodeAt(0) >= 97 && id.charCodeAt(0) <= 122)
        n[0] = code[(id.charCodeAt(0) - 97)];
    if (id.charCodeAt(0) >= 65 && id.charCodeAt(0) <= 90)
        n[0] = code[(id.charCodeAt(0) - 65)];

    for (i = 1; i < 10; i++) {
        if (id.charCodeAt(i) >= 48 && id.charCodeAt(i) <= 57)
            n[i] = id.charCodeAt(i) - 48;
    }

    if (((n[0] - (n[0] % 10)) / 10 + 9 * (n[0] % 10) + 8 * n[1] + 7 * n[2] + 6 * n[3] + 5 * n[4] + 4 * n[5] + 3 * n[6] + 2 * n[7] + n[8] + n[9]) % 10 == 0)
        return flag;
    else {
        flag = false;
        alert(field_alt + " 不正確");
        return flag;
    } //end if
    return flag;
} //end function


//id=daterange 日期區間
function task_daterange(date1, date2) {
    var flag = true;
    if (document.getElementById(date1).value > document.getElementById(date2).value) {
        var tmp = document.getElementById(date1).value;
        document.getElementById(date1).value = document.getElementById(date2).value;
        document.getElementById(date2).value = tmp;
        return flag;
    }
    return flag;
}


//id=length 字數
function task_length(field_id, field_alt, field_length) {
    //alert(field_alt+field_length);
    var flag = true;

    if (document.getElementById(field_id).value.length == field_length) {

        return flag;
    }
    else {
        flag = false;
        alert(field_alt + " 需為 " + field_length + " 個字元");
        return flag;
    }
}

//id=time 時間
function task_time(field_id, field_alt) {
    var flag = true;
    var time = document.getElementById(field_id).value;
    var hh = 0;
    var mi = 0;

    //正規表示法

    var timeformate = /^[0-9]*$/;

    var msg = '';
    if (time != '') {
        if (timeformate.test(time) && time.length == 4) {
            hh = parseInt(time.substr(0, 2));
            mi = parseInt(time.substr(2, 2));

            if (hh < 0 || hh > 24) {
                flag = false;

                msg = msg + '時';
            }
            else if (hh == 24) {
                if (mi != 0) {
                    flag = false;

                    msg = msg + '分';
                }
            }
            else {
                if (mi < 0 || mi >= 60) {
                    flag = false;

                    msg = msg + '分';
                }
            }

            if (flag == false) {
                alert(field_alt + ":" + msg + " 輸入錯誤");
            }
        }
        else {
            alert(field_alt + "：時間格式應為HHMM");
            flag = false;
        }
    }

    return flag;
}

//id=time_half 時間
function task_time_half(field_id, field_alt) {
    var flag = task_time(field_id, field_alt);
    var time = document.getElementById(field_id).value;
    
    if(flag && time != ""){
        time = time.substr(2, 2);
        if(time!="00" && time!="30"){
            flag = false;
            alert(field_alt + "：時間僅能輸入整點或半點，例：1200或1230");
        }
    }
                
    return flag;
}
//id=time_hour 時間
function task_time_hour (field_id, field_alt) {
    var flag = task_time(field_id, field_alt);
    var time = document.getElementById(field_id).value;

    if (flag && time != "") {
        time = time.substr(2, 2);
        if (time != "00") {
            flag = false;
            alert(field_alt + "：時間僅能輸入整點，例：1200或0300");
        }
    }

    return flag;
}

//id=plus 欄位需為正數
function task_plus(field_id, field_alt) {
   
    var flag = true;
    var a = "";
    var b = "";
    //判斷欄位是否為空值(can't use NULL)
    var length = document.getElementById(field_id).value.toString().length;
    for (i = 0; i < length; i++) {
        a = document.getElementById(field_id).value.toString().substring(i, i + 1);

        //判斷欄位是否有0-9
        if (!isNaN(a) || a == "-") {
            b = b + a;
        }
    }
  
    if (parseInt(b, 10) < 0) {
        flag = false;
        alert(field_alt + " 須為正整數");
        return flag;
    } //end if
    return flag;
} //end function


//id=percent 欄位需為正數
function task_percent(field_id, field_alt) {
    var flag = true;
    var per_value = parseInt(document.getElementById(field_id).value.replace("%", ""), 10);
    if (per_value < 0 || per_value > 100) {
        flag = false;
        alert(field_alt + " 須為0~100%之間");
        return flag;
    } //end if
    return flag;
} //end function

//------------------------------------------------------------------------------
/* ** chkWestDate檢核西元日期*//*  參數    str:欲檢核的日期字串
            mid:為日期格式的符號，若不需要則輸入空字串''，若傳'C'則以中文-年月日為format
    傳回值 日期錯誤時傳回空字串''
           若檢核完成傳回正確格式民國日期


    範例： chkWestDate(20000101,'/')    return  2000/01/01
           chkWestDate(20000101,'-')    return  2000-01-01
           chkWestDate(20000101,'C')    return  2000年01月01日

           chkWestDate(20000101,'')     return  20000101
           chkWestDate(20000133,'/')    return  ''
 */
function chkWestDate(str, mid) {
    var SourceDate = str;
    var temp = "";
    var str = "";
    var yyyy = "", mm = "", dd = "";
    if (SourceDate != "") {
        if (SourceDate.length < 8)
            return '';
        if (SourceDate.match('/')) {
            slcount = 0;
            for (i = 0; i < SourceDate.length; i++) {
                temp = SourceDate.substr(i, 1);
                if (temp == '/') {
                    slcount = slcount + 1;
                } else {
                    if (slcount == 0)
                        yyyy = yyyy + temp;
                    if (slcount == 1)
                        mm = mm + temp;
                    if (slcount == 2)
                        dd = dd + temp;
                }
            }
            if (slcount > 2)
                return '';
        } else {
            yyyy = SourceDate.substring(0, (SourceDate.length - 4));
            mm = SourceDate.substring((SourceDate.length - 4), (SourceDate.length - 2));
            dd = SourceDate.substring((SourceDate.length - 2), SourceDate.length);
        }
        if (((mm - 0) > 12) || ((mm - 0) < 1))
            return '';
        if ((dd - 0) < 1)
            return '';
        if ((((mm - 0) == 1) || ((mm - 0) == 3) || ((mm - 0) == 5) || ((mm - 0) == 7) || ((mm - 0) == 8) || ((mm - 0) == 10) || ((mm - 0) == 12)) && ((dd - 0) > 31))
            return '';
        if ((((mm - 0) == 4) || ((mm - 0) == 6) || ((mm - 0) == 9) || ((mm - 0) == 11)) && ((dd - 0) > 30))
            return '';
        if ((mm - 0) == 2) {
            if (((yyyy - 0) % 4) == 0) {
                if ((dd - 0) > 29)
                    return '';
            } else {
                if ((dd - 0) > 28)
                    return '';
            }
        }
        myDate = new Date(parseFloat(yyyy), mm, dd);
        if (myDate != null) {
            for (i = 1; yyyy.length < 4; i++)
                yyyy = '0' + yyyy;
            for (i = 1; mm.length < 2; i++)
                mm = '0' + mm;
            for (i = 1; dd.length < 2; i++)
                dd = '0' + dd;
            if (mid == 'C') {
                str = yyyy + '年' + mm + '月' + dd + '日';
            } else {
                str = yyyy + mid + mm + mid + dd;
            }
            return str;
        } else
            return '';
    } else
        return '';
}

function task_date2(field_id, field_alt) {
    var flag = true;
    var value = document.getElementById(field_id).value;
    if (value == "")
        return true;
    var objvalue = chkWestDate(value, '');
    var intdate = chkIntDate(value);
    if (objvalue == '' || intdate == '') {
        flag = false
        alert(field_alt + '：日期格式應為YYYYMMDD');
        return flag;
    }
    return flag;
}

function task_date(field_id, field_alt) {
    var flag = true;
    var value = document.getElementById(field_id).value;

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

    //初始設定
    var dLen = dateTag.length;
    var strFormat = "";
    if (dateFormat == 4) {
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
        alert(field_alt + '：日期格式應為' + strFormat);
        return flag;
    }

    //從字串取得年、月、日
    var yyyy = "", mm = "", dd = "";
    if (dateTag == '') {
        if (dateFormat == 4) {
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

        if (dateFormat == 4) {
            //民國年，年、月、日長度不符3、2、2
            if (yyyy.length != 3 || mm.length != 2 || dd.length != 2) {
                flag = false
                alert(field_alt + '：日期格式應為' + strFormat);
                return flag;
            }
        }
        else {
            //西元年，年、月、日長度不符4、2、2
            if (yyyy.length != 4 || mm.length != 2 || dd.length != 2) {
                flag = false
                alert(field_alt + '：日期格式應為' + strFormat);
                return flag;
            }
        }
    }

    //驗證實際輸入是否正確
    if (((mm - 0) > 12) || ((mm - 0) < 1)) {
        flag = false
        alert(field_alt + '：日期格式應為' + strFormat);
        return flag;
    }
    if ((dd - 0) < 1) {
        flag = false
        alert(field_alt + '：日期格式應為' + strFormat);
        return flag;
    }
    if ((((mm - 0) == 1) || ((mm - 0) == 3) || ((mm - 0) == 5) || ((mm - 0) == 7) || ((mm - 0) == 8) || ((mm - 0) == 10) || ((mm - 0) == 12)) && ((dd - 0) > 31)) {
        flag = false
        alert(field_alt + '：日期格式應為' + strFormat);
        return flag;
    }
    if ((((mm - 0) == 4) || ((mm - 0) == 6) || ((mm - 0) == 9) || ((mm - 0) == 11)) && ((dd - 0) > 30)) {
        flag = false
        alert(field_alt + '：日期格式應為' + strFormat);
        return flag;
    }
    if ((mm - 0) == 2) {
        if (((yyyy - 0) % 4) == 0) {
            if ((dd - 0) > 29) {
                flag = false
                alert(field_alt + '：日期格式應為' + strFormat);
                return flag;
            }
        } else {
            if ((dd - 0) > 28) {
                flag = false
                alert(field_alt + '：日期格式應為' + strFormat);
                return flag;
            }
        }
    }

    return flag;
}

function task_month(field_id, field_alt) {
    var flag = false;
    var month = document.getElementById(field_id).value;

    if (!isNaN(month)) {
        var str = '' + month;
        if (str.length == 1) {
            str = '0' + str;
        }

        if (str <= '12' & str >= '01') {
            flag = true;
        }
    }

    if (!flag) {
        alert(field_alt + " 需為1至12的數字!");
    }
    return flag;
}

//日期欄位必須為整數 by Stan 20060911
function chkIntDate(str) {
    var str;
    //檢查string裡是否有0-9以外的字元存在

    var anum = /^\d+$/;
    if (!anum.test(str)) {
        return '';
    }
}

function choice() {
    flag = true;
    return flag;
}

function check_pw() {
    flag = true;
    return flag;
}

function check_oldpw() {
    flag = true;
    return flag;
}



       