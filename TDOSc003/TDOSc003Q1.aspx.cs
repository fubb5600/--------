using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 勤務記錄：查詢頁
/// </summary>
public partial class TDOSc003_TDOSc003Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();        
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
        try
        {
            dao.open();

            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限
                    btnQuery.Visible = userID.hasFunc("TDOSc003_query") || userID.hasFunc("TDOSc003_update");
                    btnInsert.Visible = userID.hasFunc("TDOSc003_insert");
                    string a = userID.getUserOrg();
                    string[] a_result = a.Split(',');

                    for (int j = 0; j < a_result.Length; j++)
                    {
                        string b = "";
                        if (a_result[j] == "TT002I591")
                        {
                            b = "士林區清潔隊";


                        }

                        if (a_result[j] == "TT002I592")
                        {
                            b = "大同區清潔隊";


                        }

                        if (a_result[j] == "TT002I593")
                        {
                            b = "大安區清潔隊";


                        }
                        if (a_result[j] == "TT002I594")
                        {
                            b = "中山區清潔隊";


                        }
                        if (a_result[j] == "TT002I595")
                        {
                            b = "中正區清潔隊";


                        }
                        if (a_result[j] == "TT002I598")
                        {
                            b = "公廁管理隊";
                        }
                        if (a_result[j] == "TT002I599")
                        {
                            b = "北投區清潔隊";
                        }
                        if (a_result[j] == "TT002I600")
                        {
                            b = "環境檢驗中心";
                        }

                        if (a_result[j] == "TT002I596")
                        {
                            b = "內湖區清潔隊";

                        }
                        if (a_result[j] == "TT002I597")
                        {
                            b = "文山區清潔隊";
                        }



                        if (a_result[j] == "TT002I601")
                        {
                            b = "松山區清潔隊";


                        }
                        if (a_result[j] == "TT002I602")
                        {
                            b = "直屬清潔隊";


                        }
                        if (a_result[j] == "TT002I603")
                        {
                            b = "信義區清潔隊";
                        }
                        if (a_result[j] == "TT002I604")
                        {
                            b = "南港區清潔隊";
                        }

                        if (a_result[j] == "TT002I605")
                        {
                            b = "政風室";
                        }
                        if (a_result[j] == "TT002I606")
                        {
                            b = "修車廠";
                        }

                        if (a_result[j] == "TT002I607")
                        {
                            b = "秘書室";
                        }
                        if (a_result[j] == "TT002I608")
                        {
                            b = "廢棄物處理場";
                        }

                        if (a_result[j] == "TT002I609")
                        {
                            b = "清山淨水";
                        }
                        if (a_result[j] == "TT002I610")
                        {
                            b = "空污噪音防制科";
                        }
                        if (a_result[j] == "TT002I611")
                        {
                            b = "水質病媒管制科";
                        }
                        if (a_result[j] == "TT002I612")
                        {
                            b = "溝渠一隊";
                        }
                        if (a_result[j] == "TT002I613")
                        {
                            b = "溝渠二隊";
                        }
                        if (a_result[j] == "TT002I614")
                        {
                            b = "萬華區清潔隊";
                        }
                        if (a_result[j] == "TT002I615")
                        {
                            b = "資源回收隊";
                        }
                        if (a_result[j] == "TT002I617")
                        {
                            b = "職業安全管理科";
                        }
                        if (a_result[j] == "TT002I619")
                        {
                            b = "氣候變遷管理科";
                        }
                        if (a_result[j] == "TT002I620")
                        {
                            b = "綜合企劃科";
                        }
                        if (a_result[j] == "TT002I621")
                        {
                            b = "環境清潔管理科";
                        }

                        if (a_result[j] == "TT002I622")
                        {
                            b = "廢棄物處理管理科";
                        }

                        if (a_result[j] == "TT002I623")
                        {
                            b = "資源循環管理科";
                        }










                        keep_org.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                    }
                }
                keep_org.SelectedValue = userID.getUserOrg1();
                if (userID.getUserRead() == "SELF")
                {
                    keep_org.Enabled = false;

                }
                WorkModel model = new WorkModel();
                model.dao = dao;

                //分頁設定
                //查詢資料
                Form form = new Form();
                PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
                pb.setDBDAO(dao);
                DataSet ds = pb.doSearch(model, "browse1");

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                }

                car_no.Text = form.getValue("car_no");
                dep_no.Text = form.getValue("dep_no");
                card_no.Text = form.getValue("card_no");
                work_str.Text = form.getValue("work_str");
                work_end.Text = form.getValue("work_end");
                work_date_str.Text = form.getValue("work_date_str");
                work_date_end.Text = form.getValue("work_date_end");   

                //狀態
                String typeValue = "";
                String orgValue = "";
                String worktype = "";
                String machineValue = "";
                //有預設值，若有查詢過，則以新條件為準

                if (pb.isDoSearch())
                {
                    typeValue = form.getValue("car_type");
                    orgValue = form.getValue("work_org");
                    worktype = form.getValue("work_type");
                    machineValue = form.getValue("worwork_machinek_type");
                }
                else
                {
                    //增加預設查詢條件
                    orgValue = userID.getUserOrg();

                    DateTime today = DateTime.Now;
                    DateTime start = new DateTime(today.Year, today.Month, 1);
                    DateTime end = start.AddMonths(1).AddDays(-1);

                    //2019/07/24更新隱藏
                    //work_str.Text = "";
                    //work_end.Text = "";
                    work_str.Text = DateTransfer.c_date_intrans(start.ToString("yyyy/MM/dd"));
                    work_end.Text = DateTransfer.c_date_intrans(end.ToString("yyyy/MM/dd"));
                }

                hTag.createMediatorCheckBox("CAR_TYPE", car_type, typeValue, "", 0);                
                hTag.createMediatorCheckBox("WORK_TYPE", work_type, worktype, "", 0);
                hTag.createMediatorCheckBox("MACHINE", work_machine, machineValue, "", 0);

              

                if (__EVENTTARGET.Equals("ChangePaging"))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script>chgHash('pb'); </script>");
                }
            }
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
            //e.Row.Cells[6].Text = statusText;           
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSc003I1.aspx", "", this));
    }

    protected void btnO1_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSc003O1.aspx", "", this));
    }


    /// <summary>
    /// 查詢按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];

        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("work_type", HandleParam.getMultiValue(work_type));
            form.setValue("work_str", work_str.Text.Trim());
            form.setValue("work_end", work_end.Text.Trim());
            form.setValue("work_date_str", work_date_str.Text.Trim());
            form.setValue("work_date_end", work_date_end.Text.Trim());
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("card_no", card_no.Text.Trim());            
            form.setValue("work_machine", HandleParam.getMultiValue(work_machine));
            form.setValue("car_type", HandleParam.getMultiValue(car_type));

            if (keep_org.SelectedValue == "")
            {
                form.setValue("work_org", userID.getUserOrg());

            }
            else
            {
                form.setValue("work_org", HandleParam.getMultiValue(keep_org));


            }
            

            WorkModel model = new WorkModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);           
            DataSet ds = pb.doSearch(model, form, "browse1");
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
            }

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


    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string work_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();
        Response.Redirect(Forward.Redirect("TDOSc003U1.aspx?work_id=" + work_id, "", this));
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





    //protected void EXE_Click(object sender, EventArgs e)
    //{
       
      
    //    Process explorer = new Process();
    //    explorer.StartInfo.FileName = "explorer.exe";
    //    explorer.StartInfo.FileName = @"D:\TDOS\WindowsFormsApp8.exe";


    //    explorer.Start();
    //}
}
