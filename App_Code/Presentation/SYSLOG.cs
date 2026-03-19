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
using System.Web.SessionState;
using System.Collections;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Text;
/// <summary>
/// 儲存系統記錄檔
/// </summary>
public class SYSLOG
{
	public SYSLOG()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    
    /// <summary>
    /// 儲存系統記錄檔
    /// </summary>     
    /// <param name="request">HttpRequest</param>  
    /// <param name="session">HttpSessionState</param>  
    /// <param name="action">執行動作</param>  
    /// <param name="log">log內容</param>    
    public static void setLog(HttpRequest request, HttpSessionState session, String action, String log)
    {
        DBDAO dao = new DBDAO();
        try
        {
            UserID userID = (UserID)session["UserID"];
            String path = request.CurrentExecutionFilePath;
            String[] arrPath = path.Split('/');
            String task_id = arrPath[arrPath.Length - 2];
            String page_id = arrPath[arrPath.Length - 1];
            page_id = page_id.Replace(".aspx", "");

            dao.open();
           
            SysModel model = new SysModel();
            model.dao = dao;
            Form form = new Form();
            form.setValue("task_id", task_id);
            form.setValue("page_id", page_id);
            form.setValue("exec_action", action.ToUpper());           
            form.setValue("exec_user", userID.getUserID());
            model.insertSysLog(form, log.Replace("'", "’"));             
        }
        catch (Exception)
        {
            dao.rollback();
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 系統發生exception發送給系統管理員
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="userID"></param>
    public static void sendMail(Exception ex, UserID userID, HttpRequest request)
    {
        try
        {
            string nameFrom = "油料管理系統";
            MailMessage msgMail = new MailMessage();
            msgMail.From = new MailAddress("taipei.dep@gmail.com", nameFrom);
            msgMail.To.Add("sarahyrp@gmail.com");
            //msgMail.Subject = mailSubject;
            msgMail.Subject = "系統錯誤通知";
            string mailBody = string.Empty;
            String path = request.CurrentExecutionFilePath;
            String[] arrPath = path.Split('/');
            String task_id = arrPath[arrPath.Length - 2];
            String page_id = arrPath[arrPath.Length - 1];
            page_id = page_id.Replace(".aspx", "");
            TaskMediator taskMed = TaskMediator.getInstance();
            String task_name = taskMed.lookupTaskName(task_id);
            mailBody += "操作人員：" + userID.getUserID() + "(" + userID.getUserName().ToUpper() + ")<br />";
            mailBody += "操作時間：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "<br/>";
            mailBody += "系統功能：" + task_name + "(" + page_id + ")<br/>";
            mailBody += "系統錯誤訊息：" + ex.Message + "<br/>";
            mailBody += "系統錯誤位置：" + ex.StackTrace + "<br/>";
            msgMail.Body = mailBody;
            msgMail.BodyEncoding = Encoding.UTF8;
            msgMail.IsBodyHtml = true;

            SmtpClient SmtpMail = new SmtpClient();
            msgMail.IsBodyHtml = true;
            msgMail.BodyEncoding = Encoding.UTF8;
            msgMail.SubjectEncoding = Encoding.UTF8;
            //msgMail.Subject = mailSubject;
            msgMail.Subject = "系統錯誤通知";
            msgMail.Body = mailBody;

            //if (mailAttachment.Length > 0)
            //{
            //    if (mailAttachment.Contains(","))
            //    {
            //        string[] Attach = mailAttachment.Split(',');

            //        for (int i = 0; i < Attach.Length - 1; i++)
            //        {
            //            Attachment attachment = new Attachment(Attach[i]); //create the attachment
            //            msgMail.Attachments.Add(attachment);  //add the attachment
            //        }
            //    }
            //}

            #region 可以發信的GMail
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);
            MySmtp.UseDefaultCredentials = false;
            MySmtp.Credentials = new NetworkCredential("taipei.dep@gmail.com", "la73087308");//設定帳號密碼 
            MySmtp.EnableSsl = true; //smtp 是否使用 SSL 
            MySmtp.Send(msgMail);
            #endregion
        }
        catch (Exception e)
        {
            throw e;
        }

    }
}
