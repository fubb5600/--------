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

/// <summary>
///  車輛定檢月報表   
/// </summary>
public partial class TDOSd006_TDOSd006Q1 : System.Web.UI.Page
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
                    btnQuery.Visible = userID.hasFunc("TDOSd006_query");
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
                    keep_org.SelectedValue = userID.getUserOrg1();
                    if (userID.getUserRead() == "SELF")
                    {
                        keep_org.Enabled = false;

                    }

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
    /// 產出報表按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];

        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        TDOS tdos = new TDOS();
        try
        {
            dao.open();

            Form form = new Form();
            string strREPORTYMD = DateTransfer.c_date_trans(txtReport_YM.Text.Trim() + "/01");//轉【西元年/月/日】字串
            string strREPORTYM = strREPORTYMD.Substring(0, 4) + strREPORTYMD.Substring(5, 2);//組西元年月
            DateTime start_date = DateTime.Parse(DateTransfer.c_date_trans(txtReport_YM.Text.Trim() + "/01"));
            DateTime end_date = start_date.AddMonths(1).AddDays(-1);
            int InspectRange_Start = int.Parse(start_date.AddDays(-30).ToString("MMdd"));
            int InspectRange_End = int.Parse(end_date.AddDays(30).ToString("MMdd"));

            form.setValue("report_ym", strREPORTYM);//form需設為西元年月，因為SQL語法是用西元年月來接
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg()
             );

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("start_date", start_date.ToString("yyyy/MM/dd"));
            form.setValue("end_date", end_date.ToString("yyyy/MM/dd"));
            ReportModel model = new ReportModel();
            model.dao = dao;
            //ArrayList al = model.TDOSd006(form); 
            ArrayList al = model.TDOSd006_CAR(form);
            ArrayList alINSPECTED = model.TDOSd006_INSPECTED(form);
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                for (int j = 0; j < alINSPECTED.Count; j++)
                {
                    Hashtable htINSPECTED = (Hashtable)alINSPECTED[j];

                    if (ht["CAR_ID"].ToString() == htINSPECTED["CAR_ID"].ToString())
                    {
                        ht["INSPECTION_DATE"] = htINSPECTED["INSPECTION_DATE"].ToString();
                        ht["INSPECTION_STATUS"] = htINSPECTED["INSPECTION_STATUS"].ToString();
                    }
                }
                if (ht["NEXT_INSPECTION"] != string.Empty)
                {
                    int Next_Inspect = int.Parse(ht["NEXT_INSPECTION"].ToString().Substring(4, 4));
                    if (InspectRange_Start < InspectRange_End)
                    {
                        if (Next_Inspect > InspectRange_Start && Next_Inspect < InspectRange_End)
                        {
                            ht["INSPECTION_STATUS"] = "0";
                        }
                    }

                    if (InspectRange_Start > InspectRange_End)//可驗車期間 跨年度時，">"及"<"相反
                    {

                        if (Next_Inspect < InspectRange_Start && Next_Inspect > InspectRange_End)
                        {

                        }
                        else
                        {
                            ht["INSPECTION_STATUS"] = "0";
                        }
                    }
                }
            }

            ExcelUtility excel = new ExcelUtility();

            //設定style
            HSSFFont HtitleFont = excel.CreateFont(14, "標楷體", true);
            HSSFFont HdateFont = excel.CreateFont(10, "標楷體", true);
            HSSFFont TitleFont = excel.CreateFont(11, "標楷體", true);
            HSSFFont ContFont = excel.CreateFont(10, "標楷體", true);
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
            excel.CreateRow(0);//excel第一列索引值為0
            excel.SetRowHeight(40);
            excel.AddMergedRegion(0, 0, 0, 7);
            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局車輛定檢月報表");

            //列印日期
            excel.CreateRow(1);
            excel.AddMergedRegion(1, 1, 0, 3);
            excel.AddMergedRegion(1, 1, 6, 7);
            excel.CreateCell(styleHdateL, 0, "報表年月：" + txtReport_YM.Text);
            excel.CreateCell(styleHdateR, 6, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

            //標題
            excel.CreateRow(2);
            excel.CreateCell(styleTitleC, 0, "局編號");
            excel.SetColumnWidth(0, 100);
            excel.CreateCell(styleTitleC, 1, "車號");
            excel.SetColumnWidth(1, 100);
            excel.CreateCell(styleTitleC, 2, "保管單位");
            excel.SetColumnWidth(2, 110);
            excel.CreateCell(styleTitleC, 3, "車輛種類");
            excel.SetColumnWidth(3, 110);
            excel.CreateCell(styleTitleC, 4, "發照日期");
            excel.SetColumnWidth(4, 140);
            excel.CreateCell(styleTitleC, 5, "檢驗狀態");
            excel.SetColumnWidth(5, 140);
            excel.CreateCell(styleTitleC, 6, "檢驗日期");
            excel.SetColumnWidth(6, 140);

            excel.CreateCell(styleTitleC, 7, "可檢驗期間");
            excel.SetColumnWidth(7, 140);



            int rows = 2;
            //String sCaseNO = "";
            int iStartRow = rows;

            //內容
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];
                if (ht["INSPECTION_STATUS"] != string.Empty)
                {
                    rows++;
                    excel.CreateRow(rows);
                    excel.SetRowHeight(30);

                    excel.CreateCell(styleContL, 0, ht["DEP_NO"].ToString());//局編號
                    excel.CreateCell(styleContL, 1, ht["CAR_NO"].ToString());//車號
                    excel.CreateCell(styleContL, 2, med.lookupParamName("DEP_ORG", ht["KEEP_ORG"].ToString(), 0));//保管單位
                    excel.CreateCell(styleContL, 3, med.lookupParamName("CAR_TYPE", ht["CAR_TYPE"].ToString(), 0));//車輛種類
                    if (ht["LICENSING_DATE"].ToString() != string.Empty)
                        excel.CreateCell(styleContL, 4, DateTransfer.c_date_intrans(ht["LICENSING_DATE"].ToString()));//發照日期
                    else
                        excel.CreateCell(styleContL, 4, "");
                    if (ht["INSPECTION_STATUS"].ToString() != string.Empty)
                        excel.CreateCell(styleContL, 5, med.lookupParamName("INSPECT_STS", ht["INSPECTION_STATUS"].ToString(), 0));//檢驗狀態
                    else
                        excel.CreateCell(styleContL, 5, "");
                    if (ht["INSPECTION_DATE"].ToString() != string.Empty)
                        excel.CreateCell(styleContL, 6, DateTransfer.c_date_intrans(ht["INSPECTION_DATE"].ToString()));//檢驗日期
                    else
                        excel.CreateCell(styleContL, 6, "");

                    if (ht["INSPECTION_STATUS"].ToString() == "0")//未檢驗
                    {
                        string inspection_range = string.Empty;
                        int year = start_date.Year;

                        try
                        {
                            DateTime inspection_start = DateTime.Parse(ht["INSPECTION_START"].ToString());

                            if (start_date.Month < inspection_start.Month)//報表月為一月份時且inspection_start是12月時
                            {
                                year -= 1;
                            }
                            inspection_range += DateTransfer.c_date_intrans(string.Format("{0}/{1}/{2}", year, inspection_start.Month, inspection_start.Day));
                        }
                        catch (Exception)
                        {
                        }
                        year = start_date.Year;
                        try
                        {
                            DateTime inspection_end = DateTime.Parse(ht["INSPECTION_END"].ToString());

                            if (start_date.Month > inspection_end.Month)//報表月為12月份時且inspection_end是一月時
                            {
                                year += 1;
                            }
                            inspection_range += "~" + DateTransfer.c_date_intrans(string.Format("{0}/{1}/{2}", year, inspection_end.Month, inspection_end.Day));
                        }
                        catch (Exception)
                        {
                        }




                        excel.CreateCell(styleContL, 7, inspection_range);//可檢驗期間
                    }
                    else
                        excel.CreateCell(styleContL, 7, "");


                    //if (ht["NEXT_INSPECTION"].ToString() != string.Empty)
                    //excel.CreateCell(styleContC, 5, ht["NEXT_INSPECTION"].ToString().Substring(0, ht["NEXT_INSPECTION"].ToString().IndexOf(" ")));//下次定檢日，取【2016/6/8 上午00:00:00】Substring(索引到第一個空白鍵)
                    //else
                    //    excel.CreateCell(styleContC, 5, "");

                }

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
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("臺北市政府環境保護局車輛定檢月報表.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + "\\\n" + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 驗證年月格式
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void YMValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(args.Value + "/01"));
            args.IsValid = true;
        }
        catch
        {
            args.IsValid = false;
        }
    }


    /// <summary>
    /// 本月按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnThisMonth_Click(object sender, EventArgs e)
    {

        DateTime thisMonth = DateTime.Now;// 2015/06/08
        string strYM = DateTransfer.c_date_intrans(thisMonth.ToString("yyyy/MM/dd"));// 105/06/08
        txtReport_YM.Text = strYM.Substring(0, 6);// 105/05
    }


    /// <summary>
    /// 上月按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLastMonth_Click(object sender, EventArgs e)
    {
        DateTime lastMonth = DateTime.Now;// 2015/06/08

        try
        {
            lastMonth = Convert.ToDateTime(DateTransfer.c_date_trans(txtReport_YM.Text + "/01"));
        }
        catch
        {
            lastMonth = DateTime.Now;
        }

        lastMonth = lastMonth.AddMonths(-1);// 2015/05/08

        string strYM = DateTransfer.c_date_intrans(lastMonth.ToString("yyyy/MM/dd"));// 105/05/08
        txtReport_YM.Text = strYM.Substring(0, 6);// 105/05

    }
}
