using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 系統參數修改頁
/// </summary>
public partial class TDOSa002_TDOSa002U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSa002_update");
                btnInsert.Visible = userID.hasFunc("TDOSa002_update");
                btnIdSave.Visible = userID.hasFunc("TDOSa002_update");
                btnIdDelete.Visible = userID.hasFunc("TDOSa002_delete");

                Form form = new Form();
                form.setValue("param_type", Request["param_type"]);

                ParamModel model = new ParamModel();
                model.dao = dao;
                DataSet ds = model.selectParam(form.getValue("param_type"));
                DataRow dr = ds.Tables[0].Rows[0];
                param_type.Text = form.getValue("param_type");
                param_name.Text = dr["param_name"].ToString();
                memo.Text = dr["memo"].ToString();

                HtmlTag hTag = new HtmlTag();
                hTag.createMediatorRadio("USE_STS", status, dr["status"].ToString(), 0);

                gvMainBind(form.getValue("param_type"));
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
    /// gvMain資料繫結
    /// </summary>
    /// <param name="strParamType"></param>
    private void gvMainBind(String strParamType)
    {
        DBDAO dao = new DBDAO();
        try
        {
            ParamModel model = new ParamModel();
            model.dao = dao;
            dao.open();
            gvMain.DataSource = model.selectParamData(strParamType);
            gvMain.DataBind();
        }
        catch { }
        finally { dao.close(); }
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
            ParamModel model = new ParamModel();
            model.dao = dao;

            Form form = new Form();
            form.setValue("param_type", param_type.Text.Trim());
            form.setValue("param_name", param_name.Text.Trim());
            form.setValue("status", status.SelectedValue);
            form.setValue("memo", memo.Text.Trim());
            form.setValue("update_user", userID.getUserID());

            model.updateParam(form);
            SYSLOG.setLog(Request, Session, "修改", dao.getSQL());

            dao.commit();
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
    /// 返回按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSa002Q1.aspx", "", this));
    }


    /// <summary>
    /// gvMain_RowDataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //變更狀態欄顯示
            Mediator med = Mediator.getInstance(false);
            String statusValue = drv["status"].ToString();
            String statusText = med.lookupParamName("USE_STS", statusValue, 0);
            e.Row.Cells[3].Text = statusText;

        }
    }


    /// <summary>
    /// gvMain_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        string strParamID = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        PanelShow("edit");
        hfAction.Value = "update";
        ParamIdBind(strParamID);
        param_id.Enabled = param_type.Text.Equals("REPAIR_VENDER");
        if (userID.hasFunc("TDOSa002_delete"))
        {
            btnIdDelete.Visible = true;
        }
        else
        {
            btnIdDelete.Visible = false;
        }
    }


    /// <summary>
    /// 新增屬性按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        ClearControl();
        PanelShow("edit");
        ParamIdBind("");
        hfAction.Value = "insert";
        btnIdDelete.Visible = false;
    }


    /// <summary>
    /// 取消按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        PanelShow("list");
        gvMainBind(param_type.Text);

    }


    /// <summary>
    /// 儲存按鈕的事件(系統參數明細)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIdSave_Click(object sender, EventArgs e)
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
                form.setValue("param_type", param_type.Text.Trim());
                form.setValue("original_id", original_id.Value);
                form.setValue("original_id_name", original_id_name.Value);
                form.setValue("param_id", param_id.Text.Trim().ToUpper());
                form.setValue("id_name", id_name.Text.Trim());
                form.setValue("status", id_status.SelectedValue);
                form.setValue("id_order_by", id_order_by.Text.Trim());
                form.setValue("memo", id_memo.Text.Trim());
                form.setValue("create_user", userID.getUserID());
                form.setValue("update_user", userID.getUserID());

                ParamModel model = new ParamModel();
                model.dao = dao;
                #region 修正維修廠商沒有資料_wenny1061218

                if (hfAction.Value == "insert")
                {
                    if (model.IsUnique(form.getValue("param_type"), form.getValue("param_id"), form.getValue("id_name")))
                    {
                        model.insertSYSParam(form);
                        SYSLOG.setLog(Request, Session, "新增", dao.getSQL());
                    }
                    else if (!model.IsUnique(form.getValue("param_type"), form.getValue("param_id")))
                    {
                        SysMsg.AlertMessage(this.Page, "屬性代碼重複！請重新輸入。");
                        return;
                    }
                    else if (!model.IsUniqueName(form.getValue("param_type"), form.getValue("id_name")))
                    {
                        SysMsg.AlertMessage(this.Page, "屬性名稱重複！請重新輸入。");
                        return;
                    }
                }
                else if (hfAction.Value == "update")
                {
                    if (param_id.Text == original_id.Value && id_name.Text == original_id_name.Value)
                    {
                        model.updateSYSParam(form);
                        SYSLOG.setLog(Request, Session, "修改", dao.getSQL());
                    }
                    else if (model.IsUnique(form.getValue("param_type"), form.getValue("param_id"), form.getValue("id_name")))
                    {
                        model.updateSYSParam(form);
                        SYSLOG.setLog(Request, Session, "修改", dao.getSQL());
                    }
                    else if (!model.IsUnique(form.getValue("param_type"), form.getValue("param_id")))
                    {
                        SysMsg.AlertMessage(this.Page, "屬性代碼重複！請重新輸入。");
                        return;
                    }
                    else if (!model.IsUniqueName(form.getValue("param_type"), form.getValue("id_name")))
                    {
                        SysMsg.AlertMessage(this.Page, "屬性名稱重複！請重新輸入。");
                        return;
                    }
                }
                #endregion
                #region 修正維修廠商沒有資料_wenny1061218_修正前原始碼
                //if (hfAction.Value == "insert")
                //{
                //    if (model.IsUnique(form.getValue("param_type"), form.getValue("param_id")))
                //    {
                //        model.insertSYSParam(form);
                //        SYSLOG.setLog(Request, Session, "新增", dao.getSQL());
                //    }
                //    else
                //    {
                //        SysMsg.AlertMessage(this.Page, "屬性代碼重複！請重新輸入。");
                //        return;
                //    }
                //}
                //else if (hfAction.Value == "update")
                //{
                //    model.updateSYSParam(form);
                //    SYSLOG.setLog(Request, Session, "修改", dao.getSQL());
                //}
                #endregion
                #region 「勤務記錄作業項第一層」系統參數主檔新增
                if (hfAction.Value == "insert" && ParamModel.specParamTYPE.Contains(param_type.Text))
                {
                    Form formParamType = new Form();
                    formParamType.setValue("param_type", param_id.Text.ToUpper());
                    formParamType.setValue("param_name", id_name.Text);
                    formParamType.setValue("param_attr", "U");
                    formParamType.setValue("status", id_status.SelectedValue);
                    formParamType.setValue("memo", param_name.Text + "「" + id_name.Text + "」之子項目維護。");
                    formParamType.setValue("create_user", userID.getUserID());
                    model.insertParamType(formParamType);
                    SYSLOG.setLog(Request, Session, "新增", dao.getSQL());
                }
                #endregion

                dao.commit();
                ClearControl();
                PanelShow("list");

                gvMainBind(param_type.Text);
                Mediator med = Mediator.getInstance(true);
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


    private Boolean CheckAll()
    {
        DBDAO dao = new DBDAO();
        ParamModel model = new ParamModel();
        Boolean flag = true;

        if (flag && param_type.Text == "CAR_WITEM_L1")
        {
            if (param_id.Text.Length >= 6)
            {
                if (param_id.Text.Substring(0, 5) != "CITEM")
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "屬性代碼前5碼須為『CITEM』！");
                }
            }
            else
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "屬性代碼長度不足，且前5碼須為『CITEM』！");
            }
        }


        if (flag && param_type.Text == "MCHN_WITEM_L1")
        {
            if (param_id.Text.Length >= 6)
            {
                if (param_id.Text.Substring(0, 5) != "MITEM")
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "屬性代碼前5碼須為『MITEM』！");
                }
            }
            else
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "屬性代碼長度不足，且前5碼須為『MITEM』！");
            }
        }

        if (flag && !param_type.Text.Equals("CAR_WITEM_L1") && !param_type.Text.Equals("MCHN_WITEM_L1"))
        {
            if (param_id.Text.Length >= 6)
            {
                if (flag && param_id.Text.Substring(0, 5) == "CITEM")
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "屬性代碼前4碼不可使用『CITEM』！");
                }

                if (flag && param_id.Text.Substring(0, 5) == "MITEM")
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "屬性代碼前5碼不可使用『MITEM』！");
                }

            }
        }

        try
        {
            dao.open();
            model.dao = dao;


            //作業項目跨param_type不可重複
            if (flag && (param_type.Text.Substring(0, 5).Equals("CITEM") || param_type.Text.Substring(0, 5).Equals("MITEM"))
                && hfAction.Value == "insert")
            {
                if (!model.IsUniqueOfWorkItem(param_type.Text.Substring(0, 5), param_id.Text.Trim()))
                {
                    SysMsg.AlertMessage(this.Page, "屬性代碼重複！請重新輸入。");
                    flag = false;
                }
            }

        }
        catch
        {
        }
        finally
        {
            dao.close();
        }


        return flag;
    }


    /// <summary>
    /// 設定Panel顯示
    /// </summary>
    /// <param name="mode"></param>
    private void PanelShow(String mode)
    {
        if (mode == "edit")
        {

            pnlEdit.Visible = true;
            pnlMain.Visible = false;
            param_id.Enabled = true;
        }
        else
        {
            pnlEdit.Visible = false;
            pnlMain.Visible = true;
            gvMain.EditIndex = -1; //修正維修廠商沒有資料_wenny1061218
            hfAction.Value = string.Empty;

        }
    }


    /// <summary>
    /// 取得系統參數屬性明細
    /// </summary>
    /// <param name="strParam_id"></param>
    private void ParamIdBind(String strParam_id)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            ParamModel model = new ParamModel();
            model.dao = dao;
            if (strParam_id != string.Empty)
            {
                DataSet ds = model.selectParamId(param_type.Text, strParam_id);
                DataRow dr = ds.Tables[0].Rows[0];
                original_id.Value = strParam_id;
                original_id_name.Value = dr["id_name"].ToString();//修正維修廠商沒有資料_wenny1061218
                param_id.Text = strParam_id;
                id_name.Text = dr["id_name"].ToString();
                id_memo.Text = dr["memo"].ToString();
                id_order_by.Text = dr["id_order_by"].ToString();
                HtmlTag hTag = new HtmlTag();
                hTag.createMediatorRadio("USE_STS", id_status, dr["status"].ToString(), 0);
            }
            else
            {
                HtmlTag hTag = new HtmlTag();
                hTag.createMediatorRadio("USE_STS", id_status, "O", 0);
                id_order_by.Text = model.getDefaultIdorder(param_type.Text).ToString();
            }
        }
        catch { }
        finally
        {
            dao.close();
        }
    }

    /// <summary>
    /// 刪除按鈕事件(系統參數明細)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIdDelete_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            dao.beginTransaction();
            ParamModel model = new ParamModel();
            model.dao = dao;

            Form form = new Form();
            form.setValue("param_type", param_type.Text);
            form.setValue("param_id", param_id.Text.ToUpper());
            model.deleteSYSParam(form);
            SYSLOG.setLog(Request, Session, "刪除", dao.getSQL());

            if (ParamModel.specParamTYPE.Contains(param_type.Text))
            {
                model.deleteParamType(form);
                SYSLOG.setLog(Request, Session, "刪除", dao.getSQL());
            }

            dao.commit();
            SysMsg.AlertMessage(this.Page, "刪除成功！");
            ClearControl();
            PanelShow("list");
            gvMainBind(param_type.Text);
        }
        catch { }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 清除控制項的內容
    /// </summary>
    private void ClearControl()
    {
        param_id.Text = string.Empty;
        id_name.Text = string.Empty;
        id_memo.Text = string.Empty;
        id_order_by.Text = string.Empty;
    }
    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        String field = "id_order_by";
        try
        {

            Form form = new Form();
            form.setValue("param_type", Request["param_type"]);

            ParamModel model = new ParamModel();
            model.dao = dao;
            dao.open();
            DataSet ds = model.selectParam(form.getValue("param_type"));
            DataRow dr = ds.Tables[0].Rows[0];
            param_type.Text = form.getValue("param_type");
            param_name.Text = dr["param_name"].ToString();
            memo.Text = dr["memo"].ToString();

            HtmlTag hTag = new HtmlTag();
            hTag.createMediatorRadio("USE_STS", status, dr["status"].ToString(), 0);
            //test
            Button Lbtn = (Button)sender;

            switch (Lbtn.ID)
            {
                case "param_id_s":
                    field = "param_id ";
                    break;
                case "param_id_sd":
                    field = "param_id desc ";
                    break;
                case "id_name_s":
                    field = "id_name";
                    break;
                case "id_name_sd":
                    field = "id_name desc";
                    break;
                case "status_s":
                    field = "status";
                    break;
                case "status_sd":
                    field = "status desc";
                    break;
                case "id_order_by_s":
                    field = "id_order_by";
                    break;
                case "id_order_by_sd":
                    field = "id_order_by desc";
                    break;
                case "memo_s":
                    field = "memo";
                    break;
                case "memo_sd":
                    field = " memo desc ";
                    break;

                default:
                    break;
            }
            String strParamType = form.getValue("param_type");
            DataSet dsdata = model.selectParamData(strParamType);
            DataTable dts = new DataTable();
            dts = dsdata.Tables[0];
            //for (int i = 0; i < 6; i++)
            //{
            //    string colmName = dts.Columns[i].ColumnName;
            //    if (string.IsNullOrEmpty(colmName))
            //    {
            //        Response.Write(i + "沒有欄位名<br/>");
            //    }
            //    Response.Write(i+colmName+"<br/>");

            //}

            dts.DefaultView.Sort = field;
            dts = dts.DefaultView.ToTable();
            gvMain.DataSource = dts;
            gvMain.DataBind();
            //gvMainBind(form.getValue("param_type"));
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
}

