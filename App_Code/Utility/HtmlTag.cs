using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// HtmlTag 的摘要描述

/// </summary>
public class HtmlTag
{
	public HtmlTag()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    /// <summary>
    ///從ArrayList產生Select、CheckBox、Radio的選項資料
    ///<param name="al">選單內容的ArrayList</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>
    ///<param name="defaultItem">預設空白選項顯示的文字</param>
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary>    
    protected void createItems(ArrayList al, ListControl obj, String defaultValue, String defaultItem, int showType)
    {
        Boolean setDefault = false;
        //先清除所有Items
        obj.Items.Clear();

        int count = al.Count;
        if (count == 0)
        {
            ListItem li = new ListItem("--無選項--", "");
            obj.Items.Add(li);
        }
        else
        {
            if (!defaultValue.Equals(""))
            {
                setDefault = true;
                defaultValue = Mediator.splitTag + defaultValue + Mediator.splitTag;
            }

            if (!defaultItem.Equals(""))
            {
                ListItem li = new ListItem(defaultItem, "");
                obj.Items.Add(li);
            }

            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];
                //String[] arr = new String[ht.Count];

                //ht.Values.CopyTo(arr, 0);

                //String value = arr.GetValue(0).ToString();
                //String text = arr.GetValue(1).ToString();

                String value = ht["PVALUE"].ToString();
                String text = ht["PTEXT"].ToString();

                if (showType == 1)
                {
                    text = text + "(" + value + ")";
                }
                else if (showType == 2)
                {
                    text = value + "(" + text + ")";
                }
                else
                {
                    //只顯示中文


                }

                if (!text.Contains("已停用"))
                {

                    ListItem li = new ListItem(text, value);
                    if (setDefault)
                    {
                        String check = Mediator.splitTag + value + Mediator.splitTag;
                        if (defaultValue.IndexOf(check) != -1)
                        {
                            li.Selected = true;
                        }
                        else
                        {
                            li.Selected = false;
                        }
                    }

                    obj.Items.Add(li);
                }
            }
        }
    }
  
    /// <summary>
    ///產生Select選項
    ///<param name="al">選單內容的ArrayList</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>
    ///<param name="defaultItem">預設空白選項顯示的文字</param>
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary>  
    public void createSelect(ArrayList al, DropDownList obj, String defaultValue, String defaultItem, int showType)
    {
        createItems(al, obj, defaultValue, defaultItem, showType);
    }

    
    /// <summary>
    ///產生CheckBox選項
    ///<param name="al">選單內容的ArrayList</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>   
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary>  
    public void createCheckBox(ArrayList al, CheckBoxList obj, String defaultValue, int showType)
    {
        createItems(al, obj, defaultValue, "", showType);
    }
    
    /// <summary>
    ///產生Radio選項
    ///<param name="al">選單內容的ArrayList</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>   
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary>  
    public void createRadio(ArrayList al, RadioButtonList obj, String defaultValue, int showType)
    {
        createItems(al, obj, defaultValue, "", showType);
    }
   
    /// <summary>
    ///產生Select選項
    ///<param name="al">選單內容的ArrayList</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>   
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary>  
    public void createLbox(ArrayList al, ListBox obj, String defaultValue, String defaultItem, int showType)
    {
        createItems(al, obj, defaultValue, "", showType);
    }
    
    /// <summary>
    ///從Mediator產生Select、CheckBox、Radio的選項資料
    ///<param name="PARAM_TYPE">參數類別</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>
    ///<param name="defaultItem">預設空白選項顯示的文字</param>
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary>  
    protected void createMediatorItems(String PARAM_TYPE, ListControl obj, String defaultValue, String defaultItem, int showType)
    {
        Mediator med = Mediator.getInstance(false);

        Boolean setDefault = false;
        //先清除所有Items
        obj.Items.Clear();

        int count = med.getParamTypeCount(PARAM_TYPE);
        if (count == 0)
        {
            ListItem li = new ListItem("--無選項--", "");
            obj.Items.Add(li);
        }
        else
        {
            if (!defaultValue.Equals(""))
            {
                setDefault = true;
                defaultValue = Mediator.splitTag + defaultValue + Mediator.splitTag;
            }

            if (!defaultItem.Equals(""))
            {
                ListItem li = new ListItem(defaultItem, "");
                obj.Items.Add(li);
            }



            for (int i = 0; i < count; i++)
            {
                String value = med.getParamTypeID(PARAM_TYPE, i);
                String text = med.lookupParamName(PARAM_TYPE, value, 0);

                if (showType == 1)
                {
                    text = text + "(" + value + ")";
                }
                else if (showType == 2)
                {
                    text = value + "(" + text + ")";
                }
                else
                {
                    //只顯示中文


                }
                if (!text.Contains("已停用"))
                {
                    ListItem li = new ListItem(text, value);
                    if (setDefault)
                    {
                        String check = Mediator.splitTag + value + Mediator.splitTag;
                        if (defaultValue.IndexOf(check) != -1)
                        {
                            li.Selected = true;
                        }
                        else
                        {
                            li.Selected = false;
                        }
                    }

                    obj.Items.Add(li);
                }
            }
        }
    }

    /// <summary>
    ///從Mediator產生Select、CheckBox、Radio的選項資料
    ///</summary> 
    ///<param name="PARAM_TYPE">參數類別</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>
    ///<param name="defaultItem">預設空白選項顯示的文字</param>
    ///<param name="displayValue">要顯示的選項</param>
    ///<param name="showType">顯示類別0、1、2</param>
    ///  
    protected void createMediatorItems(String PARAM_TYPE, ListControl obj, String defaultValue, String defaultItem,String displayValue, int showType)
    {
        Mediator med = Mediator.getInstance(false);

        Boolean setDefault = false;
        //先清除所有Items
        obj.Items.Clear();

        int count = med.getParamTypeCount(PARAM_TYPE);
        if (count == 0)
        {
            ListItem li = new ListItem("--無選項--", "");
            obj.Items.Add(li);
        }
        else
        {
            if (!defaultValue.Equals(""))
            {
                setDefault = true;
                defaultValue = Mediator.splitTag + defaultValue + Mediator.splitTag;
            }

            if (!defaultItem.Equals(""))
            {
                ListItem li = new ListItem(defaultItem, "");
                obj.Items.Add(li);
            }
            if (!displayValue.Equals(""))
            {
                displayValue = Mediator.splitTag + displayValue + Mediator.splitTag;
            }


            for (int i = 0; i < count; i++)
            {
                String value = med.getParamTypeID(PARAM_TYPE, i);
                String text = med.lookupParamName(PARAM_TYPE, value, 0);

                if (showType == 1)
                {
                    text = text + "(" + value + ")";
                }
                else if (showType == 2)
                {
                    text = value + "(" + text + ")";
                }
                else
                {
                    //只顯示中文



                }

                if (!text.Contains("已停用"))
                {
                    ListItem li = new ListItem(text, value);
                    String check = Mediator.splitTag + value + Mediator.splitTag;
                    if (setDefault)
                    {

                        if (defaultValue.IndexOf(check) != -1)
                        {
                            li.Selected = true;
                        }
                        else
                        {
                            li.Selected = false;
                        }
                    }

                    obj.Items.Add(li);
                }
            }
        }
    }

    /// <summary>
    ///從Mediator產生Select的選項資料
    ///<param name="PARAM_TYPE">參數類別</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>
    ///<param name="defaultItem">預設空白選項顯示的文字</param>
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary> 
    public void createMediatorSelect(String PARAM_TYPE, DropDownList obj, String defaultValue, String defaultItem, int showType)
    {
        createMediatorItems(PARAM_TYPE, obj, defaultValue, defaultItem, showType);
    }

    /// <summary>
    ///從Mediator產生CheckBox的選項資料
    ///<param name="PARAM_TYPE">參數類別</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>    
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary> 
    public void createMediatorCheckBox(String PARAM_TYPE, CheckBoxList obj, String defaultValue, int showType)
    {
        createMediatorItems(PARAM_TYPE, obj, defaultValue, "", showType);
    }
    
    ///<summary>
    ///從Mediator產生CheckBox的選項資料(可控制要顯示的選項)
    ///</summary> 
    ///<param name="PARAM_TYPE">參數類別</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param> 
    ///<param name="displayValue">要顯示的項目</param> 
    ///<param name="showType">顯示類別0、1、2</param>
    /// 
    
    public void createMediatorCheckBox(String PARAM_TYPE, CheckBoxList obj, String defaultValue, String displayValue, int showType)
    {
        createMediatorItems(PARAM_TYPE, obj, defaultValue, "", displayValue, showType);
    }
    /// <summary>
    ///從Mediator產生Radio的選項資料
    ///<param name="PARAM_TYPE">參數類別</param>
    ///<param name="obj">要產生選項的物件</param>
    ///<param name="defaultValue">預設值</param>   
    ///<param name="showType">顯示類別0、1、2</param>
    /// </summary> 
    public void createMediatorRadio(String PARAM_TYPE, RadioButtonList obj, String defaultValue, int showType)
    {
        createMediatorItems(PARAM_TYPE, obj, defaultValue, "", showType);
    }

    public void createMediatorSelect(string selectedValue, ListBox work_item_lvl2, string v1, string v2, int v3)
    {
        throw new NotImplementedException();
    }
}
