using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油資料管理 ：修改頁
/// </summary>
public partial class TDOSb001_TDOSb001U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
        TDOS tdos = new TDOS();
        try
        {
            if (!IsPostBack)
            {
                Form form = new Form();
                form.setValue("fuel_id", Request["fuel_id"]);

                CPCModel model = new CPCModel();
                model.dao = dao;
                dao.open();

                DataSet ds = model.selectCPCData(form.getValue("fuel_id"));
                DataRow dr = ds.Tables[0].Rows[0];

                fuel_id.Value = dr["fuel_id"].ToString().ToUpper();
                data_source.Text = med.lookupParamName("DATA_SOURCE", "CPC", 0);
                report_ym.Text = dr["report_ym"].ToString();
                imp_date.Text = dr["imp_date"].ToString() + "  [" + dr["import_id"].ToString() + "]";
                seller_id.Text = dr["seller_id"].ToString();
                seller_name.Text = dr["seller_name"].ToString();
                custom_id.Text = dr["custom_id"].ToString();
                custom_name.Text = dr["custom_name"].ToString();
                biller_id.Text = dr["biller_id"].ToString();
                biller_name.Text = dr["biller_name"].ToString();
                mng_id.Text = dr["mng_id"].ToString();
                mng_name.Text = dr["mng_name"].ToString();
                imp_card.Text = dr["card_no"].ToString();
                car_no.Text = dr["car_no"].ToString();
                deal_date.Text = dr["deal_date"].ToString();
                stand.Text = dr["stand_id"].ToString() + " / " + dr["stand_name"].ToString();
                fuel_name.Text = dr["fuel_name"].ToString();
                fuel_count.Text = dr["fuel_count"].ToString();
                fuel_amount.Text = dr["fuel_amount"].ToString();
                memo1.Text = dr["memo1"].ToString();
                memo2.Text = dr["memo2"].ToString();
                old_status.Value = dr["cfm_status"].ToString();
                old_desc.Value = dr["cfm_desc"].ToString();
                cfm_desc.Text = dr["cfm_desc"].ToString();
                cfm_user.Text = dr["cfm_user"].ToString() + "(" + dr["cfm_username"].ToString() + ")";
                cfm_date.Text = dr["cfm_date"].ToString();

                hTag.createMediatorRadio("CFM_STS", cfm_status, dr["cfm_status"].ToString(), 0);

                if (dr["cfm_user"].ToString() != string.Empty)
                {
                    pnlCfm.Visible = true;
                }
                else
                {
                    pnlCfm.Visible = false;
                }

                Card_Data1.mode = "show";
                Card_Data1.cardID = dr["card_id"].ToString();
                Card_Data1.carNO = dr["car_no"].ToString();
                Card_Data1.queryDate = DateTransfer.c_date_trans(dr["deal_date"].ToString().Substring(0, 9));

                //button權限        
                //if (dr["cfm_status"].ToString() != "1") 
                //{
                if (tdos.IsKeyDateLock(dr["deal_date"].ToString().Substring(0, 9), userID.getUserID(), "TDOSb001"))
                {
                    btnSave.Visible = userID.hasFunc("TDOSb001_update") || userID.hasFunc("TDOSb001_audit");
                    btnDelete.Visible = userID.hasFunc("TDOSb001_delete") && dr["cfm_status"].ToString() != "1";
                }
                else
                {
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                }
                //}
                //else
                //{
                //    btnSave.Visible = false;
                //}

                getWorkData(dr["deal_date"].ToString().Substring(0, 9), dr["card_id"].ToString(), dr["fuel_use"].ToString());
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
        UserID userID = (UserID)Session["UserID"];
        Boolean flag = true;
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
            dao.open();
            CarModel car_model = new CarModel();
            car_model.dao = dao;

            if (CheckAll())
            {
                Form form = new Form();
                form.setValue("fuel_id", fuel_id.Value);
                form.setValue("report_ym", report_ym.Text.Trim());
                form.setValue("car_no", car_no.Text.Trim().ToUpper());
                form.setValue("update_user", userID.getUserID());
                if (cfm_status.SelectedValue != old_status.Value || cfm_desc.Text != old_desc.Value)
                {
                    form.setValue("cfm_status", cfm_status.SelectedValue);
                    form.setValue("cfm_desc", cfm_desc.Text.Trim());
                }

                dao.beginTransaction();

                CPCModel model = new CPCModel();
                model.dao = dao;
                model.updateImportDtl(form);

                if (work_id != null)
                {
                    model.deleteFuelUse(fuel_id.Value, "CPC");

                    String[] work_data = HandleParam.getMultiValue(work_id).Split(',');
                    for (int i = 0; i < work_data.Length; i++)
                    {
                        Form form_use = new Form();
                        form_use.setValue("fuel_id", fuel_id.Value);
                        form_use.setValue("data_source", "CPC");
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
            SysMsg.AlertMessage(this.Page, "儲存失敗！\\\n" + ex.Message);
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


    /// <summary>
    /// 取得勤務記錄
    /// </summary>
    private void getWorkData(String deal_date, String card_id, String fuel_use)
    {
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            if (deal_date != string.Empty && card_id != string.Empty)
            {
                CPCModel model = new CPCModel();
                model.dao = dao;
                Form form = new Form();
                DateTime target_date = Convert.ToDateTime(DateTransfer.c_date_trans(deal_date));
                //改成當月份1號開始
                target_date = new DateTime(target_date.Year, target_date.Month, 1);
                DateTime end_date = target_date.AddMonths(2).AddDays(-1);
                form.setValue("fuel_id", "");
                form.setValue("data_source", "DEP");
                form.setValue("start_date", target_date.ToString("yyyy/MM/dd"));
                form.setValue("end_date", end_date.ToString("yyyy/MM/dd"));
                form.setValue("card_id", card_id);
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
            model.deleteCPCMst(fuel_id.Value);

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
}