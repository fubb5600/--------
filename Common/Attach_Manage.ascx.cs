using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class Common_Attach_Manage : System.Web.UI.UserControl
{
    public String attach_type;
    public String main_id;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private void BindAttach()
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("attach_type", attach_type);
            form.setValue("main_id", main_id);
            //ToiletModel model = new ToiletModel(); 
            //DataSet ds = modeldoSearch(model, form, "browse1");
            //if (pb.isDoSearch())
            //{
            //    gvMain.DataSource = ds;
            //    gvMain.DataBind();
            //}
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
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string toilet_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        
    }
}