using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
/// <summary>
/// 車輛狀態的歷程記錄
/// </summary>
public partial class Common_car_status : System.Web.UI.UserControl
{
    public String str_car_id = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            car_id.Value = str_car_id;
            BindCarStatusGrid(car_id.Value);
        }
    }


    /// <summary>
    /// 取得車輛狀態歷史資料
    /// </summary>
    /// <param name="car_id"></param>
    public void BindCarStatusGrid(String car_id)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("car_id", car_id);
            ChangeModel model = new ChangeModel();
            model.dao = dao;
            DataSet ds = model.getCarStatus(form);

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
    /// GridView的RowDataBound事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        Mediator med = Mediator.getInstance(false);

        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (userID.getUserID().ToUpper() == "ADMIN")
            {
                e.Row.Cells[4].Visible = true;
            }
            else
            {
                e.Row.Cells[4].Visible = false;
            }
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //變更保管時間欄顯示
            string exec_end = drv["exec_end"].ToString() != string.Empty ? drv["exec_end"].ToString() : "迄今";
            e.Row.Cells[1].Text = drv["exec_start"].ToString() + "~" + exec_end;
            e.Row.Cells[2].Text = med.lookupParamName("USE_STS", drv["status"].ToString(), 0);


            if (userID.getUserID().ToUpper() == "ADMIN")
            {
                e.Row.Cells[4].Visible = true;
            }
            else
            {
                e.Row.Cells[4].Visible = false;
            }
        }
    }


    /// <summary>
    /// 變更車輛狀態按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        int index = Convert.ToInt32(e.CommandArgument);
       
        if (e.CommandName == "Change")
        {
            UserID userID = (UserID)Session["UserID"];
            DBDAO dao = new DBDAO();
            try
            {
                dao.open();
                String exec_id = gvMain.DataKeys[index].Values[0].ToString();
                String status = gvMain.DataKeys[index].Values[1].ToString();
                Form form = new Form();
                form.setValue("exec_id", exec_id);
                form.setValue("status", status == "C" ? "O" : "C");
                form.setValue("update_user", userID.getUserID());
                ChangeModel model = new ChangeModel();
                model.dao = dao;
                model.updateStatus(form);
                dao.commit();

                BindCarStatusGrid(car_id.Value);
                SysMsg.AlertMessage(this.Page, "變更成功！");
            }
            catch (Exception ex)
            {
                dao.rollback();
                SysMsg.AlertMessage(this.Page, "變更失敗！\n" + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                dao.close();
            }
        }
    }
}