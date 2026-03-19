using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// FaqModel 的摘要描述
/// </summary>
public class FaqModel:Model
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
    /// 新增常見問題
    /// </summary>
    /// <param name="form"></param>
    public void insertFAQ(Form form, String log)
    {
        String sql = "insert into a_faq_mst(question, answer, create_user, create_date)" +
            "values (@question, @answer, @create_user, GETDATE())";

        dao.CommandSQL = sql;
        dao.setParam("@question", form.getValue("question"));
        dao.setParam("@answer", form.getValue("answer"));       
        dao.setParam("@create_user", form.getValue("create_user"));  

        dao.executeModify();
    }


    /// <summary>
    /// 取得常見問題
    /// </summary>
    /// <param name="faq_type"></param>
    /// <returns></returns>
    public DataSet getFAQ(String faq_type)
    {
        String sql = "select  question, answer, dbo.chineseDate(update_date) as update_date from a_faq_mst";

        if (faq_type != string.Empty)
        {
            sql += " where faq_type=@faq_type";
            dao.setParam("@faq_type",faq_type); 
        }
        dao.CommandSQL = sql;             

        return dao.searchForDS();
    }
}