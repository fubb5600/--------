using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
///加油資料匯入：查詢頁
/// </summary>
public partial class TDOSe002_TDOSe002Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        if (IsPostBack)
        {
            var ctlName = this.Request.Params["__EVENTTARGET"];
            switch (ctlName)
            {
                case "MasterPage$ContentPlaceHolder1$btnQuery":
                    sortedfield.Value = "browse2";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$ROW_NUM_s":
                    sortedfield.Value = "browse2";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$ROW_NUM_sd":
                    sortedfield.Value = "browse2d";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$import_id_s":
                    sortedfield.Value = "browse2";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$import_id_sd":
                    sortedfield.Value = "browse2d";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$report_y_s":
                    sortedfield.Value = "browse2report_y";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$report_y_sd":
                    sortedfield.Value = "browse2report_yd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$import_date_s":
                    sortedfield.Value = "browse2import_date";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$import_date_sd":
                    sortedfield.Value = "browse2import_dated";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$import_user_s":
                    sortedfield.Value = "browse2import_user";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$import_user_sd":
                    sortedfield.Value = "browse2import_userd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$count_s":
                    sortedfield.Value = "browse2count";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$count_sd":
                    sortedfield.Value = "browse2countd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$memo_s":
                    sortedfield.Value = "browse2memo";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$memo_sd":
                    sortedfield.Value = "browse2memod";
                    break;
                default:
                    break;
            }
            //Response.Write(ctlName);
        }
        try
        {
            dao.open();

            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限
                    btnQuery.Visible = userID.hasFunc("TDOSe002_query") || userID.hasFunc("TDOSe002_update");
                    btnInsert.Visible = userID.hasFunc("TDOSe002_insert");
                }

                ComponentModel model = new ComponentModel();
                model.dao = dao;

                //分頁設定
                //查詢資料
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
                //DataSet ds = pb.doSearch(model, "browse2");

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                }

                report_year.SelectedValue = form.getValue("report_y"); //wenny_年改下拉式選單
                //report_y.Value = form.getValue("report_y");// wenny_年改下拉式選單
                import_start.Text = form.getValue("import_start");
                import_end.Text = form.getValue("import_end");
                #region 年度
                ArrayList alYear = model.selectYear_imp();
                hTag.createSelect(alYear, report_year, "", "請選擇", 0);
                #endregion
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

        }
    }


    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSe002I1.aspx", "", this));
    }

    /// <summary>
    /// 查詢按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue);// wenny_年改下拉式選單

            //form.setValue("report_y", report_y.Value);// wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2");

           
            Session["field"] = "browse2";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
    protected void report_y_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue);// wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value);// wenny_年改下拉式選單

            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2report_y");
            Session["field"] = "browse2report_y";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
    protected void import_date_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue);// wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value);// wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2import_date");
            Session["field"] = "browse2import_date";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
    protected void import_user_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue); //wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value); //wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2import_user");
            Session["field"] = "browse2import_user";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
    protected void count_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue);// wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value);// wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2count");
            Session["field"] = "browse2count";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue); //wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value); //wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2memo");
            Session["field"] = "browse2memo";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue); //wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value); //wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2d");
            Session["field"] = "browse2d";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
    protected void report_y_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value);//wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2report_yd");
            Session["field"] = "browse2report_yd";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
    protected void import_date_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue); //wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value); //wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2import_dated");
            Session["field"] = "browse2import_dated";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
    protected void import_user_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue); //wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value); //wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2import_userd");
            Session["field"] = "browse2import_userd";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
    protected void count_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue); //wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value); //wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2countd");
            Session["field"] = "browse2countd";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", report_year.SelectedValue); //wenny_年改下拉式選單
            //form.setValue("report_y", report_y.Value); //wenny_年改下拉式選單
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2memod");
            Session["field"] = "browse2memod";
            #region 顯示列數修改_wenny1061123
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (i > 3)
            //        ds.Tables[0].Rows[i].Delete();
            //}
            #endregion 顯示列數修改_wenny1061123
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


    protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBDAO dao = new DBDAO();
        string export_id = gvMain.DataKeys[e.RowIndex].Values[0].ToString().Trim();
        try
        {
            dao.open();
            dao.beginTransaction();
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            model.deleteImportMst(export_id);
            model.deleteImportDtl(export_id);
            dao.commit();
            Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSe002Q1.aspx", "", this) + "'; </script>");
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "刪除失敗！\n" + ex.Message);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 驗證日期格式
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void DateValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(args.Value));
            args.IsValid = true;
        }
        catch
        {
            args.IsValid = false;
        }
    }
}