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
/// 車輛報修作業：查詢頁
/// </summary>
public partial class TDOSf001_TDOSf001Q1 : System.Web.UI.Page
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
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$keep_org_s":
                    sortedfield.Value = "browse1keep_org";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$keep_org_sd":
                    sortedfield.Value = "browse1keep_orgd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_s":
                    sortedfield.Value = "browse1car_type";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_sd":
                    sortedfield.Value = "browse1car_typed";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$work_no_s":
                    sortedfield.Value = "browse1work_no";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$work_no_sd":
                    sortedfield.Value = "browse1work_nod";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$notify_date_s":
                    sortedfield.Value = "browse1notify_date";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$notify_date_sd":
                    sortedfield.Value = "browse1notify_dated";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$finish_date_s":
                    sortedfield.Value = "browse1finish_date";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$finish_date_sd":
                    sortedfield.Value = "browse1finish_dated";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$notify_item_s":
                    sortedfield.Value = "browse1notify_item";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$notify_item_sd":
                    sortedfield.Value = "browse1notify_itemd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$repair_type_s":
                    sortedfield.Value = "browse1repair_type_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$repair_type_sd":
                    sortedfield.Value = "browse1repair_type_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$repair_status_s":
                    sortedfield.Value = "browse1repair_status_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$repair_status_sd":
                    sortedfield.Value = "browse1repair_status_sd";
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
                    btnQuery.Visible = userID.hasFunc("TDOSf001_query") || userID.hasFunc("TDOSf001_update");
                    btnInsert.Visible = userID.hasFunc("TDOSf002_insert");
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                    li.Value = userID.getUserOrg();
                    //2018/09/03單位改type改 DEP_ORG
                    //li.Text = med.lookupParamName("CRS_ORG", userID.getUserOrg(), 0);
                    li.Text = med.lookupParamName("DEP_ORG", userID.getUserOrg(), 0);
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










                        crs_org.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));

                    }
                    crs_org.SelectedValue = userID.getUserOrg1();
                    if (userID.getUserRead() == "SELF")
                    {
                        crs_org.Enabled = false;

                    }

                }

                NotifyModel model = new NotifyModel();
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
                //DataSet ds = pb.doSearch(model," browse1");

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                    pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
                }
                else
                    pnlPrint.Visible = false;

                //狀態
                String typeValue = "";
                String carnoValue = "";
                String depnoValue = "";
                String venderValue = "";
                String startValue = "";
                String endValue = "";
                String worknoValue = "";
                String repair1Value = "";
                String repair2Value = "";
                String repair3Value = "";
                String orgValue = "";
                String statusValue = "";
                String finishStartValue = "";
                String finishEndValue = "";
                String notify_itemValue = "";
                

                //有預設值，若有查詢過，則以新條件為準
                if (pb.isDoSearch())
                {
                    typeValue = form.getValue("notify_type");
                    carnoValue = form.getValue("car_no");
                    depnoValue = form.getValue("dep_no");
                    venderValue = form.getValue("repair_vender");
                    startValue = form.getValue("start_date");
                    endValue = form.getValue("end_date");
                    worknoValue = form.getValue("work_no");
                    repair1Value = form.getValue("repair_type1");
                    repair2Value = form.getValue("repair_type2");
                    repair3Value = form.getValue("repair_type3");
                    orgValue = form.getValue("crs_org");
                    statusValue = form.getValue("repair_status");
                    finishStartValue = form.getValue("finish_start");
                    finishEndValue = form.getValue("finish_end");
                    notify_itemValue = form.getValue("notify_item");
                }

                car_no.Text = carnoValue;
                dep_no.Text = depnoValue;
                repair_vender.Text = venderValue;
                start_date.Text = startValue;
                end_date.Text = endValue;
                work_no.Text = worknoValue;
                finish_start.Text = finishStartValue;
                finish_end.Text = finishEndValue;
                notify_item.Text = notify_itemValue;
              
                  
                

                    hTag.createMediatorCheckBox("WORK_TYPE", notify_type, typeValue, "", 0);
                hTag.createMediatorSelect("REPAIR_TYPE", repair_type1, repair1Value, "請選擇", 0);
                hTag.createMediatorSelect("REPAIR_TYPE_3", repair_type3, repair3Value, "請選擇", 0);
                hTag.createMediatorCheckBox("REPAIR_STS", repair_status, statusValue, "", 0);

                repair_type1_SelectedIndexChanged(sender, e);
                repair_type2_SelectedIndexChanged(sender, e);
                repair_type2.SelectedValue = repair2Value;
                if (repair_type3.Visible)
                    repair_type3.SelectedValue = repair3Value;

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
        //Mediator med = new Mediator();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //變更狀態欄顯示
            Mediator med = Mediator.getInstance(false);
            //String statusValue = drv["status"].ToString();
            //String statusText = med.lookupParamName("USE_STS", statusValue, 0);



            if (drv["notify_type"].ToString().Equals("C"))
            {
                e.Row.Cells[4].Text = med.lookupParamName("DEP_ORG", drv["keep_org"].ToString(), 0);
                e.Row.Cells[5].Text = med.lookupParamName("CAR_TYPE", drv["car_type"].ToString(), 0);
            }
            else
            {
                e.Row.Cells[4].Text = med.lookupParamName("DEP_ORG", drv["crs_org"].ToString(), 0);
                e.Row.Cells[5].Text = med.lookupParamName("MACHINE", drv["car_type"].ToString(), 0);
            }

            e.Row.Cells[7].Text = DateTransfer.c_date_intrans(drv["notify_date"].ToString());
            if (drv["finish_date"].ToString().Length > 0)
                e.Row.Cells[8].Text = DateTransfer.c_date_intrans(drv["finish_date"].ToString());
           
            e.Row.Cells[9].Text = drv["notify_item"].ToString().Replace("|", "；");

            //為報修方式_wenny
            String sRepairValue = "";
            if (drv["repair_type3"].ToString() != string.Empty)
            sRepairValue = med.lookupParamName("REPAIR_TYPE_3", drv["repair_type3"].ToString(), 0)+"-";
            String sRepairValue1 = "";

            sRepairValue1 = med.lookupParamName("REPAIR_TYPE", drv["repair_type1"].ToString(), 0);


            sRepairValue += sRepairValue1;

            string a = drv["repair_type2"].ToString();
            string[] a_result = a.Split(',');

            string b = "";

            for (int j = 0; j < a_result.Length; j++)
            {
                if (a_result[j] == "MAINTENANCE")
                {
                    a_result[j] = "保養";


                }
                if (a_result[j] == "MATERIAL")
                {
                    a_result[j] = "須換料";


                }
                if (a_result[j] == "REPAIR")
                {
                    a_result[j] = "維修";


                }
                if (a_result[j] == "TUNE")
                {
                    a_result[j] = "調校";


                }
                if (a_result[j] == "BOTHMR")
                {
                    a_result[j] = "保養,維修";


                }


                b += a_result[j] + ",";
               
            }
             b = b.TrimEnd(',');
            sRepairValue += "-" + b;
  

            e.Row.Cells[10].Text = sRepairValue;
            


            //Label lb = (Label)e.Row.FindControl("Label_h");
            //lb.Text = "1";
            //為報修狀態_wenny
            e.Row.Cells[11].Text = med.lookupParamName("REPAIR_STS", drv["repair_status"].ToString(), 0);
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSf001I1.aspx", "", this));
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

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1");
            Session["field"] = "browse1";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void dep_no_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1dep_no");
            Session["field"] = "browse1dep_no";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_no");
            Session["field"] = "browse1car_no";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void keep_org_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1keep_org");
            Session["field"] = "browse1keep_org";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_type");
            Session["field"] = "browse1car_type";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1work_no");
            Session["field"] = "browse1work_no";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1notify_date");
            Session["field"] = "browse1notify_date";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1finish_date");
            Session["field"] = "browse1finish_date";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void notify_item_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        
        try
        {
            dao.open();

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1notify_item");
            Session["field"] = "browse1notify_item";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void repair_type_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        
        try
        {
            dao.open();

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1repair_type_s");
            Session["field"] = "browse1repair_type_s";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void repair_status_s_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        
        try
        {
            dao.open();

            Form form = genFilter();         

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1repair_status_s");
            Session["field"] = "browse1repair_status_s";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1d");
            Session["field"] = "browse1d";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1dep_nod");
            Session["field"] = "browse1dep_nod";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_nod");
            Session["field"] = "browse1car_nod";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void keep_org_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1keep_orgd");
            Session["field"] = "browse1keep_orgd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_typed");
            Session["field"] = "browse1car_typed";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1work_nod");
            Session["field"] = "browse1work_nod";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1notify_dated");
            Session["field"] = "browse1notify_dated";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1finish_dated");
            Session["field"] = "browse1finish_dated";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void notify_item_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1notify_itemd");
            Session["field"] = "browse1notify_itemd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void repair_type_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1repair_type_sd");
            Session["field"] = "browse1repair_type_sd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    protected void repair_status_sd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = genFilter();

            NotifyModel model = new NotifyModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1repair_status_sd");
            Session["field"] = "browse1repair_status_sd";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
                pnlPrint.Visible = (userID.hasFunc("TDOSf001_print") && (ds.Tables[0].Rows.Count > 0));
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
    //wenny_text_排序
    /// <summary>
    /// 查詢條件
    /// </summary>
    /// <returns></returns>
    private Form genFilter()
    {
        Form form = new Form();
        UserID userID = (UserID)Session["UserID"];

        form.setValue("notify_type", HandleParam.getMultiValue(notify_type));
        form.setValue("car_no", car_no.Text.Trim());
        form.setValue("dep_no", dep_no.Text.Trim());
        form.setValue("repair_vender", repair_vender.Text.Trim());
        form.setValue("start_date", start_date.Text.Trim());
        form.setValue("end_date", end_date.Text.Trim());
        form.setValue("work_no", work_no.Text.Trim());
        form.setValue("repair_type1", repair_type1.SelectedValue);
        form.setValue("repair_type2", repair_type2.SelectedValue);
        form.setValue("repair_type3", repair_type3.SelectedValue);
        form.setValue("repair_status", HandleParam.getMultiValue(repair_status));
        form.setValue("finish_start", finish_start.Text.Trim());
        form.setValue("notify_item", notify_item.Text.Trim());
        form.setValue("finish_end", finish_end.Text.Trim());
        if (crs_org.SelectedValue == "")
        {
            form.setValue("crs_org", userID.getUserOrg()
         );

        }
        else
        {
            form.setValue("crs_org", HandleParam.getMultiValue(crs_org));


        }

        return form;
    }


    /// <summary>
    /// gvMain_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string notify_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("TDOSf001U1.aspx?notify_id=" + notify_id, "", this));
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

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string notify_id = "";

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            GridViewRow gvr = gvMain.Rows[i];

            CheckBox ckb = (CheckBox)gvr.FindControl("chkSelect");
            if (ckb.Checked == true)
            {
                notify_id += gvMain.DataKeys[i].Value.ToString() + ",";
            }
        }

        if (notify_id == string.Empty)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "onload",
                "<script>if(confirm('尚未勾選列印項目，是否列印空白表單？'))   location.href='TDOSf001P1.ashx?notify_id=" + notify_id + "';</script>");
        }
        else
            Response.Redirect("TDOSf001P1.ashx?notify_id=" + notify_id.Substring(0, notify_id.Length - 1));

    }

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

            Form form = genFilter();
            NotifyModel model = new NotifyModel();
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
            excel.CreateSheet("車輛報修作業");

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
            excel.SetColumnWidth(0, 80);          
            excel.CreateCell(styleTitleC, 1, "局編號");
            excel.SetColumnWidth(1, 100);
            excel.CreateCell(styleTitleC, 2, "車牌號碼");
            excel.SetColumnWidth(2, 100);
            excel.CreateCell(styleTitleC, 3, "保管單位");
            excel.SetColumnWidth(3, 110);
            excel.CreateCell(styleTitleC, 4, "車型/機具");
            excel.SetColumnWidth(4, 140);
            excel.CreateCell(styleTitleC, 5, "派工單號");
            excel.SetColumnWidth(5, 100);
            excel.CreateCell(styleTitleC, 6, "報修日期");
            excel.SetColumnWidth(6, 100);
            excel.CreateCell(styleTitleC, 7, "完工日期");
            excel.SetColumnWidth(7, 100);
            excel.CreateCell(styleTitleC, 8, "報修內容");
            excel.SetColumnWidth(8, 200);
            excel.CreateCell(styleTitleC, 9, "報修方式");
            excel.SetColumnWidth(9, 140);            
            excel.CreateCell(styleTitleC, 10, "報修狀態");
            excel.SetColumnWidth(10, 90);

            int rows = 0;
           
            //內容
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                rows++;
                excel.CreateRow(rows);
                excel.SetRowHeight(30);

                excel.CreateCell(styleContC, 0, (i + 1));                
                excel.CreateCell(styleContL, 1, ht["DEP_NO"].ToString());
                excel.CreateCell(styleContL, 2, ht["CAR_NO"].ToString());
                
                if (ht["NOTIFY_TYPE"].ToString().Equals("C"))
                {
                    excel.CreateCell(styleContL, 3, med.lookupParamName("DEP_ORG", ht["KEEP_ORG"].ToString(), 0));
                    excel.CreateCell(styleContL, 4, med.lookupParamName("CAR_TYPE", ht["CAR_TYPE"].ToString(), 0));
                }
                else
                { //2018/09/03單位改type改 DEP_ORG
                   // excel.CreateCell(styleContL, 3, med.lookupParamName("CRS_ORG", ht["CRS_ORG"].ToString(), 0));
                    excel.CreateCell(styleContL, 3, med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0));
                    //2018/09/03單位改type改 DEP_ORG
                    excel.CreateCell(styleContL, 4, med.lookupParamName("MACHINE", ht["CAR_TYPE"].ToString(), 0));
                }

                excel.CreateCell(styleContC, 5, ht["WORK_NO"].ToString());     
                excel.CreateCell(styleContC, 6, string.IsNullOrEmpty(ht["NOTIFY_DATE"].ToString())?"":DateTransfer.c_date_intrans(ht["NOTIFY_DATE"].ToString()));
                excel.CreateCell(styleContC, 7, string.IsNullOrEmpty(ht["FINISH_DATE"].ToString())?"":DateTransfer.c_date_intrans(ht["FINISH_DATE"].ToString()));
                excel.CreateCell(styleContL, 8, ht["NOTIFY_ITEM"].ToString().Replace("|", "；"));
                String sRepairValue = "";
                if (ht["REPAIR_TYPE3"].ToString() != string.Empty)
                    sRepairValue =  ht["REPAIR_TYPE3"].ToString()+ "-";
                String sRepairValue1 = "";

                sRepairValue1 = ht["REPAIR_TYPE1"].ToString();

            String   sRepairValue3=ht["REPAIR_TYPE3"].ToString();
               
                string a = ht["REPAIR_TYPE2"].ToString();
if (sRepairValue1  == "OUT")
                    {
                       sRepairValue1  = "委外";


                    }
       if (sRepairValue1  == "SELF")
                    {
                       sRepairValue1  = "自修";


                    }
 if (sRepairValue3== "IN")
                    {
                        sRepairValue3 = "合約內";


                    }
       if (sRepairValue3 == "OUT")
                    {
                       sRepairValue3 = "合約外";


                    }
                string[] a_result = a.Split(',');

                string b = "";

                for (int j = 0; j < a_result.Length; j++)
                {
                    if (a_result[j] == "MAINTENANCE")
                    {
                        a_result[j] = "保養";


                    }
                    if (a_result[j] == "MATERIAL")
                    {
                        a_result[j] = "須換料";


                    }
                    if (a_result[j] == "REPAIR")
                    {
                        a_result[j] = "維修";


                    }
                    if (a_result[j] == "TUNE")
                    {
                        a_result[j] = "調校";


                    }
                    if (a_result[j] == "BOTHMR")
                    {
                        a_result[j] = "保養,維修";


                    }


                    b += a_result[j] + ",";

                }
                b = b.TrimEnd(',');
                sRepairValue += "-" + b;
                String sRepairValue4=sRepairValue3+ "-" +b  + "-" +sRepairValue1; 
   if(sRepairValue3=="")
{
sRepairValue4=b  + "-" +sRepairValue1; 
}
                
                sRepairValue = med.lookupParamName("REPAIR_TYPE", ht["REPAIR_TYPE1"].ToString(), 0) + "-" +
                    med.lookupParamName("REPAIR_TYPE_" + ht["REPAIR_TYPE1"].ToString(), ht["REPAIR_TYPE2"].ToString(), 0) +
                    (string.IsNullOrEmpty(ht["REPAIR_TYPE3"].ToString())?"":"-" + med.lookupParamName("REPAIR_TYPE_3", ht["REPAIR_TYPE3"].ToString(), 0));    
                


                excel.CreateCell(styleContL, 9, sRepairValue4);
                excel.CreateCell(styleContC, 10, med.lookupParamName("REPAIR_STS", ht["REPAIR_STATUS"].ToString(), 0));
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
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("車輛報修作業.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + "\\\n" + ex.StackTrace);
        }
    }

   
}