using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 車輛異動記錄：修改頁
/// </summary>
public partial class TDOSc002_TDOSc002U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();

        chg_rsn.Enabled = false;
        try
        {
            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSc002_update");
                //btnDelete.Visible = userID.hasFunc("TDOSc002_delete");
                
                Form form = new Form();
                form.setValue("chg_id", Request["chg_id"]);
                
                ChangeModel model = new ChangeModel();
                model.dao = dao;
                dao.open();
                HtmlTag hTag = new HtmlTag();
                DataSet ds = model.selectChg(form.getValue("chg_id"));
                DataRow dr = ds.Tables[0].Rows[0];
                keep_id.Text = dr["keep_id"].ToString();
                dep_no.Text = dr["dep_no"].ToString();
                car_type.Text = med.lookupParamName("CAR_TYPE", dr["car_type"].ToString(), 0);
                car_id.Value = dr["car_id"].ToString();
                old_chg_date.Value = DateTransfer.c_date_trans(dr["chg_date"].ToString());
                old_chg_rsn.Value = dr["chg_rsn"].ToString();
                card_id.Text = dr["card_id"].ToString();
                car_id1.Text = dr["car_id"].ToString();
                old_r1_org.Value = dr["r1_org"].ToString();
                old_chg_org.Value = dr["chg_org"].ToString();   
                chg_id.Value = dr["chg_id"].ToString().ToUpper();

                chg_id1.Text = dr["chg_id"].ToString().ToUpper();
                chg_date.Text = dr["chg_date"].ToString();
                chg_desc.Text = dr["chg_desc"].ToString();
                memo.Text = dr["memo"].ToString();

                old_status.Value = dr["old_status"].ToString();
                new_status.Value = dr["new_status"].ToString();
                old_keep.Value = dr["old_keep"].ToString();
                new_keep.Value = dr["new_keep"].ToString();
                old_card.Value = dr["old_card"].ToString();
                new_card.Value = dr["new_card"].ToString();

                //車隊卡卡號
                //card_no.Text = dr["card_no"].ToString(); 
                
                old_card.Value = dr["old_card"].ToString();
                new_card.Value = dr["new_card"].ToString();              
               
                if (!dr["old_keep"].ToString().Equals(""))
                {
                    keep_org.Text = med.lookupParamName("DEP_ORG", dr["old_keep"].ToString(), 0);
                }else
                    keep_org.Text = med.lookupParamName("DEP_ORG", dr["new_keep"].ToString(), 0);


               
                    status.Text = med.lookupParamName("USE_STS", dr["new_status"].ToString(), 0);
                

               
                if (!dr["old_card_no"].ToString().Equals(""))
                {
                    car_no.Text = dr["old_card_no"].ToString();
                }
                else
                {
                    car_no.Text = dr["new_card_no"].ToString();
                }
              

                hTag.createMediatorSelect("CHG_RSN", chg_rsn, dr["chg_rsn"].ToString(), "請選擇", 0);


                if (dr["chg_rsn"].ToString() == IniValue.ChgRsnR1)
                {
                    hTag.createMediatorSelect("DEP_ORG", r1_org, dr["r1_org"].ToString(), "請選擇", 0);
                    ListItem li = new ListItem();
                    li.Value = dr["chg_org"].ToString();
                    li.Text = med.lookupParamName("DEP_ORG", dr["chg_org"].ToString(), 0);
                    r1_org.Items.Remove(li);
                    pnlR1.Visible = true;
                    pnlR5.Visible = false;
                }
                else if (dr["chg_rsn"].ToString() == IniValue.ChgRsnR5)
                {
                    r5_license.Text = dr["r5_license"].ToString();
                    pnlR1.Visible = false;
                    pnlR5.Visible = true;
                    car_id2.Text = dr["r5_license"].ToString();

                }
                else
                {
                    pnlR1.Visible = false;
                    pnlR5.Visible = false;
                }
                if(dr["chg_rsn"].ToString() == "R5"|| dr["chg_rsn"].ToString() == "R1" || dr["chg_rsn"].ToString() == "R6" )
                {
                    //btnDelete.Visible = false;

                }




                #region 異動時的保管單位與車隊卡卡號
                form.setValue("chg_date", DateTransfer.c_date_trans(dr["chg_date"].ToString()));
                form.setValue("car_id", dr["car_id"].ToString());
                keep_org.Text = med.lookupParamName("DEP_ORG", dr["chg_org"].ToString(), 0);
                //card_no.Text = model.getCardNo(form);
                #endregion

                #region 異動原因是移撥且已過異動日期不可刪除
                DateTime chg_dt = Convert.ToDateTime(DateTransfer.c_date_trans(dr["chg_date"].ToString()));
                if (chg_dt <= DateTime.Now && dr["chg_rsn"].ToString() == "R1")
                {
                    if (!userID.getUserRead().Equals("ALL")) ;//跨單位讀取允許刪除
                        //btnDelete.Visible = false;
                }
                #endregion

                car_status1.str_car_id = dr["car_id"].ToString();
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
        Response.Redirect(Forward.Redirect("TDOSc002Q1.aspx", "", this));
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

        try
        {
            dao.open();
            dao.beginTransaction();

            Form form = new Form();
            form.setValue("chg_desc", chg_desc.Text);
            form.setValue("chg_date", DateTransfer.c_date_trans(chg_date.Text.Trim()));
            form.setValue("chg_id", chg_id1.Text);
            form.setValue("memo", memo.Text);
            form.setValue("car_id", car_id1.Text);
            form.setValue("keep_id", keep_id.Text);
            form.setValue("card_no", car_no.Text);
            form.setValue("car_no", r5_license.Text);
            form.setValue("car_no1", car_no.Text);
            form.setValue("card_id", card_id.Text);
            form.setValue("car_id2", car_id2.Text);
            form.setValue("car_id", car_id1.Text);

            form.setValue("keep_org", r1_org.SelectedValue);
            form.setValue("chg_rsn", chg_rsn.SelectedValue);

            ChangeModel model = new ChangeModel();
            model.dao = dao;
            if (chg_rsn.SelectedValue == "R2")
            {
                model.updateChg(form);

                model.NewChg(form.getValue("chg_id"));

            }
            
            if (chg_rsn.SelectedValue == "R4")
            {
                model.updateChg(form);

                model.NewChg(form.getValue("chg_id"));

            }
            if (chg_rsn.SelectedValue == "R6")
            {
                model.updateChg(form);

                model.NewChg(form.getValue("chg_id"));


                


            }
           
            if (chg_rsn.SelectedValue == "R1")//移撥

            {
                model.NewChg(form.getValue("chg_id"));
                model.updateChg1(form);

                model.updateCarKeep(form);
                //model.updatec_card_mst(form);

                //model.chg_org(form);
                //model.keep_mst(form);


            }
            if (chg_rsn.SelectedValue == "R5")//變更車牌
            {
                model.updateChg2(form);

                model.NewChg(form.getValue("chg_id"));
                model.updateCarNo3(form);
                model.updateCarNo2(form);

               
            }




            SYSLOG.setLog(Request, Session, "新增", dao.getSQL());

            CarModel car_model = new CarModel();
            SysMsg.AlertMessage(this.Page, "儲存成功！");
            dao.commit();
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
            if (!CheckAll())
                return;

            dao.open();
            dao.beginTransaction();

            ChangeModel model = new ChangeModel();
            CardModel cardModel = new CardModel();
            CarModel car_model = new CarModel();

            model.dao = dao;
            cardModel.dao = dao;
            car_model.dao = dao;

            Form form = new Form();
            form.setValue("chg_id", chg_id.Value);

            Form keep_form = new Form();
            DateTime chg_dt = Convert.ToDateTime(old_chg_date.Value);
            keep_form.setValue("keep_start", chg_dt.ToString("yyyy/MM/dd"));
            keep_form.setValue("keep_end", chg_dt.AddDays(-1).ToString("yyyy/MM/dd"));
            keep_form.setValue("car_id", car_id.Value);


            if (old_chg_rsn.Value == IniValue.ChgRsnR1)
            {
                #region 刪除移撥異動影響記錄
                //model.updatekeepOld(keep_form); //原保管單位keep_end設為null
                //model.updateCardPossessOld(keep_form); //原加油卡possess_end設為null
                //model.deletekeepNew(keep_form); //刪除新保管單位保管記錄
                //model.deleteCardPossessNew(keep_form); //刪除新加油卡持有記錄
                #endregion
            }
            else if (chg_rsn.SelectedValue == IniValue.ChgRsnR4 || chg_rsn.SelectedValue == IniValue.ChgRsnR2)
            {
                #region 刪除報廢異動影響資料
                model.updateStatusOld(keep_form); //原狀態資料exec_end設為null

                model.deleteStatusNew(keep_form); //刪除新狀態資料
                #endregion
            }
            else if (chg_rsn.SelectedValue == IniValue.ChgRsnR5)
            {
                #region 刪除變更車牌異動影響資料
                //修改車輛的車牌號碼
                Form carForm = new Form();
                carForm.setValue("car_id", car_id.Value);
                carForm.setValue("car_no", car_no.Text);
                carForm.setValue("memo", Environment.NewLine + DateTransfer.c_date_intrans(DateTime.Now.ToString("yyyy/MM/dd")) + "刪除異動資料：異動日期" + chg_date.Text + "變更車牌號碼" + form.getValue("r5_license") + "。");
                car_model.updateCarNo(carForm);

                //修改舊車隊卡對應資料
                Form cardForm = new Form();
                cardForm.setValue("card_id", old_card.Value);
                cardForm.setValue("chg_date", old_chg_date.Value);
                cardForm.setValue("update_user", userID.getUserID());
                cardModel.updateCardPossessNull(cardForm);

                //刪除新車隊卡對應資料
                cardModel.deleteCarCard(new_card.Value);

                //刪除新車隊卡
                cardModel.deleteCard(new_card.Value);

                #endregion
            }

            #region 將加油卡狀態改回使用中    
            
            if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR1) || chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR2) || chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR4) || chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR6)) //R5變更車牌
            {
                Form card_status = new Form();
                card_status.setValue("card_id", new_card.Value);
                card_status.setValue("status", "O");
                card_status.setValue("update_user", userID.getUserID());
                cardModel.updateCardStatus(card_status);
            }
           if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR6)) //復駛
            {

                model.updateStatusOld(keep_form); //原狀態資料exec_end設為null

                model.deleteStatusNew(keep_form); //刪除新狀態資料
            }
            #endregion

            //Form status_form = new Form();
            //CarModel car_model = new CarModel();
            //car_model.dao = dao;
            //status_form.setValue("car_id", car_id.Value);
            //status_form.setValue("exec_end", "");

            //car_form.setValue("status", car_status.Value);
            //car_form.setValue("update_user", userID.getUserID());
            //car_model.updateCarStatus(car_form);


            model.deleteChg(form.getValue("chg_id"));

            dao.commit();
            Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSc002Q1.aspx", "", this) + "'; </script>");
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

    private Boolean CheckAll()
    {
        Boolean flag = true;
        DBDAO dao = new DBDAO();

        ChangeModel model = new ChangeModel();
        //CardModel cardModel = new CardModel();
        Form form = new Form();

        form.setValue("car_id", car_id.Value);

        try
        {
            dao.open();

            //carModel.dao = dao;
            model.dao = dao;

            DataSet dsStatus = model.getCarStatus(form);
            DataSet dsCard = model.getCarCard(form);

            //報停
            if (flag && chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR2))
            {
                if (dsStatus.Tables[0].Rows.Count > 0)
                {
                    int iLast = dsStatus.Tables[0].Rows.Count - 1;
                    DataRow drStatus = dsStatus.Tables[0].Rows[iLast];

                    if (!drStatus["exec_start"].ToString().Equals(chg_date.Text))
                    {
                        flag = false;
                        SysMsg.AlertMessage(this.Page, "已有其他較新異動不可刪除此資料！");
                    }
                }
            }

            //變更車牌
            if (flag && chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR5))
            {
                if (dsCard.Tables[0].Rows.Count > 0)
                {
                    int iLast = dsCard.Tables[0].Rows.Count - 1;
                    DataRow drCard = dsCard.Tables[0].Rows[iLast];

                    if (!drCard["possess_start"].ToString().Equals(chg_date.Text))
                    {
                        flag = false;
                        SysMsg.AlertMessage(this.Page, "已有其他較新異動不可刪除此資料！");
                    }
                }
            }



        }
        catch (Exception ex)
        {
            flag = false;
            SysMsg.AlertMessage(this.Page, ex.Message + "\n" + ex.StackTrace);
        }
        finally
        {
            dao.close();
        }




        return flag;
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
}