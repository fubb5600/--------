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
using System.Data.SqlClient;


/// <summary>
/// AlertMsg 的摘要描述
/// </summary>
public class SysMsg
{
	public SysMsg()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    /// <summary>
    /// alert系統訊息
    /// </summary>
    /// <param name="page"></param>
    /// <param name="msg"></param>
    public static void showSysMsg(Page page, String msg)
    {
        if (IniValue.isAlertMsg)
        {
            msg = HandleParam.reaplce(msg);
            page.ClientScript.RegisterStartupScript(page.GetType(), "onload", "<script type='text/javascript'>showSysMsg('" + msg + "');</script>");
        }
    }

    /// <summary>
    /// 顯示訊息畫面
    /// </summary>
    /// <param name="page"></param>
    /// <param name="message"></param>
    /// <param name="errormessage"></param>
    /// <param name="ex"></param>
    /// <param name="nextPage"></param>
    /// <param name="pageParam"></param>
    public static void goResult(Page page, String message, String errormessage, Exception ex, String page_name, String page_param)
    {
        Panel TaskPanel = (Panel)page.Master.FindControl("TaskPanel");
        Panel ResultPanel = (Panel)page.Master.FindControl("ResultPanel");
        Label ResultMsg = (Label)page.Master.FindControl("ResultMsg");
        Label ResultMsgDesc = (Label)page.Master.FindControl("ResultMsgDesc");
        TextBox nextPage = (TextBox)page.Master.FindControl("nextPage");
        TextBox pageParam = (TextBox)page.Master.FindControl("pageParam");

        if (ex != null)
        {
            ResultMsg.Text = "作業失敗";

            if (ex is SqlException)
            {
                SqlException sqlEx = (SqlException)ex;
                //SQLException才有Number
                int errNum = sqlEx.Number;

                Mediator med = Mediator.getInstance(false);
                //有參數就用參數的說明
                String msgdesc = med.lookupParamName("SQL_ERR", errNum.ToString(), 0);
                if (msgdesc.Equals("") || msgdesc.StartsWith("ERR(")) //沒有列在資料庫時, 直接用Exception的描述
                {
                    msgdesc = "錯誤代碼 " + errNum + "：" + sqlEx.Message + sqlEx.StackTrace;
                }
                else
                {
                    msgdesc = "錯誤代碼 " + errNum + "：" + msgdesc + sqlEx.StackTrace;
                }

                ResultMsgDesc.Text = msgdesc;
            }
            else
            {
                ResultMsgDesc.Text = ex.Message + ex.StackTrace;
            }
        }
        else if (!errormessage.Equals(""))
        {
            ResultMsg.Text = "作業失敗";
            ResultMsgDesc.Text = errormessage;
        }
        else
        {
            ResultMsg.Text = "作業成功";
            ResultMsgDesc.Text = message;
        }

        if (page_name != null)
        {
            nextPage.Text = page_name;
        }

        if (page_param != null)
        {
            pageParam.Text = page_param;
        }

        TaskPanel.Visible = false;
        ResultPanel.Visible = true;
    }

    /// <summary>
    /// 顯示訊息畫面
    /// </summary>
    /// <param name="page"></param>
    /// <param name="message"></param>
    /// <param name="errormessage"></param>
    /// <param name="ex"></param>
    public static void goResult(Page page, String message, String errormessage, Exception ex)
    {
        goResult(page, message, errormessage, ex, "", "");
    }


    /// <summary>
    /// 提示錯誤訊息alert
    /// </summary>
    /// <param name="Message"></param>
    public static void AlertMessage(Page page, string Message)
    {
        Message = Message.Replace("'", " ");
        page.ClientScript.RegisterClientScriptBlock(page.GetType(), "Message", "alert('" + Message + "');", true);
        
    }    
}
