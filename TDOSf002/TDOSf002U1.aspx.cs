using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
/// <summary>
/// 委外託修作業：修改頁
/// </summary>
public partial class TDOSf002_TDOSf002U1 : System.Web.UI.Page
{
    string check_result_value = "";
    string is_late_value = "";
    string time_unit_value = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        TDOS tdos = new TDOS();

        try
        {
            if (!IsPostBack)
            {
                //button權限
                //btnSave.Visible = userID.hasFunc("TDOSf002_update");
                btnDelete.Visible = userID.hasFunc("TDOSf002_delete");
                btnPrint1.Visible = userID.hasFunc("TDOSf002_print");
                btnPrint2.Visible = userID.hasFunc("TDOSf002_print");
                btnPrint3.Visible = userID.hasFunc("TDOSf002_print");

                HtmlTag hTag = new HtmlTag();

                Form form = new Form();
                form.setValue("repair_id", Request["repair_id"]);
                RepairModel model = new RepairModel();
                model.dao = dao;
                dao.open();

                DataSet ds = model.selectRepairMst(form.getValue("repair_id"));
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["status"].ToString()=="X")
                {
                    exec_deadline.Enabled = false;
                    exec_HH.Enabled = false;
                    exec_mm.Enabled = false;
                    finish_date.Enabled = false;
                    finish_HH.Enabled = false;
                    finish_mm.Enabled = false;
                    check_date.Enabled = false;
                    check_HH.Enabled = false;
                    check_mm.Enabled = false;
                    qualified_date.Enabled = false;
                    qualified_HH.Enabled = false;
                    qualified_mm.Enabled = false;



                }
                    
                repair_id.Value = dr["repair_id"].ToString();
                car_id.Value = dr["car_id"].ToString();
                crs_org.Value = dr["crs_org"].ToString();
                repair_type3.Value = dr["repair_type3"].ToString();
                work_no.Text = dr["work_no"].ToString();
                repair_vender.Text = dr["repair_vender"].ToString();
                //case_no_y.Text = dr["case_no"].ToString().Substring(0, 3);
                //case_no_v.Text = dr["case_no"].ToString().Substring(7, 3);
                case_no.Text = dr["case_no"].ToString();
                budget_area.Value = dr["budget_area"].ToString();

                if (dr["repair_type3"].ToString().Equals("OUT"))
                {
                    region_year.Value = case_no.Text.Substring(1, 3);
                    year.Text = case_no.Text.Substring(1, 3);
                }
                else
                {
                    region_year.Value = case_no.Text.Substring(0, 3);
                    year.Text = case_no.Text.Substring(0, 3);
                }
                region_caseno.Value = dr["case_no"].ToString();

                region_vender.Value = med.lookupParamId("REPAIR_VENDER", dr["REPAIR_VENDER"].ToString());
                //2018 / 09 / 01RadioButtonList改成checkBox
                //hTag.createMediatorRadio("TIME_UNIT", time_unit, dr["delivery_unit"].ToString(), 0);

                if (dr["delivery_unit"].ToString() == "WORKDAY") time_unit1.Checked = true;
                else if ((dr["delivery_unit"].ToString() == "HOUR")) time_unit2.Checked = true;
                //2018/09/01RadioButtonList改成checkBox

                if (dr["notify_date"].ToString() != string.Empty)
                {
                    notify_date.Text = dr["notify_date"].ToString().Substring(0, 9);
                    if (!dr["notify_date"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        notify_HH.Text = dr["notify_date"].ToString().Substring(10, 2);
                        notify_mm.Text = dr["notify_date"].ToString().Substring(13, 2);
                    }
                }

                if (dr["exec_deadline"].ToString() != string.Empty)
                {
                    exec_deadline.Text = dr["exec_deadline"].ToString().Substring(0, 9);
                    if (!dr["exec_deadline"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        exec_HH.Text = dr["exec_deadline"].ToString().Substring(10, 2);
                        exec_mm.Text = dr["exec_deadline"].ToString().Substring(13, 2);
                    }
                }

                if (dr["finish_date"].ToString() != string.Empty)
                {
                    finish_date.Text = dr["finish_date"].ToString().Substring(0, 9);
                    if (!dr["finish_date"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        finish_HH.Text = dr["finish_date"].ToString().Substring(10, 2);
                        finish_mm.Text = dr["finish_date"].ToString().Substring(13, 2);
                    }
                }

                if (dr["check_date"].ToString() != string.Empty)
                {
                    check_date.Text = dr["check_date"].ToString().Substring(0, 9);
                    if (!dr["check_date"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        check_HH.Text = dr["check_date"].ToString().Substring(10, 2);
                        check_mm.Text = dr["check_date"].ToString().Substring(13, 2);
                    }
                }

                if (dr["qualified_date"].ToString() != string.Empty)
                {
                    qualified_date.Text = dr["qualified_date"].ToString().Substring(0, 9);
                    if (!dr["qualified_date"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        qualified_HH.Text = dr["qualified_date"].ToString().Substring(10, 2);
                        qualified_mm.Text = dr["qualified_date"].ToString().Substring(13, 2);
                    }
                }

                delivery_days.Text = dr["delivery_days"].ToString();
                memo.Text = dr["memo"].ToString();

                //hTag.createMediatorRadio("YES_NO", is_late, dr["is_late"].ToString(), 0);
                if (dr["is_late"].ToString() == "Y") is_late1.Checked = true;
                else if ((dr["is_late"].ToString() == "N")) is_late2.Checked = true;
                //hTag.createMediatorRadio("CHECK_RSLT", check_result, dr["check_result"].ToString(), 0); //2018/08/31測試查驗結果Checkbox
                if (dr["check_result"].ToString() == "PASS") check_result1.Checked = true;
                else if ((dr["check_result"].ToString() == "FAIL")) check_result2.Checked = true;
                //hTag.createMediatorSelect("CHECK_RSLT", check_result, dr["check_result"].ToString(), "請選擇", 0);
                hTag.createMediatorSelect("REPAIR_VENDER", repair_vender, med.lookupParamId("REPAIR_VENDER", dr["REPAIR_VENDER"].ToString()), "請選擇", 0);

                car_data.setDrNotify(dr);
                car_data.getNotifyData();

                TDOSf002U2.WorkNo = dr["work_no"].ToString();
                //crs_area.Value = tdos.getCRSArea(dr["crs_org"].ToString()).ToString();
                //crs_area.Value = dr["budget_area"].ToString(); //預算單價區域
                crs_area.SelectedValue = dr["budget_area"].ToString(); //預算單價區域

                TDOSf002U2.CRSArea = crs_area.SelectedValue;


                DataSet dsDtl = model.selectRepairDtl(form.getValue("repair_id"), dr["budget_area"].ToString());
                DataRow drDtl = dsDtl.Tables[0].Rows[0];

                if (drDtl["repair_item"].ToString().Length > 0)
                    drDtl["repair_item"] = drDtl["repair_item"].ToString().Replace("&amp;", "aaaaaaa");//20180206修正'&'出錯
                                                                                                       //TDOSf002U2.RepairItem = drDtl["repair_item"].ToString().Substring(0, drDtl["repair_item"].ToString().Length - 1);
                TDOSf002U2.RepairItem = drDtl["repair_item"].ToString().Substring(0, drDtl["repair_item"].ToString().Length - 1);

                repair_item.Value = TDOSf002U2.RepairItem;
                //SysMsg.AlertMessage(this.Page, repair_item.Value);
            }

            //genReapirItem(repair_item.Value);
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
        case_no_advise.Text = "";

        try
        {

            #region 檢查派工單是否按確定_wenny1061212
            if (string.IsNullOrEmpty(TDOSf002U2.WorkNo))
            {
                SysMsg.AlertMessage(this, "請輸入派工單編號");
                return;
            }
            #endregion
            if (CheckAll())
            {
                dao.open();
                dao.beginTransaction();

                Form form = new Form();
                form.setValue("repair_id", repair_id.Value);
                form.setValue("car_id", car_id.Value);
                form.setValue("crs_org", crs_org.Value);
                form.setValue("case_no", case_no.Text.Trim());
                form.setValue("work_no", work_no.Text.Trim());
                form.setValue("repair_vender", repair_vender.SelectedItem.Text);
                form.setValue("notify_date", TDOS.formatDateTimeForm(notify_date.Text, notify_HH.Text, notify_mm.Text));
                form.setValue("exec_deadline", TDOS.formatDateTimeForm(exec_deadline.Text, exec_HH.Text, exec_mm.Text));
                form.setValue("finish_date", TDOS.formatDateTimeForm(finish_date.Text, finish_HH.Text, finish_mm.Text));
                form.setValue("check_date", TDOS.formatDateTimeForm(check_date.Text, check_HH.Text, check_mm.Text));
                form.setValue("qualified_date", TDOS.formatDateTimeForm(qualified_date.Text, qualified_HH.Text, qualified_mm.Text));
                form.setValue("delivery_days", delivery_days.Text);

                // 2018 / 09 / 01RadioButtonList改成checkBox
                //form.setValue("delivery_unit", time_unit.SelectedValue);
                if (time_unit1.Checked)
                {
                    time_unit_value = "WORKDAY";
                }
                else if (time_unit2.Checked)
                {
                    time_unit_value = "HOUR";
                }
                else { check_result_value = ""; }
                form.setValue("delivery_unit", time_unit_value);


                //2018 / 09 / 01RadioButtonList改成checkBox

                //2018/08/31測試查驗結果Checkbox
                // form.setValue("check_result", check_result.SelectedValue); 2018/08/31測試查驗結果Checkbox befor

                if (check_result1.Checked)
                {
                    check_result_value = "PASS";
                }
                else if (check_result2.Checked)
                {
                    check_result_value = "FAIL";
                }
                else { check_result_value = ""; }
                form.setValue("check_result", check_result_value);



                //2018/08/31測試查驗結果Checkbox

                //2018/09/01RadioButtonList改成checkBox
                //form.setValue("is_late", is_late.SelectedValue);
                if (is_late1.Checked)
                {
                    is_late_value = "Y";
                }
                else if (is_late2.Checked)
                {
                    is_late_value = "N";
                }
                else { is_late_value = ""; }
                form.setValue("is_late", is_late_value);
                //2018/09/01RadioButtonList改成checkBox

                form.setValue("create_user", userID.getUserID());
                form.setValue("memo", memo.Text.Trim());
                form.setValue("budget_area", crs_area.SelectedValue);
                form.setValue("update_user", userID.getUserID());

                RepairModel model = new RepairModel();
                model.dao = dao;
                model.updateRepairMst(form);

                model.deleteRepairDtl(repair_id.Value);

                if (TDOSf002U2.RepairItem != string.Empty)
                {
                    //Label1.Text = TDOSf002U2.RepairItem.ToString();
                    string str = TDOSf002U2.RepairItem.ToString().Replace("&amp;", "aaaaaaa");//20180206修正'&'出錯
                    string[] arrRepair = str.Split(';');//20180206修正'&'出錯

                    //string[] arrRepair = TDOSf002U2.RepairItem.Substring(0, TDOSf002U2.RepairItem.Length).Split(';');//20180206修正'&'出錯_o

                    for (int i = 0; i < arrRepair.Length; i++)
                    {

                        string[] arrItem = arrRepair[i].Split('|');
                        arrItem[0] = arrItem[0].Replace("aaaaaaa", "&");//20180206修正'&'出錯
                        //Response.Write(arrItem[0] + "<br>");
                        //Response.Write(arrItem[1] + "<br>");
                        Form formItem = new Form();

                        formItem.setValue("repair_id", repair_id.Value);
                        formItem.setValue("notify_item", arrItem[0]);
                        formItem.setValue("component_no", arrItem[1]);
                        //新增欄位 componet_name arritem[i]修正延後index  2018/09/18
                        formItem.setValue("count", arrItem[3]);
                        formItem.setValue("junk_name", arrItem[5]);
                        formItem.setValue("junk_count", arrItem[6]);
                        int junk_count = int.Parse(string.IsNullOrEmpty(arrItem[6]) ? "0" : arrItem[6]);
                        formItem.setValue("junk_count", junk_count.ToString());
                        formItem.setValue("is_junk", junk_count > 0 ? "Y" : "N");
                        formItem.setValue("create_user", userID.getUserID());
                        model.insertRepairDtl(formItem);
                    }
                }

                dao.commit();

                budget_area.Value = crs_area.SelectedValue;
                repair_item.Value = TDOSf002U2.RepairItem;
                genReapirItem(repair_item.Value);

                SysMsg.AlertMessage(this.Page, "儲存成功！");//

                Response.Write("<script>alert('儲存成功！'); location.href='" + Forward.Redirect("TDOSf002Q1.aspx",
               "", this) + "'; </script>");
            }
        }
        catch (System.Data.SqlClient.SqlException exSQL)
        {
            dao.rollback();
            if (exSQL.Number.Equals(2601))
            {
                case_no_advise.Text = "建議：" + getCaseNo(work_no.Text, repair_type3.Value);
                SysMsg.AlertMessage(this.Page, "新增失敗！已有相同的標案編號已儲存，請重新儲存！");
            }
        }
        catch (System.IndexOutOfRangeException exIndex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "儲存失敗！\\\n託修內容錯誤，請刪除顯示不完整的列資料重新新增一列！");
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "儲存失敗！\\\n" + ex.Message);
        }

        finally
        {
            dao.close();
        }
    }

    private void genReapirItem(String sRepairItem)
    {
        if (crs_area.SelectedValue != budget_area.Value)
            area_memo.Text = "修改單價區域後必須點選儲存按鈕才會生效！";
        else
            area_memo.Text = "";

        if (sRepairItem.Length > 0)
            TDOSf002U2.RepairItem = sRepairItem;

        TDOSf002U2.refresh();
    }

    /// <summary>
    /// 刪除按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {

            dao.open();
            RepairModel model = new RepairModel();
            model.dao = dao;
            model.deleteRepairMst(repair_id.Value);
            model.deleteRepairDtl(repair_id.Value);
            dao.commit();

            Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSf002Q1.aspx", "", this) + "'; </script>");
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "刪除失敗！\\\n" + ex.Message + "\n" + ex.StackTrace);
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

    protected void btnWork_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        try
        {
            dao.open();
            NotifyModel model = new NotifyModel();
            model.dao = dao;
            Form form = new Form();
            Mediator med = Mediator.getInstance(true);

            DataSet ds = model.selectNotifyByWorkNo(work_no.Text, userID.getUserID());
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                try
                {
                    repair_vender.SelectedValue = med.lookupParamId("REPAIR_VENDER", dr["repair_vender"].ToString());
                }
                catch
                {
                    repair_vender.SelectedValue = "";
                }

                if (dr["year_rp3"].ToString().Equals("OUT"))
                    year.Text = dr["year_cn"].ToString().Substring(1, 3);
                else
                    year.Text = dr["year_cn"].ToString().Substring(0, 3);

                notify_date.Text = dr["notify_date"].ToString();
                car_id.Value = dr["car_id"].ToString();
                crs_org.Value = dr["crs_org"].ToString();
                repair_type3.Value = dr["repair_type3"].ToString();

                if ((repair_vender.SelectedValue != string.Empty || repair_type3.Value.Equals("OUT")) && year.Text != string.Empty)
                    case_no.Text = getCaseNo(dr["work_no"].ToString(), repair_type3.Value);

                car_data.setDrNotify(dr);
                car_data.getNotifyData();
                TDOSf002U2.WorkNo = dr["work_no"].ToString();

            }
            else
            {
                SysMsg.AlertMessage(this.Page, "查無符合的派工單號，請重新輸入！");
                work_no.Focus();
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


    protected void btnPrint1_Click(object sender, EventArgs e)
    {
        print("TDOSf002P1.ashx");
    }

    protected void btnPrint2_Click(object sender, EventArgs e)
    {
        print("TDOSf002P2.ashx");
    }

    protected void btnPrint3_Click(object sender, EventArgs e)
    {
        print("TDOSf002P3.ashx");
    }

    private void print(String sURL)
    {
        Response.Redirect(sURL + "?repair_id=" + repair_id.Value + "&crs_area=" + crs_area.SelectedValue);

    }

    private Boolean validGetCaseNo()
    {
        Boolean flag = true;

        if (flag && year.Text.Length == 0)
        {
            case_no.Text = "";
            SysMsg.AlertMessage(this.Page, "請輸入年度！");
            year.Focus();
            flag = false;
        }


        if (flag && (repair_vender.SelectedValue == "" && !repair_type3.Value.Equals("OUT")))
        {
            case_no.Text = "";
            SysMsg.AlertMessage(this.Page, "請選擇維修廠商！");
            year.Focus();
            flag = false;
        }

        int iYear = 0;
        if (flag && !int.TryParse(year.Text, out iYear))
        {
            case_no.Text = "";
            SysMsg.AlertMessage(this.Page, "年度不正確無法編列標案編號！");
            year.Focus();
            flag = false;
        }

        if (flag)
            year.Text = HandleParam.addZero(year.Text, 3);

        return flag;
    }

    private string getCaseNo(String work_no, String repair_type_3)
    {
        string sRetValue = "";
        case_no_advise.Text = "";

        //無變更
        if (repair_type_3.Equals("OUT"))
        {
            if (year.Text.Equals(region_year.Value))
            {
                return region_caseno.Value;
            }
        }
        else
        {
            if (repair_vender.SelectedValue.Equals(region_vender.Value) && year.Text.Equals(region_year.Value))
            {
                return region_caseno.Value;
            }
        }


        if (!validGetCaseNo())
            return "";

        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        TDOS tdos = new TDOS();

        try
        {
            dao.open();
            RepairModel model = new RepairModel();
            model.dao = dao;

            if (repair_type_3.Equals("OUT"))
            {
                sRetValue = model.getEndCaseNo(work_no, year.Text);
            }
            else
            {
                if (car_id.Value != string.Empty && repair_vender.SelectedValue != "" && year.Text != string.Empty)
                {
                    sRetValue = model.getCaseNo(work_no, repair_vender.SelectedValue, year.Text);
                    String[] arrRetValue = sRetValue.Split('-');
                    sRetValue = arrRetValue[0] + arrRetValue[1] + "-" + arrRetValue[2] + "號";
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

        return sRetValue;
    }

    protected void repair_vender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (car_id.Value != string.Empty && repair_vender.SelectedValue != "")
            case_no.Text = getCaseNo(work_no.Text, repair_type3.Value);
        #region 2018/08/29 依廠商取得單價區域
        if (repair_vender.SelectedValue != "")
        {
            case_no.Text = getCaseNo(work_no.Text, repair_type3.Value);

            if (repair_vender.SelectedItem.Text.Contains("第1區"))
            {
                crs_area.SelectedValue = "1";

            }
            else if (repair_vender.SelectedItem.Text.Contains("第2區"))
            {
                crs_area.SelectedValue = "2";

            }
            else if (repair_vender.SelectedItem.Text.Contains("第3區"))
            {
                crs_area.SelectedValue = "3";

            }
            else if (repair_vender.SelectedItem.Text.Contains("第4區"))
            {
                crs_area.SelectedValue = "4";

            }
            else { crs_area.SelectedValue = "2"; }
            // Response.Write(crs_area.SelectedValue);
        }
        #endregion
    }


    protected void year_TextChanged(object sender, EventArgs e)
    {
        if (car_id.Value != string.Empty)
            case_no.Text = getCaseNo(work_no.Text, repair_type3.Value);
    }


    private Boolean CheckAll()
    {
        Boolean flag = true;

        //檢核標案編號 ex:I105零託字第0007號
        if (repair_type3.Value.Equals("OUT"))
        {
            if (flag && case_no.Text.Length != 13)
            {
                SysMsg.AlertMessage(this.Page, "標案編號長度不正確，須為13碼！");
                flag = false;
            }

            int iYear = 0;
            if (flag && !int.TryParse(case_no.Text.Substring(1, 3), out iYear))
            {
                SysMsg.AlertMessage(this.Page, "標案編號第2~4碼須為年度！");
                flag = false;
            }

            int iNum = 0;
            if (flag && !int.TryParse(case_no.Text.Substring(8, 4), out iNum))
            {
                SysMsg.AlertMessage(this.Page, "標案編號第9~12碼(" + case_no.Text.Substring(8, 4) + ")須為數值！");
                flag = false;
            }

            if (flag && iNum == 0)
            {
                SysMsg.AlertMessage(this.Page, "標案編號第9~12碼不可為0000！");
                flag = false;
            }

        }
        //檢核標案編號 ex:104環勞字第092-00008號
        else
        {
            int iLength = (10 + repair_vender.SelectedValue.Length);

            if (case_no.Text.Contains("環勞字第"))
                iLength = (14 + repair_vender.SelectedValue.Length);

            if (flag && case_no.Text.Length != iLength)
            {
                SysMsg.AlertMessage(this.Page, "標案編號長度不正確，須為" + iLength + "碼！");
                flag = false;
            }

            int iYear = 0;
            if (flag && !int.TryParse(case_no.Text.Substring(0, 3), out iYear))
            {
                SysMsg.AlertMessage(this.Page, "標案編號第1~3碼須為年度！");
                flag = false;
            }

            int iNum = 0;
            iLength = iLength - 6;
            if (flag && !int.TryParse(case_no.Text.Substring(iLength, 5), out iNum))
            {
                SysMsg.AlertMessage(this.Page, "標案編號第" + (iLength + 1) + "~" + (iLength + 6) + "碼(" + case_no.Text.Substring(iLength, 5) + ")須為數值！");
                flag = false;
            }

            if (flag && iNum == 0)
            {
                SysMsg.AlertMessage(this.Page, "標案編號第" + (iLength + 1) + "~" + (iLength + 6) + "碼不可為00000！");
                flag = false;
            }
        }

        if (flag && !validCasNoUnique())
        {
            SysMsg.AlertMessage(this.Page, "標案編號重複請依建議值輸入。");
            flag = false;
        }


        return flag;
    }


    private Boolean validCasNoUnique()
    {
        Boolean flag = true;
        case_no_advise.Text = "";
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();
            RepairModel model = new RepairModel();
            model.dao = dao;
            int count = model.GetCaseNoCount(case_no.Text);
            if (count > 0)
            {
                if (case_no.Text != region_caseno.Value)
                {
                    flag = false;
                    case_no_advise.Text = "建議：" + getCaseNo(work_no.Text, repair_type3.Value);
                }
            }
        }
        catch (Exception ex)
        {
            flag = false;
            dao.rollback();
        }
        finally
        {
            dao.close();
        }

        return flag;
    }


    /// <summary>
    /// 異動預算單價區域
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void crs_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();

        try
        {
            ComponentModel model = new ComponentModel();

            model.dao = dao;
            dao.open();

            TDOSf002U2.CRSArea = crs_area.SelectedValue;

            string[] arrRepair = TDOSf002U2.RepairItem.Substring(0, TDOSf002U2.RepairItem.Length).Split(';');
            String sMultiComponent = "";
            String sNewRepairItem = "";

            for (int i = 0; i < arrRepair.Length; i++)
            {
                string[] arrItem = arrRepair[i].Split('|');

                sMultiComponent += arrItem[1] + Mediator.splitTag;
            }

            //查詢單價
            DataSet dsDtl = model.selectComponent(crs_area.SelectedValue, sMultiComponent);



            for (int k = 0; k < arrRepair.Length; k++)
            {
                string[] arrItem = arrRepair[k].Split('|');

                for (int i = 0; i < dsDtl.Tables[0].Rows.Count; i++)
                {
                    DataRow drDtl = dsDtl.Tables[0].Rows[i];

                    if (arrItem[1].Equals(drDtl["component_no"].ToString()))
                    {
                        arrItem[4] = drDtl["budget" + crs_area.SelectedValue].ToString();
                    }
                }

                //組回字串
                String sItem = "";

                for (int j = 0; j < arrItem.Length; j++)
                {
                    sItem += arrItem[j] + "|";
                }

                arrRepair[k] = sItem.Substring(0, sItem.Length - 1) + ";";

                sNewRepairItem += arrRepair[k];
            }

            if (sNewRepairItem.Length > 0)
                genReapirItem(sNewRepairItem.Substring(0, sNewRepairItem.Length - 1));

            //if (sNewRepairItem.Length > 0)
            //    TDOSf002U2.RepairItem = sNewRepairItem.Substring(0, sNewRepairItem.Length - 1);

            //TDOSf002U2.refresh();

            //if (drDtl["repair_item"].ToString().Length > 0)
            //    TDOSf002U2.RepairItem = drDtl["repair_item"].ToString().Substring(0, drDtl["repair_item"].ToString().Length - 1);

            //TDOSf002U2.refresh();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            dao.close();
        }
    }
    protected void check_result1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (check_result1.Checked)
        {
            check_result2.Checked = false;
            check_result_value = "PASS";
        }


        // Response.Write(check_result.SelectedItem.Value);

    }
    protected void check_result2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (check_result2.Checked)
        {
            check_result1.Checked = false;
            check_result_value = "FAIL";
        }
    }



    protected void is_late1_CheckedChanged(object sender, EventArgs e)
    {
        if (is_late1.Checked)
        {
            is_late2.Checked = false;
            is_late_value = "Y";
        }
    }

    protected void is_late2_CheckedChanged(object sender, EventArgs e)
    {
        if (is_late2.Checked)
        {
            is_late1.Checked = false;
            is_late_value = "N";
        }
    }

    protected void time_unit1_CheckedChanged(object sender, EventArgs e)
    {
        time_unit2.Checked = false;
        time_unit_value = "WORKDAY";
    }

    protected void time_unit2_CheckedChanged(object sender, EventArgs e)
    {
        time_unit1.Checked = false;
        time_unit_value = "HOUR";
    }
}
