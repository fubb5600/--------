using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Common_select_work : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Form form = new Form();
            form.setValue("card_id", Request["card_id"]);
            form.setValue("deal_date", Request["deal_date"]);

            BindFuelUse(form.getValue("card_id"), form.getValue("deal_date"));
        }
    }


    public void BindFuelUse(String str_card_id, String deal_date)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            CPCModel model = new CPCModel();
            model.dao = dao;
            Form form = new Form();
            deal_date = deal_date.Substring(0, 3) + "/" + deal_date.Substring(3, 2) + "/" + deal_date.Substring(5, 2);
            DateTime target_date = Convert.ToDateTime(DateTransfer.c_date_trans(deal_date));
            DateTime end_date = target_date.AddDays(60);
            form.setValue("card_id", str_card_id);
            form.setValue("start_date", target_date.ToString("yyyy/MM/dd"));
            form.setValue("end_date", end_date.ToString("yyyy/MM/dd"));
            DataSet ds = model.getFuelUse(form);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
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

            e.Row.Cells[1].Text = drv["work_start"].ToString() + " ~ " + drv["work_end"].ToString();
           
            //確認 / 審核欄顯示
            Mediator med = new Mediator();
            if (drv["data_source"].ToString() == "CPC")
            {
                //
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

        //if (e.CommandName == "Download")
        //{
        //    string AttachId = GridView1.DataKeys[index].Values[1].ToString();
        //    string filename = GridView1.DataKeys[index].Values[2].ToString();
        //    string CreateUser = GridView1.DataKeys[index].Values[3].ToString();

        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        String work_id = string.Empty;

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            try
            {
                CheckBox cbSelect = (CheckBox)GridView1.Rows[i].FindControl("cbSelect");                
                String work_id_str = GridView1.Rows[i].Cells[3].Text;
                if (cbSelect.Checked == true)
                {
                    work_id += work_id_str + ",";
                }
            }
            catch (Exception ex)
            {
                SysMsg.AlertMessage(this.Page, ex.Message + ex.StackTrace);
            }
        }

        if (work_id.Length > 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "",
                "opener.document.getElementById('MasterPage$ContentPlaceHolder1$fuel_use1$work_id').value = '"
                     + work_id + "';window.close();", true);
        }
    }
}