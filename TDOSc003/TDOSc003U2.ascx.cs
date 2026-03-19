using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TDOSc003_TDOSc003U2 : System.Web.UI.UserControl
{
    public string WorkItem
    {
        get { return this.work_item.Value; }
        set
        {
            this.work_item.Value = value;

        }
    }

    public string WorkType
    {
        get { return this.work_type.Value; }
        set
        {
            this.work_type.Value = value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //genWorkItemLevel1(sender, e);
    }


    public void setWorkTypeChange(String sWorkType, object sender, EventArgs e)
    {
        this.work_type.Value = sWorkType;
        genWorkItemLevel1(sender, e);
    }


    /// <summary>
    /// 作業項目第一層選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void genWorkItemLevel1(object sender, EventArgs e)
    {
        HtmlTag hTag = new HtmlTag();

        if (work_type.Value.Equals("C"))
            hTag.createMediatorSelect("CAR_WITEM_L1", work_item_lvl1, "", "請選擇", 0);
        else
            hTag.createMediatorSelect("MCHN_WITEM_L1", work_item_lvl1, "", "請選擇", 0);

        work_item_lvl1_SelectedIndexChanged(sender, e);
    }


    /// <summary>
    /// 作業項目第二層選單
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void work_item_lvl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        HtmlTag hTag = new HtmlTag();
        work_item_lvl2.Items.Clear();

        if (!work_item_lvl1.SelectedValue.Equals(""))
            hTag.createMediatorSelect(work_item_lvl1.SelectedValue, work_item_lvl2, "", "請選擇", 0);
        else
        {
            ListItem li = new ListItem();
            li.Value = "";
            li.Text = "請選擇";
            work_item_lvl2.Items.Add(li);
        }
    }
}