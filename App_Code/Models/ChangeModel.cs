using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// ChangeModel 的摘要描述
/// </summary>
public class ChangeModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse1_dep_no"))
        {
            browse1_dep_no(pb, form);
        }
        else if (pbKey.Equals("browse1_car_no_s"))
        {
            browse1_car_no_s(pb, form);
        }
        else if (pbKey.Equals("browse1_car_type_s"))
        {
            browse1_car_type_s(pb, form);
        }
        else if (pbKey.Equals("browse1_chg_org_s"))
        {
            browse1_chg_org_s(pb, form);
        }
        else if (pbKey.Equals("browse1_chg_date_s"))
        {
            browse1_chg_date_s(pb, form);
        }
        else if (pbKey.Equals("browse1_chg_rsn_s"))
        {
            browse1_chg_rsn_s(pb, form);
        }
        //反排
        else if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);
        }
        else if (pbKey.Equals("browse1_dep_nod"))
        {
            browse1_dep_nod(pb, form);
        }
        else if (pbKey.Equals("browse1_car_no_sd"))
        {
            browse1_car_no_sd(pb, form);
        }
        else if (pbKey.Equals("browse1_car_type_sd"))
        {
            browse1_car_type_sd(pb, form);
        }
        else if (pbKey.Equals("browse1_chg_org_sd"))
        {
            browse1_chg_org_sd(pb, form);
        }
        else if (pbKey.Equals("browse1_chg_date_sd"))
        {
            browse1_chg_date_sd(pb, form);
        }
        else if (pbKey.Equals("browse1_chg_rsn_sd"))
        {
            browse1_chg_rsn_sd(pb, form);
        }
        //wenny_test_排序

        else if (pbKey.Equals("browse2"))
        {
            browseCRS(pb, form);
        }
    }

    /// <summary>
    /// 車輛異動記錄資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,d.card_id,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";
        //String where_org = "where 1=1";//wenny_test_車輛跨單位繼承

       if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
            //where_org += " and e.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";//新單位繼承舊單位資料
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }
        
        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct e.car_id from c_chg_mst e " + where_org;
        //sql = sql + where;
        //sql = "select * from (" + sql + ") as f where f.car_id in ( " + sqlchgorg + " ) ";

        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼
        pb.CommandSQL = sql;

        pb.OrderSQL = " chg_id desc ";

    }
    //wenny_test_排序
    //正排
    private void browse1_dep_no(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }

        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼
        pb.CommandSQL = sql;
        pb.OrderSQL = " dep_no  ";
    }
    private void browse1_car_no_s(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼


        pb.CommandSQL = sql;
        pb.OrderSQL = " car_no  ";
    }
    private void browse1_car_type_s(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }

        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " car_type  ";
    }
    private void browse1_chg_org_s(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }

        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " chg_org  ";
    }
    private void browse1_chg_date_s(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " chg_date  ";
    }
    private void browse1_chg_rsn_s(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " chg_rsn  ";
    }
    //反排
    private void browse1d(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼
        pb.CommandSQL = sql;
        pb.OrderSQL = " chg_id desc ";
    }
    private void browse1_dep_nod(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " dep_no desc ";
    }
    private void browse1_car_no_sd(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼
        pb.CommandSQL = sql;
        pb.OrderSQL = " car_no  desc ";
    }
    private void browse1_car_type_sd(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼
        pb.CommandSQL = sql;
        pb.OrderSQL = " car_type desc ";
    }
    private void browse1_chg_org_sd(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }

        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " chg_org desc ";
    }
    private void browse1_chg_date_sd(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }
        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " chg_date desc ";
    }
    private void browse1_chg_rsn_sd(PageBreak pb, Form form)
    {
        String sql = "select chg_id, a.car_id, dbo.chineseDate(chg_date) as chg_date,  convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) as last_date, " +
            "convert(varchar(10), c.possess_start, 111) as start_date, convert(varchar(10), possess_end, 111)  as end_date, b.car_type, a.chg_org, a.chg_rsn, " +
            "d.card_no as car_no,  b.dep_no " +
            "from c_chg_mst a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join c_car_card c on a.car_id = c.car_id and  convert(varchar(10), c.possess_start, 111) <= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), DATEADD(Day, -1, a.chg_date), 111)) " +
            "left join c_card_mst d on c.card_id = d.card_id ";

        String where = "where 1=1";
        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status like @status";
            pb.setParam("@status", "%" + form.getValue("status") + "%");
        }
        if (!form.getValue("car_no").Equals(""))
        {
            where += " and (d.card_no like @car_no or b.car_no like @car_no) ";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and b.dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }

        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " chg_rsn desc ";
    }








    private void browseCRS(PageBreak pb, Form form)
    {
        String sql = "select a.chg_id, a.car_id, dbo.chineseDate(a.chg_date) as chg_date, e.id_name as chg_rsn, " +
            "b.car_no, c.id_name as type_name, d.id_name as org_name, b.dep_no " +
            "from c_crs_chg a " +
            "left join c_car_mst b on a.car_id = b.car_id " +
            "left join a_sysparam_data c on b.car_type = c.param_id and c.param_type='CAR_TYPE' " +
            "left join a_sysparam_data d on a.chg_org = d.param_id and d.param_type='DEP_ORG' " +
            "left join a_sysparam_data e on a.chg_rsn = e.param_id and e.param_type='CRS_CHGRSN' ";

        String where = "where 1=1";

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

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and f.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and b.car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("chg_org").Equals(""))
        {
            where += " and a.chg_org in (" + handleMultiData("chg_org", form.getValue("chg_org"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {
            where += " and a.chg_rsn in (" + handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + ")";
        }

        if (!form.getValue("start_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  >= @start_date";
            pb.setParam("@start_date", DateTransfer.c_date_trans(form.getValue("start_date")));
        }

        if (!form.getValue("end_date").Equals(""))
        {
            where += " and convert(varchar(10) , a.chg_date, 111 )  <= @end_date";
            pb.setParam("@end_date", DateTransfer.c_date_trans(form.getValue("end_date")));
        }

        //wenny_可查舊單位資料
        //String sqlchgorg = "select distinct a.car_id from c_chg_mst a ";
        //sqlchgorg = sqlchgorg + where;
        //sql = sql + " where a.car_id in (" + sqlchgorg + ")";
        //wenny_可查舊單位資料
        //原程式碼
        sql = sql + where;
        //原程式碼

        pb.CommandSQL = sql;
        pb.OrderSQL = " car_no, chg_id ";
    }

    /// <summary>
    /// 新增異動記錄
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertChg(Form form)
    {
        String sql = "insert into c_chg_mst (car_id, chg_date, chg_rsn, r1_org, r5_license, chg_desc, chg_org, memo, " +
            "create_date, create_user, update_date, update_user,status) " +
            "values (@car_id, @chg_date, @chg_rsn, @r1_org, @r5_license, @chg_desc, @chg_org, @memo, GETDATE(), " +
            "@create_user, GETDATE(), @create_user,'O')";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@chg_date", form.getValue("chg_date"));
        dao.setParam("@chg_rsn", form.getValue("chg_rsn"));
        if (form.getValue("r1_org") != string.Empty)
        { dao.setParam("@r1_org", form.getValue("r1_org")); }
        else
        {
            dao.setParam("@r1_org", DBNull.Value);
        }


        if (form.getValue("r5_license") != string.Empty)
        { dao.setParam("@r5_license", form.getValue("r5_license")); }
        else
        {
            dao.setParam("@r5_license", DBNull.Value);
        }

        dao.setParam("@chg_desc", form.getValue("chg_desc"));
        dao.setParam("@chg_org", form.getValue("chg_org"));        
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));       
        Decimal chg_id = dao.insertForSEQ();

        insertCRSChg(form);
        return chg_id;
    }

    public  void updateChg(Form form)
    {
        String sql = "update [TDOS].[dbo].[c_chg_mst] set  chg_desc=@chg_desc,chg_rsn=@chg_rsn ,memo=@memo ,chg_date=@chg_date,status='O' where chg_id=@chg_id";

        dao.CommandSQL = sql;
        dao.setParam("@chg_desc", form.getValue("chg_desc"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@chg_id", form.getValue("chg_id"));
        dao.setParam("@chg_date", form.getValue("chg_date"));
        dao.setParam("@chg_org", form.getValue("chg_org"));
        dao.setParam("@chg_rsn", form.getValue("chg_rsn"));

        dao.executeModify();


    }

    //public void updateChg(Form form)
    //{
    //    String sql = "update [TDOS].[dbo].[c_chg_mst] set  chg_desc=@chg_desc,chg_rsn=@chg_rsn ,memo=@memo ,chg_date=@chg_date,status='O' where chg_id=@chg_id";

    //    dao.CommandSQL = sql;
    //    dao.setParam("@chg_desc", form.getValue("chg_desc"));
    //    dao.setParam("@memo", form.getValue("memo"));
    //    dao.setParam("@chg_id", form.getValue("chg_id"));
    //    dao.setParam("@chg_date", form.getValue("chg_date"));
    //    dao.setParam("@chg_org", form.getValue("chg_org"));
    //    dao.setParam("@chg_rsn", form.getValue("chg_rsn"));

    //    dao.executeModify();


    //}
    public void updateChg1(Form form)
    {
        String sql = "update [TDOS].[dbo].[c_chg_mst] set  r1_org=@keep_org,  chg_desc=@chg_desc,chg_rsn=@chg_rsn ,memo=@memo ,chg_date=@chg_date,status='O' where chg_id=@chg_id";

        dao.CommandSQL = sql;
        dao.setParam("@chg_desc", form.getValue("chg_desc"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@chg_id", form.getValue("chg_id"));
        dao.setParam("@chg_date", form.getValue("chg_date"));
        dao.setParam("@keep_org", form.getValue("keep_org"));
        dao.setParam("@chg_rsn", form.getValue("chg_rsn"));

        dao.executeModify();


    }



    public void keep_mst1(Form form)
    {
        String sql = "update [TDOS].[dbo].[c_keep_mst] set  keep_org=@keep_org  where keep_id=@keep_id";

        dao.CommandSQL = sql;
        
        dao.setParam("@keep_org", form.getValue("keep_org"));
        dao.setParam("@keep_id", form.getValue("keep_id"));

        dao.executeModify();


    }
    public void updateChg2(Form form)
    {
        String sql = "update [TDOS].[dbo].[c_chg_mst] set  chg_desc=@chg_desc,chg_rsn=@chg_rsn ,memo=@memo ,chg_date=@chg_date,r5_license=@car_no  ,status='O' where chg_id=@chg_id";

        dao.CommandSQL = sql;
        dao.setParam("@chg_desc", form.getValue("chg_desc"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@chg_id", form.getValue("chg_id"));
        dao.setParam("@chg_date", form.getValue("chg_date"));
        dao.setParam("@chg_org", form.getValue("chg_org"));
        dao.setParam("@chg_rsn", form.getValue("chg_rsn"));
        dao.setParam("@car_no", form.getValue("car_no"));

        dao.executeModify();


    }




    public void chg_org(Form form)
    {
        String sql = "update [TDOS].[dbo].[c_chg_mst] set  r1_org=@chg_org where chg_id=@chg_id";

        dao.CommandSQL = sql;
     
        dao.setParam("@chg_org", form.getValue("chg_org"));
        dao.setParam("@chg_id", form.getValue("chg_id"));

        dao.executeModify();


    }
    public void keep_mst(Form form)
    {
        String sql = "update [TDOS].[dbo].[c_keep_mst] set  keep_org=@chg_org where car_id=@car_id";

        dao.CommandSQL = sql;

        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@chg_org", form.getValue("chg_org"));

        dao.executeModify();


    }
    public void updateCarNo2(Form form)
    {
        String sql = "update c_car_mst set car_no=@car_no  ";

        sql = sql + " where car_no=@car_id2";

        dao.CommandSQL = sql;
        dao.setParam("@car_id2", form.getValue("car_id2"));

        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }

    public void updateCarNo3(Form form)
    {
        
        String sql = "update c_card_mst set card_no=@car_no  ";

        sql = sql + " where card_no=@car_id2";

        dao.CommandSQL = sql;
      
        dao.setParam("@car_id2", form.getValue("car_id2"));
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();

    }
    public void updateCarNo1(Form form)
    {
        String sql = "update c_card_mst set card_no=@car_no, memo = memo + @memo, update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where card_no=@car_no1";

        dao.CommandSQL = sql;

        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.setParam("@car_no1", form.getValue("car_no1"));

        dao.executeModify();

    }

    public Decimal insertCRSChg(Form form)
    {
        String sql = "insert into c_crs_chg (car_id, chg_date, chg_rsn, r1_org, chg_desc, chg_org, memo, " +
            "create_date, create_user, update_date, update_user) " +
            "values (@car_id, @chg_date, @chg_rsn, @r1_org, @chg_desc, @chg_org, @memo, GETDATE(), " +
            "@create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@chg_date", form.getValue("chg_date"));
        dao.setParam("@chg_rsn", form.getValue("chg_rsn"));
        if (form.getValue("r1_org") != string.Empty)
        { dao.setParam("@r1_org", form.getValue("r1_org")); }
        else
        {
            dao.setParam("@r1_org", DBNull.Value);
        }

        dao.setParam("@chg_desc", form.getValue("chg_desc"));
        dao.setParam("@chg_org", form.getValue("chg_org"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 查詢異動記錄
    /// </summary>
    /// <param name="car_id"></param>
    /// <returns></returns>
    public DataSet selectChg(String chg_id)
    {
        String sql = @"select  exec_id,d.card_id, c.keep_id, a.chg_id, dbo.chineseDate(a.chg_date) as chg_date, a.chg_rsn, a.r1_org, a.r5_license, a.chg_desc, a.memo, a.chg_org, 
            b.car_type, b.keep_org as new_keep, b.status as new_status, b.car_no, b.dep_no, b.car_id, b.card_no, b.card_id as new_card,  
            c.keep_org as old_keep, d.card_id as old_card, e.status as old_status, f.card_no as old_card_no, g.card_no as new_card_no 
            from c_chg_mst a 
            left join v_car b on a.car_id = b.car_id             
            left join c_keep_mst c on a.car_id = c.car_id and convert(varchar(10), c.keep_end,111) = convert(varchar(10), DATEADD(day, -1, a.chg_date),111)             
            left join c_car_card d on a.car_id = d.car_id and convert(varchar(10), d.possess_end,111) = convert(varchar(10), DATEADD(day, -1, a.chg_date),111) 
            left join c_car_sts e on a.car_id = e.car_id and convert(varchar(10), e.exec_end,111) = convert(varchar(10), DATEADD(day, -1, a.chg_date),111) 
            left join c_card_mst f on d.card_id = f.card_id 
            left join c_card_mst g on b.card_id = g.card_id 
            where a.chg_id = @chg_id";

        dao.CommandSQL = sql;
        dao.setParam("@chg_id", chg_id);
        return dao.searchForDS();
    }

    public DataSet selectCRSChg(String chg_id)
    {
        String sql = "select a.chg_id, dbo.chineseDate(a.chg_date) as chg_date, a.chg_rsn, a.r1_org, " +
            "a.chg_desc, a.car_status, a.memo, b.car_no, b.dep_no, b.car_id, b.card_no, b.type_name, " +
            "d.id_name as org_name , a.chg_org, b.status_name, e.card_id from c_crs_chg a " +
            "left join v_car b on a.car_id = b.car_id " +
            "left join c_keep_mst c on a.car_id = c.car_id " +
            "and convert(varchar(10), c.keep_start,111) <= convert(varchar(10), a.chg_date,111) " +
            "and (c.keep_end is null or convert(varchar(10), c.keep_end,111) >= convert(varchar(10), " +
            "a.chg_date,111)) " +
            "left join a_sysparam_data d on c.keep_org = d.param_id and d.param_type='DEP_ORG' " +
            " left join c_car_card e on a.car_id = e.car_id and convert(varchar(10), e.possess_start,111) <= convert(varchar(10), a.chg_date,111) " +
            "and (e.possess_end is null or convert(varchar(10), e.possess_end,111) >= convert(varchar(10), a.chg_date,111)) " +
            "where a.chg_id = @chg_id";

        dao.CommandSQL = sql;
        dao.setParam("@chg_id", chg_id);
        return dao.searchForDS();
    }


    /// <summary>
    /// 刪除異動記錄
    /// </summary>
    /// <param name="card_id"></param>
    public void deleteChg(String chg_id)
    {
        String sql = "update c_chg_mst  set status='X' where chg_id=@chg_id";

        dao.CommandSQL = sql;
        dao.setParam("@chg_id", chg_id);
        dao.executeModify();
    }


    public void NewChg(String chg_id)
    {
        String sql = "update c_chg_mst  set status='O' where chg_id=@chg_id";

        dao.CommandSQL = sql;
        dao.setParam("@chg_id", chg_id);
        dao.executeModify();
    }
    public void updateCarKeep(Form form)
    {
        String sql = "update c_keep_mst set update_date=GETDATE(), update_user=@update_user  ,keep_org=@keep_org  where car_id=@car_id";

       
            
        




        dao.CommandSQL = sql;
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.setParam("@keep_org", form.getValue("keep_org"));
        dao.setParam("@car_id", form.getValue("car_id"));

        dao.executeModify();
    }
    
        public void updatec_card_mst(Form form)
    {
        String sql = "update c_card_mst set keep_org=@keep_org  where card_no=@car_no1";








        dao.CommandSQL = sql;
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.setParam("@keep_org", form.getValue("keep_org"));
        dao.setParam("@car_no1", form.getValue("car_no1"));

        dao.executeModify();
    }
    /// <summary>
    ///  修改移撥舊加油卡的持有結束日
    /// </summary>
    /// <param name="form"></param>
    public void updateCardPossessOld(Form form)
    {
        String sql = "update c_car_card set possess_end = null where convert(varchar(10), possess_end, 111)=@possess_end and car_id=@car_id ";

        dao.CommandSQL = sql;
        dao.setParam("@possess_end", form.getValue("keep_end"));
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.executeModify();
    }

    /// <summary>
    /// 刪除移撥新加油卡持有資料
    /// </summary>
    /// <param name="form"></param>
    public void deleteCardPossessNew(Form form)
    {
        String sql = "delete c_car_card where possess_id=(select possess_id from c_car_card where convert(varchar(10), possess_start,111)=@keep_start " +
            "and car_id=@car_id) ";

        dao.CommandSQL = sql;
        dao.setParam("@keep_start", form.getValue("keep_start"));
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.executeModify();
    }


    /// <summary>
    /// 刪除移撥新保管單位
    /// </summary>
    /// <param name="chg_id"></param>
    /// <param name="r1_org"></param>
    public void deletekeepNew(Form form)
    {
        String sql = "delete c_keep_mst where keep_id=(select keep_id from c_keep_mst where convert(varchar(10), keep_start,111)=@keep_start " +
            "and car_id=@car_id) ";

        dao.CommandSQL = sql;
        dao.setParam("@keep_start", form.getValue("keep_start"));
        dao.setParam("@car_id", form.getValue("car_id"));    
        dao.executeModify();
    }


    /// <summary>
    /// 刪除新狀態資料
    /// </summary>
    /// <param name="form"></param>
    public void deleteStatusNew(Form form)
    {
        String sql = "delete c_car_sts where exec_id=(select exec_id from c_car_sts where convert(varchar(10), exec_start,111)=@exec_start " +
            "and car_id=@car_id) ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@exec_start", form.getValue("keep_start"));        
        dao.executeModify();
        deleteCRSStatusNew(form);
    }


    public void deleteCRSStatusNew(Form form)
    {
        String sql = "delete c_crs_sts where exec_id=(select exec_id from c_car_sts where convert(varchar(10), exec_start,111)=@exec_start " +
            "and car_id=@car_id) ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@exec_start", form.getValue("keep_start"));
        dao.executeModify();
    }


    /// <summary>
    /// 修改移撥舊保管單位
    /// </summary>
    /// <param name="chg_id"></param>
    /// <param name="chg_org"></param>
    public void updatekeepOld(Form form)
    {
        String sql = "update c_keep_mst set keep_end = null where keep_id=(select keep_id from c_keep_mst where " +
            "convert(varchar(10), keep_end, 111)=@keep_end and car_id=@car_id)  ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@keep_end", form.getValue("keep_end"));
        dao.executeModify();
    }


    /// <summary>
    /// 修改報廢的舊狀態資料
    /// </summary>
    /// <param name="form"></param>
    public void updateStatusOld(Form form)
    {
        String sql = "update c_car_sts set exec_end = null,status='C' where exec_id=(select exec_id from c_car_sts where " +
            "convert(varchar(10), exec_end, 111)=@exec_end and car_id=@car_id)  ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@exec_end", form.getValue("keep_end"));
        dao.executeModify();
        updateCRSStatusOld(form);
    }

    public void updateStatusOld1(Form form)
    {
        String sql = "update c_car_sts set exec_end = null,status='O'   " +
            "  where  car_id=@car_id  ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@exec_end", form.getValue("keep_end"));
        dao.executeModify();
        updateCRSStatusOld(form);
    }

    public void updateCRSStatusOld(Form form)
    {
        String sql = "update c_crs_sts set exec_end = null where exec_id=(select exec_id from c_car_sts where " +
            "convert(varchar(10), exec_end, 111)=@exec_end and car_id=@car_id)  ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@exec_end", form.getValue("keep_end"));
        dao.executeModify();
    }

    /// <summary>
    /// 取得異動日期前一日的車隊卡卡號
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public String getCardNo(Form form)
    {
        String card_no = string.Empty;
        String sql = "select card_no from c_card_mst where card_id=(select card_id from c_car_card where car_id=@car_id " +
            "and convert(varchar(10), possess_start, 111)<=@possess_end and " +
            "(possess_end is null or convert(varchar(10), possess_end, 111)>=@possess_end))";

        dao.CommandSQL = sql;

        DateTime possess_end = Convert.ToDateTime(form.getValue("chg_date"));
        possess_end = possess_end.AddDays(-1);

        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@possess_end", possess_end.ToString("yyyy/MM/dd"));

        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            card_no = dr["card_no"].ToString();
        }
        return card_no;
    }


    /// <summary>
    /// 在車輛異動記錄修改頁顯示該車輛過去的保管時間及狀態
    /// </summary>
    /// <param name="form"></param>
    public DataSet getCarStatus(Form form)
    {
        String sql = "select row_number() over (order by exec_id) as row_num, exec_id, status, " +
            "dbo.chineseDate(exec_start) as exec_start, dbo.chineseDate(exec_end) as exec_end, dbo.chineseDateTime(update_date) as update_date from c_car_sts " +
            "where car_id=@car_id ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));               

        return dao.searchForDS();
    }


    public DataSet getCarCard(Form form)
    {
        String sql = "select row_number() over (order by possess_id) as row_num, possess_id, card_id, " +
            "dbo.chineseDate(possess_start) as possess_start, dbo.chineseDate(possess_end) as possess_end, dbo.chineseDateTime(update_date) as update_date from c_car_card " +
            "where car_id=@car_id ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));

        return dao.searchForDS();
    }


    public DataSet getCRSCarStatus(Form form)
    {
        String sql = "select row_number() over (order by exec_id) as row_num, exec_id, status, " +
            "dbo.chineseDate(exec_start) as exec_start, dbo.chineseDate(exec_end) as exec_end, dbo.chineseDateTime(update_date) as update_date from c_crs_sts " +
            "where car_id=@car_id ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));

        return dao.searchForDS();
    }


    /// <summary>
    /// 變更車輛狀態
    /// </summary>
    /// <param name="form"></param>
    public void updateStatus(Form form)
    {
        String sql = "update c_car_sts set status = @status, update_user=@update_user, update_date=getdate() where exec_id=@exec_id ";

        dao.CommandSQL = sql;
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@exec_id", form.getValue("exec_id"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.executeModify();
    }


    /// <summary>
    /// 查詢上一筆異動記錄
    /// </summary>
    /// <returns></returns>
    public DataSet selectLastChg(Form form)
    {
        String sql = "select top(1)* from c_chg_mst where car_id = @car_id order by chg_id desc";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));

        return dao.searchForDS();
    }
}