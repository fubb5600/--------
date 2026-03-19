using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TDOSa002_TDOSa002Q1 : System.Web.UI.Page
{
    string sBrowse;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                
                if (!IsPostBack)
                {
                    //button權限
                    btnQuery.Visible = userID.hasFunc("TDOSa002_query") || userID.hasFunc("TDOSa002_update");
                }

                //分頁設定
                //查詢資料
                Form form = new Form();
                ParamModel model = new ParamModel();

                //String sBrowse = "browse1";
                PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
                pb.setDBDAO(dao);
                if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                {
                    param_attr.Enabled = false;
                    sBrowse = "browse3";
                }
                //wenny_test_排序
                if (string.IsNullOrEmpty(sortedfield.Value))
                {
                    sortedfield.Value = Session["field"].ToString();//查詢排序編輯後返回頁面
                }
                DataSet ds = pb.doSearch(model, sortedfield.Value);
                //wenny_test_排序

                //DataSet ds = pb.doSearch(model, sortedfield.Value);
                if (pb.isDoSearch())
                {
                    gvMain.DataSource = ds;
                    gvMain.DataBind();

                    //還原查詢條件
                    form = pb.getFormData();
                }

                HtmlTag hTag = new HtmlTag();

                //參數代碼
                param_type.Text = form.getValue("param_type");

                //參數名稱
                param_name.Text = form.getValue("param_name");

                //狀態
                String statusValue = "O";
                String attrValue = "1";

                //有預設值，若有查詢過，則以新條件為準

                if (pb.isDoSearch())
                {
                    statusValue = form.getValue("status");

                    attrValue = form.getValue("param_attr");
                }


                hTag.createMediatorCheckBox("USE_STS", status, statusValue, "", 0);
                param_attr.SelectedValue = attrValue;

                if (__EVENTTARGET.Equals("ChangePaging"))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script>chgHash('pb'); </script>");
                }
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

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //變更狀態欄顯示
            Mediator med = Mediator.getInstance(false);
            String statusValue = drv["status"].ToString();
            String statusText = med.lookupParamName("USE_STS", statusValue, 0);
            e.Row.Cells[3].Text = statusText;

            ////點選(依狀況修改)
            //String url = Forward.Redirect("TDTSa002U1.aspx", "param_type=" + drv["param_type"].ToString(), this);
            //String script = "javascript:window.location='" + url + "'";
            ////tr選取
            //e.Row.Attributes.Add("onclick", script);
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
          
            String sBrowse = "browse1";
            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3";

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);
            sortedfield.Value = sBrowse;
            Session["field"] = sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
    protected void param_type_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1_param_type";//可能要先判斷案哪個鈕給

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3_param_type";

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);
            sortedfield.Value = sBrowse;
            Session["field"] = sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
    protected void param_name_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1_param_name";

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3_param_name";

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);
            sortedfield.Value = sBrowse;
            Session["field"] = sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1_status";
            Session["field"] = sBrowse;

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3_status";

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);
            sortedfield.Value = sBrowse;
            Session["field"] = sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
    protected void memo_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1_memo";

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3_memo";
                Session["field"] = sBrowse;

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);
            sortedfield.Value = sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1d";

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3d";
                Session["field"] = sBrowse;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);

            sortedfield .Value= sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
    protected void param_type_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1_param_typed";

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3_param_typed";

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);
            sortedfield.Value = sBrowse;
            Session["field"] = sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
    protected void param_name_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1_param_named";

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3_param_named";

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);
            sortedfield.Value = sBrowse;
            Session["field"] = sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1_statusd";

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3_statusd";

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, sBrowse);
            sortedfield.Value = sBrowse;
            Session["field"] = sBrowse;
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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
    protected void memo_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("param_attr", param_attr.SelectedValue);
            form.setValue("param_type", param_type.Text.ToUpper());
            form.setValue("param_name", param_name.Text);
            form.setValue("status", HandleParam.getMultiValue(status));
            ParamModel model = new ParamModel();
            String sBrowse = "browse1_memod";

            if (userID.getUserSys().Equals(IniValue.sysCRS) && !userID.getUserID().ToUpper().Equals("ADMIN"))
                sBrowse = "browse3_memod";

            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            sortedfield.Value = sBrowse;
            Session["field"] = sBrowse;
            DataSet ds = pb.doSearch(model, form, sBrowse);
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
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







    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string param_type = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("TDOSa002U1.aspx?param_type=" + param_type, "", this));
    }
}