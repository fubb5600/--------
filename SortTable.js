$(document).ready(function () {
    $('table.SortTable').each(function () {
        var $table = $(this);
        $('th', $table).each(function (column) {
            if ($(this).is('.SortColumn')) {
                $(this).click(function () {

                    var sColumnTitile;
                    switch (column) {
                        case 0:
                            sColumnTitile = 'source_name';
                            break;
                        case 1:
                            sColumnTitile = '序號';
                            break;
                        case 2:
                            sColumnTitile = '匯入序號';
                            break;
                        case 3:
                            sColumnTitile = '報表年月';
                            break;
                        case 4:
                            sColumnTitile = '折讓金額';
                            break;
                        case 5:
                            sColumnTitile = '匯入時間';
                            break;
                        case 6:
                            sColumnTitile = '匯入人員';
                            break;
                        case 7:
                            sColumnTitile = '匯入筆數';
                            break;
                        case 8:
                            sColumnTitile = '備註';
                            break;
                    }

                    var bSort = ($(this).html().indexOf('↑') > -1);
                    if (bSort)
                        $(this).html(sColumnTitile + '&darr;');
                    else
                        $(this).html(sColumnTitile + '&uarr;');
                    var rows = $table.find('tbody > tr').get();
                    rows.sort(function (a, b) {
                        var keyA = $(a).children('td').eq(column).text().toUpperCase();
                        var keyB = $(b).children('td').eq(column).text().toUpperCase();
                        if (bSort) {
                            if (keyA > keyB) return 1;
                            if (keyA < keyB) return -1;
                        }
                        else {
                            if (keyA < keyB) return 1;
                            if (keyA > keyB) return -1;
                        }
                        return 0;
                    });
                    $.each(rows, function (index, row) {
                        $table.children('tbody').append(row);
                    })
                });
            };
        });
    });
});