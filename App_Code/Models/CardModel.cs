using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// CardModel 的摘要描述
/// </summary>
public class CardModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse1_card_type"))
        {
            browse1_card_type(pb, form);
        }
        else if (pbKey.Equals("browse1_card_no"))
        {
            browse1_card_no(pb, form);
        }
        else if (pbKey.Equals("browse1_keep_org"))
        {
            browse1_keep_org(pb, form);
        }
        else if (pbKey.Equals("browse1_fuel_type"))
        {
            browse1_fuel_type(pb, form);
        }
        else if (pbKey.Equals("browse1_status"))
        {
            browse1_status(pb, form);
        }
        //反排
        else if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);
        }
        else if (pbKey.Equals("browse1_card_typed"))
        {
            browse1_card_typed(pb, form);
        }
        else if (pbKey.Equals("browse1_card_nod"))
        {
            browse1_card_nod(pb, form);
        }
        else if (pbKey.Equals("browse1_keep_orgd"))
        { 
            browse1_keep_orgd(pb, form);
        }
        else if (pbKey.Equals("browse1_fuel_typed"))
        {
            browse1_fuel_typed(pb, form);
        }
        else if (pbKey.Equals("browse1_statusd"))
        {
            browse1_statusd(pb, form);
        }
    }

    /// <summary>
    /// 加油卡資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";            

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

       
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
       

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no";
    }
    //wenny_test_排序
    //正排
    private void browse1_card_type(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_type";
    }
    private void browse1_card_no(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no";
    }
    private void browse1_keep_org(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "keep_org";
    }
    private void browse1_fuel_type(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_type";
    }
    private void browse1_status(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "status";
    }
    //反排
    private void browse1d(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no desc";
    }
    private void browse1_card_typed(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_type desc";
    }
    private void browse1_card_nod(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no desc";
    }
    private void browse1_keep_orgd(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "keep_org desc";
    }
    private void browse1_fuel_typed(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_type desc";
    }
    private void browse1_statusd(PageBreak pb, Form form)
    {
        String sql = "select card_id, card_type, card_no, keep_org, keep_man, fuel_type, status from c_card_mst a ";

        String where = "where 1=1 and card_type <> '1' ";

        if (!form.getValue("card_no").Equals(""))
        {
            where += " and a.card_no like @card_no";
            pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        }

        if (!form.getValue("keep_man").Equals(""))
        {
            where += " and a.keep_man like @keep_man";
            pb.setParam("@keep_man", "%" + form.getValue("keep_man") + "%");
        }

        if (!form.getValue("card_type").Equals(""))
        {
            where += " and a.card_type in (" + handleMultiData("card_type", form.getValue("card_type"), pb) + ")";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and a.fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and a.keep_org in (" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "status desc";
    }
    //wenny_test_排序



    /// <summary>
    /// 新增加油卡
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertCard(Form form)
    {
        String sql = "insert into c_card_mst (card_type, card_no, keep_org, keep_man, fuel_type, status, create_date, " +
            "create_user, update_date, update_user) " +
            "values (@card_type, @card_no, @keep_org, @keep_man, @fuel_type, @status, GETDATE(), @create_user, " +
            "GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@card_type", form.getValue("card_type"));
        dao.setParam("@card_no", form.getValue("card_no"));
        dao.setParam("@keep_org", form.getValue("keep_org"));
        dao.setParam("@keep_man", form.getValue("keep_man"));
        dao.setParam("@fuel_type", form.getValue("fuel_type"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@create_user", form.getValue("create_user"));

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 複製加油卡
    /// </summary>
    /// <param name="card_id"></param>
    /// <returns></returns>
    public Decimal copyCard(String card_id)
    {
        String sql = @"insert into c_card_mst(card_type, card_no, keep_org, keep_man, fuel_type, status, create_date, 
            create_user, update_date, update_user) select card_type, card_no, keep_org, keep_man, fuel_type, status, create_date, 
            create_user, update_date, update_user from c_card_mst where card_id = @card_id";

        dao.CommandSQL = sql;

        dao.setParam("@card_id", card_id); 

        return dao.insertForSEQ();
    }

    /// <summary>
    /// 查詢加油卡資料明細
    /// </summary>
    /// <param name="card_id"></param>
    /// <returns></returns>
    public DataSet selectCard(String card_id)
    {
        String sql = "select a.*, c.car_no from c_card_mst a " +
            "left join (select * from c_car_card where card_id = @card_id and possess_start <= convert(varchar(10), GETDATE(), 111) " +
            "and (possess_end is null or possess_end >= convert(varchar(10), GETDATE(), 111))) b " +
            "on a.card_id = b.card_id " +
            "left join c_car_mst c on b.car_id = c.car_id " +
            "where a.card_id = @card_id ";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", card_id);
        return dao.searchForDS();
    }


    /// <summary>
    /// 依加油卡取出車輛資料(勤務記錄)
    /// </summary>
    /// <param name="card_id"></param>
    /// <returns></returns>
    public DataSet selectCardWithCar(String card_id, String target_date)
    {
        String sql = @"select distinct car,a.card_id, a.card_type, a.card_no, a.keep_org, a.status as card_status, c.car_id, a.card_no as car_no, 
            c.car_type, c.dep_no, c.fuel_std, c.fuel_type, d.status as car_status, a.fuel_type as machine_fuel from c_card_mst a 
            left join (select * from c_car_card where card_id =@card_id and possess_start <= @target_date 
            and (possess_end is null or possess_end >= @target_date)) b on a.card_id = b.card_id 
            left join c_car_mst c on b.car_id = c.car_id 
            left join c_car_sts d on b.car_id = d.car_id and convert(varchar(10), d.exec_start, 111) <= @target_date 
            and (exec_end is null or convert(varchar(10), d.exec_end, 111) >= @target_date) 
            where a.card_id = @card_id";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", card_id);
        if (target_date != string.Empty)
        {
            dao.setParam("@target_date", target_date);
        }
        else
        {
            dao.setParam("@target_date", DateTime.Now.ToString("yyyy/MM/dd"));
        }

        return dao.searchForDS();
    }


    /// <summary>
    /// 修改加油卡資料
    /// </summary>
    /// <param name="form"></param>
    public void updateCard(Form form)
    {
        String sql = "update c_card_mst set card_type=@card_type, card_no=@card_no, keep_org=@keep_org, " +
            "keep_man=@keep_man, fuel_type = @fuel_type, status = @status, update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where card_id=@card_id";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@card_type", form.getValue("card_type"));
        dao.setParam("@card_no", form.getValue("card_no"));
        dao.setParam("@keep_org", form.getValue("keep_org"));
        dao.setParam("@keep_man", form.getValue("keep_man"));
        dao.setParam("@fuel_type", form.getValue("fuel_type"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 修改加油卡卡號(車牌號碼)
    /// </summary>
    /// <param name="form"></param>
    public void updateCardNo(Form form)
    {
        String sql = "update c_card_mst set card_no=@card_no, update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where card_id=@card_id";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", form.getValue("card_id"));      
        dao.setParam("@card_no", form.getValue("card_no"));        
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 刪除加油卡資料
    /// </summary>
    /// <param name="card_id"></param>
    public void deleteCard(String card_id)
    {
        String sql = "delete c_card_mst where card_id=@card_id";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", card_id);
        dao.executeModify();
    }


    /// <summary>
    /// 刪除加油卡對應車輛
    /// </summary>
    /// <param name="car_id"></param>
    public void deleteCarCard(String card_id)
    {
        String sql = "delete c_car_card where card_id=@card_id";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", card_id);
        dao.executeModify();
    }


    /// <summary>
    /// 取出沒有對應車輛的車隊卡及目前正在使用的車隊卡
    /// </summary>
    /// <param name="keep_org"></param>
    /// <param name="card_id"></param>
    /// <returns></returns>
    public ArrayList selectCardNo(String keep_org, String card_id)
    {
        String sql = "select card_id as PVALUE, card_no as PTEXT from c_card_mst where card_id not in( " +
            "select card_id from c_car_card where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) and " +
            "(possess_end is null or possess_end>= convert(varchar(10), GETDATE(), 111))) and card_type = '1' and status='O' " +
            "and keep_org= @keep_org";

        if (card_id != string.Empty)
        {
            sql += " union select card_id as PVALUE, card_no as PTEXT from c_card_mst " +
                "where card_id = @card_id and keep_org= @keep_org";

            dao.setParam("@card_id", card_id);
        }

        sql += " order by card_no";

        dao.CommandSQL = sql;
        dao.setParam("@keep_org", keep_org);

        return dao.search();
    }


    /// <summary>
    /// 勤務記錄取出加油卡資料，不包含車隊卡
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList selectCardNoWithoutCar(Form form)
    {
        String sql = "select card_id as PVALUE, card_no as PTEXT from c_card_mst " +
            "where card_type <> '1' and status='O'";

        if (form.getValue("user_read") != "ALL")
        {
            sql += " and keep_org= @keep_org";
            dao.setParam("@keep_org", form.getValue("user_org"));
        }

        sql += " order by card_no";

        dao.CommandSQL = sql;


        return dao.search();
    }


    /// <summary>
    /// 加油卡號的下拉選單
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList selectCardNo(Form form)
    {      
        String sql = @"select a.card_id as PVALUE, case when a.status = 'C' then card_no+'(停用)' else card_no end as PTEXT from c_card_mst a";
        
       

            sql += " left join c_car_card b on a.card_id = b.card_id left join [c_car_mst] c  on b.car_id =c.car_id  ";
        
        sql += " where 1=1  ";
        
         //if(form.getValue("card_type").Equals("1"))
         //   sql += "and b.possess_start <= @query_date and (b.possess_end is null or b.possess_end >= @query_date)";

        if (form.getValue("user_read") != "ALL")
        {
            sql += "and a.keep_org= @user_org";
            dao.setParam("@user_org", form.getValue("user_org"));
        }

        if (form.getValue("keep_org") != string.Empty)
        {
            sql += " and a.keep_org= @keep_org";
            dao.setParam("@keep_org", form.getValue("keep_org"));
        }       

        if (form.getValue("card_type") != string.Empty)
        {
            sql += " and a.card_type= @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (form.getValue("query_date") != string.Empty)
            dao.setParam("@query_date", form.getValue("query_date"));
        else
            dao.setParam("@query_date", DateTime.Now.ToString("yyyy/MM/dd"));

        ////勤務類型
        //if (form.getValue("work_type") != string.Empty)
        //{
        //    if (form.getValue("work_type") == "M")
        //    {
        //        sql += " and card_type <> '1'";
        //    }
        //    else
        //    {
        //        sql += " and card_type = '1'";
        //    }
        //}

        //if (form.getValue("action") == "edit")
        //{
        //    sql += " and status = 'O'";
        //}

        sql += " and b.car_id is null   or car_type='89' order by card_no";

        dao.CommandSQL = sql;


        return dao.search();
    }

    /// <summary>
    /// 加油卡號的下拉選單
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList selectCardNo1(Form form)
    {
        String sql = @"select a.card_id as PVALUE, case when a.status = 'C' then card_no+'(停用)' else card_no end as PTEXT from c_card_mst a";




        sql += " where 1=1  ";

        //if(form.getValue("card_type").Equals("1"))
        //   sql += "and b.possess_start <= @query_date and (b.possess_end is null or b.possess_end >= @query_date)";

        if (form.getValue("user_read") != "ALL")
        {
            sql += "and a.keep_org= @user_org";
            dao.setParam("@user_org", form.getValue("user_org"));
        }

        if (form.getValue("keep_org") != string.Empty)
        {
            sql += " and a.keep_org= @keep_org";
            dao.setParam("@keep_org", form.getValue("keep_org"));
        }

        if (form.getValue("card_type") != string.Empty)
        {
            sql += " and a.card_type= @card_type";
            dao.setParam("@card_type", form.getValue("card_type"));
        }

        if (form.getValue("query_date") != string.Empty)
            dao.setParam("@query_date", form.getValue("query_date"));
        else
            dao.setParam("@query_date", DateTime.Now.ToString("yyyy/MM/dd"));

        


        dao.CommandSQL = sql;


        return dao.search();
    }


    /// <summary>
    /// 勤務記錄使用的加油卡下拉選單
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList selectCardNoByWorkType(Form form)
    {
        String sql = "";
        ArrayList al = new ArrayList();

        if (form.getValue("work_type").Equals("C"))
        {
            sql = @"select a.car_id, a.card_id as PVALUE, b.status, convert(varchar(10), b.exec_start, 111) as exec_start, 
                            convert(varchar(10), b.exec_end, 111) as exec_end, c.card_no as PTEXT, c.keep_org from(        
                            select car_id, card_id from c_car_card where convert(varchar(10), possess_start, 111) <= @query_date and 
                            (possess_end is null or convert(varchar(10), possess_end, 111) >= @query_date)) a 
                            left join (select car_id, status, exec_start, exec_end from c_car_sts where convert(varchar(10), exec_start, 111) <= @query_date
                            and (exec_end is null or convert(varchar(10), exec_end, 111) >= @query_date) ) b on a.car_id = b.car_id 
                            left join c_card_mst c on a.card_id = c.card_id where 1=1 and b.status = 'O'";
        
            if(form.getValue("action").Equals("update"))
            {
                sql += @" union select a.car_id, a.card_id as PVALUE, b.status, convert(varchar(10), c.exec_start, 111) as exec_start, 
                    convert(varchar(10), c.exec_end, 111) as exec_end, b.card_no as PTEXT, a.keep_org from c_work_mst a 
                    left join c_card_mst b on a.card_id = b.card_id 
                    left join c_car_sts c on a.car_id = c.car_id and convert(varchar(10), c.exec_start, 111) <= convert(varchar(10), a.work_date, 111)
                    and (exec_end is null or convert(varchar(10), c.exec_end, 111) >= convert(varchar(10), a.work_date, 111)) where work_id = @work_id";
                            
                    dao.setParam("@keep_org", form.getValue("keep_org"));
            }

            if (form.getValue("keep_org") != string.Empty)
            {
                sql += " and c.keep_org = @keep_org ";
                dao.setParam("@keep_org", form.getValue("keep_org"));
            }


            dao.setParam("@query_date", form.getValue("query_date"));

            dao.CommandSQL = sql + " order by c.card_no";

            al = dao.search();
        
        }
        else if (form.getValue("work_type").Equals("M"))
        {
            al = selectCardNo(form);
        }

        return al;
    }
     
    /// <summary>
    /// 勤務記錄使用的加油卡卡別下拉選單
    /// </summary>
    /// <param name="work_type"></param>
    /// <returns></returns>
    public ArrayList selectCardTypeByWorkType(String work_type)
    {
        String sql = "select param_id as PVALUE, id_name as PTEXT from a_sysparam_data " +
            "where param_type = 'CARD_TYPE'";

        if (work_type == "C")
        {
            sql += " and param_id = '1'";
        }
        else
        {
            sql += " and param_id <> '1'";
        }


        sql += " order by id_order_by ";

        dao.CommandSQL = sql;


        return dao.search();
    }


    /// <summary>
    /// 依加油卡ID取得交易日期內的加油數量及金額
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public DataSet getFuelDataDuringWork(Form form)
    {
        String sql = "select card_no, SUM(fuel_amount) as fuel_amount, SUM(fuel_count) as fuel_count " +
            "from v_fuel where 1=1";


        if (form.getValue("card_id") != string.Empty)
        {
            sql += " and card_id= @card_id";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (form.getValue("start_date") != string.Empty)
        {
           // sql += " and deal_date >= @start_date";
            sql += " and convert(varchar(10), deal_date, 111) >= @start_date";
            dao.setParam("@start_date", form.getValue("start_date"));
        }

        if (form.getValue("end_date") != string.Empty)
        {
            //sql += " and deal_date <= @end_date";
            sql += " and convert(varchar(10), deal_date, 111) <= @end_date";
            dao.setParam("@end_date", form.getValue("end_date"));
        }

        sql += " group by card_no";

        dao.CommandSQL = sql;

        return dao.searchForDS();
    }


    /// <summary>
    /// 取得使用中的加油卡卡號(匯入中油資料使用)
    /// </summary>
    /// <returns></returns>
    public ArrayList GetUseCardNo()
    {
        String sql = "select card_no from c_card_mst where status='O'";

        dao.CommandSQL = sql;

        return dao.search();
    }


    /// <summary>
    /// 檢核加油卡是否已存在
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public String IsCardNoExist(Form form)
    {
        String card_id = "";

        String sql = "select card_id from c_card_mst where card_no=@card_no and keep_org=@keep_org ";

        if (form.getValue("action") == "Update")
        {
            sql += " and card_id <> @card_id ";
            dao.setParam("@card_id", form.getValue("card_id"));
        }
        dao.CommandSQL = sql;
        dao.setParam("@card_no", form.getValue("card_no").ToUpper());
        dao.setParam("@keep_org", form.getValue("keep_org"));

        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count > 0)
        {
            card_id = ds.Tables[0].Rows[0]["card_id"].ToString();
        }
        return card_id;
    }


    /// <summary>
    /// 查詢車隊卡對應資料
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public DataSet selectCarCard(Form form)
    {        
        String sql = "select * from c_car_card where 1=1 ";

        if (form.getValue("card_id") != string.Empty)
        {
            sql += "and card_id = @card_id ";
            dao.setParam("@card_id", form.getValue("card_id"));
        }

        if (form.getValue("car_id") != string.Empty)
        {
            sql += "and car_id = @car_id ";
            dao.setParam("@car_id", form.getValue("car_id"));
        }

        dao.CommandSQL = sql;    

        DataSet ds = dao.searchForDS();

        return ds;
    }


    /// <summary>
    /// 檢核是否相同的加油卡號
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public Boolean IsCardNoOverOne(String card_no)
    {
        Boolean flag = false;
        String sql = "select card_id from c_card_mst where card_no=@card_no";
        
        dao.CommandSQL = sql;
        dao.setParam("@card_no", card_no);
        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count > 1)
        {
            flag = true;
        }
        return flag;
    }


    /// <summary>
    /// 檢核car_id是否使用在勤務記錄中
    /// </summary>
    /// <param name="car_id"></param>
    /// <returns></returns>
    public Boolean IsCardIdExistWorkData(String card_id)
    {
        Boolean flag = false;
        String sql = "select work_id from c_work_mst where card_id=@card_id";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", card_id);
        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
        }
        return flag;
    }


    /// <summary>
    /// 檢核car_id是否使用在加油資料中
    /// </summary>
    /// <param name="car_id"></param>
    /// <returns></returns>
    public Boolean IsCardIdExistFuelData(String card_id)
    {
        Boolean flag = false;
        String sql = "select * from v_fuel where report_sts='Y' and card_id=@card_id ";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", card_id);
        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
        }
        return flag;
    }


    /// <summary>
    /// 修改加油卡資料
    /// </summary>
    /// <param name="form"></param>
    public void updateCardPossess(Form form)
    {
        String sql = "update c_car_card set possess_end=@possess_end,update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where possess_id=@possess_id";

        dao.CommandSQL = sql;
        dao.setParam("@possess_id", form.getValue("possess_id"));

        if(form.getValue("possess_end") != string.Empty)
            dao.setParam("@possess_end", form.getValue("possess_end")); 
        else
            dao.setParam("@possess_end", DBNull.Value);
 
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 異動記錄變更車牌修改舊的加油卡possess_end
    /// </summary>
    /// <param name="form"></param>
    public void updateCardPossessNull(Form form)
    {
        String sql = @"update c_car_card set possess_end=NULL, update_date=GETDATE(), update_user=@update_user 
            where possess_id= (select possess_id from c_car_card where card_id = @card_id and possess_end = 
            convert(varchar(10), DATEADD(day, -1, @chg_date), 111)) ";

        dao.CommandSQL = sql; 
       
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@chg_date", form.getValue("chg_date"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }




    /// <summary>
    /// 異動加油卡狀態
    /// </summary>
    /// <param name="form"></param>
    public void updateCardStatus(Form form)
    {
        String sql = "update c_card_mst set status=@status, update_date=GETDATE(), update_user=@update_user where card_id=@card_id";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }

    public void updateCardStatus1(Form form)
    {
        String sql = "update c_card_mst set status='X', update_date=GETDATE(), update_user=@update_user where card_id=@card_id";

        dao.CommandSQL = sql;
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 變更車隊卡
    /// </summary>
    /// <param name="form"></param>
    public void updateCarCard(Form form)
    {
        String sql = "update c_car_card set card_id=@new_card, update_date=GETDATE(), update_user=@update_user where card_id=@old_card";

        dao.CommandSQL = sql;
        dao.setParam("@new_card", form.getValue("new_card"));
        dao.setParam("@old_card", form.getValue("old_card"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }
}