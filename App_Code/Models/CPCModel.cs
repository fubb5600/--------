using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Security.Cryptography;

/// <summary>
/// CPCModel 的摘要描述
/// </summary>
public class CPCModel : Model
{
    //wenny_test_排序_


    //wenny_test_排序_
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        //加油匯入
        //正排
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        else if (pbKey.Equals("browse1r"))
        {
            browse1r(pb, form);
        }
        else if (pbKey.Equals("browse1dc"))
        {
            browse1dc(pb, form);
        }
        else if (pbKey.Equals("browse1s"))
        {
            browse1s(pb, form);
        }
        else if (pbKey.Equals("browse1impd"))
        {
            browse1impd(pb, form);
        }
        else if (pbKey.Equals("browse1impu"))
        {
            browse1impu(pb, form);
        }
        else if (pbKey.Equals("browse1c"))
        {
            browse1c(pb, form);
        }
        else if (pbKey.Equals("browse1m"))
        {
            browse1m(pb, form);
        }
        //反排
        else if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);
        }
        else if (pbKey.Equals("browse1rd"))
        {
            browse1rd(pb, form);
        }
        else if (pbKey.Equals("browse1dcd"))
        {
            browse1dcd(pb, form);
        }
        else if (pbKey.Equals("browse1sd"))
        {
            browse1sd(pb, form);
        }
        else if (pbKey.Equals("browse1impdd"))
        {
            browse1impdd(pb, form);
        }
        else if (pbKey.Equals("browse1impud"))
        {
            browse1impud(pb, form);
        }
        else if (pbKey.Equals("browse1cd"))
        {
            browse1cd(pb, form);
        }
        else if (pbKey.Equals("browse1md"))
        {
            browse1md(pb, form);
        }

        //加油資料管理
        //正排
        else if (pbKey.Equals("browse2"))
        {
            browse2(pb, form);
        }
        else if (pbKey.Equals("browse2s"))
        {
            browse2s(pb, form);
        }
        else if (pbKey.Equals("browse2impid"))
        {
            browse2impid(pb, form);
        }
        else if (pbKey.Equals("browse2mng"))
        {
            browse2mng(pb, form);
        }
        else if (pbKey.Equals("browse2cards"))
        {
            browse2cards(pb, form);
        }
        else if (pbKey.Equals("browse2deals"))
        {
            browse2deals(pb, form);
        }
        else if (pbKey.Equals("browse2stand"))
        {
            browse2stand(pb, form);
        }
        else if (pbKey.Equals("browse2fueln"))
        {
            browse2fueln(pb, form);
        }
        else if (pbKey.Equals("browse2c"))
        {
            browse2c(pb, form);
        }
        else if (pbKey.Equals("browse2fuela"))
        {
            browse2fuela(pb, form);
        }
        else if (pbKey.Equals("browse2cfm_status"))
        {
            browse2cfm_status(pb, form);
        }
        //反排
        else if (pbKey.Equals("browse2d"))
        {
            browse2d(pb, form);
        }
        else if (pbKey.Equals("browse2sd"))
        {
            browse2sd(pb, form);
        }
        else if (pbKey.Equals("browse2impidd"))
        {
            browse2impidd(pb, form);
        }
        else if (pbKey.Equals("browse2mngd"))
        {
            browse2mngd(pb, form);
        }
        else if (pbKey.Equals("browse2cardsd"))
        {
            browse2cardsd(pb, form);
        }
        else if (pbKey.Equals("browse2dealsd"))
        {
            browse2dealsd(pb, form);
        }
        else if (pbKey.Equals("browse2standd"))
        {
            browse2standd(pb, form);
        }
        else if (pbKey.Equals("browse2fuelnd"))
        {
            browse2fuelnd(pb, form);
        }
        else if (pbKey.Equals("browse2cd"))
        {
            browse2cd(pb, form);
        }
        else if (pbKey.Equals("browse2fuelad"))
        {
            browse2fuelad(pb, form);
        }
        else if (pbKey.Equals("browse2cfm_statusd"))
        {
            browse2cfm_statusd(pb, form);
        }

    }

    /// <summary>
    /// 加油資料匯入主檔資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    //正排
    private void browse(PageBreak pb, Form form)
    {
        //原程式碼start
        String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        #region //新增資料來源(data_source)、折讓(discount)
        //String sql = "select discount, f.id_name as source_name," +
        //    " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " + 
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId "+
        //     "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' "  ;
        #endregion
        //wenny_test_end

        String where = "where 1=1";
        //if (!form.getValue("data_source").Equals(""))
        //{
        //    where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        //}
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            //where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            //where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            //where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;



        pb.OrderSQL = "import_id";

        //pb.OrderSQL = "discount";
        //pb.OrderSQL = "source_name";
        //pb.OrderSQL = "report_ym";
        //pb.OrderSQL = "import_date";
        //pb.OrderSQL = "count";
        //pb.OrderSQL = "memo";
        //pb.OrderSQL = "import_user";
    }

    private void browse1r(PageBreak pb, Form form)
    {
        //原程式碼start
        String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        //String sql = "select discount, f.id_name as source_name," +
        //    " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
        //     "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;




        pb.OrderSQL = "report_ym";

    }
    private void browse1s(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "source_name";


    }
    private void browse1dc(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "discount";


    }
    private void browse1impd(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "import_date";


    }
    private void browse1impu(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "import_user";


    }
    private void browse1c(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "count";


    }
    private void browse1m(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "memo";


    }
    //反排
    private void browse1d(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;



        pb.OrderSQL = "import_id desc";

        //pb.OrderSQL = "discount";
        //pb.OrderSQL = "source_name";
        //pb.OrderSQL = "report_ym";
        //pb.OrderSQL = "import_date";
        //pb.OrderSQL = "count";
        //pb.OrderSQL = "memo";
        //pb.OrderSQL = "import_user";
    }
    private void browse1rd(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;

        pb.OrderSQL = "report_ym desc";

    }
    private void browse1sd(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "source_name desc";


    }
    private void browse1dcd(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "discount desc";


    }
    private void browse1impdd(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "import_date desc";


    }
    private void browse1impud(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "import_user desc";


    }
    private void browse1cd(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "count desc";


    }
    private void browse1md(PageBreak pb, Form form)
    {
        //原程式碼start
        //String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
        //    "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
        //    "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";
        //原程式碼end

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        String sql = "select discount, f.id_name as source_name," +
            " import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId " +
             "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' ";

        //wenny_test_end

        String where = "where 1=1";
        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }
        if (!form.getValue("report_y").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            where += " and SUBSTRING(report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            //where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            where += " and SUBSTRING(report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            //where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";

            where += " and convert(varchar(10) , import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }



        sql = sql + where;

        pb.CommandSQL = sql;


        pb.OrderSQL = "memo desc";


    }


    /// <summary>
    /// 加油資料管理明細檔資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    //正排
    private void browse2(PageBreak pb, Form form)
    { 
        String sql = "select  DISTINCT fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        where += " and a.mng_id in (" + handleMultiData("fuel_type", form.getValue("mng_id"), pb) + ")";
        pb.setParam("@mng_id", form.getValue("mng_id"));


        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "deal_date desc";


        //wenny_test_排序
        //pb.OrderSQL = "deal_date"  ;
        //wenny_test_排序
    }

    private void browse2s(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "data_source ";
    }
    private void browse2impid(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "import_id ";
    }
    private void browse2mng(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "mng_name ";
    }
    private void browse2cards(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no ";
    }
    private void browse2deals(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "deal_date ";
    }
    private void browse2stand(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "stand_name ";
    }
    private void browse2fueln(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_name ";
    }
    private void browse2c(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_count ";
    }
    private void browse2fuela(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_amount ";
    }
    private void browse2cfm_status(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "cfm_status ";
    }
    //反排
    private void browse2d(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "deal_date ";


        //wenny_test_排序
        //pb.OrderSQL = "deal_date"  ;
        //wenny_test_排序
    }
    private void browse2sd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "data_source desc ";
    }
    private void browse2impidd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "import_id desc ";
    }
    private void browse2mngd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "mng_name desc ";
    }
    private void browse2cardsd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no desc ";
    }
    private void browse2dealsd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "deal_date desc ";
    }
    private void browse2standd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "stand_name desc ";
    }
    private void browse2fuelnd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_name desc ";
    }
    private void browse2cd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_count desc ";
    }
    private void browse2fuelad(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_amount desc ";
    }
    private void browse2cfm_statusd(PageBreak pb, Form form)
    {
        String sql = "select fuel_id, b.id_name as mng_name, a.card_no, dbo.chineseDateTime(deal_date) as " +
            "deal_date, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source"), pb) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status"), pb) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status"), pb) + "))";
        }

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and substring(a.report_ym, 1, 3) = @report_y";
            pb.setParam("@report_y", form.getValue("report_y"));
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and substring(a.report_ym, 5, 2) = @report_m";
            pb.setParam("@report_m", form.getValue("report_m"));
        }

        if (!form.getValue("stand_name").Equals(""))
        {
            where += " and a.stand_name like @stand_name";
            pb.setParam("@stand_name", "%" + form.getValue("stand_name") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            pb.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            pb.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            pb.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            pb.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            pb.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("import_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  >= @import_start";
            pb.setParam("@import_start", DateTransfer.c_date_trans(form.getValue("import_start")));
        }

        if (!form.getValue("import_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.import_date, 111 )  <= @import_end";
            pb.setParam("@import_end", DateTransfer.c_date_trans(form.getValue("import_end")));
        }

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and a.import_id = @import_id";
            pb.setParam("@import_id", form.getValue("import_id"));
        }

        //if (!form.getValue("none_car").Equals(""))
        //{
        //    where += " and (a.car_no is null or a.car_no = '')";
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "cfm_status desc ";
    }





    /// <summary>
    /// 加油資料批次審核查詢
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    public DataSet browse3(Form form)
    {
        String sql = "select ROW_NUMBER() over (order by deal_date desc ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
            "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id " +
            "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;


        return dao.searchForDS();


    }
    //wenny_test_排序
    //正排
    public DataSet browse3source_name_s(Form form)
    {
        String sql = "select ROW_NUMBER() over (order by f.id_name ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
            "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id " +
            "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;


        return dao.searchForDS();


    }
    public DataSet browse3import_id_s(Form form)
    {
        String sql = "select ROW_NUMBER() over (order by import_id) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
            "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id " +
            "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3mng_name(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by b.id_name ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3card_type_name(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by h.id_name ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3card_no(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by a.card_no ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3deal_date(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by deal_date ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3stand_name(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by stand_name ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3fuel_name(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by c.id_name ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3fuel_count(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by fuel_count ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3fuel_amount(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by fuel_amount ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3cfm_status(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by cfm_status ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    //反排
    public DataSet browse3d(Form form)
    {
        String sql = "select ROW_NUMBER() over (order by deal_date  ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
            "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id " +
            "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;


        return dao.searchForDS();


    }
    public DataSet browse3source_name_sd(Form form)
    {
        String sql = "select ROW_NUMBER() over (order by f.id_name desc) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
            "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id " +
            "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;


        return dao.searchForDS();


    }
    public DataSet browse3import_id_sd(Form form)
    {
        String sql = "select ROW_NUMBER() over (order by import_id desc) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
            "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
            "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
            "from v_fuel a " +
            "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
            "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
            "on a.card_id = d.card_id " +
            "left join c_car_mst e on d.car_id = e.car_id " +
            "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
            "left join c_card_mst g on a.card_id = g.card_id " +
            "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3mng_named(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by b.id_name desc) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3card_type_named(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by h.id_name desc) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3card_nod(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by a.card_no desc ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3deal_dated(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by deal_date desc) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3stand_named(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by stand_name desc) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3fuel_named(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by c.id_name desc ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3fuel_countd(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by fuel_count desc ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3fuel_amountd(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by fuel_amount desc) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    public DataSet browse3cfm_statusd(Form form)
    {

        String sql = "select ROW_NUMBER() over (order by cfm_status desc ) as ROW_NUM, fuel_id, b.id_name as mng_name, a.card_no, " +
                "dbo.chineseDateTime(deal_date) as deal_date, h.id_name as card_type_name, import_id, import_date, stand_name, c.id_name as fuel_name, fuel_count, fuel_amount, " +
                "adt_status, cfm_status, e.car_no, data_source, f.id_name as source_name, g.card_type  " +
                "from v_fuel a " +
                "left join a_sysparam_data b on a.mng_id = b.param_id and b.param_type='DEP_ORG' " +
                "left join a_sysparam_data c on a.fuel_type = c.param_id and c.param_type='FUEL_TYPE' " +
                "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
                "where convert(varchar(10), possess_start, 111) <= GETDATE() " +
                "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= GETDATE())) d " +
                "on a.card_id = d.card_id " +
                "left join c_car_mst e on d.car_id = e.car_id " +
                "left join a_sysparam_data f on a.data_source = f.param_id and f.param_type='DATA_SOURCE' " +
                "left join c_card_mst g on a.card_id = g.card_id " +
                "left join a_sysparam_data h on g.card_type = h.param_id and h.param_type='CARD_TYPE' ";

        String where = "where 1=1";

        if (!form.getValue("data_source").Equals(""))
        {
            where += " and a.data_source in (" + handleMultiData("data_source", form.getValue("data_source")) + ")";
        }

        if (!form.getValue("cfm_status").Equals("") && form.getValue("adt_status").Equals(""))
        {
            where += " and a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && form.getValue("cfm_status").Equals(""))
        {
            where += " and a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + ")";
        }

        if (!form.getValue("adt_status").Equals("") && !form.getValue("cfm_status").Equals(""))
        {
            where += " and (a.cfm_status in (" + handleMultiData("cfm_status", form.getValue("cfm_status")) + ") or " +
                "a.adt_status in (" + handleMultiData("adt_status", form.getValue("adt_status")) + "))";
        }

        if (!form.getValue("deal_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  >= @deal_start";
            dao.setParam("@deal_start", DateTransfer.c_date_trans(form.getValue("deal_start")));
        }

        if (!form.getValue("deal_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.deal_date, 111 )  <= @deal_end";
            dao.setParam("@deal_end", DateTransfer.c_date_trans(form.getValue("deal_end")));
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and g.card_type = @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (!form.getValue("card_id").Equals(""))
        {
            where += " and a.card_id = @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and e.dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("mng_id").Equals(""))
        {
            where += " and a.mng_id = @mng_id";
            dao.setParam("@mng_id", form.getValue("mng_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and e.car_no = @car_no";
            dao.setParam("@car_no", form.getValue("car_no"));
        }

        sql = sql + where;
        dao.CommandSQL = sql;



        return dao.searchForDS();


    }
    //wenny_test_排序





    /// <summary>
    /// 新增匯入主檔
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertImportMst(Form form)
    {
        String sql = "insert into b_cpc_imp (import_date, import_user, report_ym, memo, create_date, " +
            "create_user, update_date, update_user,oil) " +
            "values (GETDATE(), @import_user, @report_ym, @memo, GETDATE(), @import_user, " +
            "GETDATE(), @import_user,@oil)";

        //wenny_test_start
        //新增資料來源(data_source)、折讓(discount)
        //String sql = "insert into b_cpc_imp (discount,data_source,import_date, import_user, report_ym, memo, create_date, " +
        //    "create_user, update_date, update_user) " +
        //    "values (@discount,@data_source,GETDATE(), @import_user, @report_ym, @memo, GETDATE(), @import_user, " +
        //    "GETDATE(), @import_user)";

        //wenny_test_end
        dao.CommandSQL = sql;
        //wenny_test_start
        //dao.setParam("@discount", form.getValue("discount"));
        //dao.setParam("@data_source", form.getValue("data_source"));
        //wenny_test_end
        dao.setParam("@import_user", form.getValue("import_user"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@oil", form.getValue("oil"));

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 新增匯入明細檔
    /// </summary>
    /// <param name="form"></param>
    public void insertImportDtl(Form form)
    {
        String sql = "insert into b_cpc_mst (seller_id, seller_name, custom_id, custom_name, biller_id, biller_name, " +
            "mng_id, mng_name, card_no, deal_date, stand_id, stand_name, fuel_name, fuel_count, fuel_amount, " +
            "memo1, memo2, import_id, report_ym, cfm_status, unit_price, cpc_class, create_date, create_user, " +
            "update_date, update_user,oil) " +
            "values (@seller_id, @seller_name, @custom_id, @custom_name, @biller_id, @biller_name, @mng_id, " +
            "@mng_name, @card_no, @deal_date, @stand_id, @stand_name, @fuel_name, @fuel_count, " +
            "@fuel_amount, @memo1, @memo2, @import_id, @report_ym, @cfm_status,  @unit_price, 'OIL', " +
            "GETDATE(), @create_user, GETDATE(), @create_user,@oil)";

        dao.CommandSQL = sql;
        dao.setParam("@seller_id", form.getValue("seller_id"));
        dao.setParam("@seller_name", form.getValue("seller_name"));
        dao.setParam("@custom_id", form.getValue("custom_id"));
        dao.setParam("@custom_name", form.getValue("custom_name"));
        dao.setParam("@biller_id", form.getValue("biller_id"));
        dao.setParam("@biller_name", form.getValue("biller_name"));
        dao.setParam("@mng_id", form.getValue("mng_id"));
        dao.setParam("@mng_name", form.getValue("mng_name"));
        dao.setParam("@card_no", form.getValue("card_no"));
        dao.setParam("@deal_date", form.getValue("deal_date"));
        dao.setParam("@stand_id", form.getValue("stand_id"));
        dao.setParam("@stand_name", form.getValue("stand_name"));
        dao.setParam("@fuel_name", form.getValue("fuel_name"));
        dao.setParam("@fuel_count", form.getValue("fuel_count"));
        dao.setParam("@fuel_amount", form.getValue("fuel_amount"));
        dao.setParam("@memo1", form.getValue("memo1"));
        dao.setParam("@memo2", form.getValue("memo2"));
        dao.setParam("@import_id", form.getValue("import_id"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@cfm_status", form.getValue("cfm_status"));
        dao.setParam("@create_user", form.getValue("create_user"));
        dao.setParam("@oil", form.getValue("oil"));

        if (form.getValue("unit_price") != string.Empty)
        {
            dao.setParam("@unit_price", form.getValue("unit_price"));
        }
        else
        {
            dao.setParam("@unit_price", DBNull.Value);
        }

        if (form.getValue("cpc_class") != string.Empty)
        {
            dao.setParam("@cpc_class", form.getValue("cpc_class"));
        }
        else
        {
            dao.setParam("@cpc_class", DBNull.Value);
        }

        dao.executeModify();
    }


    /// <summary>
    /// 新增加油資料
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertOilMst(Form form)
    {
        String sql = "insert into b_oil_mst (mng_id, card_no, deal_date, stand_name, fuel_type, fuel_name, " +
            "fuel_count, fuel_amount, report_ym, memo, adt_status, create_user, create_date, update_user, " +
            "update_date) " +
            "values (@mng_id, @card_no, @deal_date, @stand_name, @fuel_type, @fuel_name, @fuel_count, " +
            "@fuel_amount, @report_ym, @memo, @adt_status,  @create_user, GETDATE(), @create_user, " +
            "GETDATE())";

        dao.CommandSQL = sql;

        dao.setParam("@mng_id", form.getValue("mng_id"));
        dao.setParam("@card_no", form.getValue("card_no"));
        dao.setParam("@deal_date", form.getValue("deal_date"));
        dao.setParam("@stand_name", form.getValue("stand_name"));
        dao.setParam("@fuel_type", form.getValue("fuel_type"));
        dao.setParam("@fuel_name", form.getValue("fuel_name"));
        dao.setParam("@fuel_count", form.getValue("fuel_count"));
        dao.setParam("@fuel_amount", form.getValue("fuel_amount"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@adt_status", form.getValue("adt_status"));
        dao.setParam("@create_user", form.getValue("create_user"));

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 新增加油卡使用資料
    /// </summary>
    /// <param name="form"></param>
    public void insertFuelUse(Form form)
    {
        String sql = "insert into b_fuel_use (fuel_id, work_id, data_source, memo, create_date, create_user, " +
            "update_date, update_user) " +
            "values (@fuel_id, @work_id, @data_source, NULL, GETDATE(), @create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@fuel_id", form.getValue("fuel_id"));
        dao.setParam("@work_id", form.getValue("work_id"));
        dao.setParam("@data_source", form.getValue("data_source"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 查詢匯入明細檔
    /// </summary>
    /// <param name="fuel_id"></param>
    /// <returns></returns>
    public DataSet selectImportDtl(String fuel_id)
    {
        String sql = "select * from b_cpc_mst where fuel_id = @fuel_id ";

        dao.CommandSQL = sql;
        dao.setParam("@fuel_id", fuel_id);
        return dao.searchForDS();
    }


    /// <summary>
    /// 匯入時更新主檔的匯入筆數
    /// </summary>
    /// <param name="import_id"></param>
    public void updateImportCount(String import_id)
    {
        String sql = "update b_cpc_imp set count= (select count(*) from b_cpc_mst " +
            "where import_id = @import_id) where import_id = @import_id ";

        dao.CommandSQL = sql;
        dao.setParam("@import_id", import_id);

        dao.executeModify();
    }


    /// <summary>
    /// 修改中油匯入的明細檔
    /// </summary>
    /// <param name="form"></param>
    public void updateImportDtl(Form form)
    {
        String sql = "update b_cpc_mst set report_ym=@report_ym, car_no=@car_no, " +
            "update_date=GETDATE(), update_user=@update_user";

        if (form.getValue("cfm_status") != string.Empty)
        {
            sql += ", cfm_status=@cfm_status, cfm_desc = @cfm_desc, cfm_user = @update_user, " +
                "cfm_date=GETDATE()";
            dao.setParam("@cfm_status", form.getValue("cfm_status"));
            dao.setParam("@cfm_desc", form.getValue("cfm_desc"));
        }

        sql = sql + " where fuel_id=@fuel_id";

        dao.CommandSQL = sql;
        dao.setParam("@fuel_id", form.getValue("fuel_id"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 修改區隊建立的加油資料
    /// </summary>
    /// <param name="form"></param>
    public void updateOilMst(Form form)
    {
        String sql = "update b_oil_mst set mng_id=@mng_id, card_no=@card_no, car_no=@car_no, deal_date=@deal_date, " +
            "stand_name=@stand_name, fuel_type= @fuel_type, fuel_name=@fuel_name, " +
            "fuel_count=@fuel_count, fuel_amount=@fuel_amount, report_ym=@report_ym, " +
            "memo=@memo, update_date=GETDATE(), update_user=@update_user";

        if (form.getValue("adt_status") != string.Empty)
        {
            sql += ", adt_status=@adt_status, adt_desc = @adt_desc, adt_user = @update_user, " +
                "adt_date=GETDATE()";
            dao.setParam("@adt_status", form.getValue("adt_status"));
            dao.setParam("@adt_desc", form.getValue("adt_desc"));
        }

        sql = sql + " where oil_id=@oil_id";

        dao.CommandSQL = sql;
        dao.setParam("@oil_id", form.getValue("oil_id"));
        dao.setParam("@mng_id", form.getValue("mng_id"));
        dao.setParam("@card_no", form.getValue("card_no"));
        if (form.getValue("car_no") != string.Empty)
        {
            dao.setParam("@car_no", form.getValue("car_no"));
        }
        else
        {
            dao.setParam("@car_no", DBNull.Value);
        }
        dao.setParam("@deal_date", form.getValue("deal_date"));
        dao.setParam("@stand_name", form.getValue("stand_name"));
        dao.setParam("@fuel_type", form.getValue("fuel_type"));
        dao.setParam("@fuel_name", form.getValue("fuel_name"));
        dao.setParam("@fuel_count", form.getValue("fuel_count"));
        dao.setParam("@fuel_amount", form.getValue("fuel_amount"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 刪除匯入主檔
    /// </summary>
    /// <param name="import_id"></param>
    public void deleteImportMst(String import_id)
    {
        //原程式
        String sql = "delete b_cpc_imp where import_id=@import_id";
        //原程式
        //wenny_test_start
        //String sql = "delete b_cpc_imp where import_id=@import_id and where data_source = @data_source";
        //wenny_test_end
        dao.CommandSQL = sql;
        dao.setParam("@import_id", import_id);
        dao.executeModify();
    }


    /// <summary>
    /// 刪除區隊建立的加油資料
    /// </summary>
    /// <param name="oil_id"></param>
    public void deleteDepOilMst(String oil_id)
    {
        String sql = "delete b_oil_mst where oil_id=@oil_id";

        dao.CommandSQL = sql;
        dao.setParam("@oil_id", oil_id);
        dao.executeModify();
    }


    /// <summary>
    /// 刪除中油匯入的加油資料
    /// </summary>
    /// <param name="fuel_id"></param>
    public void deleteCPCMst(String fuel_id)
    {
        String sql = "delete b_cpc_mst where fuel_id=@fuel_id";

        dao.CommandSQL = sql;
        dao.setParam("@fuel_id", fuel_id);
        dao.executeModify();
    }


    /// <summary>
    /// 刪除加油卡的使用資料
    /// </summary>
    /// <param name="fuel_id"></param>
    public void deleteFuelUse(String fuel_id, String data_source)
    {
        String sql = "delete b_fuel_use where fuel_id=@fuel_id and data_source = @data_source";

        dao.CommandSQL = sql;
        dao.setParam("@fuel_id", fuel_id);
        dao.setParam("@data_source", data_source);
        dao.executeModify();
    }

    /// <summary>
    /// 刪除匯入明細檔
    /// </summary>
    /// <param name="import_id"></param>
    public void deleteImportDtl(String import_id)
    {
        //原程式
        String sql = "delete b_cpc_mst where import_id=@import_id";
        //原程式
        //wenny_test_start
        //String sql = "delete b_cpc_mst where import_id=@import_id and where data_source=@data_source";
        //wenny_test_end
        dao.CommandSQL = sql;
        dao.setParam("@import_id", import_id);
        dao.executeModify();
    }


    /// <summary>
    /// 取得匯入的中油資料
    /// </summary>
    /// <param name="fuel_id"></param>
    /// <returns></returns>
    public DataSet selectCPCData(String fuel_id)
    {
        //String sql = "select b.data_source, a.fuel_id, a.seller_id, a.seller_name, a.custom_id, a.custom_name, a.biller_id, " +
        //    "a.biller_name, a.mng_id, a.mng_name, a.card_no, a.car_no, dbo.chineseDateTime(a.deal_date) " +
        //    "as deal_date, a.stand_id, a.stand_name, a.fuel_name, a.fuel_count, a.fuel_amount, a.memo1, " +
        //    "a.memo2, a.report_ym, a.import_id, dbo.chineseDateTime(b.import_date) as imp_date, a.cfm_status, " +
        //    "a.cfm_user, UPPER(c.UserName) as cfm_username, dbo.chineseDateTime(a.cfm_date) as cfm_date, " +
        //    "a.cfm_desc, d.card_id, d.card_type, dbo.F_FuelUse('CPC', a.fuel_id) as fuel_use " +
        //    "from b_cpc_mst a " +
        //    "left join b_cpc_imp b on a.import_id = b.import_id " +
        //    "left join " + dao.DepDB() + "..Users c on a.cfm_user = c.UserId " +
        //    "left join c_card_mst d on a.card_no = d.card_no " +
        //    "left join c_car_card e on d.card_id = e.card_id and convert(varchar(10), e.possess_start, 111) <= convert(varchar(10), a.deal_date, 111) " +
        //    "and (e.possess_end is null or convert(varchar(10), e.possess_end, 111) >= convert(varchar(10), a.deal_date, 111)) " +
        //    "where a.fuel_id = @fuel_id and ((d.card_type = '1' and e.card_id is not null) or (d.card_type <> '1' and e.card_id is null))";

        String sql = "select  a.fuel_id, a.seller_id, a.seller_name, a.custom_id, a.custom_name, a.biller_id, " +
            "a.biller_name, a.mng_id, a.mng_name, a.card_no, a.car_no, dbo.chineseDateTime(a.deal_date) " +
            "as deal_date, a.stand_id, a.stand_name, a.fuel_name, a.fuel_count, a.fuel_amount, a.memo1, " +
            "a.memo2, a.report_ym, a.import_id, dbo.chineseDateTime(b.import_date) as imp_date, a.cfm_status, " +
            "a.cfm_user, UPPER(c.UserName) as cfm_username, dbo.chineseDateTime(a.cfm_date) as cfm_date, " +
            "a.cfm_desc, d.card_id, d.card_type, dbo.F_FuelUse('CPC', a.fuel_id) as fuel_use " +
            "from b_cpc_mst a " +
            "left join b_cpc_imp b on a.import_id = b.import_id " +
            "left join " + dao.DepDB() + "..Users c on a.cfm_user = c.UserId " +
            "left join c_card_mst d on a.card_no = d.card_no " +
            "left join c_car_card e on d.card_id = e.card_id and convert(varchar(10), e.possess_start, 111) <= convert(varchar(10), a.deal_date, 111) " +
            "and (e.possess_end is null or convert(varchar(10), e.possess_end, 111) >= convert(varchar(10), a.deal_date, 111)) " +
            "where a.fuel_id = @fuel_id and ((d.card_type = '1' and e.card_id is not null) or (d.card_type <> '1' and e.card_id is null))";

        dao.CommandSQL = sql;
        dao.setParam("@fuel_id", fuel_id);
        return dao.searchForDS();
    }


    /// <summary>
    /// 取得區隊建立的加油資料
    /// </summary>
    /// <param name="oil_id"></param>
    /// <returns></returns>
    public DataSet selectOilData(String oil_id)
    {
        String sql = "select oil_id, mng_id, a.card_no, a.car_no, dbo.chineseDateTime(deal_date) as deal_date, " +
            "stand_name, a.fuel_type, fuel_name, fuel_count, fuel_amount, report_ym, a.memo, adt_status, " +
            "adt_user, dbo.chineseDateTime(adt_date) as adt_date, adt_desc, b.card_type, b.card_id, " +
            "UPPER(c.username) as adt_username, dbo.F_FuelUse('DEP', oil_id) as fuel_use  " +
            "from b_oil_mst a " +
            "left join c_card_mst b on a.card_no = b.card_no " +
            "left join " + dao.DepDB() + "..Users c on a.adt_user = c.UserId " +
            "where a.oil_id = @oil_id";

        dao.CommandSQL = sql;
        dao.setParam("@oil_id", oil_id);
        return dao.searchForDS();
    }


    public DataSet selectCarDatabyCarNo(String car_no)
    {
        String sql = "select car_id, dep_no, car_no, f.id_name as fuel_type, fuel_std, b.id_name as status, " +
            "c.id_name as car_type, d.id_name as keep_org, e.card_no " +
            " from c_car_mst a " +
            "left join a_sysparam_data b on a.status = b.param_id and b.param_type='USE_STS' " +
            "left join a_sysparam_data c on a.car_type = c.param_id and c.param_type='CAR_TYPE' " +
            "left join a_sysparam_data d on a.keep_org = d.param_id and d.param_type='DEP_ORG' " +
            "left join a_oilcard_mst e on a.card_id = e.card_id " +
            "left join a_sysparam_data f on a.fuel_type = f.param_id and f.param_type='FUEL_TYPE' " +
            "where a.car_no = @car_no";

        dao.CommandSQL = sql;
        dao.setParam("@car_no", car_no);
        return dao.searchForDS();
    }


    /// <summary>
    /// 新增匯入資料之管理單位到參數檔
    /// </summary>
    public void InsertDepOrg(String import_id)
    {
        String sql = "INSERT INTO a_sysparam_data (param_type, param_id, id_name, id_order_by, status, " +
            "create_date, create_user, update_date, update_user) select 'DEP_ORG' as param_type, a.param_id, " +
            "a.id_name, row_number() over (order by len(id_name) desc, param_id) as id_order_by, 'O' as status, " +
            "GETDATE() as create_date, 'ADMIN' as create_user, GETDATE() as update_date, 'ADMIN' as update_user " +
            "from (SELECT distinct mng_id as param_id, mng_name as id_name from b_cpc_mst where " +
            "import_id = @import_id and mng_id " +
            "not in(select distinct param_id from a_sysparam_data where param_type='DEP_ORG' )) a ";

        dao.CommandSQL = sql;
        dao.setParam("@import_id", import_id);
        dao.executeModify();
    }


    /// <summary>
    /// 新增不存在的油品名稱到系統參數
    /// </summary>
    public void InsertFuelName()
    {
        String sql = "INSERT INTO a_sysparam_data (param_type, param_id, id_name, id_order_by, status, " +
            "create_date, create_user, update_date, update_user) select 'FUEL_NAME' as param_type, " +
            "row_number() over (order by len(a.fuel_name), a.fuel_name) + (select ISNULL(MAX(param_id),0) " +
           "as param_id from  a_sysparam_data where param_type='FUEL_NAME') as param_id, " +
            "a.fuel_name as id_name, row_number() over (order by len(a.fuel_name), a.fuel_name) + (select " +
            "ISNULL(MAX(param_id),0) as param_id from  a_sysparam_data where param_type='FUEL_NAME') " +
            "as id_order_by, 'O' as status, " +
            "GETDATE() as create_date, 'ADMIN' as create_user, GETDATE() as update_date, 'ADMIN' " +
            "as update_user " +
            "from (select distinct(fuel_name) from b_cpc_mst where fuel_name " +
            "not in(select distinct id_name from a_sysparam_data where param_type='FUEL_NAME' )) a";

        dao.CommandSQL = sql;
        dao.executeModify();
    }


    //wenny_test_start
    /// <summary>
    /// 依報表年月+資料來源刪除中油台塑匯入檔
    /// </summary>
    /// <param name="report_ym"></param>
    /// <param name="data_source"></param>
    public void deleteCPCImpByReportYMDatasource(String report_ym, String date_source)
    {
        //String sql = "delete b_cpc_imp where report_ym=@report_ym";
        //dao.CommandSQL = sql;
        //dao.setParam("@report_ym", report_ym);
        //dao.executeModify();
        String sql = "delete b_cpc_imp where report_ym=@report_ym and data_source=@data_source";
        dao.CommandSQL = sql;
        dao.setParam("@report_ym", report_ym);
        dao.setParam("@data_source", date_source);
        dao.executeModify();
    }

    /// <summary>
    /// 依報表年月+資料來源刪除中油台塑資料主檔
    /// </summary>
    /// <param name="report_ym"></param>
    /// <param name="data_source"></param>
    public void deleteCPCMstByReportYMDatasource(String report_ym, String data_source)
    {

        String sql = "delete b_cpc_mst  where import_id = (select import_id from b_cpc_imp where report_ym=@report_ym and data_source = @data_source)";



        dao.CommandSQL = sql;
        String aaa = dao.CommandSQL;
        dao.setParam("@report_ym", report_ym);
        dao.setParam("@data_source", data_source);
        dao.executeModify();
    }

    public DataSet selectCPCImpByReportYM(String report_ym, String oil)
    {

        String sql = "select TOP 1  import_id from b_cpc_mst where  report_ym=@report_ym  and seller_name='台北直銷中心' and oil=@oil  ";
        dao.CommandSQL = sql;
        dao.setParam("@report_ym", report_ym);
        dao.setParam("@oil", oil);

        return dao.searchForDS();
    }




    public DataSet selectCPCImpByReportYM1(String report_ym, String oil)
    {

        String sql = "select TOP 1  import_id from b_cpc_mst where  report_ym=@report_ym and seller_name='台塑'  and oil=@oil  ";
        dao.CommandSQL = sql;
        dao.setParam("@report_ym", report_ym);
        dao.setParam("@oil", oil);

        return dao.searchForDS();
    }
    public DataSet selectOPCImpByReportYM(String report_ym)
    {

        String sql = "select TOP 1  import_id from b_cpc_mst where  report_ym=@report_ym  and seller_name='台塑' ";
        dao.CommandSQL = sql;
        dao.setParam("@report_ym", report_ym);
        return dao.searchForDS();
    }

    public DataSet selectOil(String card_no)
    {

        String sql = " SELECT    fuel_type FROM  c_card_mst where card_no=@card_no ";
        dao.CommandSQL = sql;
        dao.setParam("@card_no", card_no);
        return dao.searchForDS();
    }
    //wenny_test_end

    ///2019.08.29
    /// <summary>
    /// 依import_id刪除匯入檔
    /// </summary>
    /// <param name="import_id"></param>
    public void deleteCPCImpByReportYM(String import_id)
    {
        //String sql = "delete b_cpc_imp where report_ym=@report_ym";
        //dao.CommandSQL = sql;
        //dao.setParam("@report_ym", report_ym);
        //dao.executeModify();
        //String sql2 = "select TOP 1  fuel_id from b_cpc_mst where  report_ym=@report_ym  and seller_name='台北直銷中心' ";
        //String sql = "delete b_cpc_imp where fuel_id='' ";
        String sql = "delete b_cpc_imp where import_id=@import_id ";
        dao.CommandSQL = sql;
        dao.setParam("@import_id", import_id);
        dao.executeModify();
    }
    ///2019.08.29
    /// <summary>
    /// 依import_id刪除中油資料主檔
    /// </summary>
    /// <param name="import_id"></param>
    public void deleteCPCMstByReportYM(String import_id)
    {
        String sql = "delete b_cpc_mst where import_id=@import_id";

        dao.CommandSQL = sql;
        dao.setParam("@import_id", import_id);
        dao.executeModify();
    }




    /// <summary>
    /// 取得勤務記錄join加油使用資料
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public DataSet getFuelUse(Form form)
    {
        String sql = "select a.work_id, dbo.chineseDateTime(work_start) as work_start, " +
            "dbo.chineseDateTime(work_end) as work_end, work_machine, c.id_name as mchn_name, " +
            " b.fuel_id, b.data_source from c_work_mst a " +
            "left join b_fuel_use b on a.work_id = b.work_id " +
            "left join a_sysparam_data c on a.work_machine = c.param_id and c.param_type = 'MACHINE' ";

        String where = "where 1=1 and convert(varchar(10), work_start, 111) <= @end_date " +
            "and convert(varchar(10), work_end, 111) >= @start_date and a.card_id = @card_id ";

        if (form.getValue("fuel_id") != string.Empty)
        {
            where += " and b.fuel_id = @fuel_id and b.data_source = @data_source";
            dao.setParam("@fuel_id", form.getValue("fuel_id"));
            dao.setParam("@data_source", form.getValue("data_source"));
        }

        dao.CommandSQL = sql + where;
        dao.setParam("@start_date", form.getValue("start_date"));
        dao.setParam("@end_date", form.getValue("end_date"));
        dao.setParam("@card_id", form.getValue("card_id"));

        return dao.searchForDS();
    }


    /// <summary>
    /// 取得勤務記錄join加油使用資料
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList SelectFuelUse(Form form)
    {
        String sql = "select a.work_id as PVALUE, dbo.chineseDateTime(work_start) + '~' + " +
            "dbo.chineseDateTime(work_end) +'(' + c.id_name + ')' as PTEXT from c_work_mst a " +
            "left join b_fuel_use b on a.work_id = b.work_id " +
            "left join a_sysparam_data c on a.work_machine = c.param_id and c.param_type = 'MACHINE' ";

        String where = "where 1=1 and convert(varchar(10), work_start, 111) <= @end_date " +
            "and convert(varchar(10), work_end, 111) >= @start_date and a.card_id = @card_id " +
            "and work_type = 'M' ";

        if (form.getValue("fuel_id") != string.Empty)
        {
            where += " and b.fuel_id = @fuel_id and b.data_source = @data_source";
            dao.setParam("@fuel_id", form.getValue("fuel_id"));
            dao.setParam("@data_source", form.getValue("data_source"));
        }

        dao.CommandSQL = sql + where;
        dao.setParam("@start_date", form.getValue("start_date"));
        dao.setParam("@end_date", form.getValue("end_date"));
        dao.setParam("@card_id", form.getValue("card_id"));

        return dao.search();
    }


    /// <summary>
    /// 修改區隊建立的加油資料狀態
    /// </summary>
    /// <param name="form"></param>
    public void updateOilStatus(Form form)
    {
        String sql = "update b_oil_mst set adt_status=@adt_status, adt_desc = @adt_desc, adt_user = @update_user, " +
                "adt_date=GETDATE(), update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where oil_id=@oil_id";

        dao.CommandSQL = sql;
        dao.setParam("@oil_id", form.getValue("oil_id"));
        dao.setParam("@adt_status", form.getValue("adt_status"));
        dao.setParam("@adt_desc", form.getValue("adt_desc"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 修改中油匯入的明細檔
    /// </summary>
    /// <param name="form"></param>
    public void auditBatchwithCarNo(Form form)
    {
        String table = "b_cpc_mst";
        String columnID = "fuel_id";
        String columnAdt = "cfm_status";
        String columnDesc = "cfm_desc";
        String columnDate = "cfm_date";
        String columnAdtUser = "cfm_user";

        if (form.getValue("data_source") == "DEP")
        {
            table = "b_oil_mst";
            columnID = "oil_id";
            columnAdt = "adt_status";
            columnDesc = "adt_desc";
            columnDate = "adt_date";
            columnAdtUser = "adt_user";
        }

        String sql = "update " + table + " set report_ym=@report_ym, car_no=@car_no, " +
            "update_date=GETDATE(), update_user=@update_user";

        if (form.getValue("status") != string.Empty)
        {
            sql += ", " + columnAdt + "=@status, " + columnDesc + "=@desc, " + columnAdtUser + "=@update_user, " +
                columnDate + "=GETDATE()";

            dao.setParam("@status", form.getValue("status"));
            dao.setParam("@desc", form.getValue("desc"));
        }

        sql = sql + " where " + columnID + "=@id";

        dao.CommandSQL = sql;
        dao.setParam("@id", form.getValue("id"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }

    public void auditDEPBatch(Form form)
    {
        String sql = "update b_oil_mst set report_ym=@report_ym, update_date=GETDATE(), update_user=@update_user, " +
            "adt_status=@status, adt_desc=@desc, adt_user=@update_user, adt_date=GETDATE() where oil_id in (" + handleMultiData("oil_id", form.getValue("oil_id")) + ")";

        dao.CommandSQL = sql;

        dao.setParam("@oil_id", form.getValue("oil_id"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@desc", form.getValue("desc"));

        dao.executeModify();

    }


    public void confirmCPCBatch(Form form)
    {
        String sql = "update b_cpc_mst set report_ym=@report_ym, update_date=GETDATE(), update_user=@update_user, " +
            "cfm_status=@status, cfm_desc=@desc, cfm_user=@update_user, cfm_date=GETDATE() where fuel_id in (" + handleMultiData("fuel_id", form.getValue("fuel_id")) + ")";

        dao.CommandSQL = sql;

        dao.setParam("@fuel_id", form.getValue("fuel_id"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@desc", form.getValue("desc"));

        dao.executeModify();



    }
}