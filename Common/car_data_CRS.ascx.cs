using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Common_car_data_CRS : System.Web.UI.UserControl
{
    private String sCarId = string.Empty;
    private DataRow drNotify;

    public void setCarId(String sCarId)
    {
        this.sCarId = sCarId;
    }

    public String getCarId()
    {
        return sCarId;
    }

    public void setDrNotify(DataRow dr)
    {
        this.drNotify = dr;
    }

    public DataRow getDrNotify()
    {

        return drNotify;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    public void getNotifyData()
    {
        Mediator med = Mediator.getInstance(true);

        car_no.Text = drNotify["car_no"].ToString();
        dep_no.Text = drNotify["dep_no"].ToString();
        car_type.Text = drNotify["car_type"].ToString();
        brand_no.Text = drNotify["brand_no"].ToString();
        car_status.Text = drNotify["car_status"].ToString();
        keep_org.Text = drNotify["keep_org"].ToString();
        mileage.Text = drNotify["mileage"].ToString();
        driver.Text = drNotify["driver"].ToString();
        machine_no.Text = drNotify["dep_no"].ToString();
        machine_type.Text = med.lookupParamName("MACHINE", drNotify["machine_type"].ToString(), 0);
        machine_org.Text = med.lookupParamName("DEP_ORG", drNotify["machine_org"].ToString(), 0);
          
        if (drNotify["notify_type"].ToString().Equals("C"))
        {
            Session["DEPORG"] = dep_no.Text;//加註已報修過_wenny_1061207 
            pnlCar.Visible = true;
            pnlMachine.Visible = false;
        }
        else if (drNotify["notify_type"].ToString().Equals("M"))
        {
            Session["DEPORG"] = machine_no.Text;//加註已報修過_wenny_1061207 
            pnlCar.Visible = false;
            pnlMachine.Visible = true;
        }
    }

    public void clearNotify()
    {
        car_no.Text = "";
        dep_no.Text = "";
        car_type.Text = "";
        brand_no.Text = "";
        car_status.Text = "";
        keep_org.Text = "";
        mileage.Text = "";
        driver.Text = "";
        machine_no.Text = "";
        machine_org.Text = "";
        machine_type.Text = "";
        Session["DEPORG"] = "";//加註已報修過_wenny_1061207 
    }
}