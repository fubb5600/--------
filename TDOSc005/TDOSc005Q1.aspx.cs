using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
///載重資料匯入：查詢頁
/// </summary>
public partial class TDOSc005_TDOSc005Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();        
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();

            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限
                    btnQuery.Visible = userID.hasFunc("TDOSc005_query");
                    btnInsert.Visible = userID.hasFunc("TDOSc005_insert");
                }

                LoadModel model = new LoadModel();
                model.dao = dao;
                //2019/07/29
                report_y.Items.Insert(0, new ListItem("請選擇", ""));

                int year = int.Parse(DateTime.Now.ToString("yyyy")) - 1911;
                for (int i = 0; i <= 10; i++)
                {
                    report_y.Items.Add(new ListItem((year - i).ToString(), (year - i).ToString()));


                }
                report_m.Items.Insert(0, new ListItem("請選擇", ""));

                for (int i = 0; i < 9; i++)
                {
                    report_m.Items.Add(new ListItem(0 + (i + 1).ToString()));


                }

                for (int i = 9; i < 12; i++)
                {
                    report_m.Items.Add(new ListItem((i + 1).ToString()));


                }
                //分頁設定
                //查詢資料
                Form form = new Form();
                PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
                pb.setDBDAO(dao);
                DataSet ds = pb.doSearch(model, "browse2");
                String orgValue = "";
                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    orgValue = form.getValue("load_org");
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                }

                report_y.Text = form.getValue("report_y");
                report_m.Text = form.getValue("report_m");
                load_start.Text = form.getValue("load_start");
                load_end.Text = form.getValue("load_end");
                imp_id.Text = form.getValue("imp_id");
                car_no.Text = form.getValue("car_no");
                hTag.createMediatorCheckBox("LOAD_ORG", load_org, orgValue, 0);

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


    /// <summary>
    /// GridView1_RowDataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            //e.Row.Cells[7].Text = statusText;           
        }
    }


    /// <summary>
    /// 新增按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSc005I1.aspx", "", this));
    }


    /// <summary>
    /// 查詢按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", HandleParam.addZero(report_y.Text.Trim(), 3));
            form.setValue("report_m", HandleParam.addZero(report_m.Text.Trim(), 2));
            form.setValue("load_start", load_start.Text.Trim());
            form.setValue("load_end", load_end.Text.Trim());
            form.setValue("imp_id", imp_id.Text.Trim());
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("load_org", HandleParam.getMultiValue(load_org));
            LoadModel model = new LoadModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2");
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


    /// <summary>
    /// gvMain_RowDeleting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBDAO dao = new DBDAO();
        string imp_id = gvMain.DataKeys[e.RowIndex].Values[0].ToString().Trim();
         try
        {
            dao.open();
            dao.beginTransaction();
            LoadModel model = new LoadModel();
            model.dao = dao;
            model.deleteLoadImp(imp_id);
            model.deleteLoadMst(imp_id);
            dao.commit();            
            Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSc005Q1.aspx", "", this) + "'; </script>");
        }
         catch (Exception ex)
         {
             dao.rollback();
             SysMsg.AlertMessage(this.Page, "刪除失敗！\n" + ex.Message);
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