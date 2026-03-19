using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// SysModel 的摘要描述
/// </summary>
public class SysModel:Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
    }

   
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select param_type, param_name, status, memo, create_date " +
            " from a_sysparam_type ";

        String where = "where param_attr = 'U' ";

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

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = " create_date ";
    }
    

    /// <summary>
    /// 新增系統事件
    /// </summary>
    /// <param name="form"></param>
    public void insertSysLog(Form form, String log)
    {
        String sql = "insert into a_syslog_mst (task_id, page_id, exec_action, sql_desc, exec_user, exec_date)" +
            "values (@task_id, @page_id, @exec_action, @sql_desc , @exec_user, GETDATE())";

        dao.CommandSQL = sql;
        dao.setParam("@task_id", form.getValue("task_id"));
        dao.setParam("@page_id", form.getValue("page_id"));
        dao.setParam("@exec_action", form.getValue("exec_action"));
        dao.setParam("@sql_desc", log);
        dao.setParam("@exec_user", form.getValue("exec_user"));  

        dao.executeModify();
    }
    
}