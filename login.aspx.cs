using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
/// <summary>
/// 登入頁面
/// </summary>
public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                Session.RemoveAll();
            }


            String sWebName = IniValue.WebName;

            if (Request.Url.Segments[1].ToUpper().Contains(IniValue.sysCRS))
                sWebName = IniValue.CRSWebName;

            lblWebName.Text = sWebName;
            this.Title = sWebName;

            txtUserId.Focus();

            // 以程式設定中文按鈕文字，避免標記中使用非 ASCII 導致編碼或剖析問題
            btnLogin.Text = "\u767B\u0020\u5165"; // "登 入"
        }
    }

    /// <summary>
    /// 登入按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Session["items"] = "";

        Mediator med = Mediator.getInstance(true);

        Form form = new Form();
        form.setValue("userid", txtUserId.Text);
        form.setValue("password", txtPassword.Text);
        Session["field"] = "";
        AuthAC ac = new AuthAC();
        UserID userID = ac.authUserData(form.getValue("userid"), form.getValue("password"));
        if (userID != null)
        {
            Session.Add("Screen_w", Screen_w.Text);
            Session.Add("Screen_h", Screen_h.Text);
            Session.Add("UserID", ac.makeUserBean(userID));
            Response.Write(txtUserId.Text);
            Session["user"] = txtUserId.Text;
            Response.Redirect("~/common/index.aspx", true);
        }
        else
        {
            SysMsg.AlertMessage(this.Page, "帳號或密碼錯誤！");
        }
            
    }
}
