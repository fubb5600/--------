using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;
/// <summary>
/// 載重資料匯入：新增頁
/// </summary>
public partial class TDTSc005_TDTSc005I1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();

            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSc005_insert");
                hTag.createMediatorSelect("LOAD_ORG", load_org, "", "請選擇", 0);

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
        Response.Redirect(Forward.Redirect("TDOSc005Q1.aspx", "", this));
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
        Boolean error = false;
        int row = 0;
        lblErrorMsg.Text = "";
        try
        {
            if (FileUpload1.HasFile)
            {
                dao.open();
                dao.beginTransaction();


                LoadModel model = new LoadModel();
                model.dao = dao;

                String report_ym_str = HandleParam.addZero(report_y.Text.Trim(), 3) + "/" +
                    HandleParam.addZero(report_m.Text.Trim(), 2);

                Form del_form = new Form();
                del_form.setValue("report_ym", report_ym_str);
                del_form.setValue("load_org", load_org.SelectedValue);
                #region 刪除舊資料

                model.deleteLoadMstByReportYM(del_form);
                model.deleteLoadImpByReportYM(del_form);

                #endregion

                #region 檔案複製到根目錄Export資料夾
                string saveDir = Server.MapPath("../Load_IMP/");
                DirectoryInfo dir = new DirectoryInfo(saveDir);
                String filename = string.Empty;

                if (FileUpload1.HasFile)
                {
                    string str = DateTime.Now.ToString("yyyyMMddHHmmss");
                    filename = str + "_" + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(saveDir + filename);
                }
                #endregion

                #region 新增至匯入檔

                Form imp_form = new Form();
                imp_form.setValue("imp_user", userID.getUserID());
                imp_form.setValue("report_ym", report_ym_str);
                imp_form.setValue("load_org", load_org.SelectedValue);
                imp_form.setValue("memo", memo.Text.Trim());
                decimal imp_id = model.insertImportMst(imp_form);

                #endregion

                #region 讀取excel儲存至主檔
                ExcelUtility excel = new ExcelUtility(saveDir + filename);
                excel.GetSheet(0);

                for (int i = 2; i <= excel.GetLastRow(); i++)
                {
                    row++;
                    excel.GetRow(i);
                    Form form = new Form();

                    //string load_dt = HandleParam.addZero(excel.getCellValue(0), 9);
                    //int yyyy = Convert.ToInt32(load_dt.Substring(0, 3)) + 1911;
                    //int MM = Convert.ToInt32(load_dt.Substring(4, 2));
                    //int dd = Convert.ToInt32(load_dt.Substring(7, 2));
                    //int HH = Convert.ToInt32(excel.getCellValue(1).Substring(0, 2));
                    //int mm = Convert.ToInt32(excel.getCellValue(1).Substring(3, 2));
                    //int ss = Convert.ToInt32(excel.getCellValue(1).Substring(6, 2));

                    if (excel.getCellValue(0).Trim() != string.Empty)
                    {
                        try
                        {

                            string first_cell = excel.getCellValue(0).Trim();
                            int number;
                            DateTime dateValue;

                            string[] load_time = excel.getCellValue(1).Trim().Split(':');
                            int HH = Convert.ToInt32(load_time[0]);
                            int mm = Convert.ToInt32(load_time[1]);
                            int ss = Convert.ToInt32(load_time[2]);

                            if (Int32.TryParse(first_cell, out number))
                            {
                                DateTime time = new DateTime(1900, 1, 1);
                                dateValue = time.AddDays(number - 2);
                                DateTime load_date = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day, HH, mm, ss);
                                form.setValue("load_date", load_date.ToString("yyyy/MM/dd HH:mm:ss"));
                            }
                            else if (DateTime.TryParse(first_cell, out dateValue))
                            {
                                string[] load_dt = first_cell.Split('/');
                                int yyyy = Convert.ToInt32(load_dt[0]);

                                if (load_dt[0].Length != 4)
                                {
                                    yyyy = yyyy + 1911;
                                }
                                int MM = Convert.ToInt32(load_dt[1]);
                                int dd = Convert.ToInt32(load_dt[2]);
                                dateValue = new DateTime(yyyy, MM, dd);
                                DateTime load_date = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day, HH, mm, ss);
                                form.setValue("load_date", load_date.ToString("yyyy/MM/dd HH:mm:ss"));
                            }
                            else
                            {
                                form.setValue("load_date", "");
                                form.setValue("memo", "進廠時間無法轉換：" + "\"" + excel.getCellValue(0) + " " + excel.getCellValue(1) + "\"");
                                error = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            form.setValue("load_date", "");
                            form.setValue("memo", "進廠時間錯誤：" + "\"" + excel.getCellValue(0) + " " + excel.getCellValue(1) + "\"" + ex.Message);
                            error = true;
                        }
                    }

                    try
                    {
                        form.setValue("car_no", excel.getCellValue(2).Trim());
                    }
                    catch
                    {
                        form.setValue("car_no", "");
                    }

                    try
                    {
                        form.setValue("net_weight", excel.getCellValue(3).Trim());
                    }
                    catch
                    {
                        form.setValue("net_weight", "");
                    }

                    form.setValue("report_ym", report_ym_str);
                    form.setValue("imp_id", imp_id.ToString());

                    //新增匯入     
                    if (form.getValue("car_no") != string.Empty && form.getValue("net_weight") != string.Empty)
                    {
                        model.insertImportDtl(form);
                    }

                }
                #endregion

                #region 更新主檔筆數
                model.updateImportCount(imp_id.ToString());

                #endregion
                dao.commit();
                string errorMsg = string.Empty;
                if (error)
                    errorMsg = "但是有錯誤發生。";
                SysMsg.AlertMessage(this.Page, "匯入成功！" + errorMsg);
            }
            else
            {
                SysMsg.AlertMessage(this.Page, "請選擇檔案來源！");
            }
        }
        catch (Exception ex)
        {
            dao.rollback();
            lblErrorMsg.Text = "匯入失敗！資料列第" + row + "筆發生錯誤。";
            SysMsg.AlertMessage(this.Page, "匯入失敗！資料列第" + row + "筆。\n" + ex.Message + "\n" + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }
    }
}