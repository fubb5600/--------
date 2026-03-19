using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

public partial class TDOSf002_TDOSf002U3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        Mediator med = new Mediator();
        ComponentModel model = new ComponentModel();
        HtmlTag hTag = new HtmlTag();

        try
        {
            if (!IsPostBack)
            {
                has_junk.Attributes.Add("onclick", "javascript:clearJunk();");
                hfWorkNo.Value = Request["work_no"];
                hfCRSArea.Value = Request["crs_area"];
                hfRepairItem.Value = Request["repair_item"];

                dao.open();
                model.dao = dao;
                ArrayList alYear = model.selectYear();
                hTag.createSelect(alYear, year, "", "請選擇", 0);
                year.SelectedIndex = alYear.Count;
                year_SelectedIndexChanged(sender, e);//新增"適用車種排序"_wenny1061212
                #region //新增"適用車種排序"_wenny1061212
                ArrayList alComponentCode = model.selectCode(year.SelectedValue, car_type_keyword.Text);

                hTag.createSelect(alComponentCode, component_code, "", "請選擇", 0);
                component_code_SelectedIndexChanged(sender, e);//新增"適用車種排序"_wenny1061212
                ArrayList alComponentNo = model.selectComponentno("", "", "");//新增"適用車種排序"_wenny1061212
                hTag.createSelect(alComponentNo, component_no, "", "請選擇", 0);
                #endregion

               
                hTag.createSelect(genNotifyItemSelect(Request["work_no"]), notify_item, "", "請選擇", 0);
                hTag.createMediatorRadio("YES_NO", has_junk, "Y", 0);

                budget_memo.Text = " (使用單價第" + hfCRSArea.Value + "區)";

                loadData(sender, e);
                //1080513新增

                if (has_junk.SelectedValue == "N")
                {
                    junk_name.Visible = false;
                    junk_count.Visible = false;
                }
                if (has_junk.SelectedValue == "Y")
                {
                    junk_name.Visible = true;
                    junk_count.Visible = true;
                }
                DataSet ds = model.selectRepairMst1(Request["work_no"]);
                DataRow dr = ds.Tables[0].Rows[0];



                Date.Text = dr["notify_date"].ToString();
                Car.Text = dr["car_no"].ToString();
                crs_org.Text = dr["crs_org"].ToString();
                DataSet ds1 = model.selectChg(component_name.Text, crs_org.Text);
                DataRow dr1 = ds1.Tables[0].Rows[0];

                Stock1.Text = dr1["count"].ToString();
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




    private void loadData(object sender, EventArgs e)
    {
        if (hfRepairItem.Value.Equals(""))
            return;

        string[] data = hfRepairItem.Value.Split('|');

        notify_item.SelectedValue = data[0];

        year.SelectedValue = data[1].ToString().Substring(0, 3);
        year_SelectedIndexChanged(sender, e);
        component_code.SelectedValue = getComponentCode(data[1]);
        component_code_SelectedIndexChanged(sender, e);
        component_no.SelectedValue = data[1];
        component_no_SelectedIndexChanged(sender, e);
        count.Text = data[3];
        count_TextChanged(sender, e);
        junk_name.Text = data[5];
        junk_count.Text = data[6];

        if (string.IsNullOrEmpty(junk_name.Text))
            has_junk.SelectedValue = "N";


    }

    //1080513新增

    protected void has_junk_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (has_junk.SelectedValue.Equals("N"))
        {
            junk_name.Visible = false;
            junk_count.Visible = false;

            has_junk.SelectedValue = "N";

        }
        if (has_junk.SelectedValue.Equals("Y"))
        {
            junk_name.Visible = true;
            junk_count.Visible = true;

            has_junk.SelectedValue = "Y";

        }

    }
    private String getComponentCode(String sComponentNo)
    {
        String sRetValue = "";
        DBDAO dao = new DBDAO();
        ComponentModel model = new ComponentModel();
        try
        {
            dao.open();
            model.dao = dao;
            sRetValue = model.getComponentCode(sComponentNo);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            dao.close();
        }

        return sRetValue;
    }


    private ArrayList genNotifyItemSelect(String sWorkNo)
    {
        NotifyModel model = new NotifyModel();
        DBDAO dao = new DBDAO();
        ArrayList al = new ArrayList();
        UserID userID = (UserID)Session["UserID"];

        try
        {
            dao.open();

            model.dao = dao;
            DataSet ds = model.selectNotifyByWorkNo(sWorkNo, userID.getUserID());

            if (ds.Tables[0].Rows.Count == 1)
            {
                String sNotifyItem = ds.Tables[0].Rows[0]["notify_item"].ToString();

                String[] items = sNotifyItem.Split('|');

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != string.Empty)
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("PVALUE", items[i]);
                        ht.Add("PTEXT", items[i]);
                        al.Add(ht);
                    }
                }
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
        return al;
    }

    #region //新增"適用車種排序"_wenny1061212
    protected void car_type_keyword_TextChanged(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        ComponentModel model = new ComponentModel();
        HtmlTag hTag = new HtmlTag();






        try
        {
            dao.open();
            model.dao = dao;
            notified.Text = "";
            component_name.Text = "";
            component_spec.Text = "";
            ArrayList alCarType;
            ArrayList alComponent;
            if (string.IsNullOrEmpty(car_type_keyword.Text))
            {
                component_keyword.Text = "";
                alCarType = model.selectCarType(year.SelectedValue, "");//新增"適用車種排序"_wenny1061212
                hTag.createSelect(alCarType, car_type, "", "請選擇", 0);//新增"適用車種排序"_wenny1061212
                alComponent = model.selectComponentno("", "");
                hTag.createSelect(alComponent, component_no, "", "請選擇", 0);
                return;
            }
            alCarType = model.selectCarType(year.SelectedValue, car_type_keyword.Text);//新增"適用車種排序"_wenny1061212
            hTag.createSelect(alCarType, car_type, "", "請選擇", 0);//新增"適用車種排序"_wenny1061212
            ArrayList alCode = model.selectCode(year.SelectedValue, car_type_keyword.Text);
            hTag.createSelect(alCode, component_code, "", "請選擇", 0);
            alComponent = model.selectComponentno(year.SelectedValue, car_type_keyword.Text);
            hTag.createSelect(alComponent, component_no, "", "請選擇", 0);

            Session["alComponent"] = alComponent;
            hfYear.Value = year.SelectedValue;

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
    protected void car_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        ComponentModel model = new ComponentModel();
        HtmlTag hTag = new HtmlTag();
        try
        {
            dao.open();
            model.dao = dao;
            ArrayList alComponent;
            ArrayList alCode;
            component_name.Text = "";
            component_spec.Text = "";
            notified.Text = "";

            if (car_type.SelectedValue.Equals(""))
            {
                car_type_keyword.Text = "";
                component_keyword.Text = "";
                ArrayList alCarType = model.selectCarType(year.SelectedValue, car_type_keyword.Text);
                hTag.createSelect(alCarType, car_type, "", "請選擇", 0);
                alCode = model.selectCode(year.SelectedValue, "", "");
                hTag.createSelect(alCode, component_code, "", "請選擇", 0);
                alComponent = model.selectComponentno("", "", "", "", "");
                hTag.createSelect(alComponent, component_no, "", "請選擇", 0);
                return;
            }

            alCode = model.selectCode(year.SelectedValue, "", car_type.SelectedValue);
            hTag.createSelect(alCode, component_code, "", "請選擇", 0);

            alComponent = model.selectComponentno(year.SelectedValue, car_type.SelectedValue, component_keyword.Text);
            hTag.createSelect(alComponent, component_no, "", "請選擇", 0);
            Session["alComponent"] = alComponent;


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
    protected void component_code_SelectedIndexChanged(object sender, EventArgs e)
    {

        DBDAO dao = new DBDAO();
        ComponentModel model = new ComponentModel();
        HtmlTag hTag = new HtmlTag();

        try
        {

            dao.open();
            model.dao = dao;
            ArrayList alComponent;
            component_name.Text = "";
            component_spec.Text = "";
            notified.Text = "";

            if (car_type.SelectedValue.Equals("") && component_code.SelectedValue.Equals(""))
            {
                component_keyword.Text = "";
                alComponent = model.selectComponentno("", "", "");
                hTag.createSelect(alComponent, component_no, "", "請選擇", 0);

                return;
            }
            alComponent = model.selectComponentno(year.SelectedValue, "", car_type.SelectedValue, component_code.SelectedValue, component_keyword.Text);
            hTag.createSelect(alComponent, component_no, "", "請選擇", 0);
            Session["alComponent"] = alComponent;

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
    protected void component_keyword_TextChanged(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        ComponentModel model = new ComponentModel();
        HtmlTag hTag = new HtmlTag();
        try
        {
            ArrayList alComponent;
            notified.Text = "";
            component_name.Text = "";
            component_spec.Text = "";


            dao.open();
            model.dao = dao;
            if (component_keyword.Text == "" && !string.IsNullOrEmpty(car_type_keyword.Text))
            {
                alComponent = model.selectComponentno(year.SelectedValue, car_type_keyword.Text);
                hTag.createSelect(alComponent, component_no, "", "請選擇", 0);
                return;
            }
            if (car_type.SelectedValue.Equals("") && component_code.SelectedValue.Equals("") && component_keyword.Text == "")
            {
                component_keyword.Text = "";
                alComponent = model.selectComponentno("", "", "");
                hTag.createSelect(alComponent, component_no, "", "請選擇", 0);
                return;
            }


            alComponent = model.selectComponentno(year.SelectedValue, car_type_keyword.Text, car_type.SelectedValue, component_code.SelectedValue, component_keyword.Text);
            hTag.createSelect(alComponent, component_no, "", "請選擇", 0);
            Session["alComponent"] = alComponent;

        }
        catch (Exception)
        {

            throw;
        }

    }

    #endregion
    #region //新增"適用車種排序"_wenny1061212_原始碼
    #region //component_code_SelectedIndexChanged 
    //protected void component_code_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    filterComponent();//新增"適用車種排序"_wenny1061212_原始碼
    //    //ArrayList al = (ArrayList)Session["Component"];
    //    //ArrayList alComponent = new ArrayList();
    //    //for (int i = 0; i < al.Count; i++)
    //    //{
    //    //    Hashtable ht = (Hashtable)al[i];
    //    //    if (ht["COMPONENT_CODE"].ToString().Equals(component_code.SelectedValue))
    //    //    {
    //    //        alComponent.Add(ht);
    //    //    }
    //    //}
    //    //HtmlTag hTag = new HtmlTag();
    //    //hTag.createSelect(alComponent, component_no, "", "請選擇", 0);        
    //    //Session["ComponentFilter"] = alComponent;
    //}
    #endregion
    #region //component_filter_TextChanged
    //protected void component_filter_TextChanged(object sender, EventArgs e)
    //{
    //    //filterComponent();
    //}
    #endregion
    #region //filterComponent()
    //private void filterComponent()
    //{
    //    ArrayList al = (ArrayList)Session["Component"];
    //    ArrayList alComponent = new ArrayList();
    //    for (int i = 0; i < al.Count; i++)
    //    {
    //        Hashtable ht = (Hashtable)al[i];
    //        Boolean isAdd = false;
    //        if (component_filter.Text != string.Empty)
    //        {
    //            if (!isAdd && ht["COMPONENT_NAME"].ToString().Contains(component_filter.Text))
    //                isAdd = true;

    //            if (!isAdd && ht["COMPONENT_NO"].ToString().Contains(component_filter.Text))
    //                isAdd = true;

    //        }

    //        if (!isAdd && component_code.SelectedValue != "" && ht["COMPONENT_CODE"].ToString().Contains(component_code.SelectedValue))
    //            isAdd = true;

    //        if (isAdd)
    //            alComponent.Add(ht);
    //    }
    //    HtmlTag hTag = new HtmlTag();
    //    hTag.createSelect(alComponent, component_no, "", "請選擇", 0);
    //    Session["ComponentFilter"] = alComponent;

    //}
    #endregion
    #endregion


    protected void component_no_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (component_no.SelectedValue.Equals(""))
            return;
        component_name.Text = "";
        component_spec.Text = "";
        notified.Text = "";

        ArrayList al = (ArrayList)Session["alComponent"];
        Hashtable ht = (Hashtable)al[component_no.SelectedIndex - 1];
        component_name.Text = ht["COMPONENT_NAME"].ToString();
        component_spec.Text = ht["COMPONENT_SPEC"].ToString();
        Notified();
        calculatePrice();
    }

    protected void count_TextChanged(object sender, EventArgs e)
    {
        calculatePrice();
    }

    private void calculatePrice()
    {
        UserID userID = (UserID)Session["UserID"];

        if (component_no.SelectedValue != string.Empty && count.Text != string.Empty)
        {
            try
            {
                ArrayList al = (ArrayList)Session["alComponent"];// 新增"適用車種排序"_wenny1061212_原始碼
                                                                 //ArrayList al = (ArrayList)Session["ComponentFilter"];//原始碼
                Hashtable ht = (Hashtable)al[component_no.SelectedIndex - 1];
                Double dBudget = Double.Parse(ht["BUDGET" + hfCRSArea.Value].ToString());

                //total_price.Text = String.Format("{0:N0}", (dBudget * (Double.Parse(count.Text))));
                //unit_price.Text = String.Format("{0:N0}", dBudget);//修正單價為小數點兩位_wennyh_1229_原始碼
                unit_price.Text = String.Format("{0:N2}", dBudget);////修正單價為小數點兩位_wennyh_1229


            }
            catch
            {
                unit_price.Text = "";
            }
            junk_name.Focus();
        }
    }




    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (has_junk.SelectedValue == "Y")
        {
            if (args.Value.Equals(""))
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
    protected void year_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (year.SelectedValue.Equals(hfYear.Value))
            return;

        DBDAO dao = new DBDAO();
        ComponentModel model = new ComponentModel();
        HtmlTag hTag = new HtmlTag();

        try
        {
            dao.open();
            model.dao = dao;
            notified.Text = "";
            component_name.Text = "";
            component_spec.Text = "";
            //ArrayList alComponent = model.selectComponentSource(year.SelectedValue);//新增"適用車種排序"_wenny1061212_修改前原始碼
            ArrayList alCarType = model.selectCarType(year.SelectedValue, "");
            //ArrayList alCarType = model.selectCarType(year.SelectedValue , car_type_keyword.Text);//新增"適用車種排序"_wenny1061212
            //ArrayList alCode = model.selectCode(year.SelectedValue);//原始碼
            hTag.createSelect(alCarType, car_type, "", "請選擇", 0);//新增"適用車種排序"_wenny1061212
                                                                 //hTag.createSelect(alCode, component_code, "", "請選擇", 0);//原始碼
            ArrayList alCode = model.selectCode(year.SelectedValue, "");
            //ArrayList alCode = model.selectCode(year.SelectedValue, car_type_keyword.Text);////新增"適用車種排序"_wenny1061212
            hTag.createSelect(alCode, component_code, "", "請選擇", 0);
            ArrayList alComponentNo = model.selectComponentno("", "", "");
            hTag.createSelect(alComponentNo, component_no, "", "請選擇", 0);

            //ArrayList alComponentNo;
            //if (string.IsNullOrEmpty(car_type_keyword.Text) & string.IsNullOrEmpty(component_filter.Text))
            //{ alComponentNo = model.selectComponentno("", car_type_keyword.Text, component_filter.Text); }
            //else
            //{ alComponentNo = model.selectComponentno(year.SelectedValue, car_type_keyword.Text, component_filter.Text); }
            //hTag.createSelect(alComponentNo, component_no, "", "請選擇", 0);

            //string a = model.selectCode(year.SelectedValue, car_type_keyword.Text, car_type.SelectedValue);
            //Response.Write(a);
            //Session["Component"] = alComponent;//新增"適用車種排序"_wenny1061212_修改前原始碼
            //filterComponent();//新增"適用車種排序"_wenny1061212_修改前原始碼
            hfYear.Value = year.SelectedValue;
            car_type_keyword.Text = "";
            component_keyword.Text = "";
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

    #region//加註已報修過_wenny_1061207
    private void Notified()
    {

        string sql = @"select     
                                  convert(varchar(10), c.notify_date, 111) as notify_date
                               -- c.notify_date  as notify_date
                            from f_repair_mst a 
                               left join c_car_mst b on a.car_id = b.car_id 
                               left join f_notify_mst c on a.work_no = c.work_no 
                               left join 
                                   (select t.component_no,t.repair_id
                                     from( select a.*
                                           from(  select c.component_no, a.repair_id,b.budget_area, 
                                                     case when budget_area = 1 then c.budget1  
                                                     when budget_area = 3 then c.budget3
        		                                     when budget_area = 4 then c.budget4
                                                     else c.budget2 end as budget 
                                                  from f_repair_dtl a 
                                                     left join f_repair_mst b on a.repair_id = b.repair_id 
                                                     left join e_component_mst c on a.component_no = c.component_no
                                                )a 
                                          )t
                                    )t on t.repair_id = a.repair_id 
                            where    
                                c.notify_date between dateadd(year,-1 ,GETDATE()) and GETDATE()
                              --c.notify_date between '2015-01-01 08:30:00.000' and '2016-12-30 08:30:00.000'
                               
                                and dep_no = @dep_no
                                 and component_no like @component_no 
                           group by c.notify_date ";

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebConnectionString"].ToString()))
        {
            string str = "";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                string componentNo = (component_no.SelectedValue).Substring(3);
                String depOrg = Session["DEPORG"].ToString();
                cmd.Parameters.AddWithValue("@dep_no", depOrg);
                cmd.Parameters.AddWithValue("@component_no", "%" + componentNo + "%");

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str = str + dr["notify_date"].ToString() + " 、 ";
                }
                con.Close();
            }
            if (!string.IsNullOrEmpty(str))
            {
                //SysMsg.AlertMessage(this.Page, str.Substring(0, str.Length - 2));
                notified.Text = str.Substring(0, str.Length - 2);
            }
            else
            { notified.Text = ""; }
        }


    }

    #endregion


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //work_no = Request["work_no"];
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {


            dao.open();
            dao.beginTransaction();

            string notify_item1 = "";
            notify_item1 = notify_item.SelectedItem.ToString();
            if (notify_item1 == "請選擇")
            {
                notify_item1 = "";



            }

            Form form = new Form();
            form.setValue("crs_org", crs_org.Text);
            form.setValue("Thing", component_name.Text.Trim());
            form.setValue("Count", count1.Text.Trim());
            form.setValue("Work_no", Request["work_no"]);
            form.setValue("Memo", notify_item1);
            form.setValue("car_no", Car.Text.Trim());
            form.setValue("notify_date", Date.Text.Trim());

            form.setValue("component_no", component_no.SelectedValue.Trim());




            if (component_name.Text.Trim() != "" && count1.Text.Trim() != "" && Int32.Parse(count.Text) >= Int32.Parse(count1.Text))
            {
                RoleModel roleModel = new RoleModel();
                roleModel.dao = dao;


                roleModel.insertStock(form);

                //Response.Write("<script>alert('新增成功！'); </script>");

            }






            dao.commit();
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

    protected void btnStock_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {


            dao.open();
            dao.beginTransaction();

            string notify_item1 = "";
            notify_item1 = notify_item.SelectedItem.ToString();
            if (notify_item1 == "請選擇")
            {
                notify_item1 = "";



            }

            Form form = new Form();
            form.setValue("notify_item", notify_item.SelectedValue);
            form.setValue("crs_org", crs_org.Text);
            form.setValue("Count","-"+count2.Text.Trim());
            form.setValue("Work_no", Request["work_no"]);
            form.setValue("Memo", "使用庫存");
            form.setValue("car_no", Car.Text.Trim());
            form.setValue("notify_date", Date.Text.Trim());
            form.setValue("Thing", component_name.Text.Trim());
            form.setValue("component_no", component_no.SelectedValue.Trim());


            if(Int32.Parse(Stock1.Text) >= Int32.Parse(count2.Text))
            {
                RoleModel roleModel = new RoleModel();
                roleModel.dao = dao;


                roleModel.UseStock(form);
            }

         
              

                //Response.Write("<script>alert('新增成功！'); </script>");

            






            dao.commit();
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
}