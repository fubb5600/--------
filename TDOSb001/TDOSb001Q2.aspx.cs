using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class TDOSb001_TDOSb001Q2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
        if (gvMain.Rows.Count == 0)
            pnlAdt.Visible = false;



        try
        {
            dao.open();

            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限
                    btnAdt.Visible = userID.hasFunc("TDOSb001_audit");

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

                //CPCModel model = new CPCModel();
                //model.dao = dao;

                ////分頁設定
                ////查詢資料
                //Form form = new Form();
                //DataSet ds = model.browse3(form);

                String sourceValue = "CPC";
                String orgValue = "";
                String cardValue = "";                

               // hTag.createMediatorCheckBox("DATA_SOURCE", data_source, sourceValue, 0);
                hTag.createMediatorRadio("DATA_SOURCE", data_source, sourceValue, 0);               
                hTag.createMediatorSelect("CARD_TYPE", card_type, cardValue, "請選擇", 0);

                #region 保管單位下拉選單
               
                #endregion

                //車隊卡號
                genCardIdSelect();

                //if (__EVENTTARGET.Equals("ChangePaging"))
                //{
                //    this.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script>chgHash('pb'); </script>");
                //}

                data_source_SelectedIndexChanged(sender, e);
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
    /// 管理單位連動加油卡卡號下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
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
    /// 加油卡卡別連動加油卡卡號下拉式選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void card_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect();
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        String rowID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            rowID = "row" + e.Row.RowIndex;

            //移動變色
            //e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            //e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            e.Row.Attributes.Add("id", rowID);
            CheckBox cbSelected = (CheckBox)e.Row.Cells[13].FindControl("cbAdt");
            // cbSelected.Attributes.Add("onclick", "colorselected(" + "'" + rowID + "', this" + ")");
            cbSelected.Attributes.Add("onclick", "colorSeleted2()");
            //確認 / 審核欄顯示
            Mediator med = new Mediator();
            if (drv["data_source"].ToString() == "CPC")
            {
                e.Row.Cells[11].Text = med.lookupParamName("CFM_STS", drv["cfm_status"].ToString(), 0);
            }
            else
            {
                e.Row.Cells[11].Text = med.lookupParamName("ADT_STS", drv["adt_status"].ToString(), 0);
            }

            if (drv["card_type"].ToString() == "1")
            {
                TextBox tb = (TextBox)e.Row.Cells[12].FindControl("tbCardNo");
                tb.Enabled = false;
            }



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
    /// 返回按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSb001Q1.aspx", "", this));
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
        if (gvMain.Rows.Count == 0)
            pnlAdt.Visible = false;
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("data_source", HandleParam.getMultiValue(data_source));
            form.setValue("cfm_status", "0");
            form.setValue("adt_status", "0");
            form.setValue("deal_start", deal_start.Text.Trim());
            form.setValue("deal_end", deal_end.Text.Trim());
            form.setValue("card_type", card_type.SelectedValue);
            form.setValue("card_id", card_id.SelectedValue);
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("keep_org", mng_id.SelectedValue);
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("user_read", userID.getUserRead());
            if (mng_id.SelectedValue == "")
            {
                form.setValue("mng_id", userID.getUserOrg());

            }
            else
            {
                form.setValue("mng_id", HandleParam.getMultiValue(mng_id));


            }

            CPCModel model = new CPCModel();
            model.dao = dao;
            DataSet ds = model.browse3(form);

            gvMain.DataSource = ds;
            gvMain.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                pnlAdt.Visible = true;
                if (deal_start.Text.Substring(0, 6).Equals(deal_end.Text.Substring(0, 6)))               
                    tbReportYM.Text = deal_start.Text.Substring(0, 6);                
                else
                    tbReportYM.Text = "";

            }
            else
                tbReportYM.Text = "";


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


    protected void btnAdt_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        String fuel_id = string.Empty;
        String oil_id = string.Empty;
        int count = 0;
        try
        {
            if (!checkAll())
            {
                return;
            }
            dao.open();
            dao.beginTransaction();

            CPCModel model = new CPCModel();
            model.dao = dao;

            for (int i = 0; i < gvMain.Rows.Count; i++)
            {
                if (((CheckBox)gvMain.Rows[i].FindControl("cbAdt")).Checked)
                {
                    String carNo = ((TextBox)gvMain.Rows[i].FindControl("tbCardNo")).Text;

                    if (carNo != string.Empty)
                    {

                        Form form = new Form();
                        form.setValue("id", gvMain.DataKeys[i].Values[0].ToString());
                        form.setValue("report_ym", tbReportYM.Text.Trim());
                        form.setValue("car_no", carNo);
                        form.setValue("update_user", userID.getUserID());
                        form.setValue("status", adt_status.SelectedValue);
                        form.setValue("desc", adt_desc.Text.Trim());
                        form.setValue("data_source", gvMain.DataKeys[i].Values[1].ToString());

                        model.auditBatchwithCarNo(form);
                    }
                    else
                    {

                        if (gvMain.DataKeys[i].Values[1].ToString() == "CPC")
                        {
                            fuel_id += gvMain.DataKeys[i].Values[0].ToString() +  Mediator.splitTag;
                        }
                        else if (gvMain.DataKeys[i].Values[1].ToString() == "DEP")
                        {
                            oil_id += gvMain.DataKeys[i].Values[0].ToString() + Mediator.splitTag;
                        }
                    }
                    count++;
                }
            }

            if (fuel_id.Length > 0)
                fuel_id = fuel_id.Substring(0, fuel_id.Length - 1);
            if (oil_id.Length > 0)
                oil_id = oil_id.Substring(0, oil_id.Length - 1);

            Form formBatch = new Form();
            formBatch.setValue("report_ym", tbReportYM.Text.Trim());
            formBatch.setValue("update_user", userID.getUserID());
            formBatch.setValue("status", adt_status.SelectedValue);
            formBatch.setValue("desc", adt_desc.Text.Trim());
            formBatch.setValue("fuel_id", fuel_id);
            formBatch.setValue("oil_id", oil_id);

            if (data_source.SelectedValue == "CPC")
            {
                model.confirmCPCBatch(formBatch);
            }
            else
            {
                model.auditDEPBatch(formBatch);
            }
            
            

            dao.commit();
            SysMsg.AlertMessage(this.Page, "審核" + count + "筆資料成功！");

            btnQuery_Click(sender, e);
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


    private Boolean checkAll()
    {
        UserID userID = (UserID)Session["UserID"];
        Boolean flag = true;
        TDOS tdos = new TDOS();

        if (tbReportYM.Text == string.Empty)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請輸入報表年月！");
        }



        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (((CheckBox)gvMain.Rows[i].FindControl("cbAdt")).Checked)
            {
                String dealDate = gvMain.DataKeys[i].Values[2].ToString();
                //檢核交易日期是否已鎖定
                flag = tdos.IsKeyDateLock(dealDate, userID.getUserID(), "TDOSb001");
                if (flag == false)
                {
                    SysMsg.AlertMessage(this.Page, "第" + (i + 1) + "筆已鎖定的交易日期不可修改資料，請聯繫管理者！");
                    break;
                }

            }
        }

        return flag;
    }

    /// <summary>
    /// 驗證年月格式
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void YMValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(args.Value + "/01"));
            args.IsValid = true;
        }
        catch
        {
            args.IsValid = false;
        }
    }


    protected void data_source_SelectedIndexChanged(object sender, EventArgs e)
    {
        HtmlTag hTag = new HtmlTag();
       // Mediator med = new Mediator();

        if (data_source.SelectedValue == "CPC")
        {
            hTag.createMediatorRadio("CFM_STS", adt_status, "0", 0); 
        }
        else
        {
            hTag.createMediatorRadio("ADT_STS", adt_status, "0", 0);
        }
    }
}