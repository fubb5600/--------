using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.SessionState;
using System.Collections;

/// <summary>
/// PageBreak 的摘要描述

/// </summary>
public class PageBreak
{
    //頁數設定
    public static readonly int records = 10;
    private int pageRecords = records;
    private int pageNumber = 1;
    private String web = "";
    //回傳資料
    private int totalCount = 0;
    private int totalPage = 1;

    private DBDAO dao;
    private Label label;
    private HttpRequest request;
    private HttpSessionState session;
    private Page thisPage;

    private String sessionID = "";

    //執行SQL
    private String cmdSQL = "";
    //Order By For MSSQL分頁
    private String odrSQL = "";
    //Param
    private Hashtable htParam = new Hashtable();

    private Boolean flag = false;

    public PageBreak()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public PageBreak(HttpRequest request, HttpSessionState session, Page nowPage, Label label)
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
        this.label = label;
        this.request = request;
        this.session = session;
        this.thisPage = nowPage;
    }

    public PageBreak(HttpRequest request, HttpSessionState session, Page nowPage, Label label, DBDAO dao)
    {
        this.label = label;
        this.request = request;
        this.session = session;
        this.thisPage = nowPage;
        this.dao = dao;
    }

    /// <summary>
    /// 設定使用的DBDAO
    /// </summary>
    /// <param name="dao">DBDAO</param>
    public void setDBDAO(DBDAO dao)
    {
        this.dao = dao;
    }

    /// <summary>
    /// 取得使用的DBDAO
    /// </summary>
    /// <returns>DBDAO</returns>
    public DBDAO getDBDAO()
    {
        return this.dao;
    }

    /// <summary>
    /// 設定分頁筆數
    /// </summary>
    /// <param name="record_num"></param>
    public void setPageRecords(int record_num)
    {
        pageRecords = record_num;
    }

    /// <summary>
    /// 取得分頁筆數
    /// </summary>
    /// <returns></returns>
    public int getPageRecords()
    {
        return pageRecords;
    }

    /// <summary>
    /// 執行SQL
    /// </summary>
    public String CommandSQL
    {
        get
        {
            return cmdSQL;
        }
        set
        {
            cmdSQL = value;
        }
    }

    /// <summary>
    /// 排序SQL
    /// PS：欄位要在select field裡，否則會因無此欄位而發生錯誤

    /// </summary>
    public String OrderSQL
    {
        get
        {
            return odrSQL;
        }
        set
        {
            odrSQL = value;
        }
    }

    /// <summary>
    /// 設定SQL參數
    /// </summary>
    /// <param name="key"></param>
    /// <param name="obj"></param>
    public void setParam(String key, Object obj)
    {
        htParam.Add(key, obj);
    }

    /// <summary>
    /// 是否已查詢過
    /// </summary>
    /// <returns>是否已查詢過</returns>
    public Boolean isDoSearch()
    {
        return this.flag;
    }

    /// <summary>
    /// 取得資料總筆數


    /// </summary>
    /// <returns>資料總筆數</returns>
    public int getTotalCount()
    {
        return totalCount;
    }

    /// <summary>
    /// 設定sessionid
    /// </summary>
    /// <param name="sessionId">sessionid</param>
    public void setSessionID(String sessionId)
    {
        this.sessionID = sessionId;
    }

    /// <summary>
    /// 產生的分頁的區塊的html
    /// </summary>
    /// <returns>分頁的區塊的html</returns>
    public String makeTag()
    {
        if (totalCount == 0)
        {
            return "";
        }

        String pageCount = totalPage.ToString();


        String str = "<script>function changePage(pageAction){ " +
            " document.getElementById('pageAction" + sessionID + "').value=pageAction; " +
            " if(pageAction == 'go'){ " +
              " var anum= /^\\d+$/; " +
              " if(document.getElementById('goPageNumber" + sessionID + "').value!='' && anum.test(document.getElementById('goPageNumber" + sessionID + "').value )){  " +
                " if(document.getElementById('goPageNumber" + sessionID + "').value == 0 ){document.getElementById('goPageNumber" + sessionID + "').value=1;} __doPostBack('ChangePaging', ''); " +
                "} else { document.getElementById('goPageNumber" + sessionID + "').value='1'; alert('頁數須為整數'); } " +
              "} else{ __doPostBack('ChangePaging', ''); } }" +
                            "function chgHash(myHash){" +
              "location.hash=myHash}</script>" +

            "<a name=\"pb\"></a><table>" +
            "<tr>" +
            "<td>" +
            "共&nbsp;" + totalCount + "筆&nbsp;&nbsp;第&nbsp;" + pageNumber + "頁/共&nbsp;" + totalPage + "頁&nbsp;&nbsp;" +
            "<a href=\"javascript:changePage('previous')\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('BtnA','','images/control_first-2.gif',1)\"><img name=\"BtnA\" border=\"0\"  alt=\"第一頁\"></a>" +
            "<a href=\"javascript:changePage('back')\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('BtnB','','images/control_previous-2.gif',1)\"><img name=\"BtnB\" border=\"0\" alt=\"上一頁\"></a>" +
            "<a href=\"javascript:changePage('next')\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('BtnC','','images/control_next-2.gif',1)\"><img name=\"BtnC\" border=\"0\"  alt=\"下一頁\"></a>" +
            "<a href=\"javascript:changePage('forward')\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('BtnD','','images/control_last-2.gif',1)\"><img name=\"BtnD\" border=\"0\"  alt=\"最末頁\"></a>" +
            "&nbsp;&nbsp;跳至第<input type=\"text\" name=\"goPageNumber" + sessionID + "\" id=\"goPageNumber" + sessionID + "\" size=\"5\" maxlength=\"" + pageCount.Length + "\" value=\"" + pageNumber + "\"/>頁" +
            "<a href=\"javascript:changePage('go')\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('BtnE','','images/control_go-2.gif',1)\"><img name=\"BtnE\" border=\"0\"  alt=\"GO\"></a>" +
            "<input type=\"hidden\" name=\"pageAction" + sessionID + "\" id=\"pageAction" + sessionID + "\" value=\"\"/>" +
            "</td>" +
            "</tr>" +
            "</table>";

        return str;
    }

    /// <summary>
    /// 查詢資料總筆數

    /// </summary>
    public void searchTotalCount()
    {
        String sql = "select count(*) as TOTALCOUNT from (" + cmdSQL + ") pb";
        dao.CommandSQL = sql;

        if (htParam.Count > 0)
        {
            foreach (string key in htParam.Keys)
            {
                Object obj = htParam[key];
                dao.setParam(key, obj);
            }
        }

        ArrayList al = dao.search();
        Hashtable ht = (Hashtable)al[0];
        totalCount = Convert.ToInt32(ht["TOTALCOUNT"].ToString());

        totalPage = totalCount % pageRecords > 0 ? totalCount / pageRecords + 1 : totalCount / pageRecords;
        if (totalPage == 0)
        {
            totalPage = 1;
            pageNumber = 1;
        }

        if (pageNumber == -1)
        {
            pageNumber = totalPage;
        }
        else if (pageNumber < 0)
        {
            pageNumber = 1;
        }
        else if (totalPage < pageNumber)
        {
            pageNumber = totalPage;
        }
    }

    /// <summary>
    /// 查詢
    /// </summary>
    /// <param name="model">Model</param>
    /// <param name="form">Form</param>
    /// <param name="pbKey">String</param>
    /// <returns>DataSet</returns>
    public DataSet doSearch(Model model, Form form, String pbKey)
    {
        TextBox ot = (TextBox)thisPage.Master.FindControl("OLD_TASK");
        TextBox wp = (TextBox)thisPage.Master.FindControl("whereParam" + sessionID);
        TextBox pn = (TextBox)thisPage.Master.FindControl("pageNumber" + sessionID);
        UserID userID = (UserID)session["UserID"];
        String whereParam = "";

        web = request.ApplicationPath + "/";

        if (form == null)
        {
            //判別是否為同一作業，若為不同作業，就先將查詢條件清空

            String path = request.CurrentExecutionFilePath;
            String[] arrPath = path.Split('/');
            String task_id = arrPath[arrPath.Length - 2];
            String OLD_TASK = ot.Text;

            if (!task_id.Equals(OLD_TASK))
            {
                //從別作業過來，將狀態歸零，並將新task放入session
                wp.Text = "";
                pn.Text = "1";
                ot.Text = task_id;
            }
            else
            {
                String pageAction = request["pageAction" + sessionID];

                String pnText = pn.Text;
                if (pnText.Equals(""))
                {
                    pnText = "1";
                }

                if (pageAction == null || pageAction.Equals(""))
                {
                    pageNumber = Convert.ToInt32(pnText);
                }
                else
                {
                    if (pageAction.Equals("previous"))
                    {
                        pageNumber = 1;
                    }
                    else if (pageAction.Equals("back"))
                    {
                        pageNumber = Convert.ToInt32(pnText);

                        if (pageNumber > 1)
                        {
                            pageNumber = pageNumber - 1;
                        }

                    }
                    else if (pageAction.Equals("next"))
                    {
                        pageNumber = Convert.ToInt32(pnText);

                        pageNumber = pageNumber + 1;
                    }
                    else if (pageAction.Equals("forward"))
                    {
                        pageNumber = -1;
                    }
                    else if (pageAction.Equals("go"))
                    {
                        String rpn = HandleParam.replaceChars(request["goPageNumber" + sessionID]);
                        if (rpn.Equals(""))
                        {
                            rpn = "1";
                        }

                        pageNumber = Convert.ToInt32(rpn);
                    }
                }

                if (!wp.Text.Equals(""))
                {
                    whereParam = AES.Decrypt(userID.getUserID(), wp.Text);
                    //換成HashTable
                    form = new Form();
                    form.setWhereParam(whereParam);
                }
            }

            if (whereParam.Equals(""))
            {
                flag = false;
                label.Text = "";
                return null;
            }
        }
        else
        {
            String path = request.CurrentExecutionFilePath;
            String[] arrPath = path.Split('/');
            String task_id = arrPath[arrPath.Length - 2];
            String OLD_TASK = ot.Text;

            wp.Text = "";
            pn.Text = "1";
            ot.Text = task_id;

            whereParam = form.getWhereParam();
        }

        flag = true;

        //取得SQL與參數

        model.doPageBreak(this, form, pbKey);

        //計算總筆數與實際頁數
        searchTotalCount();

        //取得資料
        dao.CommandSQL = cmdSQL;
        dao.OrderSQL = odrSQL;

        if (htParam.Count > 0)
        {
            foreach (string key in htParam.Keys)
            {
                Object obj = htParam[key];
                dao.setParam(key, obj);
            }
        }

        DataSet ds = dao.search(pageRecords, pageNumber);

        //產生分頁控制畫面
        label.Text = makeTag();

        //設定分頁系統資訊
        whereParam = AES.Encrypt(userID.getUserID(), whereParam);
        wp.Text = whereParam;
        pn.Text = pageNumber.ToString();

        return ds;
    }

    /// <summary>
    /// 查詢 (Page Load)
    /// </summary>
    /// <param name="model">Model</param>
    /// <param name="pbKey">String</param>
    /// <returns>DataSet</returns>
    public DataSet doSearch(Model model, String pbKey)
    {
        return doSearch(model, null, pbKey);
    }

    /// <summary>
    /// 取得查詢條件
    /// </summary>
    /// <returns>Form</returns>
    public Form getFormData()
    {
        TextBox wp = (TextBox)thisPage.Master.FindControl("whereParam" + sessionID);
        UserID userID = (UserID)session["UserID"];
        Form form = new Form();
        String whereParam = AES.Decrypt(userID.getUserID(), wp.Text);
        form.setWhereParam(whereParam);

        return form;
    }
}
