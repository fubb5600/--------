using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 變更密碼頁
/// </summary>
public partial class TDTSa004_TDTSa004U1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        try
        {
            dao.open();

            if (!IsPostBack)
            {
                //button權限
                btnSave.Visible = userID.hasFunc("TDTSa004_update");

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {
            if (CheckOldPwd(userID.getUserID(), old_passwd.Text))
            {
                dao.open();
                dao.beginTransaction();

                Form form = new Form();
                form.setValue("user_id", userID.getUserID());
                form.setValue("passwd", passwd.Text);
                form.setValue("update_user", userID.getUserID());

                UserModel userModel = new UserModel();
                userModel.dao = dao;
                userModel.updateUserPwd(form);

                dao.commit();
                SysMsg.AlertMessage(this.Page, "密碼變更成功！");
            }
            else { SysMsg.AlertMessage(this.Page, "舊密碼錯誤！"); }
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
}