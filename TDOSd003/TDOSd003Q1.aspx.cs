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
///  總表  
/// </summary>
public partial class TDOSd003_TDOSd003Q1 : System.Web.UI.Page
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
                    btnQuery.Visible = userID.hasFunc("TDOSd003_query");
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

                hTag.createMediatorCheckBox("FUEL_TYPE", fuel_type, "", "", 0);
                hTag.createMediatorCheckBox("CARD_TYPE", card_type, "", "", 0);

              
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
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("start_date", DateTransfer.c_date_trans(start_date.Text.Trim()));
            form.setValue("end_date", DateTransfer.c_date_trans(end_date.Text.Trim()));
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("fuel_type", HandleParam.getMultiValue(fuel_type));
            form.setValue("card_type", HandleParam.getMultiValue(card_type));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("keep_org", userID.getUserOrg()
             );

            }
            else
            {
                form.setValue("keep_org", HandleParam.getMultiValue(keep_org));


            }
            ReportModel model = new ReportModel();
            model.dao = dao;
            ArrayList al = model.TDOSd003(form);
            ArrayList al_r2 = model.TDOSd003_R2(form);
            ArrayList al_chg = model.TDOSd001_CarChange(form);
            ArrayList al_carNo_memo = model.showCarNoMomo(form, "TDOSd003");

            if (al_r2.Count > 0 || al_chg.Count > 0)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Hashtable ht = (Hashtable)al[i];

                    if (al_r2.Count > 0)
                    {
                        for (int j = 0; j < al_r2.Count; j++)
                        {
                            Hashtable ht_r2 = (Hashtable)al_r2[j];
                            if (ht["CARD_ID"].ToString() == ht_r2["CARD_ID"].ToString())
                            {
                                al.RemoveAt(i);
                                al.Insert(i, ht_r2);                               
                            }
                        }
                    }

                    //異動車牌時 不顯示舊車牌
                    if (al_chg.Count > 0)
                    {
                        for (int k = 0; k < al_chg.Count; k++)
                        {
                            Hashtable ht_chg = (Hashtable)al_chg[k];

                            if (ht_chg["CAR_ID"].ToString() == ht["CAR_ID"].ToString())
                            {
                                //變更車牌
                                if (ht_chg["CHG_RSN"].ToString().Equals("R5") && !ht["CAR_NO"].ToString().Equals(ht_chg["R5_LICENSE"].ToString()))
                                {
                                    ht["R5_LICENSE"] = ht_chg["R5_LICENSE"].ToString();                                    
                                }
                            }
                        }
                    }
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
            excel.AddMergedRegion(0, 0, 0, 19);
            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局加油卡用油、排氣量、油耗量參考值、總里程明細表");

            //列印日期
            excel.CreateRow(1);
            excel.AddMergedRegion(1, 1, 0, 18);
            excel.AddMergedRegion(1, 1, 18, 19);
            excel.CreateCell(styleHdateL, 0, "統計期間：" + start_date.Text + "~" + end_date.Text);
            excel.CreateCell(styleHdateR, 18, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

            //標題
            excel.CreateRow(2);
            excel.CreateCell(styleTitleC, 0, "保管單位");
            excel.SetColumnWidth(0, 120);
            excel.CreateCell(styleTitleC, 1, "車牌號碼或卡代號");
            excel.SetColumnWidth(1, 100);
            excel.CreateCell(styleTitleC, 2, "局編號");
            excel.SetColumnWidth(2, 80);
            excel.CreateCell(styleTitleC, 3, "年份");
            excel.SetColumnWidth(3, 50);
            excel.CreateCell(styleTitleC, 4, "購置日期");
            excel.SetColumnWidth(4, 80);
            excel.CreateCell(styleTitleC, 5, "廠牌型號");
            excel.SetColumnWidth(5, 120);
            excel.CreateCell(styleTitleC, 6, "引擎號碼");
            excel.SetColumnWidth(6, 120);
            excel.CreateCell(styleTitleC, 7, "排氣量\n(CC數)");
            excel.SetColumnWidth(7, 68);
            excel.CreateCell(styleTitleC, 8, "噸數");
            excel.SetColumnWidth(8, 58);
            excel.CreateCell(styleTitleC, 9, "車輛種類");
            excel.SetColumnWidth(9, 120);
            excel.CreateCell(styleTitleC, 10, "加油種類\n(油品)");
            excel.SetColumnWidth(10, 80);
            excel.CreateCell(styleTitleC, 11, "總里程數");
            excel.SetColumnWidth(11, 80);
            excel.CreateCell(styleTitleC, 12, "加油數量(公升)");
            excel.SetColumnWidth(12, 80);
            excel.CreateCell(styleTitleC, 13, "金額\n(元)");
            excel.SetColumnWidth(13, 58);
            excel.CreateCell(styleTitleC, 14, "車次或\n時數");
            excel.SetColumnWidth(14, 58);
            excel.CreateCell(styleTitleC, 15, "出勤\n天數");
            excel.SetColumnWidth(15, 58);
            excel.CreateCell(styleTitleC, 16, "油耗量\n參考值");
            excel.SetColumnWidth(16, 80);
            excel.CreateCell(styleTitleC, 17, "作業面積(平方公尺)");
            excel.SetColumnWidth(17, 100);
            excel.CreateCell(styleTitleC, 18, "勤務記錄");
            excel.SetColumnWidth(18, 350);
            excel.CreateCell(styleTitleC, 19, "備註");
            excel.SetColumnWidth(19, 120);

            int rows = 2;

            //內容
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                if ((ht["CAR_STS"].ToString() == "O" || ht["CARD_STS"].ToString() == "O") && String.IsNullOrEmpty(ht["R5_LICENSE"].ToString())) //所對應的車輛狀態使用中或加油卡使用中
                {
                    //if ((ht["CAR_STS"].ToString() != string.Empty || ht["CARD_TYPE"].ToString() != "1") && ht["CARD_STS"].ToString() != "C")
                    //{
                        rows++;
                        excel.CreateRow(rows);
                        excel.CreateCell(styleContL, 0, med.lookupParamName("DEP_ORG", ht["KEEP_ORG"].ToString(), 0));
                        if (ht["CAR_NO"].ToString() != string.Empty)
                        {
                            excel.CreateCell(styleContL, 1, ht["CAR_NO"].ToString());
                        }
                        else
                        {
                            excel.CreateCell(styleContL, 1, ht["CARD_NO"].ToString());
                        }
                        excel.CreateCell(styleContL, 2, ht["DEP_NO"].ToString());
                        excel.CreateCell(styleContC, 3, ht["CAR_YEAR"].ToString());
                        excel.CreateCell(styleContC, 4, ht["BUY_DATE"].ToString());
                        excel.CreateCell(styleContL, 5, ht["BRAND_NO"].ToString());
                        excel.CreateCell(styleContL, 6, ht["ENGINE_NO"].ToString());
                        excel.CreateCell(styleContR, 7, ht["DISPLACEMENT"].ToString());
                        excel.CreateCell(styleContR, 8, ht["TONNAGE"].ToString());
                        excel.CreateCell(styleContL, 9, med.lookupParamName("CAR_TYPE", ht["CAR_TYPE"].ToString(), 0));
                        excel.CreateCell(styleContL, 10, med.lookupParamName("FUEL_TYPE", ht["FUEL_TYPE"].ToString(), 0));
                        excel.CreateCell(styleContR, 11, ht["SUM_MILEAGE"].ToString());
                        if (ht["CAR_NO"].ToString() != string.Empty)
                        {
                            excel.CreateCell(styleContF, 12, Convert.ToDouble(ht["SUM_CAR_COUNT"].ToString()));
                            excel.CreateCell(styleContM, 13, Convert.ToDouble(ht["SUM_CAR_AMOUNT"].ToString()));
                        }
                        else
                        {
                            excel.CreateCell(styleContF, 12, Convert.ToDouble(ht["SUM_COUNT"].ToString()));
                            excel.CreateCell(styleContM, 13, Convert.ToDouble(ht["SUM_AMOUNT"].ToString()));
                        }

                        if (ht["CAR_NO"].ToString() != string.Empty)
                        {
                            excel.CreateCell(styleContR, 14, ht["CAR_COUNT"].ToString());
                        }
                        else
                        {
                            excel.CreateCell(styleContF, 14, Convert.ToDouble(ht["SUM_HOUR"].ToString() != string.Empty ? ht["SUM_HOUR"].ToString() : "0"));
                        }

                        excel.CreateCell(styleContC, 15, ht["DAYS"].ToString());
                        if (ht["FUEL_STD"].ToString() != string.Empty)
                        {
                            excel.CreateCell(styleContF, 16, Convert.ToDouble(ht["FUEL_STD"].ToString()));
                        }
                        else
                        {
                            excel.CreateCell(styleContR, 16, "");
                        }
                        excel.CreateCell(styleContR, 17, ht["SUM_AREA"].ToString());
                        
                        //車輛移撥/報廢等異動情形摘要
                        String car_memo = string.Empty;
                        car_memo = getCarChangeEvent(form, ht["CAR_ID"].ToString());
                        if (ht["MEMO"].ToString() != string.Empty)
                        {
                            if (car_memo != string.Empty)
                                car_memo += "\n";
                            car_memo += ht["MEMO"].ToString();
                        }
                        #region 備註補充臨時卡的補登車號
                         string card_memo = model.TDOSd003_CarNo(form, ht["KEEP_ORG"].ToString(), ht["CARD_ID"].ToString());
                        if (card_memo !=string.Empty)
                        {
                            if (car_memo != string.Empty)
                                car_memo += "\n";
                            car_memo += card_memo;
                        }
                        #endregion

                        #region 車輛備註使用臨時卡補登車號
                        String car_no_memo = string.Empty;
                        for (int j = 0; j < al_carNo_memo.Count; j++)
                        {
                            Hashtable htMemo = (Hashtable)al_carNo_memo[j];
                            if (htMemo["CAR_NO"].ToString() == ht["CAR_NO"].ToString() && htMemo["MNG_ID"].ToString() == ht["KEEP_ORG"].ToString())
                            {
                                car_no_memo += "使用臨時卡" + htMemo["CARD_NO"].ToString() + "加油" + htMemo["FUEL_COUNT"].ToString() + "公升\n";
                            }
                        }

                        if(car_no_memo != string.Empty)
                            car_memo += car_no_memo.Substring(0, car_no_memo.Length-1);

                        #endregion
                        excel.CreateCell(styleContL, 19, car_memo);

                        #region 對應勤務記錄機具
                        if (ht["CARD_TYPE"].ToString() != "1")
                        {
                            Form form_use = new Form();
                            form_use.setValue("start_date", DateTransfer.c_date_trans(start_date.Text));
                            form_use.setValue("end_date", DateTransfer.c_date_trans(end_date.Text));
                            form_use.setValue("card_id", ht["CARD_ID"].ToString());
                            ArrayList al_use = model.TDOSd003_FuelUse(form_use);
                            if (al_use.Count > 0)
                            {
                                int start_row = rows;
                                for (int j = 0; j < al_use.Count; j++)
                                {
                                    Hashtable ht_use = (Hashtable)al_use[j];
                                    if (j > 0)
                                    {
                                        rows++;
                                        excel.CreateRow(rows);

                                        for (int k = 0; k < 18; k++)
                                        {
                                            excel.CreateCell(styleContR, k, "");
                                        }

                                        excel.CreateCell(styleContR, 19, "");
                                    }
                                    excel.CreateCell(styleContL, 18, ht_use["WORK_DATA"].ToString());
                                }

                                for (int k = 0; k < 18; k++)
                                {
                                    excel.AddMergedRegion(start_row, rows, k, k);
                                }

                                excel.AddMergedRegion(start_row, rows, 19, 19);
                            }
                            else
                            {
                                excel.CreateCell(styleContL, 18, "");
                            }
                        }
                        else
                        { excel.CreateCell(styleContL, 18, ""); }
                        #endregion
                    //}
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
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("臺北市政府環境保護局加油卡用油、排氣量、油耗量參考值、總里程明細表.xls", System.Text.Encoding.UTF8));
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
    protected void btnThisMonth_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Now;
        DateTime start = new DateTime(today.Year, today.Month, 1);
        DateTime end = start.AddMonths(1).AddDays(-1);
        start_date.Text = DateTransfer.c_date_intrans(start.ToString("yyyy/MM/dd"));
        end_date.Text = DateTransfer.c_date_intrans(end.ToString("yyyy/MM/dd"));
    }


    /// <summary>
    /// 本月按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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