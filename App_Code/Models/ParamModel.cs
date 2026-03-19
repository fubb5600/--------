using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// ParamModel 的摘要描述
/// </summary>
public class ParamModel : Model
{
    public static String[] specParamTYPE = { "CAR_WITEM_L1", "MCHN_WITEM_L1" };
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse1_param_type"))
        {
            browse1_param_type(pb, form);
        }
        else if (pbKey.Equals("browse1_param_name"))
        {
            browse1_param_name(pb, form);
        }
        else if (pbKey.Equals("browse1_status"))
        {
            browse1_status(pb, form);
        }
        else if (pbKey.Equals("browse1_memo"))
        {
            browse1_memo(pb, form);
        }
        //反排
        if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);
        }
        else if (pbKey.Equals("browse1_param_typed"))
        {
            browse1_param_typed(pb, form);
        }
        else if (pbKey.Equals("browse1_param_named"))
        {
            browse1_param_named(pb, form);
        }
        else if (pbKey.Equals("browse1_statusd"))
        {
            browse1_statusd(pb, form);
        }
        else if (pbKey.Equals("browse1_memod"))
        {
            browse1_memod(pb, form);
        }
        //wenny_test_排序

        else if (pbKey.Equals("browse2"))
        {
            browse2(pb, form);
        }

        else if (pbKey.Equals("browse3"))
        {
            browse3(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse3d"))
        {
            browse3d(pb, form);
        }
        else if (pbKey.Equals("browse3_param_typed"))
        {
            browse3_param_typed(pb, form);
        }
        else if (pbKey.Equals("browse3_param_named"))
        {
            browse3_param_named(pb, form);
        }
        else if (pbKey.Equals("browse3_statusd"))
        {
            browse3_statusd(pb, form);
        }
        else if (pbKey.Equals("browse3_memod"))
        {
            browse3_memod(pb, form);
        }
        //反排
        //wenny_test_排序

    }

    /// <summary>
    /// TDOS系統參數瀏覽查詢
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " create_date ";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    //wenny_test_排序
    //正排
    private void browse1_param_type(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " param_type ";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    private void browse1_param_name(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " param_name ";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    private void browse1_status(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " status ";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    private void browse1_memo(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " memo ";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    //反排
    private void browse1d(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " create_date desc ";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    private void browse1_param_typed(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " param_type desc";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    private void browse1_param_named(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " param_name desc";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    private void browse1_statusd(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " status desc";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    private void browse1_memod(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type not in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        if (!form.getValue("param_attr").Equals(""))
        {
            if (form.getValue("param_attr").Equals("1"))
            {
                where += " and substring(param_type, 1, 5) <> 'CITEM' and substring(param_type, 1, 5) <> 'MITEM'";
            }
            else if (form.getValue("param_attr").Equals("2"))
            {
                where += " and substring(param_type, 1, 5) = 'CITEM'";
            }
            else if (form.getValue("param_attr").Equals("3"))
            {
                where += " and substring(param_type, 1, 5) = 'MITEM'";
            }
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        //原程式碼
        pb.OrderSQL = " memo desc";
        //原程式碼
        //wenny_test_排序
        //pb.OrderSQL = " create_date ";
        //wenny_test_排序
    }
    //wenny_test_排序
    /// <summary>
    /// 基本參數解除鎖定資料 
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse2(PageBreak pb, Form form)
    {
        String sql = "select a.unlock_id, b.id_name as unlock_type, a.user_id + '(' + c.username + ')' as unlock_user, " +
            "dbo.chineseDate(data_start) as data_start, dbo.chineseDate(data_end) as data_end, " +
            "dbo.chineseDate(key_start) as key_start, dbo.chineseDate(key_end) as key_end, " +
            " a.create_user + '(' + d.username + ')' as create_user, dbo.chineseDateTime(a.create_date) as create_date " +
            "from a_unlock_mst a " +
            "left join a_sysparam_data b on a.unlock_type = b.param_id and b.param_type ='UNLOCK_TYPE' " +
            "left join " + dao.DepDB() + "..Users c on a.user_id = c.userid " +
            "left join " + dao.DepDB() + "..Users d on a.create_user = d.userid " +
            "where " +
            "convert(varchar(10), key_start, 111) <= convert(varchar(10), GETDATE(), 111) and " +
            "convert(varchar(10), key_end, 111) >= convert(varchar(10), GETDATE(), 111) ";


        pb.CommandSQL = sql;
        pb.OrderSQL = " unlock_id ";
    }


    /// <summary>
    /// CRS系統參數瀏覽查詢
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse3(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " create_date ";
    }
    //wenny_test_排序
    //正排
    private void browse3_param_type(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " param_type ";
    }
    private void browse3_param_name(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " param_name ";
    }
    private void browse3_status(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " status ";
    }
    private void browse3_memo(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " memo ";
    }
    //反排
    private void browse3d(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " create_date desc ";
    }
    private void browse3_param_typed(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " param_type desc";
    }
    private void browse3_param_named(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " param_name desc ";
    }
    private void browse3_statusd(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " status desc";
    }
    private void browse3_memod(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' and param_type in('REPAIR_VENDER')";

        if (!form.getValue("param_type").Equals(""))
        {
            where += " and param_type like @param_type ";
            pb.setParam("@param_type", "%" + form.getValue("param_type") + "%");
        }

        if (!form.getValue("param_name").Equals(""))
        {
            where += " and param_name like @param_name ";
            pb.setParam("@param_name", "%" + form.getValue("param_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        //if (!form.getValue("param_attr").Equals(""))
        //{
        //    if (form.getValue("param_attr").Equals("1"))
        //    {
        //        where += " and substring(param_type, 1, 4) <> 'TYPE' and substring(param_type, 1, 5) <> 'CLASS'";
        //    }
        //    else if (form.getValue("param_attr").Equals("2"))
        //    {
        //        where += " and substring(param_type, 1, 4) = 'TYPE'";
        //    }
        //    else if (form.getValue("param_attr").Equals("3"))
        //    {
        //        where += " and substring(param_type, 1, 5) = 'CLASS'";
        //    }
        //}

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " memo desc ";
    }
    //wenny_test_排序
    /// <summary>
    /// 鄉鎮的下拉
    /// </summary>
    /// <returns></returns>
    public ArrayList selectCntyOptionbyCity(String City)
    {
        String sql = "select cnty as PVALUE, cnty_name as PTEXT, city from a_cnty_mst where city = @city order by city, cnty";

        dao.CommandSQL = sql;
        dao.setParam("@city", City);
        return dao.search();
    }

    /// <summary>
    /// 單位的下拉(年月週天)
    /// 顯示帶入參數以上的值，例：帶入月，則回傳年月。
    /// </summary>
    /// <returns></returns>
    public ArrayList selectUnitOptionbyParm(String Parm)
    {
        int num = 10;
        if (Parm.Equals("Y"))
        {
            num = 1;
        }
        else if (Parm.Equals("M"))
        {
            num = 2;
        }
        else if (Parm.Equals("W"))
        {
            num = 3;
        }
        else if (Parm.Equals("D"))
        {
            num = 4;
        }

        String sql = "select param_id as PVALUE, id_name as PTEXT from a_sysparam_data where param_type = 'PER_UNT' and id_order_by <=@num order by id_order_by";

        dao.CommandSQL = sql;
        dao.setParam("@num", num);
        return dao.search();
    }

    /// <summary>
    /// 查詢參數主檔
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns></returns>
    public DataSet selectParam(String param_type)
    {
        String sql = "select a.param_type, a.param_name ,a.memo, a.status " +
            "from a_sysparam_type a " +
            "where a.param_type = @param_type ";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", param_type);
        return dao.searchForDS();
    }

    /// <summary>
    /// 查詢參數明細
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns></returns>
    public DataSet selectParamData(String param_type)
    {
        String sql = "select b.param_type, b.param_id, b.id_name, b.status, b.memo, b.id_order_by " +
            "from a_sysparam_data b  " +
            "where b.param_type = @param_type " +
            "order by b.id_order_by ";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", param_type);
        return dao.searchForDS();
    }


    /// <summary>
    /// 查詢參數屬性明細
    /// </summary>
    /// <param name="param_type"></param>
    /// <param name="param_id"></param>
    /// <returns></returns>
    public DataSet selectParamId(String param_type, String param_id)
    {
        String sql = "select b.param_type, b.param_id, b.id_name, b.status, b.memo, b.id_order_by " +
            "from a_sysparam_data b  " +
            "where b.param_type = @param_type and b.param_id = @param_id " +
            "order by b.id_order_by ";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", param_type);
        dao.setParam("@param_id", param_id);
        return dao.searchForDS();
    }

    /// <summary>
    /// 修改參數主檔
    /// </summary>
    /// <param name="form"></param>
    public void updateParam(Form form)
    {
        String sql = "update a_sysparam_type set param_name=@param_name, status=@status, " +
            "memo=@memo, update_date=GETDATE(), update_user=@update_user " +
            "where param_type = @param_type ";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", form.getValue("param_type"));
        dao.setParam("@param_name", form.getValue("param_name"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));


        dao.executeModify();
    }

    /// <summary>
    /// 修改參數明細
    /// </summary>
    /// <param name="form"></param>
    public void updateSYSParam(Form form)
    {
        String sql = "update a_sysparam_data set param_id=@param_id, id_name=@id_name, " +
            "id_order_by=@id_order_by, status=@status, memo=@memo, update_date=GETDATE(), " +
            "update_user=@update_user " +
            "where param_type = @param_type and param_id=@original_id ";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", form.getValue("param_type"));
        dao.setParam("@original_id", form.getValue("original_id"));
        dao.setParam("@param_id", form.getValue("param_id"));
        dao.setParam("@id_name", form.getValue("id_name"));
        dao.setParam("@id_order_by", form.getValue("id_order_by"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.executeModify();
    }


    /// <summary>
    /// 刪除參數主檔
    /// </summary>
    /// <param name="user_id"></param>
    public void deleteParamType(Form form)
    {
        String sql = "delete a_sysparam_type where param_type=@param_type";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", form.getValue("param_id"));
        dao.executeModify();
    }


    /// <summary>
    /// 刪除參數明細
    /// </summary>
    /// <param name="user_id"></param>
    public void deleteSYSParam(Form form)
    {
        String sql = "delete a_sysparam_data where param_type=@param_type and param_id=@param_id ";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", form.getValue("param_type"));
        dao.setParam("@param_id", form.getValue("param_id"));
        dao.executeModify();
    }


    /// <summary>
    /// 刪除資料鎖定
    /// </summary>
    /// <param name="unlock_id"></param>
    public void deleteLockMst(String unlock_id)
    {
        String sql = "delete a_unlock_mst where unlock_id=@unlock_id ";

        dao.CommandSQL = sql;
        dao.setParam("@unlock_id", unlock_id);

        dao.executeModify();
    }


    /// <summary>
    /// 新增參數主檔
    /// </summary>
    /// <param name="form"></param>
    public void insertParamType(Form form)
    {
        String sql = "insert into a_sysparam_type (param_type, param_name, param_attr, status ,memo, " +
            "create_date ,update_date ,update_user ,create_user) " +
            "values (@param_type, @param_name, @param_attr, @status, @memo, GETDATE(), GETDATE(), " +
            "@create_user,  @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", form.getValue("param_type"));
        dao.setParam("@param_name", form.getValue("param_name"));
        dao.setParam("@param_attr", form.getValue("param_attr"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 新增參數明細
    /// </summary>
    /// <param name="form"></param>
    public void insertSYSParam(Form form)
    {
        String sql = "insert into a_sysparam_data (param_type ,param_id ,id_name ,id_order_by ,status ,memo ,create_date ,update_date ,update_user ,create_user) " +
            "values (@param_type, @param_id, @id_name, @id_order_by, @status, @memo, GETDATE(), GETDATE(), @create_user,  @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", form.getValue("param_type"));
        dao.setParam("@param_id", form.getValue("param_id"));
        dao.setParam("@id_name", form.getValue("id_name"));
        dao.setParam("@id_order_by", form.getValue("id_order_by"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 查詢基本參數
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns></returns>
    public DataSet selectBasicParam()
    {
        String sql = "select * from a_param_basic where status = 'O' ";

        dao.CommandSQL = sql;

        return dao.searchForDS();
    }

    /// <summary>
    /// 修改原基本參數狀態(C)
    /// </summary>
    /// <param name="form"></param>
    public void updateBasicParam(Form form)
    {
        String sql = "update a_param_basic set status='C' ,update_user=@update_user ,update_date=GETDATE() " +
            "where basic_id= @basic_id";

        dao.CommandSQL = sql;
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.setParam("@basic_id", form.getValue("basic_id"));
        dao.executeModify();
    }


    /// <summary>
    /// 新增基本參數
    /// </summary>
    /// <param name="form"></param>
    public void insertBasicParam(Form form)
    {
        String sql = "insert into a_param_basic (key_date, send_date, work_date, status, create_user, create_date) " +
            "values (@key_date, @send_date, @work_date,  'O', @create_user , GETDATE())";

        dao.CommandSQL = sql;
        dao.setParam("@key_date", form.getValue("key_date"));
        dao.setParam("@send_date", form.getValue("send_date"));
        dao.setParam("@work_date", form.getValue("work_date"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 新增解除鎖定資料檔
    /// </summary>
    /// <param name="form"></param>
    public void insertUnlockMst(Form form)
    {
        String sql = "insert into a_unlock_mst (user_id, unlock_type, data_start, data_end, key_start, key_end, " +
            "create_user, create_date, update_user, update_date) " +
            "values (@user_id, @unlock_type, @data_start,  @data_end, @key_start, @key_end, @create_user , " +
            "GETDATE(),  @create_user, GETDATE())";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", form.getValue("user_id"));
        dao.setParam("@unlock_type", form.getValue("unlock_type"));
        dao.setParam("@data_start", form.getValue("data_start"));
        dao.setParam("@data_end", form.getValue("data_end"));
        dao.setParam("@key_start", form.getValue("key_start"));
        dao.setParam("@key_end", form.getValue("key_end"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 取得維修項目
    /// </summary>
    /// <param name="param_type"></param>
    /// <returns></returns>
    public ArrayList getRepItemData(String rep_item)
    {
        String sql = "select param_id, id_name from a_sysparam_data where status = 'O' and param_type = 'REP_ITEM'";

        if (rep_item.Length > 0)
        {
            sql += " and param_id in (" + handleMultiData("param_id", rep_item) + ")";
        }

        sql += " order by id_order_by";

        dao.CommandSQL = sql;
        return dao.search();
    }

    public ArrayList selectPARMList(String param_type)
    {
        String sql = "select param_id as PVALUE , id_name as PTEXT " +
            "from a_sysparam_data " +
            "where status = 'O' and  param_type = @param_type " +
            "order by id_order_by ";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", param_type);
        return dao.search();
    }

    public Int32 getDefaultIdorder(String param_type)
    {
        Int32 order = 1;
        String sql = "select top(1) id_order_by from a_sysparam_data " +
            "where param_type=@param_type order by id_order_by desc";

        dao.CommandSQL = sql;
        dao.setParam("@param_type", param_type);
        DataSet ds = dao.searchForDS();
        if (ds.Tables[0].Rows.Count == 1)
        {
            order = Convert.ToInt32(ds.Tables[0].Rows[0]["id_order_by"].ToString()) + 1;
        }
        return order;
    }


    /// <summary>
    /// 檢核屬性代碼是否唯一
    /// </summary>
    /// <param name="param_id"></param>
    /// <returns></returns>
    public Boolean IsUnique(String param_type, String param_id)
    {
        Boolean flag = true;
        String sql = "select param_id from a_sysparam_data where param_id=@param_id " +
            "and param_type = @param_type";

        dao.CommandSQL = sql;
        dao.setParam("@param_id", param_id);
        dao.setParam("@param_type", param_type);
        ArrayList al = dao.search();

        if (al.Count == 1)
        {
            flag = false;
        }

        return flag;
    }
    #region 修正維修廠商沒有資料_wenny1061218_
    /// <summary>
    /// 檢核屬性代碼或名稱是否唯一
    /// </summary>
    /// <param name="param_type"></param>
    /// <param name="param_id"></param>
    /// <param name="id_name"></param>
    /// <returns></returns>
    public Boolean IsUnique(String param_type, String param_id,String id_name)
    {
        Boolean flag = false;
        String sql = "select param_id from a_sysparam_data where param_type = @param_type " +
        "and (param_id=@param_id  or id_name=@id_name)";
        dao.setParam("@param_id", param_id);
        dao.setParam("@param_type", param_type);
        dao.setParam("@id_name", id_name);
        dao.CommandSQL = sql;
        ArrayList al = dao.search();

        if (al.Count ==0)
        {
            flag = true;
        }

        return flag;
    }
    /// <summary>
    /// 檢核屬性名稱是否唯一
    /// </summary>
    /// <param name="param_type"></param>
    /// <param name="param_id"></param>
    /// <param name="id_name"></param>
    /// <returns></returns>
    public Boolean IsUniqueName(String param_type,String id_name)
    {
        Boolean flag = false;
        String sql = "select param_id from a_sysparam_data where param_type = @param_type " +
        "and  id_name=@id_name";
   
        dao.setParam("@param_type", param_type);
        dao.setParam("@id_name", id_name);
        dao.CommandSQL = sql;
        ArrayList al = dao.search();

        if (al.Count == 0)
        {
            flag = true;
        }

        return flag;
    }
    #endregion

    /// <summary>
    /// 是否有授權登打已鎖定資料
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public Boolean IsUnlock(Form form)
    {
        Boolean flag = false;
        String sql = "select * from a_unlock_mst where user_id = @user_id and unlock_type= @unlock_type " +
            "and convert(varchar(10), data_start, 111) <=  convert(varchar(10), @target_date, 111) " +
            "and convert(varchar(10), data_end, 111) >=  convert(varchar(10), @target_date, 111) " +
            "and convert(varchar(10), key_start, 111) <= convert(varchar(10), GETDATE(), 111) " +
            "and convert(varchar(10), key_end, 111) >= convert(varchar(10), GETDATE(), 111)";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", form.getValue("user_id"));
        dao.setParam("@unlock_type", form.getValue("unlock_type"));
        dao.setParam("@target_date", form.getValue("target_date"));
        ArrayList al = dao.search();

        if (al.Count > 0)
        {
            flag = true;
        }

        return flag;
    }


    /// <summary>
    /// 查詢報廢或報停車輛過濾條件
    /// </summary>
    /// <param name="Parm"></param>
    /// <returns></returns>
    public ArrayList selectCarStatusChgRsn()
    {
        String sql = @"select param_id as PVALUE, id_name as PTEXT from a_sysparam_data 
            where param_type = 'CHG_RSN' and param_id in('R2', 'R4') order by id_order_by";

        dao.CommandSQL = sql;

        return dao.search();
    }


    /// <summary>
    /// 檢核作業項目是否唯一
    /// </summary>
    /// <param name="param_type"></param>
    /// <param name="param_id"></param>
    /// <returns></returns>
    public Boolean IsUniqueOfWorkItem(String param_type, String param_id)
    {
        Boolean flag = true;
        String sql = "select param_id from a_sysparam_data where substring(param_type, 1, 5) = @param_type and param_id = @param_id";

        dao.CommandSQL = sql;
        dao.setParam("@param_id", param_id);
        dao.setParam("@param_type", param_type);
        ArrayList al = dao.search();

        if (al.Count == 1)
        {
            flag = false;
        }

        return flag;
    }

}