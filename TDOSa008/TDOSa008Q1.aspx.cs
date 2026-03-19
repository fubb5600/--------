using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 系統帳號：查詢頁
/// </summary>
public partial class TDOSa008_TDOSa008Q1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();
        HtmlTag hTag = new HtmlTag();

        //Response.Write(ctlName);


        dao.open();

        String __EVENTTARGET = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
        if (!IsPostBack || __EVENTTARGET.Equals("ChangePaging"))
        {
            if (!IsPostBack)
            {
                //button權限
            }


            UserModel model = new UserModel();
            model.dao = dao;

            //角色群組資料來源             
            ArrayList al_Role = model.selectRole();

            //分頁設定                
            Form form = new Form();


            //狀態
            String statusValue = "";
            String DepValue = "";
            String SubDepValue = "";
            String TitleValue = "";
            String RoleValue = "";
            //有預設值，若有查詢過，則以新條件為準

         


            hTag.createSelect(al_Role, user_role, RoleValue, "請選擇", 0);
        }

        if (__EVENTTARGET.Equals("ChangePaging"))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script>chgHash('pb'); </script>");
        }

        dao.close();







    }
   

   

    protected void btndelete_Click(object sender, EventArgs e)
    {
        UserID userID = (UserID)Session["UserID"];
        DBDAO dao = new DBDAO();

        try
        {


            dao.open();
            dao.beginTransaction();

            Form form = new Form();
            form.setValue("user_role", user_role.SelectedValue);
            RoleModel roleModel = new RoleModel();
            roleModel.dao = dao;

            roleModel.deleteGroup(form);
            roleModel.deleteGroup1(form);
            dao.commit();
            Response.Write("<script>alert('刪除成功！');  </script>");
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
