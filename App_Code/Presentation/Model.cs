using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;

/// <summary>
/// Model 的摘要描述
/// </summary>
public abstract class Model
{
    private DBDAO _dao = null;

    public DBDAO dao
    {
        get{
            return _dao;
        }
        set
        {
            _dao = value;
        }
    }

    public abstract void doPageBreak(PageBreak pb, Form form, String pbKey);
    //public abstract void doPageBreak(PageBreak pb, Form form, String pbKey ,String sorted);//wenny_test_排序
    protected String handleMultiData(String key, String values, PageBreak pb)
    {
        String inStr = "";
        String[] arr = values.Split(',');

        for (int i = 0; i < arr.Length; i++)
        {
            String value = arr[i].Trim();
            String paramKey = "@" + key + "_" + i.ToString();

            if (inStr.Equals(""))
            {
                inStr = paramKey;
            }
            else
            {
                inStr = inStr + ", " + paramKey;
            }

            pb.setParam(paramKey, value);
        }

        return inStr;
    }

    protected String handleMultiData(String key, String values)
    {
        String inStr = "";
        String[] arr = values.Split(',');

        for (int i = 0; i < arr.Length; i++)
        {
            String value = arr[i].Trim();
            String paramKey = "@" + key + "_" + i.ToString();

            if (inStr.Equals(""))
            {
                inStr = paramKey;
            }
            else
            {
                inStr = inStr + ", " + paramKey;
            }

            _dao.setParam(paramKey, value);
        }

        return inStr;
    }
}
