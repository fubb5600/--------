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
/// 車輛服勤記錄 
/// </summary>
public partial class TDOSd002_TDOSd002Q1 : System.Web.UI.Page
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
            //2019/07/29
            //report_year.Items.Insert(0, new ListItem("請選擇", ""));

            //int year = int.Parse(DateTime.Now.ToString("yyyy")) - 1911;
            //for (int i = 0; i <= 10; i++)
            //{
            //    report_year.Items.Add(new ListItem((year - i).ToString(), (year - i).ToString()));


            //}
            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限
                    btnQuery.Visible = userID.hasFunc("TDOSd002_query");

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

                year.Text = DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")).Substring(0, 3);
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

        try
        {
            dao.open();

            ReportModel model = new ReportModel();
            model.dao = dao;

            DateTime start_date = Convert.ToDateTime(DateTransfer.c_date_trans(year.Text.Trim() + "/01/01"));
            DateTime end_date = Convert.ToDateTime(DateTransfer.c_date_trans(year.Text.Trim() + "/12/31"));
            Form form = new Form();
            form.setValue("year", year.Text);
            form.setValue("start_date", start_date.ToString("yyyy/MM/dd"));
            form.setValue("end_date", end_date.ToString("yyyy/MM/dd"));
            form.setValue("car_no", car_no.Text.Trim());
            form.setValue("dep_no", dep_no.Text.Trim());
            form.setValue("keep_org", keep_org.SelectedValue);
            form.setValue("car_id", model.TDOSd002_getMultiCarId(form));

            ArrayList al_car = model.TDOSd002_Car(form);
            ArrayList al = model.TDOSd002(form);

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
            HSSFCellStyle styleContP = excel.CreateNumberStyle(ContFont, ExcelUtility.ALIGN_RIGHT, true, "#0.00%");
            //excel.fillCellColor(styleTitleC, HSSFColor.LIGHT_CORNFLOWER_BLUE.index);           
            excel.fillCellColor(styleSumC, HSSFColor.TAN.index);
            excel.fillCellColor(styleSumR, HSSFColor.TAN.index);
            excel.CreateSheet();
            //預設列高
            excel.SetDefaultRowHeight(31);

            //表頭
            excel.CreateRow(0);
            excel.SetRowHeight(61);
            excel.AddMergedRegion(0, 0, 0, 15);
            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局" + keep_org.SelectedItem.Text + year.Text + "年1-12月份車輛作業及加油紀錄表");

            //欄寬
            excel.SetColumnWidth(0, 69);
            excel.SetColumnWidth(1, 85);
            excel.SetColumnWidth(2, 85);
            //excel.SetColumnWidth(3, 77);
            excel.SetColumnWidth(3, 101);
            excel.SetColumnWidth(4, 90);
            excel.SetColumnWidth(5, 90);
            excel.SetColumnWidth(6, 120);
            excel.SetColumnWidth(7, 75);

            excel.SetColumnWidth(8, 69);
            excel.SetColumnWidth(9, 85);
            excel.SetColumnWidth(10, 85);
            //excel.SetColumnWidth(12, 77);
            excel.SetColumnWidth(11, 101);
            excel.SetColumnWidth(12, 90);
            excel.SetColumnWidth(13, 90);
            excel.SetColumnWidth(14, 120);
            excel.SetColumnWidth(15, 75);

            int car_odd = al_car.Count / 2;
            int last_even_str = 0;
            
            if (al_car.Count % 2 != 0)
            {
                last_even_str = car_odd * 15;
                car_odd += 1;                
            }
          
            int total_rows = car_odd * 15;
            
            int rows = 0;
            for (int j = 0; j < total_rows; j++)
            {
                rows++;
                excel.CreateRow(rows);

                excel.CreateCell(styleContC, 0, 0);
                excel.CreateCell(styleContC, 1, 0);
                excel.CreateCell(styleContC, 2, 0);
                //excel.CreateCell(styleContP, 3, 0);
                excel.CreateCell(styleContR, 3, 0);
                excel.CreateCell(styleContF, 4, 0);
                excel.CreateCell(styleContM, 5, 0);
                excel.CreateCell(styleContF, 6, 0);
                excel.CreateCell(styleContC, 7, "");

                if ((al_car.Count % 2 != 0 && j < last_even_str) || al_car.Count % 2 == 0)
                {
                    excel.CreateCell(styleContC, 8, 0);
                    excel.CreateCell(styleContC, 9, 0);
                    excel.CreateCell(styleContC, 10, 0);
                    //excel.CreateCell(styleContP, 12, 0);
                    excel.CreateCell(styleContR, 11, 0);
                    excel.CreateCell(styleContF, 12, 0);
                    excel.CreateCell(styleContM, 13, 0);
                    excel.CreateCell(styleContF, 14, 0);
                    excel.CreateCell(styleContC, 15, "");
                }
            }

            ////列印日期
            //excel.CreateRow(1);
            //excel.AddMergedRegion(1, 1, 0, 16);
            //excel.AddMergedRegion(1, 1, 17, 18);
            //excel.CreateCell(styleHdateL, 0, "統計期間：" + start_date.Text + "~" + end_date.Text);
            //excel.CreateCell(styleHdateR, 17, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

            rows = 0;

            //內容
            for (int i = 0; i < al_car.Count; i++)
            {
                Hashtable ht_car = (Hashtable)al_car[i];

                #region 奇數欄

                if ((i + 1) % 2 == 1)
                {
                    //標題
                    rows++;
                    excel.GetRow(rows);
                    excel.SetRowHeight(57);
                    excel.SetCell(styleContC, 0, "局編號：");
                    excel.SetCell(styleContC, 1, ht_car["DEP_NO"].ToString());
                    excel.SetCell(styleContC, 2, "車號：");
                    excel.SetCell(styleContC, 3, ht_car["CAR_NO"].ToString());
                    excel.SetCell(styleContC, 4, "油耗量參考值(公里/公升，時/公升等)：");
                    excel.SetCell(styleContC, 5, "");
                    excel.SetCell(styleContC, 6, "");
                    excel.AddMergedRegion(rows, rows, 4, 6);
                    excel.SetCell(styleContC, 7, ht_car["FUEL_STD"].ToString());                   
                    //excel.AddMergedRegion(rows, rows, 7, 8);

                    rows++;
                    excel.GetRow(rows);
                    excel.SetCell(styleContC, 0, "月份");
                    excel.SetCell(styleContC, 1, "車次");
                    excel.SetCell(styleContC, 2, "作業天數");
                    //excel.SetCell(styleContC, 3, "出車率");
                    excel.SetCell(styleContC, 3, "公里數");
                    excel.SetCell(styleContC, 4, "公升");
                    excel.SetCell(styleContC, 5, "金額");
                    excel.SetCell(styleContC, 6, "油耗量實際值");
                    excel.SetCell(styleContC, 7, "備註");

                    int row_start = 1+rows;

                    for (int j = 1; j < 13; j++)
                    {
                        rows++;
                        excel.GetRow(rows);
                        excel.SetCell(styleContC, 0, j);

                        #region 填值
                        for (int k = 0; k < al.Count; k++)
                        {
                            Hashtable ht = (Hashtable)al[k];
                            if (ht["CAR_ID"].ToString() == ht_car["CAR_ID"].ToString() &&
                                ht["REPORT_M"].ToString() == HandleParam.addZero(j.ToString(), 2))
                            {
                                excel.SetCell(styleContC, 1, Convert.ToDouble(ht["CAR_COUNT"].ToString()));
                                excel.SetCell(styleContC, 2, Convert.ToDouble(ht["WORK_DAY"].ToString()));
                                //excel.SetMathCell(styleContP, 3, "IF(" + excel.cell_name(rows, 2) + "=0, 0, " +
                                //    excel.cell_name(rows, 1) + "/" + excel.cell_name(rows, 2) + ")"
                                //    );
                                excel.SetCell(styleContR, 3, Convert.ToDouble(ht["SUM_MILEAGE"].ToString()));
                                excel.SetCell(styleContF, 4, Convert.ToDouble(ht["SUM_COUNT"].ToString()));
                                excel.SetCell(styleContM, 5, Convert.ToDouble(ht["SUM_AMOUNT"].ToString()));
                                excel.SetMathCell(styleContF, 6, "IF(" + excel.cell_name(rows, 4) + "=0, 0, " +
                                   excel.cell_name(rows, 3) + "/" + excel.cell_name(rows, 4) + ")"
                                   );
                                excel.SetCell(styleContC, 7, "");
                            }
                        }
                        #endregion
                    }

                    //合計列
                    rows++;
                    excel.GetRow(rows);
                    excel.SetCell(styleContC, 0, "合計");
                    excel.SetMathCell(styleContC, 1, "SUM(" + excel.cell_name(row_start, 1) + ": " + excel.cell_name(rows - 1, 1) + ")");
                    excel.SetMathCell(styleContC, 2, "SUM(" + excel.cell_name(row_start, 2) + ": " + excel.cell_name(rows - 1, 2) + ")");
                    //excel.SetMathCell(styleContP, 3, "AVERAGE(" + excel.cell_name(row_start, 3) + ": " + excel.cell_name(rows - 1, 3) + ")");
                    excel.SetMathCell(styleContR, 3, "SUM(" + excel.cell_name(row_start, 3) + ": " + excel.cell_name(rows - 1, 3) + ")");
                    excel.SetMathCell(styleContF, 4, "SUM(" + excel.cell_name(row_start, 4) + ": " + excel.cell_name(rows - 1, 4) + ")");
                    excel.SetMathCell(styleContM, 5, "SUM(" + excel.cell_name(row_start, 5) + ": " + excel.cell_name(rows - 1, 5) + ")");
                    excel.SetMathCell(styleContF, 6, "AVERAGE(" + excel.cell_name(row_start, 6) + ": " + excel.cell_name(rows - 1, 6) + ")");
                    excel.SetCell(styleContM, 7, ht_car["MEMO"].ToString());
                }
                #endregion
            }

            rows = 0;

            for (int j = 0; j < al_car.Count; j++)
            {
                Hashtable ht_car = (Hashtable)al_car[j];

                #region 偶數欄

                if ((j + 1) % 2 == 0)
                {
                    //標題
                    rows++;
                    excel.GetRow(rows);
                    excel.SetRowHeight(57);
                    excel.SetCell(styleContC, 8, "局編號：");
                    excel.SetCell(styleContC, 9, ht_car["DEP_NO"].ToString());
                    excel.SetCell(styleContC, 10, "車號：");
                    excel.SetCell(styleContC, 11, ht_car["CAR_NO"].ToString());
                    excel.SetCell(styleContC, 12, "油耗量參考值(公里/公升，時/公升等)：");
                    excel.SetCell(styleContC, 13, "");
                    excel.SetCell(styleContC, 14, "");
                    excel.AddMergedRegion(rows, rows, 12, 14);
                    excel.SetCell(styleContC, 15, ht_car["FUEL_STD"].ToString());
                    //excel.SetCell(styleContC, 15, "");
                    //excel.AddMergedRegion(rows, rows, 16, 17);

                    rows++;
                    excel.GetRow(rows);
                    excel.SetCell(styleContC, 8, "月份");
                    excel.SetCell(styleContC, 9, "車次");
                    excel.SetCell(styleContC, 10, "作業天數");
                    //excel.SetCell(styleContC, 12, "出車率");
                    excel.SetCell(styleContC, 11, "公里數");
                    excel.SetCell(styleContC, 12, "公升");
                    excel.SetCell(styleContC, 13, "金額");
                    excel.SetCell(styleContC, 14, "油耗量實際值");
                    excel.SetCell(styleContC, 15, "備註");

                    int row_start = 1 + rows;

                    for (int n = 1; n < 13; n++)
                    {
                        rows++;
                        excel.GetRow(rows);
                        excel.SetCell(styleContC, 8, n);
                       
                        #region 填值
                        for (int k = 0; k < al.Count; k++)
                        {
                            Hashtable ht = (Hashtable)al[k];
                            if (ht["CAR_ID"].ToString() == ht_car["CAR_ID"].ToString() &&
                                ht["REPORT_M"].ToString() == HandleParam.addZero(n.ToString(), 2))
                            {
                                excel.SetCell(styleContC, 9, Convert.ToDouble(ht["CAR_COUNT"].ToString()));
                                excel.SetCell(styleContC, 10, Convert.ToDouble(ht["WORK_DAY"].ToString()));
                                //excel.SetMathCell(styleContP, 10, "IF(" + excel.cell_name(rows, 11) + "=0, 0, " +
                                //    excel.cell_name(rows, 10) + "/" + excel.cell_name(rows, 11) + ")"
                                //    );
                                excel.SetCell(styleContR, 11, Convert.ToDouble(ht["SUM_MILEAGE"].ToString()));
                                excel.SetCell(styleContF, 12, Convert.ToDouble(ht["SUM_COUNT"].ToString()));
                                excel.SetCell(styleContM, 13, Convert.ToDouble(ht["SUM_AMOUNT"].ToString()));
                                excel.SetMathCell(styleContF, 14, "IF(" + excel.cell_name(rows, 12) + "=0, 0, " +
                                   excel.cell_name(rows, 11) + "/" + excel.cell_name(rows, 12) + ")"
                                   );
                                excel.SetCell(styleContC, 15, "");
                            }
                        }
                        #endregion                        
                    }

                    //合計列
                    rows++;
                    excel.GetRow(rows);
                    excel.SetCell(styleContC, 8, "合計");
                    excel.SetMathCell(styleContC, 9, "SUM(" + excel.cell_name(row_start, 9) + ": " + excel.cell_name(rows - 1, 9) + ")");
                    excel.SetMathCell(styleContC, 10, "SUM(" + excel.cell_name(row_start, 10) + ": " + excel.cell_name(rows - 1, 10) + ")");
                    //excel.SetMathCell(styleContP, 12, "AVERAGE(" + excel.cell_name(row_start, 12) + ": " + excel.cell_name(rows - 1, 12) + ")");
                    excel.SetMathCell(styleContR, 11, "SUM(" + excel.cell_name(row_start, 11) + ": " + excel.cell_name(rows - 1, 11) + ")");
                    excel.SetMathCell(styleContF, 12, "SUM(" + excel.cell_name(row_start, 12) + ": " + excel.cell_name(rows - 1, 12) + ")");
                    excel.SetMathCell(styleContM, 13, "SUM(" + excel.cell_name(row_start, 13) + ": " + excel.cell_name(rows - 1, 13) + ")");
                    excel.SetMathCell(styleContF, 14, "AVERAGE(" + excel.cell_name(row_start, 14) + ": " + excel.cell_name(rows - 1, 14) + ")");
                    excel.SetCell(styleContM, 15, "");
                }
                #endregion
            }

            //設定列印配置
            excel.SetPagesize(8);     //A4
            excel.SetLandscape(true);//橫印             
            excel.setScale(100);      //設定縮放 %
            excel.SetMargin(1, 1, 0.5, 1);  //設定邊寬
            excel.SetFooterMargin(0.5);
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 0);

            //輸出檔案
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" +
                HttpUtility.UrlEncode("臺北市政府環境保護局" + keep_org.SelectedItem.Text + year.Text +
                "年1-12月份車輛作業及加油紀錄表.xls", System.Text.Encoding.UTF8));
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
    /// 驗證民國年格式
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void CHYearValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(args.Value + "/01/01"));
            args.IsValid = true;
        }
        catch
        {
            args.IsValid = false;
        }
    }
}