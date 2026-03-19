using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// CarModel 的摘要描述
/// </summary>
public class CarModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        //wenny_test_排序
        //正排
        //新增廠牌欄位正排序_wenny1061122
        else if (pbKey.Equals("browse1Brand_no"))
        {
            browse1Brand_no(pb, form);
        }
        //新增噸數欄位正排序_wenny1061122
        else if (pbKey.Equals("browse1Tonnage"))
        {
            browse1Tonnage(pb, form);
        }
        else if (pbKey.Equals("browse1car_no"))
        {
            browse1car_no(pb, form);
        }
        else if (pbKey.Equals("browse1dep_no"))
        {
            browse1dep_no(pb, form);
        }
        else if (pbKey.Equals("browse1card_no"))
        {
            browse1card_no(pb, form);
        }
        else if (pbKey.Equals("browse1car_type"))
        {
            browse1car_type(pb, form);
        }
        else if (pbKey.Equals("browse1fuel_type"))
        {
            browse1fuel_type(pb, form);
        }
        else if (pbKey.Equals("browse1keep_org"))
        {
            browse1keep_org(pb, form);
        }
        else if (pbKey.Equals("browse1status"))
        {
            browse1status(pb, form);
        }
        //反排
        //新增廠牌欄位反排序_wenny1061122
        else if (pbKey.Equals("browse1Brand_noD"))
        {
            browse1Brand_noD(pb, form);
        }
        //新增噸數欄位正排序_wenny1061122
        else if (pbKey.Equals("browse1TonnageD"))
        {
            browse1TonnageD(pb, form);
        }
        else if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);
        }
        else if (pbKey.Equals("browse1car_nod"))
        {
            browse1car_nod(pb, form);
        }
        else if (pbKey.Equals("browse1dep_nod"))
        {
            browse1dep_nod(pb, form);
        }
        else if (pbKey.Equals("browse1card_nod"))
        {
            browse1card_nod(pb, form);
        }
        else if (pbKey.Equals("browse1car_typed"))
        {
            browse1car_typed(pb, form);
        }
        else if (pbKey.Equals("browse1fuel_typed"))
        {
            browse1fuel_typed(pb, form);
        }
        else if (pbKey.Equals("browse1keep_orgd"))
        {
            browse1keep_orgd(pb, form);
        }
        else if (pbKey.Equals("browse1statusd"))
        {
            browse1statusd(pb, form);
        }
    }

    /// <summary>
    /// 車輛基本資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no ";
    }
    //wenny_test_排序
    //正排
    //新增廠牌欄位正排序_wenny1061122
    private void browse1Brand_no(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "brand_no ";
    }
    //新增噸數欄位正排序_wenny1061122
    private void browse1Tonnage(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "tonnage ";
    }
    private void browse1car_no(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no ";
    }
    private void browse1dep_no(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "dep_no ";
    }
    private void browse1card_no(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no ";
    }
    private void browse1car_type(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_type ";
    }
    private void browse1fuel_type(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_type ";
    }
    private void browse1keep_org(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "keep_org ";
    }
    private void browse1status(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "status ";
    }
    //反排
    //新增廠牌欄位反排序_wenny1061122
    private void browse1Brand_noD(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "brand_no desc ";
    }
    //新增噸數欄位正排序_wenny1061122
    private void browse1TonnageD(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "tonnage desc ";
    }
    private void browse1d(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no desc ";
    }
    private void browse1car_nod(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_no desc ";
    }
    private void browse1dep_nod(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "dep_no desc ";
    }
    private void browse1card_nod(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "card_no desc ";
    }
    private void browse1car_typed(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "car_type desc";
    }
    private void browse1fuel_typed(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "fuel_type desc";
    }
    private void browse1keep_orgd(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "keep_org desc ";
    }
    private void browse1statusd(PageBreak pb, Form form)
    {
        //String sql = "select distinct a.car_id, a.car_no, g.card_no, a.car_type, f.id_name as org_name, " +
        //    "h.status, a.dep_no, e.id_name as fuel_type from c_car_mst a " +
        //    //"left join a_sysparam_data b on a.car_type = b.param_id and b.param_type='CAR_TYPE' " +
        //    "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
        //    "where convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) and (keep_end is null or " +
        //    "convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c on a.car_id = c.car_id " +
        //    "left join a_sysparam_data f on c.keep_org = f.param_id and f.param_type='DEP_ORG' " +
        //    "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
        //    "where convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
        //    "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
        //    "on a.car_id = d.car_id " +
        //    "left join c_card_mst g on d.card_id = g.card_id " +
        //    "left join a_sysparam_data e on a.fuel_type = e.param_id and e.param_type='FUEL_TYPE' " +
        //    "left join c_car_sts h on a.car_id = h.car_id and convert(varchar(10), h.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
        //    "and (h.exec_end is null or convert(varchar(10), h.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) ";

        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            pb.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            pb.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        //if (!form.getValue("card_no").Equals(""))
        //{
        //    where += " and g.card_no like @card_no";
        //    pb.setParam("@card_no", "%" + form.getValue("card_no") + "%");
        //}

        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type"), pb) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org"), pb) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type"), pb) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn"), pb) + "))";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "status desc ";
    }


    /// <summary>
    /// 新增車輛
    /// </summary>
    /// <param name="form"></param>
    public Decimal insertCar(Form form)
    {
        String sql = "insert into c_car_mst (car_no, dep_no, car_type, car_year, buy_date, brand_no, engine_no, " +
            "tonnage, displacement, fuel_type, fuel_std, status, add_device, check_date, memo, create_date, create_user, update_date, " +
            "update_user, next_inspection, licensing_date,car) " +
            "values (@car_no, @dep_no, @car_type, @car_year, @buy_date, @brand_no, @engine_no, @tonnage, " +
            "@displacement, @fuel_type, @fuel_std, @status, @add_device, @check_date, @memo, GETDATE(), @create_user, GETDATE(), " +
            "@create_user, @next_inspection, @licensing_date,@car)";

        dao.CommandSQL = sql;
        dao.setParam("@car", form.getValue("car"));

        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@dep_no", form.getValue("dep_no"));
        dao.setParam("@car_type", form.getValue("car_type"));
        dao.setParam("@car_year", form.getValue("car_year"));
        dao.setParam("@buy_date", form.getValue("buy_date"));
        dao.setParam("@brand_no", form.getValue("brand_no"));
        dao.setParam("@engine_no", form.getValue("engine_no"));
        dao.setParam("@tonnage", form.getValue("tonnage"));
        dao.setParam("@displacement", form.getValue("displacement"));
        dao.setParam("@fuel_type", form.getValue("fuel_type"));
        dao.setParam("@fuel_std", form.getValue("fuel_std"));
        dao.setParam("@status", form.getValue("status"));



        if (form.getValue("user_sys").Equals(IniValue.sysCRS))
        {
            dao.setParam("add_device", form.getValue("add_device"));

            if (!form.getValue("check_date").Equals(""))
                dao.setParam("check_date", form.getValue("check_date"));
            else
                dao.setParam("check_date", DBNull.Value);
        }
        else
        {
            dao.setParam("add_device", DBNull.Value);
            dao.setParam("check_date", DBNull.Value);
        }

        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        //下次定檢日
        if (!form.getValue("next_inspection").Equals(""))
        {
            dao.setParam("@next_inspection", form.getValue("next_inspection"));
        }
        else
        {
            dao.setParam("@next_inspection", DBNull.Value);
        }

        //發照日期
        if (!form.getValue("licensing_date").Equals(""))
        {
            dao.setParam("@licensing_date", form.getValue("licensing_date"));
        }
        else
        {
            dao.setParam("@licensing_date", DBNull.Value);
        }

        return dao.insertForSEQ();
    }


    /// <summary>
    /// 新增車輛保管記錄
    /// </summary>
    /// <param name="form"></param>
    public void insertCarkeep(Form form)
    {
        String sql = "insert into c_keep_mst (car_id, keep_org, keep_start, chg_id, create_date, create_user, " +
            "update_date, update_user) " +
            "values (@car_id, @keep_org, @keep_start, @chg_id, GETDATE(), @create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@keep_org", form.getValue("keep_org"));
        dao.setParam("@keep_start", form.getValue("keep_start"));
        if (form.getValue("chg_id") != string.Empty)
        {
            dao.setParam("@chg_id", form.getValue("chg_id"));
        }
        else
        {
            dao.setParam("@chg_id", DBNull.Value);
        }
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 新增車輛對應車隊卡資料
    /// </summary>
    /// <param name="form"></param>
    public void insertCarCard(Form form)
    {
        String sql = "insert into c_car_card (car_id, card_id, possess_start, create_date, create_user, " +
            "update_date, update_user) " +
            "values (@car_id, @card_id, @possess_start, GETDATE(), @create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@possess_start", form.getValue("possess_start"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 新增車輛狀態資料
    /// </summary>
    /// <param name="form"></param>
    public void insertCarStatus(Form form)
    {
        String sql = "insert into c_car_sts (car_id, status, exec_start, create_date, create_user, update_date, update_user) " +
            "values (@car_id, @status, @exec_start, GETDATE(), @create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@car", form.getValue("car"));

        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@exec_start", form.getValue("exec_start"));
        dao.setParam("@create_user", form.getValue("create_user"));
        dao.executeModify();

        //insertCRSCarStatus(form);
    }

    public void insertCarStatus1(Form form)
    {
        String sql = "insert into c_car_sts (car_id, status, exec_start, create_date, create_user, update_date, update_user) " +
            "values (@car_id, 'O', @exec_start, GETDATE(), @create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@exec_start", form.getValue("exec_start"));
        dao.setParam("@create_user", form.getValue("create_user"));
        dao.executeModify();

        //insertCRSCarStatus(form);


    }
        //public void insertCRSCarStatus(Form form)
        //{
        //    String sql = "insert into c_crs_sts (car_id, status, exec_start, create_date, create_user, update_date, update_user) " +
        //        "values (@car_id, @status, @exec_start, GETDATE(), @create_user, GETDATE(), @create_user)";

        //    dao.CommandSQL = sql;
        //    dao.setParam("@car_id", form.getValue("car_id"));
        //    dao.setParam("@status", form.getValue("status"));
        //    dao.setParam("@exec_start", form.getValue("exec_start"));
        //    dao.setParam("@create_user", form.getValue("create_user"));

        //    dao.executeModify();
        //}


        /// <summary>
        /// 查詢車輛明細
        /// </summary>
        /// <param name="car_id"></param>
        /// <returns></returns>
        public DataSet selectCar(Form form)
    {
        String sStatusTable = "c_car_sts";
        //if (form.getValue("user_sys").Equals(IniValue.sysCRS))
        //    sStatusTable = "c_crs_sts";

        String sql = "select CAR,a.car_id, a.dep_no, a.car_no, a.car_type,  a.car_year, e.card_id, dbo.chineseDate(a.buy_date) as buy_date, a.brand_no, a.engine_no, " +
            "a.tonnage, a.displacement, d.possess_id, d.card_id, e.card_no, a.fuel_type, a.fuel_std, f.status, f.exec_id, a.add_device,  " +
            "dbo.chineseDate(a.check_date) as check_date, a.memo, " +
            "dbo.chineseDate(b.chg_date) as chg_date, b.chg_desc, b.chg_rsn, c.keep_org, " +
            "convert(varchar(10), c.keep_start, 111) as keep_start, c.keep_end, c.keep_id, " +

            //2016.05.26新增
            "dbo.chineseDate(a.next_inspection) as next_inspection,dbo.chineseDate(a.licensing_date) as licensing_date " +

            "from c_car_mst a " +
            "left join (select top (1) * from c_chg_mst where car_id= @car_id) b on a.car_id = b.car_id " +
            "left join (select keep_id, car_id, keep_org, keep_start, keep_end from c_keep_mst " +
            "where car_id = @car_id and convert(varchar(10), keep_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
            "and (keep_end is null or convert(varchar(10), keep_end, 111)  >= convert(varchar(10), GETDATE(), 111))) c " +
            "on a.car_id = c.car_id " +
            "left join (select possess_id, car_id, card_id, possess_start, possess_end from c_car_card " +
            "where car_id = @car_id and convert(varchar(10), possess_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
            "and (possess_end is null or convert(varchar(10), possess_end, 111)  >= convert(varchar(10), GETDATE(), 111))) d " +
            "on a.car_id = d.car_id " +
            "left join c_card_mst e on d.card_id = e.card_id " +
            "left join " + sStatusTable + " f on a.car_id = f.car_id and convert(varchar(10), f.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
            "and (f.exec_end is null or convert(varchar(10), f.exec_end, 111)>= convert(varchar(10), GETDATE(), 111)) " +
            "where 1=1 ";

        if (form.getValue("car_id") != string.Empty)
        {
            sql += "and a.car_id = @car_id ";
            dao.setParam("@car_id", form.getValue("car_id"));
        }

        if (form.getValue("car_no") != string.Empty)
        {
            sql += "and a.car_no like @car_no ";
            dao.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (form.getValue("dep_no") != string.Empty)
        {
            sql += "and a.dep_no like @dep_no ";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }

        if (form.getValue("dep_car") != string.Empty)
        {
            sql += "and (a.car_no like @dep_car or dep_no like @dep_car) ";
            dao.setParam("@dep_car", "%" + form.getValue("dep_car") + "%");
        }

        if (form.getValue("keep_org") != string.Empty)
        {
            sql += "and c.keep_org = @keep_org ";
            dao.setParam("@keep_org", form.getValue("keep_org"));
        }

        dao.CommandSQL = sql;
        return dao.searchForDS();
    }


    /// <summary>
    /// 查詢車輛最新一筆狀態記錄
    /// </summary>
    /// <param name="car_id"></param>
    /// <param name="exec_start"></param>
    /// <returns></returns>
    public DataSet selectCarLatestStatus(String car_id)
    {
        String sql = "select exec_id, car_id, status, convert(varchar(10), exec_start, 111) as exec_start from c_car_sts " +
            "where car_id = @car_id and exec_end is NULL order by exec_id desc";

        dao.setParam("@car_id", car_id);

        dao.CommandSQL = sql;
        return dao.searchForDS();
    }


    /// <summary>
    /// 依車牌號碼或局編號查詢車輛ID
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public DataSet selectCarIdbyNo(Form form)
    {
        String sql = "select car_id from v_car " +
            "where car_no like @dep_car or dep_no like @dep_car ";

        if (form.getValue("keep_org") != string.Empty)
        {

            sql += "and keep_org = @keep_org";
            dao.setParam("@keep_org", form.getValue("keep_org"));
        }

        dao.setParam("@dep_car", "%" + form.getValue("dep_car") + "%");

        dao.CommandSQL = sql;
        return dao.searchForDS();
    }


    /// <summary>
    /// 修改車輛
    /// </summary>
    /// <param name="form"></param>
    public void updateCar(Form form)
    {
        String sql = "update c_car_mst set car_no= @car_no, dep_no=@dep_no, car_type=@car_type, " +
            "car_year=@car_year, buy_date=@buy_date, brand_no=@brand_no, engine_no=@engine_no, " +
            "tonnage=@tonnage, displacement=@displacement, fuel_type=@fuel_type, fuel_std= @fuel_std, " +
            "status=@status, memo=@memo, update_date=GETDATE(), update_user=@update_user, " +

            "next_inspection=@next_inspection, licensing_date=@licensing_date ,car=@car";

        if (form.getValue("user_sys").Equals(IniValue.sysCRS))
        {
            sql += ", add_device=@add_device, check_date = @check_date";
            dao.setParam("@add_device", form.getValue("add_device"));
            if (!form.getValue("check_date").Equals(""))
                dao.setParam("@check_date", form.getValue("check_date"));
            else
                dao.setParam("@check_date", DBNull.Value);


        }

        sql = sql + " where car_id=@car_id";

        dao.CommandSQL = sql;
        dao.setParam("@car", form.getValue("car"));

        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@dep_no", form.getValue("dep_no"));
        dao.setParam("@car_type", form.getValue("car_type"));
        dao.setParam("@car_year", form.getValue("car_year"));
        dao.setParam("@buy_date", form.getValue("buy_date"));
        dao.setParam("@brand_no", form.getValue("brand_no"));
        dao.setParam("@engine_no", form.getValue("engine_no"));
        dao.setParam("@tonnage", form.getValue("tonnage"));
        dao.setParam("@displacement", form.getValue("displacement"));
        dao.setParam("@fuel_type", form.getValue("fuel_type"));
        dao.setParam("@fuel_std", form.getValue("fuel_std"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));

        //dao.setParam("@next_inspection", form.getValue("next_inspection"));//下次定檢日
        //dao.setParam("@licensing_date", form.getValue("licensing_date")); //發照日期

        //下次定檢日
        if (!form.getValue("next_inspection").Equals(""))
        {
            dao.setParam("@next_inspection", form.getValue("next_inspection"));
        }
        else
        {
            dao.setParam("@next_inspection", DBNull.Value);
        }

        //發照日期
        if (!form.getValue("licensing_date").Equals(""))
        {
            dao.setParam("@licensing_date", form.getValue("licensing_date"));
        }
        else
        {
            dao.setParam("@licensing_date", DBNull.Value);
        }

        dao.executeModify();
    }


    /// <summary>
    /// 變更車牌號碼
    /// </summary>
    /// <param name="form"></param>
    public void updateCarNo(Form form)
    {
        String sql = "update c_car_mst set car_no=@car_no, memo = memo + @memo, update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where car_id=@car_id";

        dao.CommandSQL = sql;

        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@car_no", form.getValue("car_no"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();

    }

    /// <summary>
    /// 異動車輛狀態
    /// </summary>
    /// <param name="form"></param>
    public void updateCarStatus(Form form)
    {
        String sql = "update c_car_sts set exec_end=@exec_end, update_date=GETDATE(), " +
            "update_user=@update_user ";

        if (form.getValue("status") != string.Empty)
        {
            sql += ", status=@status ";
            dao.setParam("@status", form.getValue("status"));
        }

        if (form.getValue("exec_start") != string.Empty)
        {
            sql += ", exec_start=@exec_start ";
            dao.setParam("@exec_start", form.getValue("exec_start"));
        }

        if (form.getValue("exec_end") != string.Empty)
        {
            dao.setParam("@exec_end", form.getValue("exec_end"));
        }
        else
        {
            dao.setParam("@exec_end", DBNull.Value);
        }

        sql = sql + " where exec_id=@exec_id";

        dao.CommandSQL = sql;
        dao.setParam("@exec_id", form.getValue("exec_id"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.executeModify();

        //updateCRSCarStatus(form);
    }

    public void updateCarStatus1(Form form)
    {
        String sql = "update c_car_sts set exec_end=@exec_end, update_date=GETDATE(), " +
            "update_user=@update_user ,status='O'";

      

        if (form.getValue("exec_start") != string.Empty)
        {
            sql += ", exec_start=@exec_start ";
            dao.setParam("@exec_start", form.getValue("exec_start"));
        }

        if (form.getValue("exec_end") != string.Empty)
        {
            dao.setParam("@exec_end", form.getValue("exec_end"));
        }
        else
        {
            dao.setParam("@exec_end", DBNull.Value);
        }

        sql = sql + " where exec_id=@exec_id";

        dao.CommandSQL = sql;
        dao.setParam("@exec_id", form.getValue("exec_id"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.executeModify();

        //updateCRSCarStatus(form);
    }
    public void updateCarStatus2(Form form)
    {
        String sql = "update c_car_sts set exec_end=@exec_end, update_date=GETDATE(), " +
            "update_user=@update_user ,status='C'";



        if (form.getValue("exec_start") != string.Empty)
        {
            sql += ", exec_start=@exec_start ";
            dao.setParam("@exec_start", form.getValue("exec_start"));
        }

        if (form.getValue("exec_end") != string.Empty)
        {
            dao.setParam("@exec_end", form.getValue("exec_end"));
        }
        else
        {
            dao.setParam("@exec_end", DBNull.Value);
        }

        sql = sql + " where exec_id=@exec_id";

        dao.CommandSQL = sql;
        dao.setParam("@exec_id", form.getValue("exec_id"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.executeModify();

        //updateCRSCarStatus(form);
    }

    public void updateCarStatus3(Form form)
    {
        String sql = "update c_car_sts set exec_end=@exec_end, update_date=GETDATE(), " +
            "update_user=@update_user ";



        if (form.getValue("exec_start") != string.Empty)
        {
            sql += ", exec_start=@exec_start ";
            dao.setParam("@exec_start", form.getValue("exec_start"));
        }

        if (form.getValue("exec_end") != string.Empty)
        {
            dao.setParam("@exec_end", form.getValue("exec_end"));
        }
        else
        {
            dao.setParam("@exec_end", DBNull.Value);
        }

        sql = sql + " where car_id =@car_id and status='報廢' ";

        dao.CommandSQL = sql;
        dao.setParam("@exec_id", form.getValue("exec_id"));
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.executeModify();

        //updateCRSCarStatus(form);
    }
    public void updatec_car_mst(Form form)
    {
        String sql = "update c_car_mst set status='C' ";


      

        sql = sql + " where car_no=@car_no";

        dao.CommandSQL = sql;
        dao.setParam("@exec_id", form.getValue("exec_id"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.executeModify();

        //updateCRSCarStatus(form);
    }
    public void updateCRSCarStatus(Form form)
    {
        String sql = "update c_crs_sts set exec_end=@exec_end, update_date=GETDATE(), " +
            "update_user=@update_user ";

        if (form.getValue("status") != string.Empty)
        {
            sql += ", status=@status ";
            dao.setParam("@status", form.getValue("status"));
        }

        if (form.getValue("exec_start") != string.Empty)
        {
            sql += ", exec_start=@exec_start ";
            dao.setParam("@exec_start", form.getValue("exec_start"));
        }

        if (form.getValue("exec_end") != string.Empty)
        {
            dao.setParam("@exec_end", form.getValue("exec_end"));
        }
        else
        {
            dao.setParam("@exec_end", DBNull.Value);
        }

        sql = sql + " where exec_id=@exec_id";

        dao.CommandSQL = sql;
        dao.setParam("@exec_id", form.getValue("exec_id"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 系統管理員可修正車輛基本資料異動會修改到c_crs_sts可能是錯誤的exec_id
    /// </summary>
    /// <param name="car_no"></param>
    public Boolean correctCarStatusByAdmin(String car_no)
    {
        String sql = "update c_car_sts set exec_end = NULL, update_date= getdate(), update_user = 'ADMIN' " +
            "where exec_id = (select top(1) exec_id from c_crs_sts " +
            "where car_id = (select car_id from c_car_mst where car_no = @car_no) " +
            "order by exec_end desc) ";

        dao.CommandSQL = sql;
        dao.setParam("@car_no", car_no);


        return dao.executeModify();
    }

    /// <summary>
    /// 修改車輛保管記錄
    /// </summary>
    /// <param name="form"></param>
    public void updateCarKeep(Form form)
    {
        String sql = "update c_keep_mst set update_date=GETDATE(), update_user=@update_user";

        if (form.getValue("keep_org") != string.Empty)
        {
            sql += ", keep_org=@keep_org";
            dao.setParam("@keep_org", form.getValue("keep_org"));
        }

        if (form.getValue("keep_end") != string.Empty)
        {
            sql += ", keep_end=@keep_end";
            dao.setParam("@keep_end", form.getValue("keep_end"));
        }

        if (form.getValue("memo") != string.Empty)
        {
            sql += ", memo = memo + @memo";
            dao.setParam("@memo", form.getValue("memo"));
        }

        if (form.getValue("keep_start") != string.Empty)
        {
            sql += ", keep_start=@keep_start";
            dao.setParam("@keep_start", form.getValue("keep_start"));
        }

        sql = sql + " where keep_id=@keep_id";

        dao.CommandSQL = sql;
        dao.setParam("@keep_id", form.getValue("keep_id"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 修改車輛對應車隊卡資料
    /// </summary>
    /// <param name="form"></param>
    public void updateCarCard(Form form)
    {
        String sql = "update c_car_card set car_id=@car_id, card_id=@card_id, update_date=GETDATE(), " +
            "update_user=@update_user ";

        if (form.getValue("possess_start") != string.Empty)
        {
            sql += ", possess_start=@possess_start ";
            dao.setParam("@possess_start", form.getValue("possess_start"));
        }

        if (form.getValue("possess_end") != string.Empty)
        {
            sql += ", possess_end=@possess_end ";
            dao.setParam("@possess_end", form.getValue("possess_end"));
        }

        sql = sql + " where possess_id=@possess_id";

        dao.CommandSQL = sql;
        dao.setParam("@possess_id", form.getValue("possess_id"));
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.setParam("@card_id", form.getValue("card_id"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 刪除車輛
    /// </summary>
    /// <param name="card_id"></param>
    public void deleteCar(String car_id)
    {
        String sql = "delete c_car_mst where car_id=@car_id";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        dao.executeModify();
    }


    /// <summary>
    /// 刪除車輛保管單位對應
    /// </summary>
    /// <param name="car_id"></param>
    public void deleteCarKeep(String car_id)
    {
        String sql = "delete c_keep_mst where car_id=@car_id";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        dao.executeModify();
    }

    /// <summary>
    /// 刪除車輛對應加油卡對應
    /// </summary>
    /// <param name="car_id"></param>
    public void deleteCarCard(String car_id)
    {
        String sql = "delete c_car_card where car_id=@car_id";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        dao.executeModify();
    }


    /// <summary>
    /// 刪除車輛的狀態資料
    /// </summary>
    /// <param name="car_id"></param>
    public void deleteCarStatus(String car_id)
    {
        String sql = "delete c_car_sts where car_id=@car_id";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        dao.executeModify();
    }

    /// <summary>
    /// 刪除車輛異動記錄
    /// </summary>
    /// <param name="car_id"></param>
    public void deleteCarChange(String car_id)
    {
        String sql = "delete c_chg_mst where car_id=@car_id";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        dao.executeModify();
    }


    /// <summary>
    /// 加油資料管理依車號取出加油卡資料
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public DataSet selectCarDatabyCarNo(Form form)
    {
        String sql = "select a.car_id, dep_no, car_no, fuel_name, fuel_std, status_name, type_name, org_name, card_no, keep_start, keep_end, " +
            "keep_org, car_type, b.status as car_status, fuel_type, fuel_std from v_car a " +
            "left join c_car_sts b on a.car_id=b.car_id and convert(varchar(10), b.exec_start, 111)<=convert(varchar(10), GETDATE(), 111) " +
            "and (exec_end is null or convert(varchar(10), b.exec_end, 111)>=convert(varchar(10), GETDATE(), 111)) " +
            "where a.car_no = @car_no ";

        //if (!form.getValue("user_read").Equals("ALL"))
        //{
        sql += " and a.keep_org = @user_org";
        dao.setParam("@user_org", form.getValue("user_org"));
        //}

        dao.CommandSQL = sql;
        dao.setParam("@car_no", form.getValue("car_no"));


        return dao.searchForDS();
    }


    /// <summary>
    /// 依車號取得車輛ID(匯入中油資料時使用)
    /// </summary>
    /// <param name="car_no"></param>
    /// <returns></returns>
    public String getCarIdbyCarNo(String car_no)
    {
        String sql = "select car_id  from c_car_mst where car_no = @car_no";
        String car_id = string.Empty;

        dao.CommandSQL = sql;
        dao.setParam("@car_no", car_no);
        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            car_id = dr["car_id"].ToString();
        }

        return car_id;
    }


    /// <summary>
    /// 產生車輛的下拉式選單資料來源
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList selectCarId(Form form)
    {
        String sql = "select DISTINCT car_id as PVALUE, car_no as PTEXT from v_car " +
            "where keep_org= @keep_org";

        sql += " order by car_no";

        dao.CommandSQL = sql;
        dao.setParam("@keep_org", form.getValue("keep_org"));

        return dao.search();
    }


    public ArrayList selectCRSCarId(Form form)
    {
        String sql = "select  car_id as PVALUE, car_no as PTEXT from v_crs_car " +
            "where keep_org= @keep_org and status = 'O'";

        sql += " order by car_no";

        dao.CommandSQL = sql;
        dao.setParam("@keep_org", form.getValue("keep_org"));

        return dao.search();
    }


    /// <summary>
    /// 檢核車牌號碼是否已存在
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public Boolean IsCarNoExist(Form form)
    {
        Boolean flag = false;
        String sql = "select car_id from c_car_mst where car_no=@car_no";

        if (form.getValue("action") == "Update")
        {
            sql += " and car_id <> @car_id ";
            dao.setParam("@car_id", form.getValue("car_id"));
        }
        dao.CommandSQL = sql;
        dao.setParam("@car_no", form.getValue("car_no"));
        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count > 0)
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
    public Boolean IsCarIdExistWorkData(String car_id)
    {
        Boolean flag = false;
        String sql = "select work_id from c_work_mst where car_id=@car_id ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
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
    public Boolean IsCarIdExistFuelData(String car_id)
    {
        Boolean flag = false;
        String sql = "select * from v_fuel where report_sts='Y' and car_id=@car_id ";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
        }
        return flag;
    }


    /// <summary>
    /// 檢核car_id是否有移撥的車輛異動記錄
    /// </summary>
    /// <param name="car_id"></param>
    /// <returns></returns>
    public Boolean IsCarChanged(String car_id, String chg_rsn)
    {
        Boolean flag = false;
        String sql = "select * from c_chg_mst where car_id=@car_id and [status]='O' ";

        if (chg_rsn != string.Empty)
        {
            sql += " and chg_rsn=@chg_rsn  ";
            dao.setParam("@chg_rsn", chg_rsn);
        }

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);

        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = true;
        }
        return flag;
    }


    /// <summary>
    /// 車輛購置日期修改時異動車輛狀態起始日
    /// </summary>
    /// <param name="car_id"></param>
    /// <param name="buy_date"></param>
    public void updateFirstStatusStart(String car_id, String buy_date)
    {
        String sql = "update c_car_sts set exec_start=@buy_date where exec_id =(select MIN(exec_id) from c_car_sts where car_id=@car_id)";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        dao.setParam("@buy_date", buy_date);
        dao.executeModify();
    }


    /// <summary>
    /// 車輛購置日期修改時異動車隊卡持有起始日
    /// </summary>
    /// <param name="car_id"></param>
    /// <param name="buy_date"></param>
    public void updateFirstCardStart(String car_id, String buy_date)
    {
        String sql = "update c_car_card set possess_start=@buy_date where possess_id =(select MIN(possess_id) from c_car_card where car_id=@car_id)";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        dao.setParam("@buy_date", buy_date);
        dao.executeModify();
    }

    /// <summary>
    /// 車輛購置日期修改時異動車輛保管起始日
    /// </summary>
    /// <param name="car_id"></param>
    /// <param name="buy_date"></param>
    public void updateFirstKeepStart(String car_id, String buy_date)
    {
        String sql = "update c_keep_mst set keep_start=@buy_date where keep_id =(select MIN(keep_id) from c_keep_mst where car_id=@car_id)";

        dao.CommandSQL = sql;
        dao.setParam("@car_id", car_id);
        dao.setParam("@buy_date", buy_date);
        dao.executeModify();
    }

    /// <summary>
    /// 匯出EXCEL_wenny1061128
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public ArrayList export(Form form)
    {
        String sql = "select * from v_car ";

        String where = "where 1=1";

        if (!form.getValue("car_no").Equals(""))
        {
            where += " and car_no like @car_no";
            dao.setParam("@car_no", "%" + form.getValue("car_no") + "%");
        }

        if (!form.getValue("dep_no").Equals(""))
        {
            where += " and dep_no like @dep_no";
            dao.setParam("@dep_no", "%" + form.getValue("dep_no") + "%");
        }
        if (!form.getValue("car_type").Equals(""))
        {
            where += " and car_type in (" + handleMultiData("car_type", form.getValue("car_type")) + ")";
        }

        if (!form.getValue("keep_org").Equals(""))
        {
            where += " and car_id in(select car_id from c_keep_mst where " +
                "convert(varchar(10), keep_start, 111) <= getdate() and " +
                "keep_org in(" + handleMultiData("keep_org", form.getValue("keep_org")) + "))";
        }

        if (!form.getValue("fuel_type").Equals(""))
        {
            where += " and fuel_type in (" + handleMultiData("fuel_type", form.getValue("fuel_type")) + ")";
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status")) + ")";
        }

        if (!form.getValue("chg_rsn").Equals(""))
        {

            where += " and car_id in (SELECT t.car_id FROM (SELECT car_id, MAX(chg_date) as chg_date FROM c_chg_mst GROUP BY car_id ) r " +
                "INNER JOIN c_chg_mst t ON t.car_id = r.car_id AND t.chg_date = r.chg_date and t.chg_rsn in(" +
                handleMultiData("chg_rsn", form.getValue("chg_rsn")) + "))";
        }

        sql = sql + where + " order by car_no ";
        dao.CommandSQL = sql;

        return dao.search();
    }
}