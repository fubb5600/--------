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
public partial class TDOSd005_TDOSd005Q1 : System.Web.UI.Page
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
                    btnQuery.Visible = userID.hasFunc("TDOSd005_query");
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

                    hTag.createMediatorRadio("WORK_TYPE", work_type, "C", 0);
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
            form.setValue("start_date", DateTransfer.c_date_trans(start_date.Text.Trim()));
            form.setValue("end_date", DateTransfer.c_date_trans(end_date.Text.Trim()));
            if (keep_org.SelectedValue == "")
            {
                form.setValue("crs_org", userID.getUserOrg()
             );

            }
            else
            {
                form.setValue("crs_org", HandleParam.getMultiValue(keep_org));


            }

            //2018/09/03新增局編號查詢條件
            form.setValue("dep_no", dep_no.Text.Trim());
            //2018/09/03新增局編號查詢條件
            //2018/09/03新增車號查詢條件
            form.setValue("car_no", car_no.Text.Trim());
            //2018/09/03新增車號查詢條件
            ReportModel model = new ReportModel();
            model.dao = dao;
            ArrayList al = new ArrayList();

            if (work_type.SelectedValue.Equals("C"))
                al = model.TDOSd005(form);
            else
                al = model.TDOSd005_Machine(form);

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
            excel.CreateRow(0);
            excel.SetRowHeight(40);

            excel.AddMergedRegion(0, 0, 0, 12);//新增零件編號欄位_wenny1061225
            //excel.AddMergedRegion(0, 0, 0, 11);//新增零件編號欄位_wenny1061225_原始碼
            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局修車廠報修車輛委外託修統計表");

            //列印日期
            excel.CreateRow(1);
            excel.AddMergedRegion(1, 1, 0, 9);
            excel.AddMergedRegion(1, 1, 10, 12); //新增零件編號欄位_wenny1061225
            //excel.AddMergedRegion(1, 1, 10, 11);//新增零件編號欄位_wenny1061225_原始碼
            excel.CreateCell(styleHdateL, 0, "統計期間：" + start_date.Text + "~" + end_date.Text);
            excel.CreateCell(styleHdateR, 10, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

            //標題
            excel.CreateRow(2);
            excel.CreateCell(styleTitleC, 0, "進廠日期");
            excel.SetColumnWidth(0, 85);//新增零件編號欄位_wenny1061225
            //excel.SetColumnWidth(0, 110);//新增零件編號欄位_wenny1061225_原始碼
            excel.CreateCell(styleTitleC, 1, "局編號");
            excel.SetColumnWidth(1, 70);
            if (work_type.SelectedValue.Equals("C"))
                excel.CreateCell(styleTitleC, 2, "車牌號碼");
            else
                excel.CreateCell(styleTitleC, 2, "機具");
            excel.SetColumnWidth(2, 85);//新增零件編號欄位_wenny1061225
            //excel.SetColumnWidth(2, 80);//新增零件編號欄位_wenny1061225_原始碼
            excel.CreateCell(styleTitleC, 3, "單位");
            excel.SetColumnWidth(3, 95);
            excel.CreateCell(styleTitleC, 4, "報修內容");
            excel.SetColumnWidth(4, 140);
            excel.CreateCell(styleTitleC, 5, "委外項目");
            excel.SetColumnWidth(5, 140);
            excel.CreateCell(styleTitleC, 6, "單位");
            excel.SetColumnWidth(6, 45);//新增零件編號欄位_wenny1061225
            //excel.SetColumnWidth(6, 50);//新增零件編號欄位_wenny1061225_原始碼
            excel.CreateCell(styleTitleC, 7, "單價");
            excel.SetColumnWidth(7, 60);
            excel.CreateCell(styleTitleC, 8, "數量");
            excel.SetColumnWidth(8, 45);
            excel.CreateCell(styleTitleC, 9, "總價");
            excel.SetColumnWidth(9, 60);
            excel.CreateCell(styleTitleC, 10, "維修廠商");
            excel.SetColumnWidth(10, 130);
            excel.CreateCell(styleTitleC, 11, "派工單號");
            excel.SetColumnWidth(11, 85);//新增零件編號欄位_wenny1061225
            //excel.SetColumnWidth(11, 80);//新增零件編號欄位_wenny1061225_原始碼
            #region 新增零件編號欄位_wenny1061225
            excel.CreateCell(styleTitleC, 12, "零件編號");
            excel.SetColumnWidth(12, 85);
            #endregion
            int rows = 2;
            String sCaseNO = "";
            int iStartRow = rows;

            //內容
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                rows++;
                excel.CreateRow(rows);
                excel.SetRowHeight(30);

                string sNotifyDate = "";
                if (ht["NOTIFY_DATE"].ToString() != string.Empty)
                {
                    if (!ht["NOTIFY_DATE"].ToString().Substring(10, 5).Equals("00:00"))

                        sNotifyDate = ht["NOTIFY_DATE"].ToString();
                    else
                        sNotifyDate = ht["NOTIFY_DATE"].ToString().Substring(0, 9);
                }
                excel.CreateCell(styleContL, 0, sNotifyDate);


                if (work_type.SelectedValue.Equals("C"))
                {
                    excel.CreateCell(styleContL, 1, ht["DEP_NO"].ToString());
                    excel.CreateCell(styleContL, 2, ht["CAR_NO"].ToString());
                }
                else
                {
                    excel.CreateCell(styleContL, 1, ht["MACHINE_NO"].ToString());
                    excel.CreateCell(styleContL, 2, med.lookupParamName("MACHINE", ht["MACHINE_TYPE"].ToString(), 0));
                }
                excel.CreateCell(styleContL, 3, med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0));
                excel.CreateCell(styleContL, 4, ht["NOTIFY_ITEM"].ToString());
                excel.CreateCell(styleContL, 5, ht["COMPONENT_NAME"].ToString());
                excel.CreateCell(styleContC, 6, ht["UNIT"].ToString());
                Double dBudget = Double.Parse(string.IsNullOrEmpty(ht["BUDGET" + ht["BUDGET_AREA"].ToString()].ToString()) ? "0" : ht["BUDGET" + ht["BUDGET_AREA"].ToString()].ToString());
                //excel.CreateCell(styleContR, 7, String.Format("{0:N0}", dBudget));//修正單價為小數點兩位_wennyh_1229_原始檔
                excel.CreateCell(styleContR, 7, String.Format("{0:N2}", dBudget));//修正單價為小數點兩位_wennyh_1229
                excel.CreateCell(styleContR, 8, ht["COUNT"].ToString());
                Double dTotalPrice = Double.Parse(string.IsNullOrEmpty(ht["TOTAL_PRICE" + ht["BUDGET_AREA"].ToString()].ToString()) ? "0" : ht["TOTAL_PRICE" + ht["BUDGET_AREA"].ToString()].ToString());
                excel.CreateCell(styleContR, 9, String.Format("{0:N0}", dTotalPrice));
                excel.CreateCell(styleContL, 10, ht["REPAIR_VENDER"].ToString());
                excel.CreateCell(styleContC, 11, ht["WORK_NO"].ToString());
                excel.CreateCell(styleContC, 12, ht["COMPONENT_NO"].ToString()); //新增零件編號欄位_wenny1061225
                if (sCaseNO != ht["CASE_NO"].ToString()) 
                {
                    iStartRow = rows;
                    excel.AddMergedRegion(iStartRow, rows, 1, 1);
                }
                sCaseNO = ht["CASE_NO"].ToString();

            }

            //設定列印配置
            excel.SetPagesize(9);     //A4
            excel.SetLandscape(true);//橫印     
            excel.SetHorizontallyCenter(true);
            excel.setScale(94);      //設定縮放 %
            excel.SetMargin(0, 0, 0, 0);  //設定邊寬
            excel.SetFooterMargin(0.5);
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 2);

            //輸出檔案
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("臺北市政府環境保護局報修車輛委外託修統計表.xls", System.Text.Encoding.UTF8));
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

    protected void btnQuery1_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];

        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        TDOS tdos = new TDOS();
        try
        {
            dao.open();

            Form form = new Form();
            form.setValue("start_date", DateTransfer.c_date_trans(start_date.Text.Trim()));
            form.setValue("end_date", DateTransfer.c_date_trans(end_date.Text.Trim()));




            if (keep_org.SelectedValue == "")
            {
                form.setValue("crs_org", userID.getUserOrg()
             );

            }
            else
            {
                form.setValue("crs_org", HandleParam.getMultiValue(keep_org));


            }

            //2018/09/03新增局編號查詢條件
            form.setValue("dep_no", dep_no.Text.Trim());
            //2018/09/03新增局編號查詢條件
            //2018/09/03新增車號查詢條件
            form.setValue("car_no", car_no.Text.Trim());
            //2018/09/03新增車號查詢條件
            ReportModel model = new ReportModel();
            model.dao = dao;
            ArrayList al = new ArrayList();

            if (work_type.SelectedValue.Equals("C"))
                al = model.TDOSd0051(form);
            else
                al = model.TDOSd0051_Machine(form);

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
            excel.fillCellColor(styleSumC, HSSFColor.RED.index);
            excel.fillCellColor(styleSumR, HSSFColor.TAN.index);
            excel.CreateSheet();
            //預設列高
            excel.SetDefaultRowHeight(40);

            //表頭
            excel.CreateRow(0);
            excel.SetRowHeight(40);

            excel.AddMergedRegion(0, 0, 0, 12);//新增零件編號欄位_wenny1061225
            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局修車廠報修車輛委外託修統計表");

            //列印日期
            excel.CreateRow(1);
            excel.AddMergedRegion(1, 1, 0, 9);
            excel.AddMergedRegion(1, 1, 10, 12); //新增零件編號欄位_wenny1061225
            excel.CreateCell(styleHdateL, 0, "統計期間：" + start_date.Text + "~" + end_date.Text);
            excel.CreateCell(styleHdateR, 10, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

            //標題
            excel.CreateRow(2);
       
            if (work_type.SelectedValue.Equals("C"))
                excel.CreateCell(styleTitleC, 0, "車牌號碼");
            else
                excel.CreateCell(styleTitleC, 0, "機具");
            excel.SetColumnWidth(0, 85);//新增零件編號欄位_wenny1061225
          
            excel.CreateCell(styleTitleC, 1, "單位");
            excel.SetColumnWidth(1, 95);
            excel.CreateCell(styleTitleC, 2, "局編號");
            excel.SetColumnWidth(1, 95);
            excel.CreateCell(styleTitleC, 3, "總價");
            excel.SetColumnWidth(2, 60);

        
            int rows = 2;
            String sCaseNO = "";
            int iStartRow = rows;


            //內容
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                rows++;
                excel.CreateRow(rows);
                excel.SetRowHeight(30);

                string sNotifyDate = "";
              
             


         
                  
                if(int.Parse(ht["TOTAL_PRICE"].ToString())>200000)
                {
                    excel.CreateCell(styleSumC, 0, ht["CAR_NO"].ToString());
                    excel.CreateCell(styleSumC, 3, ht["TOTAL_PRICE"].ToString());
                    excel.CreateCell(styleSumC, 1, med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0));
                    excel.CreateCell(styleSumC, 2, ht["DEP_NO"].ToString());
                }

               else
                {
                    excel.CreateCell(styleContR, 0, ht["CAR_NO"].ToString());
                    excel.CreateCell(styleContR, 3, ht["TOTAL_PRICE"].ToString());
                    excel.CreateCell(styleContR, 1, med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0));
                    excel.CreateCell(styleContL, 2, ht["DEP_NO"].ToString());
                }

            }

            //設定列印配置
            excel.SetPagesize(9);     //A4
            excel.SetLandscape(true);//橫印     
            excel.SetHorizontallyCenter(true);
            excel.setScale(94);      //設定縮放 %
            excel.SetMargin(0, 0, 0, 0);  //設定邊寬
            excel.SetFooterMargin(0.5);
            excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁");//設定頁尾(頁次)
            excel.SetRepeatRegion(0, -1, -1, 0, 2);

            //輸出檔案
            excel.GetHSSFWorkbook().Write(Response.OutputStream);
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("臺北市政府環境保護局報修車輛委外託修統計表.xls", System.Text.Encoding.UTF8));
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



    protected void btnQuery2_Click(object sender, EventArgs e)
    {

        if(start_date.Text.Substring(0, 3) == end_date.Text.Substring(0, 3))
        {
            string end_date2= end_date.Text.Trim().Substring(0, 3);
            int end_date1 = int.Parse(end_date2) + 1992;
           
            UserID userID = (UserID)Session["UserID"];

            DBDAO dao = new DBDAO();
            Mediator med = new Mediator();
            TDOS tdos = new TDOS();
            try
            {
                dao.open();

                Form form = new Form();
                form.setValue("start_date", DateTransfer.c_date_trans(start_date.Text.Trim()));
                form.setValue("end_date", DateTransfer.c_date_trans(end_date.Text.Trim()));
                form.setValue("start_date1", DateTransfer.c_date_trans(start_date.Text.Trim()).Substring(0, 4)+ "/01/01");
                form.setValue("end_date1", DateTransfer.c_date_trans(end_date.Text.Trim()).Substring(0, 4) + "/04/01");
                form.setValue("start_date2", DateTransfer.c_date_trans(start_date.Text.Trim()).Substring(0, 4) + "/04/01");
                form.setValue("end_date2", DateTransfer.c_date_trans(end_date.Text.Trim()).Substring(0, 4) + "/07/01");
                form.setValue("start_date3", DateTransfer.c_date_trans(start_date.Text.Trim()).Substring(0, 4) + "/07/01");
                form.setValue("end_date3", DateTransfer.c_date_trans(end_date.Text.Trim()).Substring(0, 4) + "/09/30");
                form.setValue("start_date4", DateTransfer.c_date_trans(start_date.Text.Trim()).Substring(0, 4) + "/09/30");
                form.setValue("end_date4", end_date1.ToString() + "/01/01");



                if (keep_org.SelectedValue == "")
                {
                    form.setValue("crs_org", userID.getUserOrg()
                 );

                }
                else
                {
                    form.setValue("crs_org", HandleParam.getMultiValue(keep_org));


                }

                //2018/09/03新增局編號查詢條件
                form.setValue("dep_no", dep_no.Text.Trim());
                //2018/09/03新增局編號查詢條件
                //2018/09/03新增車號查詢條件
                form.setValue("car_no", car_no.Text.Trim());
                //2018/09/03新增車號查詢條件
                ReportModel model = new ReportModel();
                model.dao = dao;
                ArrayList al = new ArrayList();

                if (work_type.SelectedValue.Equals("C"))
                    al = model.TDOSd0052(form);
                else
                    al = model.TDOSd0052_Machine(form);

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
                excel.fillCellColor(styleSumC, HSSFColor.RED.index);
                excel.fillCellColor(styleSumR, HSSFColor.TAN.index);
                excel.CreateSheet();
                //預設列高
                excel.SetDefaultRowHeight(40);

                //表頭
                excel.CreateRow(0);
                excel.SetRowHeight(40);

                excel.AddMergedRegion(0, 0, 0, 12);//新增零件編號欄位_wenny1061225
                excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局修車廠報修車輛委外託修統計表");

                //列印日期
                excel.CreateRow(1);
                excel.AddMergedRegion(1, 1, 0, 9);
                excel.AddMergedRegion(1, 1, 10, 12); //新增零件編號欄位_wenny1061225
                excel.CreateCell(styleHdateL, 0, "統計期間：" + start_date.Text + "~" + end_date.Text);
                excel.CreateCell(styleHdateR, 10, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

                //標題
                excel.CreateRow(2);

                if (work_type.SelectedValue.Equals("C"))
                    excel.CreateCell(styleTitleC, 0, "車牌號碼");
                else
                    excel.CreateCell(styleTitleC, 0, "機具");
                excel.SetColumnWidth(0, 85);//新增零件編號欄位_wenny1061225

                excel.CreateCell(styleTitleC, 1, "單位");
                excel.SetColumnWidth(1, 95);
                excel.CreateCell(styleTitleC, 2, "局編號");
                excel.SetColumnWidth(1, 95);

                excel.CreateCell(styleTitleC, 3, "總價");
                excel.SetColumnWidth(2, 60);

                excel.CreateCell(styleTitleC, 4, "季");
                excel.SetColumnWidth(2, 60);

                int rows = 2;
                String sCaseNO = "";
                int iStartRow = rows;


                //內容
                for (int i = 0; i < al.Count; i++)
                {
                    Hashtable ht = (Hashtable)al[i];

                    rows++;
                    excel.CreateRow(rows);
                    excel.SetRowHeight(30);

                    string sNotifyDate = "";




                  
                    if (int.Parse(ht["TOTAL_PRICE"].ToString()) > 75000)
                    {
                        excel.CreateCell(styleSumC, 0, ht["CAR_NO"].ToString());
                        excel.CreateCell(styleSumC, 1, med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0));
                        excel.CreateCell(styleSumC, 2, ht["DEP_NO"].ToString());
                        excel.CreateCell(styleSumC, 3,  ht["TOTAL_PRICE"].ToString());
                        excel.CreateCell(styleSumC, 4, ht["NOTIFY_DATE1"].ToString());
                    }   

                    else
                    {
                        excel.CreateCell(styleContR, 0, ht["CAR_NO"].ToString());
                        excel.CreateCell(styleContR, 1, med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0));
                        excel.CreateCell(styleContR, 2, ht["DEP_NO"].ToString());
                        excel.CreateCell(styleContR, 3, ht["TOTAL_PRICE"].ToString());
                        excel.CreateCell(styleContR, 4, ht["NOTIFY_DATE1"].ToString());

                    }



                }

                //設定列印配置
                excel.SetPagesize(9);     //A4
                excel.SetLandscape(true);//橫印     
                excel.SetHorizontallyCenter(true);
                excel.setScale(94);      //設定縮放 %
                excel.SetMargin(0, 0, 0, 0);  //設定邊寬
                excel.SetFooterMargin(0.5);
                excel.SetCenterFooter(ContFont, "第 " + ExcelUtility.GetNowPage() + " 頁");//設定頁尾(頁次)
                excel.SetRepeatRegion(0, -1, -1, 0, 2);

                //輸出檔案
                excel.GetHSSFWorkbook().Write(Response.OutputStream);
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("臺北市政府環境保護局報修車輛委外託修統計表.xls", System.Text.Encoding.UTF8));
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
        else
        {
            SysMsg.AlertMessage(this.Page,"必須同一年");

        }

    }
}