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
/// Form 的摘要描述
/// </summary>
public class Form
{
    private Hashtable ht = new Hashtable();

	public Form()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    /// <summary>
    /// 設定值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void setValue(String key, String value)
    {
        if (value == null)
        {
            value = "";
        }

        if (ht.ContainsKey(key.ToUpper()))
        {
            ht[key.ToUpper()] = HandleParam.replaceChars(value);
        }
        else
        {
            ht.Add(key.ToUpper(), HandleParam.replaceChars(value));
        }
    }

    /// <summary>
    /// 取得值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public String getValue(String key)
    {
        String value = (String)ht[key.ToUpper()];

        if (value == null) return "";

        return value;
    }

    /// <summary>
    /// 將whereParam轉為form資料
    /// </summary>
    /// <param name="page"></param>
    /// <param name="userID"></param>
    /// <param name="sessionID"></param>
    public void setWhereParam(Page page, UserID userID, String sessionID)
    {
        TextBox wp = (TextBox)page.Master.FindControl("whereParam" + sessionID);
        String whereParam = AES.Decrypt(userID.getUserID(), wp.Text);
        setWhereParam(whereParam);
    }

    /// <summary>
    /// 將whereParam轉為form資料
    /// </summary>
    /// <param name="whereParam"></param>
    public void setWhereParam(String whereParam)
    {
        if (!whereParam.Equals("") && !whereParam.Equals("1=1"))
        {
            String[] arr = whereParam.Split(';');
            for (int i = 0; i < arr.Length; i++)
            {
                String[] temp = arr[i].Split('=');

                if (temp.Length != 2)
                {
                    ht.Add(temp[0], "");
                }
                else
                {
                    ht.Add(temp[0], temp[1]);
                }
            }
        }
    }

    /// <summary>
    /// 將form資料轉為whereParam字串
    /// </summary>
    /// <returns></returns>
    public String getWhereParam()
    {
        String param = "";
        foreach (string key in ht.Keys)
        {
            if (param.Equals(""))
            {
                param = key + "=" + ht[key];
            }
            else
            {
                param = param + ";" + key + "=" + ht[key];
            }
        }

        if (param.Equals(""))
        {
            //當分頁不須任何條件時，不能回傳空值，否則將無法分頁(whereParam = "" 視同無查詢過)
            param = "1=1";
        }

        return param;
    }
}
