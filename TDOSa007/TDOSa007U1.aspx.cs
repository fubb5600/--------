using System;
/// <summary>
/// </summary>
public partial class TDTSa007_TDTSa007U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
      
        try
        {
            dao.open();

            if (!IsPostBack)
            {
                //button權限

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
    /// 儲存按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
  

    /// <summary>
    /// 驗證舊密碼
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="user_pwd"></param>
    /// <returns>Boolean</returns>
    private Boolean CheckOldPwd(string user_id, string user_pwd)
    {
        DBDAO dao = new DBDAO();
        Boolean flag = false;
        try
        {
            dao.open();
            UserModel model = new UserModel();
            string db_pw = model.getUserPwd(user_id);
            string pw = MD5Digest.GetMD5(user_pwd + user_id);
            if (db_pw == pw)
            {
                flag = true;
            }
        }
        catch
        {
            flag = false;
        }
        finally
        {
            dao.close();
        }
        return flag;
    }

  

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        if(name1.Text !=""&& name.Text != "")
        {
            try
            {


                dao.open();
                dao.beginTransaction();
                string str = "";

                Form form = new Form();
                form.setValue("role_name", name.Text.Trim());
                form.setValue("role_id", name1.Text.Trim());
                for (int i = 0; i < keep_org.Items.Count; i++)
                {
                    if (keep_org.Items[i].Selected == true)
                    {

                        str += keep_org.Items[i].Value.Trim() + ",";



                    }

                }
                str = str.TrimEnd(',');

                form.setValue("keep_org", str);
                RoleModel roleModel = new RoleModel();
                roleModel.dao = dao;
                
                roleModel.insertGroup(form);
              
          

                if (TDOSa001_delete.Checked)
                {
                    roleModel.insertTDOSa001_delete(form);
                }

                if (TDOSa001_insert.Checked)
                {
                    roleModel.TDOSa001_insert(form);
                }
                if (TDOSa001_query.Checked)
                {
                    roleModel.TDOSa001_query(form);
                }
                if (TDOSa001_update.Checked)
                {
                    roleModel.TDOSa001_update(form);
                }

                if (TDOSa002_delete.Checked)


                {
                    roleModel.TDOSa002_delete(form);
                }

                if (TDOSa002_query.Checked)
                {
                    roleModel.TDOSa002_query(form);
                }
                if (TDOSa002_update.Checked)
                {
                    roleModel.TDOSa002_update(form);
                }


                if (TDOSa003_update.Checked)
                {
                    roleModel.TDOSa003_update(form);
                }
                if (TDOSa004_update.Checked)
                {
                    roleModel.TDOSa004_update(form);
                }

                if (TDOSa007_insert.Checked)
                {
                    roleModel.TDOSa007_insert(form);
                }
                if (TDOSa008_delete.Checked)
                {
                    roleModel.TDOSa008_delete(form);
                }
                if (TDOSb001_audit.Checked)
                {
                    roleModel.TDOSb001_audit(form);
                }
                if (TDOSb001_delete.Checked)
                {
                    roleModel.TDOSb001_delete(form);
                }

                if (TDOSb001_insert.Checked)
                {
                    roleModel.TDOSb001_insert(form);
                }
                if (TDOSb001_query.Checked)
                {
                    roleModel.TDOSb001_query(form);
                }

                if (TDOSb001_update.Checked)
                {
                    roleModel.TDOSb001_update(form);
                }




                if (TDOSb002_delete.Checked)
                {
                    roleModel.TDOSb002_delete(form);
                }

                if (TDOSb002_insert.Checked)
                {
                    roleModel.TDOSb002_insert(form);
                }
                if (TDOSb002_query.Checked)
                {
                    roleModel.TDOSb002_query(form);
                }

                if (TDOSb002_update.Checked)
                {
                    roleModel.TDOSb002_update(form);
                }


                if (TDOSc001_delete.Checked)
                {
                    roleModel.TDOSc001_delete(form);
                }
                if (TDOSc001_insert.Checked)
                {
                    roleModel.TDOSc001_insert(form);
                }
                if (TDOSc001_query.Checked)
                {
                    roleModel.TDOSc001_query(form);
                }
                if (TDOSc001_update.Checked)
                {
                    roleModel.TDOSc001_update(form);
                }

                if (TDOSc001_Allinsert.Checked)
                {
                    roleModel.TDOSc001_Allinsert(form);
                }

                if (TDOSc002_delete.Checked)
                {
                    roleModel.TDOSc002_delete(form);
                }
                if (TDOSc002_insert.Checked)
                {
                    roleModel.TDOSc002_insert(form);
                }
                if (TDOSc002_query.Checked)
                {
                    roleModel.TDOSc002_query(form);
                }
                if (TDOSc002_update.Checked)
                {
                    roleModel.TDOSc002_update(form);
                }

                if (TDOSc003_delete.Checked)
                {
                    roleModel.TDOSc003_delete(form);
                }
                if (TDOSc003_insert.Checked)
                {
                    roleModel.TDOSc003_insert(form);
                }
                if (TDOSc003_query.Checked)
                {
                    roleModel.TDOSc003_query(form);
                }
                if (TDOSc003_update.Checked)
                {
                    roleModel.TDOSc003_update(form);
                }

                if (TDOSc004_insert.Checked)
                {
                    roleModel.TDOSc004_insert(form);
                }
                if (TDOSc004_query.Checked)
                {
                    roleModel.TDOSc004_query(form);
                }

                if (TDOSc005_delete.Checked)
                {
                    roleModel.TDOSc005_delete(form);
                }
                if (TDOSc005_insert.Checked)
                {
                    roleModel.TDOSc005_insert(form);
                }
                if (TDOSc005_query.Checked)
                {
                    roleModel.TDOSc005_query(form);
                }
                if (TDOSc005_update.Checked)
                {
                    roleModel.TDOSc005_update(form);
                }
                if (TDOSd008_query.Checked)
                {
                    roleModel.TDOSd008_query(form);

                }
                if (TDOSd008_delete.Checked)
                {
                    roleModel.TDOSd008_delete(form);

                }
                if (TDOSd009_query.Checked)
                {
                    roleModel.TDOSd009_query(form);

                }



                if (TDOSd001_query.Checked)
                {
                    roleModel.TDOSd001_query(form);
                }
                if (TDOSd001_update.Checked)
                {
                    roleModel.TDOSd001_update(form);
                }

                if (TDOSd002_query.Checked)
                {
                    roleModel.TDOSd002_query(form);
                }
                if (TDOSd003_query.Checked)
                {
                    roleModel.TDOSd003_query(form);
                }
                if (TDOSd004_query.Checked)
                {
                    roleModel.TDOSd004_query(form);
                }
                if (TDOSd005_query.Checked)
                {
                    roleModel.TDOSd005_query(form);
                }
                if (TDOSd006_query.Checked)
                {
                    roleModel.TDOSd006_query(form);
                }
                if (TDOSd007_query.Checked)
                {
                    roleModel.TDOSd007_query(form);
                }
              

                if (TDOSe001_delete.Checked)
                {
                    roleModel.TDOSe001_delete(form);
                }
                if (TDOSe001_insert.Checked)
                {
                    roleModel.TDOSe001_insert(form);
                }
                if (TDOSe001_query.Checked)
                {
                    roleModel.TDOSe001_query(form);
                }
                if (TDOSe001_update.Checked)
                {
                    roleModel.TDOSe001_update(form);
                }
                if (TDOSe002_delete.Checked)
                {
                    roleModel.TDOSe002_delete(form);
                }
                if (TDOSe002_insert.Checked)
                {
                    roleModel.TDOSe002_insert(form);
                }
                if (TDOSe002_query.Checked)
                {
                    roleModel.TDOSe002_query(form);
                }
                if (TDOSe002_update.Checked)
                {
                    roleModel.TDOSe002_update(form);
                }
                if (TDOSf001_delete.Checked)
                {
                    roleModel.TDOSf001_delete(form);
                }
                if (TDOSf001_insert.Checked)
                {
                    roleModel.TDOSf001_insert(form);
                }
                if (TDOSf001_query.Checked)
                {
                    roleModel.TDOSf001_query(form);
                }
                if (TDOSf001_update.Checked)
                {
                    roleModel.TDOSf001_update(form);
                }
                if (TDOSf001_print.Checked)
                {
                    roleModel.TDOSf001_print(form);
                }

                if (TDOSf002_delete.Checked)
                {
                    roleModel.TDOSf002_delete(form);
                }
                if (TDOSf002_insert.Checked)
                {
                    roleModel.TDOSf002_insert(form);
                }
                if (TDOSf002_query.Checked)
                {
                    roleModel.TDOSf002_query(form);
                }
                if (TDOSf002_update.Checked)
                {
                    roleModel.TDOSf002_update(form);
                }
                if (TDOSf002_print.Checked)
                {
                    roleModel.TDOSf002_print(form);
                }

                dao.commit();
                Response.Write("<script>alert('新增成功！');  </script>");

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


}