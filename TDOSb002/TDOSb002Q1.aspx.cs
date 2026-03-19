using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
///加油資料匯入：查詢頁
/// </summary>
public partial class TDOSb002_TDOSb002Q1 : System.Web.UI.Page
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
                    btnQuery.Visible = userID.hasFunc("TDOSb002_query") || userID.hasFunc("TDOSb002_update");

                }

                CPCModel model = new CPCModel();
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
                DataSet ds = pb.doSearch(model, "browse1");

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                }

                report_y.Text = form.getValue("report_y");
                report_m.Text = form.getValue("report_m");
                import_start.Text = form.getValue("import_start");
                import_end.Text = form.getValue("import_end");

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
            //e.Row.Cells[7].Text = statusText;           
        }
    }


    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSb002I1.aspx", "", this));
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("report_y", HandleParam.addZero(report_y.Text.Trim(), 3));
            form.setValue("report_m", HandleParam.addZero(report_m.Text.Trim(), 2));
            form.setValue("import_start", import_start.Text.Trim());
            form.setValue("import_end", import_end.Text.Trim());
            CPCModel model = new CPCModel();
            model.dao = dao;
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel, dao);          
            
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


    protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBDAO dao = new DBDAO();
        string export_id = gvMain.DataKeys[e.RowIndex].Values[0].ToString().Trim();
         try
        {
            dao.open();
            dao.beginTransaction();
            CPCModel model = new CPCModel();
            model.dao = dao;
            model.deleteImportMst(export_id);
            model.deleteImportDtl(export_id);
            dao.commit();            
            Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSb002Q1.aspx", "", this) + "'; </script>");
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
}