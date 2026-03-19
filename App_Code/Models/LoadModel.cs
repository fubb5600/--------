using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// LoadModel 的摘要描述
/// </summary>
public class LoadModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        else if (pbKey.Equals("browse2"))
        {
            browse2(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse2_imp_id"))
        {
            browse2_imp_id(pb, form);
        }
        else if (pbKey.Equals("browse2_report_ym"))
        {
            browse2_report_ym(pb, form);
        }
        else if (pbKey.Equals("browse2_load_org"))
        {
            browse2_load_org(pb, form);
        }
        else if (pbKey.Equals("browse2_load_date"))
        {
            browse2_load_date(pb, form);
        }
        else if (pbKey.Equals("browse2_car_no"))
        {
            browse2_car_no(pb, form);
        }
        else if (pbKey.Equals("browse2_net_weight"))
        {
            browse2_net_weight(pb, form);
        }
        else if (pbKey.Equals("browse2_memo"))
        {
            browse2_memo(pb, form);
        }
        //反排
        else if (pbKey.Equals("browse2d"))
        {
            browse2d(pb, form);
        }
        else if (pbKey.Equals("browse2_imp_idd"))
        {
            browse2_imp_idd(pb, form);
        }
        else if (pbKey.Equals("browse2_report_ymd"))
        {
            browse2_report_ymd(pb, form);
        }
        else if (pbKey.Equals("browse2_load_orgd"))
        {
            browse2_load_orgd(pb, form);
        }
        else if (pbKey.Equals("browse2_load_dated"))
        {
            browse2_load_dated(pb, form);
        }
        else if (pbKey.Equals("browse2_car_nod"))
        {
            browse2_car_nod(pb, form);
        }
        else if (pbKey.Equals("browse2_net_weightd"))
        {
            browse2_net_weightd(pb, form);
        }
        else if (pbKey.Equals("browse2_memod"))
        {
            browse2_memod(pb, form);
        }
        //wenny_test_排序
    }

    /// <summary>
    /// 加油資料匯入主檔資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select import_id, report_ym, dbo.chineseDateTime(import_date) as import_date, " +
            "count, a.memo, a.import_user + '(' + UPPER(b.username) + ')' as import_user " +
            "from b_cpc_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";


        String where = "where 1=1";

        if (!form.getValue("report_y").Equals(""))
        {
            where += " and SUBSTRING(a.report_ym,1,3) like @report_y";
            pb.setParam("@report_y", form.getValue("report_y") + "%");
        }

        if (!form.getValue("report_m").Equals(""))
        {
            where += " and SUBSTRING(a.report_ym,5,2) like @report_m";
            pb.setParam("@report_m", "%" + form.getValue("report_m"));
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

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "import_id";
    }


    /// <summary>
    /// 載重資料主檔資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse2(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " + 
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "load_id desc, load_date";
    }
    //wenny_test_排序
    //正排
    private void browse2_imp_id(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "imp_id";
    }
    private void browse2_report_ym(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "report_ym";
    }
    private void browse2_load_org(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "load_org";
    }
    private void browse2_load_date(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "load_date";
    }
    private void browse2_car_no(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no";
    }
    private void browse2_net_weight(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "net_weight";
    }
    private void browse2_memo(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "memo";
    }
    //反排
    private void browse2d(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "load_id desc, load_date desc";
    }
    private void browse2_imp_idd(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "imp_id desc";
    }
    private void browse2_report_ymd(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "report_ym desc";
    }
    private void browse2_load_orgd(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "load_org desc";
    }
    private void browse2_load_dated(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "load_date desc";
    }
    private void browse2_car_nod(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no desc";
    }
    private void browse2_net_weightd(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "net_weight desc";
    }
    private void browse2_memod(PageBreak pb, Form form)
    {
        String sql = "select load_id, dbo.chineseDateTime(load_date) as load_date, car_no, net_weight, c.id_name as load_org, " +
            "a.report_ym, a.imp_id, a.memo from c_load_mst a left join c_load_imp b on a.imp_id = b.imp_id " +
            "left join a_sysparam_data c on b.load_org = c.param_id and c.param_type ='LOAD_ORG' ";

        String where = "where 1=1";

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


        if (!form.getValue("load_start").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  >= @load_start";
            pb.setParam("@load_start", DateTransfer.c_date_trans(form.getValue("load_start")));
        }

        if (!form.getValue("load_end").Equals(""))
        {
            where += " and convert(varchar(10) , load_date, 111 )  <= @load_end";
            pb.setParam("@load_end", DateTransfer.c_date_trans(form.getValue("load_end")));
        }

        //if (!form.getValue("imp_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  >= @imp_start";
        //    pb.setParam("@imp_start", DateTransfer.c_date_trans(form.getValue("imp_start")));
        //}

        //if (!form.getValue("imp_end").Equals(""))
        //{
        //    where += " and convert(varchar(10) , b.import_date, 111 )  <= @imp_end";
        //    pb.setParam("@imp_end", DateTransfer.c_date_trans(form.getValue("imp_end")));
        //}

        if (!form.getValue("imp_id").Equals(""))
        {
            where += " and a.imp_id = @imp_id";
            pb.setParam("@imp_id", form.getValue("imp_id"));
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and a.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("load_org").Equals(""))
        {
            where += " and b.load_org in (" + handleMultiData("load_org", form.getValue("load_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "memo desc";
    }
    //wenny_test_排序

    /// <summary>
    /// 新增匯入主檔
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertImportMst(Form form)
    {
        String sql = "insert into c_load_imp (imp_date, imp_user, report_ym, memo, create_date, " +
            "create_user, update_date, update_user, load_org) " +
            "values (GETDATE(), @imp_user, @report_ym, @memo, GETDATE(), @imp_user, " +
            "GETDATE(), @imp_user, @load_org)";

        dao.CommandSQL = sql;
        dao.setParam("@imp_user", form.getValue("imp_user"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@load_org", form.getValue("load_org"));
        dao.setParam("@memo", form.getValue("memo"));

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 新增匯入明細檔
    /// </summary>
    /// <param name="form"></param>
    public void insertImportDtl(Form form)
    {
        String sql = "insert into c_load_mst (load_date, car_no, net_weight, report_ym, imp_id, memo, create_date, " +
            "create_user, update_date, update_user) " +
            "values (@load_date, @car_no, @net_weight, @report_ym, @imp_id, @memo, GETDATE(), " +
            "@create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        if (form.getValue("load_date") != string.Empty)
        {
            dao.setParam("@load_date", form.getValue("load_date"));
        }
        else { dao.setParam("@load_date", DBNull.Value); }
       
        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@net_weight", form.getValue("net_weight"));
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@imp_id", form.getValue("imp_id"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }   


    /// <summary>
    /// 修改匯入檔的筆數資料
    /// </summary>
    /// <param name="imp_id"></param>
    public void updateImportCount(String imp_id)
    {
        String sql = "update c_load_imp set count= (select count(*) from c_load_mst where imp_id = @imp_id)";
       
        dao.CommandSQL = sql;
        dao.setParam("@imp_id", imp_id);

        dao.executeModify();
    }


    /// <summary>
    /// 刪除匯入主檔
    /// </summary>
    /// <param name="imp_id"></param>
    public void deleteLoadImp(String imp_id)
    {
        String sql = "delete c_load_imp where imp_id=@imp_id";

        dao.CommandSQL = sql;
        dao.setParam("@imp_id", imp_id);
        dao.executeModify();
    }



    /// <summary>
    /// 刪除匯入明細檔
    /// </summary>
    /// <param name="import_id"></param>
    public void deleteLoadMst(String imp_id)
    {
        String sql = "delete c_load_mst where imp_id=@imp_id";

        dao.CommandSQL = sql;
        dao.setParam("@imp_id", imp_id);
        dao.executeModify();
    }


    /// <summary>
    /// 依報表年月刪除載重匯入檔
    /// </summary>
    /// <param name="report_ym"></param>
    public void deleteLoadImpByReportYM(Form form)
    {
        String sql = "delete c_load_imp where report_ym=@report_ym and load_org=@load_org";

        dao.CommandSQL = sql;
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@load_org", form.getValue("load_org"));
        dao.executeModify();
    }


    /// <summary>
    /// 依報表年月刪除載重主檔
    /// </summary>
    /// <param name="report_ym"></param>
    public void deleteLoadMstByReportYM(Form form)
    {
        String sql = "delete c_load_mst where imp_id in(select imp_id from c_load_imp where report_ym=@report_ym and load_org=@load_org)";

        dao.CommandSQL = sql;
        dao.setParam("@report_ym", form.getValue("report_ym"));
        dao.setParam("@load_org", form.getValue("load_org"));
        dao.executeModify();
    }

}