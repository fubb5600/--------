using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class Common_car_inspection : System.Web.UI.UserControl
{
    public String str_car_id = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            car_id.Value = str_car_id;
            BindCarInspectionGrid(car_id.Value);
        }

        
    }
    /// <summary>
    /// 取得車輛狀態歷史資料
    /// </summary>
    /// <param name="car_id"></param>
    public void BindCarInspectionGrid(String car_id)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        // 這裡開始

        dao.open();

        Form form = new Form();
        form.setValue("car_id", car_id);
        PageBreak pb = new PageBreak(Request, Session, this.Page, pbLabel);//每10筆分頁
        CarInspectionModel model = new CarInspectionModel();
        model.dao = dao;

        //DataSet ds = model.browse(pb, form);  //這樣browse 有紅線耶
        DataSet ds = model.select(form);
        //DataSet ds = pb.doSearch(model, "browse1");
        gvInspection.DataSource = ds;
        gvInspection.DataBind();

        dao.close();
        //try
        //{
        //    dao.open();

        //    Form form = new Form();
        //    form.setValue("car_id", car_id);
        //    PageBreak pb = new PageBreak(Request, Session, this.Page, pbLabel);//每10筆分頁
        //    CarInspectionModel model = new CarInspectionModel();
        //    model.dao = dao;

        //    //DataSet ds = model.browse(pb, form);  //這樣browse 有紅線耶
        //    DataSet ds = model.select(form);
        //    //DataSet ds = pb.doSearch(model, "browse1");
        //    gvInspection.DataSource = ds;
        //    gvInspection.DataBind();

        //}
        //catch (Exception ex)
        //{
        //    SysMsg.AlertMessage(this.Page, ex.Message);
        //}
        //finally
        //{
        //    dao.close();
        //}
    }


    /// <summary>
    /// GridView的RowDataBound事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInspection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        Mediator med = Mediator.getInstance(false);              

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");
        }
    }


    /// <summary>
    /// 刪除車輛檢驗紀錄事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInspection_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        String inspection_id = gvInspection.DataKeys[e.RowIndex].Values[0].ToString().Trim();
      
        try
        {
            dao.open();            
            Form form = new Form();
            form.setValue("inspect_id", inspection_id);            
            form.setValue("update_user", userID.getUserID());

            CarInspectionModel model = new CarInspectionModel();
            model.dao = dao;
            model.delete(form);
            dao.commit();

            BindCarInspectionGrid(car_id.Value);
            SysMsg.AlertMessage(this.Page, "刪除成功！");             
            SYSLOG.setLog(Request, Session, "刪除", dao.getSQL());//紀錄LOG 資料           
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "刪除失敗！\n" + ex.Message + "\n" + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
        //}
    }


    /// <summary>
    /// 儲存按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            Form form = new Form();
            form.setValue("car_id", car_id.Value);//取得Page_load事件中的car_id
            form.setValue("regular_date", DateTransfer.c_date_trans(regular_date.Text.Trim()));
            form.setValue("inspection_date", DateTransfer.c_date_trans(inspection_date.Text.Trim()));
            form.setValue("memo", memo.Text.Trim());
            form.setValue("create_user", userID.getUserID());
            CarInspectionModel model = new CarInspectionModel();

            dao.open();
            model.dao = dao;

            model.insert(form);//2016.05.27新增
            SYSLOG.setLog(Request, Session, "新增", dao.getSQL());//紀錄LOG 資料

            SysMsg.AlertMessage(this.Page, "儲存成功！");
            BindCarInspectionGrid(car_id.Value);
            clear();
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
    /// 清除按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }


    private void clear()
    {
        regular_date.Text = "";
        inspection_date.Text = "";
        memo.Text = "";
    }
}
