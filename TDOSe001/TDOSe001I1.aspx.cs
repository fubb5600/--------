using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油資料管理：新增頁
/// </summary>
public partial class TDTSe001_TDTSe001I1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        try
        {
            dao.open();

            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSe001_insert");

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
        Response.Redirect(Forward.Redirect("TDOSe001Q1.aspx", "", this));
    }


    /// <summary>
    /// 儲存前的檢核
    /// </summary>
    /// <returns></returns>
    private Boolean CheckAll()
    {
        Boolean flag = true;
        UserID userID = (UserID)Session["UserID"];

        #region 檢核零件編號長度

        if (component_no.Text.Trim().Length < 3)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "零件編號長度不足3碼！");
        }

        #endregion

        #region 檢核零件編號前三碼須為年度
        try
        {
            Int16 year = Convert.ToInt16(component_no.Text.Trim().Substring(0, 3));
        }
        catch (Exception ex)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "零件編號前3碼不正確！");
        }

        #endregion
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
                form.setValue("component_no", component_no.Text);
                form.setValue("component_name", component_name.Text);
                form.setValue("component_spec", component_Spec.Text);
                form.setValue("component_code", component_code.Text);
                form.setValue("count", count.Text);
                form.setValue("unit", unit.Text);
                form.setValue("budget1", budget1.Text);
                form.setValue("budget2", budget2.Text);
                form.setValue("budget3", budget3.Text);
                form.setValue("budget4", budget4.Text);
                form.setValue("car_type", car_type.Text);
                form.setValue("place_of_origin", place_of_origin.Text);
                form.setValue("memo", memo.Text.Trim());               
                form.setValue("create_user", userID.getUserID());

                ComponentModel model = new ComponentModel();
                model.dao = dao;
                Decimal fuel_id = model.insertComponent(form);

              

                dao.commit();

                Response.Write("<script>alert('新增成功！'); location.href='" + Forward.Redirect("TDOSe001Q1.aspx",
                    "", this) + "'; </script>");
            }
        }
        catch (System.Data.SqlClient.SqlException exSQL)
        {
            if (exSQL.Number.Equals(2601))
            {                
                SysMsg.AlertMessage(this.Page, "新增失敗！已有相同的零件編號！");
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



}