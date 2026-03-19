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
/// 委外託修作業：新增頁
/// </summary>
public partial class TDTSf002_TDTSf002I1 : System.Web.UI.Page
{
    string check_result_value = "";
    string is_late_value = "";
    string time_unit_value = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();

        try
        {
            dao.open();

            if (!IsPostBack)
            {
                //button權限
                //btnSave.Visible = userID.hasFunc("TDOSf001_insert");

                HtmlTag hTag = new HtmlTag();
                mng_id_SelectedIndexChanged(sender, e);
                //2018/09/01RadioButtonList改成checkBox
                //hTag.createMediatorRadio("YES_NO", is_late, "", 0);//2018/09/01RadioButtonList改成checkBox 

                //2018/09/01RadioButtonList改成checkBox


                //2018/08/31檢驗結果改checkbox
                //hTag.createMediatorRadio("CHECK_RSLT", check_result, "", 0);
                //2018/08/31檢驗結果改checkbox
                hTag.createMediatorSelect("REPAIR_VENDER", repair_vender, "", "請選擇", 0);
                //2018/08/31rRadio改checkbox
                //hTag.createMediatorRadio("TIME_UNIT", time_unit, "WORKDAY", 0);

                //2018/08/31rRadio改checkbox
                //year.Attributes.Add("onkeyup", "this.value=this.value.replace(/[^0-9]/g,'')");

                // TDOSf002U2.RepairItem = "|||||";
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

    ICollection CreateDataSource()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add(new DataColumn("ValueField", typeof(String)));
        dt.Columns.Add(new DataColumn("TextField", typeof(String)));

        DateTime date = DateTime.Now.AddDays(-1);
        String sNum = DateTransfer.transferFormate(date.ToString("yyyy/MM/dd"), "", DateTransfer.YYY_MM_DD);

        dt.Rows.Add("0", "請選擇");
        dt.Rows.Add("1", sNum + "001");
        dt.Rows.Add("2", sNum + "002");

        DataView dv = new DataView(dt);
        return dv;

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
                form.setValue("car_id", car_id.Value);
                form.setValue("crs_org", crs_org.Value);
                form.setValue("case_no", case_no.Text.Trim());
                form.setValue("work_no", work_no.Text.Trim());
                form.setValue("repair_vender", repair_vender.SelectedItem.Text.Trim());
                form.setValue("notify_date", formatDateTimeForm(notify_date.Text, notify_HH.Text, notify_mm.Text.Trim()));
                form.setValue("exec_deadline", formatDateTimeForm(exec_deadline.Text, exec_HH.Text, exec_mm.Text.Trim()));
                form.setValue("finish_date", formatDateTimeForm(finish_date.Text, finish_HH.Text, finish_mm.Text.Trim()));
                form.setValue("check_date", formatDateTimeForm(check_date.Text, check_HH.Text, check_mm.Text.Trim()));
                form.setValue("qualified_date", formatDateTimeForm(qualified_date.Text, qualified_HH.Text, qualified_mm.Text.Trim()));
                form.setValue("delivery_days", delivery_days.Text.Trim());
                //2018/09/01RadioButtonList改成checkBox
                //form.setValue("delivery_unit", time_unit.SelectedValue);

                if (time_unit1.Checked)
                {
                    time_unit_value = "WORKDAY";
                }
                else if (time_unit2.Checked)
                {
                    time_unit_value = "HOUR";
                }
                else { time_unit_value = "WORKDAY"; }
                form.setValue("delivery_unit", time_unit_value); //form.getValue("delivery_unit")
             
                //單價區域
                form.setValue("crs_area", crs_area.SelectedValue);
                //SysMsg.AlertMessage(this.Page, form.getValue("crs_area"));
                //Response.Write(is_late_value);

                //2018/09/01RadioButtonList改成checkBox


                //2018/09/01RadioButtonList改成checkBox
                //form.setValue("is_late", is_late.SelectedValue);//2018/09/01RadioButtonList改成checkBox
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
                //Response.Write(is_late_value);

                //2018/09/01RadioButtonList改成checkBox
                // form.setValue("check_result", check_result.SelectedValue); 2018/08/31測試查驗結果Checkbox befor
                //2018/08/31測試查驗結果Checkbox
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
               // Response.Write(check_result_value);
                
                form.setValue("memo", memo.Text.Trim());
                form.setValue("create_user", userID.getUserID());
              //2018/08/31測試查驗結果Checkbox
                RepairModel model = new RepairModel();
                model.dao = dao;
                Decimal repair_id = model.insertRepairMst(form);

                if (TDOSf002U2.RepairItem != string.Empty)
                {

                    string[] arrRepair = TDOSf002U2.RepairItem.Split(';');


                    for (int i = 0; i < arrRepair.Length; i++)
                    {
                        string[] arrItem = arrRepair[i].Split('|');

                        Form formItem = new Form(); formItem.setValue("repair_id", repair_id.ToString());
                        formItem.setValue("notify_item", arrItem[0]);
                        formItem.setValue("component_no", arrItem[1]);
                        formItem.setValue("count", arrItem[3]);
                        formItem.setValue("junk_name", arrItem[5]);
                        int junk_count = int.Parse(string.IsNullOrEmpty(arrItem[6]) ? "0" : arrItem[6]);
                        formItem.setValue("junk_count", junk_count.ToString());
                        formItem.setValue("is_junk", junk_count > 0 ? "Y" : "N");
                       
                        model.insertRepairDtl(formItem);
                    }
                }

                dao.commit();

                //Response.Write("<script>alert('新增成功！');  </script>");
                Response.Write("<script>alert('新增成功！'); location.href='" + Forward.Redirect("TDOSf002Q1.aspx",
                "", this) + "'; </script>");
            }
        }
        catch (System.Data.SqlClient.SqlException exSQL)
        {
            if (exSQL.Number.Equals(2601))
            {
                case_no_advise.Text = "建議：" + getCaseNo(work_no.Text, repair_type3.Value);
                SysMsg.AlertMessage(this.Page, "新增失敗！已有相同的標案編號已儲存，請重新儲存！");
                //Response.Write("<script>alert('新增失敗！已有相同的標案編號已儲存，請重新儲存！');</script>");
            }
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }


    }

    private String formatDateTimeForm(String strDate, String strHH, String strMM)
    {
        String retValue = "";
        strDate = strDate.Trim();
        strHH = strHH.Trim();
        strMM = strMM.Trim();

        if (strDate != string.Empty && strHH != string.Empty && strMM != string.Empty)
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(strDate.Trim()) + " " +
              HandleParam.addZero(strHH.Trim(), 2) + ":" + HandleParam.addZero(strMM.Trim(), 2) + ":00");
            retValue = dt.ToString("yyyy/MM/dd HH:mm:ss");
        }
        else if (strDate != string.Empty && (strHH == string.Empty || strMM == string.Empty))
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(strDate.Trim()) + " 00:00:00");
            retValue = dt.ToString("yyyy/MM/dd HH:mm:ss");
        }

        return retValue;
    }

    /// <summary>
    /// 依車牌號碼取出車輛資料
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCar_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        ClearCarControl();
        try
        {
            dao.open();
            Form form = new Form();
            form.setValue("user_read", userID.getUserRead());
            form.setValue("user_org", userID.getUserOrg());
            CarModel model = new CarModel();
            model.dao = dao;
            DataSet ds = model.selectCarDatabyCarNo(form);

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
    /// 清除車輛資料
    /// </summary>
    private void ClearCarControl()
    {



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
                flag = false;
                case_no_advise.Text = "建議：" + getCaseNo(work_no.Text, repair_type3.Value);
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
    /// 管理單位連動車牌號碼下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            CarModel model = new CarModel();
            model.dao = dao;
            Form form = new Form();

            ArrayList al_car = model.selectCarId(form);
            ClearCarControl();
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

    protected void btnWork_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        TDOS tdos = new TDOS();
        Mediator med = Mediator.getInstance(true);
        try
        {
            dao.open();
            NotifyModel model = new NotifyModel();
            model.dao = dao;
            Form form = new Form();

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

                if (dr["year_cn"].ToString() != string.Empty)
                {
                    if (dr["year_rp3"].ToString().Equals("OUT"))
                        year.Text = dr["year_cn"].ToString().Substring(1, 3);
                    else
                        year.Text = dr["year_cn"].ToString().Substring(0, 3);
                }

                //notify_date.Text = dr["notify_date"].ToString();

                if (dr["notify_type"].ToString().Equals("C"))
                {
                    car_id.Value = dr["car_id"].ToString();

                }


                //Session["DEPORG"] = dr["dep_no"].ToString();//加註已報修過_wenny_1061207
                crs_org.Value = dr["crs_org"].ToString();
                repair_type3.Value = dr["repair_type3"].ToString();

                if ((repair_vender.SelectedValue != string.Empty || repair_type3.Value.Equals("OUT")) && year.Text != string.Empty)
                    case_no.Text = getCaseNo(dr["work_no"].ToString(), repair_type3.Value);


                TDOSf002U2.WorkNo = dr["work_no"].ToString();
                TDOSf002U2.CRSArea = tdos.getCRSArea(dr["crs_org"].ToString()).ToString();

                dr["car_status"] = med.lookupParamName("USE_STS", dr["status"].ToString(), 0);

                dr["keep_org"] = med.lookupParamName("DEP_ORG", dr["keep_org"].ToString(), 0);
                dr["car_type"] = med.lookupParamName("CAR_TYPE", dr["car_type"].ToString(), 0);

                car_data.setDrNotify(dr);
                car_data.getNotifyData();

                //TDOSf002U2.RepairItem = "|||||";
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

        if (validGetCaseNo())
        {

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
                    //if (car_id.Value != string.Empty && repair_vender.SelectedValue != "")
                    if (repair_vender.SelectedValue != "")
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

        }
        return sRetValue;
    }

    #region  2018/08/29 依廠商選單價區
    protected void repair_vender_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Response.Write(repair_vender.SelectedItem.Text);
        //if (car_id.Value != string.Empty && repair_vender.SelectedValue != "")
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
    }
    #endregion

    protected void year_TextChanged(object sender, EventArgs e)
    {
        if (car_id.Value != string.Empty)
            case_no.Text = getCaseNo(work_no.Text, repair_type3.Value);
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
                        //arrItem[3] = drDtl["budget" + crs_area.SelectedValue].ToString();//20181113新增零件名稱欄位原始code
                        arrItem[4] = drDtl["budget" + crs_area.SelectedValue].ToString();//20181113新增零件名稱欄位所以索引值往後推一位
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
            TDOSf002U2.refresh();
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
            
        }
    }

    protected void is_late2_CheckedChanged(object sender, EventArgs e)
    {
        if (is_late2.Checked)
        {
            is_late1.Checked = false;

        }
    }

    protected void time_unit1_CheckedChanged(object sender, EventArgs e)
    {
        if (time_unit1.Checked)
        {
            time_unit2.Checked = false;

        }
    }

    protected void time_unit2_CheckedChanged(object sender, EventArgs e)
    {
        if (time_unit2.Checked)
        {
            time_unit1.Checked = false;

        }
    }
}