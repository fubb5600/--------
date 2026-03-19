using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;

public partial class TDOSc003_TDOSc003O1 : System.Web.UI.Page
{
    private Boolean isUnusualCheck = true;
    private Boolean isDoSearch = false;

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

                }
            }
            ScriptManager sm = ScriptManager.GetCurrent(this);
            if (sm != null)
            {
                sm.RegisterPostBackControl(btnQuery);
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

    protected void btnReport_Click(object sender, EventArgs e)
    {

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        try
        {
            dao.open();

            dao.CommandSQL = @"SELECT TOP (1000)
                                b.car_no AS 車牌號碼,
                                c.id_name AS 使用單位,
                                CONVERT(date, a.work_start) AS 使用日期起,
                                CONVERT(time, a.work_start) AS 使用時間起,
                                CONVERT(date, a.work_end) AS 使用日期迄,
                                CONVERT(time, a.work_end) AS 使用時間迄,
                                a.memo AS 使用事由,
                                a.work_man AS 駕駛人,
                                a.work_location AS 行車地點,
                                a.mileage_start AS 出場前里程表讀數,
                                a.mileage_end AS 回場後里程表讀數,
                                (a.mileage_end - a.mileage_start) AS 當次行駛公里數,
                                a.yesno AS 是否行駛外縣市,
                                a.location AS 外縣市地點,
                                b.keep_org AS 車輛所屬機關_ID,
                                a.CAR AS 車輛屬性,
                                '' AS 備註
                              FROM c_work_mst a
                              LEFT JOIN v_car b ON a.car_id = b.car_id
                              LEFT JOIN a_sysparam_data c ON b.keep_org = c.param_id AND c.param_type = 'DEP_ORG'
                              WHERE CONVERT(date, a.work_start) >= @start_date
                                AND CONVERT(date, a.work_end) <= @end_date";

            dao.setParam("@start_date", DateTransfer.c_date_trans(start_date.Text.Trim()));
            dao.setParam("@end_date", DateTransfer.c_date_trans(end_date.Text.Trim()));

            if (!string.IsNullOrEmpty(car_no.Text.Trim()))
            {
                dao.CommandSQL += " AND b.car_no LIKE @car_no";
                dao.setParam("@car_no", "%" + car_no.Text.Trim() + "%");
            }

            dao.CommandSQL += " ORDER BY b.car_no, a.work_start";

            ArrayList rows = dao.search();

            ExcelUtility excel = new ExcelUtility();

            HSSFFont HtitleFont = excel.CreateFont(12, "標楷體", true);
            HSSFFont TitleFont = excel.CreateFont(11, "標楷體", true);
            HSSFFont ContFont = excel.CreateFont(11, "標楷體", false);
            HSSFCellStyle styleHtitle = excel.CreateWordStyle(HtitleFont, ExcelUtility.ALIGN_CENTER, false, true);
            HSSFCellStyle styleTitleC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContC = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContL = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleContR = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, true);

            excel.CreateSheet();
            excel.SetDefaultRowHeight(28);

            excel.CreateRow(0);
            excel.AddMergedRegion(0, 0, 0, 16);
            excel.CreateCell(styleHtitle, 0, "勤務記錄使用明細表");

            excel.CreateRow(1);
            excel.CreateCell(styleTitleC, 0, "車牌號碼");
            excel.CreateCell(styleTitleC, 1, "使用單位");
            excel.CreateCell(styleTitleC, 2, "使用日期起");
            excel.CreateCell(styleTitleC, 3, "使用時間起");
            excel.CreateCell(styleTitleC, 4, "使用日期迄");
            excel.CreateCell(styleTitleC, 5, "使用時間迄");
            excel.CreateCell(styleTitleC, 6, "使用事由");
            excel.CreateCell(styleTitleC, 7, "駕駛人");
            excel.CreateCell(styleTitleC, 8, "行車地點");
            excel.CreateCell(styleTitleC, 9, "出場前里程表讀數");
            excel.CreateCell(styleTitleC, 10, "回場後里程表讀數");
            excel.CreateCell(styleTitleC, 11, "當次行駛公里數");
            excel.CreateCell(styleTitleC, 12, "是否行駛外縣市");
            excel.CreateCell(styleTitleC, 13, "外縣市地點");
            excel.CreateCell(styleTitleC, 14, "車輛所屬機關");
            excel.CreateCell(styleTitleC, 15, "車輛屬性");
            excel.CreateCell(styleTitleC, 16, "備註");
            excel.SetColumnWidth(0, 100);
            excel.SetColumnWidth(1, 120);
            excel.SetColumnWidth(2, 90);
            excel.SetColumnWidth(3, 90);
            excel.SetColumnWidth(4, 90);
            excel.SetColumnWidth(5, 90);
            excel.SetColumnWidth(6, 140);
            excel.SetColumnWidth(7, 100);
            excel.SetColumnWidth(8, 110);
            excel.SetColumnWidth(9, 160);
            excel.SetColumnWidth(10, 130);
            excel.SetColumnWidth(11, 130);
            excel.SetColumnWidth(12, 110);
            excel.SetColumnWidth(13, 110);
            excel.SetColumnWidth(14, 120);
            excel.SetColumnWidth(15, 110);
            excel.SetColumnWidth(16, 160);

            int r = 1;
            for (int i = 0; i < rows.Count; i++)
            {
                Hashtable ht = (Hashtable)rows[i];
                r++;
                excel.CreateRow(r);
                excel.CreateCell(styleContL, 0, ht["車牌號碼"].ToString());
                excel.CreateCell(styleContL, 1, ht["使用單位"].ToString());
                {
                    string v = ht["使用日期起"].ToString();
                    v = v.Length >= 10 ? v.Substring(0, 10) : v;
                    v = v.Replace("上", "");
                    v = v.Replace("午", "");

                    excel.CreateCell(styleContC, 2, v);
                }
                excel.CreateCell(styleContC, 3, ht["使用時間起"].ToString());
                {
                    string v2 = ht["使用日期迄"].ToString();
                    v2 = v2.Length >= 10 ? v2.Substring(0, 10) : v2;
                    v2 = v2.Replace("上", "");
                    v2 = v2.Replace("午", "");

                    excel.CreateCell(styleContC, 4, v2);
                }
                excel.CreateCell(styleContC, 5, ht["使用時間迄"].ToString());
                excel.CreateCell(styleContL, 6, ht["使用事由"].ToString());
                excel.CreateCell(styleContL, 7, ht["駕駛人"].ToString());
                excel.CreateCell(styleContL, 8, ht["行車地點"].ToString());
                excel.CreateCell(styleContR, 9, ht["出場前里程表讀數"].ToString());
                excel.CreateCell(styleContR, 10, ht["回場後里程表讀數"].ToString());
                excel.CreateCell(styleContR, 11, ht["當次行駛公里數"].ToString());
                excel.CreateCell(styleContC, 12, ht["是否行駛外縣市"].ToString());
                excel.CreateCell(styleContL, 13, ht["外縣市地點"].ToString());
                // 車輛所屬機關以參數表顯示
                excel.CreateCell(styleContL, 14, med.lookupParamName("DEP_ORG", ht["車輛所屬機關_ID"].ToString(), 0));
                excel.CreateCell(styleContL, 15, ht["車輛屬性"].ToString());
                excel.CreateCell(styleContL, 16, ht["備註"].ToString());
            }

            excel.SetPagesize(9);
            excel.SetLandscape(true);
            excel.setScale(100);
            excel.SetMargin(1, 1, 0.5, 1);

            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("勤務記錄使用明細表.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/vnd.ms-excel";
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.Flush();
            Response.End();
            return;
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
  
    protected void btnLastMonth_Click(object sender, EventArgs e)
    {
        DateTime lastMonth = DateTime.Now;

        try
        {
            lastMonth = Convert.ToDateTime(DateTransfer.c_date_trans(start_date.Text));
        }
        catch
        {
            lastMonth = DateTime.Now;
        }

        lastMonth = lastMonth.AddMonths(-1);
        DateTime start = new DateTime(lastMonth.Year, lastMonth.Month, 1);
        DateTime end = start.AddMonths(1).AddDays(-1);
        start_date.Text = DateTransfer.c_date_intrans(start.ToString("yyyy/MM/dd"));
        end_date.Text = DateTransfer.c_date_intrans(end.ToString("yyyy/MM/dd"));

    }
    protected void btnThisMonth_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Now;
        DateTime start = new DateTime(today.Year, today.Month, 1);
        DateTime end = start.AddMonths(1).AddDays(-1);
        start_date.Text = DateTransfer.c_date_intrans(start.ToString("yyyy/MM/dd"));
        end_date.Text = DateTransfer.c_date_intrans(end.ToString("yyyy/MM/dd"));
    }

    

 

}
