using System;
using System.Data;
using System.IO;
/// <summary>
/// 加油資料匯入：新增頁
/// </summary>
public partial class TDTSb002_TDTSb002I1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSb002_insert");

                HtmlTag hTag = new HtmlTag();




            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 返回按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSb002Q1.aspx", "", this));
    }


    /// <summary>
    /// 儲存按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        err_msg.Text = string.Empty;
        String ErrorMsg = "";
        int ErrorRow = 0;

        try
        {
            if (FileUpload1.HasFile)
            {
                dao.open();
                dao.beginTransaction();

                CPCModel model = new CPCModel();
                model.dao = dao;

                String report_ym_str = HandleParam.addZero(report_y.Text, 3) + "/" +
                    HandleParam.addZero(report_m.Text, 2);

                DateTime report_date = Convert.ToDateTime(DateTransfer.c_date_trans(report_ym_str + "/01"));

                string oil = Oil.SelectedValue;
                if(Oil.SelectedValue=="中油")
                {
                    #region 刪除舊資料

                    DataSet ds = model.selectCPCImpByReportYM(report_ym_str,oil);
                    if (ds.Tables[0].DefaultView.Count.ToString() != "0")
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        String import_id = dr["import_id"].ToString();

                        model.deleteCPCImpByReportYM(import_id);
                        model.deleteCPCMstByReportYM(import_id);
                    }
                    #endregion

                    #region 檔案複製到根目錄Export資料夾
                    string saveDir = Server.MapPath("../Export/");
                    DirectoryInfo dir = new DirectoryInfo(saveDir);
                    String filename = string.Empty;

                    if (FileUpload1.HasFile)
                    {
                        string str = DateTime.Now.ToString("yyyyMMddHHmmss");
                        filename = str + "_" + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        FileUpload1.PostedFile.SaveAs(saveDir + filename);
                    }
                    #endregion

                    #region 新增至主檔

                    Form mstform = new Form();
                    mstform.setValue("import_user", userID.getUserID());
                    mstform.setValue("report_ym", report_ym_str);
                    mstform.setValue("memo", memo.Text.Trim());
                    mstform.setValue("oil", Oil.SelectedValue);
                    decimal export_id = model.insertImportMst(mstform);

                    #endregion

                    #region 讀取excel儲存至明細檔
                    ExcelUtility excel = new ExcelUtility(saveDir + filename);
                    excel.GetSheet(0);

                    for (int i = 2; i <= excel.GetLastRow(); i++)
                    {
                        ErrorRow = i - 1;
                        excel.GetRow(i);

                        #region 資料檢核

                        if (excel.getCellValue(6) != null && string.IsNullOrEmpty(excel.getCellValue(6).Trim()))
                        {
                            ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：管理單位代號空白，請修正資料後重新匯入。";
                            break;
                        }

                        #endregion

                        string date = excel.getCellValue(9).Trim();
                        date = date.Substring(1, date.Length - 2);



                        string time = HandleParam.addZero(excel.getCellValue(10).Trim(), 6);

                        time = time.Substring(1, date.Length - 2);


                        Form form = new Form();
                        form.setValue("seller_id", excel.getCellValue(0).Trim());
                        form.setValue("seller_name", excel.getCellValue(1).Trim());
                        form.setValue("custom_id", excel.getCellValue(2).Trim());
                        form.setValue("custom_name", excel.getCellValue(3).Trim());
                        form.setValue("biller_id", excel.getCellValue(4).Trim());
                        form.setValue("biller_name", excel.getCellValue(5).Trim());

                        String mng_name = excel.getCellValue(7).Trim();
                        String mng_id = excel.getCellValue(6).Trim();
                        string[] mngNames = {
    "士林清潔隊", "大同清潔隊", "大安清潔隊", "中山清潔隊", "中正清潔隊",
    "內湖清潔隊", "文山清潔隊", "公廁管理隊", "北投清潔隊", "環境檢驗中心",
    "松山清潔隊", "直屬清潔隊", "信義清潔隊", "南港清潔隊", "政風室",
    "修車廠", "秘書室", "廢棄物處理場", "清山淨水", "空污噪音防制科",
    "水質病媒管制科", "溝渠一隊", "溝渠二隊", "萬華清潔隊", "資源回收隊",
    "職業安全管理科", "氣候變遷管理科", "綜合企劃科", "環境清潔管理科",
    "廢棄物處理管理科", "資源循環管理科"
};

                        string[] mngIds = {
    "TT002I591", "TT002I592", "TT002I593", "TT002I594", "TT002I595",
    "TT002I596", "TT002I597", "TT002I598", "TT002I599", "TT002I600",
    "TT002I601", "TT002I602", "TT002I603", "TT002I604", "TT002I605",
    "TT002I606", "TT002I607", "TT002I608", "TT002I609", "TT002I610",
    "TT002I611", "TT002I612", "TT002I613", "TT002I614", "TT002I615",
    "TT002I617", "TT002I619", "TT002I620", "TT002I621", "TT002I622",
    "TT002I623"
};

                        int index = Array.IndexOf(mngNames, mng_name);
                        if (index != -1)
                        {
                            mng_id = mngIds[index];
                        }

                    


                        form.setValue("mng_id", mng_id);
                        form.setValue("mng_name", mng_name);
                        String card_no= excel.getCellValue(8).Trim();
                        card_no= card_no.Substring(1, card_no.Length - 2);

                        form.setValue("card_no", card_no);
                        form.setValue("deal_date", date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" +
                            date.Substring(6, 2) + " " + time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4, 2));
                        string[] stand = excel.getCellValue(11).Trim().Split('/');
                        form.setValue("stand_id", stand[0]);
                        form.setValue("stand_name", stand[1]);
                        form.setValue("fuel_name", excel.getCellValue(12).Trim());
                        form.setValue("fuel_count", excel.getCellValue(13).Trim());
                        form.setValue("fuel_amount", excel.getCellValue(14).Trim());

                        if (report_date < Convert.ToDateTime("2012/06/01"))
                        {
                            try { form.setValue("memo1", excel.getCellValue(15).Trim()); }
                            catch { form.setValue("memo1", ""); }
                            try { form.setValue("memo2", excel.getCellValue(16).Trim()); }
                            catch { form.setValue("memo2", ""); }
                            form.setValue("unit_price", "");
                            form.setValue("cpc_class", "");
                        }
                        else
                        {
                            form.setValue("unit_price", excel.getCellValue(15).Trim());
                            form.setValue("cpc_class", excel.getCellValue(16) != null ? excel.getCellValue(16).Trim() : "");
                            try { form.setValue("memo1", excel.getCellValue(17).Trim()); }
                            catch { form.setValue("memo1", ""); }
                            try { form.setValue("memo2", excel.getCellValue(18).Trim()); }
                            catch { form.setValue("memo2", ""); }
                        }

                        form.setValue("import_id", export_id.ToString());
                        form.setValue("report_ym", report_ym_str);
                        if (excel.getCellValue(12).Contains("柴油"))
                        {
                            form.setValue("fuel_type", "DIESEL"); //柴油
                        }
                        else if (excel.getCellValue(12).Contains("汽油"))
                        {
                            form.setValue("fuel_type", "GASOLINE"); //汽油
                        }

                        form.setValue("cfm_status", "0");
                        form.setValue("create_user", userID.getUserID());
                        form.setValue("oil", Oil.SelectedValue);

                        //新增匯入                
                        model.insertImportDtl(form);
                    }
                    #endregion

                    #region 更新主檔筆數
                    model.updateImportCount(export_id.ToString());


                    #endregion


                }
                if (Oil.SelectedValue == "台塑")
                {
                    #region 刪除舊資料

                    DataSet ds = model.selectCPCImpByReportYM1(report_ym_str, oil);
                    if (ds.Tables[0].DefaultView.Count.ToString() != "0")
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        String import_id = dr["import_id"].ToString();

                        model.deleteCPCImpByReportYM(import_id);
                        model.deleteCPCMstByReportYM(import_id);
                    }
                    #endregion

                    #region 檔案複製到根目錄Export資料夾
                    string saveDir = Server.MapPath("../Export/");
                    DirectoryInfo dir = new DirectoryInfo(saveDir);
                    String filename = string.Empty;

                    if (FileUpload1.HasFile)
                    {
                        string str = DateTime.Now.ToString("yyyyMMddHHmmss");
                        filename = str + "_" + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        FileUpload1.PostedFile.SaveAs(saveDir + filename);
                    }
                    #endregion

                    #region 新增至主檔

                    Form mstform = new Form();
                    mstform.setValue("import_user", userID.getUserID());
                    mstform.setValue("report_ym", report_ym_str);
                    mstform.setValue("memo", memo.Text.Trim());
                    mstform.setValue("oil", Oil.SelectedValue );

                    decimal export_id = model.insertImportMst(mstform);

                    #endregion

                    #region 讀取excel儲存至明細檔
                    ExcelUtility excel = new ExcelUtility(saveDir + filename);
                    excel.GetSheet(0);

                    for (int i = 1; i <= excel.GetLastRow(); i++)
                    {
                        ErrorRow = i - 1;
                        excel.GetRow(i);

                        #region 資料檢核

                        if (excel.getCellValue(6) != null && string.IsNullOrEmpty(excel.getCellValue(6).Trim()))
                        {
                            ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：管理單位代號空白，請修正資料後重新匯入。";
                            break;
                        }

                        #endregion

                        string date = excel.getCellValue(7).Trim();//交易日要改 1130401
                        int year = int.Parse(date.Substring(0, 3)) + 1911;
                        string monthDay = date.Substring(3);
                        date = year.ToString() + monthDay;




                        string time = HandleParam.addZero(excel.getCellValue(8).Trim(), 6);//交易時間要改 140055
                        Form form = new Form();
                        form.setValue("seller_id", "TPSC");
                        form.setValue("seller_name", "台塑");
                        form.setValue("custom_id", "TPHP");
                        form.setValue("custom_name", "臺北市政府環保局");
                        form.setValue("biller_id", "A00000001");
                        form.setValue("biller_name", "台北市政府環境保護局");

                        String mng_name = excel.getCellValue(1).Trim();
                        String mng_id ="";
                        string[] mngNames = {
    "環保局士林清潔隊", "環保局大同清潔隊", "環保局大安清潔隊", "環保局中山清潔隊", "環保局中正清潔隊",
    "環保局內湖清潔隊", "環保局文山清潔隊", "環保局公廁管理隊", "環保局北投清潔隊", "環保局環境檢驗中心",
    "環保局松山清潔隊", "環保局直屬清潔隊", "環保局信義清潔隊", "環保局南港清潔隊", "環保局政風室",
    "環保局修車廠", "環保局秘書室", "環保局廢棄物處理場", "環保局清山淨水", "環保局空污噪音防制科",
    "環保局水質病媒管制科", "環保局溝渠一隊", "環保局溝渠二隊", "環保局萬華清潔隊", "環保局資源回收隊",
    "環保局職業安全管理科", "環保局氣候變遷管理科", "環保局綜合企劃科", "環保局環境清潔管理科",
    "環保局廢棄物處理管理科", "環保局資源循環管理科"
};

                        string[] mngIds = {
    "TT002I591", "TT002I592", "TT002I593", "TT002I594", "TT002I595",
    "TT002I596", "TT002I597", "TT002I598", "TT002I599", "TT002I600",
    "TT002I601", "TT002I602", "TT002I603", "TT002I604", "TT002I605",
    "TT002I606", "TT002I607", "TT002I608", "TT002I609", "TT002I610",
    "TT002I611", "TT002I612", "TT002I613", "TT002I614", "TT002I615",
    "TT002I617", "TT002I619", "TT002I620", "TT002I621", "TT002I622",
    "TT002I623"
};

                        int index = Array.IndexOf(mngNames, mng_name);
                        if (index != -1)
                        {
                            mng_id = mngIds[index];
                        }

                        mng_name = mng_name.Remove(0, 3);

                        form.setValue("mng_id", mng_id);
                        form.setValue("mng_name", mng_name);
                        form.setValue("card_no", excel.getCellValue(6).Trim());
                        form.setValue("deal_date", date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" +
                            date.Substring(6, 2) + " " + time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4, 2));
                        string[] stand = excel.getCellValue(11).Trim().Split('/');//油站
                        form.setValue("stand_id", excel.getCellValue(2).Trim());
                        form.setValue("stand_name", excel.getCellValue(3).Trim());

                        string fuel_name = excel.getCellValue(9).Trim();
                        if(fuel_name.Trim()== "DO-P")
                        {
                            fuel_name = "超級柴油";

                        }
                        if (fuel_name.Trim() == "MG-95")
                        {
                            fuel_name = "95無鉛汽油";

                        }
                        if (fuel_name.Trim() == "MG-92")
                        {
                            fuel_name = "92無鉛汽油";

                        }
                        form.setValue("fuel_name", fuel_name);//超級柴油



                        form.setValue("fuel_count", excel.getCellValue(10).Trim());//63.05
                        form.setValue("fuel_amount", excel.getCellValue(17).Trim());//1690

                        form.setValue("unit_price", excel.getCellValue(19).Trim());


                        form.setValue("import_id", export_id.ToString());
                        form.setValue("report_ym", report_ym_str);
                        if (excel.getCellValue(9).Contains("DO-P"))
                        {
                            form.setValue("fuel_type", "超級柴油"); //超級柴油
                        }
                        else if (excel.getCellValue(9).Contains("MG-95"))
                        {
                            form.setValue("fuel_type", "95無鉛汽油"); //95無鉛汽油
                        }
                        else if (excel.getCellValue(9).Contains("MG-92"))
                        {
                            form.setValue("fuel_type", "92無鉛汽油"); //92無鉛汽油
                        }

                        form.setValue("cfm_status", "0");
                        form.setValue("create_user", userID.getUserID());
                        form.setValue("oil",Oil.SelectedValue);

                        //新增匯入                
                        model.insertImportDtl(form);
                    }
                    #endregion

                    #region 更新主檔筆數
                    model.updateImportCount(export_id.ToString());


                    #endregion


                }

                if (ErrorMsg == string.Empty)
                {
                    dao.commit();
                    SysMsg.AlertMessage(this.Page, "匯入成功！");
                }
                else
                {
                    dao.rollback();
                    err_msg.Text = ErrorMsg;
                }
            }
            else
            {
                SysMsg.AlertMessage(this.Page, "請選擇檔案來源！");
            }
        }
        catch (Exception ex)
        {
            dao.rollback();
            err_msg.Text = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：" + ex.Message + "<br>" + ex.StackTrace;
            SysMsg.AlertMessage(this.Page, "匯入失敗！請將網頁上的錯誤訊息及欲匯入之Excel檔寄送至系統管理員。");
        }
        finally
        {
            dao.close();
        }







    }


    /// <summary>
    /// 依車號取得車輛ID
    /// </summary>
    /// <param name="car_no"></param>
    /// <returns></returns>
    private String getCarIdbyCarNo(String car_no)
    {
        String car_id = string.Empty;
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();
            CarModel model = new CarModel();
            model.dao = dao;
            car_id = model.getCarIdbyCarNo(car_no);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            dao.close();
        }

        return car_id;
    }



    protected void Oil_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

