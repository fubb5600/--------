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
public partial class TDTSe002_TDTSe002I1 : System.Web.UI.Page
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
                btnSave.Visible = userID.hasFunc("TDOSe002_insert");


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
        Response.Redirect(Forward.Redirect("TDOSe002Q1.aspx", "", this));
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
        int ErrorRow = 0;
        String ErrorMsg = "";

        try
        {
            if (FileUpload1.HasFile)
            {
                dao.open();
                dao.beginTransaction();

                ComponentModel model = new ComponentModel();
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
                int rn =excel.GetLastRow();
                 //Response.Write(rn);
                if (fInfo.Length/1024 > 15360) //fInfol.Length單位為位元組(Byte)除以1024換算成KB
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
                        mstform.setValue("memo", memo.Text.Trim());
                        decimal export_id = model.insertComponentImp(mstform);

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
                            ErrorRow = (i + 1);

                            excel.GetRow(i);

                            #region 資料檢核
                            Form form = new Form();
                            try
                            {
                                form.setValue("component_no", excel.getCellValue(0).Trim());
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：零件編號不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try
                            {
                                form.setValue("component_name", excel.getCellValue(1).Trim());
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：項目名稱不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try
                            {
                                form.setValue("component_spec", excel.getCellValue(2).Trim());
                            }
                            catch
                            {
                                form.setValue("component_spec", "");
                            }

                            try { form.setValue("count", Regex.Replace(excel.getCellValue(3).Trim(), @"[\W_]+", "")); }
                            catch { form.setValue("count", ""); }
                            try
                            {
                                form.setValue("unit", excel.getCellValue(4).Trim());
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：單位不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try
                            {
                                form.setValue("component_code", excel.getCellValue(5).Trim());
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：代碼不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try
                            {
                                form.setValue("car_type", excel.getCellValue(6).Trim());
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：適用車種不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try { form.setValue("place_of_origin", excel.getCellValue(7).Trim()); }
                            catch { form.setValue("place_of_origin", ""); }
                            try { form.setValue("memo", excel.getCellValue(8).Trim()); }
                            catch { form.setValue("memo", ""); }
                            try
                            {
                                
                                form.setValue("budget1", excel.getCellValue(9).Trim());//資料庫改成小數型態_wenny1061123
                                //form.setValue("budget1", Regex.Replace(excel.getCellValue(9).ToString().Trim(), @"[\W_]+", ""));
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：預算單價(第一區)不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try
                            {
                                form.setValue("budget2", excel.getCellValue(10));//資料庫改成小數型態_wenny1061123
                                //form.setValue("budget2", Regex.Replace(excel.getCellValue(10).ToString().Trim(), @"[\W_]+", ""));
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：預算單價(第二區)不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try
                            {
                                form.setValue("budget3", excel.getCellValue(11));//資料庫改成小數型態_wenny1061123
                                //form.setValue("budget3", Regex.Replace(excel.getCellValue(11).ToString().Trim(), @"[\W_]+", ""));
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：預算單價(第三區)不正確，請修正資料後重新匯入。";
                                break;
                            }
                            try
                            {
                                form.setValue("budget4", excel.getCellValue(12));//資料庫改成小數型態_wenny1061123
                                //form.setValue("budget4", Regex.Replace(excel.getCellValue(12).ToString().Trim(), @"[\W_]+", ""));
                            }
                            catch
                            {
                                ErrorMsg = "第" + ErrorRow + "筆資料發生錯誤，錯誤訊息：預算單價(第四區)不正確，請修正資料後重新匯入。";
                                break;
                            }
                            form.setValue("import_id", export_id.ToString());
                            form.setValue("create_user", userID.getUserID());
                            #endregion

                            //新增匯入 
                            model.insertImportDtl(form);
                        }
                        #endregion

                        #region 更新主檔筆數
                        //model.updateImportCount(export_id.ToString());

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