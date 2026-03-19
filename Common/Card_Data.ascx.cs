using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Common_Card_Data : System.Web.UI.UserControl
{
    public String cardID = string.Empty;
    public String carNO = string.Empty;
    public String mode = string.Empty;
    public String queryDate = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();

        if (!IsPostBack)
        {
            if (mode == "edit")
            {
                mng_id.Enabled = true;
                card_type.Enabled = true;
                card_id.Enabled = true;
                pnlEdit.Visible = true;
                pnlShow.Visible = false;
            }
            else
            {
                mng_id.Enabled = false;
                card_type.Enabled = false;
                card_id.Enabled = false;
                pnlEdit.Visible = false;
                pnlShow.Visible = true;
            }

            #region 管理單位下拉選單
            if (userID.getUserRead() == "ALL")
            {
                hTag.createMediatorSelect("DEP_ORG", mng_id, "", "請選擇", 0);
            }
            else
            {
                ListItem li = new ListItem();
                li.Value = userID.getUserOrg();
                li.Text = med.lookupParamName("DEP_ORG", userID.getUserOrg(), 0);
                mng_id.Items.Add(li);
                mng_id.SelectedValue = userID.getUserOrg();
            }
            #endregion

            hTag.createMediatorSelect("CARD_TYPE", card_type, "", "請選擇", 0);

            if (cardID != string.Empty)
            {
                if (queryDate == null)
                    queryDate = "";
                
                getOilCardData(cardID, carNO, queryDate);
            }
            //else
            //{
            //    pnlCar.Visible = false;
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
        genCardIdSelect();
    }


    protected void card_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (card_id.SelectedValue != string.Empty)
        //getOilCardData(card_id.SelectedValue);
    }


    /// <summary>
    /// 取得加油卡明細資料
    /// </summary>
    /// <param name="strCardID"></param>
    public void getOilCardData(String strCardID, String strCarNO, String strQueryDate)
    {
        DBDAO dao = new DBDAO();
        String errorMsg = "";
        try
        {
            dao.open();
            CardModel model = new CardModel();
            Mediator med = new Mediator();
            model.dao = dao;
            DataSet ds = model.selectCardWithCar(strCardID, strQueryDate);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                card_status.Text = med.lookupParamName("USE_STS", dr["card_status"].ToString(), 0);

                lblCardNo.Text = dr["card_no"].ToString();
                lblCardOrg.Text = med.lookupParamName("DEP_ORG", dr["keep_org"].ToString(), 0);
                lblCardType.Text = med.lookupParamName("CARD_TYPE", dr["card_type"].ToString(), 0);
                lblCardStatus.Text = med.lookupParamName("USE_STS", dr["card_status"].ToString(), 0);
               
                if (strCarNO == string.Empty && dr["card_type"].ToString() == "1")
                {
                    pnlCar.Visible = true;
                    DataRow dr_car = ds.Tables[0].Rows[0];
                    dep_no.Text = dr_car["dep_no"].ToString();
                    car_no.Text = dr_car["car_no"].ToString();
                    car_type.Text = med.lookupParamName("CAR_TYPE", dr_car["car_type"].ToString(), 0);
                    car_status.Text = med.lookupParamName("USE_STS", dr_car["car_status"].ToString(), 0);
                    fuel_type.Text = med.lookupParamName("FUEL_TYPE", dr_car["fuel_type"].ToString(), 0);
                    fuel_std.Text = dr_car["fuel_std"].ToString();

                    if (dr_car["dep_no"].ToString().Length == 0)
                        errorMsg = "加油卡號對應車輛資料有誤！";
                }
                else if (strCarNO != string.Empty && dr["card_type"].ToString() != "1")
                {
                    pnlCar.Visible = false;
                    CarModel car_model = new CarModel();
                    car_model.dao = dao;
                    Form car_form = new Form();
                    car_form.setValue("car_no", strCarNO);
                    car_form.setValue("user_read", "ALL");                   
                    DataSet ds_car = car_model.selectCarDatabyCarNo(car_form);
                    if (ds_car.Tables[0].Rows.Count == 1)
                    {
                        DataRow dr_car = ds_car.Tables[0].Rows[0];
                        dep_no.Text = dr_car["dep_no"].ToString();
                        car_no.Text = dr_car["car_no"].ToString();
                        car_type.Text = med.lookupParamName("CAR_TYPE", dr_car["car_type"].ToString(), 0);
                        car_status.Text = med.lookupParamName("USE_STS", dr_car["car_status"].ToString(), 0);
                        fuel_type.Text = med.lookupParamName("FUEL_TYPE", dr_car["fuel_type"].ToString(), 0);
                        fuel_std.Text = dr_car["fuel_std"].ToString();
                    }
                }
                else
                {
                    pnlCar.Visible = false;
                }               

                mng_id.SelectedValue = dr["keep_org"].ToString();
                card_type.SelectedValue = dr["card_type"].ToString();
                card_id.SelectedValue = dr["card_id"].ToString();

            }
            else
            {
                ClearControl();
                pnlCar.Visible = false;
            }

            if(errorMsg.Length>0)
                SysMsg.AlertMessage(this.Page, errorMsg);
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
    /// 加油卡卡別連動加油卡卡號下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void card_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect();
    }


    /// <summary>
    /// 產生加油卡卡號的下拉選單
    /// </summary>
    private void genCardIdSelect()
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
            ArrayList al_card = model.selectCardNo(form);
            hTag.createSelect(al_card, card_id, "", "請選擇", 0);
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
    /// 清除控制項內容
    /// </summary>
    private void ClearControl()
    {
        card_status.Text = string.Empty;
        lblCardNo.Text = string.Empty;
        lblCardOrg.Text = string.Empty;
        lblCardType.Text = string.Empty;
        lblCardStatus.Text = string.Empty;
        dep_no.Text = string.Empty;
        car_no.Text = string.Empty;
        car_type.Text = string.Empty;
        car_status.Text = string.Empty;
        fuel_type.Text = string.Empty;
        fuel_std.Text = string.Empty;
        pnlCar.Visible = false;
    }
}