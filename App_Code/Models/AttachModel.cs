using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// AttachModel 的摘要描述
/// </summary>
public class AttachModel:Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
    }

    /// <summary>
    /// 系統參數瀏覽查詢
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
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

    public DataSet selectAttach(String attach_type, String main_id)
    {
        String sql = "select row_number() over (order by attach_id) as row_num, attach_id, task_id, main_id, " + 
            "attach_type, attach_name, attach_desc, file_name, " +
            "'../Attach_File/" + attach_type + "/'+ ISNULL(create_user,'') + '/' as attach_dir, " + 
            "dbo.chineseDateTime(create_date) as create_date, " +
            "create_user from a_attach_mst where attach_type = @attach_type and " +
            "main_id = @main_id";

        dao.CommandSQL = sql;
        dao.setParam("@attach_type", attach_type);
        dao.setParam("@main_id", main_id);
        return dao.searchForDS();
    }


    public void deleteAttach(String attach_id)
    {
        String sql = "delete a_attach_mst where attach_id=@attach_id ";

        dao.CommandSQL = sql;
        dao.setParam("@attach_id", attach_id);        
        dao.executeModify();
    }

    public void insertAttach(Form form)
    {
        String sql = "insert into a_attach_mst (task_id, main_id, attach_type, attach_name, attach_desc, " +
            "file_name, create_date, create_user) " +
            "values (@task_id, @main_id, @attach_type, @attach_name, @attach_desc, @file_name, GETDATE(), " + 
            "@create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@task_id", form.getValue("task_id"));
        dao.setParam("@main_id", form.getValue("main_id"));
        dao.setParam("@attach_type", form.getValue("attach_type"));
        dao.setParam("@attach_name", form.getValue("attach_name"));
        dao.setParam("@attach_desc", form.getValue("attach_desc"));
        dao.setParam("@file_name", form.getValue("file_name"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }


    public void updateAttach(Form form)
    {
        String sql = "update a_attach_mst set attach_name =@attach_name, attach_desc=@attach_desc, " +
            "file_name =@file_name, update_date, update_user = @update_user where attach_id = @attach_id ";

        dao.CommandSQL = sql;
        dao.setParam("@attach_id", form.getValue("attach_id"));
        dao.setParam("@attach_name", form.getValue("attach_name"));
        dao.setParam("@attach_desc", form.getValue("attach_desc"));
        dao.setParam("@file_name", form.getValue("file_name"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }
}