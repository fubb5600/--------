using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 車輛異動記錄：查詢頁
/// </summary>
public partial class TDOSc002_TDOSc002Q1 : System.Web.UI.Page
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
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$dep_no_s":
                    sortedfield.Value = "browse1_dep_no";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$dep_no_sd":
                    sortedfield.Value = "browse1_dep_nod";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_no_s":
                    sortedfield.Value = "browse1_car_no_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_no_sd":
                    sortedfield.Value = "browse1_car_no_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_s":
                    sortedfield.Value = "browse1_car_type_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_sd":
                    sortedfield.Value = "browse1_car_type_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$chg_org_s":
                    sortedfield.Value = "browse1_chg_org_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$chg_org_sd":
                    sortedfield.Value = "browse1_chg_org_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$chg_date_s":
                    sortedfield.Value = "browse1_chg_date_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$chg_date_sd":
                    sortedfield.Value = "browse1_chg_date_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$chg_rsn_s":
                    sortedfield.Value = "browse1_chg_rsn_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$chg_rsn_sd":
                    sortedfield.Value = "browse1_chg_rsn_sd";
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

                    //btnQuery.Visible = userID.hasFunc("TDOSc002_query") || userID.hasFunc("TDOSc002_update");
                    btnInsert.Visible = userID.hasFunc("TDOSc002_insert");
                    string a = userID.getUserOrg();
                    string[] a_result = a.Split(',');

                    for (int j = 0; j < a_result.Length; j++)
                    {
                        string b = "";
                        if (a_result[j] == "TT002I591")
                        {
                            b = "士林區清潔隊";


                        }

                        if (a_result[j] == "TT002I592")
                        {
                            b = "大同區清潔隊";


                        }

                        if (a_result[j] == "TT002I593")
                        {
                            b = "大安區清潔隊";


                        }
                        if (a_result[j] == "TT002I594")
                        {
                            b = "中山區清潔隊";


                        }
                        if (a_result[j] == "TT002I595")
                        {
                            b = "中正區清潔隊";


                        }
                        if (a_result[j] == "TT002I598")
                        {
                            b = "公廁管理隊";
                        }
                        if (a_result[j] == "TT002I599")
                        {
                            b = "北投區清潔隊";
                        }
                        if (a_result[j] == "TT002I600")
                        {
                            b = "環境檢驗中心";
                        }

                        if (a_result[j] == "TT002I596")
                        {
                            b = "內湖區清潔隊";

                        }
                        if (a_result[j] == "TT002I597")
                        {
                            b = "文山區清潔隊";
                        }



                        if (a_result[j] == "TT002I601")
                        {
                            b = "松山區清潔隊";


                        }
                        if (a_result[j] == "TT002I602")
                        {
                            b = "直屬清潔隊";


                        }
                        if (a_result[j] == "TT002I603")
                        {
                            b = "信義區清潔隊";
                        }
                        if (a_result[j] == "TT002I604")
                        {
                            b = "南港區清潔隊";
                        }

                        if (a_result[j] == "TT002I605")
                        {
                            b = "政風室";
                        }
                        if (a_result[j] == "TT002I606")
                        {
                            b = "修車廠";
                        }

                        if (a_result[j] == "TT002I607")
                        {
                            b = "秘書室";
                        }
                        if (a_result[j] == "TT002I608")
                        {
                            b = "廢棄物處理場";
                        }

                        if (a_result[j] == "TT002I609")
                        {
                            b = "清山淨水";
                        }
                        if (a_result[j] == "TT002I610")
                        {
                            b = "空污噪音防制科";
                        }
                        if (a_result[j] == "TT002I611")
                        {
                            b = "水質病媒管制科";
                        }
                        if (a_result[j] == "TT002I612")
                        {
                            b = "溝渠一隊";
                        }
                        if (a_result[j] == "TT002I613")
                        {
                            b = "溝渠二隊";
                        }
                        if (a_result[j] == "TT002I614")
                        {
                            b = "萬華區清潔隊";
                        }
                        if (a_result[j] == "TT002I615")
                        {
                            b = "資源回收隊";
                        }
                        if (a_result[j] == "TT002I617")
                        {
                            b = "職業安全管理科";
                        }
                        if (a_result[j] == "TT002I619")
                        {
                            b = "氣候變遷管理科";
                        }
                        if (a_result[j] == "TT002I620")
                        {
                            b = "綜合企劃科";
                        }
                        if (a_result[j] == "TT002I621")
                        {
                            b = "環境清潔管理科";
                        }

                        if (a_result[j] == "TT002I622")
                        {
                            b = "廢棄物處理管理科";
                        }

                        if (a_result[j] == "TT002I623")
                        {
                            b = "資源循環管理科";
                        }










                        chg_org.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                    }

                }
                chg_org.SelectedValue = userID.getUserOrg1();
                if (userID.getUserRead() == "SELF")
                {
                    chg_org.Enabled = false;
                }
                Label1.Text = userID.getUserRead();
                ChangeModel model = new ChangeModel();
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
                //DataSet ds = pb.doSearch(model, browse1);

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                }

                car_no.Text = form.getValue("car_no");
                dep_no.Text = form.getValue("dep_no");
                start_date.Text = form.getValue("start_date");
                end_date.Text = form.getValue("end_date");

                //狀態
                String typeValue = "";
                String orgValue = "";
                String rsnValue = "";
                //有預設值，若有查詢過，則以新條件為準

                if (pb.isDoSearch())
                {
                    typeValue = form.getValue("car_type");
                    orgValue = form.getValue("chg_org");
                    rsnValue = form.getValue("chg_rsn");
                }
                hTag.createMediatorCheckBox("CAR_TYPE", car_type, typeValue, "", 0);
                //hTag.createMediatorCheckBox("DEP_ORG", keep_org, orgValue, "", 0);                

                if (userID.getUserSys().Equals(IniValue.sysCRS))     
                    hTag.createMediatorCheckBox("CRS_CHGRSN", chg_rsn, rsnValue, "", 0);
                else
                     hTag.createMediatorCheckBox("CHG_RSN", chg_rsn, rsnValue, "", 0);

               

                if (__EVENTTARGET.Equals("ChangePaging"))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script>chgHash('pb'); </script>");
                }
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// GridView1_RowDataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //變更狀態欄顯示
            Mediator med = Mediator.getInstance(false);

            e.Row.Cells[3].Text = med.lookupParamName("CAR_TYPE", drv["car_type"].ToString(), 0);
            e.Row.Cells[4].Text = med.lookupParamName("DEP_ORG", drv["chg_org"].ToString(), 0);
            e.Row.Cells[6].Text = med.lookupParamName("CHG_RSN", drv["chg_rsn"].ToString(), 0);
            //String statusValue = drv["status"].ToString();
            //String statusText = med.lookupParamName("USE_STS", statusValue, 0);
            //e.Row.Cells[5].Text = statusText;           
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSc002I1.aspx", "", this));
    }


    /// <summary>
    /// 查詢按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
       
            if (Label1.Text == "SELF")
            {
                form.setValue("status","O");

            }



            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);

            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1");
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
    protected void dep_no_s_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_dep_no");
            Session["field"] = "browse1_dep_no";

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
    protected void car_no_s_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_car_no_s");
            Session["field"] = "browse1_car_no_s";

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
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_car_type_s");
            Session["field"] = "browse1_car_type_s";

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
    protected void chg_org_s_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_chg_org_s");
            Session["field"] = "browse1_chg_org_s";

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
    protected void chg_date_s_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_chg_date_s");
            Session["field"] = "browse1_chg_date_s";

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
    protected void chg_rsn_s_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_chg_rsn_s");
            Session["field"] = "browse1_chg_rsn_s";

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
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1d");
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
    protected void dep_no_sd_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_dep_nod");
            Session["field"] = "browse1_dep_nod";

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
    protected void car_no_sd_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_car_no_sd");
            Session["field"] = "browse1_car_no_sd";

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
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_car_type_sd");
            Session["field"] = "browse1_car_type_sd";

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
    protected void chg_org_sd_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_chg_org_sd");
            Session["field"] = "browse1_chg_org_sd";

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
    protected void chg_date_sd_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_chg_date_sd");
            Session["field"] = "browse1_chg_date_sd";

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
    protected void chg_rsn_sd_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (chg_org.SelectedValue == "")
            {
                form.setValue("chg_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("chg_org", HandleParam.getMultiValue(chg_org));


            }
            if (Label1.Text == "SELF")
            {
                form.setValue("status", "O");

            }
            form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            form.setValue("start_date", start_date.Text.Trim());
            form.setValue("end_date", end_date.Text.Trim());
            ChangeModel model = new ChangeModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds;

            ds = pb.doSearch(model, form, "browse1_chg_rsn_sd");
            Session["field"] = "browse1_chg_rsn_sd";

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
        string chg_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("TDOSc002U1.aspx?chg_id=" + chg_id, "", this));
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