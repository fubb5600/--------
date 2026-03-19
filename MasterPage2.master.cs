using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.ID = "MasterPage";

        if (Session["UserID"] == null)
        {
            Response.Redirect("~/login.aspx", true);
            return;
        }

        if (Request["OLD_TASK"] != null)
        {
            OLD_TASK.Text = HandleParam.replaceChars(Request["OLD_TASK"]);
        }

        for (int i = 1; i <= IniValue.PB_COUNT; i++)
        {
            String key = "";
            if (i > 1)
            {
                key = i.ToString();
            }

            TextBox wp = new TextBox();
            wp.ID = "whereParam" + key;
            wp.Visible = false;
            if (Request["whereParam" + key] != null)
            {
                wp.Text = HandleParam.replaceChars(Request["whereParam" + key]);
            }
            else
            {
                wp.Text = "";
            }

            TextBox pn = new TextBox();
            pn.ID = "pageNumber" + key;
            pn.Visible = false;
            if (Request["pageNumber" + key] != null)
            {
                pn.Text = HandleParam.replaceChars(Request["pageNumber" + key]);
            }
            else
            {
                pn.Text = "1";
            }

            sysLabel.Controls.Add(wp);
            sysLabel.Controls.Add(pn);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ID = "MasterPage2";

        if (Session["UserID"] == null)
        {
            Response.Write("<script>alert('請先登入!!');</script>");
            Response.Redirect("login.aspx");
        }
        else if (!IsPostBack)
        {

        }
    }

    protected void ResultBack_Click(object sender, EventArgs e)
    {
        if (!nextPage.Text.Equals(""))
        {
            Response.Redirect(Forward.Redirect(nextPage.Text, pageParam.Text, this.Page));
        }
        else
        {
            TaskPanel.Visible = true;
            ResultPanel.Visible = false;
            ResultMsg.Text = "";
            ResultMsgDesc.Text = "";
            nextPage.Text = "";
            pageParam.Text = "";
        }
    }
}
