using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Common_work_item : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlTag hTag = new HtmlTag();
        if (!IsPostBack)
        {
            Form form = new Form();
            form.setValue("car_witem", Request["car_witem"]);
            form.setValue("mchn_witem", Request["mchn_witem"]);
            form.setValue("work_type", Request["work_type"]);

            if (form.getValue("work_type") == "C")
            {
                hTag.createMediatorCheckBox("CAR_WITEM", work_item, form.getValue("car_witem"), "", 0);
            }
            else
            {
                hTag.createMediatorCheckBox("MCHN_WITEM", work_item, form.getValue("mchn_witem"), "", 0);
            }
            work_type.Value = form.getValue("work_type");
        }
    }


    public String getWorkItemSelected()
    {
        string str_work_item = string.Empty;

        str_work_item = HandleParam.getMultiValue(work_item);

        return str_work_item;
    }


    protected void work_item_SelectedIndexChanged(object sender, EventArgs e)
    {
        Mediator med = new Mediator();
        string ctrl_id = string.Empty;
        if (work_type.Value == "C")
        {
            ctrl_id = "car_witem";
        }
        else
        {
            ctrl_id = "mchn_witem";
        }
        //string selected_item = "window.parent.document.getElementById('MasterPage_ContentPlaceHolder1_" + ctrl_id + "').innerHTML='" +
        //  HandleParam.getMultiValue(work_item) + "';";

        string selected_item = "window.parent.document.getElementById('MasterPage$ContentPlaceHolder1$" + ctrl_id + "').value='" +
          HandleParam.getMultiValue(work_item) + "';";

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "onload", "<script type='text/javascript'>"
            + selected_item + " window.parent.document.getElementById('MasterPage$ContentPlaceHolder1$selected_item').value='" +
             med.lookupParamNameMulti(ctrl_id.ToUpper(), HandleParam.getMultiValue(work_item), 0) + "';</script>");



    }
}