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
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// 車輛基本資料：查詢頁
/// </summary>
public partial class TDOSc001_TDOSc001Q1 : System.Web.UI.Page
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
                case "MasterPage$ContentPlaceHolder1$btnQueryd":
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
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$card_no_s":
                    sortedfield.Value = "browse1card_no";
                    break; ;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$card_no_sd":
                    sortedfield.Value = "browse1card_nod";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_s":
                    sortedfield.Value = "browse1car_type";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_type_sd":
                    sortedfield.Value = "browse1car_typed";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$fuel_type_s":
                    sortedfield.Value = "browse1fuel_type";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$fuel_type_sd":
                    sortedfield.Value = "browse1fuel_typed";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$keep_org_s":
                    sortedfield.Value = "browse1keep_org";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$keep_org_sd":
                    sortedfield.Value = "browse1keep_orgd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$status_s":
                    sortedfield.Value = "browse1status";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$status_sd":
                    sortedfield.Value = "browse1statusd";
                    break;
                //新增廠牌及噸數欄位_wenny1061122
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$tonnage_s":
                    sortedfield.Value = "browse1Tonnage";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$tonnage_sd":
                    sortedfield.Value = "browse1TonnageD";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$brand_no_s":
                    sortedfield.Value = "browse1Brand_no";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$brand_no_sd":
                    sortedfield.Value = "browse1Brand_noD";
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
                    btnQuery.Visible = userID.hasFunc("TDOSc001_query") || userID.hasFunc("TDOSc001_update");
                    btnInsert.Visible = userID.hasFunc("TDOSc001_insert");
                    //1080513新增
                    btnExportAll.Visible = userID.hasFunc("TDOSc001_Allinsert");


                    string c = userID.getUserOrg();
                    string[] c_result = c.Split(',');

                    for (int j = 0; j < c_result.Length; j++)
                    {
                        string b = "";
                        if (c_result[j] == "TT002I591")
                        {
                            b = "士林區清潔隊";


                        }

                        if (c_result[j] == "TT002I592")
                        {
                            b = "大同區清潔隊";


                        }

                        if (c_result[j] == "TT002I593")
                        {
                            b = "大安區清潔隊";


                        }
                        if (c_result[j] == "TT002I594")
                        {
                            b = "中山區清潔隊";


                        }
                        if (c_result[j] == "TT002I595")
                        {
                            b = "中正區清潔隊";


                        }
                        if (c_result[j] == "TT002I598")
                        {
                            b = "公廁管理隊";
                        }
                        if (c_result[j] == "TT002I599")
                        {
                            b = "北投區清潔隊";
                        }
                        if (c_result[j] == "TT002I600")
                        {
                            b = "環境檢驗中心";
                        }

                        if (c_result[j] == "TT002I596")
                        {
                            b = "內湖區清潔隊";

                        }
                        if (c_result[j] == "TT002I597")
                        {
                            b = "文山區清潔隊";
                        }



                        if (c_result[j] == "TT002I601")
                        {
                            b = "松山區清潔隊";


                        }
                        if (c_result[j] == "TT002I602")
                        {
                            b = "直屬清潔隊";


                        }
                        if (c_result[j] == "TT002I603")
                        {
                            b = "信義區清潔隊";
                        }
                        if (c_result[j] == "TT002I604")
                        {
                            b = "南港區清潔隊";
                        }

                        if (c_result[j] == "TT002I605")
                        {
                            b = "政風室";
                        }
                        if (c_result[j] == "TT002I606")
                        {
                            b = "修車廠";
                        }

                        if (c_result[j] == "TT002I607")
                        {
                            b = "秘書室";
                        }
                        if (c_result[j] == "TT002I608")
                        {
                            b = "廢棄物處理場";
                        }

                        if (c_result[j] == "TT002I609")
                        {
                            b = "清山淨水";
                        }
                        if (c_result[j] == "TT002I610")
                        {
                            b = "空污噪音防制科";
                        }
                        if (c_result[j] == "TT002I611")
                        {
                            b = "水質病媒管制科";
                        }
                        if (c_result[j] == "TT002I612")
                        {
                            b = "溝渠一隊";
                        }
                        if (c_result[j] == "TT002I613")
                        {
                            b = "溝渠二隊";
                        }
                        if (c_result[j] == "TT002I614")
                        {
                            b = "萬華區清潔隊";
                        }
                        if (c_result[j] == "TT002I615")
                        {
                            b = "資源回收隊";
                        }
                        if (c_result[j] == "TT002I617")
                        {
                            b = "職業安全管理科";
                        }
                        if (c_result[j] == "TT002I619")
                        {
                            b = "氣候變遷管理科";
                        }
                        if (c_result[j] == "TT002I620")
                        {
                            b = "綜合企劃科";
                        }
                        if (c_result[j] == "TT002I621")
                        {
                            b = "環境清潔管理科";
                        }

                        if (c_result[j] == "TT002I622")
                        {
                            b = "廢棄物處理管理科";
                        }

                        if (c_result[j] == "TT002I623")
                        {
                            b = "資源循環管理科";
                        }










                        keep_org.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, c_result[j]));
                        keep_org.SelectedValue = userID.getUserOrg1();
                        if (userID.getUserRead() == "SELF")
                        {
                            keep_org.Enabled = false;

                        }


                    }
                }

                CarModel model = new CarModel();
                ParamModel paramModel = new ParamModel();

                model.dao = dao;
                paramModel.dao = dao;

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

                //狀態
                String typeValue = "";
                String orgValue = "";
                String fuelValue = "";
                String statusValue = "";
                String rsnValue = "";
                //有預設值，若有查詢過，則以新條件為準

                if (pb.isDoSearch())
                {
                    typeValue = form.getValue("car_type");
                    orgValue = form.getValue("keep_org");
                    fuelValue = form.getValue("fuel_type");
                    statusValue = form.getValue("status");
                    rsnValue = form.getValue("chg_rsn");
                }
                hTag.createMediatorCheckBox("CAR_TYPE", car_type, typeValue, "", 0);

               
              
            

            ArrayList alChgRsn = paramModel.selectCarStatusChgRsn();

                hTag.createMediatorCheckBox("FUEL_TYPE", fuel_type, fuelValue, "", 0);
                //hTag.createMediatorCheckBox("USE_STS", status, statusValue, "", 0);
                hTag.createCheckBox(alChgRsn, chg_rsn, rsnValue, 0);

                if (__EVENTTARGET.Equals("ChangePaging"))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script>chgHash('pb'); </script>");
                }
            }


            foreach (System.Web.UI.WebControls.ListItem li in status.Items)
            {
                if (li.Value.Equals("C"))
                    li.Attributes.Add("onclick", "onCloseStatusChecked(this.checked);");
            }

            Boolean flag = HandleParam.getMultiValue(status).Contains("C");

            this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>onCloseStatusChecked(" + flag.ToString().ToLower() + ");</script>");



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
            Mediator med = Mediator.getInstance(false);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //變更車輛種類欄顯示            
            String typeValue = drv["car_type"].ToString();
            String typeText = med.lookupParamName("CAR_TYPE", typeValue, 0);
            //////新增廠牌及噸數欄位_wenny1061122
            //String brandValue = drv["brand_no"].ToString();
            //String brandText = med.lookupParamName("BRAND_NO", brandValue, 0);
            //e.Row.Cells[5].Text = brandValue;
            ////e.Row.Cells[5].Text=med.lookupParamName("BRAND_NO",drv["brand_no"].ToString(),0);
            //e.Row.Cells[6].Text = med.lookupParamName("TONNAGE", drv["tonnage"].ToString(), 0); ;
            //wenny_修正欄位
            e.Row.Cells[7].Text = med.lookupParamName("FUEL_TYPE", drv["fuel_type"].ToString(), 0);
            e.Row.Cells[8].Text = med.lookupParamName("DEP_ORG", drv["keep_org"].ToString(), 0);
            e.Row.Cells[4].Text = typeText;
            //wenny_修正欄位
            //原程式碼欄位與標題錯開_wenny1061122
            //e.Row.Cells[4].Text = med.lookupParamName("FUEL_TYPE", drv["fuel_type"].ToString(), 0); ;
            //e.Row.Cells[5].Text = med.lookupParamName("DEP_ORG", drv["keep_org"].ToString(), 0); ;
            //e.Row.Cells[6].Text = typeText;
            //原程式碼欄位與標題錯開_wenny1061122
            //變更狀態欄顯示            
            String statusValue = drv["status"].ToString();
            String statusText = med.lookupParamName("USE_STS", statusValue, 0);
            //新增廠牌及噸數後修正欄位對應_wenny1061122
            e.Row.Cells[9].Text = statusText;
            //e.Row.Cells[7].Text = statusText;
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSc001I1.aspx", "", this));
    }


    /// <summary>
    /// 查詢按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {




            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));

            if (keep_org.SelectedValue=="")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
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
    //新增廠牌欄位正排序_wenny1061122
    protected void brand_no_s_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1Brand_no");
            Session["field"] = "browse1Brand_no";
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
    //新增噸數欄位正排序_wenny1061122
    protected void tonnage_s_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1Tonnage");
            Session["field"] = "browse1Tonnage";
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

    protected void dep_no_s_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1dep_no");
            Session["field"] = "browse1dep_no";
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
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_no");
            Session["field"] = "browse1car_no";
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
    protected void card_no_s_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1card_no");
            Session["field"] = "browse1card_no";
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
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
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
    protected void fuel_type_s_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1fuel_type");
            Session["field"] = "browse1fuel_type";
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
    protected void keep_org_s_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1keep_org");
            Session["field"] = "browse1keep_org";
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
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1status");
            Session["field"] = "browse1status";
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
    //新增廠牌欄位反排序_wenny1061122
    protected void brand_no_sd_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1Brand_noD");
            Session["field"] = "browse1Brand_noD";
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
    //新增噸數欄位反排序_wenny1061122
    protected void tonnage_sd_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1TonnageD");
            Session["field"] = "browse1TonnageD";
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

    protected void btnQueryd_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
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
    protected void dep_no_sd_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1dep_nod");
            Session["field"] = "browse1dep_nod";
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
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1car_nod");
            Session["field"] = "browse1car_nod";
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
    protected void card_no_sd_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1card_nod");
            Session["field"] = "browse1card_nod";
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
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
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
    protected void fuel_type_sd_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1fuel_typed");
            Session["field"] = "browse1fuel_typed";
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
    protected void keep_org_sd_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1keep_orgd");
            Session["field"] = "browse1keep_orgd";
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
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1statusd");
            Session["field"] = "browse1statusd";
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
        string car_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("TDOSc001U1.aspx?car_id=" + car_id, "", this));
    }

    #region//匯出EXCEL_wenny1061128
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
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
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
            excel.CreateSheet("車輛基本資料");

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
            excel.CreateCell(styleTitleC, 3, "車隊卡號");
            excel.SetColumnWidth(3, 110);
            excel.CreateCell(styleTitleC, 4, "車輛種類");
            excel.SetColumnWidth(4, 140);
            excel.CreateCell(styleTitleC, 5, "廠牌");
            excel.SetColumnWidth(5, 100);
            excel.CreateCell(styleTitleC, 6, "噸數");
            excel.SetColumnWidth(6, 100);
            excel.CreateCell(styleTitleC, 7, "油品");
            excel.SetColumnWidth(7, 100);
            excel.CreateCell(styleTitleC, 8, "保管單位");
            excel.SetColumnWidth(8, 200);
            excel.CreateCell(styleTitleC, 9, "狀態");
            excel.SetColumnWidth(9, 140);
            //excel.CreateCell(styleTitleC, 10, "報修狀態");
            //excel.SetColumnWidth(10, 90);

            int rows = 0;
            //, dep_no,car_no,card_no,carType,brand_no ,tonnage ,fuelType,keepOrg,useStatus
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
                excel.CreateCell(styleContL, 3, ht["CARD_NO"].ToString());
                excel.CreateCell(styleContL, 4, med.lookupParamName("CAR_TYPE", ht["CAR_TYPE"].ToString(), 0));
                excel.CreateCell(styleContL, 5, ht["BRAND_NO"].ToString());
                excel.CreateCell(styleContL, 6, ht["TONNAGE"].ToString());
                excel.CreateCell(styleContL, 7, med.lookupParamName("FUEL_TYPE", ht["FUEL_TYPE"].ToString(), 0));
                excel.CreateCell(styleContL, 8, med.lookupParamName("DEP_ORG", ht["KEEP_ORG"].ToString(), 0));
                excel.CreateCell(styleContL, 9, med.lookupParamName("USE_STS", ht["STATUS"].ToString(), 0));
                //if (ht["NOTIFY_TYPE"].ToString().Equals("C"))
                //{
                //    excel.CreateCell(styleContL, 3, med.lookupParamName("DEP_ORG", ht["KEEP_ORG"].ToString(), 0));
                //    excel.CreateCell(styleContL, 4, med.lookupParamName("CAR_TYPE", ht["CAR_TYPE"].ToString(), 0));
                //}
                //else
                //{
                //    excel.CreateCell(styleContL, 3, med.lookupParamName("CRS_ORG", ht["CRS_ORG"].ToString(), 0));
                //    excel.CreateCell(styleContL, 4, med.lookupParamName("MACHINE", ht["CAR_TYPE"].ToString(), 0));
                //}

                //excel.CreateCell(styleContC, 5, ht["brand_no"].ToString());
                //excel.CreateCell(styleContC, 6, string.IsNullOrEmpty(ht["NOTIFY_DATE"].ToString()) ? "" : DateTransfer.c_date_intrans(ht["NOTIFY_DATE"].ToString()));
                //excel.CreateCell(styleContC, 7, string.IsNullOrEmpty(ht["FINISH_DATE"].ToString()) ? "" : DateTransfer.c_date_intrans(ht["FINISH_DATE"].ToString()));
                //excel.CreateCell(styleContL, 8, ht["NOTIFY_ITEM"].ToString().Replace("|", "；"));
                //String sRepairValue = "";
                //sRepairValue = med.lookupParamName("REPAIR_TYPE", ht["REPAIR_TYPE1"].ToString(), 0) + "-" +
                //    med.lookupParamName("REPAIR_TYPE_" + ht["REPAIR_TYPE1"].ToString(), ht["REPAIR_TYPE2"].ToString(), 0) +
                //    (string.IsNullOrEmpty(ht["REPAIR_TYPE3"].ToString()) ? "" : "-" + med.lookupParamName("REPAIR_TYPE_3", ht["REPAIR_TYPE3"].ToString(), 0));
                //excel.CreateCell(styleContL, 9, sRepairValue);
                //excel.CreateCell(styleContC, 10, med.lookupParamName("REPAIR_STS", ht["REPAIR_STATUS"].ToString(), 0));
            }

            //設定列印配置
            excel.SetPagesize(9);     //A4
            excel.SetLandscape(true);//橫印             
            excel.setScale(100);      //設定縮放 %
            excel.SetMargin(1, 1, 0.5, 1);  //設定邊寬
            excel.SetFooterMargin(0.5);
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 0);

            //        //輸出檔案
            //SysMsg.AlertMessage(this.Page, "a");
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("車輛基本資料.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + "\\\n" + ex.StackTrace);
        }
    }

    #endregion





    //1080513新增
    protected void btnExportAll_Click(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {



            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg().Substring(0, userID.getUserOrg().LastIndexOf(",")));

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("status", HandleParam.getMultiValue(status));
            if (form.getValue("status").Contains("C"))
                form.setValue("chg_rsn", HandleParam.getMultiValue(chg_rsn));
            else
                form.setValue("chg_rsn", "");
            form.setValue("user_sys", userID.getUserSys());
            CarModel model = new CarModel();
            model.dao = dao;
            ArrayList al = model.export(form);

            genExcelAll(al);

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

    private void genExcelAll(ArrayList al)
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
            excel.CreateSheet("車輛基本資料");

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
            excel.CreateCell(styleTitleC, 3, "車隊卡號");
            excel.SetColumnWidth(3, 110);
            excel.CreateCell(styleTitleC, 4, "車輛種類");
            excel.SetColumnWidth(4, 140);
            //buy_date購置日期

            excel.CreateCell(styleTitleC, 5, "購置日期");
            excel.SetColumnWidth(5, 100);

            excel.CreateCell(styleTitleC, 6, "廠牌");
            excel.SetColumnWidth(6, 100);

            excel.CreateCell(styleTitleC, 7, "引擎號碼");
            excel.SetColumnWidth(7, 100);
            //engine_no引擎號碼




            excel.CreateCell(styleTitleC, 8, "噸數");
            excel.SetColumnWidth(8, 100);
            excel.CreateCell(styleTitleC, 9, "油品");
            excel.SetColumnWidth(9, 100);
            excel.CreateCell(styleTitleC, 10, "保管單位");
            excel.SetColumnWidth(10, 200);

            excel.CreateCell(styleTitleC, 11, "年份");
            excel.SetColumnWidth(11, 100);
            excel.CreateCell(styleTitleC, 12, "排氣量");
            excel.SetColumnWidth(12, 100);
            excel.CreateCell(styleTitleC, 13, "油耗量標準值");
            excel.SetColumnWidth(13, 120);



            excel.CreateCell(styleTitleC, 14, "發照日期");

            excel.SetColumnWidth(14, 100);
            excel.CreateCell(styleTitleC, 15, "下次定檢日");
            excel.SetColumnWidth(15, 120);
            excel.CreateCell(styleTitleC, 16, "狀態");
            excel.SetColumnWidth(16, 140);
            excel.CreateCell(styleTitleC, 17, "備註");
            excel.SetColumnWidth(17, 240);



            int rows = 0;
            //, dep_no,car_no,card_no,carType,brand_no ,tonnage ,fuelType,keepOrg,useStatus
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
                excel.CreateCell(styleContL, 3, ht["CARD_NO"].ToString());
                excel.CreateCell(styleContL, 4, med.lookupParamName("CAR_TYPE", ht["CAR_TYPE"].ToString(), 0));
                excel.CreateCell(styleContL, 5, ht["BUY_DATE"].ToString());
                excel.CreateCell(styleContL, 6, ht["BRAND_NO"].ToString());
                excel.CreateCell(styleContL, 7, ht["ENGINE_NO"].ToString());
                excel.CreateCell(styleContL, 8, ht["TONNAGE"].ToString());
                excel.CreateCell(styleContL, 9, med.lookupParamName("FUEL_TYPE", ht["FUEL_TYPE"].ToString(), 0));
                excel.CreateCell(styleContL, 10, med.lookupParamName("DEP_ORG", ht["KEEP_ORG"].ToString(), 0));
                excel.CreateCell(styleContL, 11, ht["CAR_YEAR"].ToString());
                excel.CreateCell(styleContL, 12, ht["DISPLACEMENT"].ToString());
                excel.CreateCell(styleContL, 13, ht["FUEL_STD"].ToString());
                excel.CreateCell(styleContL, 14, ht["LICENSING_DATE"].ToString());
                excel.CreateCell(styleContL, 15, ht["NEXT_INSPECTION"].ToString());
                excel.CreateCell(styleContL, 16, med.lookupParamName("USE_STS", ht["STATUS"].ToString(), 0));
                excel.CreateCell(styleContL, 17, ht["MEMO"].ToString());


                //if (ht["NOTIFY_TYPE"].ToString().Equals("C"))
                //{
                //    excel.CreateCell(styleContL, 3, med.lookupParamName("DEP_ORG", ht["KEEP_ORG"].ToString(), 0));
                //    excel.CreateCell(styleContL, 4, med.lookupParamName("CAR_TYPE", ht["CAR_TYPE"].ToString(), 0));
                //}
                //else
                //{
                //    excel.CreateCell(styleContL, 3, med.lookupParamName("CRS_ORG", ht["CRS_ORG"].ToString(), 0));
                //    excel.CreateCell(styleContL, 4, med.lookupParamName("MACHINE", ht["CAR_TYPE"].ToString(), 0));
                //}

                //excel.CreateCell(styleContC, 5, ht["brand_no"].ToString());
                //excel.CreateCell(styleContC, 6, string.IsNullOrEmpty(ht["NOTIFY_DATE"].ToString()) ? "" : DateTransfer.c_date_intrans(ht["NOTIFY_DATE"].ToString()));
                //excel.CreateCell(styleContC, 7, string.IsNullOrEmpty(ht["FINISH_DATE"].ToString()) ? "" : DateTransfer.c_date_intrans(ht["FINISH_DATE"].ToString()));
                //excel.CreateCell(styleContL, 8, ht["NOTIFY_ITEM"].ToString().Replace("|", "；"));
                //String sRepairValue = "";
                //sRepairValue = med.lookupParamName("REPAIR_TYPE", ht["REPAIR_TYPE1"].ToString(), 0) + "-" +
                //    med.lookupParamName("REPAIR_TYPE_" + ht["REPAIR_TYPE1"].ToString(), ht["REPAIR_TYPE2"].ToString(), 0) +
                //    (string.IsNullOrEmpty(ht["REPAIR_TYPE3"].ToString()) ? "" : "-" + med.lookupParamName("REPAIR_TYPE_3", ht["REPAIR_TYPE3"].ToString(), 0));
                //excel.CreateCell(styleContL, 9, sRepairValue);
                //excel.CreateCell(styleContC, 10, med.lookupParamName("REPAIR_STS", ht["REPAIR_STATUS"].ToString(), 0));
            }

            //設定列印配置
            excel.SetPagesize(9);     //A4
            excel.SetLandscape(true);//橫印             
            excel.setScale(100);      //設定縮放 %
            excel.SetMargin(1, 1, 0.5, 1);  //設定邊寬
            excel.SetFooterMargin(0.5);
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 0);

            //        //輸出檔案
            //SysMsg.AlertMessage(this.Page, "a");
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("車輛基本資料(全部).xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + "\\\n" + ex.StackTrace);
        }
    }
}


