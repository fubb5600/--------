using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using NPOI.HSSF.Record.Formula.Functions;
/// <summary>
/// 委外託修作業：修改頁
/// </summary>
public partial class TDOSd008_TDOSd008U1 : System.Web.UI.Page
{
  
    string check_result_value = "";
    string is_late_value = "";
    string time_unit_value = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        TDOS tdos = new TDOS();


        try
        {
            if (!IsPostBack)
            {
                //button權限
                HtmlTag hTag = new HtmlTag();
                //btndelete.Visible = userID.hasFunc("TDOSd008_delete");
                Form form = new Form();
                form.setValue("repair_id", Request["repair_id"]);

                RepairModel model = new RepairModel();
                model.dao = dao;
                dao.open();

                DataSet ds = model.Stock(form.getValue("repair_id"));
                DataRow dr = ds.Tables[0].Rows[0];
           
                work_no.Text = dr["Work_no"].ToString();
                User.Text = dr["User2"].ToString();
                User2.Text = dr["User1"].ToString();

                Thing.Text = dr["Thing"].ToString();
                Count.Text = dr["Count"].ToString();
                Car.Text = dr["Car"].ToString();
                Memo.Text = dr["Memo"].ToString();
                No.Text = dr["No"].ToString();
                //UseCar.Text = dr["Use_Car"].ToString();

                //UseNo.Text = dr["Use_No"].ToString();
                //UseTime.Text = dr["Use_Time"].ToString().Substring(0, 9);
                InsertTime.Text = dr["Update_Time1"].ToString().Substring(0, 9);
                Label1.Text = dr["Update_Time"].ToString().Substring(0, 9);



                string status = dr["status"].ToString().Trim();
                if (status == "X")
                {
                    btnSave.Visible = false;


                }
                DataSet dsDtl = model.selectRepairDtl(form.getValue("repair_id"), dr["budget_area"].ToString());
                DataRow drDtl = dsDtl.Tables[0].Rows[0];

               
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
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
       
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {


            dao.open();
            dao.beginTransaction();

          
            Form form = new Form();
            form.setValue("repair_id", Request["repair_id"]);




            RoleModel roleModel = new RoleModel();
            roleModel.dao = dao;
            roleModel.deleteStock(form);
            Response.Write("<script>alert('刪除成功！');  </script>");

           


            dao.commit();
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
            dao.beginTransaction();
            int Count3 = 0;
            int Count4= int.Parse(Count.Text);//數量
            int Count5 = int.Parse(Count1.Text);//使用數量
            Count3 = Count4 - Count5;
            if (UseNo.Text == "" || UseCar.Text == "")


            {
                Response.Write("<script>alert('使用車輛，單號必填');  </script>");


            }
            if (Count3 <0  || Count5==0)


            {
                Response.Write("<script>alert('不能比庫存多！');  </script>");


            }
            if (Count5 < 0  )


            {
                Response.Write("<script>alert('不能小於0');  </script>");


            }

            if (Count3 >= 0 && Count5 != 0)

            {
                Form form = new Form();
                form.setValue("repair_id", Request["repair_id"]);
                form.setValue("Count", Count3.ToString());
                form.setValue("datetime", Label1.Text);


                form.setValue("Work_no", work_no.Text.TrimEnd());
                form.setValue("Car", Car.Text.TrimEnd());
                form.setValue("User1", User2.Text);

                form.setValue("repair_id", Request["repair_id"]);
                form.setValue("Thing", Thing.Text);
                form.setValue("Car", Car.Text);
                form.setValue("Memo", Memo.Text);
                form.setValue("ststus", "O");
                form.setValue("Use_No", UseNo.Text);
                form.setValue("Use_Car", UseCar.Text);
                form.setValue("Use_Time", DateTransfer.c_date_trans(UseTime.Text.Trim()));

                form.setValue("No", No.Text);



                RoleModel roleModel = new RoleModel();
                roleModel.dao = dao;
                roleModel.InsertStock(form);
                roleModel.UpdateStock(form);

                Response.Write("<script>alert('修改成功！');  </script>");




                dao.commit();
                Response.Redirect(Forward.Redirect("TDOSd008Q1.aspx", "", this));
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

  
    /// <summary>
    /// 驗證日期格式
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void DateValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(args.Value));
            args.IsValid = true;
        }
        catch
        {
            args.IsValid = false;
        }
    }

  

  
  

  
  
}
