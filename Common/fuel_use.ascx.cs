using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油卡使用資料
/// </summary>
public partial class Common_fuel_use : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// 取得勤務記錄及加油使用資料的資料繫結
    /// </summary>
    /// <param name="str_fuel_id"></param>
    /// <param name="str_data_source"></param>
    /// <param name="deal_date"></param>
    public void BindFuelUse(String str_fuel_id, String str_data_source, String deal_date, String card_id)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            CPCModel model = new CPCModel();
            model.dao = dao;
            Form form = new Form();
            DateTime target_date = Convert.ToDateTime(DateTransfer.c_date_trans(deal_date));
            DateTime end_date = target_date.AddDays(60);
            form.setValue("fuel_id", str_fuel_id);
            form.setValue("data_source", str_data_source);
            form.setValue("start_date", target_date.ToString("yyyy/MM/dd"));
            form.setValue("end_date", end_date.ToString("yyyy/MM/dd"));
            form.setValue("card_id", card_id);
            DataSet ds = model.getFuelUse(form);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch { }
        finally { dao.close(); }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            //移動變色
            e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //確認 / 審核欄顯示
            Mediator med = new Mediator();
            if (drv["data_source"].ToString() == "CPC")
            {
                //e.Row.Cells[10].Text = med.lookupParamName("CFM_STS", drv["cfm_status"].ToString(), 0);
            }
            else
            {
                //e.Row.Cells[10].Text = med.lookupParamName("ADT_STS", drv["adt_status"].ToString(), 0);
            }
        }
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Download")
        {
            string AttachId = GridView1.DataKeys[index].Values[1].ToString();
            string filename = GridView1.DataKeys[index].Values[2].ToString();
            string CreateUser = GridView1.DataKeys[index].Values[3].ToString();

            try
            {

            }
            catch (Exception ex)
            {

            }

        }
    }


    /// <summary>
    /// 選擇勤務的按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        Boolean flag = true;
        if (flag && card_id.Value == string.Empty)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請選擇加油卡卡號!");
        }     

        if (flag && deal_date.Value == string.Empty)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請選擇交易日期!");
        }

        if (flag && data_source.Value != string.Empty)
        { 
            Page page = Parent.Page;
            page.ClientScript.RegisterStartupScript(page.GetType(), "onload", "<script type='text/javascript'>openPage()</script>");
        }
    }


    protected void ibDel_Command(object sender, CommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        int Id = System.Convert.ToInt32(GridView1.DataKeys[index].Values[0].ToString().Trim());

        try
        {

        }
        catch
        {

        }


    }
}