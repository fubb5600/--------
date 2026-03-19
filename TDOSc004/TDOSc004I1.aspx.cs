using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
/// <summary>
/// 加油卡資料：新增頁
/// </summary>
public partial class TDTSc004_TDTSc004I1 : System.Web.UI.Page
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
                btnSave.Visible = userID.hasFunc("TDOSc004_insert");

                HtmlTag hTag = new HtmlTag();

                CardModel model = new CardModel();
                model.dao = dao;
                ArrayList al_CardType = model.selectCardTypeByWorkType("");
                hTag.createRadio(al_CardType, card_type, "", 0);
                
                //hTag.createMediatorRadio("CARD_TYPE", card_type, "1", 0);

                hTag.createMediatorRadio("FUEL_TYPE", fuel_type, "", 0);
                hTag.createMediatorRadio("USE_STS", status, "O", 0);



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
        Response.Redirect(Forward.Redirect("TDOSc004Q1.aspx", "", this));
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
                form.setValue("card_type", card_type.SelectedValue);
                form.setValue("card_no", card_no.Text.Trim().ToUpper());
                form.setValue("keep_org", keep_org.SelectedValue);
                form.setValue("fuel_type", fuel_type.SelectedValue);
                form.setValue("status", status.SelectedValue);
                //form.setValue("keep_man", keep_man.Text);            
                form.setValue("create_user", userID.getUserID());

                //新增加油卡
                CardModel model = new CardModel();
                model.dao = dao;
                Decimal card_id = model.insertCard(form);

                dao.commit();
                //SysMsg.AlertMessage(this.Page, "新增成功！");

                Response.Write("<script>alert('新增成功！'); location.href='" + Forward.Redirect("TDOSc004U1.aspx",
                    "card_id=" + card_id.ToString(), this) + "'; </script>");
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
    /// 儲存前的檢核
    /// </summary>
    /// <returns></returns>
    private Boolean CheckAll()
    {
        Boolean flag = true;
        DBDAO dao = new DBDAO();
        CardModel model = new CardModel();
        try
        {
            dao.open();
            model.dao = dao;

            //檢核加油卡號是否唯一
            if (flag && card_no.Text != string.Empty && status.SelectedValue == "O")
            {
                Form form = new Form();
                form.setValue("card_no", card_no.Text);
                form.setValue("action", "Insert");
                form.setValue("card_id", "");
                if (model.IsCardNoExist(form) != string.Empty)
                {
                    flag = false;
                    SysMsg.AlertMessage(this.Page, "已存在使用中的加油卡卡號，不可重複新增！");
                }
            }
        }
        catch { }
        finally { dao.close(); }
        return flag;
    }
}