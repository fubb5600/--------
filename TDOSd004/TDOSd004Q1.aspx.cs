using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
using System.Text.RegularExpressions;
/// <summary>
///  留廠車輛報表  
/// </summary>
public partial class TDOSd004_TDOSd004Q1 : System.Web.UI.Page
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
                    btnQuery.Visible = userID.hasFunc("TDOSd004_query");
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










                        crs_org.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                    }

                    crs_org.SelectedValue = userID.getUserOrg1();
                    if (userID.getUserRead() == "SELF")
                    {
                        crs_org.Enabled = false;

                    }

                }


                DateTime dt;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                {
                    dt = DateTime.Now.AddDays(-3);
                }
                else
                    dt = DateTime.Now.AddDays(-1);

                report_date.Text = DateTransfer.c_date_intrans(dt.ToString("yyyy/MM/dd"));
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
    /// 產出報表按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        Double dCarCount = 0;        
        try
        {
            UserID userID = (UserID)Session["UserID"];

            dao.open();

            Form form = new Form();
            form.setValue("report_date", DateTransfer.c_date_trans(report_date.Text.Trim()));
            if (crs_org.SelectedValue == "")
            {
                form.setValue("crs_org", userID.getUserOrg()
             );

            }
            else
            {
                form.setValue("crs_org", HandleParam.getMultiValue(crs_org));


            }
            ReportModel model = new ReportModel();
            model.dao = dao;
            ArrayList al = model.TDOSd004(form);
            ArrayList al_car = model.TDOSd004_Car(form);
            if (al_car.Count == 1)
            {
                try
                {
                    Hashtable ht_car = (Hashtable)al_car[0];
                    dCarCount = Int32.Parse(ht_car["CAR_SUM"].ToString());
                }
                catch (Exception ex)
                {
                    dCarCount = 0;
                }
            }

            ExcelUtility excel = new ExcelUtility();

            //設定style
            HSSFFont HtitleFont = excel.CreateFont(14, "標楷體", true);
            HSSFFont HdateFont = excel.CreateFont(10, "標楷體", true);
            HSSFFont TitleFont = excel.CreateFont(12, "標楷體", true);
            HSSFFont ContFont = excel.CreateFont(12, "標楷體", true);
            HdateFont.Boldweight = 1;
            ContFont.Boldweight = 1;
            HSSFCellStyle styleHtitle = excel.CreateWordStyle(HtitleFont, ExcelUtility.ALIGN_CENTER, false, true);
            HSSFCellStyle styleHdateR = excel.CreateWordStyle(HdateFont, ExcelUtility.ALIGN_RIGHT, false, true);
            HSSFCellStyle styleHdateL = excel.CreateWordStyle(HdateFont, ExcelUtility.ALIGN_LEFT, false, true);
            HSSFCellStyle styleTitleC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleTitleL = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleTitleR = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContC = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContL = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleContR = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleSumC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleSumR = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContF = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00");
            HSSFCellStyle styleContM = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "###,##0");
            //excel.fillCellColor(styleTitleC, HSSFColor.LIGHT_CORNFLOWER_BLUE.index);           
            excel.fillCellColor(styleSumC, HSSFColor.TAN.index);
            excel.fillCellColor(styleSumR, HSSFColor.TAN.index);
            excel.CreateSheet();
            //預設列高
            excel.SetDefaultRowHeight(40);

            //表頭
            excel.CreateRow(0);
            excel.SetRowHeight(40);
            excel.AddMergedRegion(0, 0, 0, 8);
            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局報修車輛留廠現況統計表");

            //列印日期
            excel.CreateRow(1);
            excel.AddMergedRegion(1, 1, 0, 1);
            excel.CreateCell(styleHdateL, 0, "報表日期：" + report_date.Text.Trim());
            excel.AddMergedRegion(1, 1, 2, 6);
            excel.CreateCell(styleHdateL, 2, "堪用率：" + String.Format("{0:0.00%}",  1 - (Double.Parse(al.Count.ToString()) / dCarCount))+ " [1-留廠車輛數/現有車輛總數] x 100 %");
            excel.AddMergedRegion(1, 1, 7, 8);
            excel.CreateCell(styleHdateR, 7, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

            //標題
            excel.CreateRow(2);
            excel.CreateCell(styleTitleC, 0, "局編號");
            excel.SetColumnWidth(0, 100);
            excel.CreateCell(styleTitleC, 1, "車號");
            excel.SetColumnWidth(1, 80);
            excel.CreateCell(styleTitleC, 2, "單位");
            excel.SetColumnWidth(2, 110);
            excel.CreateCell(styleTitleC, 3, "報修時間");
            excel.SetColumnWidth(3, 85);
            excel.CreateCell(styleTitleC, 4, "派工單號");
            excel.SetColumnWidth(4, 80);
            excel.CreateCell(styleTitleC, 5, "報修項目");
            excel.SetColumnWidth(5, 175);
            excel.CreateCell(styleTitleC, 6, "委外項目");
            excel.SetColumnWidth(6, 175);
            excel.CreateCell(styleTitleC, 7, "委外廠商");
            excel.SetColumnWidth(7, 100);
            excel.CreateCell(styleTitleC, 8, "履約完成時間");
            excel.SetColumnWidth(8, 85);

            int rows = 2;

            //內容
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                rows++;
                excel.CreateRow(rows);

                excel.CreateCell(styleContL, 0, ht["DEP_NO"].ToString());
                excel.CreateCell(styleContL, 1, ht["CAR_NO"].ToString());
                excel.CreateCell(styleContL, 2, med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0));

                string sNotifyDate = "";
                if (ht["NOTIFY_DATE"].ToString() != string.Empty)
                {
                    if (!ht["NOTIFY_DATE"].ToString().Substring(10, 5).Equals("00:00"))

                        sNotifyDate = ht["NOTIFY_DATE"].ToString();
                    else
                        sNotifyDate = ht["NOTIFY_DATE"].ToString().Substring(0, 9);
                }
                excel.CreateCell(styleContL, 3, sNotifyDate);

                excel.CreateCell(styleContC, 4, ht["WORK_NO"].ToString());
                excel.CreateCell(styleContL, 5, ht["NOTIFY_ITEM"].ToString().Replace('|', '\n'));
                excel.CreateCell(styleContL, 6, ht["REPAIR_OUT"].ToString().Replace('|', '\n'));
                excel.CreateCell(styleContL, 7, ht["REPAIR_VENDER"].ToString().Replace(',', '\n'));

                string sExecDeadline = "";
                if (ht["EXEC_DEADLINE"].ToString() != string.Empty)
                {
                    if (!ht["EXEC_DEADLINE"].ToString().Substring(10, 5).Equals("00:00"))

                        sExecDeadline = ht["EXEC_DEADLINE"].ToString();
                    else
                        sExecDeadline = ht["EXEC_DEADLINE"].ToString().Substring(0, 9);
                }
                excel.CreateCell(styleContL, 8, sExecDeadline);

                excel.SetRowHeight(30 * getLineCount(ht));
            }

            //設定列印配置
            excel.SetPagesize(9);     //A4
            excel.SetLandscape(true);//橫印             
            excel.setScale(100);      //設定縮放 %
            excel.SetMargin(1, 1, 0.5, 1);  //設定邊寬
            excel.SetFooterMargin(0.5);
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 2);

            //輸出檔案
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("臺北市政府環境保護局報修車輛留廠現況統計表.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + "\n" + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
    }

    private Int32 getLineCount(Hashtable ht)
    {
        Int32 count = 1;       

        if (ht["NOTIFY_ITEM"].ToString().Contains("|"))
        {
            string[] array = ht["NOTIFY_ITEM"].ToString().Split('|');
            count = array.Length;
        }

        if (ht["REPAIR_OUT"].ToString().Contains("|"))
        {
            string[] array = ht["REPAIR_OUT"].ToString().Split('|');
            if (array.Length > count)
                count = array.Length;
        }

        if (ht["REPAIR_VENDER"].ToString().Contains("|"))
        {
            string[] array = ht["REPAIR_VENDER"].ToString().Split('|');
            if (array.Length > count)
                count = array.Length;
        }
        return count;
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


    /// <summary>
    /// 上月按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnToday_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Now;
        DateTime start = new DateTime(today.Year, today.Month, 1);
        DateTime end = start.AddMonths(1).AddDays(-1);
        report_date.Text = DateTransfer.c_date_intrans(start.ToString("yyyy/MM/dd"));

    }


    /// <summary>
    /// 本月按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBefore_Click(object sender, EventArgs e)
    {
        DateTime date;

        try
        {
            date = Convert.ToDateTime(DateTransfer.c_date_trans(report_date.Text));
        }
        catch
        {
            date = DateTime.Now;
        }

        date = date.AddDays(-1);

        report_date.Text = DateTransfer.c_date_intrans(date.ToString("yyyy/MM/dd"));


    }


    /// <summary>
    /// 車輛異動情形顯示在備註
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    protected String getCarChangeEvent(Form form, String car_id)
    {
        String car_chg = string.Empty;
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        try
        {
            if (car_id != string.Empty)
            {
                dao.open();
                ReportModel model = new ReportModel();
                model.dao = dao;
                form.setValue("car_id", car_id);
                ArrayList al = model.TDOSd003_CarChange(form);
                if (al.Count > 0)
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        Hashtable ht = (Hashtable)al[i];
                        car_chg += ht["CHG_DATE"].ToString() + med.lookupParamName("CHG_RSN", ht["CHG_RSN"].ToString(), 0) + "\n";
                    }
                }

                if (car_chg.Length > 2)
                {
                    car_chg = car_chg.Substring(0, car_chg.Length - 1);
                }
            }
        }
        catch { }
        finally { dao.close(); }

        return car_chg;

    }
}