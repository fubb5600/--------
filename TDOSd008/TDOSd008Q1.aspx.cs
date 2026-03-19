using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// 委外託修作業：查詢頁
/// 
/// 
/// </summary>
public partial class TDOSd008_TDOSd008Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        

        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();
        Mediator med = new Mediator();
        #region     //wenny_test_報修五日填資料
        //if (!IsPostBack)

        //{ //wenny_test_報修五日填資料
        //    string str = "下列派工單編號委外託修作業相關資料尚未建置完整\\n";
        //    //for (int i = 0; i < 100; i++)
        //    //{
        //    //    str = str + 'a'+"\\n";
        //    //}

        //    SysMsg.AlertMessage(this.Page, str);
        //}
        #endregion
        if (IsPostBack)
        {
            var ctlName = this.Request.Params["__EVENTTARGET"];
           


        }
        else
        {

        }
        try
        {

            dao.open();
            String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
            if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
            {
                if (!IsPostBack)
                {
                    //button權限


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










                        User.Items.Insert(j, new System.Web.UI.WebControls.ListItem(b, a_result[j]));


                    }

                    User.Items.Insert(0, new System.Web.UI.WebControls.ListItem("請選擇", ""));

                    User.SelectedValue = userID.getUserOrg1();
                    if (userID.getUserRead() == "SELF")
                    {
                        User.Enabled = false;

                    }






                }

                RepairModel model = new RepairModel();
                model.dao = dao;







                //分頁設定
                //查詢資料
                Form form = new Form();
                PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
                pb.setDBDAO(dao);
                //wenny_test_排序
                if (string.IsNullOrEmpty(sortedfield.Value))
                {
                    sortedfield.Value = Session["field"].ToString();//查詢排序編輯後返回頁面
                }
                DataSet ds = pb.doSearch(model, "browse2");
                //wenny_test_排序
                //DataSet ds = pb.doSearch(model, "browse1");

                if (pb.isDoSearch())
                {
                    //還原查詢條件
                    form = pb.getFormData();
                    gvMain.DataSource = ds;
                    gvMain.DataBind();
                    pnlPrint.Visible = userID.hasFunc("TDOSf002_print") && (ds.Tables[0].Rows.Count > 0);
                }
                else
                    pnlPrint.Visible = false;

                String typeValue = "";
                String carnoValue = "";
                String depnoValue = "";
                String venderValue = "";
                String worknoValue = "";
                String casenoValue = "";
                String orgValue = "";
                //2018/08/31測試查驗結果Checkbox
                String resultValue0 = "";
                String resultValue1 = "";
                String resultValue2 = "";
                //2018/08/31測試查驗結果Checkbox
                String repair1Value = "";
                String repair2Value = "";
                String repair3Value = "";
                String notifyStartValue = "";
                String notifyEndValue = "";
                String finishStartValue = "";
                String finishEndValue = "";

                //有預設值，若有查詢過，則以新條件為準
                if (pb.isDoSearch())
                {
                    typeValue = form.getValue("notify_type");
                    carnoValue = form.getValue("car_no");
                    depnoValue = form.getValue("dep_no");
                    venderValue = form.getValue("repair_vender");
                    worknoValue = form.getValue("work_no");
                    casenoValue = form.getValue("case_no");
                    //2018/08/31測試查驗結果Checkbox
                    //  resultValue = form.getValue(resultValue);//2018/08/31測試查驗結果Checkbox before
                    resultValue0 = form.getValue("resultValue0");
                    resultValue1 = form.getValue("resultValue1");
                    resultValue2 = form.getValue("resultValue2");
                    //2018/08/31測試查驗結果Checkbox
                    repair1Value = form.getValue("repair_type1");
                    repair2Value = form.getValue("repair_type2");
                    repair3Value = form.getValue("repair_type3");
                    notifyStartValue = form.getValue("notify_start");
                    notifyEndValue = form.getValue("notify_end");
                    finishStartValue = form.getValue("finish_start");
                    finishEndValue = form.getValue("finish_end");
                }

             



                //User.DataSource = dt;
                //User.DataTextField = "Nickname";
                //User.DataValueField = "Nickname";
                //User.DataBind();

             



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
    protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
 

    /// <summary>
    /// GridView1_RowDataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private Form genFilterForm()
    {

        Form form = new Form();
      
        form.setValue("role_id", Session["role_id"].ToString());
        form.setValue("car_no", car_no.Text.Trim());
        //2018/08/31測試查驗結果Checkbox
        //form.setValue("check_result", HandleParam.getMultiValue(check_result)); //2018/08/31測試查驗結果Checkbox before


        //2018/08/31測試查驗結果Checkbox
       
       
        form.setValue("update_user", Session["User"].ToString());


        //form.setValue("exec_deadline_start", exec_deadline_start.Text.Trim());
        //form.setValue("exec_deadline_end", exec_deadline_end.Text.Trim());
        //form.setValue("check_date_start", check_date_start.Text.Trim());
        //form.setValue("check_date_end", check_date_end.Text.Trim());
        //form.setValue("qualified_date_start", qualified_date_start.Text.Trim());
        //form.setValue("qualified_date_end", qualified_date_end.Text.Trim());
        //form.setValue("delivery_date_start", delivery_date_start.Text.Trim());
        //form.setValue("delivery_date_send", delivery_date_end.Text.Trim());

        return form;
    }

    /// <summary>
    /// 查詢按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {




            dao.open();

            Form form = new Form();
            form.setValue("car_no", car_no.Text.Trim());

            form.setValue("work_no", work_no.Text.Trim());
   
         
            if (User.SelectedValue == "")
            {
                form.setValue("User", userID.getUserOrg() );

            }
            else
            {
                form.setValue("User", HandleParam.getMultiValue(User));


            }

            form.setValue("Thing", Thing1.Text.Trim());
            form.setValue("Status", NeworOld.SelectedValue);
            form.setValue("No", No.Text.Trim());
            form.setValue("Use_Car", Use_Car.Text.Trim());
            form.setValue("Use_No", Use_No.Text.Trim());
            form.setValue("Update_Time_start", Update_Time_start.Text.Trim());
            form.setValue("Update_Time_end", Update_Time_end.Text.Trim());
            form.setValue("Use_Time_start", Use_Time_start.Text.Trim());
            form.setValue("Use_Time_end", Use_Time_end.Text.Trim());


            RepairModel model = new RepairModel();
            PageBreak pb = new PageBreak(Request, Session, this, pbLabel);
            pb.setDBDAO(dao);
            DataSet ds = pb.doSearch(model, form, "browse2");
            Session["field"] = "browse2";
            if (pb.isDoSearch())
            {
                gvMain.DataSource = ds;
                gvMain.DataBind();
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

    //1080513新增


    //protected void mng_id_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    genCardIdSelect();
    //}
    //private void genCardIdSelect()
    //{
    //    UserID userID = (UserID)Session["UserID"];
    //    DBDAO dao = new DBDAO();
    //    HtmlTag hTag = new HtmlTag();
    //    try
    //    {
    //        dao.open();
    //        Form form = new Form();
    //        form.setValue("user_read", userID.getUserRead());
    //        form.setValue("user_org", userID.getUserOrg());
    //        form.setValue("keep_org", mng_id.SelectedValue);
    //        CardModel card_model = new CardModel();
    //        card_model.dao = dao;
    //        ArrayList al = card_model.selectmng_id(form);
    //        hTag.createSelect(al, card_id, form.getValue("id_name"), "請選擇", 0);
    //    }
    //    catch { }
    //    finally
    //    { dao.close(); }
    //}




    /// <summary>
    /// gvMain_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
    {

        string repair_id = gvMain.DataKeys[e.NewEditIndex].Values[0].ToString().Trim();

        Response.Redirect(Forward.Redirect("TDOSd008U1.aspx?repair_id=" + repair_id, "", this));
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

 


 







    protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}