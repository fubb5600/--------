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
public class Mediator
{
    protected static Mediator ourInstance = null;
    protected Hashtable id2name = new Hashtable();
    protected Hashtable type2id = new Hashtable();
    protected Hashtable name2id = new Hashtable();
    public static String splitTag = ",";
    public static String rnTag = "___";
    public static ArrayList alDepSelf;

    public Mediator()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
        initializeParamMap();
    }

    public static Mediator getInstance(Boolean flag)
    {
        if (flag || ourInstance == null)
        {
            ourInstance = new Mediator();
            alDepSelf = selectPARAMDepOrgSelfList();
        }

        return ourInstance;
    }

    private void initializeParamMap()
    {
        id2name.Clear();
        type2id.Clear();
        name2id.Clear();

        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            ArrayList al = new ArrayList();
            String sql = "select param_type from a_sysparam_type where status = 'O'";
            dao.CommandSQL = sql;
            ArrayList al2 = dao.search();
            for (int i = 0; i < al2.Count; i++)
            {
                Hashtable ht = (Hashtable)al2[i];
                String param = ht["PARAM_TYPE"].ToString();
                al.Add(param);
            }

            for (int i = 0; i < al.Count; i++)
            {
                String param = al[i].ToString();
                String sql2 = "select param_type, param_id, id_name, status from a_sysparam_data where param_type = '" + param + "' order by id_order_by";

                try
                {
                    ArrayList idc = new ArrayList();
                    sql = "select param_type, param_id, id_name,status from a_sysparam_data where param_type = @param_type order by id_order_by";
                    dao.CommandSQL = sql;
                    dao.setParam("@param_type", param);
                    al2 = dao.search();
                    for (int j = 0; j < al2.Count; j++)
                    {
                        Hashtable ht = (Hashtable)al2[j];
                        String param_type = ht["PARAM_TYPE"].ToString().Trim();
                        String param_id = ht["PARAM_ID"].ToString();
                        String id_name = ht["ID_NAME"].ToString();
                        if (ht["STATUS"].ToString() == "C")
                        {
                            id_name += "(已停用)";
                        }

                        String paramKey = param_type + "+" + param_id;

                        if (!id2name.ContainsKey(paramKey))
                        {
                            id2name.Add(paramKey, id_name);
                            name2id.Add(param_type + "+" + id_name, param_id);
                            idc.Add(param_id);
                        }
                    }

                    type2id.Add(param.Trim(), idc);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    //ourInstance = null;
                }
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

    public String lookupParamName(String param_type, String param_id, int type)
    {
        if (param_id.Equals(""))
            return "";

        String paramName;


        if (param_type.Equals("CRS_ORG"))
        {
            for (int i = 0; i < alDepSelf.Count; i++)
            {
                Hashtable ht = (Hashtable)alDepSelf[i];
                if (ht["PVALUE"].ToString().Equals(param_id))
                {
                    paramName = "局本部";

                    if (type == 1)
                        paramName = param_id + "(局本部)";

                    return paramName;
                }
            }
        }


        if (type == 1)
        {
            paramName = (String)id2name[param_type + "+" + param_id];
            if (paramName == null)
                return "ERR(" + param_id + ")";

            paramName = param_id + "(" + paramName + ")";
        }
        else
        {
            paramName = (String)id2name[param_type + "+" + param_id];
            if (paramName == null)
                return "" + param_id + "";
        }
        return paramName;
    }

    public String lookupParamId(String param_type, String param_name)
    {
        if (param_name.Equals(""))
            return "";

        String paramID;

        paramID = (String)name2id[param_type + "+" + param_name];
        if (paramID == null)
            return "FALSE";

        return paramID;
    }

    public String lookupParamNameMulti(String param_type, String param_id, int type)
    {
        if (param_id.Equals(""))
            return "";

        String paramName = "";
        String[] arr = param_id.Split(splitTag.ToCharArray());
        for (int i = 0; i < arr.Length; i++)
        {
            String temp = arr[i];
            temp = lookupParamName(param_type, temp, type);

            if (paramName.Equals(""))
            {
                paramName = temp;
            }
            else
            {
                paramName = paramName + "、" + temp;
            }
        }

        return paramName;
    }


    public void updateData()
    {
        initializeParamMap();
    }

    public int getParamTypeCount(String paramType)
    {
        ArrayList a = (ArrayList)type2id[paramType];
        return a.Count;
    }

    public String getParamTypeID(String paramType, int index)
    {
        ArrayList a = (ArrayList)type2id[paramType];
        String param_id = (String)a[index];

        if (param_id == null)
            return null;
        else
            return param_id;
    }


    /// <summary>
    /// 取得局本部的單位(沒有在CRS_ORG的DEP_ORG單位)
    /// </summary>
    /// <returns></returns>
    public static ArrayList selectPARAMDepOrgSelfList()
    {
        ArrayList al = new ArrayList();
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            String sql = "select param_id as PVALUE , id_name as PTEXT " +
            "from a_sysparam_data where param_type = 'DEP_ORG' and status = 'O' " +
            "and param_id not in(select param_id from a_sysparam_data where param_type = 'CRS_ORG')" +
            "order by id_order_by ";

            dao.CommandSQL = sql;

            al = dao.search();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            dao.close();
        }
        return al;
    }
}
