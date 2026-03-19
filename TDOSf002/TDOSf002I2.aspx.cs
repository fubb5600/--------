using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
/// <summary>
/// 加油資料匯入：新增頁
/// </summary>
public partial class TDTSe002_TDTSe002I2 : System.Web.UI.Page
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
        Response.Redirect(Forward.Redirect("TDOSf002Q1.aspx", "", this));
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

        int ErrorRow = 0;
        String ErrorMsg = "";

        try
        {
            if (FileUpload1.HasFile)
            {
                dao.open();
                dao.beginTransaction();

                RepairModel model = new RepairModel();
                model.dao = dao;


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
                ExcelUtility excel = new ExcelUtility(saveDir + filename);
                excel.GetSheet(0);
                excel.GetRow(1);

                //修改上傳檔案大小15360_wenny1061123

                FileInfo fInfo = new FileInfo(saveDir + filename);
                int rn = excel.GetLastRow();
                //Response.Write(rn);
                if (fInfo.Length / 1024 > 15360) //fInfol.Length單位為位元組(Byte)除以1024換算成KB
                {
                    //Response.Write(fInfo.Length/1024);
                    SysMsg.AlertMessage(this.Page, "檔案太大，請修正資料後重新匯入！");

                }

                else
                {
                    //修改檔案內無資料_wenny1061123
                    if (rn == 0)
                    {
                        SysMsg.AlertMessage(this.Page, "無資料，請修正資料後重新匯入！");
                    }
                    else
                    {
                        //test
                        string report_y_str = (excel.getCellValue(0).Trim()).Substring(0, 3);
                        Form mstform = new Form();
                        mstform.setValue("import_user", userID.getUserID());
                        mstform.setValue("report_y", report_y_str);
                        mstform.setValue("count", (excel.GetLastRow()).ToString());

                        //decimal export_id = model.insertComponentImp(mstform);

                        #endregion

                        //#region 刪除舊資料
                        //string lastY = (int.Parse(export_id.ToString()) - 1).ToString();
                        //model.deleteImportMst(lastY);
                        //model.deleteImportDtl(lastY);
                        //#endregion

                        #region 讀取excel儲存至明細檔

                        excel.GetSheet(0);
                        for (int i = 1; i <= excel.GetLastRow(); i++)
                        {
                            DataSet ds = model.selectRepairMst2(excel.getCellValue(0).Trim());
                            DataSet ds1 = model.selectRepairMst3(excel.getCellValue(1).Trim());
                            DataRow dr = ds.Tables[0].Rows[0];
                            DataRow dr1 = ds1.Tables[0].Rows[0];



                            //Date.Text = dr["notify_date"].ToString();
                            ErrorRow = (i + 1);

                            excel.GetRow(i);

                            #region 資料檢核
                            Form form = new Form();
                            try
                            {
                                form.setValue("car_id", dr["car_id"].ToString());
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：車輛不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try
                            {
                                form.setValue("crs_org", dr1["param_id"].ToString());
                            }
                            catch
                            {

                            }
                            try
                            {
                                form.setValue("case_no", excel.getCellValue(2).Trim());
                            }
                            catch
                            {

                            }

                            try { form.setValue("work_no", excel.getCellValue(3).Trim()); }
                            catch { }
                            try
                            {
                                form.setValue("repair_vender", excel.getCellValue(4).Trim());
                            }
                            catch
                            {

                            }
                            try
                            {
                                form.setValue("notify_date", excel.getCellValue(5).Trim());
                            }
                            catch
                            {

                            }
                            try
                            {
                                form.setValue("exec_deadline", excel.getCellValue(6).Trim());
                            }
                            catch
                            {

                            }
                            try { form.setValue("finish_date", excel.getCellValue(7).Trim()); }
                            catch { }
                            try { form.setValue("check_date", excel.getCellValue(8).Trim()); }
                            catch { }
                            try
                            {

                                form.setValue("qualified_date", excel.getCellValue(9).Trim());

                            }
                            catch
                            {
                            }
                            try
                            {
                                form.setValue("delivery_days", excel.getCellValue(10));
                            }
                            catch
                            {

                            }
                            try
                            {
                                form.setValue("is_late", excel.getCellValue(11));

                            }
                            catch
                            {

                            }
                            try
                            {
                                form.setValue("check_result", excel.getCellValue(12));

                            }
                            catch
                            {

                            }
                            try
                            {
                                form.setValue("memo", excel.getCellValue(13));

                            }
                            catch
                            {

                            }


                            try
                            {
                                form.setValue("create_date", excel.getCellValue(14));

                            }
                            catch
                            {

                            }
                            try
                            {
                                form.setValue("delivery_unit", excel.getCellValue(15));

                            }
                            catch
                            {

                            }
                            try
                            {
                                form.setValue("budget_area", excel.getCellValue(16));

                            }
                            catch
                            {

                            }
                            //form.setValue("import_id", export_id.ToString());
                            form.setValue("create_user", userID.getUserID());
                            #endregion

                            //新增匯入 
                            Decimal repair_id = model.insertRepairMst(form);
                        }
                        #endregion



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

}