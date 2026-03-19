using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Mediator 的摘要描述


/// </summary>
public class TaskMediator
{
    protected static TaskMediator ourInstance = null;
    protected Hashtable id2name = new Hashtable(); 
    public static String splitTag = ",";

    public TaskMediator()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        initializeParamMap();
	}
    
    public static TaskMediator getInstance() 
    {
        if (ourInstance == null)
        {
            ourInstance = new TaskMediator();
        } 

        return ourInstance;
    }

    private void initializeParamMap()
    {
        id2name.Clear();     

        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            String sql = "select task_id,task_name from a_task_mst where status = 'O'";
            dao.CommandSQL = sql;
            ArrayList al = dao.search();
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];
                id2name[ht["TASK_ID"].ToString()] = ht["TASK_NAME"].ToString();               
            }           
        }
        catch (Exception e)
        {
            //Console.Write(e.Message);
            ourInstance = null;
        }
        finally
        {
            dao.close();
        }
    }

    public String lookupTaskName(String taskID)
    {
        if (taskID.Equals(""))
            return "";

        String paramName;
        paramName = (String)id2name[taskID];

        if (paramName == null){
            return "";
        }

        return paramName;
    }

    public void updateData()
    {
        initializeParamMap();
    }
}
