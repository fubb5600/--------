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
public partial class TDOSe001_TDOSe001U1 : System.Web.UI.Page
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
                form.setValue("component_id", Request["component_id"]);
                ComponentModel model = new ComponentModel();
                model.dao = dao;
                dao.open();

                DataSet ds = model.selectComponent(form.getValue("component_id").ToString());
                DataRow dr = ds.Tables[0].Rows[0];
                component_id.Value = dr["component_id"].ToString();
                component_no.Text = dr["component_no"].ToString();
                component_name.Text = dr["component_name"].ToString();
                component_Spec.Text = dr["component_Spec"].ToString();
                component_code.Text = dr["component_code"].ToString();
                report_ym.Text = dr["component_no"].ToString().Substring(0, 3);
                count.Text = dr["count"].ToString();
                unit.Text = dr["unit"].ToString();
                budget1.Text = dr["budget1"].ToString();
                budget2.Text = dr["budget2"].ToString();
                budget3.Text = dr["budget3"].ToString();
                budget4.Text = dr["budget4"].ToString();
                car_type.Text = dr["car_type"].ToString();
                place_of_origin.Text = dr["place_of_origin"].ToString();
                memo.Text = dr["memo"].ToString();

                if (dr["import_id"].ToString() != string.Empty)
                    data_source.Text = "整批匯入";
                else
                    data_source.Text = "自行輸入";

                if (tdos.IsKeyDateLock(dr["deal_date"].ToString().Substring(0, 9), userID.getUserID(), "TDOSe001"))
                {
                    btnSave.Visible = userID.hasFunc("TDOSe001_update");
                    btnDelete.Visible = userID.hasFunc("TDOSe001_delete") && dr["cfm_status"].ToString() != "1";
                }
                else
                {
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
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
        Response.Redirect(Forward.Redirect("TDOSe001Q1.aspx", "", this));
    }


    /// <summary>
    /// 儲存前的檢核
    /// </summary>
    /// <returns></returns>
    private Boolean CheckAll()
    {
        UserID userID = (UserID)Session["UserID"];
        Boolean flag = true;

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
        catch(Exception ex)
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
            dao.open();
            ComponentModel model = new ComponentModel();
            model.dao = dao;

            if (CheckAll())
            {
                Form form = new Form();
                form.setValue("component_id", component_id.Value);
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

                model.updateComponent(form);

                dao.commit();
                Response.Write("<script>alert('儲存成功！'); location.href='" + Forward.Redirect("TDOSe001Q1.aspx",
                   "", this) + "'; </script>");
                  }
        }
        catch (System.Data.SqlClient.SqlException exSQL)
        {
            if (exSQL.Number.Equals(2601))
            {
                SysMsg.AlertMessage(this.Page, "修改失敗！已有相同的零件編號！");
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

            ComponentModel model = new ComponentModel();
            model.dao = dao;
            model.deleteComponent(component_id.Value);

            dao.commit();

            Response.Write("<script>alert('刪除成功！'); location.href='" + Forward.Redirect("TDOSe001Q1.aspx", "", this) + "'; </script>");
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