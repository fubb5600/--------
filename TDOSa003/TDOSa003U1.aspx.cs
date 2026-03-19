using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 基本參數頁
/// </summary>
public partial class TDTSa003_TDTSa003U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();

            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限
                    btnSave.Visible = userID.hasFunc("TDOSa003_update");

                    BindData();
                    key_date_TextChanged(sender, e);
                    work_date_TextChanged(sender, e);

                    hTag.createMediatorSelect("DEP_ORG", dep_org, "", "請選擇", 0);
                    hTag.createMediatorRadio("UNLOCK_TYPE", unlock_type, "TDOSb001", 0);
                    dep_org_SelectedIndexChanged(sender, e);
                    unlock_type_SelectedIndexChanged(sender, e);
                    BindUnlockData();
                }

                //分頁設定
                //查詢資料
                ParamModel model = new ParamModel();
                PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
                pb.setDBDAO(dao);
                DataSet ds = pb.doSearch(model, "browse2");

                if (pb.isDoSearch())
                {
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
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
            dao.beginTransaction();

            Form form = new Form();
            form.setValue("basic_id", basic_id.Value);
            form.setValue("key_date", key_date.Text);
            form.setValue("send_date", send_date.Text);
            form.setValue("work_date", work_date.Text);
            form.setValue("create_user", userID.getUserID());
            form.setValue("update_user", userID.getUserID());

            ParamModel model = new ParamModel();
            model.dao = dao;
            if (form.getValue("basic_id") != string.Empty)
            {
                model.updateBasicParam(form);
            }
            model.insertBasicParam(form);
            dao.commit();
            BindData();
            SysMsg.AlertMessage(this.Page, "儲存成功！");

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
    /// 取出現在使用的基本參數資料
    /// </summary>
    private void BindData()
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            ParamModel model = new ParamModel();
            model.dao = dao;
            DataSet ds = model.selectBasicParam();
            if (ds.Tables[0].Rows.Count >= 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                basic_id.Value = dr["basic_id"].ToString();
                key_date.Text = dr["key_date"].ToString();
                send_date.Text = dr["send_date"].ToString();
                work_date.Text = dr["work_date"].ToString();
            }
            else
            {
                basic_id.Value = string.Empty;
                key_date.Text = string.Empty;
                send_date.Text = string.Empty;
                work_date.Text = string.Empty;
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
    /// key_date_TextChanged事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void key_date_TextChanged(object sender, EventArgs e)
    {
        if (key_date.Text != string.Empty)
        {
            key_end_date.Text = key_date.Text;
        }
    }


    /// <summary>
    /// work_date_TextChanged事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void work_date_TextChanged(object sender, EventArgs e)
    {
        if (work_date.Text != string.Empty)
        {
            work_end_date.Text = work_date.Text;
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


            e.Row.Cells[3].Text = drv["data_start"].ToString() + "~" + drv["data_end"].ToString();
            e.Row.Cells[4].Text = drv["key_start"].ToString() + "~" + drv["key_end"].ToString();
        }
    }


    /// <summary>
    /// 解除鎖定資料DataBind
    /// </summary>
    private void BindUnlockData()
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            Form form = new Form();
            ParamModel model = new ParamModel();
            model.dao = dao;
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
        finally { dao.close(); }

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
    /// dep_org_SelectedIndexChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dep_org_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            UserModel model = new UserModel();
            model.dao = dao;
            ArrayList al = model.selectUserbyDep(dep_org.SelectedValue);
            hTag.createSelect(al, unlock_user, "", "全部", 0);

            if (dep_org.SelectedValue != string.Empty)
            {
                unlock_user.Visible = true;
            }
            else
            {
                unlock_user.Visible = false;
            }
        }
        catch (Exception ex) { SysMsg.AlertMessage(this.Page, ex.Message); }
        finally { dao.close(); }
    }


    /// <summary>
    /// unlock_type_SelectedIndexChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void unlock_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (unlock_type.SelectedValue == "TDOSb001")
        {
            data_memo.Text = "交易日期在此範圍的加油資料";
        }
        else
        {
            data_memo.Text = "勤務日期在此範圍的勤務記錄";
        }
    }


    protected void btn_Unlock_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();
            dao.beginTransaction();

            Form form = new Form();
            form.setValue("unlock_type", unlock_type.SelectedValue);
            form.setValue("data_start", DateTransfer.c_date_trans(data_str.Text));
            form.setValue("data_end", DateTransfer.c_date_trans(data_end.Text));
            form.setValue("key_start", DateTransfer.c_date_trans(key_str.Text));
            form.setValue("key_end", DateTransfer.c_date_trans(key_end.Text));
            form.setValue("create_user", userID.getUserID());

            if (unlock_user.SelectedValue != string.Empty)
            {
                insertUnlock(form, dao, unlock_user.SelectedValue);
            }
            else
            {
                UserModel model = new UserModel();
                model.dao = dao;
                ArrayList al = model.selectUserbyDep(dep_org.SelectedValue);
                for (int i = 0; i < al.Count; i++)
                {
                    Hashtable ht = (Hashtable)al[i];
                    insertUnlock(form, dao, ht["PVALUE"].ToString());
                }
            }


            dao.commit();
            BindUnlockData();
            ClearUnlockControl();
            SysMsg.AlertMessage(this.Page, "儲存成功！");
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


    private void insertUnlock(Form form, DBDAO dao, String unlock_user)
    {
        form.setValue("user_id", unlock_user);
        ParamModel model = new ParamModel();
        model.dao = dao;
        model.insertUnlockMst(form);
    }


    /// <summary>
    /// 清除資料鎖定設定控制項
    /// </summary>
    private void ClearUnlockControl()
    {
        dep_org.SelectedIndex = 0;
        unlock_user.Visible = false;
        data_str.Text = string.Empty;
        data_end.Text = string.Empty;
        key_str.Text = string.Empty;
        key_end.Text = string.Empty;
    }


    /// <summary>
    /// 刪除資料鎖定的授權資料
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            ParamModel model = new ParamModel();
            model.dao = dao;
            string unlock_id = gvMain.DataKeys[e.RowIndex].Values[0].ToString().Trim();
            model.deleteLockMst(unlock_id);
            dao.commit();
            BindUnlockData();
            SysMsg.AlertMessage(this.Page, "刪除成功！");
        }
        catch { }
        finally { dao.close(); }
    }
}