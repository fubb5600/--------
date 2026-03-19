using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油卡資料：修改頁
/// </summary>
public partial class TDOSc004_TDOSc004U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSc004_update");
                btnDelete.Visible = userID.hasFunc("TDOSc004_delete");

                Form form = new Form();
                form.setValue("card_id", Request["card_id"]);

                CardModel model = new CardModel();
                model.dao = dao;
                dao.open();
                HtmlTag hTag = new HtmlTag();

                DataSet ds = model.selectCard(form.getValue("card_id"));
                DataRow dr = ds.Tables[0].Rows[0];

                card_id.Value = dr["card_id"].ToString().ToUpper();
                card_no.Text = dr["card_no"].ToString();
                old_keep_org.Value = dr["keep_org"].ToString();
                //keep_man.Text = dr["keep_man"].ToString();

                ArrayList al_CardType = model.selectCardTypeByWorkType("");
                hTag.createRadio(al_CardType, card_type, dr["card_type"].ToString(), 0);

                //hTag.createMediatorRadio("CARD_TYPE", card_type, dr["card_type"].ToString(), 0);
                hTag.createMediatorSelect("DEP_ORG", keep_org, dr["keep_org"].ToString(), "請選擇", 0);
                hTag.createMediatorRadio("FUEL_TYPE", fuel_type, dr["fuel_type"].ToString(), 0);
                hTag.createMediatorRadio("USE_STS", status, dr["status"].ToString(), 0);

                if (dr["car_no"].ToString() != string.Empty)
                {
                    car_no.Text = "(車牌號碼：" + dr["car_no"].ToString() + ")";
                }
                else
                {
                    car_no.Text = string.Empty;
                }
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
        Response.Redirect(Forward.Redirect("TDOSc004Q1.aspx", "", this));
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
            if (CheckAll())
            {
                dao.beginTransaction();

                Form form = new Form();
                form.setValue("card_id", card_id.Value);
                form.setValue("card_type", card_type.SelectedValue);
                form.setValue("card_no", card_no.Text.Trim().ToUpper());
                form.setValue("keep_org", keep_org.SelectedValue);
                form.setValue("fuel_type", fuel_type.SelectedValue);
                form.setValue("status", status.SelectedValue);
                //form.setValue("keep_man", keep_man.Text);
                form.setValue("update_user", userID.getUserID());
                CardModel model = new CardModel();
                model.dao = dao;

                model.updateCard(form);

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
    /// 刪除按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Boolean flag = true;
        CardModel model = new CardModel();
        model.dao = dao;
        try
        {
            dao.open();
            dao.beginTransaction();

            //if (!model.IsCardNoOverOne(card_no.Text)) //只有一筆加油卡號才檢查
            //{
                #region 刪除前檢核是否有勤務記錄及加油資料
                if (flag && model.IsCardIdExistWorkData(card_id.Value))
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "已有建立勤務記錄，不可刪除！");
                }

                if (flag && model.IsCardIdExistFuelData(card_id.Value))
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "已有加油資料不可刪除！");
                }
                #endregion
           // }

            if (flag)
            {
                Form form = new Form();
                form.setValue("card_id", card_id.Value);

                model.deleteCard(form.getValue("card_id"));
                model.deleteCarCard(form.getValue("card_id"));

                dao.commit();
                Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSc004Q1.aspx", "", this) + "'; </script>");

            }
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "刪除失敗！\\\n" + ex.Message);
        }
        finally
        {
            dao.close();
        }
    }


    private Boolean CheckAll()
    {
        Boolean flag = true;
        DBDAO dao = new DBDAO();
        CardModel model = new CardModel();

        if (flag && car_no.Text != string.Empty && card_type.SelectedValue != "1")
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "車隊卡已有車輛使用，不可變更加油卡卡別！");
        }

        if (flag && car_no.Text != string.Empty && old_keep_org.Value != keep_org.SelectedValue)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "車隊卡已有車輛使用，不可變更保管單位！");
        }

        //if (flag && car_no.Text != string.Empty && status.SelectedValue == "C")
        //{
        //    flag = false;
        //    SysMsg.AlertMessage(this.Page, "車隊卡已有車輛使用不可停用，請先變更車輛資料！");
        //}

        //檢核加油卡號是否唯一
        if (flag && card_no.Text != string.Empty && status.SelectedValue == "O")
        {
            try
            {
                dao.open();
                model.dao = dao;

                Form form = new Form();
                form.setValue("card_no", card_no.Text);
                form.setValue("action", "Update");
                form.setValue("card_id", card_id.Value);
                if (model.IsCardNoExist(form) != string.Empty)
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "已存在使用中的加油卡卡號，不可重複新增！");
                }
            }

            catch { }
            finally { dao.close(); }
        }

        return flag;
    }
}