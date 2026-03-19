using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class TDOSf002_TDOSf002U2 : System.Web.UI.UserControl
{
    public string WorkNo
    {
        get { return this.work_no.Value; }
        set { this.work_no.Value = value; }
    }

    public string CRSArea
    {
        get { return this.crs_area.Value; }
        set { this.crs_area.Value = value; }
    }
    
    public string RepairItem
    {


        get { return this.repair_item.Value; }
        set
        {
            this.repair_item.Value = value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {   
    
           
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Response.Write(123);
    }
        public void refresh()
    {
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "deleteAllRows();tableCreate();", "MyFunction()", true);
    }

    #region//加註已報修過_wenny_1061207
    //public void notified()
    //{

    //    #region
    //    if (Request.Url.Segments[1].ToUpper().Contains(IniValue.sysCRS))
    //    {
    //        string sql = @"select t.component_no,a.repair_id, a.car_id, a.crs_org, a.case_no, a.work_no, a.repair_vender, a.check_result, 
    //                              case when c.notify_type = 'C' then b.dep_no else c.machine_no end as dep_no, 
    //                              case when c.notify_type = 'C' then b.car_no else '-' end as car_no, b.car_type, c.repair_type1, c.repair_type2, 
    //                              c.repair_type3, c.notify_type, c.machine_type, c.machine_org,
    //                              convert(varchar(10), c.notify_date, 111) as notify_date,
    //                              dbo.chineseDate(a.finish_date) as finish_date
    //                        from f_repair_mst a 
    //                           left join c_car_mst b on a.car_id = b.car_id 
    //                           left join f_notify_mst c on a.work_no = c.work_no 
    //                           left join 
    //                               (select t.component_no,t.repair_id
    //                                 from( 
    //                                               select a.*
    //                                from( 
    //                                                     select c.component_no, a.repair_id,
    //                                       b.budget_area, 
    //                                           case when budget_area = 1 then c.budget1  when budget_area = 3 then c.budget3
    //    		                                 when budget_area = 4 then c.budget4 else c.budget2 end as budget 
    //                                from f_repair_dtl a 
    //                                                     left join f_repair_mst b on a.repair_id = b.repair_id 
    //                                                     left join e_component_mst c on a.component_no = c.component_no
    //                                )a 
    //                             )t
    //                               )t on t.repair_id = a.repair_id 
    //                        where    
    //                        c.notify_date between dateadd(year,-1 ,GETDATE()) and GETDATE()
    //                            --c.notify_date between '2015-01-01 08:30:00.000' and '2016-12-30 08:30:00.000'
                               
    //                            and dep_no = @dep_no";
    //        //and component_no = @component_no";
    //        //and component_no = @component_no";//and dep_no='93-598'



    //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebConnectionString"].ToString()))
    //        {
    //            string str = "";

    //            using (SqlCommand cmd = new SqlCommand(sql, con))
    //            {
    //                con.Open();

    //                string componentNo = Session["componentNo"].ToString();
    //                //if (string.IsNullOrEmpty(componentNo))
    //                //{ componentNo = ""; }//105AB0017
    //                String depOrg = Session["DEPORG"].ToString();
    //                cmd.Parameters.AddWithValue("@dep_no", depOrg);
    //                //cmd.Parameters.AddWithValue("@dep_no", "93-598");
    //                //cmd.Parameters.AddWithValue("@component_no", componentNo);
    //                SqlDataReader dr = cmd.ExecuteReader();
    //                //if (dr.HasRows) { str = "託修作業資料尚未建置完整"; }
    //                while (dr.Read())
    //                { str = str + dr["notify_date"].ToString() + dr["component_no"].ToString() + "\\n "; }
    //                //{ str = str + dr["dep_no"].ToString() + dr["notify_date"].ToString() + dr["component_no"].ToString() + "\\n "; }
    //                con.Close();
    //            }


    //            if (!string.IsNullOrEmpty(str))
    //            {
    //                SysMsg.AlertMessage(this.Page, str);
    //                Session["NOTIFIED"] = str;

    //            }
    //            else
    //            { Session["NOTIFIED"] = ""; }


    //        }
    //    }
    //    #endregion
    //}

    #endregion

}