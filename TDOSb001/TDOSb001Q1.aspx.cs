using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油資料管理：查詢頁
/// </summary>
public partial class TDOSb001_TDOSb001Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
        try
        {
            dao.open();

            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限
                    btnQuery.Visible = userID.hasFunc("TDOSb001_query") || userID.hasFunc("TDOSb001_update");
                    ListItem li = new ListItem();
                    li.Value = userID.getUserOrg();
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










                        mng_id.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                    }
                    mng_id.Items.Insert(0, new System.Web.UI.WebControls.ListItem("請選擇", ""));
                    mng_id.SelectedValue = userID.getUserOrg1();
                    if (userID.getUserRead() == "SELF")
                    {
                        mng_id.Enabled = false;

                    }

                }

                CPCModel model = new CPCModel();
                model.dao = dao;
                //2019/07/29
                report_y.Items.Insert(0, new ListItem("請選擇", ""));

                int year = int.Parse(DateTime.Now.ToString("yyyy")) - 1911;
                for (int i = 0; i <= 10; i++)
                {
                    report_y.Items.Add(new ListItem((year - i).ToString(), (year - i).ToString()));


                }
                report_m.Items.Insert(0, new ListItem("請選擇", ""));

                for (int i = 0; i < 9; i++)
                {
                    report_m.Items.Add(new ListItem(0+(i + 1).ToString()));


                }

                for (int i = 9; i < 12; i++)
                {
                    report_m.Items.Add(new ListItem((i + 1).ToString()));


                }

                //分頁設定
                //查詢資料
                Form form = new Form();
                PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
                pb.setDBDAO(dao);
                DataSet ds = pb.doSearch(model, "browse2");

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                }

                //car_no.Text = form.getValue("car_no");
                dep_no.Text = form.getValue("dep_no");
                report_y.Text = form.getValue("report_y");
                report_m.Text = form.getValue("report_m");
                deal_start.Text = form.getValue("deal_start");
                deal_end.Text = form.getValue("deal_end");
                stand_name.Text = form.getValue("stand_name");
                import_id.Text = form.getValue("import_id");
                import_start.Text = form.getValue("import_start");
                import_end.Text = form.getValue("import_end");

                String orgValue = "";
                String fuelValue = "";
                String typeValue = "";
                String cardValue = "";
                String sourceValue = "";
                String cfmValue = "";
                String adtValue = "";
                
                //有預設值，若有查詢過，則以新條件為準

                if (pb.isDoSearch())
                {
                    orgValue = form.getValue("mng_id");
                    fuelValue = form.getValue("fuel_type");
                    typeValue = form.getValue("card_type");
                    cardValue = form.getValue("card_id");
                    sourceValue = form.getValue("data_source");
                    cfmValue = form.getValue("cfm_status");
                    adtValue = form.getValue("adt_status");
                }

                hTag.createMediatorCheckBox("FUEL_TYPE", fuel_type, fuelValue, "", 0);
                hTag.createMediatorSelect("CARD_TYPE", card_type, typeValue, "請選擇", 0);
                hTag.createMediatorCheckBox("DATA_SOURCE", data_source, sourceValue, 0);
                hTag.createMediatorCheckBox("CFM_STS", cfm_status, cfmValue, 0);
                hTag.createMediatorCheckBox("ADT_STS", adt_status, adtValue, 0);

                #region 管理單位下拉選單
              
      



                #endregion

                #region 加油卡卡號
                CardModel card_model = new CardModel();
                card_model.dao = dao;
                ArrayList al = card_model.selectCardNo1(form);
                hTag.createSelect(al, card_id, cardValue, "請選擇", 0);
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

            //確認 / 審核欄顯示
            Mediator med = new Mediator();
            if (drv["data_source"].ToString() == "CPC")
            {
                e.Row.Cells[10].Text = med.lookupParamName("CFM_STS", drv["cfm_status"].ToString(), 0);
            }
            else
            {
                e.Row.Cells[10].Text = med.lookupParamName("ADT_STS", drv["adt_status"].ToString(), 0);
            }
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSb001I2.aspx", "", this));
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
            form.setValue("data_source", HandleParam.getMultiValue(data_source));
            form.setValue("cfm_status", HandleParam.getMultiValue(cfm_status));
            form.setValue("adt_status", HandleParam.getMultiValue(adt_status));
            form.setValue("report_y", report_y.SelectedValue);
            form.setValue("report_m", report_m.SelectedValue);
            form.setValue("deal_start", deal_start.Text.Trim());
            form.setValue("deal_end", deal_end.Text.Trim());
            form.setValue("stand_name", stand_name.Text.Trim());
            form.setValue("import_id", import_id.Text.Trim());
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            form.setValue("card_type", card_type.SelectedValue);
            form.setValue("card_id", card_id.SelectedValue);
            form.setValue("dep_no", dep_no.Text.Trim());            
            if(mng_id.SelectedValue=="")
            {
                form.setValue("mng_id", userID.getUserOrg());

            }
            else
            {
                form.setValue("mng_id", mng_id.SelectedValue);


            }
            form.setValue("keep_org", mng_id.SelectedValue);
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("user_read", userID.getUserRead());

            CPCModel model = new CPCModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2");
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
    /// gvMain_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string fuel_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        string data_source = gvMain.DataKeys[e.NewEditIndex].Values[1].ToString().Trim();
        if (data_source == "CPC")
        {
            Response.Redirect(Forward.Redirect("TDOSb001U1.aspx?fuel_id=" + fuel_id, "", this));
        }
        else
        {
            Response.Redirect(Forward.Redirect("TDOSb001U2.aspx?oil_id=" + fuel_id, "", this));
        }
    }


    /// <summary>
    /// 加油卡卡別連動加油卡卡號下拉式選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void card_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect();
    }


    /// <summary>
    /// 產生加油卡卡號的下拉式選單
    /// </summary>
    private void genCardIdSelect()
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            Form form = new Form();
            form.setValue("user_read", userID.getUserRead());
            form.setValue("user_org", userID.getUserOrg());
            form.setValue("keep_org", mng_id.SelectedValue);
            form.setValue("card_type", card_type.SelectedValue);
            CardModel card_model = new CardModel();
            card_model.dao = dao;
            ArrayList al = card_model.selectCardNo1(form);
            hTag.createSelect(al, card_id, form.getValue("card_no"), "請選擇", 0);
        }
        catch { }
        finally
        { dao.close(); }
    }


    /// <summary>
    /// 管理單位連動加油卡卡號下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect();
    }

    /// <summary>
    /// 批次審核按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchAudit_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSb001Q2.aspx", "", this));
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