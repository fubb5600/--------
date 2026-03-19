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
public partial class TDTSa005_TDTSa005U1 : System.Web.UI.Page
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
                btnSave.Visible = userID.getUserID().Equals("ADMIN");

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
        Boolean flag = false;

        try
        {
            dao.open();


            CarModel model = new CarModel();
            model.dao = dao;

            if (car_no_1.Text != string.Empty && userID.getUserID().Equals("ADMIN"))
                flag = model.correctCarStatusByAdmin(car_no_1.Text);

            dao.commit();
           
            if(flag)
                SysMsg.AlertMessage(this.Page, "執行成功！");


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