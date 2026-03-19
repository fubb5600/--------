using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 系統帳號：新增頁
/// </summary>
public partial class TDTSa001_TDTSa001I1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            if (!IsPostBack)
            {
                String DepValue = "";
                String SubDepValue = "";
                String TitleValue = "";
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSa001_insert");

                HtmlTag hTag = new HtmlTag();

                RoleModel roleModel = new RoleModel();
                roleModel.dao = dao;
                ArrayList alRole = roleModel.selectRoleOption();
                hTag.createSelect(alRole, role_id, "", "", 0);

                hTag.createMediatorSelect("USE_STS", status, "", "", 0);

                UserModel model = new UserModel();
                model.dao = dao;


                hTag.createSelect(model.selectUserDep(), user_dep, DepValue, "請選擇", 0);

                hTag.createSelect(model.selectUserSubDep(DepValue), sub_dep, SubDepValue, "請選擇", 0);
                hTag.createSelect(model.selectUserTitle(), user_title, TitleValue, "請選擇", 0);


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
    protected void user_dep_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBDAO daoDep = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            UserModel Depmodel = new UserModel();
            daoDep.UseDepConn(true);
            daoDep.open();
            Depmodel.dao = daoDep;

            hTag.createSelect(Depmodel.selectUserSubDep(user_dep.SelectedValue), sub_dep, "", "請選擇", 0);
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            daoDep.close();
        }
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
            dao.open();
            dao.beginTransaction();

            Form form = new Form();
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("status", status.SelectedValue);
            form.setValue("passwd", passwd.Text);
            form.setValue("role_id", role_id.SelectedValue);
            form.setValue("create_user", userID.getUserID());

            //新增使用者

            UserModel userModel = new UserModel();
            userModel.dao = dao;
            userModel.insertUser(form);

            //新增使用者群組

            RoleModel roleModel = new RoleModel();
            roleModel.dao = dao;




            roleModel.insertRoleForUser(form.getValue("user_id"), form.getValue("role_id"));
            form.setValue("user_no", user_no.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_department", user_department.Text);

            form.setValue("user_cont1", user_cont1.Text);
            form.setValue("user_cont2", user_cont2.Text);
            form.setValue("ExPhone", ExPhone.Text);
            form.setValue("ExPhone2", ExPhone2.Text);

            form.setValue("user_fax", user_fax.Text);
            form.setValue("user_mobile", user_mobile.Text);
            form.setValue("user_address", user_address.Text);
            form.setValue("user_email", user_email.Text);
            form.setValue("passwd", passwd.Text);

            //新增使用者資訊
            userModel.insertUser1(form);








            dao.commit();
            SysMsg.AlertMessage(this.Page, "新增成功！");
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
}