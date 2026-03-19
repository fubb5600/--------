using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油資料管理：新增頁
/// </summary>
public partial class TDTSb001_TDTSb001I2 : System.Web.UI.Page
{
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
                btnSave.Visible = userID.hasFunc("TDOSb001_insert");

                deal_HH.Attributes["onkeyup"] = "if(this.value.length==2)document.getElementById('MasterPage_ContentPlaceHolder1_deal_mm').focus();";

                HtmlTag hTag = new HtmlTag();
                hTag.createMediatorRadio("FUEL_TYPE", fuel_type, "GASOLINE", 0);
                //hTag.createMediatorSelect("DEP_ORG", mng_id, userID.getUserOrg(), "請選擇", 0);
                hTag.createMediatorSelect("CARD_TYPE", card_type, "", "請選擇", 0);
                hTag.createMediatorSelect("FUEL_NAME", fuel_name, "", "請選擇", 0);

                ListItem li = new ListItem();
                li.Value = userID.getUserOrg();
                li.Text = med.lookupParamName("DEP_ORG", userID.getUserOrg(), 0);
                string a = userID.getUserOrg();
                string[] a_result = a.Split(',');


                for (int j = 0; j < a_result.Length; j++)
                {
                    string b = "";
                    if (a_result[j] == "TT002I591")
                    {
                        b = "士林區清潔隊";


                    }

                    if (a_result[j] == "TT002I592")
                    {
                        b = "大同區清潔隊";


                    }

                    if (a_result[j] == "TT002I593")
                    {
                        b = "大安區清潔隊";


                    }
                    if (a_result[j] == "TT002I594")
                    {
                        b = "中山區清潔隊";


                    }
                    if (a_result[j] == "TT002I595")
                    {
                        b = "中正區清潔隊";


                    }
                    if (a_result[j] == "TT002I598")
                    {
                        b = "公廁管理隊";
                    }
                    if (a_result[j] == "TT002I599")
                    {
                        b = "北投區清潔隊";
                    }
                    if (a_result[j] == "TT002I600")
                    {
                        b = "環境檢驗中心";
                    }

                    if (a_result[j] == "TT002I596")
                    {
                        b = "內湖區清潔隊";

                    }
                    if (a_result[j] == "TT002I597")
                    {
                        b = "文山區清潔隊";
                    }



                    if (a_result[j] == "TT002I601")
                    {
                        b = "松山區清潔隊";


                    }
                    if (a_result[j] == "TT002I602")
                    {
                        b = "直屬清潔隊";


                    }
                    if (a_result[j] == "TT002I603")
                    {
                        b = "信義區清潔隊";
                    }
                    if (a_result[j] == "TT002I604")
                    {
                        b = "南港區清潔隊";
                    }

                    if (a_result[j] == "TT002I605")
                    {
                        b = "政風室";
                    }
                    if (a_result[j] == "TT002I606")
                    {
                        b = "修車廠";
                    }

                    if (a_result[j] == "TT002I607")
                    {
                        b = "秘書室";
                    }
                    if (a_result[j] == "TT002I608")
                    {
                        b = "廢棄物處理場";
                    }

                    if (a_result[j] == "TT002I609")
                    {
                        b = "清山淨水";
                    }
                    if (a_result[j] == "TT002I610")
                    {
                        b = "空污噪音防制科";
                    }
                    if (a_result[j] == "TT002I611")
                    {
                        b = "水質病媒管制科";
                    }
                    if (a_result[j] == "TT002I612")
                    {
                        b = "溝渠一隊";
                    }
                    if (a_result[j] == "TT002I613")
                    {
                        b = "溝渠二隊";
                    }
                    if (a_result[j] == "TT002I614")
                    {
                        b = "萬華區清潔隊";
                    }
                    if (a_result[j] == "TT002I615")
                    {
                        b = "資源回收隊";
                    }
                    if (a_result[j] == "TT002I617")
                    {
                        b = "職業安全管理科";
                    }
                    if (a_result[j] == "TT002I619")
                    {
                        b = "氣候變遷管理科";
                    }
                    if (a_result[j] == "TT002I620")
                    {
                        b = "綜合企劃科";
                    }
                    if (a_result[j] == "TT002I621")
                    {
                        b = "環境清潔管理科";
                    }

                    if (a_result[j] == "TT002I622")
                    {
                        b = "廢棄物處理管理科";
                    }

                    if (a_result[j] == "TT002I623")
                    {
                        b = "資源循環管理科";
                    }










                    mng_id.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                }
                mng_id.Items.Insert(0, new System.Web.UI.WebControls.ListItem("請選擇", ""));
                mng_id.SelectedValue = userID.getUserOrg1();
                if(userID.getUserRead()=="SELF")
                {
                    mng_id.Enabled = false;

                }

            genCardIdSelect();
                Card_Data1.mode = "show";
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
        Response.Redirect(Forward.Redirect("TDOSb001Q1.aspx", "", this));
    }


    /// <summary>
    /// 儲存前的檢核
    /// </summary>
    /// <returns></returns>
    private Boolean CheckAll()
    {
        Boolean flag = true;
        UserID userID = (UserID)Session["UserID"];
        TDOS tdos = new TDOS();

        //檢核交易日期是否已鎖定
        if (deal_date.Text != string.Empty)
        {
            flag = tdos.IsKeyDateLock(deal_date.Text, userID.getUserID(), "TDOSb001");
            if (flag == false)
            {
                SysMsg.AlertMessage(this.Page, "已鎖定的交易日期不可新增資料，請聯繫管理者！");
            }
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

        try
        {
            if (CheckAll())
            {
                dao.open();
                dao.beginTransaction();

                Form form = new Form();
                form.setValue("mng_id", mng_id.SelectedValue);
                form.setValue("card_no", card_id.SelectedItem.Text.Replace("(停用)", ""));
                form.setValue("deal_date", DateTransfer.c_date_trans(deal_date.Text.Trim()) + " " +
                       deal_HH.Text.Trim() + ":" + deal_mm.Text.Trim() + ":00");
                form.setValue("stand_name", stand_name.Text.Trim());
                form.setValue("fuel_type", fuel_type.SelectedValue);
                form.setValue("fuel_name", fuel_name.SelectedValue);
                form.setValue("fuel_count", fuel_count.Text.Trim());
                form.setValue("fuel_amount", fuel_amount.Text.Trim());
                form.setValue("report_ym", report_ym.Text.Trim());
                form.setValue("memo", memo.Text.Trim());
                form.setValue("adt_status", "0");
                form.setValue("create_user", userID.getUserID());

                CPCModel model = new CPCModel();
                model.dao = dao;
                Decimal fuel_id = model.insertOilMst(form);

                if (work_id != null)
                {
                    String[] work_data = HandleParam.getMultiValue(work_id).Split(',');
                    for (int i = 0; i < work_data.Length; i++)
                    {
                        Form form_use = new Form();
                        form_use.setValue("fuel_id", fuel_id.ToString());
                        form_use.setValue("data_source", "DEP");
                        form_use.setValue("create_user", userID.getUserID());
                        form_use.setValue("work_id", work_data[i]);

                        model.insertFuelUse(form_use);
                    }
                }

                dao.commit();
                SysMsg.AlertMessage(this.Page, "新增成功！");
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
    /// 保管單位連動車隊卡卡號
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void keep_org_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            CardModel model = new CardModel();
            model.dao = dao;
            //ArrayList al_card = model.selectCardNo(keep_org.SelectedValue, "");
            //hTag.createSelect(al_card, card_id, "", "請選擇", 0);
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
    /// 管理單位連動加油卡卡號下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        genCardIdSelect();
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
            try
            {
                if(deal_date.Text != string.Empty)
                 form.setValue("query_date", DateTransfer.c_date_trans(deal_date.Text.Trim()));
            }
            catch
            {            
            }
            
            form.setValue("action", "edit");
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
    /// 加油卡卡號連動相關資料顯示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void card_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        Card_Data1.getOilCardData(card_id.SelectedValue, car_no.Text, "");
        getWorkData();
    }


    /// <summary>
    /// 驗證年月格式
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void YMValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(args.Value + "/01"));
            args.IsValid = true;
        }
        catch
        {
            args.IsValid = false;
        }
    }


    /// <summary>
    /// 交易日期TextChanged事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void deal_date_TextChanged(object sender, EventArgs e)
    {
        if (card_id.SelectedValue == "")
            genCardIdSelect();

        getWorkData();
    }


    /// <summary>
    /// 取得勤務記錄
    /// </summary>
    private void getWorkData()
    {
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            if (deal_date.Text != string.Empty && card_id.SelectedValue != string.Empty)
            {
                CPCModel model = new CPCModel();
                model.dao = dao;
                Form form = new Form();
                DateTime target_date = Convert.ToDateTime(DateTransfer.c_date_trans(deal_date.Text));
                DateTime end_date = target_date.AddDays(60);
                form.setValue("fuel_id", "");
                form.setValue("data_source", "DEP");
                form.setValue("start_date", target_date.ToString("yyyy/MM/dd"));
                form.setValue("end_date", end_date.ToString("yyyy/MM/dd"));
                form.setValue("card_id", card_id.SelectedValue);
                ArrayList al = model.SelectFuelUse(form);
                hTag.createCheckBox(al, work_id, "", 0);
            }
        }
        catch (Exception ex)
        {
            SysMsg.AlertMessage(this.Page, ex.Message);
        }
        finally { dao.close(); }
    }


    /// <summary>
    /// 更新勤務記錄的圖示按鈕
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibWork_Click(object sender, ImageClickEventArgs e)
    {
        getWorkData();
    }
}