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

using System.Text.RegularExpressions;
/// <summary>
/// 委外託修作業：查詢頁
/// 
/// 
/// </summary>
public partial class TDOSf002_TDOSf002Q1 : System.Web.UI.Page
{
    string crs_org1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
        #region     //wenny_test_報修五日填資料
        //if (!IsPostBack)

        //{ //wenny_test_報修五日填資料
        //    string str = "下列派工單編號委外託修作業相關資料尚未建置完整\\n";
        //    //for (int i = 0; i < 100; i++)
        //    //{
        //    //    str = str + 'a'+"\\n";
        //    //}

        //    SysMsg.AlertMessage(this.Page, str);
        //}
        #endregion
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
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$crs_org_s":
                    sortedfield.Value = "browse1crs_org_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$crs_org_sd":
                    sortedfield.Value = "browse1crs_org_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$dep_no_s":
                    sortedfield.Value = "browse1dep_no";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$dep_no_sd":
                    sortedfield.Value = "browse1dep_nod";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_no_s":
                    sortedfield.Value = "browse1car_no";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_no_sd":
                    sortedfield.Value = "browse1car_nod";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_s":
                    sortedfield.Value = "browse1car_type";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_sd":
                    sortedfield.Value = "browse1car_typed";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$case_no_s":
                    sortedfield.Value = "browse1case_no";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$case_no_sd":
                    sortedfield.Value = "browse1case_nod";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$work_no_s":
                    sortedfield.Value = "browse1work_no";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$work_no_sd":
                    sortedfield.Value = "browse1work_nod";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$repair_vender_s":
                    sortedfield.Value = "browse1repair_vender";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$repair_vender_sd":
                    sortedfield.Value = "browse1repair_venderd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$check_results":
                    sortedfield.Value = "browse1check_result";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$check_resultsd":
                    sortedfield.Value = "browse1check_resultd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$notify_date_s":
                    sortedfield.Value = "browse1notify_date";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$notify_date_sd":
                    sortedfield.Value = "browse1notify_dated";
                    break;
              
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$finish_dates":
                    sortedfield.Value = "browse1finish_date";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$finish_datesd":
                    sortedfield.Value = "browse1finish_dated";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$total_price_s":
                    sortedfield.Value = "browse1total_price";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$total_price_sd":
                    sortedfield.Value = "browse1total_priced";
                    break;

                //1080513新增
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$notify_date_s1":
                    sortedfield.Value = "browse1notify_date";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$notify_date_sd1":
                    sortedfield.Value = "browse1notify_dated";
                    break;

                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$delivery_days":
                    sortedfield.Value = "browse1delivery_days";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$delivery_daysd":
                    sortedfield.Value = "browse1delivery_daysd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$exec_deadline_s":
                    sortedfield.Value = "browse1exec_deadline_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$exec_deadline_sd":
                    sortedfield.Value = "browse1exec_deadline_sd";
                    break;



                default:
                    break;
            }
            //Response.Write(ctlName);
        }
        else
        {

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

                    btnQuery.Visible = userID.hasFunc("TDOSf002_query") || userID.hasFunc("TDOSf002_update");
                    btnInsert.Visible = userID.hasFunc("TDOSf002_insert");
                    if(Session["role_id"].ToString() == "ADMIN")
                    {
                        True.Visible = true;
                        False.Visible = true;


                    }


                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                    li.Value = userID.getUserOrg();
                    //2018/09/03單位改type改 DEP_ORG
                    //li.Text = med.lookupParamName("CRS_ORG", userID.getUserOrg(), 0);
                    li.Text = med.lookupParamName("DEP_ORG", userID.getUserOrg(), 0);
                    //2018/09/03單位改type改 DEP_ORG
                    string a = userID.getUserOrg();
                    string[] a_result = a.Split(',');
                    Session["role_name"] = userID.getrole_name();


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










                        crs_org.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                    }




                }

              

                RepairModel model = new RepairModel();
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
                    pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
                }
                else
                    pnlPrint.Visible = false;

                String typeValue = "";
                String carnoValue = "";
                String depnoValue = "";
                String venderValue = "";
                String worknoValue = "";
                String casenoValue = "";
                String orgValue = "";
                //2018/08/31測試查驗結果Checkbox
                String resultValue0 = "";
                String resultValue1 = "";
                String resultValue2 = "";
                //2018/08/31測試查驗結果Checkbox
                String repair1Value = "";
                String repair2Value = "";
                String repair3Value = "";
                String notifyStartValue = "";
                String notifyEndValue = "";
                String finishStartValue = "";
                String finishEndValue = "";

                //有預設值，若有查詢過，則以新條件為準
                if (pb.isDoSearch())
                {
                    typeValue = form.getValue("notify_type");
                    carnoValue = form.getValue("car_no");
                    depnoValue = form.getValue("dep_no");
                    venderValue = form.getValue("repair_vender");
                    worknoValue = form.getValue("work_no");
                    casenoValue = form.getValue("case_no");
                    orgValue = form.getValue("crs_org");
                    //2018/08/31測試查驗結果Checkbox
                    //  resultValue = form.getValue(resultValue);//2018/08/31測試查驗結果Checkbox before
                    resultValue0 = form.getValue("resultValue0");
                    resultValue1 = form.getValue("resultValue1");
                    resultValue2 = form.getValue("resultValue2");
                    //2018/08/31測試查驗結果Checkbox
                    repair1Value = form.getValue("repair_type1");
                    repair2Value = form.getValue("repair_type2");
                    repair3Value = form.getValue("repair_type3");
                    notifyStartValue = form.getValue("notify_start");
                    notifyEndValue = form.getValue("notify_end");
                    finishStartValue = form.getValue("finish_start");
                    finishEndValue = form.getValue("finish_end");
                }

                case_no.Text = carnoValue;
                dep_no.Text = depnoValue;
                repair_vender.Text = venderValue;
                case_no.Text = casenoValue;
                work_no.Text = worknoValue;
                notify_start.Text = notifyStartValue;
                notify_end.Text = notifyEndValue;
                finish_start.Text = finishStartValue;
                finish_end.Text = finishEndValue;

               
               
                
                hTag.createMediatorCheckBox("WORK_TYPE", work_type, typeValue, "", 0);
                //2018/08/31測試查驗結果Checkbox
                //hTag.createMediatorCheckBox("CHECK_RSLT", check_result, resultValue, "", 0); //2018/08/31測試查驗結果Checkbox before
                //2018/08/31測試查驗結果Checkbox
                hTag.createMediatorSelect("REPAIR_TYPE", repair_type1, repair1Value, "請選擇", 0);
                hTag.createMediatorSelect("REPAIR_TYPE_3", repair_type3, repair3Value, "請選擇", 0);

                repair_type1_SelectedIndexChanged(sender, e);
                repair_type2_SelectedIndexChanged(sender, e);
                repair_type2.SelectedValue = repair2Value;
                if (repair_type3.Visible)
                    repair_type3.SelectedValue = repair3Value;

                //exec_deadline_start.Text = form.getValue("start_date");
                //exec_deadline_end.Text = form.getValue("end_date");

                //finish_date_start.Text = form.getValue("start_date");
                //finish_date_end.Text = form.getValue("end_date");
                //check_date_start.Text = form.getValue("start_date");
                //check_date_end.Text = form.getValue("end_date");
                //qualified_date_start.Text = form.getValue("start_date");
                //qualified_date_end.Text = form.getValue("end_date");
                //delivery_date_start.Text = form.getValue("start_date");
                //delivery_date_end.Text = form.getValue("end_date");

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
            Mediator med = Mediator.getInstance(true);
            //String statusValue = drv["status"].ToString();
            //String statusText = med.lookupParamName("USE_STS", statusValue, 0);
            //2018/09/03單位改type改 DEP_ORG
            //e.Row.Cells[2].Text = med.lookupParamName("CRS_ORG", drv["crs_org"].ToString(), 0);
            e.Row.Cells[2].Text = med.lookupParamName("DEP_ORG", drv["crs_org"].ToString(), 0);
            //2018/09/03單位改type改 DEP_ORG
            if (drv["notify_type"].ToString().Equals("C"))
                e.Row.Cells[5].Text = med.lookupParamName("CAR_TYPE", drv["car_type"].ToString(), 0);
            else
                e.Row.Cells[5].Text = med.lookupParamName("MACHINE", drv["machine_type"].ToString(), 0);

            e.Row.Cells[14].Text = med.lookupParamName("CHECK_RSLT", drv["check_result"].ToString(), 0);
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSf002I1.aspx", "", this));
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
        String str = "";
      
        try
        {
            dao.open();
            Form form = genFilterForm();
            //2018/08/31測試查驗結果Checkbox 
            //Response.Write(form.getValue("resultValue0")+"<br/>");
            //Response.Write(form.getValue("resultValue1") + "<br/>");
            //Response.Write(form.getValue("resultValue2") + "<br/>");

            //2018/08/31測試查驗結果Checkbox
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1");
            Session["field"] = "browse1";

          




            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void crs_org_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1crs_org_s");
            Session["field"] = "browse1crs_org_s";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void dep_no_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1dep_no");
            Session["field"] = "browse1dep_no";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_no");
            Session["field"] = "browse1car_no";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_type");
            Session["field"] = "browse1car_type";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void case_no_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1case_no");
            Session["field"] = "browse1case_no";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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

    protected void work_no_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1work_no");
            Session["field"] = "browse1work_no";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void repair_vender_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1repair_vender");
            Session["field"] = "browse1repair_vender";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void check_results_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1check_result");
            Session["field"] = "browse1check_result";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void notify_date_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1notify_date");
            Session["field"] = "browse1notify_date";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void finish_date_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1finish_date");
            Session["field"] = "browse1finish_date";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void total_price_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1total_price");
            Session["field"] = "browse1total_price";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
            Form form = genFilterForm();
          
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1d");
            Session["field"] = "browse1d";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void crs_org_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1crs_org_sd");
            Session["field"] = "browse1crs_org_sd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1dep_nod");
            Session["field"] = "browse1dep_nod";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_nod");
            Session["field"] = "browse1car_nod";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_typed");
            Session["field"] = "browse1car_typed";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void case_no_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1case_nod");
            Session["field"] = "browse1case_nod";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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

    protected void work_no_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1work_nod");
            Session["field"] = "browse1work_nod";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void repair_vender_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1repair_venderd");
            Session["field"] = "browse1repair_venderd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void check_resultsd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1check_resultd");
            Session["field"] = "browse1check_resultd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void notify_date_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1notify_dated");
            Session["field"] = "browse1notify_dated";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void finish_date_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1finish_dated");
            Session["field"] = "browse1finish_dated";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void total_price_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1total_priced");
            Session["field"] = "browse1total_priced";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    //1080513新增

    protected void delivery_days_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1delivery_days");
            Session["field"] = "browse1delivery_days";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void delivery_days_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1delivery_daysd");
            Session["field"] = "browse1delivery_daysd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void exec_deadline_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1exec_deadline_s");
            Session["field"] = "browse1exec_deadline_s";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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
    protected void exec_deadline_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1exec_deadline_sd");
            Session["field"] = "browse1exec_deadline_sd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
            }
            else
                pnlPrint.Visible = false;

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




    private Form genFilterForm()
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        dao.open();
        RepairModel model = new RepairModel();
        model.dao = dao;
        Form form = new Form();
        form.setValue("notify_type", HandleParam.getMultiValue(work_type));
        form.setValue("dep_no", dep_no.Text.Trim());
        form.setValue("role_id", Session["role_id"].ToString());
        form.setValue("car_no", car_no.Text.Trim());
        //2018/08/31測試查驗結果Checkbox
        //form.setValue("check_result", HandleParam.getMultiValue(check_result)); //2018/08/31測試查驗結果Checkbox before
        if (check_result0_chk.Checked)
            form.setValue("resultValue0", "PASS");
        else form.setValue("resultValue0", "");
        if(check_result1_chk.Checked)
            form.setValue("resultValue1", "FAIL");
        else form.setValue("resultValue1", "");
        if (check_result2_chk.Checked)
            form.setValue("resultValue2", check_result2_chk.Text);
        else form.setValue("resultValue2", "");

        //2018/08/31測試查驗結果Checkbox
        form.setValue("case_no", case_no.Text.Trim());
        form.setValue("work_no", work_no.Text.Trim());
        form.setValue("repair_vender", repair_vender.Text.Trim());

        if(crs_org.SelectedValue=="")
        {
            form.setValue("crs_org", userID.getUserOrg()
         );

        }
        else
        {
            form.setValue("crs_org", HandleParam.getMultiValue(crs_org));


        }
        form.setValue("repair_type1", repair_type1.SelectedValue);
        form.setValue("repair_type2", repair_type2.SelectedValue);
        form.setValue("repair_type3", repair_type3.SelectedValue);
        form.setValue("notify_start", notify_start.Text.Trim());
        form.setValue("notify_end", notify_end.Text.Trim());
        form.setValue("finish_start", finish_start.Text.Trim());
        form.setValue("finish_end", finish_end.Text.Trim());

        form.setValue("update_user", Session["User"].ToString());


        //form.setValue("exec_deadline_start", exec_deadline_start.Text.Trim());
        //form.setValue("exec_deadline_end", exec_deadline_end.Text.Trim());
        //form.setValue("check_date_start", check_date_start.Text.Trim());
        //form.setValue("check_date_end", check_date_end.Text.Trim());
        //form.setValue("qualified_date_start", qualified_date_start.Text.Trim());
        //form.setValue("qualified_date_end", qualified_date_end.Text.Trim());
        //form.setValue("delivery_date_start", delivery_date_start.Text.Trim());
        //form.setValue("delivery_date_send", delivery_date_end.Text.Trim());
        dao.close();

        return form;
    }

    /// <summary>
    /// gvMain_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string repair_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        string dispatch_num = gvMain.Rows[e.NewEditIndex].Cells[4].Text;
        //Response.Redirect(Forward.Redirect("TDOSf002U1.aspx?chg_id=" + chg_id + "&dispatch_num=" + dispatch_num, "", this));
        Response.Redirect(Forward.Redirect("TDOSf002U1.aspx?repair_id=" + repair_id, "", this));
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

    private void createPDF(String sType, String sFileName)
    {
        var doc = new Document(PageSize.A4, 50, 50, 80, 50);

        MemoryStream memory = new MemoryStream();
        PdfWriter.GetInstance(doc, memory);
        string path = Server.MapPath("./");
        PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(path + sFileName + ".pdf", FileMode.Create));

        //字型設定
        BaseFont bfChilese = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font ChTitleFont = new Font(bfChilese, 24);
        Font ChLargeFont = new Font(bfChilese, 16);
        Font ChFont = new Font(bfChilese, 12);

        doc.Open();

        #region 車輛維修、材料申請暨查驗記錄單
        if (sType.Equals("1"))
        {
            Chunk cTitle = new Chunk("臺北市政府環境保護局\n車輛維修、材料申請暨查驗記錄單", ChTitleFont);
            Phrase pTitle = new Phrase(cTitle);
            Paragraph pg = new Paragraph(pTitle);
            pg.Alignment = Element.ALIGN_CENTER;
            doc.Add(pg);
        }
        #endregion

        #region 車輛送修交車簽收單
        if (sType.Equals("2"))
        {
            for (int i = 0; i < 5; i++)
            {
                Chunk cTitle = new Chunk("臺北市政府環境保護局\n車輛送修交車簽收單", ChTitleFont);
                Phrase pTitle = new Phrase(cTitle);
                Paragraph pg = new Paragraph(pTitle);
                pg.Alignment = Element.ALIGN_CENTER;
                doc.Add(pg);

                doc.Add(new Paragraph(Environment.NewLine, ChFont));
                //表格
                PdfPTable table = new PdfPTable(new float[] { 1, 1, 1, 1 });
                table.TotalWidth = 450f;
                table.LockedWidth = true;

                PdfPCell cellTitle = new PdfPCell(new Phrase("車屬單位：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                PdfPCell cellContent = new PdfPCell(new Phrase("", ChLargeFont));
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("局編車號：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChLargeFont));
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("派工單號：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChLargeFont));
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("交車地點：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChLargeFont));
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("交車日期：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("     年      月      日      時      分", ChLargeFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("備    註", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 80f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChLargeFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("駕駛簽名", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 100f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChLargeFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellContent = new PdfPCell(new Phrase("廠商簽章", ChLargeFont));
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellContent = new PdfPCell(new Phrase("", ChLargeFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                doc.Add(table);

                Chunk cFooter = new Chunk("附註：本單於廠商簽章後，請交回車輛管理員存查。", ChFont);
                Phrase pFooter = new Phrase(cFooter);
                Paragraph pgFooter = new Paragraph(pFooter);
                pgFooter.IndentationLeft = 20f;
                doc.Add(pgFooter);

                doc.NewPage();

            }
        }
        #endregion

        #region 接車單
        if (sType.Equals("3"))
        {
            Chunk cTitle = new Chunk("臺北市政府環境保護局 \n 車輛送修完工接車單", ChTitleFont);
            Phrase pTitle = new Phrase(cTitle);
            Paragraph pg = new Paragraph(pTitle);
            pg.Alignment = Element.ALIGN_CENTER;
            doc.Add(pg);
            doc.Add(new Paragraph(Environment.NewLine, ChFont));
            //表格
            PdfPTable table = new PdfPTable(new float[] { 2, 1, 1, 3, 1 });
            table.TotalWidth = 470f;
            table.LockedWidth = true;

            PdfPCell cellTitle = new PdfPCell(new Phrase("車屬單位：", ChLargeFont));
            cellTitle.MinimumHeight = 20f;
            cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellTitle.FixedHeight = 35f;
            table.AddCell(cellTitle);
            PdfPCell cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.Colspan = 4;
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("局編車號：", ChLargeFont));
            cellTitle.MinimumHeight = 20f;
            cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellTitle.FixedHeight = 35f;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.Colspan = 4;
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("派工號碼：", ChLargeFont));
            cellTitle.MinimumHeight = 20f;
            cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellTitle.FixedHeight = 35f;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.Colspan = 4;
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("接車日期：", ChLargeFont));
            cellTitle.MinimumHeight = 20f;
            cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellTitle.FixedHeight = 35f;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("     年      月      日      時      分", ChLargeFont));
            cellContent.Colspan = 4;
            cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("廠商註記事項(說\n明或建議): ", ChFont));
            cellTitle.MinimumHeight = 20f;
            cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellTitle.FixedHeight = 70f;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.Colspan = 4;
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("□有廢品(名稱/數量)                ■無廢品（原因說明）： ", ChFont));
            cellTitle.Colspan = 8;
            cellTitle.MinimumHeight = 20f;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellTitle.FixedHeight = 35f;
            table.AddCell(cellTitle);

            cellTitle = new PdfPCell(new Phrase("廢品名稱", ChFont));
            cellTitle.MinimumHeight = 18f;
            cellTitle.Colspan = 2;
            cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("數量", ChFont));
            cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("廢品名稱", ChFont));
            cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("數量", ChFont));
            cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);


            cellTitle = new PdfPCell(new Phrase("", ChLargeFont));
            cellTitle.Colspan = 2;
            cellTitle.FixedHeight = 30f;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("", ChLargeFont));
            cellTitle.Colspan = 2;
            cellTitle.FixedHeight = 30f;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("", ChLargeFont));
            cellTitle.Colspan = 2;
            cellTitle.FixedHeight = 30f;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("", ChLargeFont));
            cellTitle.Colspan = 2;
            cellTitle.FixedHeight = 30f;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("", ChLargeFont));
            cellTitle.Colspan = 2;
            cellTitle.FixedHeight = 30f;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellTitle);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);
            cellContent = new PdfPCell(new Phrase("", ChLargeFont));
            cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cellContent);

            cellTitle = new PdfPCell(new Phrase("廠商簽章:                駕駛簽章:                 接收人簽章:", ChFont));
            cellTitle.Colspan = 5;
            cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellTitle.FixedHeight = 50f;
            table.AddCell(cellTitle);
            doc.Add(table);
            doc.NewPage();
        }
        #endregion
        doc.Close();

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(sFileName, System.Text.Encoding.UTF8) + ".pdf");
        Response.ContentType = "application/octet-steam";
        Response.OutputStream.Write(memory.GetBuffer(), 0, memory.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        Response.Flush();
        Response.End();
    }

    protected void btnPrint1_Click(object sender, EventArgs e)
    {
        //createPDF("1", btnPrint1.Text);
        print("TDOSf002P1.ashx");
    }

    protected void btnPrint2_Click(object sender, EventArgs e)
    {
        //createPDF("2", btnPrint2.Text);
        print("TDOSf002P2.ashx");
    }

    protected void btnPrint3_Click(object sender, EventArgs e)
    {
        // createPDF("3", btnPrint3.Text);
        print("TDOSf002P3.ashx");
    }

    private void print(String sURL)
    {
        TDOS tdos = new TDOS();
        string repair_id = "";
        string crs_area = "";

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            GridViewRow gvr = gvMain.Rows[i];

            CheckBox ckb = (CheckBox)gvr.FindControl("chkSelect");
            if (ckb.Checked == true)
            {
                repair_id += gvMain.DataKeys[i].Value.ToString() + ",";
            }
        }

        if (repair_id == string.Empty)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "onload",
                "<script>if(confirm('尚未勾選列印項目，是否列印空白表單？'))   location.href='" + sURL + "?repair_id=" + "';</script>");
        }
        else
            Response.Redirect(sURL + "?repair_id=" + repair_id.Substring(0, repair_id.Length - 1));
    }

    protected void repair_type1_SelectedIndexChanged(object sender, EventArgs e)
    {
        HtmlTag hTag = new HtmlTag();
        if (repair_type1.SelectedValue != string.Empty)
        {
            string sRepairSubType = "REPAIR_TYPE_" + repair_type1.SelectedValue;
            hTag.createMediatorSelect(sRepairSubType, repair_type2, "", "請選擇", 0);
        }
        else
        {
            repair_type2.Items.Clear();
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("請選擇", "");
            repair_type2.Items.Add(li);
        }

        repair_type2_SelectedIndexChanged(sender, e);
    }

    protected void repair_type2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (repair_type1.SelectedValue == "OUT" || repair_type2.SelectedValue == "REPAIR" || repair_type2.SelectedValue == "MAINTENANCE")
        {
            repair_type3.Visible = true;
        }
        else
        {
            repair_type3.Visible = false;
        }

        repair_type3.SelectedIndex = 0;
    }

    /// <summary>
    /// 匯出按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();
            Form form = genFilterForm();
            RepairModel model = new RepairModel();
            model.dao = dao;
            ArrayList al = model.export(form);
            genExcel(al);
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this, ex.Message);
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
            excel.CreateSheet("委外託修作業");

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

            //標題
            excel.CreateRow(0);
            excel.CreateCell(styleTitleC, 0, "序號");
            excel.SetColumnWidth(0, 100);
            excel.CreateCell(styleTitleC, 1, "託修單位");
            excel.SetColumnWidth(1, 110);
            excel.CreateCell(styleTitleC, 2, "局編號");
            excel.SetColumnWidth(2, 100);
            excel.CreateCell(styleTitleC, 3, "車牌號碼");
            excel.SetColumnWidth(3, 100);
            excel.CreateCell(styleTitleC, 4, "車輛/機具類型");
            excel.SetColumnWidth(4, 140);
            excel.CreateCell(styleTitleC, 5, "標案編號");
            excel.SetColumnWidth(5, 200);
            excel.CreateCell(styleTitleC, 6, "派工單號");
            excel.SetColumnWidth(6, 100);
            excel.CreateCell(styleTitleC, 7, "維修廠商");
            excel.SetColumnWidth(7, 160);
            excel.CreateCell(styleTitleC, 8, "查驗結果");
            excel.SetColumnWidth(8, 80);
            excel.CreateCell(styleTitleC, 9, "報修日期");
            excel.SetColumnWidth(9, 100);
            excel.CreateCell(styleTitleC, 10, "完工日期");
            excel.SetColumnWidth(10, 100);
            excel.CreateCell(styleTitleC, 11, "託修總價");
            excel.SetColumnWidth(11, 100);

            int rows = 0;

            //內容
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                rows++;
                excel.CreateRow(rows);
                excel.SetRowHeight(30);

                excel.CreateCell(styleContC, 0, (i + 1));
                //2018/09/03單位改type改 DEP_ORG
                //excel.CreateCell(styleContL, 1, med.lookupParamName("CRS_ORG", ht["CRS_ORG"].ToString(), 0));
                excel.CreateCell(styleContL, 1, med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0));
                //2018/09/03單位改type改 DEP_ORG
                excel.CreateCell(styleContL, 2, ht["DEP_NO"].ToString());
                excel.CreateCell(styleContL, 3, ht["CAR_NO"].ToString());

                if (ht["NOTIFY_TYPE"].ToString().Equals("C"))
                    excel.CreateCell(styleContL, 4, med.lookupParamName("CAR_TYPE", ht["CAR_TYPE"].ToString(), 0));
                else
                    excel.CreateCell(styleContL, 4, med.lookupParamName("MACHINE", ht["MACHINE_TYPE"].ToString(), 0));
                excel.CreateCell(styleContC, 5, ht["CASE_NO"].ToString());
                excel.CreateCell(styleContC, 6, ht["WORK_NO"].ToString());
                excel.CreateCell(styleContL, 7, ht["REPAIR_VENDER"].ToString());
                excel.CreateCell(styleContC, 8, med.lookupParamName("CHECK_RSLT", ht["CHECK_RESULT"].ToString(), 0));
                excel.CreateCell(styleContC, 9, ht["NOTIFY_DATE"].ToString());
                excel.CreateCell(styleContC, 10, ht["FINISH_DATE"].ToString());
                excel.CreateCell(styleContR, 11, string.Format("${0:N0}", Double.Parse((string.IsNullOrEmpty(ht["TOTAL_PRICE"].ToString()) ? "0" : ht["TOTAL_PRICE"].ToString()))));
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
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("臺北市政府環境保護局委外託修作業.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + "\\\n" + ex.StackTrace);
        }
    }



    protected void True_Click(object sender, EventArgs e)
    {
        TDOS tdos = new TDOS();
        string repair_id = "";
        string crs_area = "";
       
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            GridViewRow gvr = gvMain.Rows[i];

            CheckBox ckb = (CheckBox)gvr.FindControl("chkSelect");
            if (ckb.Checked == true)
            {
                repair_id += gvMain.DataKeys[i].Value.ToString() + ",";
            }

        }
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {


            dao.open();
            dao.beginTransaction();
            Form form = new Form();
            form.setValue("repair_id", repair_id);


            RepairModel model = new RepairModel();
            model.dao = dao;
            model.True(form);


            Response.Write("<script>alert('修改成功！');  </script>");




            dao.commit();
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

    protected void False_Click(object sender, EventArgs e)
    {
        TDOS tdos = new TDOS();
        string repair_id = "";
        string crs_area = "";

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            GridViewRow gvr = gvMain.Rows[i];

            CheckBox ckb = (CheckBox)gvr.FindControl("chkSelect");
            if (ckb.Checked == true)
            {
                repair_id += gvMain.DataKeys[i].Value.ToString() + ",";
            }

        }
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {


            dao.open();
            dao.beginTransaction();
            Form form = new Form();
            form.setValue("repair_id", repair_id);


            RepairModel model = new RepairModel();
            model.dao = dao;
            model.Flase(form);


            Response.Write("<script>alert('修改成功！');  </script>");




            dao.commit();
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

    protected void btnIn_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSf002I2.aspx", "", this));
      
    }


}
