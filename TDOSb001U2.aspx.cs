using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油資料管理：修改頁
/// </summary>
public partial class TDTSb001_TDTSb001U2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        HtmlTag hTag = new HtmlTag();
        TDOS tdos = new TDOS();
        try
        {
            dao.open();

            if (!IsPostBack)
            {
                //button權限                
                adt_status.Enabled = userID.hasFunc("TDOSb001_audit");
                adt_desc.Enabled = userID.hasFunc("TDOSb001_audit");
                btnReset.Enabled = userID.hasFunc("TDOSb001_audit");

                Form form = new Form();
                form.setValue("oil_id", Request["oil_id"]);

                CPCModel model = new CPCModel();
                model.dao = dao;
                DataSet ds = model.selectOilData(form.getValue("oil_id"));
                DataRow dr = ds.Tables[0].Rows[0];

                oil_id.Value = dr["oil_id"].ToString();
                car_no.Text = dr["car_no"].ToString();
                deal_date.Text = dr["deal_date"].ToString().Substring(0, 9);
                deal_HH.Text = dr["deal_date"].ToString().Substring(10, 2);
                deal_mm.Text = dr["deal_date"].ToString().Substring(13, 2);
                stand_name.Text = dr["stand_name"].ToString();
                fuel_count.Text = dr["fuel_count"].ToString();
                fuel_amount.Text = dr["fuel_amount"].ToString();
                report_ym.Text = dr["report_ym"].ToString();
                memo.Text = dr["memo"].ToString();
                adt_desc.Text = dr["adt_desc"].ToString();
                adt_user.Text = dr["adt_user"].ToString() + "(" + dr["adt_username"].ToString() + ")";
                adt_date.Text = dr["adt_date"].ToString();
                old_status.Value = dr["adt_status"].ToString();
                old_desc.Value = dr["adt_desc"].ToString();

                hTag.createMediatorRadio("FUEL_TYPE", fuel_type, dr["fuel_type"].ToString(), 0);
                hTag.createMediatorSelect("DEP_ORG", mng_id, dr["mng_id"].ToString(), "請選擇", 0);
                hTag.createMediatorSelect("CARD_TYPE", card_type, dr["card_type"].ToString(), "請選擇", 0);
                hTag.createMediatorSelect("FUEL_NAME", fuel_name, dr["fuel_name"].ToString(), "請選擇", 0);
                hTag.createMediatorRadio("ADT_STS", adt_status, dr["adt_status"].ToString(), 0);

                if (dr["adt_user"].ToString() != string.Empty)
                {
                    pnlAdt.Visible = true;
                }
                else
                {
                    pnlAdt.Visible = false;
                }

               

                keep_org_SelectedIndexChanged(sender, e);
                genCardIdSelect(dr["card_id"].ToString());

                Card_Data1.mode = "show";
                Card_Data1.cardID = dr["card_id"].ToString();

                if (dr["adt_status"].ToString() != "1")
                {
                    if (tdos.IsKeyDateLock(dr["deal_date"].ToString().Substring(0, 9), userID.getUserID(), "TDOSb001"))
                    {
                        btnSave.Visible = userID.hasFunc("TDOSb001_update") || userID.hasFunc("TDOSb001_audit");
                        btnDelete.Visible = userID.hasFunc("TDOSb001_delete");
                    }
                    else
                    {
                        btnSave.Visible = false;
                        btnDelete.Visible = false;
                    }
                    btnReset.Visible = false;                   
                }
                else
                {
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    if (tdos.IsKeyDateLock(dr["deal_date"].ToString().Substring(0, 9), userID.getUserID(), "TDOSb001"))
                    {
                        btnReset.Visible = userID.hasFunc("TDOSb001_audit");
                    }
                    else
                    {
                        btnReset.Visible = false;
                    }
                }

                //勤務記錄
                getWorkData(dr["fuel_use"].ToString());
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.StackTrace);
        }
        finally
        {
            dao.close();
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
    /// 儲存前的檢核
    /// </summary>
    /// <returns></returns>
    private Boolean CheckAll()
    {
        Boolean flag = true;
        UserID userID = (UserID)Session["UserID"];
        TDOS tdos = new TDOS();

        //檢核交易日期是否已鎖定
        if (deal_date.Text != string.Empty)
        {
            flag = tdos.IsKeyDateLock(deal_date.Text, userID.getUserID(), "TDOSb001");
            if (flag == false)
            {
                SysMsg.AlertMessage(this.Page, "已鎖定的交易日期不可修改資料，請聯繫管理者！");
            }
        }



        return flag;
    }


    /// <summary>
    /// 儲存按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {
            if (CheckAll())
            {
                dao.open();
                dao.beginTransaction();

                Form form = new Form();
                form.setValue("oil_id", oil_id.Value);
                form.setValue("mng_id", mng_id.SelectedValue);
                form.setValue("card_no", card_id.SelectedItem.Text.Replace("(停用)", ""));
                form.setValue("car_no", car_no.Text.Trim());
                form.setValue("deal_date", DateTransfer.c_date_trans(deal_date.Text.Trim()) + " " +
                       deal_HH.Text.Trim() + ":" + deal_mm.Text.Trim() + ":00");
                form.setValue("stand_name", stand_name.Text.Trim());
                form.setValue("fuel_type", fuel_type.SelectedValue);
                form.setValue("fuel_name", fuel_name.SelectedValue);
                form.setValue("fuel_count", fuel_count.Text.Trim());
                form.setValue("fuel_amount", fuel_amount.Text.Trim());
                form.setValue("report_ym", report_ym.Text.Trim());
                form.setValue("memo", memo.Text.Trim());
                form.setValue("update_user", userID.getUserID());

                if (adt_status.SelectedValue != old_status.Value || adt_desc.Text != old_desc.Value)
                {
                    form.setValue("adt_status", adt_status.SelectedValue);
                    form.setValue("adt_desc", adt_desc.Text.Trim());
                }

                CPCModel model = new CPCModel();
                model.dao = dao;
                model.updateOilMst(form);

                if (work_id != null)
                {
                    model.deleteFuelUse(oil_id.Value, "DEP");

                    String[] work_data = HandleParam.getMultiValue(work_id).Split(',');
                    for (int i = 0; i < work_data.Length; i++)
                    {
                        Form form_use = new Form();
                        form_use.setValue("fuel_id", oil_id.Value);
                        form_use.setValue("data_source", "DEP");
                        form_use.setValue("create_user", userID.getUserID());
                        form_use.setValue("work_id", work_data[i]);
                        if (work_data[i] != string.Empty)
                        {
                            model.insertFuelUse(form_use);
                        }
                    }
                }
                dao.commit();
                SysMsg.AlertMessage(this.Page, "儲存成功！");
            }
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


    /// <summary>
    /// 保管單位連動車隊卡卡號
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void keep_org_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            CardModel model = new CardModel();
            model.dao = dao;
            //ArrayList al_card = model.selectCardNo(keep_org.SelectedValue, "");
            //hTag.createSelect(al_card, card_id, "", "請選擇", 0);
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


    /// <summary>
    /// 管理單位連動加油卡卡號下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect("");
    }

    /// <summary>
    /// 加油卡卡別連動加油卡卡號下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void card_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect("");
    }


    /// <summary>
    /// 產生加油卡卡號的下拉選單
    /// </summary>
    private void genCardIdSelect(String str_card_id)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            CardModel model = new CardModel();
            model.dao = dao;
            Form form = new Form();
            form.setValue("user_read", userID.getUserRead());
            form.setValue("user_org", userID.getUserOrg());
            form.setValue("keep_org", mng_id.SelectedValue);
            form.setValue("card_type", card_type.SelectedValue);
            ArrayList al_card = model.selectCardNo(form);
            hTag.createSelect(al_card, card_id, str_card_id, "請選擇", 0);
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
    /// 加油卡卡號連動相關資料顯示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void card_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (btnSave.Visible == true)
        {
            Card_Data1.getOilCardData(card_id.SelectedValue, car_no.Text, "");
            getWorkData("");
        }
    }


    /// <summary>
    /// 交易日期TextChanged事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void deal_date_TextChanged(object sender, EventArgs e)
    {
        getWorkData("");
    }


    /// <summary>
    /// 取得勤務記錄
    /// </summary>
    private void getWorkData(String fuel_use)
    {
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            if (deal_date.Text != string.Empty && card_id.SelectedValue != string.Empty)
            {
                CPCModel model = new CPCModel();
                model.dao = dao;
                Form form = new Form();
                DateTime target_date = Convert.ToDateTime(DateTransfer.c_date_trans(deal_date.Text));
                //改成當月份1號開始
                target_date = new DateTime(target_date.Year, target_date.Month, 1);
                DateTime end_date = target_date.AddMonths(2).AddDays(-1);
                form.setValue("fuel_id", "");
                form.setValue("data_source", "DEP");
                form.setValue("start_date", target_date.ToString("yyyy/MM/dd"));
                form.setValue("end_date", end_date.ToString("yyyy/MM/dd"));
                form.setValue("card_id", card_id.SelectedValue);
                ArrayList al = model.SelectFuelUse(form);
                hTag.createCheckBox(al, work_id, fuel_use, 0);
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally { dao.close(); }
    }


    /// <summary>
    /// 更新勤務記錄的圖示按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibWork_Click(object sender, ImageClickEventArgs e)
    {
        getWorkData("");
    }


    /// <summary>
    /// 重設狀態按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("oil_id", oil_id.Value);
            form.setValue("adt_status", "0");
            form.setValue("adt_desc", adt_desc.Text + Environment.NewLine +  "使用者："+ userID.getUserID() + "(" + userID.getUserName()+")在" + 
                DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd"))+"重設狀態為尚未審核。");
            form.setValue("update_user", userID.getUserID());  

            CPCModel model = new CPCModel();
            model.dao = dao;
            model.updateOilStatus(form);
            dao.commit();

            Response.Write("<script>alert('重設狀態成功！'); location.href='" + Forward.Redirect("TDOSb001U2.aspx", "oil_id=" + Request["oil_id"], this) + "'; </script>");            
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, "重設狀態失敗！\\\n" + ex.Message);
        }
        finally 
        { 
            dao.close();
        }
    }


    /// <summary>
    /// 刪除按鈕動作事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
         DBDAO dao = new DBDAO();
         try
         {
             dao.open();

             CPCModel model = new CPCModel();
             model.dao = dao;
             model.deleteDepOilMst(oil_id.Value);

             dao.commit();

             Response.Write("<script>alert('刪除成功！'); location.href='" + Forward.Redirect("TDOSb001Q1.aspx", "", this) + "'; </script>");
         }
         catch (Exception ex)
         {
            SysMsg.AlertMessage(this.Page, "刪除失敗！\\\n" + ex.Message);
        }
        finally 
        { 
            dao.close();
        }
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
}