using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油卡資料：查詢頁
/// </summary>
public partial class TDOSc004_TDOSc004Q1 : System.Web.UI.Page
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
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$card_type_s":
                    sortedfield.Value = "browse1_card_type";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$card_type_sd":
                    sortedfield.Value = "browse1_card_typed";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_no_s":
                    sortedfield.Value = "browse1_car_no_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$car_no_sd":
                    sortedfield.Value = "browse1_car_no_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$keep_org_s":
                    sortedfield.Value = "browse1_keep_org_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$keep_org_sd":
                    sortedfield.Value = "browse1_keep_org_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$fuel_type_s":
                    sortedfield.Value = "browse1_fuel_type_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$fuel_type_sd":
                    sortedfield.Value = "browse1_fuel_type_sd";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$statuse_s":
                    sortedfield.Value = "browse1_status_s";
                    break;
                case "MasterPage$ContentPlaceHolder1$gvMain$ctl01$status_sd":
                    sortedfield.Value = "browse1_status_sd";
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
                    btnQuery.Visible = userID.hasFunc("TDOSc004_query") || userID.hasFunc("TDOSc004_update");
                    btnInsert.Visible = userID.hasFunc("TDOSc004_insert");
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










                        keep_org.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                    }
                    keep_org.SelectedValue = userID.getUserOrg1();
                    if (userID.getUserRead() == "SELF")
                    {
                        keep_org.Enabled = false;

                    }

                }

                CardModel model = new CardModel();
                model.dao = dao;

                //分頁設定
                //查詢資料
                Form form = new Form();
                PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
                pb.setDBDAO(dao);
                if (string.IsNullOrEmpty(sortedfield.Value))
                {
                    sortedfield.Value = Session["field"].ToString();//查詢排序編輯後返回頁面
                }
                DataSet ds = pb.doSearch(model, sortedfield.Value);
                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                }

                card_no.Text = form.getValue("card_no");               

                //狀態
                String typeValue = "";
                String orgValue = "";
                String statusValue = "";
                String fuelValue = "";
                //有預設值，若有查詢過，則以新條件為準

                if (pb.isDoSearch())
                {
                    typeValue = form.getValue("card_type");
                    orgValue = form.getValue("keep_org");
                    statusValue = form.getValue("status");
                    fuelValue = form.getValue("fuel_type");
                }

                ArrayList al_CardType = model.selectCardTypeByWorkType("");
                hTag.createCheckBox(al_CardType, card_type, typeValue, 0);
                //hTag.createMediatorCheckBox("CARD_TYPE", card_type, typeValue, "", 0);
                //hTag.createMediatorCheckBox("DEP_ORG", keep_org, orgValue, "", 0);
                hTag.createMediatorCheckBox("FUEL_TYPE", fuel_type, fuelValue, 0);
                hTag.createMediatorCheckBox("USE_STS", status, statusValue, 0);

              

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
            
            e.Row.Cells[1].Text = med.lookupParamName("CARD_TYPE", drv["card_type"].ToString(), 0);
            e.Row.Cells[3].Text = med.lookupParamName("DEP_ORG", drv["keep_org"].ToString(), 0);
            e.Row.Cells[4].Text = med.lookupParamName("FUEL_TYPE", drv["fuel_type"].ToString(), 0);
            e.Row.Cells[5].Text = med.lookupParamName("USE_STS", drv["status"].ToString(), 0);
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSc004I1.aspx", "", this));
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
            form.setValue("card_no", card_no.Text.Trim());            
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));

            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1");
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
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
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
    protected void btnQuerycard_type_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();
            UserID userID = (UserID)Session["UserID"];

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_card_type");
            Session["field"] = "browse1_card_type";
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
    protected void btnQuerydcard_typed_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_card_typed");
            Session["field"] = "browse1_card_typed";
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
    protected void btnQuerycard_no_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_card_no");
            Session["field"] = "browse1_card_no";
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
    protected void btnQuerydcard_nod_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];

        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_card_nod");
            Session["field"] = "browse1_card_nod";
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
    protected void btnQuerykeep_org_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_keep_org");
            Session["field"] = "browse1_keep_org";
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
    protected void btnQuerykeep_orgd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_keep_orgd");
            Session["field"] = "browse1_keep_orgd";
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
    protected void btnQueryfuel_type_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_fuel_type");
            Session["field"] = "browse1_fuel_type";
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
    protected void btnQueryfuel_typed_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_fuel_typed");
            Session["field"] = "browse1_fuel_typed";
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
    protected void btnQuerystatus_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_status");
            Session["field"] = "browse1_status";
         
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
    protected void btnQuerystatusd_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("card_no", card_no.Text.Trim());
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("status", HandleParam.getMultiValue(status));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            CardModel model = new CardModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse1_statusd");
            Session["field"] = "browse1_statusd";
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
    /// <summary>
    /// gvMain_RowEditing事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string card_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("TDOSc004U1.aspx?card_id=" + card_id, "", this));
    }






}