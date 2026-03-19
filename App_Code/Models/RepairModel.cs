using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

/// <summary>
/// RepairModel 的摘要描述
/// </summary>
public class RepairModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }

        if (pbKey.Equals("browse2"))
        {
            browse1(pb, form);
        }
        if (pbKey.Equals("browse3"))
        {
            browse2(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse1crs_org_s"))
        {
            browse1crs_org_s(pb, form);

        }
        else if (pbKey.Equals("browse1dep_no"))
        {
            browse1dep_no(pb, form);

        }
        else if (pbKey.Equals("browse1car_no"))
        {
            browse1car_no(pb, form);

        }
        else if (pbKey.Equals("browse1car_type"))
        {
            browse1car_type(pb, form);
        }
        else if (pbKey.Equals("browse1case_no"))
        {
            browse1case_no(pb, form);
        }
        else if (pbKey.Equals("browse1work_no"))
        {
            browse1work_no(pb, form);
        }
        else if (pbKey.Equals("browse1repair_vender"))
        {
            browse1repair_vender(pb, form);
        }
        else if (pbKey.Equals("browse1check_result"))
        {
            browse1check_result(pb, form);
        }
        else if (pbKey.Equals("browse1notify_date"))
        {
            browse1notify_date(pb, form);
        }
        else if (pbKey.Equals("browse1finish_date"))
        {
            browse1finish_date(pb, form);
        }
        else if (pbKey.Equals("browse1total_price"))
        {
            browse1total_price(pb, form);
        }
        //反排
        else if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);

        }
        else if (pbKey.Equals("browse1crs_org_sd"))
        {
            browse1crs_org_sd(pb, form);

        }
        else if (pbKey.Equals("browse1dep_nod"))
        {
            browse1dep_nod(pb, form);

        }
        else if (pbKey.Equals("browse1car_nod"))
        {
            browse1car_nod(pb, form);

        }
        else if (pbKey.Equals("browse1car_typed"))
        {
            browse1car_typed(pb, form);
        }
        else if (pbKey.Equals("browse1case_nod"))
        {
            browse1case_nod(pb, form);
        }
        else if (pbKey.Equals("browse1work_nod"))
        {
            browse1work_nod(pb, form);
        }
        else if (pbKey.Equals("browse1repair_venderd"))
        {
            browse1repair_venderd(pb, form);
        }
        else if (pbKey.Equals("browse1check_resultd"))
        {
            browse1check_resultd(pb, form);
        }
        else if (pbKey.Equals("browse1notify_dated"))
        {
            browse1notify_dated(pb, form);
        }
        else if (pbKey.Equals("browse1finish_dated"))
        {
            browse1finish_dated(pb, form);
        }
        else if (pbKey.Equals("browse1total_priced"))
        {
            browse1total_priced(pb, form);
        }
        //wenny_test_排序

        //108/05/06
        else if (pbKey.Equals("browse1delivery_days"))
        {
            browse1delivery_days(pb, form);
        }
        else if (pbKey.Equals("browse1delivery_daysd"))
        {
            browse1delivery_daysd(pb, form);
        }
        else if (pbKey.Equals("browse1exec_deadline_s"))
        {
            browse1exec_deadline_s(pb, form);
        }
        else if (pbKey.Equals("browse1exec_deadline_sd"))
        {
            browse1exec_deadline_sd(pb, form);
        }



    }
    private void browse(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb,form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "repair_id desc";
        //pb.OrderSQL = "repair_id ";
    }
    private void browse1(PageBreak pb, Form form)
    {
        string sql = sqlstr1(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "ID desc";
        //pb.OrderSQL = "repair_id ";
    }


    private void browse2(PageBreak pb, Form form)
    {
        string sql = sqlstr2(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "User1 desc";
        //pb.OrderSQL = "repair_id ";
    }
    //wenny_test_排序
    //正排
    private void browse1crs_org_s(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "crs_org";
    }
    private void browse1dep_no(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "dep_no";
    }
    private void browse1car_no(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no";
    }
    private void browse1car_type(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "car_type";
    }
    private void browse1case_no(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "case_no";
    }
    private void browse1work_no(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "work_no";
    }
    private void browse1repair_vender(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "repair_vender";
    }
    private void browse1check_result(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "check_result";
    }
    private void browse1notify_date(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "notify_date";
    }
    private void browse1finish_date(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "finish_date";
    }
    private void browse1total_price(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "total_price";
    }
    //反排
    private void browse1d(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "repair_id desc";
    }
    private void browse1crs_org_sd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "crs_org desc";
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
        pb.OrderSQL = "car_no desc";
    }
    private void browse1car_typed(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_type desc";
    }
    private void browse1case_nod(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "case_no desc";
    }
    private void browse1work_nod(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);
        pb.CommandSQL = sql;
        pb.OrderSQL = "work_no desc";
    }
    private void browse1repair_venderd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "repair_vender desc";
    }
    private void browse1check_resultd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "check_result desc";
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
    private void browse1total_priced(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "total_price desc";
    }

    //108/05/06
    private void browse1delivery_days(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "delivery_days2 ";
    }
    private void browse1delivery_daysd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "delivery_days2 desc";
    }
    private void browse1exec_deadline_s(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "exec_deadline ";
    }
    private void browse1exec_deadline_sd(PageBreak pb, Form form)
    {
        string sql = sqlstr(pb, form);

        pb.CommandSQL = sql;
        pb.OrderSQL = "exec_deadline desc";
    }




    //wenny_test_排序
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

    public Decimal insertRepairMst(Form form)
    {
        String sql = "INSERT INTO f_repair_mst(car_id, crs_org, case_no, work_no, repair_vender, notify_date, exec_deadline, " +
            "finish_date, check_date, qualified_date, delivery_days, delivery_unit, is_late, check_result, memo, create_date, create_user, " +
            "update_date, update_user,budget_area) VALUES (@car_id, @crs_org, @case_no, @work_no, @repair_vender, @notify_date, " +
            "@exec_deadline, @finish_date, @check_date, @qualified_date, @delivery_days, @delivery_unit, @is_late, @check_result, " +
            "@memo, getdate(), @create_user, getdate(), @create_user,@budget_area) ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@crs_org", form.getValue("crs_org"));
        dao.setParam("@case_no", form.getValue("case_no"));
        dao.setParam("@work_no", form.getValue("work_no"));
        dao.setParam("@repair_vender", form.getValue("repair_vender"));
        dao.setParam("@budget_area", form.getValue("crs_area"));
        if (form.getValue("notify_date") != string.Empty)
            dao.setParam("@notify_date", form.getValue("notify_date"));
        else
            dao.setParam("@notify_date", DBNull.Value);

        if (form.getValue("exec_deadline") != string.Empty)
            dao.setParam("@exec_deadline", form.getValue("exec_deadline"));
        else
            dao.setParam("@exec_deadline", DBNull.Value);

        if (form.getValue("finish_date") != string.Empty)
            dao.setParam("@finish_date", form.getValue("finish_date"));
        else
            dao.setParam("@finish_date", DBNull.Value);

        if (form.getValue("check_date") != string.Empty)
            dao.setParam("@check_date", form.getValue("check_date"));
        else
            dao.setParam("@check_date", DBNull.Value);

        if (form.getValue("qualified_date") != string.Empty)
            dao.setParam("@qualified_date", form.getValue("qualified_date"));
        else
            dao.setParam("@qualified_date", DBNull.Value);

        if (form.getValue("delivery_days") != string.Empty)
            dao.setParam("@delivery_days", form.getValue("delivery_days"));
        else
            dao.setParam("@delivery_days", DBNull.Value);

        dao.setParam("@delivery_unit", form.getValue("delivery_unit"));
        dao.setParam("@is_late", form.getValue("is_late"));

        if (form.getValue("check_result") != string.Empty)
            dao.setParam("@check_result", form.getValue("check_result"));
        else
            dao.setParam("@check_result", DBNull.Value);

        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        return dao.insertForSEQ();
    }


    public Decimal insertRepairDtl(Form form)
    {
        String sql = "INSERT INTO f_repair_dtl(repair_id, notify_item, component_no, count, is_junk, junk_name, junk_count, create_date, create_user, update_date, update_user) " +
            "VALUES (@repair_id, @notify_item, @component_no, @count, @is_junk, @junk_name, @junk_count, getdate(), @create_user, getdate(), @create_user) ";

        dao.CommandSQL = sql;
        dao.setParam("@repair_id", form.getValue("repair_id"));
        dao.setParam("@notify_item", form.getValue("notify_item"));
        dao.setParam("@component_no", form.getValue("component_no"));
        dao.setParam("@count", form.getValue("count"));
        dao.setParam("@is_junk", form.getValue("is_junk"));
        dao.setParam("@junk_name", form.getValue("junk_name"));
        dao.setParam("@junk_count", form.getValue("junk_count"));

        dao.setParam("@create_user", form.getValue("create_user"));

        return dao.insertForSEQ();
    }

    /// <summary>
    /// 刪除託修項目明細
    /// </summary>
    /// <param name="repair_id"></param>
    public void deleteRepairDtl(String repair_id)
    {
        String sql = "delete f_repair_dtl where repair_id=@repair_id";

        dao.CommandSQL = sql;
        dao.setParam("@repair_id", repair_id);
        dao.executeModify();
    }




    /// <summary>
    /// 維修主檔
    /// </summary>
    /// <param name="repair_id"></param>
    /// <returns></returns>
    public DataSet selectRepairMst(String repair_id)
    {
        String sql = "SELECT  a.status as status ,   a.repair_id, a.car_id, a.crs_org, a.budget_area, case_no, a.work_no, a.repair_vender, a.delivery_unit, dbo.chineseDateTime(a.notify_date) as notify_date, " +
            "dbo.chineseDateTime(a.exec_deadline) as exec_deadline, dbo.chineseDateTime(a.finish_date) as finish_date, " +
            "dbo.chineseDateTime(a.check_date)as check_date, dbo.chineseDateTime(a.qualified_date) as qualified_date, delivery_days, is_late, " +
            "check_result, a.memo, b.notify_id, b.notify_item, b.mileage, b.driver, b.repair_type3, " +
            "case when b.notify_type = 'C' then c.dep_no else b.machine_no end as dep_no, c.car_no, c.car_type, c.brand_no, d.id_name as keep_org, " +
            "e.id_name as cart_ype, g.id_name as car_status, b.notify_type, b.machine_type, b.machine_org " +
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

            "where a.repair_id = @repair_id ";

        dao.CommandSQL = sql;
        dao.setParam("@repair_id", repair_id);
        return dao.searchForDS();
    }


    public DataSet selectRepairMst1(String work_no)
    {
        String sql = "SELECT a.repair_id, a.car_id, a.crs_org, a.budget_area, case_no, a.work_no, a.repair_vender, a.delivery_unit, dbo.chineseDateTime(a.notify_date) as notify_date, " +
            "dbo.chineseDateTime(a.exec_deadline) as exec_deadline, dbo.chineseDateTime(a.finish_date) as finish_date, " +
            "dbo.chineseDateTime(a.check_date)as check_date, dbo.chineseDateTime(a.qualified_date) as qualified_date, delivery_days, is_late, " +
            "check_result, a.memo, b.notify_id, b.notify_item, b.mileage, b.driver, b.repair_type3, " +
            "case when b.notify_type = 'C' then c.dep_no else b.machine_no end as dep_no, c.car_no, c.car_type, c.brand_no, d.id_name as keep_org, " +
            "e.id_name as cart_ype, g.id_name as car_status, b.notify_type, b.machine_type, b.machine_org " +
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


    public DataSet Stock(String repair_id)
    {
        String sql = "SELECT   [User1],B.id_name   AS  [User2],  [Thing],[Car],A.[Memo],[Work_no],[ID],[date],A.[status],[Count]," +
            "[No],dbo.chineseDateTime(Update_Time)as Update_Time1,Update_Time" +
            ",  dbo.chineseDateTime([Use_Time])AS Use_Time " +
            ",[Use_Car],[Use_No]   FROM [TDOS].[dbo].[Stock]   a left join  [TDOS].[dbo].[a_sysparam_data] b  on a.User1=b.param_ID and B.param_type = 'DEP_ORG'" +

            "where ID = @ID ";

        dao.CommandSQL = sql;
        dao.setParam("@ID", repair_id);
        return dao.searchForDS();
    }
    /// <summary>
    /// 託修內容
    /// </summary>
    /// <param name="repair_id"></param>
    /// <param name="budget_area"></param>
    /// <returns></returns>
    public DataSet selectRepairDtl(String repair_id, String budget_area)
    {
        #region//修正單價為小數點兩位_wennyh_1229
        String sql = @"select @repair_id as repair_id, (select cast(repair_item AS NVARCHAR(1000) ) + ';' 
                                                         from (select a.notify_item  + '|' + a.component_no + '|'+ component_name  + '|' + CAST(a.count as varchar(10)) + '|' + 
            CAST(CAST((b.budget" + budget_area + @") AS DECIMAL(10, 2)) AS VARCHAR(10))+ '|' + a.junk_name + '|' +  CAST(a.junk_count as varchar(10)) as repair_item 
            from f_repair_dtl a left join f_repair_mst c on a.repair_id = c.repair_id 
            left join e_component_mst b on a.component_no = b.component_no where a.repair_id = @repair_id) a FOR XML PATH('')) as repair_item";
        #endregion
        #region//修正單價為小數點兩位_wennyh_1229_原始檔
        //String sql = @"select @repair_id as repair_id, (select cast(repair_item AS NVARCHAR(1000) ) + ';' 
        //  from (select a.notify_item  + '|' + a.component_no + '|' + CAST(a.count as varchar(10)) + '|' + 
        //  CAST(CAST((b.budget" + budget_area + @") AS DECIMAL(10, 0)) AS VARCHAR(10))+ '|' + a.junk_name + '|' +  CAST(a.junk_count as varchar(10)) as repair_item 
        //  from f_repair_dtl a left join f_repair_mst c on a.repair_id = c.repair_id 
        //  left join e_component_mst b on a.component_no = b.component_no where a.repair_id = @repair_id) a FOR XML PATH('')) as repair_item";
        #endregion
        dao.CommandSQL = sql;
        dao.setParam("@repair_id", repair_id);
        return dao.searchForDS();
    }


    public void updateRepairMst(Form form)
    {
        String sql = "update f_repair_mst set car_id=@car_id, crs_org=@crs_org, case_no=@case_no, work_no= @work_no, repair_vender=@repair_vender, " +
            "notify_date = @notify_date, exec_deadline=@exec_deadline, finish_date=@finish_date, check_date=@check_date, qualified_date=@qualified_date, " +
            "delivery_days=@delivery_days, delivery_unit = @delivery_unit, is_late=@is_late, check_result=@check_result, memo=@memo, budget_area = @budget_area, " +
            "update_date=GETDATE()";

        sql = sql + " where repair_id=@repair_id";

        dao.CommandSQL = sql;

        dao.setParam(@"repair_id", form.getValue("repair_id"));
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@crs_org", form.getValue("crs_org"));
        dao.setParam("@case_no", form.getValue("case_no"));
        dao.setParam("@work_no", form.getValue("work_no"));
        dao.setParam("@repair_vender", form.getValue("repair_vender"));
        dao.setParam("@is_late", form.getValue("is_late"));

        if (form.getValue("check_result") != string.Empty)
            dao.setParam("@check_result", form.getValue("check_result"));
        else
            dao.setParam("@check_result", DBNull.Value);

        if (form.getValue("notify_date") != string.Empty)
            dao.setParam("@notify_date", form.getValue("notify_date"));
        else
            dao.setParam("@notify_date", DBNull.Value);

        if (form.getValue("exec_deadline") != string.Empty)
            dao.setParam("@exec_deadline", form.getValue("exec_deadline"));
        else
            dao.setParam("@exec_deadline", DBNull.Value);

        if (form.getValue("finish_date") != string.Empty)
            dao.setParam("@finish_date", form.getValue("finish_date"));
        else
            dao.setParam("@finish_date", DBNull.Value);

        if (form.getValue("check_date") != string.Empty)
            dao.setParam("@check_date", form.getValue("check_date"));
        else
            dao.setParam("@check_date", DBNull.Value);

        if (form.getValue("qualified_date") != string.Empty)
            dao.setParam("@qualified_date", form.getValue("qualified_date"));
        else
            dao.setParam("@qualified_date", DBNull.Value);

        if (form.getValue("delivery_days") != string.Empty)
            dao.setParam("@delivery_days", form.getValue("delivery_days"));
        else
            dao.setParam("@delivery_days", DBNull.Value);

        dao.setParam("@delivery_unit", form.getValue("delivery_unit"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@budget_area", form.getValue("budget_area"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    public void deleteRepairMst(String repair_id)
    {
        String sql = "delete f_repair_mst where repair_id=@repair_id";

        dao.CommandSQL = sql;
        dao.setParam("@repair_id", repair_id);
        dao.executeModify();
    }

    /// <summary>
    /// 查驗記錄單
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList printRepairPDF1(Form form)
    {
        String sql = "select a.case_no, a.crs_org, a.repair_id, case when d.notify_type = 'C' then b.dep_no else d.machine_no end as dep_no, " +
            "b.car_no, a.work_no, a.repair_vender, a.delivery_unit, dbo.chineseDateTime(a.create_date) as create_date, dbo.chineseDateTime(a.notify_date) as notify_date, " +
            "dbo.chineseDateTime(exec_deadline) as exec_deadline, dbo.chineseDateTime(qualified_date) as qualified_date, " +
            "dbo.chineseDateTime(a.check_date) as check_date, " +
            "dbo.chineseDateTime(a.finish_date) as finish_date_out, dbo.chineseDateTime(d.finish_date) as finish_date_in, delivery_days, is_late, " +
            "check_result, c.total_price1, c.total_price2, c.total_price3, c.total_price4, a.budget_area from f_repair_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id left join f_notify_mst d on a.work_no = d.work_no " +
            "left join (select a.repair_id, sum(a.count * b.budget1) as total_price1, sum(a.count*b.budget2) as total_price2, " +
            "sum(a.count*b.budget3) as total_price3, sum(a.count*b.budget4) as total_price4 from f_repair_dtl a " +
            "left join e_component_mst b on a.component_no = b.component_no " +
            "where a.repair_id in(" + handleMultiData("repair_id", form.getValue("repair_id")) + ") group by repair_id ) c on a.repair_id = c.repair_id " +
            "where a.repair_id in(" + handleMultiData("repair_id2", form.getValue("repair_id")) + ") order by a.work_no ";

        dao.CommandSQL = sql;

        return dao.search();
    }


    /// <summary>
    /// 查驗記錄單零件資料來源
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList printRepairPDF1Component(Form form)
    {
        String sql = "select a.repair_id, a.component_no, b.component_name, b.component_spec, b.unit, sum(a.count) as count, " +
            "b.budget1, b.budget2, b.budget3, b.budget4, sum((a.count* b.budget1)) as total_price1, sum((a.count* b.budget2)) as total_price2, " +
            "sum((a.count* b.budget3)) as total_price3, sum((a.count* b.budget4)) as total_price4, b.memo from f_repair_dtl a " +
            "left join e_component_mst b on a.component_no = b.component_no where repair_id in(" + handleMultiData("repair_id", form.getValue("repair_id")) +
            ") group by repair_id, a.component_no, component_name, component_spec, unit, budget1, budget2, budget3, budget4, memo " +
            "order by repair_id, component_no";

        dao.CommandSQL = sql;

        return dao.search();
    }

    /// <summary>
    /// 交車簽收單資料來源
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList printRepairPDF2(Form form)
    {
        String sql = "select a.crs_org, case when c.notify_type = 'C' then b.dep_no else c.machine_no end as dep_no, a.work_no, " +
            "dbo.chineseDateTime(c.pickup_date) as pickup_date from f_repair_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id left join f_notify_mst c on a.work_no = c.work_no " +
            "where 1=1 and repair_id in(" + handleMultiData("repair_id", form.getValue("repair_id")) + ")";

        dao.CommandSQL = sql;

        return dao.search();
    }


    public ArrayList Print(Form form)
    {

        String sql = @"select B.id_name   AS User1, A.[Thing],sum(Count) as Count from [TDOS].[dbo].[Stock]   a left join  [TDOS].[dbo].[a_sysparam_data] b 
                        on a.User1=b.param_ID  where param_type='DEP_ORG'  and a.status='O'  
                         and  b.param_ID like @User  and Thing like @Thing  group by  B.id_name, A.[Thing]  ";

       
   



        






        dao.CommandSQL = sql;
        dao.setParam("@User","%" + form.getValue("User") + "%");


        dao.setParam("@Thing", "%" + form.getValue("Thing") + "%");

        return dao.search();

    }

    /// <summary>
    /// 完工接車單資料來源
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList printRepairPDF3(Form form)
    {
        String sql = "select  a.repair_id, a.crs_org, case when c.notify_type = 'C' then b.dep_no else c.machine_no end as dep_no, a.work_no, " +
            "dbo.chineseDateTime(c.pickup_date) as pickup_date, a.memo, d.junk_number " +
            "from f_repair_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join f_notify_mst c on a.work_no = c.work_no " +
            "left join (select count(junk_name) as junk_number, repair_id from f_repair_dtl where repair_id in(" +
            handleMultiData("repair_id", form.getValue("repair_id")) + ") group by repair_id) d on a.repair_id = d.repair_id " +
            "where 1=1 and a.repair_id in(" + handleMultiData("repair_id2", form.getValue("repair_id")) + ")";

        dao.CommandSQL = sql;

        return dao.search();
    }


    /// <summary>
    /// 廢品資料
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList printRepairPDF3Junk(Form form)
    {
        String sql = "select repair_id, junk_name, sum(junk_count) as junk_count from f_repair_dtl where repair_id in(" +
        handleMultiData("repair_id", form.getValue("repair_id")) + ") " +
            "group by repair_id, junk_name order by repair_id, junk_name";

        dao.CommandSQL = sql;

        return dao.search();
    }


    /// <summary>
    /// 標案號碼 2015/12/21修改
    /// </summary>
    /// <param name="work_no"></param>
    /// <returns></returns>
    public String getCaseNo(String work_no, String repair_vender, String year)
    {
        String sRetValue = "";
        int case_no = 0;

        //String sql = "select Max(CONVERT(int, substring(case_no, 12, 5)) ) as case_no from f_repair_mst " +
        //    "where substring(case_no, 1, 3) = @year " +
        //    "and substring(case_no, 8, " + repair_vender.Length + ") = @repair_vender and substring(case_no, 8, 3) <> '999'";


        String sql = "select Max(CONVERT(int, SUBSTRING(case_no, CHARINDEX('-',case_no)+1,5)) ) as case_no from f_repair_mst " +
            "where substring(case_no, 1, 3) = @year " +
            "and substring(case_no, 4, " + repair_vender.Length + ") = @repair_vender ";

        if (repair_vender.Length == 3)
            sql += "and substring(case_no, 4, 3) <> '999'";

        dao.CommandSQL = sql;
        dao.setParam("@work_no", work_no);
        dao.setParam("@repair_vender", repair_vender);
        dao.setParam("@year", year);

        DataSet ds = dao.searchForDS();
        if (!ds.Tables[0].Rows[0]["case_no"].Equals(DBNull.Value))
        {
            case_no = int.Parse(ds.Tables[0].Rows[0]["case_no"].ToString());
        }

        if (case_no > 0)
        {
            case_no += 1;
            string sCaseNo = HandleParam.addZero(case_no.ToString(), 5);
            sRetValue = year + "-" + repair_vender + "-" + sCaseNo;
        }
        else
            sRetValue = year + "-" + repair_vender + "-00001";

        return sRetValue;
    }


   


    public String getEndCaseNo(String work_no, String year)
    {
        String sRetValue = "";
        int case_no = 0;

        String sql = "select Max(CONVERT(int,(substring(case_no, 9, 4)) )) as case_no from f_repair_mst " +
            "where substring(case_no, 2, 3) = @year";

        dao.CommandSQL = sql;
        dao.setParam("@work_no", work_no);
        dao.setParam("@year", year);

        DataSet ds = dao.searchForDS();
        if (!ds.Tables[0].Rows[0]["case_no"].Equals(DBNull.Value))
        {
            case_no = int.Parse(ds.Tables[0].Rows[0]["case_no"].ToString());
        }

        if (case_no > 0)
        {
            case_no += 1;
            string sCaseNo = HandleParam.addZero(case_no.ToString(), 4);
            sRetValue = work_no.Substring(0, 1) + year + "零託字第" + sCaseNo + "號";
        }
        else
            sRetValue = work_no.Substring(0, 1) + year + "零託字第0001號";

        return sRetValue;
    }

    


    public int GetCaseNoCount(String case_no)

    {
        String sql = "select * from f_repair_mst where case_no = @case_no";

        dao.CommandSQL = sql;
        dao.setParam("@case_no", case_no);
        DataSet ds = dao.searchForDS();

        return ds.Tables[0].Rows.Count;
    }


    public ArrayList export(Form form)
    {
        String sql = "select a.repair_id, a.car_id, a.crs_org, a.case_no, a.work_no, a.repair_vender, a.check_result, " +
            "case when c.notify_type = 'C' then b.dep_no else c.machine_no end as dep_no, " +
            "case when c.notify_type = 'C' then b.car_no else '-' end as car_no, b.car_type, c.repair_type1, c.repair_type2, " +
            "c.repair_type3, c.notify_type, c.machine_type, c.machine_org, dbo.chineseDate(c.notify_date) as notify_date, " +
            "dbo.chineseDate(a.finish_date) as finish_date, t.total_price from f_repair_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join f_notify_mst c on a.work_no = c.work_no " +
            //"left join a_sysparam_data c on a.crs_org = c.param_id and c.param_type = 'DEP_ORG' " +
            //"left join a_sysparam_data d on b.car_type = d.param_id and d.param_type = 'CAR_TYPE' " +
            //"left join a_sysparam_data e on a.check_result = e.param_id and e.param_type = 'CHECK_RSLT' ";
            "left join (select t.repair_id, sum(t.subtotal) as total_price from( " +
            "select a.*, round(a.count* a.budget,0) as subtotal from( " +
            "select a.repair_id, a.count, b.budget_area, case when budget_area = 1 then c.budget1  when budget_area = 3 then c.budget3 " +
             "when budget_area = 4 then c.budget4 else c.budget2 end as budget from f_repair_dtl a " +
             "left join f_repair_mst b on a.repair_id = b.repair_id " +
             "left join e_component_mst c on a.component_no = c.component_no) a )t group by t.repair_id) t on t.repair_id = a.repair_id";

        String where = " where 1=1";

        if (!form.getValue("notify_type").Equals(""))
        {
            where += " and c.notify_type in (" + handleMultiData("notify_type", form.getValue("notify_type")) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            dao.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and (b.dep_no like @dep_no or c.machine_no like @dep_no)";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("repair_vender").Equals(""))
        {
            where += " and a.repair_vender like @repair_vender";
            dao.setParam("@repair_vender", "%" + form.getValue("repair_vender") + "%");
        }

        if (!form.getValue("case_no").Equals(""))
        {
            where += " and a.case_no like @case_no";
            dao.setParam("@case_no", "%" + form.getValue("case_no") + "%");
        }

        if (!form.getValue("work_no").Equals(""))
        {
            where += " and a.work_no like @work_no";
            dao.setParam("@work_no", "%" + form.getValue("work_no") + "%");
        }

        if (!form.getValue("check_result").Equals(""))
        {
            where += " and a.check_result in (" + handleMultiData("check_result", form.getValue("check_result")) + ")";
        }

        if (!form.getValue("crs_org").Equals(""))
        {
            where += " and a.crs_org in (" + handleMultiData("crs_org", form.getValue("crs_org")) + ")";
        }

        if (!form.getValue("repair_type1").Equals(""))
        {
            where += " and c.repair_type1 = @repair_type1";
            dao.setParam("@repair_type1", form.getValue("repair_type1"));
        }

        if (!form.getValue("repair_type2").Equals(""))
        {
            where += " and c.repair_type2 = @repair_type2";
            dao.setParam("@repair_type2", form.getValue("repair_type2"));
        }

        if (!form.getValue("repair_type3").Equals(""))
        {
            where += " and c.repair_type3 = @repair_type3";
            dao.setParam("@repair_type3", form.getValue("repair_type3"));
        }
        #region 修正惠爾查不到11/20_wenny1061222
        if (!form.getValue("notify_start").Equals(""))
        {
            where += " and convert(varchar(10) , c.notify_date, 111 ) >= @notify_start";
            dao.setParam("@notify_start", DateTransfer.c_date_trans(form.getValue("notify_start")));
        }
        #endregion
        #region 修正惠爾查不到11/20_wenny1061222_原始碼
        //if (!form.getValue("notify_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , a.notify_date, 111 ) >= @notify_start";
        //    dao.setParam("@notify_start", DateTransfer.c_date_trans(form.getValue("notify_start")));
        //}
        #endregion
        if (!form.getValue("notify_end").Equals(""))
        {
            where += " and convert(varchar(10) , c.notify_date, 111 ) <= @notify_end";
            dao.setParam("@notify_end", DateTransfer.c_date_trans(form.getValue("notify_end")));
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

        sql = sql + where + " order by repair_id desc";

        dao.CommandSQL = sql;

        ArrayList al = dao.search();

        return al;
    }

    //1080513修改
    private string sqlstr( PageBreak pb,  Form form)
    {
        String sql = "select a.status as  status,a.repair_id, a.car_id, a.crs_org, a.case_no, a.work_no, a.repair_vender, a.check_date,a.check_result,CONVERT(varchar, delivery_days) + CASE  WHEN　delivery_unit ='WORKDAY' THEN '天'   WHEN delivery_unit = 'HOUR' THEN '小時' ELSE delivery_unit END as delivery_days,dbo.chineseDate(exec_deadline) as exec_deadline, delivery_days* CASE  WHEN　delivery_unit ='WORKDAY' THEN 24 WHEN delivery_unit ='HOUR' THEN 1　　 ELSE delivery_unit END as delivery_days2, " +
            "case when c.notify_type = 'C' then b.dep_no else c.machine_no end as dep_no, " +
            "case when c.notify_type = 'C' then b.car_no else '-' end as car_no, b.car_type, c.repair_type1, c.repair_type2, " +
            "c.repair_type3, c.notify_type, c.machine_type, c.machine_org, dbo.chineseDate(a.notify_date) as notify_date,dbo.chineseDate(c.notify_date) as notify_date1, " +
            "dbo.chineseDate(a.finish_date) as finish_date, t.total_price from f_repair_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join f_notify_mst c on a.work_no = c.work_no " +
           
            "left join (select t.repair_id, sum(t.subtotal) as total_price from( " +
            "select a.*, round(a.count* a.budget,0) as subtotal from( " +
            "select a.repair_id, a.count, b.budget_area, case when budget_area = 1 then c.budget1  when budget_area = 3 then c.budget3 " +
             "when budget_area = 4 then c.budget4 else c.budget2 end as budget from f_repair_dtl a " +
             "left join f_repair_mst b on a.repair_id = b.repair_id " +
             "left join e_component_mst c on a.component_no = c.component_no) a )t group by t.repair_id) t on t.repair_id = a.repair_id ";

        String where = "where 1=1";
        //109.11.18 
        if (form.getValue("role_id").Substring(0,4) == "TEST")
        {
            where += " and a.update_user = @update_user";
            where += " and a.status in('O','X')";

            pb.setParam("@update_user", form.getValue("update_user"));
        }

        if (!form.getValue("notify_type").Equals(""))
        {
            where += " and c.notify_type in (" + handleMultiData("notify_type", form.getValue("notify_type"), pb) + ")";
        }

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and b.car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and (b.dep_no like @dep_no or c.machine_no like @dep_no)";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (!form.getValue("repair_vender").Equals(""))
        {
            where += " and a.repair_vender like @repair_vender";
            pb.setParam("@repair_vender", "%" + form.getValue("repair_vender") + "%");
        }

        if (!form.getValue("case_no").Equals(""))
        {
            where += " and a.case_no like @case_no";
            pb.setParam("@case_no", "%" + form.getValue("case_no") + "%");
        }

        if (!form.getValue("work_no").Equals(""))
        {
            where += " and a.work_no like @work_no";
            pb.setParam("@work_no", "%" + form.getValue("work_no") + "%");
        }

        //2018/08/31測試查驗結果Checkbox
        /*2018/08/31測試查驗結果Checkbox before
         * if (!form.getValue("check_result").Equals(""))
        {
            where += " and a.check_result in (" + handleMultiData("check_result", form.getValue("check_result"), pb) + ")";
        }*/
        if (!form.getValue("resultValue0").Equals("") || !form.getValue("resultValue1").Equals("") || !form.getValue("resultValue2").Equals(""))
        {
            where += " and( ";
            string checkResult = "";
            if (!form.getValue("resultValue0").Equals(""))
            {

                checkResult += " a.check_result=@resultValue0 or";
                pb.setParam("@resultValue0", form.getValue("resultValue0"));
            }
            if (!form.getValue("resultValue1").Equals(""))
            {
                checkResult += "  a.check_result = @resultValue1 or";
                pb.setParam("@resultValue1", form.getValue("resultValue1"));
            }
            if (!form.getValue("resultValue2").Equals(""))
            {
                checkResult += "  a.check_result = '' or a.check_result is null ";

            }
            string laststr = checkResult.Substring(checkResult.Length - 2);
            if (laststr == "or")
            {
                checkResult = checkResult.Remove(checkResult.Length - 2);
            }
            where = where + checkResult + " ) ";
        }

        //2018/08/31測試查驗結果Checkbox
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

        if (!form.getValue("repair_type1").Equals(""))
        {
            where += " and c.repair_type1 = @repair_type1";
            pb.setParam("@repair_type1", form.getValue("repair_type1"));
        }

        if (!form.getValue("repair_type2").Equals(""))
        {
            where += " and c.repair_type2 = @repair_type2";
            pb.setParam("@repair_type2", form.getValue("repair_type2"));
        }

        if (!form.getValue("repair_type3").Equals(""))
        {
            where += " and c.repair_type3 = @repair_type3";
            pb.setParam("@repair_type3", form.getValue("repair_type3"));
        }

        #region 修正惠爾查不到11/20_wenny1061222
        if (!form.getValue("notify_start").Equals(""))
        {
            where += " and convert(varchar(10) , a.notify_date, 111 ) >= @notify_start";
            pb.setParam("@notify_start", DateTransfer.c_date_trans(form.getValue("notify_start")));
        }
        #endregion
        #region 修正惠爾查不到11/20_wenny1061222_原始碼
        //if (!form.getValue("notify_start").Equals(""))
        //{
        //    where += " and convert(varchar(10) , a.notify_date, 111 ) >= @notify_start";
        //    pb.setParam("@notify_start", DateTransfer.c_date_trans(form.getValue("notify_start")));
        //}
        #endregion

        if (!form.getValue("notify_end").Equals(""))
        {
            where += " and convert(varchar(10) ,a.notify_date, 111 ) <= @notify_end";
            pb.setParam("@notify_end", DateTransfer.c_date_trans(form.getValue("notify_end")));
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
        sql = sql + where;
        return sql;
    }
    private string sqlstr1(PageBreak pb, Form form)
    {
        String sql = "SELECT [ID] ,id_name as User2,[Thing],[Count],[Date],[Car],a.[Memo],[Work_no],[No] " +
            ",SUBSTRING( dbo.chineseDateTime(Update_Time),0,10)as Update_Time   ," +
            "CASE ([Use_Time]) WHEN '1900-01-01 00:00:00.000' THEN NULL ELSE SUBSTRING( dbo.chineseDateTime(Use_Time),0,10)    END as [Use_Time] ," +
            "[Use_Car],[Use_No] FROM [TDOS].[dbo].[Stock] a left join  [TDOS].[dbo].[a_sysparam_data] b  on a.User1=b.param_id  ";

        String where = "where 1=1 and  b.param_type='DEP_ORG' ";



        if (!form.getValue("car_no").Equals(""))
        {
            where += " and Car like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }
        if (!form.getValue("work_no").Equals(""))
        {
            where += " and Work_no like @work_no";
            pb.setParam("@work_no", "%" + form.getValue("work_no") + "%");
        }
        if (!form.getValue("notify_start").Equals(""))
        {
            where += " and date > @notify_start";
            pb.setParam("@notify_start", form.getValue("notify_start") );
        }

        if (!form.getValue("notify_end").Equals(""))
        {
            where += " and date < @notify_end";
            pb.setParam("@notify_end", form.getValue("notify_end") );
        }
      
            sql += "and User1 in(" + handleMultiData("User", form.getValue("User"), pb) + ")";







        if (!form.getValue("Thing").Equals(""))
        {
            where += " and Thing like @Thing";
            pb.setParam("@Thing", "%" + form.getValue("Thing") + "%");
        }
        if (!form.getValue("Status").Equals(""))
        {
            where += " and a.Status like @Status";
            pb.setParam("@Status", "%" + form.getValue("Status") + "%");
        }
        if (!form.getValue("No").Equals(""))
        {
            where += " and No like @No";
            pb.setParam("@No", "%" + form.getValue("No") + "%");
        }
        if (!form.getValue("Use_Car").Equals(""))
        {
            where += " and Use_Car like @Use_Car";
            pb.setParam("@Use_Car", "%" + form.getValue("Use_Car") + "%");
        }
        if (!form.getValue("Use_No").Equals(""))
        {
            where += " and Use_No like @Use_No";
            pb.setParam("@Use_No", "%" + form.getValue("Use_No") + "%");
        }
        
        if (!form.getValue("Update_Time_start").Equals(""))
        {
            where += " and convert(varchar(10) , Update_Time, 111 ) >= @Update_Time_start";
            pb.setParam("@Update_Time_start", DateTransfer.c_date_trans(form.getValue("Update_Time_start")));
        }

        if (!form.getValue("Update_Time_end").Equals(""))
        {
            where += " and convert(varchar(10) , Update_Time, 111 ) <= @Update_Time_end";
            pb.setParam("@Update_Time_end", DateTransfer.c_date_trans(form.getValue("Update_Time_end")));
        }
        if (!form.getValue("Use_Time_start").Equals(""))
        {
            where += " and convert(varchar(10) , Use_Time, 111 ) >= @Use_Time_start";
            pb.setParam("@Use_Time_start", DateTransfer.c_date_trans(form.getValue("Use_Time_start")));
        }

        if (!form.getValue("Use_Time_end").Equals(""))
        {
            where += " and convert(varchar(10) , Use_Time, 111 ) <= @Use_Time_end";
            pb.setParam("@Use_Time_end", DateTransfer.c_date_trans(form.getValue("Use_Time_end")));

        }
            sql = sql + where;
        return sql;
    }
    
    private string sqlstr2(PageBreak pb, Form form)
    {
        String sql = "select B.id_name   AS User1,     A.[Thing],sum(Count) as Count from [TDOS].[dbo].[Stock]   a left join  [TDOS].[dbo].[a_sysparam_data] b " +
            " on a.User1=b.param_ID  where param_type='DEP_ORG'  and a.status='O'   and  b.param_ID in(" + handleMultiData("User", form.getValue("User"), pb) + ")  and Thing like @Thing   group by  B.id_name,[Thing]                 ";
          

        String where = " ";


        pb.setParam("@User", "%" + form.getValue("User") + "%");

        pb.setParam("@Thing", "%" + form.getValue("Thing") + "%");

        sql = sql + where;
        return sql;
    }

    public void True(Form form)
    {
        String sql = "update   [TDOS].[dbo].[f_repair_mst] set status='O'    where repair_id in(" +   handleMultiData("repair_id", form.getValue("repair_id")) + ")";



        dao.CommandSQL = sql;
        dao.setParam("@repair_id", form.getValue("repair_id"));


      

        dao.executeModify();

    }

    public void Flase(Form form)
    {
        String sql = "update    [TDOS].[dbo].[f_repair_mst] set status='X'    where repair_id in(" + handleMultiData("repair_id", form.getValue("repair_id")) + ")";



        dao.CommandSQL = sql;
        dao.setParam("@repair_id", form.getValue("repair_id"));
        

        dao.executeModify();

    }
}