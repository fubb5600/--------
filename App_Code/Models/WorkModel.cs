using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// WorkModel 的摘要描述
/// </summary>
public class WorkModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse1_work_date"))
        {
            browse1_work_date(pb, form);

        }
        else if (pbKey.Equals("browse1_work_start"))
        {
            browse1_work_start(pb, form);

        }
        else if (pbKey.Equals("browse1_work_end"))
        {
            browse1_work_end(pb, form);

        }
        else if (pbKey.Equals("browse1_work_type"))
        {
            browse1_work_type(pb, form);

        }
        else if (pbKey.Equals("browse1_card_no"))
        {
            browse1_card_no(pb, form);

        }
        else if (pbKey.Equals("browse1_work_object"))
        {
            browse1_work_object(pb, form);

        }
        else if (pbKey.Equals("browse1_mileage_s"))
        {
            browse1_mileage_s(pb, form);

        }
        else if (pbKey.Equals("browse1_work_org"))
        {
            browse1_work_org(pb, form);

        }
        //反排
        else if (pbKey.Equals("browse1d"))
        {
            browsed(pb, form);
        }
        else if (pbKey.Equals("browse1_work_dated"))
        {
            browse1_work_dated(pb, form);

        }
        else if (pbKey.Equals("browse1_work_startd"))
        {
            browse1_work_startd(pb, form);

        }
        else if (pbKey.Equals("browse1_work_endd"))
        {
            browse1_work_endd(pb, form);

        }
        else if (pbKey.Equals("browse1_work_typed"))
        {
            browse1_work_typed(pb, form);

        }
        else if (pbKey.Equals("browse1_card_nod"))
        {
            browse1_card_nod(pb, form);

        }
        else if (pbKey.Equals("browse1_work_objectd"))
        {
            browse1_work_objectd(pb, form);

        }
        else if (pbKey.Equals("browse1_mileage_sd"))
        {
            browse1_mileage_sd(pb, form);

        }
        else if (pbKey.Equals("browse1_work_orgd"))
        {
            browse1_work_orgd(pb, form);

        }
        //wenny_test_排序
    }

    /// <summary>
    /// 勤務記錄資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

       
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            // 可索引的日期範圍條件：區間重疊（含日期不含時間）
            where += " and a.work_end >= @start_date and a.work_start < DATEADD(day, 1, @end_date)";
            pb.setParam("@start_date", DateTime.Parse(DateTransfer.c_date_trans(form.getValue("work_str"))));
            pb.setParam("@end_date", DateTime.Parse(DateTransfer.c_date_trans(form.getValue("work_end"))));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            // 起日（含當日 00:00）之後
            where += " and a.work_start >= @start_date";
            pb.setParam("@start_date", DateTime.Parse(DateTransfer.c_date_trans(form.getValue("work_str"))));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            // 迄日（含當日）以前
            where += " and a.work_end < DATEADD(day, 1, @end_date)";
            pb.setParam("@end_date", DateTime.Parse(DateTransfer.c_date_trans(form.getValue("work_end"))));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and a.work_date >= @work_date_str ";
            pb.setParam("@work_date_str", DateTime.Parse(DateTransfer.c_date_trans(form.getValue("work_date_str"))));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and a.work_date < DATEADD(day, 1, @work_date_end) ";
            pb.setParam("@work_date_end", DateTime.Parse(DateTransfer.c_date_trans(form.getValue("work_date_end"))));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no, work_start desc, work_end desc";
    }
    //wenny_test_排序
    //正排
    private void browse1_work_date(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_date";
    }
    private void browse1_work_start(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_start";
    }
    private void browse1_work_end(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_end";
    }
    private void browse1_work_type(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_type";
    }
    private void browse1_card_no(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no";
    }
    private void browse1_work_object(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_object";
    }
    private void browse1_mileage_s(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "mileage";
    }
    private void browse1_work_org(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_org";
    }
    //反排
    private void browsed(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no desc, work_start desc, work_end desc";
    }
    private void browse1_work_dated(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_date desc";
    }
    private void browse1_work_startd(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_start desc";
    }
    private void browse1_work_endd(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_end desc";
    }
    private void browse1_work_typed(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_type desc";
    }
    private void browse1_card_nod(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no desc";
    }
    private void browse1_work_objectd(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_object desc";
    }
    private void browse1_mileage_sd(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "mileage desc";
    }
    private void browse1_work_orgd(PageBreak pb, Form form)
    {
        String sql = "select d.id_name as work_type, a.work_id, dbo.chineseDate(a.work_date) as work_date, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, e.card_no, c.id_name as work_org, " +
            "case when work_type ='C' then b.car_no else f.id_name end as work_object, " +
            "case when work_type='C' then convert( varchar(15), mileage_start) +'~'+ convert( varchar(15), mileage_end) else '' end as mileage " +
            "from v_work a " +
            "left join a_sysparam_data c on a.work_org = c.param_id and c.param_type='DEP_ORG' " +
            "left join a_sysparam_data d on a.work_type = d.param_id and d.param_type='WORK_TYPE' " +
            "left join c_card_mst e on a.card_id = e.card_id " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join a_sysparam_data f on a.work_machine = f.param_id and f.param_type='MACHINE'  ";

        String where = "where 1=1";

        if (!form.getValue("work_type").Equals(""))
        {
            where += " and a.work_type in (" + handleMultiData("work_type", form.getValue("work_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and e.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("work_org").Equals(""))
        {
            where += " and a.work_org in (" + handleMultiData("work_org", form.getValue("work_org"), pb) + ")";
        }

        if (!form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) >= @start_date  and " +
                "convert(varchar(10) , a.work_start, 111 )  <= @end_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }
        else if (!form.getValue("work_str").Equals("") && form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_start, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("work_str")));
        }
        else if (form.getValue("work_str").Equals("") && !form.getValue("work_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_end, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("work_end")));
        }

        if (!form.getValue("work_machine").Equals(""))
        {
            where += " and a.work_machine in (" + handleMultiData("work_machine", form.getValue("work_machine"), pb) + ")";
        }

        if (!form.getValue("work_date_str").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) >= @work_date_str ";

            pb.setParam("@work_date_str", DateTransfer.c_date_trans(form.getValue("work_date_str")));
        }

        if (!form.getValue("work_date_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.work_date, 111 ) <= @work_date_end ";

            pb.setParam("@work_date_end", DateTransfer.c_date_trans(form.getValue("work_date_end")));
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_org desc";
    }

    //wenny_test_排序



    /// <summary>
    /// 新增勤務記錄
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertWork(Form form)
    {
        String sql = "insert into c_work_mst (work_type, card_id, car_id, work_machine, work_start, work_end, " +
             "mileage_start, mileage_end, mileage, mileage_key, work_org, mileage_rsn, work_man, work_area, " +
             "work_location, work_item, memo, create_date, create_user, update_date, update_user, car_count,CAR,yesno,location,PASSENGERS,ADM_DISTRICT,DSPH_CAUSE,MOD_DEPNAME,MOD_USERNAME,MILS,ATU_USER,OPStatus) " +
             "values (@work_type, @card_id, @car_id, @work_machine, @work_start, @work_end, @mileage_start, " +
             "@mileage_end, @mileage, @mileage_key, @work_org, @mileage_rsn, @work_man, @work_area, " +
             "@work_location, @work_item, @memo, GETDATE(), @create_user, GETDATE(), @create_user, @car_count,@car_type1,@yesno,@location,@PASSENGERS,@ADM_DISTRICT,@DSPH_CAUSE,@MOD_DEPNAME,@MOD_USERNAME,@MILS,@ATU_USER,@OPStatus)";

        dao.CommandSQL = sql;

        dao.setParam("@PASSENGERS", form.getValue("PASSENGERS"));

        dao.setParam("@ADM_DISTRICT", form.getValue("ADM_DISTRICT"));
        dao.setParam("@DSPH_CAUSE", form.getValue("DSPH_CAUSE"));

        dao.setParam("@MOD_DEPNAME", form.getValue("MOD_DEPNAME"));
        dao.setParam("@MOD_USERNAME", form.getValue("MOD_USERNAME"));



   
        dao.setParam("@MILS", form.getValue("MILS"));
        dao.setParam("@ATU_USER", form.getValue("ATU_USER"));
        dao.setParam("@OPStatus", form.getValue("OPStatus"));

        dao.setParam("@yesno", form.getValue("yesno"));
        dao.setParam("@location", form.getValue("location"));

        dao.setParam("@car_type1", form.getValue("car_type1"));
        dao.setParam("@work_type", form.getValue("work_type"));
        dao.setParam("@card_id", form.getValue("card_id"));
        if (form.getValue("car_Id") != string.Empty)
        {
            dao.setParam("@car_id", form.getValue("car_id"));
        }
        else
        {
            dao.setParam("@car_id", DBNull.Value);
        }
        dao.setParam("@work_machine", form.getValue("work_machine"));
        dao.setParam("@work_start", form.getValue("work_start"));
        dao.setParam("@work_end", form.getValue("work_end"));
        dao.setParam("@work_org", form.getValue("work_org"));
        dao.setParam("@mileage_start", form.getValue("mileage_start"));
        dao.setParam("@mileage_end", form.getValue("mileage_end"));
        dao.setParam("@mileage", form.getValue("mileage"));
        if (form.getValue("mileage_key") != string.Empty)
        {
            dao.setParam("@mileage_key", form.getValue("mileage_key"));
        }
        else
        {
            dao.setParam("@mileage_key", DBNull.Value);
        }
        if (form.getValue("work_type") == "C")
        {
            dao.setParam("@car_count", form.getValue("car_count"));
        }
        else
        {
            dao.setParam("@car_count", DBNull.Value);
        }
        dao.setParam("@mileage_rsn", form.getValue("mileage_rsn"));
        dao.setParam("@work_man", form.getValue("work_man"));
        dao.setParam("@work_area", form.getValue("work_area"));
        dao.setParam("@work_location", form.getValue("work_location"));
        dao.setParam("@work_item", form.getValue("work_item"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 新增勤務記錄之勤務日期
    /// </summary>
    /// <param name="form"></param>
    public void insertWorkDate(Form form)
    {
        String sql = "insert into c_work_date (work_id, card_id, car_id, work_date) " +
            "values (@work_id, @card_id, @car_id, @work_date)";

        dao.CommandSQL = sql;

        dao.setParam("@work_id", form.getValue("work_id"));
        dao.setParam("@card_id", form.getValue("card_id"));

        if (form.getValue("car_id") != string.Empty)
        {
            dao.setParam("@car_id", form.getValue("car_id"));
        }
        else
        {
            dao.setParam("@car_id", DBNull.Value);
        }

        dao.setParam("@work_date", form.getValue("work_date"));

        dao.executeModify();
    }


    /// <summary>
    /// 刪除勤務記錄之勤務日期
    /// </summary>
    /// <param name="work_id"></param>
    public void deleteWorkDate(String work_id)
    {
        String sql = "delete c_work_date where work_id=@work_id";

        dao.CommandSQL = sql;
        dao.setParam("@work_id", work_id);
        dao.executeModify();
    }



    /// <summary>
    /// 查詢勤務記錄明細
    /// </summary>
    /// <param name="car_id"></param>
    /// <returns></returns>
    public DataSet selectWork(String work_id)
    {
        String sql = "select car,a.work_id, a.work_type, a.card_id, a.work_machine,a.work_org, a.car_count, " +
            "dbo.chineseDateTime(a.work_start) as work_start, " +
            "dbo.chineseDateTime(a.work_end) as work_end, a.mileage_start, a.mileage_end, a.mileage, a.mileage_key, " +
            "a.mileage_rsn, a.work_man, a.work_area, a.work_location, a.work_item, a.memo, dbo.chineseDate(b.work_date) as work_date,CAR,yesno,location " +
            ", ADM_DISTRICT, DSPH_CAUSE, PASSENGERS, MOD_USERNAME, MOD_DEPNAME, DISTINATION, MILS, WriteDriveRecord, OPStatus, ATU_USER " +


            "from c_work_mst a " +
            "left join c_work_date b on a.work_id=b.work_id " +
            "where a.work_id = @work_id";

        dao.CommandSQL = sql;
        dao.setParam("@work_id", work_id);
        return dao.searchForDS();
    }


    /// <summary>
    /// 修改勤務記錄
    /// </summary>
    /// <param name="form"></param>
    public void updateWork(Form form)
    {
        String sql = "update c_work_mst set card_id=@card_id, car_id=@car_id, work_type=@work_type, " +
              "work_machine=@work_machine, work_start=@work_start, work_end=@work_end, car_count=@car_count, " +
              "work_org=@work_org, mileage_start=@mileage_start, mileage_end=@mileage_end, mileage=@mileage, " +
              "mileage_key=@mileage_key, mileage_rsn=@mileage_rsn, work_man=@work_man, work_area=@work_area,car=@car_type1 ," +
                "PASSENGERS=@PASSENGERS,ADM_DISTRICT=@ADM_DISTRICT,DSPH_CAUSE=@DSPH_CAUSE,MOD_DEPNAME=@MOD_DEPNAME,MOD_USERNAME=@MOD_USERNAME,ATU_USER=@ATU_USER,MILS=@MILS,OPStatus='1'," +
              "work_location=@work_location, work_item=@work_item, memo=@memo, " +
              "update_date=GETDATE(), update_user=@update_user,yesno=@yesno,location=@location ";

        sql = sql + " where work_id=@work_id";


        dao.CommandSQL = sql;
        
        dao.setParam("@PASSENGERS", form.getValue("PASSENGERS"));
        
        dao.setParam("@ADM_DISTRICT", form.getValue("ADM_DISTRICT"));
        dao.setParam("@DSPH_CAUSE", form.getValue("DSPH_CAUSE"));

        dao.setParam("@MOD_DEPNAME", form.getValue("MOD_DEPNAME"));
        dao.setParam("@MOD_USERNAME", form.getValue("MOD_USERNAME"));



        dao.setParam("@yesno", form.getValue("yesno"));
        dao.setParam("@location", form.getValue("location"));
        dao.setParam("@MILS", form.getValue("MILS"));
        dao.setParam("@ATU_USER", form.getValue("ATU_USER"));
 



        dao.setParam("@car_type1", form.getValue("car_type1"));

        dao.setParam("@work_id", form.getValue("work_id"));
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@work_type", form.getValue("work_type"));
        dao.setParam("@work_machine", form.getValue("work_machine"));
        dao.setParam("@work_start", form.getValue("work_start"));
        dao.setParam("@work_end", form.getValue("work_end"));
        dao.setParam("@work_org", form.getValue("work_org"));
        dao.setParam("@mileage_start", form.getValue("mileage_start"));
        dao.setParam("@mileage_end", form.getValue("mileage_end"));
        dao.setParam("@mileage", form.getValue("mileage"));
        if (form.getValue("mileage_key") != string.Empty)
        {
            dao.setParam("@mileage_key", form.getValue("mileage_key"));
        }
        else
        {
            dao.setParam("@mileage_key", DBNull.Value);
        }
        if (form.getValue("work_type") == "C")
        {
            dao.setParam("@car_count", form.getValue("car_count"));
        }
        else
        {
            dao.setParam("@car_count", DBNull.Value);
        }
        dao.setParam("@mileage_rsn", form.getValue("mileage_rsn"));
        dao.setParam("@work_man", form.getValue("work_man"));
        dao.setParam("@work_area", form.getValue("work_area"));
        dao.setParam("@work_location", form.getValue("work_location"));
        dao.setParam("@work_item", form.getValue("work_item"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 刪除勤務記錄
    /// </summary>
    /// <param name="card_id"></param>
    public void deleteWork(String work_id ,String car_type )
    {
        String sql = "";
          if(car_type=="A1:特種汽車"||car_type=="A2:特業汽車")
		  {
			          sql = "update c_work_mst    set OPStatus='-1'where work_id=@work_id";

			  
		  }
		  

		  else
		  
		  {
			  			  sql = "delete  c_work_mst    where work_id=@work_id";


		  }
		  
		  

		  
		  
        dao.CommandSQL = sql;
        dao.setParam("@work_id", work_id);
        dao.executeModify();
    }

    /// <summary>
    /// 刪除勤務記錄
    /// </summary>
    /// <param name="card_id"></param>
    public void deleteWork2(String work_id ,String car_type )
    {
        String sql = "";
        
			          sql = "delete from  c_work_mst   where work_id=@work_id";

			  
		 

		  
		  
        dao.CommandSQL = sql;
        dao.setParam("@work_id", work_id);
        dao.executeModify();
    }



    /// <summary>
    /// 刪除勤務記錄對應的用油資料
    /// </summary>
    /// <param name="work_id"></param>
    public void deleteFuelUse(String work_id)
    {
        String sql = "delete b_fuel_use where work_id=@work_id";

        dao.CommandSQL = sql;
        dao.setParam("@work_id", work_id);
        dao.executeModify();
    }


    /// <summary>
    /// 取得最近一次勤務的里程數(迄)
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public String checkMileage(Form form)
    {
        String mileage_end = string.Empty;
        String sql = "select top(1) * from c_work_mst where card_id= @card_id and " +
            "work_end <= @work_start order by work_end desc";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@work_start", form.getValue("work_start"));
        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            mileage_end = dr["mileage_end"].ToString();
        }

        return mileage_end;
    }


    /// <summary>
    /// 統計當月車次里程數等資料
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public DataSet SumThisMonthCarWork(Form form)
    {
        String mileage_end = string.Empty;
        String sql = "select sum(car_count) as sum_times, sum(mileage) as sum_mileage, " +
            "b.work_day as sum_days from c_work_mst a " +
            "left join (select COUNT(*) as work_day, c.card_id from ( " +
            "select distinct work_date as work_day, card_id from c_work_date where " +
            "card_id= @card_id and convert(varchar(10), work_date, 111) >= @work_start " +
            "and convert(varchar(10), work_date, 111) <= @work_end) c " +
            "group by c.card_id) b on a.card_id = b.card_id " + 
            "left join c_work_date c on a.work_id = c.work_id and a.car_id = c.car_id " +
            "where a.card_id = @card_id and convert(varchar(10), c.work_date, 111) >= @work_start " +
            "and convert(varchar(10), c.work_date, 111) <= @work_end " +
            "group by work_day";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@work_start", form.getValue("work_start"));
        dao.setParam("@work_end", form.getValue("work_end"));

        return dao.searchForDS();
    }


    /// <summary>
    /// 取得上一次的勤務記錄
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public DataSet getLastWork(Form form)
    {
        String sql = "select top(1) * from c_work_mst where work_type= @work_type and " +
            "create_user = @user_id order by create_date desc";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", form.getValue("user_id"));
        dao.setParam("@work_type", form.getValue("work_type"));

        return dao.searchForDS();
    }


    /// <summary>
    /// 檢核勤務記錄是否重複輸入
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public DataSet IsExistWorkMst(Form form)
    {
        String sql = "select dbo.chineseDateTime(work_start) as work_start,  " +
            "dbo.chineseDateTime(work_end) as work_end from c_work_mst where work_type= @work_type and " +
            "work_start <= @work_end and work_end >= @work_start and car_id= @car_id ";


        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@work_start", form.getValue("work_start"));
        dao.setParam("@work_end", form.getValue("work_end"));
        dao.setParam("@work_type", form.getValue("work_type"));

        if (form.getValue("work_id") != string.Empty)
        {
            sql += "and work_id <> @work_id ";
            dao.setParam("@work_id", form.getValue("work_id"));
        }

        dao.CommandSQL = sql;

        return dao.searchForDS();
    }


    /// <summary>
    /// 取得車隊卡在某時間上對應的車輛
    /// </summary>
    /// <param name="card_id"></param>
    /// <param name="target_date"></param>
    /// <returns></returns>
    public DataSet GetCarByCard(String card_id, String target_date)
    {
        String sql = "select car_id from c_car_card where card_id=@card_id and convert(varchar(10), possess_start, 111) <=@target_date and " +
            " (convert(varchar(10), possess_end, 111) >=@target_date or possess_end is null) ";

        dao.setParam("@card_id", card_id);
        dao.setParam("@target_date", target_date);
        dao.CommandSQL = sql;      

        return dao.searchForDS();
    }


    /// <summary>
    /// 取得作業項目兩階層名稱
    /// </summary>
    /// <param name="work_type"></param>
    /// <param name="work_items"></param>
    /// <returns></returns>
    public String getWorkItemText(String work_type, String work_items)
    {
        Mediator med = Mediator.getInstance(false);
        String work_item_text = "";       

        String sql = @"select a.param_id, b.id_name + '-' + a.id_name as work_item from a_sysparam_data a 
              left join a_sysparam_data b on a.param_type = b.param_id 
            where substring(a.param_type, 1, 5) = @work_type and a.param_id in(" + handleMultiData("work_item", work_items) + ")";

        dao.setParam("@work_type", work_type.ToUpper() + "ITEM");
        dao.CommandSQL = sql;

        DataSet ds = dao.searchForDS();       

        string[] items = work_items.Split(',');

        for (int i = 0; i < items.Length; i++)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                DataRow dr = ds.Tables[0].Rows[j];
                if (dr["param_id"].ToString().Equals(items[i]))
                    work_item_text += dr["work_item"].ToString() + ",";
            }
        }

        if (work_item_text.Length > 0)
            work_item_text = work_item_text.Substring(0, work_item_text.Length - 1);

        return work_item_text;
    }
}