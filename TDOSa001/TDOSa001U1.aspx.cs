using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// 系統帳號：修改頁
/// </summary>
public partial class TDOSa001_TDOSa001U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSa001_update");
                btnDelete.Visible = userID.hasFunc("TDOSa001_delete");

                Form form = new Form();
                form.setValue("user_id", Request["user_id"]);

                UserModel model = new UserModel();
                model.dao = dao;
                dao.UseDepConn(true);
                dao.open();
                HtmlTag hTag = new HtmlTag();

                DataSet ds = model.selectDepUser(form.getValue("user_id"));
                DataRow dr = ds.Tables[0].Rows[0];

                user_id.Text = dr["UserId"].ToString().ToUpper();
                user_name.Text = dr["UserName"].ToString();
                user_no.Text = dr["UserNo"].ToString();
                user_title.Text = dr["user_title"].ToString();
                user_dep.Text = dr["user_dep"].ToString() + " - " + dr["sub_dep"].ToString();
                user_department.Text = dr["Department"].ToString();
                user_cont1.Text = dr["Phone"].ToString() + dr["ExPhone"].ToString() == "" ? "" : " 分機：" + dr["ExPhone"].ToString();
                user_cont2.Text = dr["Phone2"].ToString() + dr["ExPhone2"].ToString() == "" ? "" : " 分機：" + dr["ExPhone2"].ToString();
                user_fax.Text = dr["Fax"].ToString();
                user_mobile.Text = dr["Mobile"].ToString();
                user_address.Text = dr["Address"].ToString();
                user_email.Text = dr["Email"].ToString();

                dao.close();
                dao.UseDepConn(false);
                dao.open();

                ArrayList al = model.selectUser(form.getValue("user_id"));
                RoleModel roleModel = new RoleModel();
                roleModel.dao = dao;
                ArrayList alRole = roleModel.selectRoleOption();

                String RoleValue = string.Empty;
                String StatusValue = string.Empty;
                String OrgValue = string.Empty;
                String ReadValue = "SELF";
                String subValue = string.Empty;
                if (al.Count != 0)
                {
                    Hashtable ht = (Hashtable)al[0];
                    StatusValue = ht["STATUS"].ToString();
                    RoleValue = ht["ROLE_ID"].ToString();
                    OrgValue = ht["USER_ORG"].ToString();
                    ReadValue = ht["USER_READ"].ToString();
                    subValue = ht["SUB_ORG"].ToString();
                    hfAction.Value = "update";
                    user_read.SelectedValue = ht["USER_READ"].ToString();

                }
                else
                {
                    hfAction.Value = "insert";
                    OrgValue = model.getLocalOrgId(dr["DepId"].ToString());
                }

                hTag.createSelect(alRole, role_id, RoleValue, "請選擇", 0);
                hTag.createMediatorSelect("USE_STS", status, StatusValue, "請選擇", 0);
                hTag.createMediatorSelect("DEP_ORG", user_org, OrgValue, "請選擇", 0);
                user_org_SelectedIndexChanged(sender, e);
                if (sub_org.Visible == true)
                {
                    sub_org.SelectedValue = subValue;
                }
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 返回按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSa001Q1.aspx", "", this));
    }


    private Boolean CheckAll()
    {
        Boolean flag = true;

        if (sub_org.Visible == true)
        {
            if (sub_org.SelectedValue == string.Empty)
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "請選擇分隊單位！");
            }
        }

        if (flag && user_read.SelectedValue == string.Empty)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請選擇資料讀取範圍！");
        }


        return flag;
    }

    /// <summary>
    /// 儲存按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {

            if (CheckAll())
            {
                dao.open();
                dao.beginTransaction();

                Form form = new Form();
                form.setValue("user_id", user_id.Text.ToUpper());
                form.setValue("status", status.SelectedValue);
                form.setValue("role_id", role_id.SelectedValue);
                form.setValue("user_org", user_org.SelectedValue);
                if (sub_org.Visible == true)
                {
                    form.setValue("sub_org", sub_org.SelectedValue);
                }
                form.setValue("user_read", user_read.SelectedValue);
                form.setValue("create_user", userID.getUserID());

                //新增使用者群組
                RoleModel roleModel = new RoleModel();
                roleModel.dao = dao;
                UserModel model = new UserModel();
                model.dao = dao;

                if (hfAction.Value == "insert")
                {
                    roleModel.insertRoleForUser(form.getValue("user_id"), form.getValue("role_id"));
                    model.insertUser(form);
                }
                else if (hfAction.Value == "update")
                {
                    form.setValue("update_user", userID.getUserID());
                    roleModel.updateRoleForUser(form.getValue("user_id"), form.getValue("role_id"));
                    model.updateUser(form);
                }
                dao.commit();
                btnDelete.Visible = userID.hasFunc("TDTSa001_delete");
                SysMsg.AlertMessage(this.Page, "儲存成功！");
            }
        }
        catch (Exception ex)
        {
            dao.rollback();

            SysMsg.AlertMessage(this.Page, "儲存失敗！\\\n" + ex.Message);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 刪除按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {

            dao.open();
            dao.beginTransaction();

            Form form = new Form();
            form.setValue("user_id", user_id.Text.ToUpper());

            RoleModel roleModel = new RoleModel();
            roleModel.dao = dao;
            UserModel model = new UserModel();
            model.dao = dao;

            roleModel.deleteRoleForUser(form.getValue("user_id"));
            model.deleteUser1(form.getValue("user_id"));

            dao.commit();
            Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSa001Q1.aspx", "", this) + "'; </script>");
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "刪除失敗！\\\n" + ex.Message);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// user_org_SelectedIndexChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void user_org_SelectedIndexChanged(object sender, EventArgs e)
    {
        HtmlTag hTag = new HtmlTag();
        String[] org = {"TT002I591", "TT002I592", "TT002I593", "TT002I594", "TT002I595", "TT002I596",
                        "TT002I597", "TT002I599", "TT002I601", "TT002I603", "TT002I604", "TT002I614"};
        if (org.Contains(user_org.SelectedValue))
        {
            sub_org.Visible = true;
            hTag.createMediatorSelect(user_org.SelectedValue, sub_org, "", "請選擇", 0);
        }
        else
        {
            sub_org.Visible = false;
        }
    }

   
}