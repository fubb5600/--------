using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["componentNo"] = ""; // 加註已報修過_wenny_1061207
        Session["DEPORG"] = "";//加註已報修過_wenny_1061207
        Session["NOTIFIED"] = "";//加註已報修過_wenny_1061207
        Response.Write(Session["NOTIFIED"]);
        if (!IsPostBack)
        {

            //BindCarInspectionGrid(car_id.Value);
            BindUnInspectedCar();
            //加註已報修過_wenny_1061207
            notifymsg();
            //notifymsgT();
        }
   
    }



    /// <summary>
    /// 取得車輛狀態歷史資料
    /// </summary>
    /// <param name="car_id"></param>

    public void BindUnInspectedCar()
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            CarInspectionModel model = new CarInspectionModel();
            model.dao = dao;

            DataSet ds = model.selectUnInspectCar();

            gvUnInspected.DataSource = ds.Tables[0];
            gvUnInspected.DataBind();

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

            DateTime inspect_end = DateTime.Parse(drv["inspect_end"].ToString());

            e.Row.Cells[1].Text = med.lookupParamName("DEP_ORG", drv["keep_org"].ToString(), 0);
            e.Row.Cells[4].Text = DateTransfer.c_date_intrans(DateTime.Parse(drv["next_inspection"].ToString()).ToString("yyyy/MM/dd"));
            e.Row.Cells[5].Text = DateTransfer.c_date_intrans(DateTime.Parse(drv["inspect_start"].ToString()).ToString("yyyy/MM/dd")) + "~"
                + DateTransfer.c_date_intrans(inspect_end.ToString("yyyy/MM/dd"));

            if (inspect_end < DateTime.Now.Date)
                e.Row.Attributes["style"] = "color:red";

        }
    }


    protected void gvInspection_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string car_id = gvUnInspected.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("../TDOSc001/TDOSc001U1.aspx?car_id=" + car_id, "", this));
    }



    #region//提醒託修作業資料未建置完整_WENNY_1061206
    private void notifymsg()
    {
        Session["NOTIFYMSG"] = "";
        if (Request.Url.Segments[1].ToUpper().Contains(IniValue.sysCRS))
        {
            // 報修五天內填完資料_wenny_1061201
            //107.01.01之後且報修日期五天後，該帳號報修完工日期未填寫資料
            //string sqlNotify = @"select top 5 a.notify_type, a.notify_id, a.car_id, a.crs_org, a.work_no, convert(varchar(10), notify_date, 111) as notify_date, 
            //                   convert(varchar(10), a.finish_date, 111) as finish_date, a.notify_item, case when notify_type = 'C' then b.dep_no else machine_no end as dep_no, 
            //                   case when notify_type = 'C' then b.car_no else '-' end as car_no, b.keep_org, a.repair_type1, a.repair_type2, a.repair_type3, a.repair_status, 
            //                   case when notify_type = 'C' then b.car_type else a.machine_type end as car_type from f_notify_mst a 
            //                   left join v_car b on a.car_id = b.car_id
            //                    WHERE DATEDIFF( day,[notify_date] ,GETDATE()) >5 
            //              AND  notify_date > convert(varchar(10),'2018-01-01',120)
            //              AND (a.create_user = @create_user OR a.update_user = @create_user)
            //              and a.finish_date is null
            //                  order by notify_date desc ";
            string sqlNotify = @" declare @now datetime = getdate() 
                                select top 5  work_no
                                from f_notify_mst                               
                                WHERE  notify_date <= dateadd( day,-6,@now ) 
                                      AND  notify_date >= '2018-01-02'
                                      AND (create_user = @create_user OR update_user = @create_user)
                                      and finish_date is null
                                order by notify_date desc ";

            // 107.01.01之後且報修日期五天後，該帳號未建置委外託修
            //    string sqlRpairNone = @"select top 5 * from(select  a.notify_type, a.notify_id, a.car_id, a.crs_org, a.work_no, convert(varchar(10), a.notify_date, 111) as notify_date, 
            //                       convert(varchar(10), a.finish_date, 111) as finish_date, a.notify_item, case when notify_type = 'C' then b.dep_no else machine_no end as dep_no, 
            //                       case when notify_type = 'C' then b.car_no else '-' end as car_no, b.keep_org, a.repair_type1, a.repair_type2, a.repair_type3, a.repair_status, 
            //                       case when notify_type = 'C' then b.car_type else a.machine_type end as car_type
            //                      from f_notify_mst a 
            //                       left join v_car b on a.car_id = b.car_id
            //                       WHERE      DATEDIFF( day,[notify_date] ,GETDATE()) >5 
            //                  AND  notify_date > convert(varchar(10),'2018-01-01',120)
            //                  AND (a.create_user = @create_user OR a.update_user = @update_user)
            //                  and a.finish_date is null
            //and repair_type1 ='out'
            //                        )as a where not exists  (select * from f_repair_mst as b where a.work_no= b.work_no)
            //                         order by a.notify_date desc";

            string sqlRpairNone = @" declare @now datetime = getdate() 
                                     select top 5  a.work_no
                                     from f_notify_mst a 
                                     WHERE notify_date <= dateadd( day,-6 ,@now) 
                                        AND  notify_date >= '2018-01-02'
                                        AND (a.create_user = @create_user OR a.update_user = @update_user)
                                        and a.finish_date is null
                                        and repair_type1 ='out' and  
                                        not exists  (select b.work_no,b.notify_date from f_repair_mst as b where a.work_no= b.work_no)
                                        order by a.notify_date desc";

            //107.01.01之後且報修日期五天後，該帳號委外託修資料未填寫完整
            //string sqlRepair = @"select top 5 a.repair_id, a.car_id, a.crs_org, a.case_no, a.work_no, a.repair_vender, a.check_result, 
            //                      case when c.notify_type = 'C' then b.dep_no else c.machine_no end as dep_no, 
            //                      case when c.notify_type = 'C' then b.car_no else '-' end as car_no, b.car_type, c.repair_type1, c.repair_type2, 
            //                      c.repair_type3, c.notify_type, c.machine_type, c.machine_org, dbo.chineseDate(c.notify_date) as notify_date, 
            //                      dbo.chineseDate(a.finish_date) as finish_date, t.total_price from f_repair_mst a 
            //                      left join c_car_mst b on a.car_id = b.car_id 
            //                      left join f_notify_mst c on a.work_no = c.work_no 
            //                      left join (select t.repair_id, sum(t.subtotal) as total_price from( 
            //                      select a.*, a.count* a.budget as subtotal from( 
            //                      select a.repair_id, a.count, b.budget_area, case when budget_area = 1 then c.budget1  when budget_area = 3 then c.budget3
            //                       when budget_area = 4 then c.budget4 else c.budget2 end as budget from f_repair_dtl a 
            //                       left join f_repair_mst b on a.repair_id = b.repair_id 
            //                        left join e_component_mst c on a.component_no = c.component_no) a )t group by t.repair_id) t on t.repair_id = a.repair_id 
            //               where
            //                  DATEDIFF(day,c.notify_date ,GETDATE()) >5 
            //                  AND  c.notify_date >convert(varchar(10),'2018-01-01',120)
            //                  AND  (a.create_user=@create_user OR a.update_user=@update_user)
            //                  AND (a.repair_vender is null or a.check_result is null or a.finish_date is null or total_price  is null )
            //                order by notify_date desc ";

            string sqlRepair = @"  declare @now datetime = getdate() 
                                select top 5 a.work_no
                                from f_repair_mst a
                                    left join f_notify_mst c on a.work_no = c.work_no
                                    left join(select t.repair_id, sum(t.subtotal) as total_price
                                                    from(select a.repair_id, a.count * a.budget as subtotal
                                                        from(select a.repair_id, a.count, b.budget_area,
									                                case when budget_area = 1 then c.budget1
                                                                         when budget_area = 3 then c.budget3
                                                                         when budget_area = 4 then c.budget4 else c.budget2
                                                                    end as budget
                                                               from f_repair_dtl a
                                                                    left join f_repair_mst b on a.repair_id = b.repair_id
                                                                    left join e_component_mst c on a.component_no = c.component_no
                                                            ) a
                                                        )t
                                                    group by t.repair_id
			                                 ) t on t.repair_id = a.repair_id
                                where c.notify_date <= dateadd(day, -6, @now)
                                        AND c.notify_date >= '2018-01-02'
                                        AND(a.create_user = @create_user OR a.update_user = @update_user)
                                        AND(a.repair_vender is null or a.check_result is null or a.finish_date is null or total_price is null)
                                order by c.notify_date desc  ";

            string user = (string)Session["user"];

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebConnectionString"].ToString()))
            {
                //StringBuilder sb1 = new StringBuilder();
                //StringBuilder sb2 = new StringBuilder();
                //StringBuilder sb3 = new StringBuilder();
                //StringBuilder sbAll = new StringBuilder();
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sqlNotify, con))
                {

                    cmd.Parameters.AddWithValue("@create_user", user);
                    cmd.Parameters.AddWithValue("@update_user", user);
        
                    using (SqlDataReader drNotify = cmd.ExecuteReader())
                    {

                        //if (drSelf.HasRows) { str = "託修作業資料尚未建置完整"; }
                        while (drNotify.Read())
                        {
                            //sb1.Append("         派工單編號:" + drSelf["work_no"].ToString() + "\\n");
                            str1 = str1 + "派工單編號:" + drNotify["work_no"].ToString() + "\\n";
                        }
                        //{ str = str + "strS派工單編號:" + drSelf["work_no"].ToString() + "車號:" + drSelf["car_no"].ToString() + "報修日期" + drSelf["notify_date"].ToString() + "\\n"; }
                        //cmd.Cancel();
                        //drNotify.Close();
                    }


                    //con.Close();
                }
                if (!string.IsNullOrEmpty(str1))
                { str1 = "下列派工單編號「 車輛報修資料 」尚未建置完整 : \\n\\n" + str1; }
                using (SqlCommand cmd = new SqlCommand(sqlRpairNone, con))
                {
                    //con.Open();
                    cmd.Parameters.AddWithValue("@create_user", user);
                    cmd.Parameters.AddWithValue("@update_user", user);
                    using (SqlDataReader drRpairNone = cmd.ExecuteReader())
                    {
                        //SqlDataReader drRpairNone = cmd.ExecuteReader();
                        //if (drSelf.HasRows) { str = "託修作業資料尚未建置完整"; }
                        while (drRpairNone.Read())
                        {
                            //sb2.Append("         派工單編號:" + drRpairNone["work_no"].ToString() + "\\n");
                            str2 = str2 + "派工單編號:" + drRpairNone["work_no"].ToString() + "\\n";
                        }
                        //cmd.Cancel();
                        //drRpairNone.Close();
                    }
                    //{ str = str + "strS派工單編號:" + drSelf["work_no"].ToString() + "車號:" + drSelf["car_no"].ToString() + "報修日期" + drSelf["notify_date"].ToString() + "\\n"; }

                    //con.Close();
                }
                if (!string.IsNullOrEmpty(str2))
                { str2 = "下列派工單編號「 尚未新增託修資料 」 : \\n\\n" + str2; }
                using (SqlCommand cmd = new SqlCommand(sqlRepair, con))
                {
                    //con.Open();
                    cmd.Parameters.AddWithValue("@create_user", user);
                    cmd.Parameters.AddWithValue("@update_user", user);
                    using (SqlDataReader drRepair = cmd.ExecuteReader())
                    {
                        //SqlDataReader dr2 = cmd.ExecuteReader();
                        //if (dr2.HasRows) { str = "託修作業資料尚未建置完整"; }
                        while (drRepair.Read())
                        {
                            //sb3.Append("         派工單編號:" + dr2["work_no"].ToString() + "\\n");
                            str3 = str3 + "派工單編號:" + drRepair["work_no"].ToString() + "\\n";
                        }
                        //cmd.Cancel();
                        //drRepair.Close();
                    }
                    //{ str =  str + "strY"+"派工單編號:" + dr2["work_no"].ToString() + "車號:" + dr2["car_no"].ToString() + "報修日期" + dr2["notify_date"].ToString() + "\\n"; }
                    con.Close();
                }
                if (!string.IsNullOrEmpty(str3))
                { str3 = "下列派工單編號「 託修資料 」尚未建置完整: \\n\\n" + str3; }


                if (!string.IsNullOrEmpty(str1) || !string.IsNullOrEmpty(str2) || !string.IsNullOrEmpty(str3))
                {
                    str = str1 + "\\n" + str2 + "\\n" + str3;
                    SysMsg.AlertMessage(this.Page, str);
                    Session["NOTIFYMSG"] = str;
                    //Session["NOTIFYMSG"] = "yes";
                }
                else
                { Session["NOTIFYMSG"] = ""; }

            }
        }
        else
        { Session["NOTIFYMSG"] = ""; }
    }
    #endregion

    #region test
    private void notifymsgT()
    {
        Session["NOTIFYMSG"] = "";
        if (Request.Url.Segments[1].ToUpper().Contains(IniValue.sysCRS))
        {

            string sql = @" declare @now datetime = getdate()
                            select top 5 n.work_no as nWork,n.notify_date as nNotifydate,n.finish_date as nFinishdate,n.repair_type1 as nRepairtype,
                                    rm.work_no as rmWorkno,rm.notify_date as rmNotifydate ,
	                                rm.check_result as rmCheck , rm.finish_date as rmFinishdate , rd.[count] as rdCount
                                               --rd.*,cm.* --
                           from f_notify_mst n
                                           left join f_repair_mst rm on n.work_no = rm.work_no
                                           left join f_repair_dtl rd on rm.repair_id = rd.repair_id
                                           left join e_component_mst cm on rd.component_no = cm.component_no
                          where  n.notify_date <= dateadd(day, -6,@now) 
                                          AND n.notify_date >= '2018-01-02'
                                          AND(n.create_user = @create_user OR n.update_user = @update_user)
                                          --AND(n.repair_type1='OUT')
                                          AND(n.finish_date is null or rm.work_no is null or rm.repair_vender is null or rm.check_result is null or rm.finish_date is null or rd.[count] is null)
                                                                  --or total_price is null
                                          order by n.notify_date desc ";

            string user = (string)Session["user"];

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebConnectionString"].ToString()))
            {
                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();
                StringBuilder sb3 = new StringBuilder();
                StringBuilder sbAll = new StringBuilder();
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                  
                    cmd.Parameters.AddWithValue("@create_user", user);
                    cmd.Parameters.AddWithValue("@update_user", user);
                    SqlDataReader drSelf = cmd.ExecuteReader();
                   
                    //if (drSelf.HasRows) { str = "託修作業資料尚未建置完整"; }
                    while (drSelf.Read())
                    {
                        if (string.IsNullOrEmpty(drSelf["nFinishdate"].ToString()))
                            sb1.Append("         派工單編號:" + drSelf["nWork"].ToString() + "\\n");
                        if (string.IsNullOrEmpty(drSelf["rmWorkno"].ToString()))
                                sb2.Append("         派工單編號:" + drSelf["nWork"].ToString() + "\\n");
                        else if (string.IsNullOrEmpty(drSelf["rmCheck"].ToString()) || string.IsNullOrEmpty(drSelf["rmFinishdate"].ToString()) || string.IsNullOrEmpty(drSelf["rdCount"].ToString()))
                                sb3.Append("         派工單編號:" + drSelf["nWork"].ToString() + "\\n");
                   
                    }

                    //con.Close();
                }
                if (!string.IsNullOrEmpty(sb1.ToString()))
                { str1 = "下列派工單編號「 車輛報修資料 」尚未建置完整 : \\n\\n" + sb1.ToString(); }
                if (!string.IsNullOrEmpty(sb2.ToString()))
                { str2 = "下列派工單編號「 尚未新增託修資料 」 : \\n\\n" + sb2.ToString(); }
                if (!string.IsNullOrEmpty(sb3.ToString()))
                { str3 = "下列派工單編號「 託修資料 」尚未建置完整: \\n\\n" + sb3.ToString(); }
                if (!string.IsNullOrEmpty(sb1.ToString()) || !string.IsNullOrEmpty(sb2.ToString()) || !string.IsNullOrEmpty(sb3.ToString()))
                {
                    str = str1 + "\\n" + str2 + "\\n" + str3;
                    SysMsg.AlertMessage(this.Page, str);
                    Session["NOTIFYMSG"] = str;
                    //Session["NOTIFYMSG"] = "yes";
                }
                else
                { Session["NOTIFYMSG"] = ""; }

            }
        }
        else
        { Session["NOTIFYMSG"] = ""; }
    }
    #endregion
}