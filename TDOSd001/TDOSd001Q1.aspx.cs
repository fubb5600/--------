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
/// 服勤耗油統計表 
/// </summary>
public partial class TDOSd001_TDOSd001Q1 : System.Web.UI.Page
{
   

    private Boolean isUnusualCheck = true; //true再檢查是否完成輸入異常備註才可匯出報表
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
                    //button權限
                    btnReport.Visible = userID.hasFunc("TDOSd001_query");
                    // btnQuery.Visible = userID.hasFunc("TDOSd001_update");                  
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

                WorkModel model = new WorkModel();
                model.dao = dao;

                hTag.createMediatorCheckBox("FUEL_TYPE", fuel_type, "", "", 0);
                hTag.createMediatorRadio("WORK_TYPE", work_type, "C", 0);
                work_type_SelectedIndexChanged(sender, e);

                

                reportYM_start.Text = DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")).Substring(0,6);
                reportYM_end.Text = reportYM_start.Text;
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
    /// 查詢按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReport_Click(object sender, EventArgs e)
    {
        //跨月
        if (!reportYM_start.Text.Trim().Equals(reportYM_end.Text.Trim()))
            multi_ym.Value = true.ToString();

        genReportData();
    }


    private void genReportData()
    {
        Form form = filterForm();

        if (work_type.SelectedValue == "C")
        {
            Report_Car(form);
        }
        else
        {
            Report_Machine(form);
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
    /// btnReport_Click
    /// </summary>
    /// <param name="form"></param>
    private void Report_Car(Form form)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            DataSet ds = getReportCarDataSource(form);
            dao.open();

            ReportModel model = new ReportModel();
            model.dao = dao;

        

            Mediator med = new Mediator();
            ExcelUtility excel = new ExcelUtility();

            form.setValue("car_no", model.TDOSd001_getMultiCarNo(form));
          


            ArrayList al_n = model.FuelNotInReport(form);
            //設定style
            HSSFFont HtitleFont = excel.CreateFont(14, "新細明體", true);
            HSSFFont HdateFont = excel.CreateFont(10, "新細明體", true);
            HSSFFont TitleFont = excel.CreateFont(10, "新細明體", true);
            HSSFFont TitleFont2 = excel.CreateFont(8, "新細明體", true);
            HSSFFont ContFont = excel.CreateFont(10, "新細明體", true);
            HSSFFont RedFont = excel.CreateFont(10, "新細明體", true);
            HSSFFont BlueFont = excel.CreateFont(10, "新細明體", true);
            HdateFont.Boldweight = 1;
            ContFont.Boldweight = 1;
            RedFont.Color = HSSFColor.RED.index;
            BlueFont.Color = HSSFColor.BLUE.index;

            HSSFCellStyle styleHtitle = excel.CreateWordStyle(HtitleFont, ExcelUtility.ALIGN_CENTER, false, true);
            HSSFCellStyle styleHdateR = excel.CreateWordStyle(HdateFont, ExcelUtility.ALIGN_RIGHT, false, true);
            HSSFCellStyle styleHdateL = excel.CreateWordStyle(HdateFont, ExcelUtility.ALIGN_LEFT, false, true);
            HSSFCellStyle styleFtitle = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_LEFT, false, true);
            HSSFCellStyle styleFtitleR = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_RIGHT, false, true);
            HSSFCellStyle styleTitleC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleTitleC2 = excel.CreateWordStyle(TitleFont2, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleTitleL = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleTitleR = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContC = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContCR = excel.CreateWordStyle(RedFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContCB = excel.CreateWordStyle(BlueFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContL = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleContLR = excel.CreateWordStyle(RedFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleContLB = excel.CreateWordStyle(BlueFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleContR = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContRR = excel.CreateWordStyle(RedFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContRB = excel.CreateWordStyle(BlueFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleSumC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleSumR = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleSumF = excel.CreateNumberStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00");
            HSSFCellStyle styleContF = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00");
            HSSFCellStyle styleContFR = excel.CreateNumberStyle(RedFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00");
            HSSFCellStyle styleContFB = excel.CreateNumberStyle(BlueFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00");
            HSSFCellStyle styleContM = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "###,##0");
            HSSFCellStyle styleContP = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00%");
            //excel.fillCellColor(styleTitleC, HSSFColor.LIGHT_CORNFLOWER_BLUE.index);           
            //excel.fillCellColor(styleSumC, HSSFColor.TAN.index);
            //excel.fillCellColor(styleSumR, HSSFColor.TAN.index);

            excel.CreateSheet();
            //預設列高
            excel.SetDefaultRowHeight(55);

            //表頭
            excel.CreateRow(0);
            excel.SetRowHeight(40);
            excel.AddMergedRegion(0, 0, 0, 17);

            String sReportYM = "";

            if (multi_ym.Value.Equals(true.ToString()))
                sReportYM = reportYM_start.Text.Trim() + "~" + reportYM_end.Text.Trim();
            else
                sReportYM = reportYM_start.Text.Trim().Substring(0, 3) + "年" + reportYM_start.Text.Substring(4, 2) + "月份";

            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局" + sReportYM + "服勤汽車耗油月報表");

            //保管單位
            excel.CreateRow(1);
            excel.SetRowHeight(33);
            excel.AddMergedRegion(1, 1, 0, 17);
            excel.CreateCell(styleHdateL, 0, "保管單位：" + med.lookupParamNameMulti("DEP_ORG", HandleParam.getMultiValue(keep_org), 0));

            //列印日期
            excel.CreateRow(2);
            excel.SetRowHeight(33);
            excel.AddMergedRegion(2, 2, 0, 17);
            String fuel_selected = HandleParam.getMultiValue(fuel_type);

            if (HandleParam.getMultiValue(fuel_type) == string.Empty)
            {
                fuel_selected = "GASOLINE,DIESEL";
            }

            excel.CreateCell(styleHdateL, 0, "油品類型：" + med.lookupParamNameMulti("FUEL_TYPE", HandleParam.getMultiValue(fuel_type), 0));
            excel.CreateCell(styleHdateR, 17, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

            //欄寬           
            excel.SetColumnWidth(0, 30);
            excel.SetColumnWidth(1, 50);
            excel.SetColumnWidth(2, 65);
            excel.SetColumnWidth(3, 65);
            excel.SetColumnWidth(4, 50);
            excel.SetColumnWidth(5, 35);
            excel.SetColumnWidth(6, 35);
            excel.SetColumnWidth(7, 50);
            excel.SetColumnWidth(8, 50);
            excel.SetColumnWidth(9, 50);
            excel.SetColumnWidth(10, 50);
            excel.SetColumnWidth(11, 50);
            excel.SetColumnWidth(12, 55);
            excel.SetColumnWidth(13, 55);
            excel.SetColumnWidth(14, 60);
            excel.SetColumnWidth(15, 60);
            excel.SetColumnWidth(16, 55);
            excel.SetColumnWidth(17, 145);

            //標題       
            excel.CreateRow(3);
            //excel.SetRowHeight(35);
            excel.CreateCell(styleTitleC, 0, "項\n次");
            excel.CreateCell(styleTitleC, 1, "保管單位");
            excel.CreateCell(styleTitleC, 2, "局編號");
            excel.CreateCell(styleTitleC, 3, "車牌");
            excel.CreateCell(styleTitleC, 4, "車型");
            excel.CreateCell(styleTitleC, 5, "勤務記錄");
            excel.CreateCell(styleTitleC, 6, "");
            excel.AddMergedRegion(3, 3, 5, 6);
            excel.CreateCell(styleTitleC, 7, "車輛里程表");
            excel.CreateCell(styleTitleC, 8, "");
            excel.AddMergedRegion(3, 3, 7, 9);
            excel.CreateCell(styleTitleC, 9, "行駛里程數");
            excel.CreateCell(styleTitleC, 10, "");
            excel.CreateCell(styleTitleC, 11, "");
            excel.AddMergedRegion(3, 3, 9, 11);
            excel.CreateCell(styleTitleC, 12, "實際\n加油\n公升");
            excel.CreateCell(styleTitleC, 13, "實際\n加油\n金額");
            excel.CreateCell(styleTitleC2, 14, "油耗量\n實際值\n(公里/公升)");
            excel.CreateCell(styleTitleC2, 15, "油耗量\n標準值\n(公里/公升)");
            excel.CreateCell(styleTitleC, 16, "載重量");
            excel.CreateCell(styleTitleC, 17, "行駛里程異常\n備註說明");

            excel.CreateRow(4);
            excel.CreateCell(styleTitleC, 0, "");
            excel.AddMergedRegion(3, 4, 0, 0);
            excel.CreateCell(styleTitleC, 1, "");
            excel.AddMergedRegion(3, 4, 1, 1);
            excel.CreateCell(styleTitleC, 2, "");
            excel.AddMergedRegion(3, 4, 2, 2);
            excel.CreateCell(styleTitleC, 3, "");
            excel.AddMergedRegion(3, 4, 3, 3);
            excel.CreateCell(styleTitleC, 4, "");
            excel.AddMergedRegion(3, 4, 4, 4);
            excel.CreateCell(styleTitleC2, 5, "車次");
            excel.CreateCell(styleTitleC2, 6, "天數");
            excel.CreateCell(styleTitleC2, 7, "起");
            excel.CreateCell(styleTitleC2, 8, "迄");
            excel.CreateCell(styleTitleC2, 9, "本月份");
            excel.CreateCell(styleTitleC2, 10, "前一月份");
            excel.CreateCell(styleTitleC2, 11, "去年同月");
            excel.CreateCell(styleTitleC2, 12, "");
            excel.AddMergedRegion(3, 4, 12, 12);
            excel.CreateCell(styleTitleC, 13, "");
            excel.AddMergedRegion(3, 4, 13, 13);
            excel.CreateCell(styleTitleC, 14, "");
            excel.AddMergedRegion(3, 4, 14, 14);
            excel.CreateCell(styleTitleC, 15, "");
            excel.AddMergedRegion(3, 4, 15, 15);
            excel.CreateCell(styleTitleC, 16, "");
            excel.AddMergedRegion(3, 4, 16, 16);
            excel.CreateCell(styleTitleC, 17, "");
            excel.AddMergedRegion(3, 4, 17, 17);

            int rows = 5;

            for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
            {
                excel.CreateRow(rows);
                rows++;

                for (int b = 0; b < 18; b++)
                {
                    if (b != 17)
                    {
                        excel.CreateCell(styleContR, b, 0);
                    }
                    else
                    {
                        excel.CreateCell(styleContL, b, ""); //備註
                    }
                }
            }

            rows = 5;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                // Hashtable ht_car = (Hashtable)al_car[i];
                DataRow dr = ds.Tables[0].Rows[i];
                Double month_diff = Convert.ToDouble(dr["month_diff"].ToString());
                Double year_diff = Convert.ToDouble(dr["year_diff"].ToString());
                Double fuel_diff = Convert.ToDouble(dr["fuel_diff"].ToString());
                Double fuel_real = Convert.ToDouble(dr["fuel_real"].ToString());
               



                if (month_diff > 0.2 || year_diff > 0.2 || (fuel_diff < 0.7 && fuel_real != 0))
                {
                    if (dr["MEMO"].ToString().Trim() == string.Empty && isUnusualCheck)
                    {
                        SysMsg.AlertMessage(this.Page, "尚有行駛里程異常備註未輸入不可匯出報表！");
                        return;
                    }

                    //上列
                    excel.GetRow(rows);
                    excel.SetCell(styleContCR, 0, i + 1);
                    excel.SetCell(styleContCR, 1, med.lookupParamName("DEP_ORG", dr["KEEP_ORG"].ToString(), 0));
                    excel.SetCell(styleContCR, 2, dr["DEP_NO"].ToString());
                    excel.SetCell(styleContCR, 3, dr["CAR_NO"].ToString());
                    excel.SetCell(styleContCR, 4, med.lookupParamName("CAR_TYPE", dr["CAR_TYPE"].ToString(), 0));
                    excel.SetCell(styleContRR, 5, Convert.ToDouble(dr["CAR_COUNT"].ToString()));
                    excel.SetCell(styleContRR, 6, Convert.ToDouble(dr["WORK_DAY"].ToString()));
                    excel.SetCell(styleContRR, 7, Convert.ToDouble(dr["MILEAGE_START"].ToString()));
                    excel.SetCell(styleContRR, 8, Convert.ToDouble(dr["MILEAGE_END"].ToString()));
                    excel.SetCell(styleContRR, 9, Convert.ToDouble(dr["SUM_MILEAGE"].ToString()));
                    excel.SetCell(styleContRR, 10, Convert.ToDouble(dr["LASTMONTH_MILEAGE"].ToString()));
                    excel.SetCell(styleContRR, 11, Convert.ToDouble(dr["LASTYEAR_MILEAGE"].ToString()));
                    excel.SetCell(styleContRR, 12, Convert.ToDouble(dr["SUM_COUNT"].ToString()));
                    excel.SetCell(styleContRR, 13, Convert.ToDouble(dr["SUM_AMOUNT"].ToString()));
                    excel.SetCell(styleContFR, 14, fuel_real);
                    excel.SetCell(styleContFR, 15, Convert.ToDouble(dr["FUEL_STD"].ToString()));
                    excel.SetCell(styleContRR, 16, Convert.ToDouble(dr["NET_WEIGHT"].ToString()));
                    excel.SetCell(styleContLR, 17, dr["MEMO"].ToString().Trim());

                    rows++;
                }
                else
                {
                    //上列
                    excel.GetRow(rows);
                    excel.SetCell(styleContCB, 0, i + 1);
                    excel.SetCell(styleContCB, 1, med.lookupParamName("DEP_ORG", dr["KEEP_ORG"].ToString(), 0));
                    excel.SetCell(styleContCB, 2, dr["DEP_NO"].ToString());
                    excel.SetCell(styleContCB, 3, dr["CAR_NO"].ToString());
                    excel.SetCell(styleContCB, 4, med.lookupParamName("CAR_TYPE", dr["CAR_TYPE"].ToString(), 0));
                    excel.SetCell(styleContRB, 5, Convert.ToDouble(dr["CAR_COUNT"].ToString()));
                    excel.SetCell(styleContRB, 6, Convert.ToDouble(dr["WORK_DAY"].ToString()));
                    excel.SetCell(styleContRB, 7, Convert.ToDouble(dr["MILEAGE_START"].ToString()));
                    excel.SetCell(styleContRB, 8, Convert.ToDouble(dr["MILEAGE_END"].ToString()));
                    excel.SetCell(styleContRB, 9, Convert.ToDouble(dr["SUM_MILEAGE"].ToString()));
                    excel.SetCell(styleContRB, 10, Convert.ToDouble(dr["LASTMONTH_MILEAGE"].ToString()));
                    excel.SetCell(styleContRB, 11, Convert.ToDouble(dr["LASTYEAR_MILEAGE"].ToString()));
                    excel.SetCell(styleContRB, 12, Convert.ToDouble(dr["SUM_COUNT"].ToString()));
                    excel.SetCell(styleContRB, 13, Convert.ToDouble(dr["SUM_AMOUNT"].ToString()));
                    excel.SetCell(styleContFB, 14, fuel_real);
                    excel.SetCell(styleContRB, 15, Convert.ToDouble(dr["FUEL_STD"].ToString()));
                    excel.SetCell(styleContRB, 16, Convert.ToDouble(dr["NET_WEIGHT"].ToString()));
                    excel.SetCell(styleContLB, 17, dr["MEMO"].ToString().Trim());

                    rows++;
                }
            }

            //合計列           
            excel.CreateRow(rows);
            excel.CreateCell(styleSumC, 0, "合        計");
            excel.CreateCell(styleSumC, 1, "");
            excel.CreateCell(styleSumC, 2, "");
            excel.CreateCell(styleSumC, 3, "");
            excel.CreateCell(styleSumC, 4, "");
            excel.AddMergedRegion(rows, rows, 0, 4);
            for (int c = 5; c < 14; c++)
            {
                excel.CreateMathCell(styleSumR, c, "SUM(" + excel.cell_name(5, c) + ": " + excel.cell_name(rows - 1, c) + ")");
            }
            excel.CreateMathCell(styleSumF, 14, "AVERAGE(" + excel.cell_name(5, 14) + ": " + excel.cell_name(rows - 1, 14) + ")");
            excel.CreateMathCell(styleSumF, 15, "AVERAGE(" + excel.cell_name(5, 15) + ": " + excel.cell_name(rows - 1, 15) + ")");
            excel.CreateCell(styleSumC, 16, "");
            excel.CreateCell(styleSumC, 17, "");

            //列出未被統計的加油資料
            if (al_n.Count > 0)
            {
                rows++;
                excel.CreateRow(rows);
                excel.CreateCell(styleHdateL, 0, "以下列出未被統計的加油資料：");
                excel.AddMergedRegion(rows, rows, 0, 17);
                excel.SetRowHeight(20);
                for (int d = 0; d < al_n.Count; d++)
                {
                    Hashtable ht_n = (Hashtable)al_n[d];
                    rows++;
                    excel.CreateRow(rows);
                    string str_n = "車牌號碼：" + ht_n["CAR_NO_STR"].ToString() + "   交易日期：" +
                        DateTransfer.transferFormate(ht_n["DEAL_DATE"].ToString(), "/", "23") + "   加油公升：" +
                        ht_n["FUEL_COUNT"].ToString() + "   加油金額：" + ht_n["FUEL_AMOUNT"].ToString();

                    excel.CreateCell(styleHdateL, 0, str_n);
                    excel.AddMergedRegion(rows, rows, 0, 17);
                    excel.SetRowHeight(20);
                }
            }

            //頁尾
            rows++;
            excel.CreateRow(rows);
            excel.CreateCell(styleFtitleR, 1, "承辦人：");
            excel.CreateCell(styleFtitle, 2, "");
            excel.AddMergedRegion(rows, rows, 1, 2);
            excel.CreateCell(styleFtitle, 13, "主   管：");
            excel.SetRowHeight(40);

            rows++;
            excel.CreateRow(rows);
            String memo = "一、本表應於每次月十五日以前填報，不得逾期。\n二、服勤車次行駛里程耗油表各隊應妥為保管，隨時備查。" +
                "\n三、勤務記錄內作業天數及作業車次請詳實填列。\n四、行駛里程數比較前月份及去年同期里程數，增減率任一項達±20%" +
                "以上，請於備註欄敘明原因。";
            excel.CreateCell(styleHdateL, 0, memo);
            excel.AddMergedRegion(rows, rows, 0, 17);
            excel.SetRowHeight(80);

            //設定列印配置
            excel.SetPagesize(9);     //A4
            excel.SetLandscape(true);//橫印             
            excel.setScale(100);      //設定縮放 %
            excel.SetMargin(0, 0, 0, 0);  //設定邊寬
            excel.SetFooterMargin(0.8);
            excel.SetHeaderMargin(0.8);
            excel.SetHorizontallyCenter(true);
            //excel.SetLeftFooter(ContFont, "一、本表應於每次月十五日以前填報，不得逾期。\n二、服勤車次行駛里程耗油表各隊應妥為保管，隨時備查。");            
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁，共" + ExcelUtility.GetTotalPages() + "頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 4);

            //輸出檔案
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" +
                HttpUtility.UrlEncode("臺北市政府環境保護局" + sReportYM.Replace("~", "-").Replace("/", "") + "服勤汽車耗油月報表.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + ex.StackTrace);
            //SYSLOG.sendMail(ex, userID, Request);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 機具報表
    /// </summary>
    /// <param name="form"></param>
    private void Report_Machine(Form form)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();

            ReportModel model = new ReportModel();
            model.dao = dao;
            ArrayList al = model.TDOSd001_Machine(form);
            ArrayList al_n = model.FuelNotInReport_Machine(form);
            Mediator med = new Mediator();
            ExcelUtility excel = new ExcelUtility();

            //設定style
            HSSFFont HtitleFont = excel.CreateFont(14, "新細明體", true);
            HSSFFont HdateFont = excel.CreateFont(10, "新細明體", true);
            HSSFFont TitleFont = excel.CreateFont(10, "新細明體", true);
            HSSFFont ContFont = excel.CreateFont(10, "新細明體", true);
            HSSFFont RedFont = excel.CreateFont(10, "新細明體", true);
            HdateFont.Boldweight = 1;
            ContFont.Boldweight = 1;
            RedFont.Color = HSSFColor.RED.index;
            HSSFCellStyle styleHtitle = excel.CreateWordStyle(HtitleFont, ExcelUtility.ALIGN_CENTER, false, true);
            HSSFCellStyle styleHdateR = excel.CreateWordStyle(HdateFont, ExcelUtility.ALIGN_RIGHT, false, true);
            HSSFCellStyle styleHdateL = excel.CreateWordStyle(HdateFont, ExcelUtility.ALIGN_LEFT, false, true);
            HSSFCellStyle styleFtitle = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_LEFT, false, true);
            HSSFCellStyle styleTitleC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleTitleL = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleTitleR = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContC = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContCR = excel.CreateWordStyle(RedFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleContL = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_LEFT, true, true);
            HSSFCellStyle styleContR = excel.CreateWordStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContRR = excel.CreateWordStyle(RedFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleSumC = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_CENTER, true, true);
            HSSFCellStyle styleSumR = excel.CreateWordStyle(TitleFont, ExcelUtility.ALIGN_RIGHT, true, true);
            HSSFCellStyle styleContF = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00");
            HSSFCellStyle styleContM = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "###,##0");
            HSSFCellStyle styleContP = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00%");
            //excel.fillCellColor(styleTitleC, HSSFColor.LIGHT_CORNFLOWER_BLUE.index);           
            excel.fillCellColor(styleSumC, HSSFColor.TAN.index);
            excel.fillCellColor(styleSumR, HSSFColor.TAN.index);


            excel.CreateSheet();
            //預設列高
            excel.SetDefaultRowHeight(33);

            //表頭
            excel.CreateRow(0);
            excel.SetRowHeight(40);
            excel.AddMergedRegion(0, 0, 0, 8);

            String sReportYM = "";

            if (multi_ym.Value.Equals(true.ToString()))
                sReportYM = reportYM_start.Text.Trim() + "~" + reportYM_end.Text.Trim();
            else
                sReportYM = reportYM_start.Text.Trim().Substring(0, 3) + "年" + reportYM_start.Text.Substring(4, 2) + "月份";

            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局" + sReportYM + "服勤機具耗油月報表");

            //保管單位
            excel.CreateRow(1);
            excel.CreateCell(styleHdateL, 0, "保管單位：" + med.lookupParamNameMulti("DEP_ORG", HandleParam.getMultiValue(keep_org), 0));
            excel.AddMergedRegion(1, 1, 0, 8);

            String sFuelSelected = HandleParam.getMultiValue(fuel_type);
            if (sFuelSelected == string.Empty)
                sFuelSelected = "GASOLINE,DIESEL";

            //列印日期
            excel.CreateRow(2);
            excel.CreateCell(styleHdateL, 0, "油品類型：" + med.lookupParamNameMulti("FUEL_TYPE", sFuelSelected, 0));
            excel.CreateCell(styleHdateR, 8, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));
            excel.AddMergedRegion(2, 2, 0, 7);

            //欄寬
            excel.SetColumnWidth(0, 45);
            excel.SetColumnWidth(1, 100);
            excel.SetColumnWidth(2, 100);
            excel.SetColumnWidth(3, 150);
            excel.SetColumnWidth(4, 80);
            excel.SetColumnWidth(5, 80);
            excel.SetColumnWidth(6, 80);
            excel.SetColumnWidth(7, 80);
            excel.SetColumnWidth(8, 300);


            //標題       
            excel.CreateRow(3);
            excel.CreateCell(styleTitleC, 0, "項\n次");
            excel.CreateCell(styleTitleC, 1, "保管單位");
            excel.CreateCell(styleTitleC, 2, "卡號");
            excel.CreateCell(styleTitleC, 3, "機具類型");
            excel.CreateCell(styleTitleC, 4, "勤務記錄");
            excel.CreateCell(styleTitleC, 5, "");
            excel.CreateCell(styleTitleC, 6, "實際加油\n公升");
            excel.CreateCell(styleTitleC, 7, "實際加油\n金額");
            excel.CreateCell(styleTitleC, 8, "異常備註說明");
            excel.AddMergedRegion(3, 3, 4, 5);

            for (int a = 0; a < 9; a++)
            {
                if (a != 4 && a != 5)
                {
                    excel.AddMergedRegion(3, 4, a, a);
                }
            }

            excel.CreateRow(4);

            for (int a = 0; a < 9; a++)
            {
                excel.CreateCell(styleTitleC, a, "");
            }
            excel.SetCell(styleTitleC, 4, "時數");
            excel.SetCell(styleTitleC, 5, "天數");

            int rows = 5;
            String card_id = string.Empty;

            int row_str = 5;
            int row_1st = 1;
            int[] cols = { 0, 1, 2, 6, 7, 8 };
            if (al.Count > 0)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Hashtable ht_machine = (Hashtable)al[i];
                    #region 項次
                    excel.CreateRow(rows);
                    if (i == 0)
                    {
                        excel.CreateCell(styleContC, 0, row_1st);
                    }
                    else if (card_id != ht_machine["CARD_ID"].ToString())
                    {
                        row_1st++;
                        excel.CreateCell(styleContC, 0, row_1st);
                    }
                    else if (card_id == ht_machine["CARD_ID"].ToString())
                    {
                        excel.CreateCell(styleContC, 0, "");
                    }
                    #endregion
                    excel.CreateCell(styleContC, 1, med.lookupParamName("DEP_ORG", ht_machine["KEEP_ORG"].ToString(), 0));
                    excel.CreateCell(styleContC, 2, ht_machine["CARD_NO"].ToString());
                    excel.CreateCell(styleContC, 3, med.lookupParamName("MACHINE", ht_machine["WORK_MACHINE"].ToString(), 0));
                    excel.CreateCell(styleContC, 4, Convert.ToDouble(ht_machine["HOURS"].ToString()));
                    excel.CreateCell(styleContC, 5, Convert.ToDouble(string.IsNullOrEmpty(ht_machine["DAYS"].ToString()) ? "0" : ht_machine["DAYS"].ToString()));
                    if (card_id != ht_machine["CARD_ID"].ToString())
                    {

                        excel.CreateCell(styleContF, 6, Convert.ToDouble(ht_machine["FUEL_COUNT"].ToString()));
                        excel.CreateCell(styleContM, 7, Convert.ToDouble(ht_machine["FUEL_AMOUNT"].ToString()));
                    }
                    else
                    {
                        excel.CreateCell(styleContF, 6, 0);
                        excel.CreateCell(styleContM, 7, 0);
                    }


                    excel.CreateCell(styleContC, 8, "");

                    //同張加油卡合併
                    if (i != 0 && card_id != ht_machine["CARD_ID"].ToString())
                    {
                        for (int j = 0; j < cols.Length; j++)
                        {
                            excel.AddMergedRegion(row_str, rows - 1, cols[j], cols[j]);
                        }
                        row_str = rows;
                    }
                    rows++;
                    card_id = ht_machine["CARD_ID"].ToString();
                }

                //最末筆加油卡合併
                if (row_str != rows - 1)
                {
                    for (int j = 0; j < cols.Length; j++)
                    {
                        excel.AddMergedRegion(row_str, rows - 1, cols[j], cols[j]);
                    }
                }


                //合計列
                excel.CreateRow(rows);
                excel.CreateCell(styleTitleC, 0, "合計");
                excel.CreateCell(styleTitleC, 1, "");
                excel.CreateCell(styleTitleC, 2, "");
                excel.CreateCell(styleTitleC, 3, "");
                excel.CreateMathCell(styleTitleC, 4, "SUM(" + excel.cell_name(5, 4) + ": " + excel.cell_name(rows - 1, 4) + ")");
                excel.CreateMathCell(styleTitleC, 5, "SUM(" + excel.cell_name(5, 5) + ": " + excel.cell_name(rows - 1, 5) + ")");
                excel.CreateMathCell(styleTitleR, 6, "SUM(" + excel.cell_name(5, 6) + ": " + excel.cell_name(rows - 1, 6) + ")");
                excel.CreateMathCell(styleTitleR, 7, "SUM(" + excel.cell_name(5, 7) + ": " + excel.cell_name(rows - 1, 7) + ")");
                excel.CreateCell(styleTitleC, 8, "");
                excel.AddMergedRegion(rows, rows, 0, 3);
                rows++;
            }


            //列出未被統計的加油資料
            if (al_n.Count > 0)
            {
                excel.CreateRow(rows);
                excel.CreateCell(styleHdateL, 0, "以下列出未被統計的加油資料：");
                excel.AddMergedRegion(rows, rows, 0, 8);
                excel.SetRowHeight(20);
                for (int d = 0; d < al_n.Count; d++)
                {
                    Hashtable ht_n = (Hashtable)al_n[d];
                    rows++;
                    excel.CreateRow(rows);
                    string str_n = "加油卡卡號：" + ht_n["CARD_NO"].ToString() + "   交易日期：" +
                        DateTransfer.transferFormate(ht_n["DEAL_DATE"].ToString(), "/", "23") + "   加油公升：" +
                        ht_n["FUEL_COUNT"].ToString() + "   加油金額：" + ht_n["FUEL_AMOUNT"].ToString();

                    excel.CreateCell(styleHdateL, 0, str_n);
                    excel.AddMergedRegion(rows, rows, 0, 8);
                    excel.SetRowHeight(20);
                }
                rows++;
            }

            //頁尾                
            excel.CreateRow(rows);
            excel.CreateCell(styleFtitle, 1, "承辦人：");
            excel.CreateCell(styleFtitle, 6, "主   管：");
            excel.SetRowHeight(40);

            rows++;
            excel.CreateRow(rows);
            String memo = "一、本表應於每次月十五日以前填報，不得逾期。\n二、勤務記錄內作業天數及作業時數請詳實填列。";
            excel.CreateCell(styleHdateL, 0, memo);
            excel.AddMergedRegion(rows, rows, 0, 8);
            excel.SetRowHeight(80);

            //設定列印配置
            excel.SetPagesize(9);     //A4
            excel.SetLandscape(true);//橫印             
            excel.setScale(100);      //設定縮放 %
            excel.SetMargin(0, 0, 0, 0);  //設定邊寬
            excel.SetFooterMargin(0.8);
            excel.SetHeaderMargin(0.8);
            excel.SetHorizontallyCenter(true);
            //excel.SetLeftFooter(ContFont, "一、本表應於每次月十五日以前填報，不得逾期。\n二、服勤車次行駛里程耗油表各隊應妥為保管，隨時備查。");            
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁，共" + ExcelUtility.GetTotalPages() + "頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 4);

            //輸出檔案
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" +
                HttpUtility.UrlEncode("臺北市政府環境保護局" + sReportYM.Replace("~", "-").Replace("/", "") + "服勤機具耗油月報表.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
            //SYSLOG.sendMail(ex, userID, Request);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 勤務類型 work_type_SelectedIndexChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void work_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];

        gvMain.DataSource = null;
        gvMain.DataBind();

        if (work_type.SelectedValue == "C")
        {
            btnQuery.Visible = (userID.hasFunc("TDOSd001_update"));
            btnSave.Visible = (userID.hasFunc("TDOSd001_update") && isDoSearch);
            panelTable.Visible = isDoSearch;

        }
        else
        {
            panelTable.Visible = false;
            btnQuery.Visible = false;
            btnSave.Visible = false;
        }
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

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Mediator med = Mediator.getInstance(false);

        //String rowID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            //    rowID = "row" + e.Row.RowIndex;

            //    //移動變色
            //    //e.Row.Attributes.Add("onmouseover", "colorchange(this)");
            //    //e.Row.Attributes.Add("onmouseout", "colorchange(this)");

            //    e.Row.Attributes.Add("id", rowID);
            //    CheckBox cbSelected = (CheckBox)e.Row.Cells[13].FindControl("cbAdt");
            //    // cbSelected.Attributes.Add("onclick", "colorselected(" + "'" + rowID + "', this" + ")");
            //    cbSelected.Attributes.Add("onclick", "colorSeleted2()");
            //    //確認 / 審核欄顯示
            //    Mediator med = new Mediator();
            //    if (drv["data_source"].ToString() == "CPC")
            //    {
            //        e.Row.Cells[11].Text = med.lookupParamName("CFM_STS", drv["cfm_status"].ToString(), 0);
            //    }
            //    else
            //    {
            //        e.Row.Cells[11].Text = med.lookupParamName("ADT_STS", drv["adt_status"].ToString(), 0);
            //    }
            e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();
            e.Row.Cells[1].Text = med.lookupParamName("DEP_ORG", drv["keep_org"].ToString(), 0);
            e.Row.Cells[4].Text = med.lookupParamName("CAR_TYPE", drv["car_type"].ToString(), 0);

            TextBox tb = (TextBox)e.Row.Cells[16].FindControl("txtMEMO");
            tb.Text = drv["memo"].ToString();

            Double month_diff = Convert.ToDouble(drv["month_diff"].ToString());
            Double year_diff = Convert.ToDouble(drv["year_diff"].ToString());
            Double fuel_diff = Convert.ToDouble(drv["fuel_diff"].ToString());
            Double fuel_real = Convert.ToDouble(drv["fuel_real"].ToString());
            //if (month_diff > 0.02 || month_diff < -0.02 || year_diff > 0.02 || year_diff < -0.02 || (fuel_diff < 0 && fuel_real != 0))
            //if ((month_diff > 0.2 || year_diff > 0.2 || (fuel_diff < 0.7 && fuel_real != 0)) && drv["memo"].ToString().Equals(""))
            if ((month_diff > 0.2 || year_diff > 0.2 || (fuel_diff < 0.7 && fuel_real != 0)))
            {
                for (int i = 10; i < 12; i++)
                {
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }


    /// <summary>
    /// 產製報表條件
    /// </summary>
    /// <returns></returns>
    private Form filterForm()
    {
        DBDAO dao = new DBDAO();
        Form form = new Form();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            ReportModel model = new ReportModel();
            model.dao = dao;

            DateTime start_date = Convert.ToDateTime(DateTransfer.c_date_trans(reportYM_start.Text.Trim() + "/01"));
            DateTime end_date = Convert.ToDateTime(DateTransfer.c_date_trans(reportYM_end.Text.Trim() + "/01"));
            DateTime lastmonth_end = end_date.AddDays(-1);

            end_date = end_date.AddMonths(1).AddDays(-1);

            DateTime reportYM = start_date;
            String sReportYM = "";

            do
            {
                sReportYM += DateTransfer.transferFormate(reportYM, "/", DateTransfer.YYY_MM) + Mediator.splitTag;
                reportYM = reportYM.AddMonths(1);

            }
            while (reportYM < end_date);

            if (sReportYM.Length > 0)
                sReportYM = sReportYM.Substring(0, sReportYM.Length - 1);

            form.setValue("report_ym", sReportYM);
            form.setValue("start_date", start_date.ToString("yyyy/MM/dd"));
            form.setValue("end_date", end_date.ToString("yyyy/MM/dd"));
            form.setValue("lastmonth_start", start_date.AddMonths(-1).ToString("yyyy/MM/dd"));
            form.setValue("lastmonth_end", lastmonth_end.ToString("yyyy/MM/dd"));
            form.setValue("lastyear_start", start_date.AddYears(-1).ToString("yyyy/MM/dd"));
            form.setValue("lastyear_end", end_date.AddYears(-1).ToString("yyyy/MM/dd"));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg()
             );

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            form.setValue("car_id", model.TDOSd002_getMultiCarId(form));
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }

        return form;
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();

            ReportModel model = new ReportModel();
            model.dao = dao;

            Form form = filterForm();
            DataSet ds = getReportCarDataSource(form);

            gvMain.DataSource = ds;
            gvMain.DataBind();

            //跨月
            if (!reportYM_start.Text.Trim().Equals(reportYM_end.Text.Trim()))
                multi_ym.Value = true.ToString();
            else
                multi_ym.Value = false.ToString();

            panelTable.Visible = true;
            isDoSearch = true;

            btnSave.Visible = isDoSearch;
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


    protected void gvMain_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // 建立自訂的標題
            GridView gv = (GridView)sender;

            GridViewRow gvRow0 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            GridViewRow gvRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

            string[] gvrHead0 = { "項次", "保管單位", "局編號", "車牌", "車型", "勤務記錄", "車輛里程表", "行駛里程數", "實際<br />加油<br />公升", "實際<br />加油<br />金額", "油耗量<br />實際值<br />(公里/公升)", 
                                   "油耗量<br />標準值<br />(公里/公升)", "載重量", "行駛里程異常<br />備註說明"};

            for (int i = 0; i < gvrHead0.Length; i++)
            {
                TableCell tc = new TableCell();
                tc.Text = gvrHead0[i];
                if (i == 7)
                {
                    tc.ColumnSpan = 3;
                }
                else if (i == 5 || i == 6)
                {
                    tc.ColumnSpan = 2;
                }
                else
                {
                    tc.RowSpan = 2;
                }
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.Height = 25;
                tc.CssClass = "td_center td_headhrz td_headmulti";
                gvRow0.Cells.Add(tc);
            }

            string[] gvrHead1 = { "車次", "天數", "起", "迄", "本月份", "前一月份", "去年同月" };

            for (int i = 0; i < gvrHead1.Length; i++)
            {
                TableCell tc = new TableCell();
                tc.Text = gvrHead1[i];
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.Height = 25;
                // tc.Width = 60;
                tc.CssClass = "td_center td_headhrz td_headmulti";
                gvRow1.Cells.Add(tc);
            }


            gvRow1.BackColor = System.Drawing.Color.White;
            gvRow1.ForeColor = System.Drawing.Color.Black;

            // 先清除原標題所有內容
            e.Row.Cells.Clear();

            // 加入自訂標題
            gv.Controls[0].Controls.AddAt(0, gvRow0);
            gv.Controls[0].Controls.AddAt(1, gvRow1);
        }
    }

    private DataSet getReportCarDataSource(Form form)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
       
        DataSet ds = new DataSet();
        try
        {
            dao.open();

            ReportModel model = new ReportModel();
            model.dao = dao;

            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            ArrayList al_car = model.TDOSd001_Car(form);

            Mediator med = new Mediator();
            ExcelUtility excel = new ExcelUtility();

            form.setValue("car_no", model.TDOSd001_getMultiCarNo(form));
            ArrayList al_load = model.TDOSd001_Load(form);

            DataSet dsDays = model.TDOSd001_Car_Days(form);
            DataSet dsCount = model.TDOSd001_Car_Count(form);
            DataSet dsMileS = model.TDOSd001_Car_MileS(form);
            DataSet dsMileE = model.TDOSd001_Car_MileE(form);
            DataSet dsLastM = model.TDOSd001_Car_LastM(form);
            DataSet dsLastY = model.TDOSd001_Car_LastY(form);
            DataSet dsFuel = model.TDOSd001_Car_Fuel(form);
            ArrayList alMemo = this.getCarMemo(form, al_car);

            #region dt加上column
            DataTable dt = ds.Tables.Add();
            dt.Columns.Add(new DataColumn("ROW_NUM"));
            dt.Columns.Add(new DataColumn("CAR_ID"));
            dt.Columns.Add(new DataColumn("CAR_NO"));
            dt.Columns.Add(new DataColumn("DEP_NO"));
            dt.Columns.Add(new DataColumn("CAR_TYPE"));
            dt.Columns.Add(new DataColumn("KEEP_ORG"));
            dt.Columns.Add(new DataColumn("FUEL_REAL"));
            dt.Columns.Add(new DataColumn("FUEL_STD"));
            dt.Columns.Add(new DataColumn("WORK_DAY"));
            dt.Columns.Add(new DataColumn("CAR_COUNT"));
            dt.Columns.Add(new DataColumn("SUM_MILEAGE"));
            dt.Columns.Add(new DataColumn("MILEAGE_START"));
            dt.Columns.Add(new DataColumn("MILEAGE_END"));
            dt.Columns.Add(new DataColumn("LASTMONTH_MILEAGE"));
            dt.Columns.Add(new DataColumn("LASTYEAR_MILEAGE"));
            dt.Columns.Add(new DataColumn("SUM_COUNT"));
            dt.Columns.Add(new DataColumn("SUM_AMOUNT"));
            dt.Columns.Add(new DataColumn("NET_WEIGHT"));
            dt.Columns.Add(new DataColumn("MEMO"));
            dt.Columns.Add(new DataColumn("MONTH_DIFF"));
            dt.Columns.Add(new DataColumn("YEAR_DIFF"));
            dt.Columns.Add(new DataColumn("FUEL_DIFF"));
            dt.Columns.Add(new DataColumn("R5_LICENSE"));

            #endregion

            //    #region 補ds預設值
            //    for (int i = 0; i < al_car.Count; i++)
            //    {
            //        Hashtable ht_car = (Hashtable)al_car[i];
            //        DataRow dr = dt.NewRow();

            //        dr["ROW_NUM"] = (i + 1);
            //        dr["CAR_ID"] = ht_car["CAR_ID"].ToString();
            //        dr["CAR_NO"] = ht_car["CAR_NO"].ToString();
            //        dr["DEP_NO"] = ht_car["DEP_NO"].ToString();
            //        dr["CAR_TYPE"] = ht_car["CAR_TYPE"].ToString();
            //        dr["KEEP_ORG"] = ht_car["KEEP_ORG"].ToString();
            //        dr["FUEL_REAL"] = "0";
            //        dr["FUEL_STD"] = (ht_car["FUEL_STD"].ToString() != string.Empty ? ht_car["FUEL_STD"].ToString() : "0");
            //        dr["WORK_DAY"] = "0";
            //        dr["CAR_COUNT"] = "0";
            //        dr["SUM_MILEAGE"] = "0";
            //        dr["MILEAGE_START"] = "0";
            //        dr["MILEAGE_END"] = "0";
            //        dr["LASTMONTH_MILEAGE"] = "0";
            //        dr["LASTYEAR_MILEAGE"] = "0";
            //        dr["SUM_COUNT"] = "0";
            //        dr["SUM_AMOUNT"] = "0";
            //        dr["NET_WEIGHT"] = "0";
            //        dr["MEMO"] = "";
            //        dr["MONTH_DIFF"] = "0";
            //        dr["YEAR_DIFF"] = "0";
            //        dr["FUEL_DIFF"] = "0";              

            //        dt.Rows.Add(dr);
            //    }
            //    #endregion


            //    #region 組合各個DataSet填值
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        DataRow dr = ds.Tables[0].Rows[i];

            //        //天數
            //        for (int j = 0; j < dsDays.Tables[0].Rows.Count; j++)
            //        {
            //            DataRow drDays = dsDays.Tables[0].Rows[j];
            //            if (dr["CAR_ID"].ToString() == drDays["CAR_ID"].ToString() && dr["KEEP_ORG"].ToString() == drDays["KEEP_ORG"].ToString())
            //            {
            //                dr["WORK_DAY"] = drDays["WORK_DAY"].ToString();
            //                break;
            //            }
            //        }

            //        //車次、里程數
            //        for (int j = 0; j < dsCount.Tables[0].Rows.Count; j++)
            //        {
            //            DataRow drCount = dsCount.Tables[0].Rows[j];
            //            if (dr["CAR_ID"].ToString() == drCount["CAR_ID"].ToString() && dr["KEEP_ORG"].ToString() == drCount["WORK_ORG"].ToString())
            //            {
            //                dr["CAR_COUNT"] = drCount["CAR_COUNT"].ToString();
            //                dr["SUM_MILEAGE"] = drCount["SUM_MILEAGE"].ToString();
            //                break;
            //            }
            //        }

            //        //里程數(起)
            //        for (int j = 0; j < dsMileS.Tables[0].Rows.Count; j++)
            //        {
            //            DataRow drMileS = dsMileS.Tables[0].Rows[j];
            //            if (dr["CAR_ID"].ToString() == drMileS["CAR_ID"].ToString() && dr["KEEP_ORG"].ToString() == drMileS["WORK_ORG"].ToString())
            //            {
            //                dr["MILEAGE_START"] = drMileS["MILEAGE_START"].ToString();
            //                break;
            //            }
            //        }

            //        //里程數(迄)
            //        for (int j = 0; j < dsMileE.Tables[0].Rows.Count; j++)
            //        {
            //            DataRow drMileE = dsMileE.Tables[0].Rows[j];
            //            if (dr["CAR_ID"].ToString() == drMileE["CAR_ID"].ToString() && dr["KEEP_ORG"].ToString() == drMileE["WORK_ORG"].ToString())
            //            {
            //                dr["MILEAGE_END"] = drMileE["MILEAGE_END"].ToString();
            //                break;
            //            }
            //        }

            //        //前一月份行駛里程數
            //        for (int j = 0; j < dsLastM.Tables[0].Rows.Count; j++)
            //        {
            //            DataRow drLastM = dsLastM.Tables[0].Rows[j];
            //            if (dr["CAR_ID"].ToString() == drLastM["CAR_ID"].ToString() && dr["KEEP_ORG"].ToString() == drLastM["WORK_ORG"].ToString())
            //            {
            //                dr["LASTMONTH_MILEAGE"] = drLastM["LASTMONTH_MILEAGE"].ToString();
            //                break;
            //            }
            //        }

            //        //去年同月行駛里程數
            //        for (int j = 0; j < dsLastY.Tables[0].Rows.Count; j++)
            //        {
            //            DataRow drLastY = dsLastY.Tables[0].Rows[j];
            //            if (dr["CAR_ID"].ToString() == drLastY["CAR_ID"].ToString() && dr["KEEP_ORG"].ToString() == drLastY["WORK_ORG"].ToString())
            //            {
            //                dr["LASTYEAR_MILEAGE"] = drLastY["LASTYEAR_MILEAGE"].ToString();
            //                break;
            //            }
            //        }

            //        //加油 
            //        for (int j = 0; j < dsFuel.Tables[0].Rows.Count; j++)
            //        {
            //            DataRow drFuel = dsFuel.Tables[0].Rows[j];
            //            if (dr["CAR_ID"].ToString() == drFuel["CAR_ID"].ToString() && dr["KEEP_ORG"].ToString() == drFuel["MNG_ID"].ToString())
            //            {
            //                dr["SUM_COUNT"] = drFuel["SUM_COUNT"].ToString();
            //                dr["SUM_AMOUNT"] = drFuel["SUM_AMOUNT"].ToString();
            //                break;
            //            }
            //        }

            //        //載重
            //        for (int j = 0; j < al_load.Count; j++)
            //        {
            //            Hashtable ht_load = (Hashtable)al_load[j];
            //            if (dr["CAR_NO"].ToString() == ht_load["CAR_NO"].ToString())
            //            {
            //                dr["NET_WEIGHT"] = (ht_load["NET_WEIGHT"].ToString() != string.Empty ? ht_load["NET_WEIGHT"].ToString() : "0");
            //            }
            //        }

            //        //行駛異常說明
            //        for (int j = 0; j < alMemo.Count; j++)
            //        {
            //            Hashtable htMemo = (Hashtable)alMemo[j];
            //            if (htMemo["CAR_ID"].ToString() == dr["CAR_ID"].ToString())
            //            {
            //                dr["R5_LICENSE"] = htMemo["R5_LICENSE"].ToString();    
            //                dr["MEMO"] = htMemo["MEMO"].ToString();    
            //                break;
            //            }
            //        }

            //        //油耗量實際值
            //        Double dSumMileage = Convert.ToDouble((dr["SUM_MILEAGE"].ToString() != string.Empty ? dr["SUM_MILEAGE"].ToString() : "0"));
            //        Double dSumCoumt = Convert.ToDouble((dr["SUM_COUNT"].ToString() != string.Empty ? dr["SUM_COUNT"].ToString() : "0"));
            //        Double fuel_real = 0;
            //        if (dSumMileage > 0 && dSumCoumt > 0)
            //        {
            //            fuel_real = Convert.ToDouble((dr["SUM_MILEAGE"].ToString() != string.Empty ? dr["SUM_MILEAGE"].ToString() : "0")) /
            //                Convert.ToDouble((dr["SUM_COUNT"].ToString() != string.Empty ? dr["SUM_COUNT"].ToString() : "0"));
            //        }

            //        dr["FUEL_REAL"] = (fuel_real > 0 ? string.Format("{0:F2}", fuel_real) : "0");

            //        //差異
            //        if (dSumMileage != 0)
            //        {
            //            Double month_diff = Convert.ToDouble(dr["SUM_MILEAGE"].ToString()) /
            //                        Convert.ToDouble(dr["LASTMONTH_MILEAGE"].ToString());

            //            if (month_diff < 1)
            //                month_diff = 1 - month_diff;
            //            else
            //                month_diff = month_diff - 1;

            //            dr["MONTH_DIFF"] = month_diff.ToString();
            //        }
            //        else
            //            dr["MONTH_DIFF"] = 0.3;

            //        if (dSumMileage != 0)
            //        {
            //            Double year_diff = Convert.ToDouble(dr["SUM_MILEAGE"].ToString()) /
            //                        Convert.ToDouble(dr["LASTYEAR_MILEAGE"].ToString());

            //            if (year_diff < 1)
            //                year_diff = 1 - year_diff;
            //            else
            //                year_diff = year_diff - 1;

            //            dr["YEAR_DIFF"] = year_diff.ToString();
            //        }
            //        else
            //            dr["YEAR_DIFF"] = 0.3;

            //        //實際耗油值低於標準耗油值70%
            //        Double fuel_std = Convert.ToDouble(dr["FUEL_STD"].ToString() != string.Empty ? dr["FUEL_STD"].ToString() : "0");
            //        Double fuel_diff = 0.6;

            //        if (fuel_real != 0 && fuel_std != 0)
            //            fuel_diff = fuel_real / fuel_std;

            //        //Double fuel_diff = fuel_real - Convert.ToDouble(dr["FUEL_STD"].ToString() != string.Empty ? dr["FUEL_STD"].ToString() : "0");
            //        dr["FUEL_DIFF"] = fuel_diff.ToString();
            //    }
            //    #endregion

            //    ////異動車牌時 不顯示舊車牌
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        DataRow dr = ds.Tables[0].Rows[i];

            //       if (!dr["R5_LICENSE"].ToString().Equals(dr["car_no"].ToString()) && dr["R5_LICENSE"].ToString() != string.Empty)
            //            ds.Tables[0].Rows[i].Delete();
            //    }

            //    ds.Tables[0].AcceptChanges();
            //}


            #region 補ds預設值
            for (int i = 0; i < al_car.Count; i++)
            {
                Hashtable ht_car = (Hashtable)al_car[i];
                DataRow dr = dt.NewRow();

                dr["ROW_NUM"] = (i + 1);
                dr["CAR_ID"] = ht_car["CAR_ID"].ToString();
                dr["CAR_NO"] = ht_car["CAR_NO"].ToString();
                dr["DEP_NO"] = ht_car["DEP_NO"].ToString();
                dr["CAR_TYPE"] = ht_car["CAR_TYPE"].ToString();
                dr["KEEP_ORG"] = ht_car["KEEP_ORG"].ToString();
                dr["FUEL_REAL"] = "0";
                dr["FUEL_STD"] = (ht_car["FUEL_STD"].ToString() != string.Empty ? ht_car["FUEL_STD"].ToString() : "0");
                dr["WORK_DAY"] = "0";
                dr["CAR_COUNT"] = "0";
                dr["SUM_MILEAGE"] = "0";
                dr["MILEAGE_START"] = "0";
                dr["MILEAGE_END"] = "0";
                dr["LASTMONTH_MILEAGE"] = "0";
                dr["LASTYEAR_MILEAGE"] = "0";
                dr["SUM_COUNT"] = "0";
                dr["SUM_AMOUNT"] = "0";
                dr["NET_WEIGHT"] = "0";
                dr["MEMO"] = "";
                dr["MONTH_DIFF"] = "0";
                dr["YEAR_DIFF"] = "0";
                dr["FUEL_DIFF"] = "0";

                dt.Rows.Add(dr);
            }
            #endregion


            #region 組合各個DataSet填值
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];

                //天數
                for (int j = 0; j < dsDays.Tables[0].Rows.Count; j++)
                {
                    DataRow drDays = dsDays.Tables[0].Rows[j];
                    if (dr["CAR_ID"].ToString() == drDays["CAR_ID"].ToString() )
                    {
                        dr["WORK_DAY"] = drDays["WORK_DAY"].ToString();
                        break;
                    }
                }

                //車次、里程數
                for (int j = 0; j < dsCount.Tables[0].Rows.Count; j++)
                {
                    DataRow drCount = dsCount.Tables[0].Rows[j];
                    if (dr["CAR_ID"].ToString() == drCount["CAR_ID"].ToString())
                    {
                        dr["CAR_COUNT"] = drCount["CAR_COUNT"].ToString();
                        dr["SUM_MILEAGE"] = drCount["SUM_MILEAGE"].ToString();
                        break;
                    }
                }

                //里程數(起)
                for (int j = 0; j < dsMileS.Tables[0].Rows.Count; j++)
                {
                    DataRow drMileS = dsMileS.Tables[0].Rows[j];
                    if (dr["CAR_ID"].ToString() == drMileS["CAR_ID"].ToString())
                    {
                        dr["MILEAGE_START"] = drMileS["MILEAGE_START"].ToString();
                        break;
                    }
                }

                //里程數(迄)
                for (int j = 0; j < dsMileE.Tables[0].Rows.Count; j++)
                {
                    DataRow drMileE = dsMileE.Tables[0].Rows[j];
                    if (dr["CAR_ID"].ToString() == drMileE["CAR_ID"].ToString() )
                    {
                        dr["MILEAGE_END"] = drMileE["MILEAGE_END"].ToString();
                        break;
                    }
                }

                //前一月份行駛里程數
                for (int j = 0; j < dsLastM.Tables[0].Rows.Count; j++)
                {
                    DataRow drLastM = dsLastM.Tables[0].Rows[j];
                    if (dr["CAR_ID"].ToString() == drLastM["CAR_ID"].ToString())
                    {
                        dr["LASTMONTH_MILEAGE"] = drLastM["LASTMONTH_MILEAGE"].ToString();
                        break;
                    }
                }

                //去年同月行駛里程數
                for (int j = 0; j < dsLastY.Tables[0].Rows.Count; j++)
                {
                    DataRow drLastY = dsLastY.Tables[0].Rows[j];
                    if (dr["CAR_ID"].ToString() == drLastY["CAR_ID"].ToString())
                    {
                        dr["LASTYEAR_MILEAGE"] = drLastY["LASTYEAR_MILEAGE"].ToString();
                        break;
                    }
                }

                //加油 
                for (int j = 0; j < dsFuel.Tables[0].Rows.Count; j++)
                {
                    DataRow drFuel = dsFuel.Tables[0].Rows[j];
                    if (dr["CAR_ID"].ToString() == drFuel["CAR_ID"].ToString())
                    {
                        dr["SUM_COUNT"] = drFuel["SUM_COUNT"].ToString();
                        dr["SUM_AMOUNT"] = drFuel["SUM_AMOUNT"].ToString();
                        break;
                    }
                }

                //載重
                for (int j = 0; j < al_load.Count; j++)
                {
                    Hashtable ht_load = (Hashtable)al_load[j];
                    if (dr["CAR_NO"].ToString() == ht_load["CAR_NO"].ToString())
                    {
                        dr["NET_WEIGHT"] = (ht_load["NET_WEIGHT"].ToString() != string.Empty ? ht_load["NET_WEIGHT"].ToString() : "0");
                    }
                }

                //行駛異常說明
                for (int j = 0; j < alMemo.Count; j++)
                {
                    Hashtable htMemo = (Hashtable)alMemo[j];
                    if (htMemo["CAR_ID"].ToString() == dr["CAR_ID"].ToString())
                    {
                        dr["R5_LICENSE"] = htMemo["R5_LICENSE"].ToString();
                        dr["MEMO"] = htMemo["MEMO"].ToString();
                        break;
                    }
                }

                //油耗量實際值
                Double dSumMileage = Convert.ToDouble((dr["SUM_MILEAGE"].ToString() != string.Empty ? dr["SUM_MILEAGE"].ToString() : "0"));
                Double dSumCoumt = Convert.ToDouble((dr["SUM_COUNT"].ToString() != string.Empty ? dr["SUM_COUNT"].ToString() : "0"));
                Double fuel_real = 0;
                if (dSumMileage > 0 && dSumCoumt > 0)
                {
                    fuel_real = Convert.ToDouble((dr["SUM_MILEAGE"].ToString() != string.Empty ? dr["SUM_MILEAGE"].ToString() : "0")) /
                        Convert.ToDouble((dr["SUM_COUNT"].ToString() != string.Empty ? dr["SUM_COUNT"].ToString() : "0"));
                }

                dr["FUEL_REAL"] = (fuel_real > 0 ? string.Format("{0:F2}", fuel_real) : "0");

                //差異
                if (dSumMileage != 0)
                {
                    Double month_diff = Convert.ToDouble(dr["SUM_MILEAGE"].ToString()) /
                                Convert.ToDouble(dr["LASTMONTH_MILEAGE"].ToString());

                    if (month_diff < 1)
                        month_diff = 1 - month_diff;
                    else
                        month_diff = month_diff - 1;

                    dr["MONTH_DIFF"] = month_diff.ToString();
                }
                else
                    dr["MONTH_DIFF"] = 0.3;

                if (dSumMileage != 0)
                {
                    Double year_diff = Convert.ToDouble(dr["SUM_MILEAGE"].ToString()) /
                                Convert.ToDouble(dr["LASTYEAR_MILEAGE"].ToString());

                    if (year_diff < 1)
                        year_diff = 1 - year_diff;
                    else
                        year_diff = year_diff - 1;

                    dr["YEAR_DIFF"] = year_diff.ToString();
                }
                else
                    dr["YEAR_DIFF"] = 0.3;

                //實際耗油值低於標準耗油值70%
                Double fuel_std = Convert.ToDouble(dr["FUEL_STD"].ToString() != string.Empty ? dr["FUEL_STD"].ToString() : "0");
                Double fuel_diff = 0.6;

                if (fuel_real != 0 && fuel_std != 0)
                    fuel_diff = fuel_real / fuel_std;

                //Double fuel_diff = fuel_real - Convert.ToDouble(dr["FUEL_STD"].ToString() != string.Empty ? dr["FUEL_STD"].ToString() : "0");
                dr["FUEL_DIFF"] = fuel_diff.ToString();
            }
            #endregion

            ////異動車牌時 不顯示舊車牌
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];

                if (!dr["R5_LICENSE"].ToString().Equals(dr["car_no"].ToString()) && dr["R5_LICENSE"].ToString() != string.Empty)
                    ds.Tables[0].Rows[i].Delete();
            }

            ds.Tables[0].AcceptChanges();
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }

        //ds.Tables[0].AcceptChanges();

        return ds;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        int i = 0;
        int count = 0;

        if (multi_ym.Value.Equals(true.ToString()))
        {
            SysMsg.AlertMessage(this.Page, "跨月查詢不能儲存，需為單一月份資料才可儲存當月異常！");
            return;
        }


        try
        {
            dao.open();
            dao.beginTransaction();

            ReportModel model = new ReportModel();
            model.dao = dao;

            for (i = 0; i < gvMain.Rows.Count; i++)
            {

                TextBox txtMemo = (TextBox)gvMain.Rows[i].FindControl("txtMemo");
                if (txtMemo.Text.Trim() != gvMain.DataKeys[i].Values[1].ToString())
                {

                    Form form = new Form();
                    form.setValue("report_ym", reportYM_start.Text.Trim());
                    form.setValue("car_id", gvMain.DataKeys[i].Values[0].ToString());
                    form.setValue("keep_org", keep_org.SelectedValue);
                    form.setValue("memo", txtMemo.Text.Trim());
                    form.setValue("create_user", userID.getUserID());

                    model.deleteUnusual(form);
                    model.insertUnusual(form);
                    count++;
                }
            }

            dao.commit();
            SysMsg.AlertMessage(this.Page, "儲存" + count + "筆行駛里程異常備註說明成功！");
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "第" + (i + 1) + "筆資料儲存失敗！\n" + ex.Message + "\n" + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
    }

    private ArrayList getCarMemo(Form form, ArrayList al_car)
    {
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        ArrayList al = new ArrayList();
        try
        {
            dao.open();

            ReportModel model = new ReportModel();
            model.dao = dao;

            //取得上次儲存資料(d_unusual_mst)
            ArrayList al_memo = model.showUnusualMomo(form);

            //車輛異動
            ArrayList al_chg = model.TDOSd001_CarChange(form);

            //臨時卡補登車號
            ArrayList al_carNo = model.showCarNoMomo(form, "TDOSd001");


            //整合
            for (int i = 0; i < al_car.Count; i++)
            {
                Hashtable ht = new Hashtable();
                Hashtable ht_car = (Hashtable)al_car[i];
                String memo = string.Empty;
                String r5_license = "";

                for (int j = 0; j < al_memo.Count; j++)
                {
                    Hashtable ht_memo = (Hashtable)al_memo[j];                   

                    if (ht_car["CAR_ID"].ToString() == ht_memo["CAR_ID"].ToString() && ht_car["KEEP_ORG"].ToString() == ht_memo["KEEP_ORG"].ToString())
                    {
                        memo += Environment.NewLine + ht_memo["MEMO"].ToString();
                    }
                }

                #region 補新的異動
                for (int k = 0; k < al_chg.Count; k++)
                {
                    Hashtable ht_chg = (Hashtable)al_chg[k];
                    String car_chg = string.Empty;                                      

                    if (ht_chg["CAR_ID"].ToString() == ht_car["CAR_ID"].ToString())
                    {
                        car_chg += ht_chg["CHG_DATE"].ToString() + med.lookupParamName("CHG_RSN", ht_chg["CHG_RSN"].ToString(), 0) + "\n";

                        //變更車牌
                        if (ht_chg["CHG_RSN"].ToString().Equals("R5"))
                            r5_license = ht_chg["R5_LICENSE"].ToString();
                    }


                    if (car_chg.Length > 0 && !memo.Contains(car_chg))
                    {
                        memo += Environment.NewLine + car_chg;
                    }
                }
                #endregion

                #region 補新的臨時卡
                for (int k = 0; k < al_carNo.Count; k++)
                {
                    Hashtable ht_carNo = (Hashtable)al_carNo[k];
                    String car_no = string.Empty;
                    if (ht_carNo["CAR_ID"].ToString() == ht_car["CAR_ID"].ToString() && ht_carNo["MNG_ID"].ToString() == ht_car["KEEP_ORG"].ToString())
                    {
                        car_no += "使用臨時卡" + ht_carNo["CARD_NO"].ToString() + "加油" + ht_carNo["FUEL_COUNT"].ToString() + "公升\n";
                    }

                    if (car_no.Length > 0 && !memo.Contains(car_no))
                    {
                        memo += Environment.NewLine + car_no;
                    }
                }
                #endregion


                if (memo.Length > 0)
                {
                    ht["CAR_ID"] = ht_car["CAR_ID"].ToString();
                    ht["KEEP_ORG"] = ht_car["KEEP_ORG"].ToString();
                    ht["MEMO"] = memo;
                    ht["R5_LICENSE"] = r5_license;

                    al.Add(ht);
                }
            }
            //if (al_chg.Count > 0)
            //{
            //    for (int i = 0; i < al_chg.Count; i++)
            //    {
            //        Hashtable ht = (Hashtable)al_chg[i];
            //        car_chg += ht["CHG_DATE"].ToString() + med.lookupParamName("CHG_RSN", ht["CHG_RSN"].ToString(), 0) + "\n";
            //    }
            //}

            //if (car_chg.Length > 2)
            //{
            //    car_chg = car_chg.Substring(0, car_chg.Length - 1);
            //}

        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message + "\n" + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
        return al;
    }
}