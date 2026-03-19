using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Common_Help : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBDAO dao = new DBDAO();
        FaqModel model = new FaqModel();
        model.dao = dao;
        if (!IsPostBack)
        {
            try
            {
                dao.open();
                DataSet ds = model.getFAQ("");
                String faq = string.Empty;
                Literal1.Text = "<div style=\"margin: 10px; margin-left: 45px;\"><span class=\"td_memo\">尚未建立常見問答集</span></div>";
                if (ds.Tables[0].Rows.Count > 0)
                {
                   
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        faq += "<h3>" + (i+1).ToString() + "." +  dr["question"].ToString() + "</h3><div>" + dr["answer"].ToString() ; 
                            if(dr["update_date"].ToString()!=string.Empty)
                                faq += "- " + dr["update_date"].ToString() + " -";
                        faq +="</div>";
                    }

                    Literal1.Text = "<div style=\"margin-left: 45px; margin-bottom: 10px;\"><div id=\"accordion\">" + faq +                        
                        "</div></div>";
                }
            }
            catch { }
            finally { dao.close(); }
        }
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        Label lblTaskName = (Label)this.Master.FindControl("lblTaskName");
        lblTaskName.Text = "系統說明";
    }


    /// <summary>
    /// 操作手冊下載按鈕事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbManual_Click(object sender, EventArgs e)
    {
       // string FilePath = Server.MapPath("~/Common/油料管理系統操作手冊v1.pdf");
        string FilePath = Server.MapPath("~/Common/油料暨車輛維修管理系統操作手冊v2.pdf");
        System.IO.FileInfo TargetFile = new System.IO.FileInfo(FilePath);
        Response.Clear();
        Response.HeaderEncoding = Encoding.GetEncoding("big5");
        Response.AddHeader("Content-Disposition", "attachment; filename=" + TargetFile.Name);
        Response.AddHeader("Content-Length", TargetFile.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(TargetFile.FullName);
        Response.End();
        Response.Close();
    }
   
}