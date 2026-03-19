using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// 委外託修作業：查詢頁
/// 
/// 
/// </summary>
public partial class TDOSd009_TDOSd009Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
        #region     //wenny_test_報修五日填資料
        //if (!IsPostBack)

        //{ //wenny_test_報修五日填資料
        //    string str = "下列派工單編號委外託修作業相關資料尚未建置完整\\n";
        //    //for (int i = 0; i < 100; i++)
        //    //{
        //    //    str = str + 'a'+"\\n";
        //    //}

        //    SysMsg.AlertMessage(this.Page, str);
        //}
        #endregion
        if (IsPostBack)
        {
            var ctlName = this.Request.Params["__EVENTTARGET"];



        }
        else
        {

        }
        try
        {

            dao.open();
            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限
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










                        User.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                    }

                    User.Items.Insert(0, new System.Web.UI.WebControls.ListItem("請選擇", ""));
                    User.SelectedValue = userID.getUserOrg1();
                    if (userID.getUserRead() == "SELF")
                    {
                        User.Enabled = false;

                    }

                }

                RepairModel model = new RepairModel();
                model.dao = dao;







                //分頁設定
                //查詢資料
                Form form = new Form();
                PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
                pb.setDBDAO(dao);
                //wenny_test_排序
                if (string.IsNullOrEmpty(sortedfield.Value))
                {
                    sortedfield.Value = Session["field"].ToString();//查詢排序編輯後返回頁面
                }
                DataSet ds = pb.doSearch(model, "browse3");

                //wenny_test_排序
                //DataSet ds = pb.doSearch(model, "browse1");

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                    pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
                }
                else
                    pnlPrint.Visible = false;

                String typeValue = "";
                String carnoValue = "";
                String depnoValue = "";
                String venderValue = "";
                String worknoValue = "";
                String casenoValue = "";
                String orgValue = "";
                //2018/08/31測試查驗結果Checkbox
                String resultValue0 = "";
                String resultValue1 = "";
                String resultValue2 = "";
                //2018/08/31測試查驗結果Checkbox
                String repair1Value = "";
                String repair2Value = "";
                String repair3Value = "";
                String notifyStartValue = "";
                String notifyEndValue = "";
                String finishStartValue = "";
                String finishEndValue = "";

                //有預設值，若有查詢過，則以新條件為準
                if (pb.isDoSearch())
                {
                    typeValue = form.getValue("notify_type");
                    carnoValue = form.getValue("car_no");
                    depnoValue = form.getValue("dep_no");
                    venderValue = form.getValue("repair_vender");
                    worknoValue = form.getValue("work_no");
                    casenoValue = form.getValue("case_no");
                    //2018/08/31測試查驗結果Checkbox
                    //  resultValue = form.getValue(resultValue);//2018/08/31測試查驗結果Checkbox before
                    resultValue0 = form.getValue("resultValue0");
                    resultValue1 = form.getValue("resultValue1");
                    resultValue2 = form.getValue("resultValue2");
                    //2018/08/31測試查驗結果Checkbox
                    repair1Value = form.getValue("repair_type1");
                    repair2Value = form.getValue("repair_type2");
                    repair3Value = form.getValue("repair_type3");
                    notifyStartValue = form.getValue("notify_start");
                    notifyEndValue = form.getValue("notify_end");
                    finishStartValue = form.getValue("finish_start");
                    finishEndValue = form.getValue("finish_end");
                }


              

                //User.DataSource = dt;
                //User.DataTextField = "Nickname";
                //User.DataValueField = "Nickname";
                //User.DataBind();

            



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
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


    /// <summary>
    /// GridView1_RowDataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    
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
            String User1 = User.SelectedItem.ToString();


            dao.open();

            Form form = new Form();
            if (User.SelectedValue == "")
            {
                form.setValue("User", userID.getUserOrg());

            }
            else
            {
                form.setValue("User", HandleParam.getMultiValue(User));


            }


        
           
            form.setValue("Thing", Thing.Text.Trim());
            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse3");
            Session["field"] = "browse3";
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
    /// gvMain_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {

        string repair_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();

        Response.Redirect(Forward.Redirect("TDOSd008U1.aspx?repair_id=" + repair_id, "", this));
    }














    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnQuery1_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];

        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        TDOS tdos = new TDOS();
        try
        {


            String User1 = User.SelectedItem.ToString();

            dao.open();

            Form form = new Form();
            form.setValue("Thing", Thing.Text.Trim());


          
           form.setValue("User", User.SelectedValue);

         








            RepairModel model = new RepairModel();
            model.dao = dao;
            ArrayList al = model.Print(form);
          

         
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
            excel.CreateCell(styleHtitle, 0, "臺北市政府環境保護局庫存");
            //列印日期
            excel.CreateRow(1);
            excel.AddMergedRegion(1, 1, 0, 9);
            excel.AddMergedRegion(1, 1, 10, 12); //新增零件編號欄位_wenny1061225
            excel.CreateCell(styleHdateR, 10, "列印日期：" + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")));

            //標題
            excel.CreateRow(2);


            excel.CreateCell(styleTitleC, 0, "使用者");
            excel.SetColumnWidth(0, 85);//新增零件編號欄位_wenny1061225

            excel.CreateCell(styleTitleC, 1, "庫存");
            excel.SetColumnWidth(1, 95);

            excel.CreateCell(styleTitleC, 2, "數量");
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
                excel.CreateCell(styleContL, 0, ht["USER1"].ToString());
                excel.CreateCell(styleContL, 1, ht["THING"].ToString());
                excel.CreateCell(styleContR, 2, ht["COUNT"].ToString());
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
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("臺北市政府環境保護局庫存.xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel "; //內容型態設為Excel


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
}