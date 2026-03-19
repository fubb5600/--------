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

/// <summary>
/// Forward導向相關
/// </summary>
public class Forward
{
	public Forward()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    /// <summary>
    ///產生redirect的url
    /// </summary>
    /// <param name="url">基本網址</param>
    /// <param name="param_values">附加傳送資料</param>
    /// <param name="nowPage">頁面物件(為了取得MasterPage)</param>
    public static String Redirect(String url, String param_values, Page nowPage)
    {
        TextBox ot = (TextBox)nowPage.Master.FindControl("OLD_TASK");
        String strParam = "OLD_TASK=" + ot.Text;
        String newUrl = "";

        for (int i = 1; i <= IniValue.PB_COUNT; i++)
        {
            String key = "";
            if (i > 1)
            {
                key = i.ToString();
            }

            TextBox wp = (TextBox)nowPage.Master.FindControl("whereParam" + key);
            TextBox pn = (TextBox)nowPage.Master.FindControl("pageNumber" + key);

            if (!wp.Text.Equals(""))
            {
                strParam = strParam + "&whereParam" + key + "=" + HttpUtility.UrlEncode(wp.Text) + "&pageNumber" + key + "=" + pn.Text;
            }
        }

        //附加參數
        if (!param_values.Equals(""))
        {
            strParam = strParam + "&" + param_values;
        }

        //判別url是否已有參數 (主要是為了訊息頁返回)
        if (url.ToUpper().IndexOf(".ASPX?") != -1)
        {
            newUrl = url + "&" + strParam;
        }
        else
        {
            newUrl = url + "?" + strParam;
        }


        return newUrl;
    }
}

