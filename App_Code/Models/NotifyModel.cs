using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

/// <summary>
/// NotifyModel 的摘要描述
/// </summary>
public class NotifyModel:Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse1dep_no"))
        {
            browse1dep_no(pb, form);
        }
        else if (pbKey.Equals("browse1car_no"))
        {
            browse1car_no(pb, form);
        }
        else if (pbKey.Equals("browse1keep_org"))
        {
            browse1keep_org(pb, form);
        }
        else if (pbKey.Equals("browse1car_type"))
        {
            browse1car_type(pb, form);
        }
        else if (pbKey.Equals("browse1work_no"))
        {
            browse1work_no(pb, form);
        }
        else if (pbKey.Equals("browse1notify_date"))
        {
            browse1notify_date(pb, form);
        }
        else if (pbKey.Equals("browse1finish_date"))
        {
            browse1finish_date(pb, form);
        }
        else if (pbKey.Equals("browse1notify_item"))
        {
            browse1notify_item(pb, form);
        }
        else if (pbKey.Equals("browse1repair_type_s"))
        {
            browse1repair_type_s(pb, form);
        }
        else if (pbKey.Equals("browse1repair_status_s"))
        {
            browse1repair_status_s(pb, form);
        }
        //反排
        if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);
        }
        else if (pbKey.Equals("browse1dep_nod"))
        {
            browse1dep_nod(pb, form);
        }
        else if (pbKey.Equals("browse1car_nod"))
        {
            browse1car_nod(pb, form);
        }
        else if (pbKey.Equals("browse1keep_orgd"))
        {
            browse1keep_orgd(pb, form);
        }
        else if (pbKey.Equals("browse1car_typed"))
        {
            browse1car_typed(pb, form);
        }
        else if (pbKey.Equals("browse1work_nod"))
        {
            browse1work_nod(pb, form);
        }
        else if (pbKey.Equals("browse1notify_dated"))
        {
            browse1notify_dated(pb, form);
        }
        else if (pbKey.Equals("browse1finish_dated"))
        {
            browse1finish_dated(pb, form);
        }
        else if (pbKey.Equals("browse1notify_itemd"))
        {
            browse1notify_itemd(pb, form);
        }
        else if (pbKey.Equals("browse1repair_type_sd"))
        {
            browse1repair_type_sd(pb, form);
        }
        else if (pbKey.Equals("browse1repair_status_sd"))
        {
            browse1repair_status_sd(pb, form);
        }
        //wenny_test_排序

    }


    private string sqlstr(PageBreak pb, Form form) {
        //String sql = "select a.notify_id, a.car_id, a.crs_org, a.work_no, convert(varchar(10), notify_date, 111) as notify_date, " +
        //    "convert(varchar(10), a.finish_date, 111) as finish_date, a.notify_item, " +
        //    "b.dep_no, b.car_no, b.keep_org, a.repair_type1, a.repair_type2, a.repair_type3, a.repair_status, b.car_type from f_notify_mst a " +
        //    "left join v_car b on a.car_id = b.car_id ";    

        String sql = "select a.notify_type, a.notify_id, a.car_id, a.crs_org, a.work_no, convert(varchar(10), notify_date, 111) as notify_date, " +
            "convert(varchar(10), a.finish_date, 111) as finish_date, a.notify_item, case when notify_type = 'C' then b.dep_no else machine_no end as dep_no, " +
            "case when notify_type = 'C' then b.car_no else '-' end as car_no, b.keep_org, a.repair_type1, a.repair_type2, a.repair_type3, a.repair_status, " +
            "case when notify_type = 'C' then b.car_type else a.machine_type end as car_type from f_notify_mst a " +
            "left join v_car b on a.car_id = b.car_id ";

        String where = "where 1=1";

        if (!form.getValue("notify_type").Equals(""))
        {
            where += " and a.notify_type in (" + handleMultiData("notify_type", form.getValue("notify_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and (b.dep_no like @dep_no or a.machine_no like @dep_no)";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("repair_vender").Equals(""))
        {
            where += " and a.repair_vender like @repair_vender";
            pb.setParam("@repair_vender", "%" + form.getValue("repair_vender") + "%");
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.notify_date, 111 ) >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.notify_date, 111 ) <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }

        if (!form.getValue("work_no").Equals(""))
        {
            where += " and a.work_no like @work_no";
            pb.setParam("@work_no", "%" + form.getValue("work_no") + "%");
        }

        if (!form.getValue("repair_type1").Equals(""))
        {
            where += " and a.repair_type1 = @repair_type1";
            pb.setParam("@repair_type1", form.getValue("repair_type1"));
        }

        if (!form.getValue("repair_type2").Equals(""))
        {
            where += " and a.repair_type2 = @repair_type2";
            pb.setParam("@repair_type2", form.getValue("repair_type2"));
        }

        if (!form.getValue("repair_type3").Equals(""))
        {
            where += " and a.repair_type3 = @repair_type3";
            pb.setParam("@repair_type3", form.getValue("repair_type3"));
        }

        if (!form.getValue("repair_status").Equals(""))
        {
            where += " and a.repair_status in (" + handleMultiData("repair_status", form.getValue("repair_status"), pb) + ")";
        }

        if (!form.getValue("finish_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.finish_date, 111 ) >= @finish_start";
            pb.setParam("@finish_start", DateTransfer.c_date_trans(form.getValue("finish_start")));
        }

        if (!form.getValue("finish_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.finish_date, 111 ) <= @finish_end";
            pb.setParam("@finish_end", DateTransfer.c_date_trans(form.getValue("finish_end")));
        }
        //2018/09/03新增報修內容關鍵字查詢
        if (!form.getValue("notify_item").Equals(""))
        {
            where += " and a.notify_item like @notify_item";
            pb.setParam("@notify_item", "%" + form.getValue("notify_item") + "%");
        }
        //2018/09/03新增報修內容關鍵字查詢
        if (form.getValue("crs_org").Equals("AT"))
        {
            where += "and a.crs_org in (select param_id from a_sysparam_data where param_type = 'DEP_ORG' " +
                "and status = 'O' and param_id not in(select param_id from a_sysparam_data " +
                "where param_type = 'CRS_ORG'))";
        }
        else
        {

            where += " and a.crs_org in (" + handleMultiData("crs_org", form.getValue("crs_org"), pb) + ")";

        }

        sql = sql + where;
        return sql;
    }


    private void browse(PageBreak pb, Form form)
    {

        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "notify_id desc";
        //pb.OrderSQL = "notify_id ";
    }
    //wenny_test_排序
    //正排
    private void browse1dep_no(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "dep_no ";
    }
    private void browse1car_no(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no ";
    }
    private void browse1keep_org(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "keep_org ";
    }
    private void browse1car_type(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_type ";
    }
    private void browse1work_no(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_no ";
    }
    private void browse1notify_date(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "notify_date ";
    }
    private void browse1finish_date(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "finish_date ";
    }
    private void browse1notify_item(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "notify_item ";
    }
    private void browse1repair_type_s(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "repair_type1  ";
    }
    private void browse1repair_status_s(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "repair_status ";
    }
    //反排
    private void browse1d(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "notify_id desc";
    }
    private void browse1dep_nod(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "dep_no desc";
    }
    private void browse1car_nod(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no desc ";
    }
    private void browse1keep_orgd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "keep_org desc ";
    }
    private void browse1car_typed(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_type desc";
    }
    private void browse1work_nod(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "work_no desc";
    }
    private void browse1notify_dated(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "notify_date desc";
    }
    private void browse1finish_dated(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "finish_date desc";
    }
    private void browse1notify_itemd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "notify_item desc";
    }
    private void browse1repair_type_sd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "repair_type1 desc ";
    }
    private void browse1repair_status_sd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "repair_status desc";
    }
    //wenny_test_排序
    /// <summary>
    /// 新增報修資料
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public Decimal insertNotify(Form form)
    {
        String sql = "insert into f_notify_mst (notify_type, car_id, machine_type, machine_org, machine_no, crs_org, work_no, notify_date, work_man, mileage, " +
            "notify_item, repair_vender, repair_type1, repair_type2, repair_type3, repair_status, finish_date, driver, pickup_date, memo, create_date, create_user, " +
            "update_date, update_user) " +
            "values (@notify_type, @car_id, @machine_type, @machine_org, @machine_no, @crs_org, @work_no, @notify_date, @work_man, @mileage, " +
            "@notify_item, @repair_vender, @repair_type1, @repair_type2, @repair_type3, @repair_status, @finish_date, @driver, @pickup_date, @memo, " +
            "GETDATE(), @create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;

        dao.setParam("@notify_type", form.getValue("notify_type"));

        if(form.getValue("car_id") != string.Empty)
            dao.setParam("@car_id", form.getValue("car_id"));
        else
            dao.setParam("@car_id", DBNull.Value);

        if (form.getValue("machine_type") != string.Empty)
            dao.setParam("@machine_type", form.getValue("machine_type"));
        else
            dao.setParam("@machine_type", DBNull.Value);

        if (form.getValue("machine_org") != string.Empty)
            dao.setParam("@machine_org", form.getValue("machine_org"));
        else
            dao.setParam("@machine_org", DBNull.Value);

        if (form.getValue("machine_no") != string.Empty)
            dao.setParam("@machine_no", form.getValue("machine_no"));
        else
            dao.setParam("@machine_no", DBNull.Value);

        dao.setParam("@crs_org", form.getValue("crs_org"));
        dao.setParam("@work_no", form.getValue("work_no"));
        dao.setParam("@notify_date", form.getValue("notify_date"));
        dao.setParam("@work_man", form.getValue("work_man"));

        if (form.getValue("mileage") != string.Empty)
            dao.setParam("@mileage", form.getValue("mileage"));
        else
            dao.setParam("@mileage", DBNull.Value);

        dao.setParam("@notify_item", form.getValue("notify_item"));
        dao.setParam("@repair_vender", form.getValue("repair_vender"));
        dao.setParam("@repair_type1", form.getValue("repair_type1"));
        dao.setParam("@repair_type2", form.getValue("repair_type2"));
        if (form.getValue("repair_type3") != string.Empty)
            dao.setParam("@repair_type3", form.getValue("repair_type3"));
        else
            dao.setParam("@repair_type3", DBNull.Value);

        dao.setParam("@repair_status", form.getValue("repair_status"));

        if (form.getValue("finish_date") != string.Empty)
            dao.setParam("@finish_date", form.getValue("finish_date"));
        else
            dao.setParam("@finish_date", DBNull.Value);

        dao.setParam("@driver", form.getValue("driver"));
        if(form.getValue("pickup_date") != string.Empty)
            dao.setParam("@pickup_date", form.getValue("pickup_date"));
        else
            dao.setParam("@pickup_date", DBNull.Value);
        
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 查詢報修資料
    /// </summary>
    /// <param name="notify_id"></param>
    /// <returns></returns>
    public DataSet selectNotify(String notify_id)
    {
        String sql = "select a.notify_id, a.car_id, a.crs_org, a.work_no, dbo.chineseDateTime(a.notify_date) as notify_date, a.work_man, " +
            "mileage, notify_item, repair_vender, repair_type1, repair_type2, repair_type3, repair_status, dbo.chineseDateTime(a.finish_date) as finish_date, " +
            "driver, dbo.chineseDateTime(a.pickup_date) as pickup_date, a.memo, a.notify_type, a.machine_no, a.machine_type, a.machine_org, " +
            "b.dep_no, b.car_no, b.car_type, c.id_name as org_name, d.id_name as cartype_name " +
            "from f_notify_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join a_sysparam_data c on a.crs_org = c.param_id and c.param_type = 'DEP_ORG' " +
            "left join a_sysparam_data d on b.car_type = d.param_id and d.param_type = 'CAR_TYPE' " +
            "where a.notify_id = @notify_id ";

        dao.CommandSQL = sql;
        dao.setParam("@notify_id", notify_id);
        return dao.searchForDS();
    }


    /// <summary>
    /// 修改報修資料
    /// </summary>
    /// <param name="form"></param>
    public void updateNotify(Form form)
    {
        String sql = "update f_notify_mst set car_id=@car_id, machine_type = @machine_type, machine_org = @machine_org, machine_no = @machine_no, "  +
            "crs_org=@crs_org, work_no=@work_no, notify_date=@notify_date, work_man = @work_man, " +
            "mileage=@mileage, notify_item=@notify_item, repair_vender=@repair_vender, repair_type1=@repair_type1, repair_type2=@repair_type2, " +
            "repair_type3=@repair_type3, repair_status = @repair_status, finish_date = @finish_date, driver=@driver, pickup_date=@pickup_date, " +
            "memo=@memo, update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where notify_id=@notify_id";

        dao.CommandSQL = sql;
        dao.setParam("@notify_id", form.getValue("notify_id"));

        if (form.getValue("car_id") != string.Empty)
            dao.setParam("@car_id", form.getValue("car_id"));
        else
            dao.setParam("@car_id", DBNull.Value);

        if (form.getValue("machine_type") != string.Empty)
            dao.setParam("@machine_type", form.getValue("machine_type"));
        else
            dao.setParam("@machine_type", DBNull.Value);

        if (form.getValue("machine_org") != string.Empty)
            dao.setParam("@machine_org", form.getValue("machine_org"));
        else
            dao.setParam("@machine_org", DBNull.Value);

        if (form.getValue("machine_no") != string.Empty)
            dao.setParam("@machine_no", form.getValue("machine_no"));
        else
            dao.setParam("@machine_no", DBNull.Value);
       
        dao.setParam("@crs_org", form.getValue("crs_org"));
        dao.setParam("@work_no", form.getValue("work_no"));
        dao.setParam("@notify_date", form.getValue("notify_date"));
        dao.setParam("@work_man", form.getValue("work_man"));

        if (form.getValue("mileage") != string.Empty)
            dao.setParam("@mileage", form.getValue("mileage"));
        else
            dao.setParam("@mileage", DBNull.Value);

        dao.setParam("@notify_item", form.getValue("notify_item"));
        dao.setParam("@repair_vender", form.getValue("repair_vender"));
        dao.setParam("@repair_type1", form.getValue("repair_type1"));
        dao.setParam("@repair_type2", form.getValue("repair_type2"));
        if (form.getValue("repair_type3") != string.Empty)
            dao.setParam("@repair_type3", form.getValue("repair_type3"));
        else
            dao.setParam("@repair_type3", DBNull.Value);
        dao.setParam("@repair_status", form.getValue("repair_status"));

        if (form.getValue("finish_date") != string.Empty)
            dao.setParam("@finish_date", form.getValue("finish_date"));
        else
            dao.setParam("@finish_date", DBNull.Value);
        dao.setParam("@driver", form.getValue("driver"));
        if (form.getValue("pickup_date") != string.Empty)
            dao.setParam("@pickup_date", form.getValue("pickup_date"));
        else
            dao.setParam("@pickup_date", DBNull.Value);
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 刪除報修資料
    /// </summary>
    /// <param name="notify_id"></param>
    public void deleteNotify(String notify_id)
    {
        String sql = "delete f_notify_mst where notify_id=@notify_id";

        dao.CommandSQL = sql;
        dao.setParam("@notify_id", notify_id);
        dao.executeModify();
    }

    public String getWorkNo(String simple_no)
    {
        int work_no = 0;
        string sYYYY = DateTransfer.getNow("", DateTransfer.YYY);
        String sql = "select Max(CONVERT(int,substring(work_no,2,7))) as work_no from f_notify_mst where substring(work_no, 1, 1) = @simple_no";

        dao.CommandSQL = sql;      
        dao.setParam("@simple_no", simple_no);

        DataSet ds = dao.searchForDS();
        if(!ds.Tables[0].Rows[0]["work_no"].Equals(DBNull.Value))
        {
            work_no = int.Parse(ds.Tables[0].Rows[0]["work_no"].ToString());
        }

        if (work_no > 0)
            work_no += 1;
        else
            work_no = int.Parse(sYYYY + "0001");

        return simple_no + work_no.ToString();
    }

    public DataSet selectNotifyByWorkNo(String work_no, String login_user)
    {
        String sql = @"select distinct  a.notify_type, a.notify_id, a.car_id, a.crs_org, a.work_no, dbo.chineseDate(a.notify_date) as notify_date, 
            a.work_man, mileage, notify_item, repair_vender, repair_type1, repair_type2, repair_type3, driver, 
            dbo.chineseDateTime(a.pickup_date) as pickup_date, a.memo, 
            case when a.notify_type = 'C' then b.dep_no else a.machine_no end as dep_no, a.machine_type, a.machine_org, d.keep_org, 
            c.card_id, d.card_no as car_no, b.car_type, b.brand_no, f.status, f.status as car_status, g.case_no , h.year_cn, h.year_rp3 
            from f_notify_mst a 
            left join c_car_mst b on a.car_id = b.car_id 
            left join c_car_card c on a.car_id = c.car_id and convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), a.notify_date, 111) 
            and (case when convert(varchar(10), c.possess_end, 111) >= convert(varchar(10), a.notify_date, 111) then 1 when c.possess_end is null then 1 else 0 end )>0 
            left join c_card_mst d on c.card_id = d.card_id 
            left join c_keep_mst e on a.car_id = e.car_id and convert(varchar(10), e.keep_start, 111) <= convert(varchar(10), a.notify_date, 111) 
            and (case when convert(varchar(10), e.keep_end, 111) >= convert(varchar(10), a.notify_date, 111) then 1 
            when e.keep_end is null then 1 else 0 end ) >0 
            left join c_car_sts f on a.car_id = f.car_id and convert(varchar(10), f.exec_start, 111) <= convert(varchar(10), a.notify_date, 111) 
            and (case when convert(varchar(10), f.exec_end, 111) >= convert(varchar(10), a.notify_date, 111) then 1 
            when f.exec_end is null then 1 else 0 end ) >0 
            left join (select Max(substring(case_no, 2, 9)) as case_no, @work_no as work_no from f_repair_mst where work_no = @work_no) g on a.work_no = g.work_no 
            left join(select TOP(1) a.case_no as year_cn, b.repair_type3 as year_rp3, @work_no as work_no from f_repair_mst a 
            left join f_notify_mst b on a.work_no = b.work_no where a.create_user = @login_user order by a.create_date desc) h on a.work_no = h.work_no 
            where a.work_no = @work_no ";

        dao.CommandSQL = sql;
        dao.setParam("@work_no", work_no);
        dao.setParam("@login_user", login_user);
        return dao.searchForDS();
    }

    /// <summary>
    /// 列印車輛派修單資料來源
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList printNotifyPDF(Form form)
    {
        String sql = "select a.work_no, case when notify_type = 'C' then b.dep_no else a.machine_no end as dep_no, b.car_no, b.brand_no, a.mileage, " +
            "a.crs_org, a.notify_item, a.work_man, a.memo, a.repair_type1, " +
            "a.repair_type2, a.repair_type3, a.repair_vender, dbo.chineseDateTime(a.pickup_date) as pickup_date, " +
            "dbo.chineseDateTime(a.notify_date) as notify_date from f_notify_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id where 1=1 and a.notify_id in (" + handleMultiData("notify_id", form.getValue("notify_id")) + ")";

        dao.CommandSQL = sql;       
        
        return dao.search();
    }


    /// <summary>
    /// 派工人員下拉式選單資料來源
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList selectWorkMan(Form form)
    {
        String sql = "select distinct work_man as PVALUE, work_man as PTEXT from f_notify_mst " +
            "where create_user = @create_user or update_user = @create_user or notify_id = @notify_id " +
            "or crs_org = @crs_org order by PTEXT";

        dao.CommandSQL = sql;
        dao.setParam("@create_user", form.getValue("create_user"));
        dao.setParam("@notify_id", form.getValue("notify_id"));
        dao.setParam("@crs_org", form.getValue("crs_org"));

        return dao.search();
    }


    /// <summary>
    /// 駕駛下拉式選單資料來源
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList selectDriver(Form form)
    {
        String sql = "select distinct driver as PVALUE, driver as PTEXT from f_notify_mst " +
            "where create_user = @create_user or update_user = @create_user or notify_id = @notify_id " +
            "or crs_org = @crs_org order by PTEXT";

        dao.CommandSQL = sql;
        dao.setParam("@create_user", form.getValue("create_user"));
        dao.setParam("@notify_id", form.getValue("notify_id"));
        dao.setParam("@crs_org", form.getValue("crs_org"));

        return dao.search();
    }


    public ArrayList export(Form form)
    {
        String sql = "select a.notify_type, a.notify_id, a.car_id, a.crs_org, a.work_no, convert(varchar(10), notify_date, 111) as notify_date, " +
            "convert(varchar(10), a.finish_date, 111) as finish_date, a.notify_item, case when notify_type = 'C' then b.dep_no else machine_no end as dep_no, " +
            "case when notify_type = 'C' then b.car_no else '-' end as car_no, b.keep_org, a.repair_type1, a.repair_type2, a.repair_type3, a.repair_status, " +
            "case when notify_type = 'C' then b.car_type else a.machine_type end as car_type from f_notify_mst a " +
            "left join v_car b on a.car_id = b.car_id";

        String where = " where 1=1";

        if (!form.getValue("notify_type").Equals(""))
        {
            where += " and a.notify_type in (" + handleMultiData("notify_type", form.getValue("notify_type")) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            dao.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and (b.dep_no like @dep_no or a.machine_no like @dep_no)";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("repair_vender").Equals(""))
        {
            where += " and a.repair_vender like @repair_vender";
            dao.setParam("@repair_vender", "%" + form.getValue("repair_vender") + "%");
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.notify_date, 111 ) >= @start_date";
            dao.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.notify_date, 111 ) <= @end_date";
            dao.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }

        if (!form.getValue("work_no").Equals(""))
        {
            where += " and a.work_no like @work_no";
            dao.setParam("@work_no", "%" + form.getValue("work_no") + "%");
        }

        if (!form.getValue("repair_type1").Equals(""))
        {
            where += " and a.repair_type1 = @repair_type1";
            dao.setParam("@repair_type1", form.getValue("repair_type1"));
        }

        if (!form.getValue("repair_type2").Equals(""))
        {
            where += " and a.repair_type2 = @repair_type2";
            dao.setParam("@repair_type2", form.getValue("repair_type2"));
        }

        if (!form.getValue("repair_type3").Equals(""))
        {
            where += " and a.repair_type3 = @repair_type3";
            dao.setParam("@repair_type3", form.getValue("repair_type3"));
        }

        if (!form.getValue("repair_status").Equals(""))
        {
            where += " and a.repair_status in (" + handleMultiData("repair_status", form.getValue("repair_status")) + ")";
        }

        if (!form.getValue("finish_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.finish_date, 111 ) >= @finish_start";
            dao.setParam("@finish_start", DateTransfer.c_date_trans(form.getValue("finish_start")));
        }

        if (!form.getValue("finish_end").Equals(""))
        {
            where += " and convert(varchar(10) , a.finish_date, 111 ) <= @finish_end";
            dao.setParam("@finish_end", DateTransfer.c_date_trans(form.getValue("finish_end")));
        }

        if (!form.getValue("crs_org").Equals(""))
        {
            if (form.getValue("crs_org").Equals("AT"))
            {
                where += " and a.crs_org in (select param_id from a_sysparam_data where param_type = 'DEP_ORG' " +
                    "and status = 'O' and param_id not in(select param_id from a_sysparam_data " +
                    "where param_type = 'CRS_ORG'))";
            }
            else
            {
                where += " and a.crs_org in (" + handleMultiData("crs_org", form.getValue("crs_org")) + ")";
            }
        }

        sql = sql + where + " order by notify_id desc";

        dao.CommandSQL = sql;      

        return dao.search();
    }
}