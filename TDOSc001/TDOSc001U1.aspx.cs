using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 車輛基本資料：修改頁
/// </summary>
public partial class TDOSc001_TDOSc001U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        //2019.07.29
        //status.Enabled = false;

            if (!IsPostBack)
        {
            //button權限
            btnSave.Visible = userID.hasFunc("TDOSc001_update");
            btnDelete.Visible = userID.hasFunc("TDOSc001_delete");
            pnlCRS.Visible = (btnSave.Visible && userID.getUserSys().Equals(IniValue.sysCRS));

            Form form = new Form();
            form.setValue("car_id", Request["car_id"]);
            form.setValue("keep_org", "");
            form.setValue("car_no", "");
            form.setValue("dep_no", "");
            form.setValue("dep_car", "");
            form.setValue("user_sys", userID.getUserSys());




            CarModel model = new CarModel();
            model.dao = dao;
            dao.open();
            HtmlTag hTag = new HtmlTag();
            Mediator Med = new Mediator();
            DataSet ds = model.selectCar(form);
            DataRow dr = ds.Tables[0].Rows[0];

            car_id.Value = dr["car_id"].ToString().ToUpper();
            car_no.Text = dr["car_no"].ToString();
            dep_no.Text = dr["dep_no"].ToString();
            car_year.Text = dr["car_year"].ToString();
            buy_date.Text = dr["buy_date"].ToString();
            brand_no.Text = dr["brand_no"].ToString();
            engine_no.Text = dr["engine_no"].ToString();
            tonnage.Text = dr["tonnage"].ToString();
            displacement.Text = dr["displacement"].ToString();
            fuel_std.Text = dr["fuel_std"].ToString();
            memo.Text = dr["memo"].ToString();
            old_status.Value = dr["status"].ToString();
            old_keep_org.Value = dr["keep_org"].ToString();
            possess_id.Value = dr["possess_id"].ToString();
            keep_start.Value = dr["keep_start"].ToString();
            keep_id.Value = dr["keep_id"].ToString();
            exec_id.Value = dr["exec_id"].ToString();
            old_buy_date.Value = dr["buy_date"].ToString();
            next_inspection.Text = dr["next_inspection"].ToString(); //下次定檢日
            licensing_date.Text = dr["licensing_date"].ToString();   //發照日期

            status.SelectedValue = dr["status"].ToString();
            CAR.SelectedValue = dr["CAR"].ToString();
            if (userID.getUserSys().Equals(IniValue.sysCRS))
            {
                add_device.Text = dr["add_device"].ToString();
                check_date.Text = dr["check_date"].ToString();
            }

            hTag.createMediatorSelect("CAR_TYPE", car_type, dr["car_type"].ToString(), "請選擇", 0);
            hTag.createMediatorSelect("DEP_ORG", keep_org, dr["keep_org"].ToString(), "請選擇", 0);
            hTag.createMediatorSelect("FUEL_TYPE", fuel_type, dr["fuel_type"].ToString(), "請選擇", 0);

            if (dr["chg_rsn"].ToString() != string.Empty)
            {
                if (dr["chg_rsn"].ToString() != "R3" && dr["status"].ToString() == "C")
                {
                    status_desc.Text = "(停用原因：" + dr["chg_date"].ToString() + "已設為" +
                        Med.lookupParamName("CHG_RSN", dr["chg_rsn"].ToString(), 0);
                    old_chg_rsn.Value = dr["chg_rsn"].ToString();
                }
                else if (dr["chg_rsn"].ToString() != "R2" && dr["status"].ToString() == "C" &&
                    dr["keep_org"].ToString() != userID.getUserOrg()) //移撥
                {
                    btnSave.Enabled = false;
                }
            }

            //CardModel card_model = new CardModel();
            //card_model.dao = dao;
            //ArrayList al_card = card_model.selectCardNo(keep_org.SelectedValue, dr["card_id"].ToString());
            //hTag.createSelect(al_card, card_id, dr["card_id"].ToString(), "請選擇", 0);
            card_id.Value = dr["card_id"].ToString();
            if (userID.getUserRead() != "ALL")
            {
                keep_org.Enabled = false;
            }

            car_status1.str_car_id = dr["car_id"].ToString();
            car_inspection.str_car_id = dr["car_id"].ToString();

            dao.close();
        }

        //try
        //{
        //    if (!IsPostBack)
        //    {
        //        //button權限
        //        btnSave.Visible = userID.hasFunc("TDOSc001_update");
        //        btnDelete.Visible = userID.hasFunc("TDOSc001_delete");
        //        pnlCRS.Visible = (btnSave.Visible && userID.getUserSys().Equals(IniValue.sysCRS));

        //        Form form = new Form();
        //        form.setValue("car_id", Request["car_id"]);
        //        form.setValue("keep_org", "");
        //        form.setValue("car_no", "");
        //        form.setValue("dep_no", "");
        //        form.setValue("dep_car", "");
        //        form.setValue("user_sys", userID.getUserSys());
               

        //        CarModel model = new CarModel();
        //        model.dao = dao;
        //        dao.open();
        //        HtmlTag hTag = new HtmlTag();
        //        Mediator Med = new Mediator();
        //        DataSet ds = model.selectCar(form);
        //        DataRow dr = ds.Tables[0].Rows[0];

        //        car_id.Value = dr["car_id"].ToString().ToUpper();
        //        car_no.Text = dr["car_no"].ToString();
        //        dep_no.Text = dr["dep_no"].ToString();
        //        car_year.Text = dr["car_year"].ToString();
        //        buy_date.Text = dr["buy_date"].ToString();
        //        brand_no.Text = dr["brand_no"].ToString();
        //        engine_no.Text = dr["engine_no"].ToString();
        //        tonnage.Text = dr["tonnage"].ToString();
        //        displacement.Text = dr["displacement"].ToString();
        //        fuel_std.Text = dr["fuel_std"].ToString();
        //        memo.Text = dr["memo"].ToString();
        //        old_status.Value = dr["status"].ToString();
        //        old_keep_org.Value = dr["keep_org"].ToString();
        //        possess_id.Value = dr["possess_id"].ToString();
        //        keep_start.Value = dr["keep_start"].ToString();
        //        keep_id.Value = dr["keep_id"].ToString();
        //        exec_id.Value = dr["exec_id"].ToString();
        //        old_buy_date.Value = dr["buy_date"].ToString();
        //        next_inspection.Text = dr["next_inspection"].ToString(); //下次定檢日
        //        licensing_date.Text = dr["licensing_date"].ToString();   //發照日期


        //        if (userID.getUserSys().Equals(IniValue.sysCRS))
        //        {
        //            add_device.Text = dr["add_device"].ToString();
        //            check_date.Text = dr["check_date"].ToString();
        //        }

        //        hTag.createMediatorSelect("CAR_TYPE", car_type, dr["car_type"].ToString(), "請選擇", 0);
        //        hTag.createMediatorSelect("DEP_ORG", keep_org, dr["keep_org"].ToString(), "請選擇", 0);
        //        hTag.createMediatorRadio("USE_STS", status, dr["status"].ToString(), 0);
        //        hTag.createMediatorSelect("FUEL_TYPE", fuel_type, dr["fuel_type"].ToString(), "請選擇", 0);

        //        if (dr["chg_rsn"].ToString() != string.Empty)
        //        {
        //            if (dr["chg_rsn"].ToString() != "R3" && dr["status"].ToString() == "C")
        //            {
        //                status_desc.Text = "(停用原因：" + dr["chg_date"].ToString() + "已設為" +
        //                    Med.lookupParamName("CHG_RSN", dr["chg_rsn"].ToString(), 0);
        //                old_chg_rsn.Value = dr["chg_rsn"].ToString();
        //            }
        //            else if (dr["chg_rsn"].ToString() != "R2" && dr["status"].ToString() == "C" &&
        //                dr["keep_org"].ToString() != userID.getUserOrg()) //移撥
        //            {
        //                btnSave.Enabled = false;
        //            }
        //        }

        //        //CardModel card_model = new CardModel();
        //        //card_model.dao = dao;
        //        //ArrayList al_card = card_model.selectCardNo(keep_org.SelectedValue, dr["card_id"].ToString());
        //        //hTag.createSelect(al_card, card_id, dr["card_id"].ToString(), "請選擇", 0);
        //        card_id.Value = dr["card_id"].ToString();
        //        if (userID.getUserRead() != "ALL")
        //        {
        //            keep_org.Enabled = false;
        //        }

        //        car_status1.str_car_id = dr["car_id"].ToString();
        //        car_inspection.str_car_id = dr["car_id"].ToString();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    SysMsg.AlertMessage(this.Page, ex.StackTrace);
        //}
        //finally
        //{
        //    dao.close();
        //}
    }


    /// <summary>
    /// 返回按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //Response.Write(Session["NOTIFYMSG"]);
        Response.Redirect(Forward.Redirect("TDOSc001Q1.aspx", "", this));
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
        Form form = new Form();

        try
        {
            if (CheckAll())
            {
                dao.open();
                dao.beginTransaction();
                
                form.setValue("car_id", car_id.Value);
                form.setValue("dep_no", dep_no.Text.Trim());
                form.setValue("car_no", car_no.Text.ToUpper().Trim());
                form.setValue("car_type", car_type.SelectedValue);
                form.setValue("car_year", car_year.Text.Trim());
                form.setValue("buy_date", buy_date.Text != string.Empty ? DateTransfer.c_date_trans(buy_date.Text.Trim()) : "");
                form.setValue("brand_no", brand_no.Text.Trim());
                form.setValue("engine_no", engine_no.Text.Trim());
                form.setValue("tonnage", tonnage.Text.Trim());
                form.setValue("displacement", displacement.Text.Trim());
                //form.setValue("card_id", card_id.SelectedValue);
                form.setValue("possess_id", possess_id.Value);
                form.setValue("keep_id", keep_id.Value);
                form.setValue("exec_id", exec_id.Value);
                form.setValue("keep_org", keep_org.SelectedValue);
                form.setValue("car", CAR.SelectedValue);

                form.setValue("status", status.SelectedValue);
                form.setValue("fuel_type", fuel_type.SelectedValue);
                form.setValue("fuel_std", fuel_std.Text.Trim());
                form.setValue("memo", memo.Text.Trim());
                form.setValue("update_user", userID.getUserID());
                form.setValue("add_device", add_device.Text);
                form.setValue("check_date", check_date.Text != string.Empty ? DateTransfer.c_date_trans(check_date.Text.Trim()) : "");
                form.setValue("user_sys", userID.getUserSys());
                form.setValue("next_inspection", next_inspection.Text != string.Empty ? DateTransfer.c_date_trans(next_inspection.Text.Trim()) : ""); //下次定檢日
                form.setValue("licensing_date", licensing_date.Text != string.Empty ? DateTransfer.c_date_trans(licensing_date.Text.Trim()) : ""); //發照日期
                form.setValue("card_no", form.getValue("car_no"));
                form.setValue("action", "");   
 
                CarModel model = new CarModel();
                CardModel cardModel = new CardModel();

                model.dao = dao;
                cardModel.dao = dao;

                //if (old_card_id.Value == string.Empty && keep_start.Value != string.Empty) //移撥後尚未設定車隊卡          
                //{
                //    form.setValue("keep_start", keep_start.Value);                   
                //}               
                //else 
                //{
                //    form.setValue("exec_start", "");
                //    form.setValue("keep_start", "");
                //}

                model.updateCar(form);
                model.updateCarStatus(form);
                model.updateCarKeep(form);

                //修改購置日期影響第一筆車輛狀態、車隊卡持有起始日、車輛保管起始日
                if (old_buy_date.Value != buy_date.Text && buy_date.Text !=string.Empty)
                {
                    string new_buy = DateTransfer.c_date_trans(buy_date.Text);
                    model.updateFirstStatusStart(car_id.Value, new_buy);
                    model.updateFirstKeepStart(car_id.Value, new_buy);
                    model.updateFirstCardStart(car_id.Value, new_buy);
                }

                //修改車牌號碼
                if (old_car_no.Value != form.getValue("car_no"))               
                {
                    Boolean isOtherCarUse = false;

                    String sCardId = cardModel.IsCardNoExist(form);

                    Form cardForm = new Form();
                    cardForm.setValue("card_id", card_id.Value);
                    cardForm.setValue("old_card", card_id.Value);
                    cardForm.setValue("new_card", sCardId);
                    cardForm.setValue("card_no", form.getValue("car_no"));
                    cardForm.setValue("update_user", userID.getUserID());

                    DataSet ds = cardModel.selectCarCard(cardForm);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        if (!dr["car_id"].ToString().Equals(car_id.Value))
                            isOtherCarUse = true;
                    }

                    //車牌號碼已存在加油卡，變更對應關係到已存在加油卡
                    if (sCardId != string.Empty)
                        cardModel.updateCarCard(cardForm);
                    else
                    {
                        //不存在車牌號碼但card_id有對應關係
                        if (isOtherCarUse)
                        {
                            //複製車隊卡
                            Decimal copy_card = cardModel.copyCard(card_id.Value);
                            //複製車隊卡對應關係
                            form.setValue("card_id", copy_card.ToString());
                            model.insertCarCard(form);
                        }
                        else //車牌號碼
                        {
                            cardModel.updateCardNo(cardForm);
                        }

                    }
                    ////possess_start必須是異動日那天
                    //form.setValue("possess_start", keep_start.Value);
                    //model.insertCarCard(form);
                }
                //else if (old_card_id.Value != string.Empty && old_card_id.Value != card_id.SelectedValue)
                //{
                //    //form.setValue("possess_start", DateTransfer.c_date_trans(buy_date.Text));
                //    model.updateCarCard(form);
                //}

                #region 重新啟用
                if (old_status.Value == "C" && status.SelectedValue == "O" && old_chg_rsn.Value == "R2")
                {
                    ChangeModel chg_model = new ChangeModel();
                    chg_model.dao = dao;
                    Form chg_form = new Form();
                    chg_form.setValue("car_id", car_id.Value);
                    chg_form.setValue("chg_date", DateTime.Now.ToString("yyyy/MM/dd"));
                    chg_form.setValue("chg_rsn", "R3");
                    chg_form.setValue("chg_org", keep_org.SelectedValue);
                    chg_form.setValue("chg_desc", "重新啟用");
                    chg_form.setValue("memo", "");
                    chg_form.setValue("create_user", userID.getUserID());
                    chg_model.insertChg(chg_form);

                    //新增使用中的狀態
                    Form new_sts = new Form();
                    new_sts.setValue("car_id", car_id.Value);
                    new_sts.setValue("exec_start", DateTime.Now.ToString("yyyy/MM/dd"));
                    new_sts.setValue("status", "O");
                    new_sts.setValue("create_user", userID.getUserID());
                    model.insertCarStatus(new_sts);

                    //修改原停用的狀態
                    Form old_sts = new Form();
                    old_sts.setValue("exec_id", exec_id.Value);
                    old_sts.setValue("exec_end", DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd"));
                    old_sts.setValue("update_user", userID.getUserID());
                    model.updateCarStatus(old_sts);
                }
                #endregion                

                dao.commit();

                car_status1.BindCarStatusGrid(car_id.Value);
                SysMsg.AlertMessage(this.Page, "儲存成功！");
            }
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "儲存失敗！\n" + ex.Message);
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
        Boolean flag = true;
        CarModel model = new CarModel();
        model.dao = dao;
        try
        {
            dao.open();
            dao.beginTransaction();

            #region 刪除前檢核是否有勤務記錄及加油資料
            if (flag && model.IsCarIdExistWorkData(car_id.Value))
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "已有建立勤務記錄，不可刪除！");
            }

            if (flag && model.IsCarIdExistFuelData(car_id.Value))
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "已有加油資料不可刪除！");
            }

            if (flag && model.IsCarChanged(car_id.Value, "R1"))
            {
                flag = false;
                SysMsg.AlertMessage(this.Page, "已有車輛移撥異動記錄不可刪除！");
            }
            #endregion

            if (flag)
            { 
                Form form = new Form();
                form.setValue("car_id", car_id.Value);

                model.deleteCar(form.getValue("car_id"));
                model.deleteCarStatus(form.getValue("car_id"));
                model.deleteCarCard(form.getValue("car_id"));
                model.deleteCarKeep(form.getValue("car_id"));
                model.deleteCarChange(form.getValue("car_id"));

                dao.commit();
                Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSc001Q1.aspx", "", this) + "'; </script>");
            }
        }
        catch (Exception ex)
        {
            dao.rollback();
            SysMsg.AlertMessage(this.Page, "刪除失敗！\n" + ex.Message);
        }
        finally
        {
            dao.close();
        }
    }


    //protected void keep_org_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    UserID userID = (UserID)Session["UserID"];
    //    DBDAO dao = new DBDAO();
    //    HtmlTag hTag = new HtmlTag();
    //    try
    //    {
    //        dao.open();
    //        CardModel model = new CardModel();
    //        model.dao = dao;
    //        ArrayList al_card = model.selectCardNo(keep_org.SelectedValue, old_card_id.Value);
    //        hTag.createSelect(al_card, card_id, "", "請選擇", 0);
    //    }
    //    catch (Exception ex)
    //    {
    //        SysMsg.AlertMessage(this.Page, ex.Message);
    //    }
    //    finally
    //    {
    //        dao.close();
    //    }
    //}


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
    /// 驗證西元年格式
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void ADYearValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(args.Value + "/01/01");
            args.IsValid = true;
        }
        catch
        {
            args.IsValid = false;
        }
    }


    /// <summary>
    /// 儲存前的檢核
    /// </summary>
    /// <returns></returns>
    private Boolean CheckAll()
    {
        Boolean flag = true;
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();
            CarModel model = new CarModel();
            model.dao = dao;

            #region 車牌號碼不可重複
            if (flag && car_no.Text != string.Empty)
            {
                Form form = new Form();
                form.setValue("car_no", car_no.Text);
                form.setValue("action", "Update");
                form.setValue("car_id", car_id.Value);
                if (model.IsCarNoExist(form))
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "已存在車牌號碼，不可重複新增！");
                }
            }
            #endregion

            #region 購置日期不可大於今日
            if (flag && buy_date.Text != string.Empty)
            {
                DateTime buy_dt = Convert.ToDateTime(DateTransfer.c_date_trans(buy_date.Text));
                if (buy_dt.AddDays(1) > DateTime.Now)
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "購置日期不可大於今日！");
                }
            }
            #endregion

            #region 修改保管單位必須是沒有車輛異動記錄
            if (flag && old_keep_org.Value != keep_org.SelectedValue)
            {
                if (model.IsCarChanged(car_id.Value, ""))
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "車輛已有異動記錄不可修改保管單位，請使用車輛異動記錄移撥功能！");
                }
            }
            #endregion
        }
        catch { }
        finally { dao.close(); }

        return flag;
    }
}