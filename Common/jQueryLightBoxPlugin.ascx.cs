using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;

public partial class Common_jQueryLightBoxPlugin : System.Web.UI.UserControl
{
    public String attach_type;
    public String main_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        String strHTML = string.Empty;
        try
        {
            if (!IsPostBack)
            {
                if (attach_type != string.Empty && main_id != string.Empty)
                {
                    dao.open();
                    AttachModel model = new AttachModel();
                    model.dao = dao;
                    DataSet ds = model.selectAttach(attach_type, main_id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];
                            strHTML += "<li>";
                            strHTML += "<a href=\"" + dr["attach_dir"].ToString() + dr["file_name"].ToString() + "\"" +
                                "title=\"" + dr["attach_desc"].ToString() + "\">";
                            strHTML += "<img src=\"" + dr["attach_dir"].ToString() + dr["file_name"].ToString() +
                                "\" width=\"72\" height=\"72\" alt=\"" + dr["attach_desc"].ToString() + "\" />";
                            strHTML += "</a>";
                            strHTML += "</li>";
                        }
                    }
                    else
                    {
                        strHTML = "<span class=\"td_memo\">目前無附件檔案</span>";
                    }

                    Literal1.Text = strHTML;
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        PanelShow("edit");
                    }
                   
                    hfAttachType.Value = attach_type;
                    hfMainId.Value = main_id;
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


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        PanelShow("edit");
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        PanelShow("");
    }


    private void PanelShow(String Mode)
    {
        if (Mode=="edit")
        {
            pnlMain.Visible = false;
            pnlEdit.Visible = true;
            BindAttachData();
        }
        else
        {
        pnlMain.Visible = true;
        pnlEdit.Visible = false;
        }

    }


    private void BindAttachData()
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            AttachModel model = new AttachModel();
            model.dao = dao;
            DataSet ds = model.selectAttach(hfAttachType.Value, hfMainId.Value);
            gvMain.DataSource = ds;
            gvMain.DataBind();

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
            //Mediator med = Mediator.getInstance();
            //String statusValue = drv["status"].ToString();
            //String statusText = med.lookupParamName("USE_STS", statusValue, 0);
            //e.Row.Cells[3].Text = statusText;

        }
    }


    /// <summary>
    /// gvMain_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string attach_id = gvMain.DataKeys[e.RowIndex].Values[0].ToString().Trim();

        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            AttachModel model = new AttachModel();
            model.dao = dao;
            model.deleteAttach(attach_id);
            SysMsg.AlertMessage(this.Page, "刪除成功!");
            BindAttachData();
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, "刪除失敗!\n" + ex.Message);
        }
        finally
        {
            dao.close();
        }
    }



    protected void btnUpload_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        TaskMediator taskMed = TaskMediator.getInstance();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            if (uplfiles.HasFile)
            {
                string saveDir = Server.MapPath("../Attach_File/" + hfAttachType.Value + "/" + Session["USERID"].ToString() + "/");

                DirectoryInfo dir = new DirectoryInfo(saveDir);
                String filename = string.Empty;
                String AppalId = string.Empty;

                //檢查檔案儲存目錄不存在時自動建立
                if (!dir.Exists)
                {
                    dir.Create();
                }

                if (uplfiles.HasFile)
                {
                    string rnd = string.Format("{0:00000}", (new Random()).Next(100000));
                    filename = rnd + "_" + System.IO.Path.GetFileName(uplfiles.PostedFile.FileName);
                    string SaveLocation = saveDir + filename;
                    uplfiles.PostedFile.SaveAs(SaveLocation);

                    string[] file = uplfiles.PostedFile.FileName.Split('.');

                    String currentPath = Request.AppRelativeCurrentExecutionFilePath;
                    String[] paths = currentPath.Split('/');
                    String TaskPath = string.Empty;
                    String task_id = paths[paths.Length - 2];

                    dao.open();
                    AttachModel model = new AttachModel();
                    model.dao = dao;
                    Form form = new Form();
                    form.setValue("task_id", task_id);
                    form.setValue("main_id", hfMainId.Value);
                    form.setValue("attach_type", hfAttachType.Value);
                    form.setValue("attach_name", attach_name.Text);
                    form.setValue("attach_desc", attach_desc.Text);
                    form.setValue("file_name", filename);
                    form.setValue("create_user", userID.getUserID());
                    if (hfAction.Value == "insert")
                    {
                        model.insertAttach(form);
                    }
                    else if (hfAction.Value == "update")
                    {
                        model.updateAttach(form);
                    }
                }

                SysMsg.AlertMessage(this.Page, "附件檔案儲存成功!");

            }
            else
            {
                SysMsg.AlertMessage(this.Page, "請選擇附件檔案!");
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, "附件檔案儲存失敗!\n" + ex.Message);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 取消按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        hfAction.Value = "insert";
        attach_name.Text = string.Empty;
        attach_desc.Text = string.Empty;
    
    }
}