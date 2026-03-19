using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 系統帳號：查詢頁
/// </summary>
public partial class TDOSa001_TDOSa001Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();        
        HtmlTag hTag = new HtmlTag();
        btnQuery.Visible = userID.hasFunc("TDOSa001_query");
        btnInsert.Visible = userID.hasFunc("TDOSa001_insert");
        if (IsPostBack)
        {
            var ctlName = this.Request.Params["__EVENTTARGET"];
            switch (ctlName)
            {
                case "MasterPage$ContentPlaceHolder1$btnQuery":
                    sortedfield.Value = "browse1";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$ROW_NUM_s":
                    sortedfield.Value = "browse1";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$ROW_NUM_sd":
                    sortedfield.Value = "browse1d";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$user_id_s":
                    sortedfield.Value = "browse1";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$user_id_sd":
                    sortedfield.Value = "browse1d";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$user_name_s":
                    sortedfield.Value = "browse1user_name";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$user_name_sd":
                    sortedfield.Value = "browse1user_named";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$status_s":
                    sortedfield.Value = "browse1status";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$status_sd":
                    sortedfield.Value = "browse1statusd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$DepName_s":
                    sortedfield.Value = "browse1DepName";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$DepName_sd":
                    sortedfield.Value = "browse1DepNamed";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$Department_s":
                    sortedfield.Value = "browse1Department";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$Department_sd":
                    sortedfield.Value = "browse1Departmentd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$Professional_s":
                    sortedfield.Value = "browse1Professional";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$Professional_sd":
                    sortedfield.Value = "browse1Professionald";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$role_name_s":
                    sortedfield.Value = "browse1role_name";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$role_name_sd":
                    sortedfield.Value = "browse1role_named";
                    break;
                default:
                    break;
            }
            //Response.Write(ctlName);
        }

        dao.open();

        String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
        if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
        {
            if (!IsPostBack)
            {
                //button權限
                btnQuery.Visible = userID.hasFunc("TDOSa001_query") || userID.hasFunc("TDOSa001_update");
                //btnInsert.Visible = userID.hasFunc("TDTSa001_insert");
            }


            UserModel model = new UserModel();
            model.dao = dao;

            //角色群組資料來源             
            ArrayList al_Role = model.selectRole();

            //分頁設定                
            Form form = new Form();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            //wenny_test_排序
            if (string.IsNullOrEmpty(sortedfield.Value))
            {
                sortedfield.Value = Session["field"].ToString();//查詢排序編輯後返回頁面
            }
            DataSet ds = pb.doSearch(model, sortedfield.Value);
            //wenny_test_排序
            //DataSet ds = pb.doSearch(model," browse1");
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();

                //還原查詢條件
                form = pb.getFormData();
            }

            //使用者帳號
            user_id.Text = form.getValue("user_id");

            //使用者姓名
            user_name.Text = form.getValue("user_name");

            //狀態
            String statusValue = "";
            String DepValue = "";
            String SubDepValue = "";
            String TitleValue = "";
            String RoleValue = "";
            //有預設值，若有查詢過，則以新條件為準

            if (pb.isDoSearch())
            {
                statusValue = form.getValue("status");
                DepValue = form.getValue("user_dep");
                SubDepValue = form.getValue("sub_dep");
                TitleValue = form.getValue("user_title");
                RoleValue = form.getValue("user_role");
            }

            hTag.createMediatorCheckBox("USE_STS", status, statusValue, "", 0);
            hTag.createSelect(model.selectUserDep(), user_dep, DepValue, "請選擇", 0);
            hTag.createSelect(model.selectUserSubDep(DepValue), sub_dep, SubDepValue, "請選擇", 0);
            hTag.createSelect(model.selectUserTitle(), user_title, TitleValue, "請選擇", 0);
            hTag.createSelect(al_Role, user_role, RoleValue, "請選擇", 0);
        }

        if (__EVENTTARGET.Equals("ChangePaging"))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script>chgHash('pb'); </script>");
        }

        dao.close();

     

        //try
        //{
        //    dao.open();

        //    String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
        //    if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
        //    {
        //        if (!IsPostBack)
        //        {
        //            //button權限
        //            btnQuery.Visible = userID.hasFunc("TDOSa001_query") || userID.hasFunc("TDOSa001_update");
        //            //btnInsert.Visible = userID.hasFunc("TDTSa001_insert");
        //        }


        //         UserModel model = new UserModel();
        //        model.dao = dao;

        //        //角色群組資料來源             
        //        ArrayList al_Role = model.selectRole();

        //        //分頁設定                
        //        Form form = new Form();
        //        PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
        //        pb.setDBDAO(dao);
        //        DataSet ds = pb.doSearch(model, "browse1");
        //        if (pb.isDoSearch())
        //        {
        //            gvMain.DataSource = ds;
        //            gvMain.DataBind();

        //            //還原查詢條件
        //            form = pb.getFormData();
        //        }

        //        //使用者帳號
        //        user_id.Text = form.getValue("user_id");

        //        //使用者姓名
        //        user_name.Text = form.getValue("user_name");

        //        //狀態
        //        String statusValue = "";
        //        String DepValue = "";
        //        String SubDepValue = "";
        //        String TitleValue = "";
        //        String RoleValue = "";
        //        //有預設值，若有查詢過，則以新條件為準

        //        if (pb.isDoSearch())
        //        {
        //            statusValue = form.getValue("status");
        //            DepValue = form.getValue("user_dep");
        //            SubDepValue = form.getValue("sub_dep");
        //            TitleValue = form.getValue("user_title");
        //            RoleValue = form.getValue("user_role");
        //        }

        //        hTag.createMediatorCheckBox("USE_STS", status, statusValue, "", 0);
        //        hTag.createSelect(model.selectUserDep(), user_dep, DepValue, "請選擇", 0);
        //        hTag.createSelect(model.selectUserSubDep(DepValue), sub_dep, SubDepValue, "請選擇", 0);
        //        hTag.createSelect(model.selectUserTitle(), user_title, TitleValue, "請選擇", 0);
        //        hTag.createSelect(al_Role, user_role, RoleValue, "請選擇", 0);
        //    }

        //    if (__EVENTTARGET.Equals("ChangePaging"))
        //    {
        //        this.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script>chgHash('pb'); </script>");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    SysMsg.AlertMessage(this.Page, ex.Message);
        //}
        //finally
        //{
        //    dao.close();           
        //}
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //變更狀態欄顯示
            //Mediator med = Mediator.getInstance();
            //String statusValue = drv["status"].ToString();
            //String statusText = med.lookupParamName("DEP_STS", statusValue, 0);
            //e.Row.Cells[3].Text = statusText;           
        }
    }


    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSa001I1.aspx", "", this));
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1");
           
            Session["field"] = "browse1";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    //wenny_test_排序
    //正排
    protected void user_name_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1user_name");
            Session["field"] = "browse1user_name";

            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void status_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1status");
            Session["field"] = "browse1status";

            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void DepName_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1DepName");
            Session["field"] = "browse1DepName";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void Department_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1Department");
            Session["field"] = "browse1Department";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void Professional_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1Professional");
            Session["field"] = "browse1Professional";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void role_name_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1role_name");
            Session["field"] = "browse1role_name";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    //反排
    protected void btnQueryd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1d");
            Session["field"] = "browse1d";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void user_name_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1user_named");
            Session["field"] = "browse1user_named";

            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void status_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1statusd");
            Session["field"] = "browse1statusd";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void DepName_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1DepNamed");
            Session["field"] = "browse1DepNamed";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void Department_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1Departmentd");
            Session["field"] = "browse1Departmentd";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void Professional_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1Professionald");
            Session["field"] = "browse1Professionald";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    protected void role_name_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("user_id", user_id.Text.ToUpper());
            form.setValue("user_name", user_name.Text);
            form.setValue("user_dep", user_dep.SelectedValue);
            form.setValue("sub_dep", sub_dep.SelectedValue);
            form.setValue("user_title", user_title.SelectedValue);
            form.setValue("user_role", user_role.SelectedValue);
            form.setValue("status", HandleParam.getMultiValue(status));
            UserModel model = new UserModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1role_named");
            Session["field"] = "browse1role_named";
            if (pb.isDoSearch())
            {
                DataSet ds_merge = ds;
                gvMain.DataSource = ds_merge;
                gvMain.DataBind();
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }
    }
    //wenny_test_排序




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


    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string user_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("TDOSa001U1.aspx?user_id=" + user_id, "", this));
    }


    private DataSet UserMergeRole(DataSet search_result, DataSet ds_role)
    {
        for (int i = 0; i < search_result.Tables[0].Rows.Count; i++)
        {
            DataRow dr = search_result.Tables[0].Rows[i];
            for (int j = 0; j < ds_role.Tables[0].Rows.Count; j++)
            {
                DataRow drRole = ds_role.Tables[0].Rows[j];
                if (dr["user_id"].ToString().ToUpper() == drRole["user_id"].ToString())
                {
                    dr["role_id"] = drRole["role_id"].ToString();
                    dr["role_name"] = drRole["role_name"].ToString();
                }                
            }
        }

        return search_result;
    }


    private DataSet RoleMergeUser(DataSet search_result, DataSet ds_user)
    {
        for (int i = 0; i < search_result.Tables[0].Rows.Count; i++)
        {
            DataRow dr = search_result.Tables[0].Rows[i];
            for (int j = 0; j < ds_user.Tables[0].Rows.Count; j++)
            {
                DataRow drUser = ds_user.Tables[0].Rows[j];
                if (dr["user_id"].ToString() == drUser["user_id"].ToString().ToUpper())
                {
                    dr["UserNo"] = drUser["UserNo"].ToString();
                    dr["user_name"] = drUser["user_name"].ToString();
                    dr["DepName"] = drUser["DepName"].ToString();
                    dr["Department"] = drUser["Department"].ToString();
                    dr["status"] = drUser["status"].ToString();                    
                }
            }
        }

        return search_result;
    }
}