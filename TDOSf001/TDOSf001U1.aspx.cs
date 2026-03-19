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
/// 車輛報修作業：修改頁
/// </summary>
public partial class TDOSf001_TDOSf001U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();

        foreach (ListItem item in key_type.Items)
        {
            item.Attributes["onclick"] = "getKeyType();";
        }

        try
        {   
            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDOSf001_update");
                btnDelete.Visible = userID.hasFunc("TDOSf001_delete");
                btnPrint.Visible = userID.hasFunc("TDOSf001_print");

                Form form = new Form();
                form.setValue("notify_id", Request["notify_id"]);
                form.setValue("create_user", userID.getUserID());               

                NotifyModel model = new NotifyModel();
                model.dao = dao;
                dao.open();
                HtmlTag hTag = new HtmlTag();
                DataSet ds = model.selectNotify(form.getValue("notify_id"));
                DataRow dr = ds.Tables[0].Rows[0];

                ArrayList al_driver = model.selectDriver(form);
                ArrayList al_workman = model.selectWorkMan(form);

                hfKeepOrg.Value = dr["crs_org"].ToString();
                work_no.Text = dr["work_no"].ToString();
                work_man.Text = dr["work_man"].ToString();
                mileage.Text = dr["mileage"].ToString();
                repair_vender.Text = dr["repair_vender"].ToString();
                driver.Text = dr["driver"].ToString();
            

                if (dr["notify_date"].ToString() != string.Empty)
                {
                    notify_date.Text = dr["notify_date"].ToString().Substring(0, 9);
                    if (!dr["notify_date"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        notify_HH.Text = dr["notify_date"].ToString().Substring(10, 2);
                        notify_mm.Text = dr["notify_date"].ToString().Substring(13, 2);
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

                if (dr["pickup_date"].ToString() != string.Empty)
                {
                    pickup_date.Text = dr["pickup_date"].ToString().Substring(0, 9);
                    if (!dr["pickup_date"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        pickup_HH.Text = dr["pickup_date"].ToString().Substring(10, 2);
                        pickup_mm.Text = dr["pickup_date"].ToString().Substring(13, 2);
                    }
                }

                memo.Text = dr["memo"].ToString();
                //108/06/14
              
                    repair_type4.SelectedValue = dr["repair_type3"].ToString();
                    repair_type5.SelectedValue = dr["repair_type1"].ToString();                 
  
                 
                      

                    string a = dr["repair_type2"].ToString();
                    string[] a_result = a.Split(',');

                   
                    for (int j = 0; j < a_result.Length; j++)
                    {

                        if (a_result[j] == "BOTHMR")


                        {
                        CheckBoxList1.Items[0].Selected = true;
                        CheckBoxList1.Items[2].Selected = true;

                    }
                    if (a_result[j] == "MAINTENANCE")
                        {
                            CheckBoxList1.Items[0].Selected = true;                          
                        }
                        if (a_result[j] == "MATERIAL")
                        {
                            CheckBoxList1.Items[1].Selected = true;                        
                        }
                        if (a_result[j] == "REPAIR")
                        {
                            CheckBoxList1.Items[2].Selected = true;                          
                        }
                        if (a_result[j] == "TUNE")
                        {
                            CheckBoxList1.Items[3].Selected = true;                         
                        }
                }
                string c = userID.getUserOrg();
                string[] b_result = c.Split(',');

                for (int j = 0; j < b_result.Length; j++)
                {
                    string b = "";
                    if (b_result[j] == "TT002I591")
                    {
                        b = "士林區清潔隊";


                    }

                    if (b_result[j] == "TT002I592")
                    {
                        b = "大同區清潔隊";


                    }

                    if (b_result[j] == "TT002I593")
                    {
                        b = "大安區清潔隊";


                    }
                    if (b_result[j] == "TT002I594")
                    {
                        b = "中山區清潔隊";


                    }
                    if (b_result[j] == "TT002I595")
                    {
                        b = "中正區清潔隊";


                    }
                    if (b_result[j] == "TT002I598")
                    {
                        b = "公廁管理隊";
                    }
                    if (b_result[j] == "TT002I599")
                    {
                        b = "北投區清潔隊";
                    }
                    if (b_result[j] == "TT002I600")
                    {
                        b = "環境檢驗中心";
                    }

                    if (b_result[j] == "TT002I596")
                    {
                        b = "內湖區清潔隊";

                    }
                    if (b_result[j] == "TT002I597")
                    {
                        b = "文山區清潔隊";
                    }



                    if (b_result[j] == "TT002I601")
                    {
                        b = "松山區清潔隊";


                    }
                    if (b_result[j] == "TT002I602")
                    {
                        b = "直屬清潔隊";


                    }
                    if (b_result[j] == "TT002I603")
                    {
                        b = "信義區清潔隊";
                    }
                    if (b_result[j] == "TT002I604")
                    {
                        b = "南港區清潔隊";
                    }

                    if (b_result[j] == "TT002I605")
                    {
                        b = "政風室";
                    }
                    if (b_result[j] == "TT002I606")
                    {
                        b = "修車廠";
                    }

                    if (b_result[j] == "TT002I607")
                    {
                        b = "秘書室";
                    }
                    if (b_result[j] == "TT002I608")
                    {
                        b = "廢棄物處理場";
                    }

                    if (b_result[j] == "TT002I609")
                    {
                        b = "清山淨水";
                    }
                    if (b_result[j] == "TT002I610")
                    {
                        b = "空污噪音防制科";
                    }
                    if (b_result[j] == "TT002I611")
                    {
                        b = "水質病媒管制科";
                    }
                    if (b_result[j] == "TT002I612")
                    {
                        b = "溝渠一隊";
                    }
                    if (b_result[j] == "TT002I613")
                    {
                        b = "溝渠二隊";
                    }
                    if (b_result[j] == "TT002I614")
                    {
                        b = "萬華區清潔隊";
                    }
                    if (b_result[j] == "TT002I615")
                    {
                        b = "資源回收隊";
                    }
                    if (b_result[j] == "TT002I617")
                    {
                        b = "職業安全管理科";
                    }
                    if (b_result[j] == "TT002I619")
                    {
                        b = "氣候變遷管理科";
                    }
                    if (b_result[j] == "TT002I620")
                    {
                        b = "綜合企劃科";
                    }
                    if (b_result[j] == "TT002I621")
                    {
                        b = "環境清潔管理科";
                    }

                    if (b_result[j] == "TT002I622")
                    {
                        b = "廢棄物處理管理科";
                    }

                    if (b_result[j] == "TT002I623")
                    {
                        b = "資源循環管理科";
                    }










                    mng_id.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, b_result[j]));


                }
                mng_id.SelectedValue = userID.getUserOrg1();
                if (userID.getUserRead() == "SELF")
                {
                    mng_id.Enabled = false;

                }

                mng_id.Items.Insert(0, new System.Web.UI.WebControls.ListItem("請選擇", ""));






              

                hTag.createMediatorRadio("REPAIR_STS", repair_status, dr["repair_status"].ToString(), 0);
                hTag.createSelect(al_driver, ddlDriver, dr["driver"].ToString(), "請選擇", 0);
                hTag.createSelect(al_workman, ddlWorkMan, dr["work_man"].ToString(), "請選擇", 0);
              
                hTag.createMediatorSelect("MACHINE", machine_type, dr["machine_type"].ToString(), "請選擇", 0);
                hTag.createMediatorSelect("DEP_ORG", machine_org, dr["machine_org"].ToString(), "請選擇", 0);
                hTag.createMediatorSelect("MACHINE_NO", machine_no, med.lookupParamId("MACHINE_NO", dr["machine_no"].ToString()), "請選擇", 0);
                hTag.createMediatorRadio("WORK_TYPE", notify_type, dr["notify_type"].ToString(), 0);

                genCarList();
                car_id.SelectedValue = dr["car_id"].ToString();
                car_id_SelectedIndexChanged(sender, e);
                key_type.SelectedValue = "D";
                car_type.Text = dr["cartype_name"].ToString();
                notify_id.Value = dr["notify_id"].ToString();
                notify_item.Value = dr["notify_item"].ToString();

                ddlDriver_SelectedIndexChanged(sender, e);
                ddlWorkMan_SelectedIndexChanged(sender, e);
                notify_type_SelectedIndexChanged(sender, e);
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
    /// 管理單位連動車牌號碼下拉選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        hfKeepOrg.Value = mng_id.SelectedValue;
        genCarList();
        work_no.Text = getWorkNo();
    }


    /// <summary>
    /// 產生車牌號碼下拉選單
    /// </summary>
    private void genCarList()
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
            //修正查無ATB-9067、 AAB - 313車輛_wenny1061127
            ArrayList al_car = model.selectCarId(form);
            //ArrayList al_car = model.selectCRSCarId(form);
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
    /// 清除車輛資料
    /// </summary>
    private void ClearCarControl()
    {
        dep_no.Text = string.Empty;
        car_type.Text = string.Empty;
        brand_no.Text = string.Empty;
        car_year_tonnage.Text = string.Empty;
    }


    /// <summary>
    /// 依車牌號碼取出車輛資料
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCar_Click(object sender, EventArgs e)
    {
        ClearCarControl();
        car_id.SelectedValue = "";

        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();
            CarModel model = new CarModel();
            model.dao = dao;

            Form form = new Form();
            form.setValue("dep_car", car_no.Text);

            if (userID.getUserRead().Equals("SELF"))
            {
                form.setValue("keep_org", userID.getUserOrg());
            }
            else
                form.setValue("keep_org", "");

            DataSet ds = model.selectCarIdbyNo(form);
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                form.setValue("car_no", "");
                form.setValue("dep_no", "");
                form.setValue("car_id", dr["car_id"].ToString());
                getCarData(form);
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
    /// 取得選取車牌號碼的車輛資料
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void car_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearCarControl();
        Form form = new Form();
        form.setValue("car_id", car_id.SelectedValue);
        form.setValue("keep_org", mng_id.SelectedValue);
        form.setValue("car_no", "");
        form.setValue("dep_no", "");
        form.setValue("dep_car", "");
        getCarData(form);
    }

    /// <summary>
    /// 取得車輛基本資料
    /// </summary>
    /// <param name="form"></param>
    private void getCarData(Form form)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();

        try
        {
            dao.open();
            CarModel model = new CarModel();
            model.dao = dao;

            DataSet ds = model.selectCar(form);
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                car_no.Text = dr["car_no"].ToString();
                dep_no.Text = dr["dep_no"].ToString();
                car_type.Text = med.lookupParamName("CAR_TYPE", dr["car_type"].ToString(), 0);
                brand_no.Text = dr["brand_no"].ToString();
                car_year_tonnage.Text = dr["car_year"].ToString() + "(西元年) / " + dr["tonnage"].ToString() + "(噸)";
                car_id.SelectedValue = dr["car_id"].ToString();
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
    /// 維修方式連動下拉式選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void repair_type1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    HtmlTag hTag = new HtmlTag();
    //    if (repair_type1.SelectedValue != string.Empty)
    //    {
    //        string sRepairSubType = "REPAIR_TYPE_" + repair_type1.SelectedValue;
    //        hTag.createMediatorSelect(sRepairSubType, repair_type2, "", "請選擇", 0);
    //    }
    //    else
    //    {
    //        repair_type2.Items.Clear();
    //        ListItem li = new ListItem("請選擇", "");
    //        repair_type2.Items.Add(li);
    //    }

    //    repair_type2_SelectedIndexChanged(sender, e);
    //}


    //protected void repair_type2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (repair_type1.SelectedValue == "OUT" || repair_type2.SelectedValue == "REPAIR" || repair_type2.SelectedValue == "MAINTENANCE")
    //    {
    //        repair_type3.Visible = true;
    //        repair_type3.SelectedIndex = 0;
    //    }
    //    else
    //    {
    //        repair_type3.Visible = false;
    //    }
    //}


    /// <summary>
    /// 返回按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Forward.Redirect("TDOSf001Q1.aspx", "", this));
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
        NotifyModel model = new NotifyModel();
        try
        {


            if (!CheckAll())
                return;

            dao.open();
            dao.beginTransaction();

            Form form = new Form();
           

            if (notify_type.SelectedValue.Equals("C"))
            {
                form.setValue("car_id", car_id.SelectedValue);

                form.setValue("machine_type", "");
                form.setValue("machine_org", "");
                form.setValue("machine_no", "");
            }
          



            else
            {
                form.setValue("car_id", "");                
                form.setValue("machine_type", machine_type.SelectedValue);
                form.setValue("machine_org", machine_org.SelectedValue);
                form.setValue("machine_no", genMachineNo());

                if (form.getValue("machine_no").Equals(""))
                {
                    SysMsg.AlertMessage(this.Page, "儲存失敗！");
                    return;
                }
            }

            form.setValue("crs_org", hfKeepOrg.Value);
            form.setValue("notify_id", notify_id.Value);
            form.setValue("notify_type", notify_type.SelectedValue);
            form.setValue("work_no", work_no.Text);
            form.setValue("notify_date", TDOS.formatDateTimeForm(notify_date.Text, notify_HH.Text, notify_mm.Text));
            form.setValue("work_man", work_man.Text.Trim());
            form.setValue("mileage", mileage.Text.Trim()); 
            form.setValue("notify_item", notify_item.Value.Substring(0, notify_item.Value.Length - 1));


            form.setValue("repair_vender", repair_vender.Text.Trim());

            string str = "";

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {

                    str += CheckBoxList1.Items[i].Value.Trim() + ",";



                }

            }
            //108/06/14
          
                form.setValue("repair_type3", repair_type4.SelectedValue);
                form.setValue("repair_type2", str);
                form.setValue("repair_type1", repair_type5.SelectedValue);

            



            form.setValue("repair_status", repair_status.SelectedValue);
            form.setValue("finish_date", TDOS.formatDateTimeForm(finish_date.Text, finish_HH.Text, finish_mm.Text));
            form.setValue("driver", driver.Text.Trim());
            form.setValue("pickup_date", TDOS.formatDateTimeForm(pickup_date.Text, pickup_HH.Text, pickup_mm.Text));
            form.setValue("memo", memo.Text.Trim());
            form.setValue("update_user", userID.getUserID());

            model.dao = dao;
            model.updateNotify(form);
            dao.commit();
          
            SysMsg.AlertMessage(this.Page, "儲存成功！");
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
            NotifyModel model = new NotifyModel();
            model.dao = dao;

            model.deleteNotify(notify_id.Value);
            dao.commit();
            
            Response.Write("<script>alert('刪除成功!'); location.href='" + Forward.Redirect("TDOSf001Q1.aspx", "", this) + "'; </script>");
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
    /// 驗證報修內容
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void NotifyItemValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            if (notify_item.Value != string.Empty)
                args.IsValid = true;
        }
        catch
        {
            args.IsValid = false;
        }
    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("TDOSf001P1.ashx?notify_id=" + notify_id.Value);
    }


    private string getWorkNo()
    {
        string sRetValue = "";

        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        TDOS tdos = new TDOS();
        try
        {
            dao.open();
            NotifyModel model = new NotifyModel();
            model.dao = dao;
            sRetValue = model.getWorkNo(tdos.getSimpleDepNo(hfKeepOrg.Value));
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


    /// <summary>
    /// 選擇駕駛後帶入值到文字框
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlDriver_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDriver.SelectedValue != string.Empty)
        {
            driver.Text = ddlDriver.SelectedValue;
            driver.Visible = false;
        }
        else
        {
            driver.Text = string.Empty;
            driver.Visible = true;
        }
    }


    /// <summary>
    /// 選擇派工人員駕駛後帶入值到文字框
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlWorkMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWorkMan.SelectedValue != string.Empty)
        {
            work_man.Text = ddlWorkMan.SelectedValue;
            work_man.Visible = false;
        }
        else
        {
            work_man.Text = string.Empty;
            work_man.Visible = true;
        }
    }

    /// <summary>
    /// 機具所屬單位
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void machine_org_SelectedIndexChanged(object sender, EventArgs e)
    {
       hfKeepOrg.Value = machine_no.SelectedValue;
       work_no.Text = getWorkNo();
    }


    /// <summary>
    /// 報修類型notify_type_SelectedIndexChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void notify_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (notify_type.SelectedValue.Equals("C"))
        {
            pnlCar.Visible = true;
            pnlMachine.Visible = false;
            unit.Text = "公里";
        }
        else
        {
            pnlCar.Visible = false;
            pnlMachine.Visible = true;
            unit.Text = "小時";
        }
    }

    private String genMachineNo()
    {
        String sMchineNo = machine_no.SelectedItem.Text;
        Boolean isIncluding = false;
        UserID userID = (UserID)Session["UserID"];
        String sNewParamId = "1";
        HtmlTag hTag = new HtmlTag();

        if (machine_no.Items.Count > 1)
        {
            for (int i = 0; i < machine_no.Items.Count; i++)
            {
                if (i > 0)
                {
                    ListItem item = machine_no.Items[i];
                    if (item.Text.Equals(machine_no_ins.Text.ToUpper()))
                    {
                        isIncluding = true;

                    }
                    sNewParamId = (Int32.Parse(item.Value) + 1).ToString();
                }
            }
        }

        //不存在才新增
        if (!isIncluding)
        {
            DBDAO dao = new DBDAO();

            try
            {
                ParamModel model = new ParamModel();
                model.dao = dao;

                dao.open();

                Form form = new Form();
                form.setValue("param_type", "MACHINE_NO");
                form.setValue("param_id", sNewParamId);
                form.setValue("id_name", machine_no_ins.Text.ToUpper());
                form.setValue("status", "O");
                form.setValue("id_order_by", sNewParamId);
                form.setValue("memo", "");
                form.setValue("create_user", userID.getUserID());
                form.setValue("update_user", userID.getUserID());

                if (model.IsUnique(form.getValue("param_type"), form.getValue("param_id")))
                {
                    model.insertSYSParam(form);
                    SYSLOG.setLog(Request, Session, "新增", dao.getSQL());
                    sMchineNo = machine_no_ins.Text.ToUpper();
                    Mediator med = Mediator.getInstance(true);
                    hTag.createMediatorSelect("MACHINE_NO", machine_no, med.lookupParamId("MACHINE_NO", sMchineNo), "請選擇", 0);
                    machine_no_ins.Text = "";
                }
                else
                {
                    SysMsg.AlertMessage(this.Page, "機具局編號屬性新增失敗。");
                }
            }
            catch (Exception ex)
            {
                dao.rollback();
            }
            finally
            {
                dao.close();
            }

        }

        return sMchineNo;
    }

    private Boolean CheckAll()
    {
        Boolean flag = true;

        //if (flag && notify_item.Value == string.Empty)
        //{
        //    SysMsg.AlertMessage(this.Page, "報修內容不可為空！");
        //    flag = false;
        //}

        if (flag && notify_type.SelectedValue.Equals("C"))
        {
            if (car_id.SelectedValue.Equals(""))
            {
                SysMsg.AlertMessage(this.Page, "請選擇/輸入車牌號碼！");
                flag = false;
            }
        }

        if (flag && notify_type.SelectedValue.Equals("C"))
        {
            if (mileage.Text.Equals("") || Int32.Parse(mileage.Text) == 0)
            {
                SysMsg.AlertMessage(this.Page, "請輸入里程數！");
                flag = false;
            }
        }


        if (flag && notify_type.SelectedValue.Equals("M"))
        {
            if (machine_type.SelectedValue.Equals(""))
            {
                SysMsg.AlertMessage(this.Page, "請選擇機具類型！");
                flag = false;
            }
        }

        if (flag && notify_type.SelectedValue.Equals("M"))
        {
            if (machine_org.SelectedValue.Equals(""))
            {
                SysMsg.AlertMessage(this.Page, "請選擇機具所屬單位！");
                flag = false;
            }
        }

        if (flag && notify_type.SelectedValue.Equals("M"))
        {
            if (machine_no.SelectedValue.Equals("") && machine_no_ins.Text.Equals(""))
            {
                SysMsg.AlertMessage(this.Page, "請選擇/輸入機具局編號！");
                flag = false;
            }
        }


        //檢核報修內容重複
        if (flag)
        {
            string[] notify_items = notify_item.Value.Split('|');


        }

        return flag;
    }

}