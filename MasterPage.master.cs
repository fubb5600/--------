using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.ID = "MasterPage";

        if (Session["UserID"] == null)
        {
            //SysMsg.AlertMessage(this.Page, "請先登入!!");
            Response.Write("<script>alert('請先登入!!');</script>");
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


        if (Session["UserID"] == null)
        {
            //SysMsg.AlertMessage(this.Page, "請先登入!!");
            Response.Write("<script>alert('請先登入!!');</script>");
            Response.Redirect("~/login.aspx", true);            
        }
        else if (!IsPostBack)
        {
            String sWebName = IniValue.WebName;

            if (Request.Url.Segments[1].ToUpper().Contains(IniValue.sysCRS))
                sWebName = IniValue.CRSWebName;

            lblWebName.Text = sWebName;
            
            UserID userID = (UserID)Session["UserID"];
            
            ltlMenu.Text = BuildMenu();
            Session["User"] = userID.getUserID();

            #region 現在位置
            TaskMediator taskMed = TaskMediator.getInstance();
            String currentPath = Request.AppRelativeCurrentExecutionFilePath;            
            String[] paths = currentPath.Split('/');
            String TaskPath = string.Empty;
            String task_id = paths[paths.Length - 2];
            for (int i = 0; i < paths.Length - 1; i++)
            {
                TaskPath += taskMed.lookupTaskName(paths[i + 1].Replace(".aspx", ""));
            }
            
            if (!TaskPath.Equals(""))
            {
                this.lblTaskName.Text = TaskPath;
            }
            else
            {
                this.lblTaskName.Text = "首頁";
            }

            Session.Add("TaskID", task_id);

            #endregion

            lblUserInfo.Text = userID.getUserID() + "(" + userID.getUserName() + ")";
        }
    }

    private String BuildMenu()
    {
        string str = string.Empty;
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        if (Request.Url.Segments[1].Contains(IniValue.sysCRS) || userID.getUserID().ToUpper().Equals("ADMIN"))
            userID.setUserSys(IniValue.sysCRS);
        else
            userID.setUserSys("");

        // 這裡開始

        try
        {
            dao.open();
            dao.CommandSQL = "select * from a_task_mst a " +
                "left join (select distinct substring(task_id, 1, 5) as task_id, role_id from a_role_function) b " +
                "on a.task_id = substring(b.task_id, 1, 5) " +
                "left join a_user_role c on b.role_id = c.role_id " +
                "where (a.parent='root' and a.status='O' and c.user_id = @user_id) or a.task_id='Home'" +
                "order by a.display_order ";
            dao.setParam("@user_id", userID.getUserID());
            DataSet ds = dao.searchForDS();
            if (ds.Tables[0].Rows.Count > 0)
            {
                str += "<div id=\"menu\">";
                str += "<ul class=\"menu\">";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    String ParentStr = " class=\"parent\"";
                    if (dr["task_type"].ToString() == "T")
                    {
                        ParentStr = string.Empty;
                    }
                    if (i != ds.Tables[0].Rows.Count - 1)
                    {
                        str += "<li><a href=\"" + dr["url_link"].ToString() + "\"" + ParentStr + "><span>" + dr["task_name"].ToString() + "</span></a>";

                    }
                    else
                    {
                        str += "<li class=\"last\"><a href=\"" + dr["url_link"].ToString() + "\"" + ParentStr + "><span>" + dr["task_name"].ToString() + "</span></a>";
                    }
                    if (dr["task_type"].ToString() == "M")
                    {
                        str += BuildLayer2Menu(dr["task_id"].ToString());
                    }

                    str += "</li>";
                }
                str += "</ul>";
                str += " </div>";
            }
        }
        catch
        { }
        finally { dao.close(); }

        return str;
    }

    private String BuildLayer2Menu(String ParentNode)
    {
        string str = string.Empty;
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();
            dao.CommandSQL = "select * from a_task_mst a " +
                "left join (select distinct task_id, role_id from a_role_function) b on a.task_id = b.task_id " +
                "left join a_user_role c on b.role_id = c.role_id " +
                "where a.parent= @ParentNode and a.status='O' and c.user_id=@user_id " +
                "order by a.display_order";
            dao.setParam("@ParentNode", ParentNode);
            dao.setParam("@user_id", userID.getUserID());
            DataSet ds = dao.searchForDS();
            if (ds.Tables[0].Rows.Count > 0)
            {
                str += "<div>";
                str += "          <ul>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    Session["role_id"] = dr["role_id"].ToString();
                    str += "             <li><a href=\"" + dr["url_link"].ToString() + "\"><span>" + dr["task_name"].ToString() + "</span></a></li>";
                }
                str += "         </ul>";
                str += "</div>";

            }
        }
        catch
        { }
        finally { dao.close(); }


        return str;
    }


    /// <summary>
    /// 登出按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/login.aspx", true);        
    }


    /// <summary>
    /// 系統說明連結
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblhelp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Common/Help.aspx", true);       
    }
}
