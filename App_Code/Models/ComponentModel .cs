using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// CardModel 的摘要描述
/// </summary>
public class ComponentModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse1component_name"))
        {
            browse1component_name(pb, form);
        }  
        else if (pbKey.Equals("browse1component_spec"))
        {
            browse1component_spec(pb, form);
        }  
        else if (pbKey.Equals("browse1unit"))
        {
            browse1unit(pb, form);
        }  
        else if (pbKey.Equals("browse1budget2"))
        {
            browse1budget2(pb, form);
        }  
        else if (pbKey.Equals("browse1component_code"))
        {
            browse1component_code(pb, form);
        } 
        else if (pbKey.Equals("browse1car_type"))
        {
            browse1car_type(pb, form);
        } 
        else if (pbKey.Equals("browse1memo"))
        {
            browse1memo(pb, form);
        }
        //反排
        else if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);
        }
        else if (pbKey.Equals("browse1component_named"))
        {
            browse1component_named(pb, form);
        }
        else if (pbKey.Equals("browse1component_specd"))
        {
            browse1component_specd(pb, form);
        }
        else if (pbKey.Equals("browse1unitd"))
        {
            browse1unitd(pb, form);
        }
        else if (pbKey.Equals("browse1budget2d"))
        {
            browse1budget2d(pb, form);
        }
        else if (pbKey.Equals("browse1component_coded"))
        {
            browse1component_coded(pb, form);
        }
        else if (pbKey.Equals("browse1car_typed"))
        {
            browse1car_typed(pb, form);
        }
        else if (pbKey.Equals("browse1memod"))
        {
            browse1memod(pb, form);
        }
        //wenny_test_排序
        else if (pbKey.Equals("browse2"))
        {
            browse2(pb, form);
        }

        //正排
        else if (pbKey.Equals("browse2report_y"))
        {
            browse2report_y(pb, form);
        }
        else if (pbKey.Equals("browse2import_date"))
        {
            browse2import_date(pb, form);
        }
        else if (pbKey.Equals("browse2import_user"))
        {
            browse2import_user(pb, form);
        }
        else if (pbKey.Equals("browse2count"))
        {
            browse2count(pb, form);
        }
        else if (pbKey.Equals("browse2memo"))
        {
            browse2memo(pb, form);
        }
        //反排
        else if (pbKey.Equals("browse2d"))
        {
            browse2d(pb, form);
        }
        else if (pbKey.Equals("browse2report_yd"))
        {
            browse2report_yd(pb, form);
        }
        else if (pbKey.Equals("browse2import_dated"))
        {
            browse2import_dated(pb, form);
        }
        else if (pbKey.Equals("browse2import_userd"))
        {
            browse2import_userd(pb, form);
        }
        else if (pbKey.Equals("browse2countd"))
        {
            browse2countd(pb, form);
        }
        else if (pbKey.Equals("browse2memod"))
        {
            browse2memod(pb, form);
        }
        //wenny_test_排序
    }
    public DataSet selectRepairMst1(String work_no)
    {
        String sql = "SELECT a.repair_id, a.car_id, a.crs_org, a.budget_area, case_no, a.work_no, a.repair_vender, a.delivery_unit, dbo.chineseDateTime(a.notify_date) as notify_date, " +
            "dbo.chineseDateTime(a.exec_deadline) as exec_deadline, dbo.chineseDateTime(a.finish_date) as finish_date, " +
            "dbo.chineseDateTime(a.check_date)as check_date, dbo.chineseDateTime(a.qualified_date) as qualified_date, delivery_days, is_late, " +
            "check_result, a.memo, b.notify_id, b.notify_item, b.mileage, b.driver, b.repair_type3, " +
            "case when b.notify_type = 'C' then c.dep_no else b.machine_no end as dep_no, c.car_no, c.car_type, c.brand_no, d.id_name as keep_org, " +
            "e.id_name as cart_ype, g.id_name as car_status, b.notify_type, b.machine_type, b.machine_org,budget_area " +
            "from f_repair_mst a " +
            "left join f_notify_mst b on a.work_no = b.work_no " +
            "left join c_car_mst c on a.car_id = c.car_id " +
            "left join a_sysparam_data d on a.crs_org = d.param_id and d.param_type = 'DEP_ORG' " +
            "left join a_sysparam_data e on c.car_type = e.param_id and e.param_type = 'CAR_TYPE' " +
            "left join c_car_sts f on a.car_id = f.car_id and convert(varchar(10), f.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
            "and (f.exec_end is null or convert(varchar(10), f.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) " +
            "left join a_sysparam_data g on f.status = g.param_id and g.param_type = 'USE_STS' " +

            //FOR XML PATH('') 多筆資料合併處理
            //"left join (" +
            //"select @repair_id as repair_id, (select cast(repair_item AS NVARCHAR(1000) ) + ';' from (select a.notify_item  + '|' + a.component_no + '|' + CAST(a.count as varchar(10)) + '|' + " +
            //"CAST((a.count*b.budget" + crs_area + ") as varchar(10)) + '|' + a.junk_name + '|' +  CAST(a.junk_count as varchar(10)) as repair_item " +
            //"from f_repair_dtl a left join e_component_mst b on a.component_no = b.component_no where repair_id = @repair_id) a FOR XML PATH('')) as repair_item" +
            //") h on a.repair_id = h.repair_id " +

            "where a.work_no = @work_no ";

        dao.CommandSQL = sql;
        dao.setParam("@work_no", work_no);
        return dao.searchForDS();
    }



    public DataSet selectRepairMst2(String car_no)
    {
        String sql = "SELECT  car_id,car_no  FROM[TDOS].[dbo].c_car_mst " +


            
            "where car_no = @car_no ";

        dao.CommandSQL = sql;
        dao.setParam("@car_no", car_no);
        return dao.searchForDS();
    }
    public DataSet selectRepairMst3(String id_name)
    {
        String sql = "SELECT [param_id] FROM[TDOS].[dbo].[a_sysparam_data] where param_type = 'DEP_ORG' " +



            "and id_name = @id_name ";

        dao.CommandSQL = sql;
        dao.setParam("@id_name", id_name);
        return dao.searchForDS();
    }
    private void browse2(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        //if (!form.getValue("import_id").Equals(""))
        //{
        //    where += " and import_id like @import_id";
        //    pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        //}
        //if (!form.getValue("import_date").Equals(""))
        //{
        //    where += " and import_date like @import_date";
        //    pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        //}
        //if (!form.getValue("import_user").Equals(""))
        //{
        //    where += " and import_user like @import_user";
        //    pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        //}
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



        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        //if (!form.getValue("count").Equals(""))
        //{
        //    where += " and count like @count";
        //    pb.setParam("@count", "%" + form.getValue("count") + "%");
        //}
        //if (!form.getValue("memo").Equals(""))
        //{
        //    where += " and a.memo like @memo";
        //    pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        //}

        pb.CommandSQL = sql+where;
        
        pb.OrderSQL = "import_id desc";
       
    }
    //wenny_test_排序
    //正排
    private void browse2report_y(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "report_y";
    }
    private void browse2import_date(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "import_date";
    }
    private void browse2import_user(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "import_user";
    }
    private void browse2count(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "count";
    }
    private void browse2memo(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "memo";
    }
    //反排
    private void browse2d(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "import_id desc";
    }
    private void browse2report_yd(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "report_y desc";
    }
    private void browse2import_dated(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "import_date desc";
    }
    private void browse2import_userd(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "import_user desc";
    }
    private void browse2countd(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "count desc";
    }
    private void browse2memod(PageBreak pb, Form form)
    {
        string sql = "select import_id, dbo.chineseDateTime(import_date) as import_date, a.import_user + '(' + UPPER(b.username) + ')' as import_user , report_y, count, a.memo " +
            "from e_component_imp a left join " + dao.DepDB() + "..Users b on a.import_user = b.UserId ";

        string where = "where 1=1";

        if (!form.getValue("import_id").Equals(""))
        {
            where += " and import_id like @import_id";
            pb.setParam("@import_id", "%" + form.getValue("import_id") + "%");
        }
        if (!form.getValue("import_date").Equals(""))
        {
            where += " and import_date like @import_date";
            pb.setParam("@import_date", "%" + form.getValue("import_date") + "%");
        }
        if (!form.getValue("import_user").Equals(""))
        {
            where += " and import_user like @import_user";
            pb.setParam("@import_user", "%" + form.getValue("import_user") + "%");
        }
        if (!form.getValue("report_y").Equals(""))
        {
            where += " and report_y like @report_y";
            pb.setParam("@report_y", "%" + form.getValue("report_y") + "%");
        }
        if (!form.getValue("count").Equals(""))
        {
            where += " and count like @count";
            pb.setParam("@count", "%" + form.getValue("count") + "%");
        }
        if (!form.getValue("memo").Equals(""))
        {
            where += " and a.memo like @memo";
            pb.setParam("@memo", "%" + form.getValue("memo") + "%");
        }

        pb.CommandSQL = sql;
        pb.OrderSQL = "memo desc";
    }
    //wenny_test_排序

    /// <summary>
    /// 標案項目資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year",  form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "component_no desc";
    }
    //wenny_test_排序
    //正排
    private void browse1component_name(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "component_name";
    }
    private void browse1component_spec(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "component_spec";
    }
    private void browse1unit(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "unit";
    }
    private void browse1budget2(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "budget2";
    }
    private void browse1component_code(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "component_code";
    }
    private void browse1car_type(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_type";
    }
    private void browse1memo(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "memo";
    }
    //反排
    private void browse1d(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "component_no desc";
    }
    private void browse1component_named(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "component_name desc";
    }
    private void browse1component_specd(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "component_spec desc";
    }
    private void browse1unitd(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "unit desc";
    }
    private void browse1budget2d(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "budget2 desc";
    }
    private void browse1component_coded(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "component_code desc";
    }
    private void browse1car_typed(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_type desc";
    }
    private void browse1memod(PageBreak pb, Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            pb.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            pb.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            pb.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            pb.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            pb.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            pb.setParam("@report_year", form.getValue("report_year"));
        }


        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "memo desc";
    }
    //wenny_test_排序
    /// <summary>
    /// 刪除匯入主檔
    /// </summary>
    /// <param name="import_id"></param>
    public void deleteImportMst(String import_id)
    {
        String sql = "delete e_component_mst where import_id=@import_id";

        dao.CommandSQL = sql;
        dao.setParam("@import_id", import_id);
        dao.executeModify();
    }


    /// <summary>
    /// 刪除匯入主檔
    /// </summary>
    /// <param name="import_id"></param>
    public void deleteImportDtl(String import_id)
    {
        String sql = "delete e_component_imp where import_id=@import_id";

        dao.CommandSQL = sql;
        dao.setParam("@import_id", import_id);
        dao.executeModify();
    }


    /// <summary>
    /// 新增匯入主檔
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertComponentImp(Form form)
    {
        String sql = "insert into e_component_imp (import_date, import_user, report_y, count, memo) " +

            " values (GETDATE(), @import_user, @report_y, @count, @memo)";

        dao.CommandSQL = sql;
        dao.setParam("@import_user", form.getValue("import_user"));
        dao.setParam("@report_y", form.getValue("report_y"));
        dao.setParam("@count", form.getValue("count"));
        dao.setParam("@memo", form.getValue("memo"));

        return dao.insertForSEQ();
    }
    /// <summary>
    /// 新增匯入明細檔
    /// </summary>
    /// <param name="form"></param>
    public void insertImportDtl(Form form)
    {
        //String sql = "insert into e_component_mst (import_id, component_no, component_name, component_spec, component_code, count, unit,  " +
        //    "budget1, budget2, budget3, budget4, car_type, place_of_origin, memo, create_date, create_user, update_date, update_user)" +
        //    "values (@import_id, @component_no, @component_name, @component_spec, @component_code, @count, @unit, " +
        //    "@budget1, @budget2, @budget3, @budget4, @car_type, @place_of_origin, @memo, GETDATE(),@create_user, GETDATE(), @create_user) " +
        //    "where not exist(select * from e_component_mst where component_no = @component_no);";
        
        String sql = "begin tran " +
            "if exists (select * from e_component_mst with (updlock,serializable) where component_no = @component_no) " +
            "begin " +
            "update e_component_mst set import_id = @import_id, component_name = @component_name, component_spec = @component_spec, component_code = @component_code, " +
            "unit = @unit, budget1 = @budget1, budget2 = @budget2, budget3 = @budget3, budget4 = @budget4, car_type = @car_type, update_user = @create_user, " +
            "count = @count, place_of_origin = @place_of_origin, memo = @memo, update_date = GETDATE() where component_no = @component_no " +
            "end " +
            "else " +
            "begin " +
            "insert into e_component_mst (import_id, component_no, component_name, component_spec, component_code, count, unit,  " +
            "budget1, budget2, budget3, budget4, car_type, place_of_origin, memo, create_date, create_user, update_date, update_user)" +
            "values (@import_id, @component_no, @component_name, @component_spec, @component_code, @count, @unit, " +
            "@budget1, @budget2, @budget3, @budget4, @car_type, @place_of_origin, @memo, GETDATE(),@create_user, GETDATE(), @create_user) " +
            "end " +
            "commit tran";

        dao.CommandSQL = sql;
        dao.setParam("@import_id", form.getValue("import_id"));
        dao.setParam("@component_no", form.getValue("component_no"));
        dao.setParam("@component_name", form.getValue("component_name"));
        dao.setParam("@component_spec", form.getValue("component_spec"));
        dao.setParam("@component_code", form.getValue("component_code"));
        dao.setParam("@unit", form.getValue("unit"));
        dao.setParam("@budget1", form.getValue("budget1"));
        dao.setParam("@budget2", form.getValue("budget2"));
        dao.setParam("@budget3", form.getValue("budget3"));
        dao.setParam("@budget4", form.getValue("budget4"));
        dao.setParam("@car_type", form.getValue("car_type"));
        dao.setParam("@create_user", form.getValue("create_user"));

        if (form.getValue("count") != string.Empty)
        {
            dao.setParam("@count", form.getValue("count"));
        }
        else
        {
            dao.setParam("@count", DBNull.Value);
        }

        if (form.getValue("place_of_origin") != string.Empty)
        {
            dao.setParam("@place_of_origin", form.getValue("place_of_origin"));
        }
        else
        {
            dao.setParam("@place_of_origin", DBNull.Value);
        }

        if (form.getValue("memo") != string.Empty)
        {
            dao.setParam("@memo", form.getValue("memo"));
        }
        else
        {
            dao.setParam("@memo", DBNull.Value);
        }

        dao.executeModify();
    }

    public void insertImportDt2(Form form)
    {
        //String sql = "insert into e_component_mst (import_id, component_no, component_name, component_spec, component_code, count, unit,  " +
        //    "budget1, budget2, budget3, budget4, car_type, place_of_origin, memo, create_date, create_user, update_date, update_user)" +
        //    "values (@import_id, @component_no, @component_name, @component_spec, @component_code, @count, @unit, " +
        //    "@budget1, @budget2, @budget3, @budget4, @car_type, @place_of_origin, @memo, GETDATE(),@create_user, GETDATE(), @create_user) " +
        //    "where not exist(select * from e_component_mst where component_no = @component_no);";

        String sql = 
            "insert into e_component_mst (import_id, component_no, component_name, component_spec, component_code, count, unit,  " +
            "budget1, budget2, budget3, budget4, car_type, place_of_origin, memo, create_date, create_user, update_date, update_user)" +
            "values (@import_id, @component_no, @component_name, @component_spec, @component_code, @count, @unit, " +
            "@budget1, @budget2, @budget3, @budget4, @car_type, @place_of_origin, @memo, GETDATE(),@create_user, GETDATE(), @create_user) ";


        dao.CommandSQL = sql;
        dao.setParam("@import_id", form.getValue("import_id"));
        dao.setParam("@component_no", form.getValue("component_no"));
        dao.setParam("@component_name", form.getValue("component_name"));
        dao.setParam("@component_spec", form.getValue("component_spec"));
        dao.setParam("@component_code", form.getValue("component_code"));
        dao.setParam("@unit", form.getValue("unit"));
        dao.setParam("@budget1", form.getValue("budget1"));
        dao.setParam("@budget2", form.getValue("budget2"));
        dao.setParam("@budget3", form.getValue("budget3"));
        dao.setParam("@budget4", form.getValue("budget4"));
        dao.setParam("@car_type", form.getValue("car_type"));
        dao.setParam("@create_user", form.getValue("create_user"));

        if (form.getValue("count") != string.Empty)
        {
            dao.setParam("@count", form.getValue("count"));
        }
        else
        {
            dao.setParam("@count", DBNull.Value);
        }

        if (form.getValue("place_of_origin") != string.Empty)
        {
            dao.setParam("@place_of_origin", form.getValue("place_of_origin"));
        }
        else
        {
            dao.setParam("@place_of_origin", DBNull.Value);
        }

        if (form.getValue("memo") != string.Empty)
        {
            dao.setParam("@memo", form.getValue("memo"));
        }
        else
        {
            dao.setParam("@memo", DBNull.Value);
        }

        dao.executeModify();
    }

    /// <summary>
    /// 新增標案項目
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertComponent(Form form)
    {
        String sql = "insert into e_component_mst (component_no, component_name, component_spec, component_code, count, unit, " +
            "budget1, budget2, budget3, budget4, car_type, place_of_origin, memo, create_date,create_user, update_date, update_user) " +
            "values (@component_no, @component_name, @component_spec, @component_code, @count, @unit, @budget1, @budget2, " +
            "@budget3, @budget4, @car_type, @place_of_origin, @memo, GETDATE(), @create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@car_type", form.getValue("car_type"));
        dao.setParam("@component_no", form.getValue("component_no"));
        dao.setParam("@component_name", form.getValue("component_name"));
        dao.setParam("@component_spec", form.getValue("component_spec"));
        dao.setParam("@component_code", form.getValue("component_code"));
        dao.setParam("@count", form.getValue("count"));
        dao.setParam("@unit", form.getValue("unit"));
        dao.setParam("@budget1", form.getValue("budget1"));
        dao.setParam("@budget2", form.getValue("budget2"));
        dao.setParam("@budget3", form.getValue("budget3"));
        dao.setParam("@budget4", form.getValue("budget4"));
        dao.setParam("@place_of_origin", form.getValue("place_of_origin"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 標案項目詳細資料
    /// </summary>
    /// <param name="component_no"></param>
    /// <returns></returns>
    public DataSet selectComponent(string component_no)
    {
        string sql = "select component_id, component_no, component_name, component_spec, component_code, count, car_type, unit, budget1, budget2, " +
            "budget3, budget4, place_of_origin, memo, import_id " +
            " from e_component_mst where component_no=@component_no";
        dao.CommandSQL = sql;
        dao.setParam("@component_no", component_no);
        return dao.searchForDS();
    }

    /// <summary>
    /// 取得標案項目單價資料
    /// </summary>
    /// <param name="component_no"></param>
    /// <returns></returns>
    public DataSet selectComponent(String budget_area, string component_no)
    {
        string sql = "select component_id, component_no, budget" + budget_area +
            " from e_component_mst where component_no in(" + handleMultiData("component_no", component_no) + ")";       

        dao.CommandSQL = sql;
     
        return dao.searchForDS();
    }


    /// <summary>
    /// 修改標案項目資料
    /// </summary>
    /// <param name="form"></param>
    public void updateComponent(Form form)
    {
        String sql = "update e_component_mst set component_no=@component_no, component_name=@component_name, " +
            "component_spec=@component_spec, component_code=@component_code, count = @count, unit=@unit, budget1=@budget1, " +
            "budget2=@budget2, budget3=@budget3, budget4=@budget4, car_type=@car_type,place_of_origin=@place_of_origin," +
            "memo=@memo,update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where component_id=@component_id";

        dao.CommandSQL = sql;
        dao.setParam("@component_id", form.getValue("component_id"));
        dao.setParam("@car_type", form.getValue("car_type"));
        dao.setParam("@component_no", form.getValue("component_no"));
        dao.setParam("@component_name", form.getValue("component_name"));
        dao.setParam("@component_spec", form.getValue("component_spec"));
        dao.setParam("@component_code", form.getValue("component_code"));
        dao.setParam("@count", form.getValue("count"));
        dao.setParam("@unit", form.getValue("unit"));
        dao.setParam("@budget1", form.getValue("budget1"));
        dao.setParam("@budget2", form.getValue("budget2"));
        dao.setParam("@budget3", form.getValue("budget3"));
        dao.setParam("@budget4", form.getValue("budget4"));
        dao.setParam("@place_of_origin", form.getValue("place_of_origin"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 刪除標案項目資料
    /// </summary>
    /// <param name="component_id"></param>
    public void deleteComponent(String component_id)
    {
        String sql = "delete e_component_mst where component_id=@component_id";

        dao.CommandSQL = sql;
        dao.setParam("@component_id", component_id);
        dao.executeModify();
    }

    /// <summary>
    /// 標案項目中的車輛種類的下拉式選單
    /// </summary>
    /// <returns></returns>
    public ArrayList selectCarType()
    {
        String sql = "select distinct car_type as PVALUE, car_type as PTEXT from e_component_mst order by PVALUE";//新增"適用車種排序"_wenny1061212
        dao.CommandSQL = sql;
        return dao.search();
    }

    /// <summary>
    /// 零件編號的年度選單
    /// </summary>
    /// <returns></returns>
    public ArrayList selectYear()
    {
        String sql = "select distinct substring(component_no, 1, 3) as PText, substring(component_no, 1, 3) as PValue from e_component_mst order by PVALUE desc";
        dao.CommandSQL = sql;
        return dao.search();
    }
    /// <summary>
    /// 零件編號匯入的年度選單
    /// </summary>
    /// <returns></returns>
    public ArrayList selectYear_imp()
    {
        String sql = "select distinct report_y as PText, report_y as PValue from e_component_imp order by PVALUE desc";
        dao.CommandSQL = sql;
        return dao.search();
    }
    #region//新增"適用車種排序"_wenny1061212
    public ArrayList selectCarType(String sYear, String sCarTypeKeyword)
    {
        String sql = "select distinct car_type as PVALUE, car_type as PTEXT from component_car_type ";
        string where = "where 1=1";
        where += " and substring(component_no, 1, 3) = @year";
        dao.setParam("@year", sYear);

        if (!string.IsNullOrEmpty(sCarTypeKeyword))
        {
            where += " and car_type like @car_type";
            dao.setParam("@car_type", "%" + sCarTypeKeyword + "%");
        }
        sql = sql + where + " order by PVALUE ";
        dao.CommandSQL = sql;
        return dao.search();
    }
    #endregion
    /// <summary>
    /// 零件編號代碼
    /// </summary>
    /// <param name="sYear"></param>
    /// <returns></returns>
    public ArrayList selectCode(String sYear)
    {
        String sql = "select distinct component_code as PVALUE, component_code as PTEXT from e_component_mst " +
            "where substring(component_no, 1, 3) = @year order by PVALUE";
        dao.setParam("@year", sYear);
        dao.CommandSQL = sql;
        return dao.search();
    }
    #region //新增"適用車種排序"_wenny1061212
    public ArrayList selectCode(String sYear, String sCarTypeKeyword)
    {
        String sql = "select distinct component_code as PVALUE, component_code as PTEXT from e_component_mst ";
        string where = "where 1=1";
        where += " and substring(component_no, 1, 3) = @year";
        dao.setParam("@year", sYear);

        if (!string.IsNullOrEmpty(sCarTypeKeyword))
        {
            where += " and car_type like @car_type";
            dao.setParam("@car_type", "%" + sCarTypeKeyword + "%");
        }
        sql = sql + where + " order by PVALUE ";
        dao.CommandSQL = sql;
        return dao.search();
    }
    public ArrayList selectCode(String sYear, String sCarTypeKeyword, String sCarType)
    {
        //public string selectCode(String sYear, String sCarTypeKeyword, String sCarType)
        //{
            String sql = "select distinct component_code as PVALUE, component_code as PTEXT from e_component_mst ";
        string where = "where 1=1";
        where += " and substring(component_no, 1, 3) = @year ";
        dao.setParam("@year", sYear);

 
        if (!string.IsNullOrEmpty(sCarType))
        {
            where += " and car_type like @car_type ";
            dao.setParam("@car_type","%"+ sCarType +"%");
        }
        if (!string.IsNullOrEmpty(sCarTypeKeyword))
        {
            where += " and car_type like @car_type_keyword ";
            dao.setParam("@car_type_keyword", " %" + sCarTypeKeyword + "% ");
        }
        sql = sql + where + " order by PVALUE ";
        dao.CommandSQL = sql;
        //return sql;
        return dao.search();
    }
    #endregion //新增"適用車種排序"_wenny1061212
    /// <summary>
    /// 零件選單
    /// </summary>
    /// <param name="sYear"></param>
    /// <returns></returns>
 #region //新增"適用車種排序"_wenny1061212
    public ArrayList selectComponentno(String sYear,String car_type_keyword, String  sCarType,String sCode,String sComponentKeyword)
    {
        String sql = "select component_no as PVALUE, component_no + '(' + cast(component_name AS NVARCHAR(20)) + ')' as PTEXT, component_no, " +
            "component_code, component_name, " +
            "component_spec, count, budget1, budget2, budget3, budget4 " +
            "from e_component_mst ";
        string where = "where 1=1";
        where += " and substring(component_no, 1, 3) = @year";
        dao.setParam("@year", sYear);

        if (!string.IsNullOrEmpty(car_type_keyword))
        {
            where += " and car_type like @car_type_keyword ";
            dao.setParam("@car_type_keyword", "%" + car_type_keyword + "%");
        }
        if (!string.IsNullOrEmpty(sCarType))
        {
            where += " and car_type like @car_type ";
            dao.setParam("@car_type",  "%"+sCarType+ "%" );
        }
        if (!string.IsNullOrEmpty(sCode))
        {
            where += " and component_code = @component_code ";
            dao.setParam("@component_code", sCode);
        }
        if (!string.IsNullOrEmpty(sComponentKeyword))
        {
            where += " and (component_name like @component_name or component_no like @component_no ) ";
            dao.setParam("@component_name", "%" + sComponentKeyword + "%");
            dao.setParam("@component_no", "%" + sComponentKeyword + "%");
        }

        sql = sql + where + " order by PVALUE ";
        dao.CommandSQL = sql;
        return dao.search();
    }
    public ArrayList selectComponentno(String sYear, String car_type_keyword)
    {
        String sql = "select component_no as PVALUE, component_no + '(' + cast(component_name AS NVARCHAR(20)) + ')' as PTEXT, component_no, " +
            "component_code, component_name, " +
            "component_spec, count, budget1, budget2, budget3, budget4 " +
            "from e_component_mst ";
        string where = "where 1=1";
        where += " and substring(component_no, 1, 3) = @year";
        dao.setParam("@year", sYear);

        if (!string.IsNullOrEmpty(car_type_keyword))
        {
            where += " and car_type like @car_type_keyword ";
            dao.setParam("@car_type_keyword", "%"+car_type_keyword+"%");
        }
     
      

        sql = sql + where + " order by PVALUE ";
        dao.CommandSQL = sql;
        return dao.search();
    }
    public ArrayList selectComponentno(String sYear, String sCarType, String sComponentKeyword)
    {
        String sql = "select component_no as PVALUE, component_no + '(' + cast(component_name AS NVARCHAR(20)) + ')' as PTEXT, component_no, " +
            "component_code, component_name, " +
            "component_spec, count, budget1, budget2, budget3, budget4 " +
            "from e_component_mst ";
        string where = "where 1=1";
        where += " and substring(component_no, 1, 3) = @year";

        dao.setParam("@year", sYear);

        if (!string.IsNullOrEmpty(sCarType))
        {
            where += " and car_type like @car_type ";
            dao.setParam("@car_type", "%"+ sCarType+"%");
        }

        if (!string.IsNullOrEmpty(sComponentKeyword))
        {
            where += " and component_name like @component_name ";
            dao.setParam("@component_name", "%" + sComponentKeyword + "%");
        }


        sql = sql + where + " order by PVALUE ";
        dao.CommandSQL = sql;
        return dao.search();
    }
    #endregion //新增"適用車種排序"_wenny1061212
    public ArrayList selectComponentSource(String sYear)
    {
        String sql = "select component_no as PVALUE, component_no + '(' + cast(component_name AS NVARCHAR(20)) + ')' as PTEXT, component_no, " +
            "component_code, component_name, " +
            "component_spec, count, budget1, budget2, budget3, budget4 " +
            "from e_component_mst " +
            "where substring(component_no, 1, 3) = @year";

        dao.setParam("@year", sYear);
        dao.CommandSQL = sql;
        return dao.search();
    }


    public String getLatestYear()
    {
        String sRetValue = "";
        String sql = "select MAX(substring(component_no, 1, 3)) as year from e_component_mst";

        dao.CommandSQL = sql;

        ArrayList al = dao.search();
        if (al.Count == 1)
        {
            Hashtable ht = (Hashtable)al[0];
            sRetValue =  ht["YEAR"].ToString();
        }

        return sRetValue;
    }
    

    /// <summary>
    /// 取得零件代碼
    /// </summary>
    /// <param name="component_no"></param>
    /// <returns></returns>
    public String getComponentCode(String component_no)
    {
        String sRetValue = "";
        String sql = @"select component_code from e_component_mst where component_no = @component_no";

         dao.CommandSQL = sql;

         dao.setParam("@component_no", component_no);

         DataSet ds = dao.searchForDS();

         if (ds.Tables[0].Rows.Count == 1)
             sRetValue = ds.Tables[0].Rows[0]["component_code"].ToString();

         return sRetValue;
    }
    public DataSet selectChg(String notify_item, string crs_org)
    {
        String sql = @"select User1,     A.[Thing],sum(Count) as Count from [TDOS].[dbo].[Stock]   a where a.status='O'    and Thing like @notify_item and User1=@crs_org
			    group by  User1,[Thing]                 ";

        dao.CommandSQL = sql;
        dao.setParam("@notify_item", notify_item);
        dao.setParam("@crs_org", crs_org);

        return dao.searchForDS();
    }

    #region 匯出EXCEL_wenny1061128
    /// <summary>
    /// 匯出EXCEL_wenny1061128
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList export(Form form)
    {
        String sql = "select component_no, component_name, component_spec, component_code, car_type, unit, budget1, budget2, budget3, budget4, memo " +
            "from e_component_mst";

        String where = " where 1=1";

        if (!form.getValue("component_no").Equals(""))
        {
            where += " and component_no like @component_no";
            dao.setParam("@component_no", "%" + form.getValue("component_no") + "%");
        }

        if (!form.getValue("component_name").Equals(""))
        {
            where += " and component_name like @component_name";
            dao.setParam("@component_name", "%" + form.getValue("component_name") + "%");
        }

        if (!form.getValue("component_spec").Equals(""))
        {
            where += " and component_spec like @component_spec";
            dao.setParam("@component_spec", "%" + form.getValue("component_spec") + "%");
        }

        if (!form.getValue("component_code").Equals(""))
        {
            where += " and component_code like @component_code";
            dao.setParam("@component_code", "%" + form.getValue("component_code") + "%");
        }

        //if (!form.getValue("budget_start").Equals(""))
        //{
        //    where += " and budget  >= @budget_start";
        //    pb.setParam("@budget_start", form.getValue("budget_start"));
        //}

        //if (!form.getValue("budget_end").Equals(""))
        //{
        //    where += " and budget <= @budget_end";
        //    pb.setParam("@budget_end", form.getValue("budget_end"));
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            //where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
            where += " and car_type like @car_type";
            dao.setParam("@car_type", "%" + form.getValue("car_type") + "%");
        }

        if (!form.getValue("report_year").Equals(""))
        {
            where += " and substring(component_no, 1, 3) = @report_year";
            dao.setParam("@report_year", form.getValue("report_year"));
        }




 
        sql = sql + where + " order by component_no ";

        dao.CommandSQL = sql;

        return dao.search();
    }

    #endregion
}