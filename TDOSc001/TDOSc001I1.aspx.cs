using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 車輛基本資料：新增頁
/// </summary>
public partial class TDTSc001_TDTSc001I1 : System.Web.UI.Page
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










                    keep_org.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                }

                keep_org.Items.Insert(0, new System.Web.UI.WebControls.ListItem("請選擇", ""));
                keep_org.SelectedValue = userID.getUserOrg1();
                if (userID.getUserRead() == "SELF")
                {
                    keep_org.Enabled = false;

                }

                //button權限
                btnSave.Visible = userID.hasFunc("TDOSc001_insert");
                pnlCRS.Visible = (btnSave.Visible && userID.getUserSys().Equals(IniValue.sysCRS));

                HtmlTag hTag = new HtmlTag();

                hTag.createMediatorSelect("CAR_TYPE", car_type, "", "請選擇", 0);
                hTag.createMediatorRadio("USE_STS", status, "O", 0);
                hTag.createMediatorRadio("FUEL_TYPE", fuel_type, "GASOLINE", 0);
                //2019/07/29
                report_year.Items.Insert(0, new ListItem("請選擇", ""));

                int year = int.Parse(DateTime.Now.ToString("yyyy")) - 1911;
                for (int i = 0; i <= 10; i++)
                {
                    report_year.Items.Add(new ListItem((year - i).ToString(), (year - i).ToString()));


                }
                

        
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

        try
        {
            if (CheckAll())
            {
                dao.open();
                dao.beginTransaction();

                Form form = new Form();
                form.setValue("dep_no", dep_no.Text.Trim());
                form.setValue("car_no", car_no.Text.ToUpper().Trim());
                form.setValue("car_type", car_type.SelectedValue);
                //form.setValue("car_year", car_year.Text.Trim());
                //2019.07.29
                //form.setValue("car_year", (int.Parse(report_y.Value.Trim() + 1911).ToString()));
                form.setValue("car_year", ((int.Parse(report_year.SelectedValue) + 1911).ToString()));

                form.setValue("buy_date", DateTransfer.c_date_trans(buy_date.Text.Trim()));
                form.setValue("exec_start", form.getValue("buy_date"));
                form.setValue("brand_no", brand_no.Text.Trim());
                form.setValue("engine_no", engine_no.Text.Trim());
                form.setValue("tonnage", tonnage.Text.Trim());
                form.setValue("displacement", displacement.Text.Trim());
                form.setValue("status", status.SelectedValue);
                form.setValue("fuel_std", fuel_std.Text.Trim());
                form.setValue("fuel_type", fuel_type.SelectedValue);
                form.setValue("memo", memo.Text.Trim());
                form.setValue("create_user", userID.getUserID());
                //form.setValue("card_id", card_id.SelectedValue);
                form.setValue("possess_start", form.getValue("buy_date"));
                form.setValue("keep_org", keep_org.SelectedValue);
                form.setValue("add_device", add_device.Text);
                form.setValue("check_date", check_date.Text != string.Empty ? DateTransfer.c_date_trans(check_date.Text.Trim()) : "");
                form.setValue("user_sys", userID.getUserSys());
                form.setValue("next_inspection", next_inspection.Text != string.Empty ? DateTransfer.c_date_trans(next_inspection.Text.Trim()) : ""); //下次定檢日
                form.setValue("licensing_date", licensing_date.Text != string.Empty ? DateTransfer.c_date_trans(licensing_date.Text.Trim()) : ""); //發照日期
                form.setValue("card_no", form.getValue("car_no"));
                form.setValue("card_type", "1");
                form.setValue("keep_man", "");
                form.setValue("action", "");
                form.setValue("car", CAR.SelectedValue);

                //新增車輛
                CarModel model = new CarModel();
                model.dao = dao;
                form.setValue("car_id", model.insertCar(form).ToString());

                //新增車輛狀態資料
                model.insertCarStatus(form);

                //新增保管記錄
                model.insertCarkeep(form);

                //車隊卡
                CardModel cardModel = new CardModel();
                cardModel.dao = dao;
                string sCardId = cardModel.IsCardNoExist(form);

                if (sCardId != string.Empty)
                {
                    form.setValue("card_id", sCardId);
                }
                else
                    form.setValue("card_id", cardModel.insertCard(form).ToString());      

                //新增車輛對應車隊卡記錄
                model.insertCarCard(form);

                dao.commit();
                //SysMsg.AlertMessage(this.Page, "新增成功！");
                Response.Write("<script>alert('新增成功！'); location.href='" + Forward.Redirect("TDOSc001U1.aspx",
                    "car_id=" + form.getValue("car_id"), this) + "'; </script>");
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
    //        ArrayList al_card = model.selectCardNo(keep_org.SelectedValue, "");
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
            DateTime dt = Convert.ToDateTime(args.Value+"/01/01");
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
            if (flag && car_no.Text !=string.Empty)
            {
                Form form = new Form();
                form.setValue("car_no", car_no.Text);
                form.setValue("action", "Insert");
                form.setValue("car_id", "");
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
        }
        catch { }
        finally { dao.close(); }

        return flag;
    }
}