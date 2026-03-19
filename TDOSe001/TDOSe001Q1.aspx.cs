using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
/// <summary>
/// 加油資料管理：查詢頁
/// </summary>
public partial class TDOSe001_TDOSe001Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
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
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$component_no_s":
                    sortedfield.Value = "browse1";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$component_no_sd":
                    sortedfield.Value = "browse1d";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$component_name_s":
                    sortedfield.Value = "browse1component_name";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$component_name_sd":
                    sortedfield.Value = "browse1component_named";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$component_spec_s":
                    sortedfield.Value = "browse1component_spec";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$component_spec_sd":
                    sortedfield.Value = "browse1component_specd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$unit_s":
                    sortedfield.Value = "browse1unit";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$unit_sd":
                    sortedfield.Value = "browse1unitd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$budget2_s":
                    sortedfield.Value = "browse1budget2";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$budget2_sd":
                    sortedfield.Value = "browse1budget2d";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$component_code_s":
                    sortedfield.Value = "browse1component_code";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$component_code_sd":
                    sortedfield.Value = "browse1component_coded";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_s":
                    sortedfield.Value = "browse1car_type";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_sd":
                    sortedfield.Value = "browse1car_typed";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$memo_s":
                    sortedfield.Value = "browse1memo";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$memo_sd":
                    sortedfield.Value = "browse1memod";
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
                    btnQuery.Visible = userID.hasFunc("TDOSe001_query") || userID.hasFunc("TDOSe001_update");

                    btnInsert.Visible = userID.hasFunc("TDOSe001_query") || userID.hasFunc("TDOSe001_update");
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
                //DataSet ds = pb.doSearch(model, "browse1");

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                }

                String cpnoValue = "";
                String cpnameValue = "";
                String cpspecValue = "";
                String cpcodeValue = "";
                String cartypeValue = "";
                String yearValue = "";
                //String budgetstartValue = "";
                //String budgetendValue = "";

                //有預設值，若有查詢過，則以新條件為準

                if (pb.isDoSearch())
                {
                    cpnoValue = form.getValue("component_no");
                    cpnameValue = form.getValue("component_name");
                    cpspecValue = form.getValue("component_spec");
                    cpcodeValue = form.getValue("component_code");
                    cartypeValue = form.getValue("car_type");
                    yearValue = form.getValue("report_year");
                    //budgetstartValue = form.getValue("budget_start");
                    //budgetendValue = form.getValue("budget_end");
                }
                else
                    yearValue = model.getLatestYear();

                component_no.Text = cpnoValue;
                component_name.Text = cpnameValue;
                component_spec.Text = cpspecValue;
                component_code.Text = cpcodeValue;
                report_year.SelectedValue = yearValue;
                //report_y.Value = yearValue;//wenny_年改下拉式選單
                //report_year.Text = yearValue;//原程式碼
                //budget_start.Text = budgetstartValue;
                //budget_end.Text = budgetendValue;

                #region 適用車種

                ArrayList al = model.selectCarType();
                hTag.createSelect(al, car_type, cartypeValue, "請選擇", 0);

                #endregion
                #region 年度
                ArrayList alYear = model.selectYear();
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
        UserID userID = (UserID)Session["UserID"];

        if (e.Row.RowType == DataControlRowType.Header)
        {
            //原程式碼
            Label lb = (Label)e.Row.FindControl("budget2_h");
            lb.Text = "預算單價(第" + userID.getCRSArea().ToString() + "區)";
            //e.Row.Cells[5].Text = "預算單價(第" + userID.getCRSArea().ToString() + "區)";


            //原程式碼

        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //if (userID.getCRSArea() != 2)

            //    {

            e.Row.Cells[5].Text = String.Format("{0:N2}", double.Parse(drv["budget" + userID.getCRSArea().ToString()].ToString()));//資料庫改成小數型態_wenny1061123
            //    e.Row.Cells[5].Text = String.Format("{0:N0}", (Int64.Parse(drv["budget" + userID.getCRSArea().ToString()].ToString())));
            //}
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSe001I1.aspx", "", this));
    }

    /// <summary>
    /// 查詢按鈕事件
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
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);

            form.setValue("report_year", report_year.SelectedValue);
            //form.setValue("report_year", report_y.Value);//wenny_改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1");
            Session["field"] = "browse1";
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
    protected void component_name_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        //try
        //{
        dao.open();

        Form form = new Form();
        form.setValue("component_no", component_no.Text.Trim());
        form.setValue("component_name", component_name.Text.Trim());
        form.setValue("component_spec", component_spec.Text.Trim());
        form.setValue("component_code", component_code.Text.Trim());
        form.setValue("car_type", car_type.SelectedValue); 
        form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單report_year.SelectedValue
        //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單report_year.SelectedValue

        //form.setValue("report_year", report_year.Text.Trim());//原程式碼
        //form.setValue("budget_start", budget_start.Text.Trim());
        //form.setValue("budget_end", budget_end.Text.Trim());
        ComponentModel model = new ComponentModel();
        PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
        pb.setDBDAO(dao);
        DataSet ds = pb.doSearch(model, form, "browse1component_name");
        Session["field"] = "browse1component_name";
        if (pb.isDoSearch())
        {
            gvMain.DataSource = ds;
            gvMain.DataBind();
        }

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
    protected void component_spec_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1component_spec");
            Session["field"] = "browse1component_spec";
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
    protected void unit_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1unit");
            Session["field"] = "browse1unit";
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
    protected void budget2_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year",report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1budget2");
            Session["field"] = "browse1budget2";
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
    protected void component_code_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1component_code");
            Session["field"] = "browse1component_code";
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
    protected void car_type_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_type");
            Session["field"] = "browse1car_type";
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
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1memo");
            Session["field"] = "browse1memo";
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
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1d");
            Session["field"] = "browse1d";

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
    protected void component_name_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1component_named");
            Session["field"] = "browse1component_named";
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
    protected void component_spec_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1component_specd");
            Session["field"] = "browse1component_specd";
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
    protected void unit_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1unitd");
            Session["field"] = "browse1unitd";
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
    protected void budget2_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1budget2d");
            Session["field"] = "browse1budget2d";
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
    protected void component_code_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1component_coded");
            Session["field"] = "browse1component_coded";
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
    protected void car_type_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_typed");
            Session["field"] = "browse1car_typed";
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
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_年改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_年改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1memod");
            Session["field"] = "browse1memod";
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


    /// <summary>
    /// gvMain_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string component_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("TDOSe001U1.aspx?component_id=" + component_id, "", this));
    }

    #region 匯出EXCEL_wenny_1061128
    /// <summary>
    /// 匯出按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("component_no", component_no.Text.Trim());
            form.setValue("component_name", component_name.Text.Trim());
            form.setValue("component_spec", component_spec.Text.Trim());
            form.setValue("component_code", component_code.Text.Trim());
            form.setValue("car_type", car_type.SelectedValue);
            form.setValue("report_year", report_year.SelectedValue);//wenny_改下拉式選單
            //form.setValue("report_year", report_y.Value);//wenny_改下拉式選單
            //form.setValue("report_year", report_year.Text.Trim());//原程式碼
            //form.setValue("budget_start", budget_start.Text.Trim());
            //form.setValue("budget_end", budget_end.Text.Trim());
            ComponentModel model = new ComponentModel();
            model.dao = dao;
            ArrayList al = model.export(form);
            genExcel(al);
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
    private void genExcel(ArrayList al)
    {
        ExcelUtility excel = new ExcelUtility();
        Mediator med = Mediator.getInstance(true);

        try
        {
            //設定style
            HSSFFont HtitleFont = excel.CreateFont(14, "標楷體", true);
            HSSFFont HdateFont = excel.CreateFont(10, "標楷體", true);
            HSSFFont TitleFont = excel.CreateFont(11, "標楷體", true);
            HSSFFont ContFont = excel.CreateFont(10, "標楷體", true);
            HdateFont.Boldweight = 1;
            ContFont.Boldweight = 1;
            HSSFCellStyle styleHtitle = excel.CreateWordStyle(HtitleFont, ExcelUtility.ALIGN_CENTER, false, true);
            HSSFCellStyle styleHdateR = excel.CreateWordStyle(HdateFont, ExcelUtility.ALIGN_RIGHT, false, true);
            HSSFCellStyle styleHdateL = excel.CreateWordStyle(HdateFont, ExcelUtility.ALIGN_LEFT, false, true);
            HSSFCellStyle styleTitleC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleTitleL = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleTitleR = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContC = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContL = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleContR = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleSumC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleSumR = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContF = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00");
            HSSFCellStyle styleContM = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "###,##0");
            //excel.fillCellColor(styleTitleC, HSSFColor.LIGHT_CORNFLOWER_BLUE.index);           
            excel.fillCellColor(styleSumC, HSSFColor.TAN.index);
            excel.fillCellColor(styleSumR, HSSFColor.TAN.index);
            excel.CreateSheet("標案項目管理");

            //預設列高
            excel.SetDefaultRowHeight(40);

            //表頭
            //excel.CreateRow(0);//excel第一列索引值為0
            //excel.SetRowHeight(40);
            //excel.AddMergedRegion(0, 0, 0, 7);
            //excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局車輛定檢月報表");

            ////列印日期
            //excel.CreateRow(1);
            //excel.AddMergedRegion(1, 1, 0, 3);
            //excel.AddMergedRegion(1, 1, 6, 7);
            //excel.CreateCell(styleHdateL, 0, "報表年月：" + txtReport_YM.Text);
            //excel.CreateCell(styleHdateR, 6, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));
            UserID userID = (UserID)Session["UserID"];
            //標題
            string budget = "預算單價(第" + userID.getCRSArea().ToString() + "區)";
            excel.CreateRow(0);
            excel.CreateCell(styleTitleC, 0, "序號");
            excel.SetColumnWidth(0, 80);
            excel.CreateCell(styleTitleC, 1, "零件編號");
            excel.SetColumnWidth(1, 100);
            excel.CreateCell(styleTitleC, 2, "項目名稱");
            excel.SetColumnWidth(2, 100);
            excel.CreateCell(styleTitleC, 3, "規格");
            excel.SetColumnWidth(3, 110);
            excel.CreateCell(styleTitleC, 4, "單位");
            excel.SetColumnWidth(4, 140);
            excel.CreateCell(styleTitleC, 5, budget);
            excel.SetColumnWidth(5, 100);
            excel.CreateCell(styleTitleC, 6, "代碼");
            excel.SetColumnWidth(6, 100);
            excel.CreateCell(styleTitleC, 7, "適用車種 ");
            excel.SetColumnWidth(7, 100);
            excel.CreateCell(styleTitleC, 8, "備註");
            excel.SetColumnWidth(8, 200);


            int rows = 0;

            //內容
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                rows++;
                excel.CreateRow(rows);
                excel.SetRowHeight(30);

                excel.CreateCell(styleContC, 0, (i + 1));
                excel.CreateCell(styleContL, 1, ht["COMPONENT_NO"].ToString());
                excel.CreateCell(styleContL, 2, ht["COMPONENT_NAME"].ToString());
                excel.CreateCell(styleContL, 3, ht["COMPONENT_SPEC"].ToString());
                excel.CreateCell(styleContL, 4, ht["UNIT"].ToString());
                excel.CreateCell(styleContL, 5, ht["BUDGET" + userID.getCRSArea().ToString()].ToString());
                excel.CreateCell(styleContL, 6, ht["COMPONENT_CODE"].ToString());
                //excel.CreateCell(styleContC, , ht["budget1"].ToString());
                excel.CreateCell(styleContL, 7, ht["CAR_TYPE"].ToString());
                excel.CreateCell(styleContL, 8, ht["MEMO"].ToString());

            }

            //設定列印配置
            excel.SetPagesize(9);     //A4
            excel.SetLandscape(true);//橫印             
            excel.setScale(100);      //設定縮放 %
            excel.SetMargin(1, 1, 0.5, 1);  //設定邊寬
            excel.SetFooterMargin(0.5);
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 0);

            //輸出檔案
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("標案項目管理.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + "\\\n" + ex.StackTrace);
        }
    }
    #endregion



}