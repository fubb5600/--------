using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
/// <summary>
/// 車輛異動記錄：新增頁
/// </summary>
public partial class TDTSc002_TDTSc002I1 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		UserID userID = (UserID)Session["UserID"];
		DBDAO dao = new DBDAO();
		Mediator med = new Mediator();
		HtmlTag hTag = new HtmlTag();

		try
		{
			dao.open();

			if (!IsPostBack)
			{
				//button權限
				btnSave.Visible = userID.hasFunc("TDOSc002_insert");

				hTag.createMediatorSelect("CHG_RSN", chg_rsn, "", "請選擇", 0);
				hTag.createMediatorSelect("DEP_ORG", mng_id, userID.getUserOrg1(), "請選擇", 0);
				mng_id_SelectedIndexChanged(sender, e);
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
			if (CheckAll())
			{
				dao.open();
				dao.beginTransaction();

				Form form = new Form();
				form.setValue("car_id", car_id.SelectedValue);
				form.setValue("chg_date", DateTransfer.c_date_trans(chg_date.Text.Trim()));
				form.setValue("chg_rsn", chg_rsn.SelectedValue);
				if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR1))
					form.setValue("r1_org", r1_org.SelectedValue);//移撥單位
				else
					form.setValue("r1_org", "");
				if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR5))
					form.setValue("r5_license", r5_license.Text.Trim().ToUpper());//變更車牌
				else
					form.setValue("r5_license", "");
				form.setValue("chg_desc", chg_desc.Text.Trim());
				form.setValue("chg_org", mng_id.SelectedValue);
				form.setValue("memo", memo.Text.Trim());
				form.setValue("create_user", userID.getUserID());

				//新增異動記錄
				ChangeModel model = new ChangeModel();
				model.dao = dao;
				Decimal chg_id;
				chg_id = model.insertChg(form);

				SYSLOG.setLog(Request, Session, "新增", dao.getSQL());

				CarModel car_model = new CarModel();
				car_model.dao = dao;

				CardModel card_model = new CardModel();
				card_model.dao = dao;

				DateTime chg_dt = Convert.ToDateTime(DateTransfer.c_date_trans(chg_date.Text));

                if (chg_rsn.SelectedValue == IniValue.ChgRsnR1) //移撥時異動保管記錄
                {
                    Form new_keep = new Form();
                    new_keep.setValue("car_id", car_id.SelectedValue);
                    new_keep.setValue("keep_org", r1_org.SelectedValue);
                    new_keep.setValue("keep_start", DateTransfer.c_date_trans(chg_date.Text));
                    new_keep.setValue("chg_id", chg_id.ToString());
                    new_keep.setValue("create_user", userID.getUserID());
                    car_model.insertCarkeep(new_keep);
                    SYSLOG.setLog(Request, Session, "新增", dao.getSQL());

                    Form old_keep = new Form();
                    old_keep.setValue("car_id", car_id.SelectedValue);
                    old_keep.setValue("keep_id", keep_id.Value);
                    old_keep.setValue("keep_end", chg_dt.AddDays(-1).ToString("yyyy/MM/dd"));
                    old_keep.setValue("update_user", userID.getUserID());
                    car_model.updateCarKeep(old_keep);
                    SYSLOG.setLog(Request, Session, "修改", dao.getSQL());
                }
                else if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR4)) //報停時異動車輛
                {
                    Form new_status = new Form();
                    new_status.setValue("car_id", car_id.SelectedValue);
                    new_status.setValue("exec_start", DateTransfer.c_date_trans(chg_date.Text));
                    new_status.setValue("status", "C");
                    new_status.setValue("create_user", userID.getUserID());
                    car_model.insertCarStatus(new_status);
                    SYSLOG.setLog(Request, Session, "新增", dao.getSQL());

                    Form old_status = new Form();
                    old_status.setValue("exec_id", exec_id.Value);
                    old_status.setValue("exec_end", chg_dt.AddDays(-1).ToString("yyyy/MM/dd"));
                    old_status.setValue("update_user", userID.getUserID());
                    car_model.updateCarStatus(old_status);
                    SYSLOG.setLog(Request, Session, "修改", dao.getSQL());
                }
				else if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR2)) //報停時異動車輛
				{
					Form new_status = new Form();
					new_status.setValue("car_id", car_id.SelectedValue);
					new_status.setValue("exec_start", DateTransfer.c_date_trans(chg_date.Text));
					new_status.setValue("status", "報廢");
					new_status.setValue("create_user", userID.getUserID());
					car_model.insertCarStatus(new_status);
					SYSLOG.setLog(Request, Session, "新增", dao.getSQL());

					Form old_status = new Form();
					old_status.setValue("exec_id", exec_id.Value);
					old_status.setValue("exec_end", chg_dt.AddDays(-1).ToString("yyyy/MM/dd"));
					old_status.setValue("update_user", userID.getUserID());
					car_model.updateCarStatus(old_status);
					SYSLOG.setLog(Request, Session, "修改", dao.getSQL());
				}
				else if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR5)) //變更車牌 => 變更加油卡
                {
                    //修改車輛基本資料的車牌號碼
                    Form new_carno = new Form();
                    new_carno.setValue("car_id", car_id.SelectedValue);
                    new_carno.setValue("car_no", form.getValue("r5_license"));
                    new_carno.setValue("memo", Environment.NewLine + chg_date.Text + "變更車牌號碼" + form.getValue("r5_license") + "(舊車牌號碼：" + card_no.Text + ")");
                    car_model.updateCarNo(new_carno);
                    SYSLOG.setLog(Request, Session, "修改", dao.getSQL());
                }
                else if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR6)) //復駛
                {
					Form new_status = new Form();
                    new_status.setValue("car_id", car_id.SelectedValue);
                    new_status.setValue("exec_start", DateTransfer.c_date_trans(chg_date.Text));
                    new_status.setValue("status", "O");
                    new_status.setValue("create_user", userID.getUserID());
                    car_model.insertCarStatus1(new_status);
                    SYSLOG.setLog(Request, Session, "新增", dao.getSQL());


					Form old_status = new Form();
					old_status.setValue("car_id", car_id.SelectedValue);
					old_status.setValue("exec_end", chg_dt.AddDays(-1).ToString("yyyy/MM/dd"));
					old_status.setValue("update_user", userID.getUserID());
					car_model.updateCarStatus1(old_status);
					SYSLOG.setLog(Request, Session, "修改", dao.getSQL());


					//修改車輛基本資料的車牌號碼
					Form new_carno = new Form();
					new_carno.setValue("car_id", car_id.SelectedValue);
					new_carno.setValue("exec_end", chg_dt.AddDays(-1).ToString("yyyy/MM/dd"));
					new_carno.setValue("update_user", userID.getUserID());
					car_model.updateCarStatus3(new_carno);
					SYSLOG.setLog(Request, Session, "修改", dao.getSQL());

				}

                #region 非報廢報停時異動加油卡
                if (!chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR2) && !chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR4) && !chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR6))
                {
                    Form newCardForm = new Form();

                    if (new_card.Value == string.Empty)
                    {
                        //新增車隊卡                        
                        newCardForm.setValue("card_type", "1");

                        if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR5))
                            newCardForm.setValue("card_no", form.getValue("r5_license"));
                        else
                            newCardForm.setValue("card_no", card_no.Text);

                        if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR1))
                            newCardForm.setValue("keep_org", form.getValue("r1_org"));
                        else
                            newCardForm.setValue("keep_org", mng_id.SelectedValue);
                        newCardForm.setValue("keep_man", "");
                        newCardForm.setValue("fuel_type", fuel_type.Value);
                        newCardForm.setValue("status", "O");
                        newCardForm.setValue("create_user", userID.getUserID());
                        newCardForm.setValue("possess_start", DateTransfer.c_date_trans(chg_date.Text));
                        SYSLOG.setLog(Request, Session, "新增", dao.getSQL());

                        Decimal new_carid = card_model.insertCard(newCardForm);
                        new_card.Value = new_carid.ToString();
                    }

                    //新增車輛對應車隊卡記錄
                    newCardForm.setValue("card_id", new_card.Value);
                    newCardForm.setValue("car_id", car_id.SelectedValue);
                    //2019.07.26
                    car_model.insertCarCard(newCardForm);


                    SYSLOG.setLog(Request, Session, "新增", dao.getSQL());

                    //修改舊車隊卡對應記錄
                    Form old_card = new Form();
                    old_card.setValue("possess_id", possess_id.Value);
                    old_card.setValue("possess_end", chg_dt.AddDays(-1).ToString("yyyy/MM/dd"));
                    old_card.setValue("update_user", userID.getUserID());
                    card_model.updateCardPossess(old_card);
                    SYSLOG.setLog(Request, Session, "修改", dao.getSQL());
                }

                #endregion

                #region 報停、報廢時將車隊卡設為停用
                if (chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR4) || chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR2))
                {
                    Form card_status = new Form();
                    card_status.setValue("card_id", card_id.Value);
                    card_status.setValue("status", "C");
                    card_status.setValue("update_user", userID.getUserID());
                    card_model.updateCardStatus(card_status);
                }
                #endregion


                dao.commit();
				SysMsg.AlertMessage(this.Page, "新增成功！");

				Response.Write("<script>alert('新增成功！'); location.href='" + Forward.Redirect("TDOSc002Q1.aspx",
				"", this) + "'; </script>");
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
			form.setValue("car_id", car_id.SelectedValue);
			CarModel model = new CarModel();
			model.dao = dao;
			DataSet ds = model.selectCarDatabyCarNo(form);
			if (ds.Tables[0].Rows.Count == 1)
			{
				DataRow dr = ds.Tables[0].Rows[0];
				dep_no.Text = dr["dep_no"].ToString();
				car_type.Text = dr["car_type"].ToString();
				status.Text = dr["status"].ToString();
				card_no.Text = dr["card_no"].ToString();
				keep_start.Value = dr["keep_start"].ToString();
				keep_end.Value = dr["keep_end"].ToString();
			}
			else if (ds.Tables[0].Rows.Count == 0)
			{
				SysMsg.AlertMessage(this.Page, "查無符合的車輛資料，請重新輸入車號!");
			}
			else
			{
				SysMsg.AlertMessage(this.Page, "查詢計有" + ds.Tables[0].Rows.Count.ToString() +
					"筆車輛資料，請輸入唯一值的車號!");
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
	/// 清除車輛資料
	/// </summary>
	private void ClearCarControl()
	{
		dep_no.Text = string.Empty;
		car_type.Text = string.Empty;
		status.Text = string.Empty;
		card_no.Text = string.Empty;
		keep_id.Value = string.Empty;
		keep_start.Value = string.Empty;
		keep_end.Value = string.Empty;
		possess_id.Value = string.Empty;


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
	/// 異動原因位移撥時須顯示移撥單位
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void chg_rsn_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (chg_rsn.SelectedValue == IniValue.ChgRsnR1)
		{
			pnlR1.Visible = true;
			pnlR5.Visible = false;

			#region 移撥單位排除保管單位
			HtmlTag hTag = new HtmlTag();
			Mediator med = new Mediator();
			hTag.createMediatorSelect("DEP_ORG", r1_org, "", "請選擇", 0);
			ListItem li = new ListItem();
			li.Value = mng_id.SelectedValue;
			li.Text = med.lookupParamName("DEP_ORG", mng_id.SelectedValue, 0);
			r1_org.Items.Remove(li);
			#endregion
		}
		else if (chg_rsn.SelectedValue == IniValue.ChgRsnR5)
		{
			pnlR1.Visible = false;
			pnlR5.Visible = true;
		}
		else
		{
			pnlR1.Visible = false;
		}
	}


	private Boolean CheckAll()
	{
		DBDAO dao = new DBDAO();
		Boolean flag = true;
		ChangeModel model = new ChangeModel();
		CarModel carModel = new CarModel();
		CardModel cardModel = new CardModel();

		if (flag && car_id.SelectedValue == "")
		{
			flag = false;
			SysMsg.AlertMessage(this.Page, "請選擇車輛！");
		}

		try
		{

			dao.open();
			model.dao = dao;
			carModel.dao = dao;
			cardModel.dao = dao;

			Form form = new Form();
			form.setValue("car_id", car_id.SelectedValue);

			if (flag && chg_rsn.SelectedValue == IniValue.ChgRsnR1)
			{
				if (r1_org.SelectedValue == "")
				{
					flag = false;
					SysMsg.AlertMessage(this.Page, "請輸入移撥單位！");
				}
			}

			//移撥檢查加油卡號是否已存在
			if (flag && chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR1))
			{
				form.setValue("card_no", card_no.Text);
				form.setValue("keep_org", r1_org.SelectedValue);

				string sCardId = cardModel.IsCardNoExist(form);
				if (sCardId != string.Empty)
				{
					new_card.Value = sCardId;
				}
			}

			//變更車牌檢查加油卡號是否已存在
			if (flag && chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR5))
			{
				form.setValue("card_no", r5_license.Text.Trim());
				form.setValue("keep_org", mng_id.SelectedValue);

				string sCardId = cardModel.IsCardNoExist(form);
				if (sCardId != string.Empty)
				{
					new_card.Value = sCardId;
				}
			}


			//檢查異動日期不是中斷之前的紀錄

			//報廢前需先有報停
			if (flag && chg_rsn.SelectedValue == IniValue.ChgRsnR2)
			{
				DataSet ds = model.selectLastChg(form);

				if (ds.Tables[0].Rows.Count == 0)
					flag = false;
				else
				{
					DataRow dr = ds.Tables[0].Rows[0];

					if (!dr["chg_rsn"].ToString().Equals("R4"))
						flag = false;
				}

				if (!flag)
					SysMsg.AlertMessage(this.Page, "請先建立報停異動記錄！");
			}


			//檢查異動日期是否在保管期間範圍內
			if (flag && chg_date.Text != string.Empty)
			{
				DateTime keep_str = Convert.ToDateTime(keep_start.Value);
				DateTime chg_dt = Convert.ToDateTime(DateTransfer.c_date_trans(chg_date.Text));
				if (keep_str > chg_dt)
				{
					flag = false;
					SysMsg.AlertMessage(this.Page, "異動日期不在車輛所屬保管單位期間內！\n異動日小於保管日期(起)。");
				}

				if (flag && keep_end.Value != string.Empty)
				{
					DateTime keep_close = Convert.ToDateTime(DateTransfer.c_date_trans(keep_end.Value));
					if (keep_close < chg_dt)
					{
						flag = false;
						SysMsg.AlertMessage(this.Page, "異動日期不在車輛所屬保管單位期間內！\n異動日大於保管日期(迄)。");
					}
				}
			}


			//檢查車輛狀態變更時是否是最新的異動
			if (flag && chg_rsn.SelectedValue.Equals(IniValue.ChgRsnR4))
			{
				DataSet ds = carModel.selectCarLatestStatus(car_id.SelectedValue);

				if (ds.Tables[0].Rows.Count != 1)
				{
					flag = false;
					SysMsg.AlertMessage(this.Page, "車輛狀態異常！");
				}

				if (flag)
				{
					DataRow dr = ds.Tables[0].Rows[0];

					DateTime exec_start = Convert.ToDateTime(dr["exec_start"].ToString());
					DateTime chg_dt = Convert.ToDateTime(chg_date.Text);

					if (flag && DateTime.Compare(exec_start, chg_dt) <= 0)
					{
						flag = false;
						SysMsg.AlertMessage(this.Page, "異動日期必須大於" + dr["exec_start"].ToString());
					}
				}
			}
		}
		catch (Exception ex)
		{
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
			form.setValue("keep_org", mng_id.SelectedValue);

			ArrayList al_car = model.selectCarId(form);
			hTag.createSelect(al_car, car_id, "", "請選擇", 0);
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


	/// <summary>
	/// 取得選取車牌號碼的車輛資料
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void car_id_SelectedIndexChanged(object sender, EventArgs e)
	{
		UserID userID = (UserID)Session["UserID"];
		DBDAO dao = new DBDAO();
		Mediator med = new Mediator();
		ClearCarControl();
		try
		{
			dao.open();
			CarModel model = new CarModel();
			model.dao = dao;
			Form form = new Form();
			form.setValue("car_id", car_id.SelectedValue);
			form.setValue("keep_org", mng_id.SelectedValue);
			form.setValue("car_no", "");
			form.setValue("dep_no", "");
			form.setValue("dep_car", "");
			DataSet ds = model.selectCar(form);

			if (ds.Tables[0].Rows.Count == 1)
			{
				DataRow dr = ds.Tables[0].Rows[0];
				dep_no.Text = dr["dep_no"].ToString();
				car_type.Text = med.lookupParamName("CAR_TYPE", dr["car_type"].ToString(), 0);
				status.Text = med.lookupParamName("USE_STS", dr["status"].ToString(), 0);
				car_status.Value = dr["status"].ToString();
				card_no.Text = dr["card_no"].ToString();
				keep_start.Value = dr["keep_start"].ToString();
				keep_end.Value = dr["keep_end"].ToString();
				keep_id.Value = dr["keep_id"].ToString();
				possess_id.Value = dr["possess_id"].ToString();
				exec_id.Value = dr["exec_id"].ToString();
				card_id.Value = dr["card_id"].ToString();
				fuel_type.Value = dr["fuel_type"].ToString();
				btnSave.Visible = true;
			}
			else if (ds.Tables[0].Rows.Count == 0)
			{
				SysMsg.AlertMessage(this.Page, "查無符合的車輛資料，請重新輸入車號!");
				btnSave.Visible = false;
			}
			else
			{
				SysMsg.AlertMessage(this.Page, "查詢計有" + ds.Tables[0].Rows.Count.ToString() +
					"筆車輛資料，請輸入唯一值的車號!");

				btnSave.Visible = false;
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
}
