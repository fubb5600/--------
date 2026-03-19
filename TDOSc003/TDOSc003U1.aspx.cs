using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 勤務記錄：修改頁
/// </summary>
public partial class TDOSc003_TDOSc003U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        if (car_type2.Text.Trim() == "A5:專用車")
        {

            DSPH_CAUSE.Enabled = true;
            ATU_USER.Enabled = true;
            PASSENGERS.Enabled = true;
            MILS.Enabled = true;
            ADM_DISTRICT.Enabled = true;
        }
        else
        {

            DSPH_CAUSE.Enabled = false;
            ATU_USER.Enabled = false;
            PASSENGERS.Enabled = false;
            MILS.Enabled = false;
            ADM_DISTRICT.Enabled = false;
        }
        try
        {
            if (!IsPostBack)
            {
                if (car_type2.Text.Trim() == "A5:專用車")
                {

                    DSPH_CAUSE.Enabled = true;
                    ATU_USER.Enabled = true;
                    PASSENGERS.Enabled = true;
                    MILS.Enabled = true;
                    ADM_DISTRICT.Enabled = true;
                }
                else
                {

                    DSPH_CAUSE.Enabled = false;
                    ATU_USER.Enabled = false;
                    PASSENGERS.Enabled = false;
                    MILS.Enabled = false;
                    ADM_DISTRICT.Enabled = false;
                }
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSc003_update");
                btnDelete.Visible = userID.hasFunc("TDOSc003_delete");
               

                //work_start.Attributes["onpropertychange"] = "changeWorkDate(this); setDefulatFocus(this);";
                work_start.Attributes["onpropertychange"] = "changeWorkDate(this.value);if(this.value.length==9&&document.getElementById('" +
                      "MasterPage_ContentPlaceHolder1_start_HH').value.length==0)document.getElementById('" +
                      "MasterPage_ContentPlaceHolder1_start_HH').focus();if(this.value.length==9&&document.getElementById('" +
                      "MasterPage_ContentPlaceHolder1_work_date').value.length==0)document.getElementById('" +
                      "MasterPage_ContentPlaceHolder1_work_date').value =this.value ;if(this.value.length==9&&document.getElementById('" +
                      "MasterPage_ContentPlaceHolder1_work_end').value.length==0)document.getElementById('" +
                      "MasterPage_ContentPlaceHolder1_work_end').value =this.value ;";

                start_HH.Attributes["onkeyup"] = "if(this.value.length==2)document.getElementById('MasterPage_ContentPlaceHolder1_start_mm').focus();";
                start_mm.Attributes["onkeyup"] = "if(this.value.length==2) if(document.getElementById('MasterPage_ContentPlaceHolder1_work_end').value.length == 0) " +
                    "document.getElementById('MasterPage_ContentPlaceHolder1_work_end').focus();else if(document.getElementById('MasterPage_ContentPlaceHolder1_end_HH').value.length == 0) " +
                    "document.getElementById('MasterPage_ContentPlaceHolder1_end_HH').focus();";
                work_end.Attributes["onpropertychange"] = "changeWorkDate(this.value);if(this.value.length==9){if(document.getElementById('MasterPage_ContentPlaceHolder1_start_HH').value.length == 0)" +
                    "document.getElementById('MasterPage_ContentPlaceHolder1_start_HH').focus(); else if(document.getElementById('MasterPage_ContentPlaceHolder1_end_HH').value.length == 0) document.getElementById('MasterPage_ContentPlaceHolder1_end_HH').focus();";
                end_HH.Attributes["onkeyup"] = "if(this.value.length==2)document.getElementById('MasterPage_ContentPlaceHolder1_end_mm').focus();";
                end_mm.Attributes["onkeyup"] = "if(this.value.length==2)end_mmTabNext();";
                //selected_item.Attributes["onfocus"] = "openWorkItem()";
                work_date.Attributes["onpropertychange"] = "Message()";

                //start_HH.Attributes["onkeyup"] = "setDefulatFocus(this);";
                //start_mm.Attributes["onkeyup"] = "setDefulatFocus(this);";
                //work_end.Attributes["onpropertychange"] = "changeWorkDate(this.value); setDefulatFocus(this);";
                //end_HH.Attributes["onkeyup"] = "setDefulatFocus(this);";
                //end_mm.Attributes["onkeyup"] = "setDefulatFocus(this);";
                //selected_item.Attributes["onfocus"] = "openWorkItem()";

                Form form = new Form();
                form.setValue("work_id", Request["work_id"]);
                form.setValue("user_read", userID.getUserRead());
                form.setValue("user_org", userID.getUserOrg());
               
                form.setValue("yesno", Request["yesno"]);
                form.setValue("location", Request["location"]);

                WorkModel model = new WorkModel();
                model.dao = dao;
                dao.open();
                HtmlTag hTag = new HtmlTag();
                DataSet ds = model.selectWork(form.getValue("work_id"));
                DataRow dr = ds.Tables[0].Rows[0];

                
                ADM_DISTRICT.Text = dr["ADM_DISTRICT"].ToString();
                DSPH_CAUSE.Text = dr["DSPH_CAUSE"].ToString();
                PASSENGERS.Text = dr["PASSENGERS"].ToString();

                MILS.Text = dr["MILS"].ToString();
                ATU_USER.Text = dr["ATU_USER"].ToString();
                work_id.Value = dr["work_id"].ToString();
                work_date.Text = dr["work_date"].ToString();
                work_start.Text = dr["work_start"].ToString().Substring(0, 9);
                start_HH.Text = dr["work_start"].ToString().Substring(10, 2);
                start_mm.Text = dr["work_start"].ToString().Substring(13, 2);
                work_end.Text = dr["work_end"].ToString().Substring(0, 9);
                end_HH.Text = dr["work_end"].ToString().Substring(10, 2);
                end_mm.Text = dr["work_end"].ToString().Substring(13, 2);
                mileage_start.Text = dr["mileage_start"].ToString();
                mileage_end.Text = dr["mileage_end"].ToString();
                mileage.Text = dr["mileage"].ToString();
                car_count.Text = dr["car_count"].ToString();
                car_type2.Text = dr["car"].ToString();
                if (dr["yesno"].ToString()!="")
                {

                    yesno.SelectedValue = dr["yesno"].ToString();

                }

                if (dr["location"].ToString()=="無"|| dr["location"].ToString() == "否")
                {
                    location.SelectedValue = "";


                }
                 else
                {
                    location.SelectedValue = dr["location"].ToString();


                }







                if (dr["mileage_rsn"].ToString() != string.Empty)
                {
                    pnlMileageRsn.Visible = true;
                    mileage_rsn.Text = dr["mileage_rsn"].ToString();
                }

                if (dr["mileage_key"].ToString() != string.Empty)
                {
                    cbKeyMileage.Checked = true;
                    mileage_key.Text = dr["mileage_key"].ToString();
                }
                memo.Text = dr["memo"].ToString();
                work_man.Text = dr["work_man"].ToString();
                work_area.Text = dr["work_area"].ToString();
                work_location.Text = dr["work_location"].ToString();

                hTag.createMediatorRadio("WORK_TYPE", work_type, dr["work_type"].ToString(), 0);
                hTag.createMediatorSelect("MACHINE", work_machine, dr["work_machine"].ToString(), "請選擇", 0);
                hTag.createMediatorSelect("CARD_TYPE", card_type, "", "請選擇", 0);
                work_item.Value = dr["work_item"].ToString();
                work_item_text.Value = model.getWorkItemText(dr["work_type"].ToString(), dr["work_item"].ToString());

                //if (dr["work_type"].ToString() == "C")
                //{
                //    car_witem.Value = dr["work_item"].ToString();
                //    selected_item.Text = med.lookupParamNameMulti("CAR_WITEM", dr["work_item"].ToString(), 0);
                //}
                //else
                //{
                //    mchn_witem.Value = dr["work_item"].ToString();
                //    selected_item.Text = med.lookupParamNameMulti("MCHN_WITEM", dr["work_item"].ToString(), 0);
                //}
                
                #region 管理單位下拉選單
                if (userID.getUserRead() == "ALL")
                {
                    hTag.createMediatorSelect("DEP_ORG", mng_id, userID.getUserID(), "請選擇", 0);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Value = userID.getUserOrg();
                    li.Text = med.lookupParamName("DEP_ORG", userID.getUserOrg(), 0);
                    mng_id.Items.Add(li);
                }               
                #endregion

                work_type_SelectedIndexChanged(sender, e);
                //getOilCardData(dr["card_id"].ToString());
                genCardIdSelect(dr["card_id"].ToString());

               // getFuelData();
                mng_id.SelectedValue = dr["work_org"].ToString();               
                //SumThisMonthCarWork(dr["work_date"].ToString());
                card_id_SelectedIndexChanged(sender, e);
                cbKeyMileage_CheckedChanged(sender, e);

            }

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "load", "tableCreate();", true);
            
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
        Response.Redirect(Forward.Redirect("TDOSc003Q1.aspx", "", this));
    }


    /// <summary>
    /// 儲存前的檢核
    /// </summary>
    /// <returns></returns>
    private Boolean CheckAll()
    {
        Boolean flag = true;

        DateTime start_dt = new DateTime();
        DateTime end_dt = new DateTime();
        WorkModel model = new WorkModel();
        DBDAO dao = new DBDAO();
        TDOS tdos = new TDOS();
        UserID userID = (UserID)Session["UserID"];

        #region 必填項目檢核

        if (flag && work_date.Text.Equals(""))
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請輸入報表日期！");
        }

        if (flag && work_man.Text.Equals(""))
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請輸入作業人員！");
        }

        if (flag && work_location.Text.Equals(""))
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請輸入作業地點！");
        }

        if (flag && work_item.Value.Equals(""))
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請輸入作業項目！");
        }

        if (flag && card_id.SelectedIndex == 0)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, "請選擇加油卡！");
        }

        //檢核是否輸入里程數
        if (work_type.SelectedValue == "C")
        {
            if (flag && mileage_start.Text == string.Empty)
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "請輸入里程數(起)！");
            }

            if (flag && mileage_end.Text == string.Empty)
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "請輸入里程數(迄)！");
            }
        }

        //檢核是否輸入里程數自行修正原因
        if (flag && cbKeyMileage.Checked)
        {
            if (mileage_key.Text == string.Empty)
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "請輸入里程數自行修正原因！");
            }
        }

        if (flag && work_type.SelectedValue == "C")
        {
            //檢核是否輸入里程數不連續原因
            if (mileage_start.Text != hfLastMileage.Value)
            {
                if (mileage_rsn.Text == string.Empty)
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "請輸入里程數不連續原因！");
                }
            }
        }

        //檢核是否選擇機具
        if (flag && work_type.SelectedValue == "M")
        {
            if (work_machine.SelectedValue == string.Empty)
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "請選擇機具！");
            }
        }

        //檢核勤務日期(起)
        if (flag)
        {
            try
            {
                start_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_start.Text) + " " +
                       HandleParam.addZero(start_HH.Text, 2) + ":" + HandleParam.addZero(start_mm.Text, 2) + ":00");
            }
            catch
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "勤務日期(起)不正確！");
            }
        }

        //檢核勤務日期(迄)
        if (flag)
        {
            try
            {
                end_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_end.Text) + " " +
                  HandleParam.addZero(end_HH.Text, 2) + ":" + HandleParam.addZero(end_mm.Text, 2) + ":00");
            }
            catch
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "勤務日期(迄)不正確！");
            }
        }

        #endregion

        //檢核勤務日期(迄)是否大於勤務日期(起)
        if (flag)
        {
            if (end_dt <= start_dt)
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "勤務日期(迄)需大於勤務日期(起)！");
            }
        }


        //檢核報表作業日期是否在勤務日期起迄範圍內
        if (flag)
        {
            DateTime start = Convert.ToDateTime(DateTransfer.c_date_trans(work_start.Text));
            DateTime end = Convert.ToDateTime(DateTransfer.c_date_trans(work_end.Text));
            DateTime work_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_date.Text));
            if (work_dt >= start && work_dt <= end)
            {
                flag = true;
            }
            else
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "報表作業日期不正確！");
            }
        }

        //檢核勤務日期是否已鎖定
        if (flag)
        {
            DateTime report_date = start_dt;

            do
            {
                flag = tdos.IsKeyDateLock(DateTransfer.c_date_intrans(report_date.ToString("yyyy/MM/dd")), userID.getUserID(), "TDOSc003");

                if (flag == false)
                {
                    SysMsg.AlertMessage(this.Page, "已鎖定的勤務日期(" + DateTransfer.c_date_intrans(report_date.ToString("yyyy/MM/dd")) +
                        ")不可新增資料，請聯繫管理者！");
                    break;
                }
                report_date = report_date.AddDays(1);
            } while (report_date <= end_dt);
        }

        //檢核勤務日期是否同一個月份
        //if (flag)
        //{
        //    if (start_dt.Year != end_dt.Year || start_dt.Month != end_dt.Month)
        //    {
        //        flag = false;
        //        SysMsg.AlertMessage(this.Page, "勤務日期(起)、勤務日期(迄)必須是同一月份，跨月請分開兩筆輸入！");
        //    }
        //}

        try
        {
            dao.open();
            model.dao = dao;
            //檢核勤務類型是車輛時，報表作業日期是否對應的car_id
            if (work_type.SelectedValue == "C" & card_type.SelectedValue == "1")
            {
                DataSet ds = model.GetCarByCard(card_id.SelectedValue, work_date.Text != string.Empty ? DateTransfer.c_date_trans(work_date.Text) : "");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "此加油卡號沒有正確對應到車輛，請確認車輛資料中是否有設定車隊卡！");
                }
            }

            //檢核是否重複輸入(勤務時間重疊及同車輛)
            if (flag && work_type.SelectedValue == "C" && car_id.Value != string.Empty)
            {
                Form form = new Form();
                form.setValue("work_start", start_dt.ToString("yyyy/MM/dd HH:mm:ss"));
                form.setValue("work_end", end_dt.ToString("yyyy/MM/dd HH:mm:ss"));
                form.setValue("car_id", car_id.Value);
                form.setValue("work_type", work_type.SelectedValue);
                form.setValue("work_id", work_id.Value);
                String msg = string.Empty;

                DataSet ds = model.IsExistWorkMst(form);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        msg += dr["work_start"].ToString() + "~" + dr["work_end"].ToString() + "、";
                    }
                }

                if (msg.Length > 1)
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "勤務日期不可重疊！\\\n已輸入勤務日期" + msg.Substring(0, msg.Length - 1) + "的勤務記錄。");
                }


            }
        }
        catch (Exception ex)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally
        {
            dao.close();
        }

        return flag;
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
        Mediator med = new Mediator();
        try
        {
            if (CheckAll())
            {
                dao.open();
                dao.beginTransaction();

                DateTime start_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_start.Text.Trim()) + " " +
                  HandleParam.addZero(start_HH.Text.Trim(), 2) + ":" + HandleParam.addZero(start_mm.Text.Trim(), 2) + ":00");
                DateTime end_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_end.Text.Trim()) + " " +
                   HandleParam.addZero(end_HH.Text.Trim(), 2) + ":" + HandleParam.addZero(end_mm.Text.Trim(), 2) + ":00");

                Form form = new Form();

                form.setValue("yesno", yesno.SelectedValue.Trim());

                form.setValue("location", location.Text.Trim());
                form.setValue("work_id", work_id.Value);
                form.setValue("card_id", card_id.SelectedValue);
                form.setValue("work_type", work_type.SelectedValue);
                form.setValue("work_item", work_item.Value);

                form.setValue("PASSENGERS", PASSENGERS.Text);
                form.setValue("MOD_DEPNAME", userID.getUserOrg1());
                form.setValue("MOD_USERNAME", userID.getUserID());
                form.setValue("OPStatus", "0");
                form.setValue("ADM_DISTRICT", ADM_DISTRICT.Text.Trim());
                form.setValue("DSPH_CAUSE", DSPH_CAUSE.Text.Trim());
                form.setValue("car_type1", car_type2.Text);

                form.setValue("MILS", MILS.Text);
                form.setValue("ATU_USER", ATU_USER.Text.Trim());


                if (work_type.SelectedValue == "M")
                {
                    form.setValue("work_machine", work_machine.SelectedValue);
                    //form.setValue("work_item", mchn_witem.Value);
                    form.setValue("car_count", "");
                    //selected_item.Text = med.lookupParamNameMulti("MCHN_WITEM", mchn_witem.Value, 0);
                }
                form.setValue("work_start", start_dt.ToString("yyyy/MM/dd HH:mm:ss"));
                form.setValue("work_end", end_dt.ToString("yyyy/MM/dd HH:mm:ss"));
                form.setValue("work_org", mng_id.SelectedValue);
                if (work_type.SelectedValue == "C")
                {
                    form.setValue("car_id", car_id.Value);
                    form.setValue("mileage_start", mileage_start.Text.Trim());
                    form.setValue("mileage_end", mileage_end.Text.Trim());
                    form.setValue("car_count", car_count.Text.Trim());
                    if (pnlMileageRsn.Visible == true)
                    {
                        form.setValue("mileage_rsn", mileage_rsn.Text.Trim());
                    }
                    form.setValue("mileage", mileage.Text.Trim());
                    if (cbKeyMileage.Checked == true)
                    {
                        form.setValue("mileage_key", mileage_key.Text.Trim());
                    }
                    else
                    {
                        form.setValue("mileage_key", "");
                    }
                    //form.setValue("work_item", car_witem.Value);
                    //selected_item.Text = med.lookupParamNameMulti("CAR_WITEM", car_witem.Value, 0);
                }
                form.setValue("work_man", work_man.Text.Trim());
                form.setValue("work_area", work_area.Text.Trim());
                form.setValue("work_location", work_location.Text.Trim());
                form.setValue("memo", memo.Text.Trim());
                form.setValue("update_user", userID.getUserID());
                WorkModel model = new WorkModel();
                model.dao = dao;
                model.updateWork(form);
                #region 勤務日期

                //start_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_start.Text) + " 00:00:00");
                //2012/10/12會議改成只算一天
                //end_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_end.Text) + " 00:00:00");
                //end_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_start.Text) + " 00:00:00");

                //先刪除此勤務所有日期資料再新增
                model.deleteWorkDate(work_id.Value);

                //while (start_dt <= end_dt)
                //{
                Form date_form = new Form();
                date_form.setValue("work_id", work_id.Value);
                date_form.setValue("card_id", card_id.SelectedValue);
                if (work_type.SelectedValue == "C")
                {
                    date_form.setValue("car_id", car_id.Value);
                }
                //date_form.setValue("work_date", start_dt.ToString("yyyy/MM/dd"));
                date_form.setValue("work_date", DateTransfer.c_date_trans(work_date.Text.Trim()));
                model.insertWorkDate(date_form);
                start_dt = start_dt.AddDays(1);
                //}
                #endregion
                dao.commit();

                SysMsg.AlertMessage(this.Page, "儲存成功！");
            }
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
            dao.beginTransaction();

            Form form = new Form();
            form.setValue("work_id", work_id.Value);

            WorkModel model = new WorkModel();
            model.dao = dao;

            if (car_type2.Text.Trim() == "A1:特種汽車" || car_type2.Text.Trim() == "A2:特業汽車"  &&  work_type.SelectedValue == "C")
            {
              
              model.deleteWork(form.getValue("work_id"),work_type.SelectedValue);
            }
            if (car_type2.Text.Trim() != "A1:特種汽車" || car_type2.Text.Trim() != "A2:特業汽車" ||  work_type.SelectedValue == "M")
            {

                model.deleteFuelUse(form.getValue("work_id"));
                model.deleteWorkDate(form.getValue("work_id"));
                model.deleteWork2(form.getValue("work_id"),work_type.SelectedValue);
            }



        

            dao.commit();
            Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSc003Q1.aspx", "", this) + "'; </script>");
         
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "刪除失敗！\\\n" + ex.Message);
        }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 勤務類型連動顯示表單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void work_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Mediator med = new Mediator();
        if (work_type.SelectedValue == "C")//機具
        {
            car_id_title.Text = "車牌號碼";
            pnlCar.Visible = true;
            pnlMachine.Visible = false;
            pnlMileage.Visible = true;
            card_type.Visible = false;
            //selected_item.Text = med.lookupParamNameMulti("CAR_WITEM", car_witem.Value, 0);
            pnlMSum.Visible = false;
            //car_witem.Visible = true;
            //mchn_witem.Visible = false;
            //card_type.SelectedValue = "1";
            Panel1.Visible = true;
        }
        else
        {
            car_id_title.Text = "加油卡";
            pnlCar.Visible = false;
            pnlMachine.Visible = true;
            pnlMileage.Visible = false;
            //selected_item.Text = med.lookupParamNameMulti("MCHN_WITEM", mchn_witem.Value, 0);
            pnlMSum.Visible = true;
            //car_witem.Visible = false;
            //mchn_witem.Visible = true;
            //card_type.SelectedValue = "2";
            Panel1.Visible = false;
        }

        hfWorkType.Value = work_type.SelectedValue;
        genWorkItemLevel1(sender, e);
        //card_type_SelectedIndexChanged(sender, e);
        //GenCardTypeSelect(work_type.SelectedValue);

    }


    /// <summary>
    /// 產生加油卡卡別下拉選單
    /// </summary>
    /// <param name="str_work_type"></param>
    public void GenCardTypeSelect(String str_work_type)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();

        try
        {
            dao.open();
            CardModel model = new CardModel();
            model.dao = dao;

            #region 管理單位下拉選單
            if (userID.getUserRead() == "ALL")
            {
                hTag.createMediatorSelect("DEP_ORG", mng_id, userID.getUserID(), "請選擇", 0);
            }
            else
            {
                ListItem li = new ListItem();
                li.Value = userID.getUserOrg();
                li.Text = med.lookupParamName("DEP_ORG", userID.getUserOrg(), 0);
                mng_id.Items.Add(li);
            }
            mng_id.SelectedValue = userID.getUserOrg();
            #endregion

            ArrayList al = model.selectCardTypeByWorkType(str_work_type);
            hTag.createSelect(al, card_type, "", "請選擇", 0);

            if (str_work_type == "C")
            {
                pnlCar.Visible = true;
                card_type.SelectedValue = "1";
            }
            else
            {
                pnlCar.Visible = false;
            }

            genCardIdSelect("");

        }
        catch
        { }
        finally
        { dao.close(); }
    }


    /// <summary>
    /// 產生加油卡卡號的下拉選單
    /// </summary>
    private void genCardIdSelect(String str_card_id)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            CardModel model = new CardModel();
            model.dao = dao;
            Form form = new Form();
            form.setValue("user_read", userID.getUserRead());
            form.setValue("user_org", userID.getUserOrg());
            form.setValue("keep_org", mng_id.SelectedValue);
            form.setValue("card_type", card_type.SelectedValue);
            form.setValue("action", "edit");
            form.setValue("work_type", work_type.SelectedValue);

            DateTime query_date = DateTime.Now;

            if (work_date.Text.Trim() != string.Empty)
            {
                query_date = Convert.ToDateTime(DateTransfer.c_date_trans(work_date.Text.Trim()));
            }

            form.setValue("query_date", query_date.ToString("yyyy/MM/dd"));

            //ArrayList al_card = model.selectCardNo(form);
            ArrayList al_card = model.selectCardNoByWorkType(form);
            hTag.createSelect(al_card, card_id, str_card_id, "請選擇", 0);
            card_id.SelectedValue = str_card_id;
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
    /// 更新統計資訊的imageButton事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibUpdate_Click(object sender, ImageClickEventArgs e)
    {
        getFuelData();

        if (work_type.SelectedValue == "C")
        {
            getOilCardData(card_id.SelectedValue);
            CheckMileage();
            SumThisMonthCarWork(work_date.Text);
        }

    }


    /// <summary>
    /// 檢核里程數是否連續
    /// </summary>
    private void CheckMileage()
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            string lastMileage = string.Empty;
            if (card_id.SelectedValue != string.Empty && mileage_start.Text != string.Empty &&
                work_start.Text != string.Empty && start_HH.Text != string.Empty && start_mm.Text != string.Empty)
            {
                WorkModel model = new WorkModel();
                model.dao = dao;
                Form form = new Form();
                form.setValue("card_id", card_id.SelectedValue);
                form.setValue("work_start", DateTransfer.c_date_trans(work_start.Text) + " " +
                   HandleParam.addZero(start_HH.Text, 2) + ":" + HandleParam.addZero(start_mm.Text, 2) + ":00");
                hfLastMileage.Value = model.checkMileage(form);
                if (mileage_start.Text != hfLastMileage.Value)
                {
                    pnlMileageRsn.Visible = true;
                }
                else
                {
                    pnlMileageRsn.Visible = false;
                    mileage_rsn.Text = string.Empty;
                }
            }
            else
            {
                pnlMileageRsn.Visible = false;
                mileage_rsn.Text = string.Empty;
            }
        }
        catch { }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 統計當月車輛作業天數、車次及里程數
    /// </summary>
    /// <param name="target_date"></param>
    private void SumThisMonthCarWork(string target_date)
    {
        DBDAO dao = new DBDAO();
        sum_days.Text = string.Empty;
        sum_times.Text = string.Empty;
        sum_mileage.Text = string.Empty;
        try
        {
            dao.open();
            WorkModel model = new WorkModel();
            model.dao = dao;
            Form form = new Form();
            form.setValue("card_id", card_id.SelectedValue);
            DateTime start = Convert.ToDateTime(DateTransfer.c_date_trans(target_date.Substring(0, 7) +
                "01"));
            DateTime end = start.AddMonths(1).AddDays(-1);
            form.setValue("work_start", start.ToString("yyyy/MM/dd"));
            form.setValue("work_end", end.ToString("yyyy/MM/dd"));
            DataSet ds = model.SumThisMonthCarWork(form);
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                sum_days.Text = dr["sum_days"].ToString();
                sum_times.Text = dr["sum_times"].ToString();
                sum_mileage.Text = dr["sum_mileage"].ToString();
            }
        }
        catch
        { }
        finally
        {
            dao.close();
        }
    }


    /// <summary>
    /// 取得勤務日期內的加油數量及金額
    /// </summary>
    public void getFuelData()
    {
        DBDAO dao = new DBDAO();
        TextBox work_start = (TextBox)this.Page.FindControl("MasterPage$ContentPlaceHolder1$work_start");
        TextBox work_end = (TextBox)this.Page.FindControl("MasterPage$ContentPlaceHolder1$work_end");
        String str_card_id = card_id.SelectedValue;



        if (str_card_id != string.Empty && work_start.Text != string.Empty && start_HH.Text != string.Empty &&
            start_mm.Text != string.Empty && work_end.Text != string.Empty && end_HH.Text != string.Empty
            && end_mm.Text != string.Empty)
        {
            try
            {

                //DateTime start_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_start.Text) + " " +
                // HandleParam.addZero(start_HH.Text, 2) + ":" + HandleParam.addZero(start_mm.Text, 2) + ":00");
                //DateTime end_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_end.Text) + " " +
                //   HandleParam.addZero(end_HH.Text, 2) + ":" + HandleParam.addZero(end_mm.Text, 2) + ":00");
                DateTime now_dt = DateTime.Now;
                DateTime work_dt = Convert.ToDateTime(DateTransfer.c_date_trans(work_date.Text));
                DateTime start_dt = new DateTime(work_dt.Year, work_dt.Month, 1);
                DateTime end_dt = start_dt.AddMonths(1).AddDays(-1);

                machine_fuel_count.Text = string.Empty;
                machine_fuel_amount.Text = string.Empty;
                car_fuel_count.Text = string.Empty;
                car_fuel_amount.Text = string.Empty;

                if (work_dt.Year == now_dt.Year && work_dt.Month == now_dt.Month)
                {
                    machine_fuel_count.Text = "-";
                    machine_fuel_amount.Text = "-";
                    car_fuel_count.Text = "-";
                    car_fuel_amount.Text = "-";
                    return;
                }

                dao.open();
                CardModel model = new CardModel();
                model.dao = dao;
                Form form = new Form();
                form.setValue("card_id", str_card_id);
                form.setValue("start_date", start_dt.ToString("yyyy/MM/dd"));
                form.setValue("end_date", end_dt.ToString("yyyy/MM/dd"));
                DataSet ds = model.getFuelDataDuringWork(form);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    machine_fuel_count.Text = dr["fuel_count"].ToString();
                    machine_fuel_amount.Text = String.Format("{0:$#,##0;($#,##0);0}", Convert.ToInt32(dr["fuel_amount"].ToString()));
                    car_fuel_count.Text = dr["fuel_count"].ToString();
                    car_fuel_amount.Text = String.Format("{0:$#,##0;($#,##0);0}", Convert.ToInt32(dr["fuel_amount"].ToString()));
                }
                else
                {
                    machine_fuel_count.Text = "0";
                    machine_fuel_amount.Text = String.Format("{0:$#,##0;($#,##0);0}", 0);
                    car_fuel_count.Text = "0";
                    car_fuel_amount.Text = String.Format("{0:$#,##0;($#,##0);0}", 0);
                }
            }
            catch
            {

            }
            finally
            {
                dao.close();
            }
        }
    }


    /// <summary>
    /// 里程數(起)、(迄)的TextChanged事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mileage_TextChanged(object sender, EventArgs e)
    {
        if (mileage_end.Text != string.Empty && mileage_start.Text != string.Empty)
        {
            try
            {
                mileage.Text = (Convert.ToDouble(mileage_end.Text) - Convert.ToDouble(mileage_start.Text)).ToString();
                CheckMileage();
            }
            catch
            {
                SysMsg.AlertMessage(this.Page, "請輸入數字以便計算里程數！");
            }
        }

        if (sender.Equals(mileage_start) && mileage_end.Text == string.Empty)
        {
            mileage_end.Focus();
        }

    }


    /// <summary>
    /// 加油卡卡別連動加油卡卡號下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void card_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect("");
    }


    /// <summary>
    /// card_id的SelectedIndexChanged事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void card_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        Mediator med = new Mediator();
        if (card_id.SelectedValue != string.Empty)
        {
            getOilCardData(card_id.SelectedValue);
            getFuelData();
            if (work_type.SelectedValue == "C")
            {
                CheckMileage();
                SumThisMonthCarWork(work_date.Text);
            }
            if (car_type2.Text.Trim() == "A5:專用車")
            {

                DSPH_CAUSE.Enabled = true;
                ATU_USER.Enabled = true;
                PASSENGERS.Enabled = true;
                MILS.Enabled = true;
                ADM_DISTRICT.Enabled = true;
            }
            else
            {

                DSPH_CAUSE.Enabled = false;
                ATU_USER.Enabled = false;
                PASSENGERS.Enabled = false;
                MILS.Enabled = false;
                ADM_DISTRICT.Enabled = false;
            }
            //if (work_type.SelectedValue == "C")
            //{
            //    car_witem.Value = car_witem.Value;
            //    selected_item.Text = med.lookupParamNameMulti("CAR_WITEM", car_witem.Value, 0);
            //}
            //else
            //{
            //    mchn_witem.Value = mchn_witem.Value;
            //    selected_item.Text = med.lookupParamNameMulti("MCHN_WITEM", mchn_witem.Value, 0);
            //}
        }
    }

    /// <summary>
    /// 管理單位連動加油卡卡號下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect("");
    }


    /// <summary>
    /// 取得加油卡明細資料
    /// </summary>
    /// <param name="strCardID"></param>
    private void getOilCardData(String strCardID)
    {
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();
            CardModel model = new CardModel();
            Mediator med = new Mediator();
            model.dao = dao;
            DataSet ds = model.selectCardWithCar(strCardID, work_date.Text != string.Empty ? DateTransfer.c_date_trans(work_date.Text) : "");
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                //lblCardStatus.Text = med.lookupParamName("USE_STS", dr["card_status"].ToString(), 0);

                #region 取得統計勤務期間加油資料
                SumThisMonthCarWork(work_date.Text);
                #endregion

                if (dr["car_id"].ToString() != string.Empty)
                {
                    pnlCar.Visible = true;
                    car_id.Value = dr["car_id"].ToString();
                    dep_no.Text = dr["dep_no"].ToString();
                    car_type.Text = med.lookupParamName("CAR_TYPE", dr["car_type"].ToString(), 0);
                    car_status.Text = med.lookupParamName("USE_STS", dr["car_status"].ToString(), 0);
                    fuel_type.Text = med.lookupParamName("FUEL_TYPE", dr["fuel_type"].ToString(), 0);
                    fuel_std.Text = dr["fuel_std"].ToString();
                    car_type2.Text = dr["car"].ToString();

                }
                else
                {
                    pnlCar.Visible = false;
                    machine_fuel.Text = med.lookupParamName("FUEL_TYPE", dr["machine_fuel"].ToString(), 0);
                }

                mng_id.SelectedValue = dr["keep_org"].ToString();
                card_type.SelectedValue = dr["card_type"].ToString();
                //card_id.SelectedValue = dr["card_id"].ToString();
            }
            else
            {
                ClearCardControl();
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
    /// 清除加油卡資料控制項內容
    /// </summary>
    private void ClearCardControl()
    {
        car_id.Value = string.Empty;
        dep_no.Text = string.Empty;       
        car_type.Text = string.Empty;
        car_status.Text = string.Empty;
        fuel_type.Text = string.Empty;
        fuel_std.Text = string.Empty;
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
    /// 載入前次登打資料內容
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        UserID userID = (UserID)Session["UserID"];
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
        try
        {
            dao.open();
            Form form = new Form();
            form.setValue("user_id", userID.getUserID());
            form.setValue("work_type", work_type.SelectedValue);
            WorkModel model = new WorkModel();
            model.dao = dao;
            DataSet ds = model.getLastWork(form);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                work_man.Text = dr["work_man"].ToString();
                work_area.Text = dr["work_area"].ToString();
                work_location.Text = dr["work_location"].ToString();
                //2019.09.16
                work_item.Value = dr["work_item"].ToString();
                work_item_text.Value = model.getWorkItemText(dr["work_type"].ToString(), dr["work_item"].ToString());

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "load", "tableCreate();", true);

                //if (dr["work_type"].ToString() == "C")
                //{
                //    car_witem.Value = dr["work_item"].ToString();
                //    selected_item.Text = med.lookupParamNameMulti("CAR_WITEM", dr["work_item"].ToString(), 0);
                //}
                //else
                //{
                //    mchn_witem.Value = dr["work_item"].ToString();
                //    selected_item.Text = med.lookupParamNameMulti("MCHN_WITEM", dr["work_item"].ToString(), 0);
                //}
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
    /// 里程數自行修正CheckedChanged事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cbKeyMileage_CheckedChanged(object sender, EventArgs e)
    {
        if (cbKeyMileage.Checked == true)
        {
            pnlMileageKeyRsn.Visible = true;
            mileage.Enabled = true;
        }
        else
        {
            pnlMileageKeyRsn.Visible = false;
            mileage.Enabled = false;
            mileage_TextChanged(sender, e);
        }
    }


    /// <summary>
    /// 作業項目第一層選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void genWorkItemLevel1(object sender, EventArgs e)
    {
        HtmlTag hTag = new HtmlTag();

        if (work_type.SelectedValue.Equals("C"))
            hTag.createMediatorSelect("CAR_WITEM_L1", work_item_lvl1, "", "請選擇", 0);
        else
            hTag.createMediatorSelect("MCHN_WITEM_L1", work_item_lvl1, "", "請選擇", 0);

        work_item_lvl1_SelectedIndexChanged(sender, e);
    }


    /// <summary>
    /// 作業項目第二層選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void work_item_lvl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        HtmlTag hTag = new HtmlTag();

        if (!work_item_lvl1.SelectedValue.Equals(""))
            hTag.createMediatorSelect(work_item_lvl1.SelectedValue, work_item_lvl2, "", "請選擇", 0);
        else
        {
            ListItem li = new ListItem();
            li.Value = "";
            li.Text = "請選擇";
            work_item_lvl2.Items.Add(li);
        }
    }

    protected void car_type1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (car_type2.Text == "A5:專用車")
        {

            DSPH_CAUSE.Enabled = true;
            ATU_USER.Enabled = true;
            PASSENGERS.Enabled = true;
            MILS.Enabled = true;
            ADM_DISTRICT.Enabled = true;
        }
        else
        {

            DSPH_CAUSE.Enabled = false;
            ATU_USER.Enabled = false;
            PASSENGERS.Enabled = false;
            MILS.Enabled = false;
            ADM_DISTRICT.Enabled = false;
        }

    }
}