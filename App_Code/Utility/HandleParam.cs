using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// 處理各種字串內容，包含替換半形的單引號或數字為全形，將大於小於替換成HTML代碼，中文數字與阿拉伯數字的替換等。
/// </summary>
public class HandleParam
{
	public HandleParam()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
   
    /// <summary>
    ///取得多選的值
    /// </summary>
    /// <param name="obj">ListControl</param>
    /// <returns>多選物件的值，使用分隔符號分隔值</returns>
    public static String getMultiValue(ListControl obj)
    {
        String str = "";

        for (int i = 0; i < obj.Items.Count; i++)
        {
            ListItem li = obj.Items[i];
            if (li.Selected == true)
            {
                //2018/08/31測試查驗結果Checkbox
                String value = li.Value;
                ////if (li.Value == "未填") { }
                //2018/08/31測試查驗結果Checkbox
                if (str.Equals(""))
                {
                    str = value;
                }
                else
                {
                    str = str + Mediator.splitTag + value;
                }
            }
        }

        return str;
    }

   



    /// <summary>
    ///過濾的關鍵詞
    /// </summary>
    /// <param name="replaceStr">String</param>
    /// <returns>過濾的關鍵詞字串</returns>
    public static String[] filterChars()
    {
        string[] replaceString = { "'", "--", "#", "*", "%", " and ", "exec", "insert", "select", "delete", "update", "count", "chr", "mid", 
                                     "master", "truncate", "char", "declare", "union", " AND ", "EXEC", "INSERT", "SELECT", "DELETE", "UPDATE",
                                     "COUNT", "CHR", "MID", "MASTER", "TRUNCATE", "CHAR", "DECLARE", "UNION"};
        return replaceString;
    }
    /// <summary>
    ///將字串裡的單引號取代成全型單引號
    /// </summary>
    /// <param name="replaceStr">String</param>
    /// <returns>取代成全型單引號的字串</returns>
    /// 過濾的關鍵詞包含：單引號、and、exec、insert、select、delete、update、count、*、%、chr、mid、master、truncate、char、declare、union、「--」、「#」。
    public static String replaceChars(String replaceStr)
    {
        for (int i = 0; i < filterChars().Length; i++)
        {
            switch( filterChars()[i])
            {
                case "'":
                    replaceStr = replaceStr.Replace(filterChars()[i], "’");
                    break;
                     case "--":
                    replaceStr = replaceStr.Replace(filterChars()[i], "－－");
                    break;
                     case "#":
                    replaceStr = replaceStr.Replace(filterChars()[i], "＃");
                    break;
                     case "*":
                    replaceStr = replaceStr.Replace(filterChars()[i], "＊");
                    break;
                     case "%":
                    replaceStr = replaceStr.Replace(filterChars()[i], "％");
                    break;
                     case "<":
                    replaceStr = replaceStr.Replace(filterChars()[i], "＜");
                    break;
                     case ">":
                    replaceStr = replaceStr.Replace(filterChars()[i], "＞");
                    break;
                default:
                    replaceStr = replaceStr.Replace(filterChars()[i], "");
                    break;
            }           
        }
        
        return replaceStr;
    }
   
    /// <summary>
    ///將字串裡的大於及小於取代成html代碼
    /// </summary>
    /// <param name="replaceStr">String</param>
    /// <returns>取代成html代碼的字串</returns>
    public static String replaceHtml(String replaceStr)
    {
        replaceStr = replaceStr.Replace("<", "&lt;");
        replaceStr = replaceStr.Replace(">", "&gt;");

        return replaceStr;
    }    

    /// <summary>
    ///將字串裡的有安全顧慮的字元取代掉
    /// </summary>
    /// <param name="replaceStr">String</param>
    /// <returns>取代後的字串</returns>
    public static String reaplce(String replaceStr)
    {
        String str = replaceStr;

        str = replaceChars(str);

        return str;
    }
  
    /// <summary>
    ///將字串裡的國字轉換成數字
    /// </summary>
    /// <param name="replaceStr">String</param>
    /// <returns>轉換後的字串</returns>
    public static String ChineseNum(String replaceStr)
    {
        switch (replaceStr)
        {
            case "一":
                replaceStr = "1";
                break;
            case "二":
                replaceStr = "2";
                break;
            case "三":
                replaceStr = "3";
                break;
            case "四":
                replaceStr = "4";
                break;
            case "五":
                replaceStr = "5";
                break;
            case "六":
                replaceStr = "6";
                break;
            case "七":
                replaceStr = "7";
                break;
            case "八":
                replaceStr = "8";
                break;
            case "九":
                replaceStr = "9";
                break;
            case "十":
                replaceStr = "10";
                break;
            case "十一":
                replaceStr = "11";
                break;
            case "十二":
                replaceStr = "12";
                break;
            case "十三":
                replaceStr = "13";
                break;
            case "十四":
                replaceStr = "14";
                break;
            case "十五":
                replaceStr = "15";
                break;
            case "十六":
                replaceStr = "16";
                break;
            case "十七":
                replaceStr = "17";
                break;
            case "十八":
                replaceStr = "18";
                break;
            case "十九":
                replaceStr = "19";
                break;
        }


        return replaceStr;
    }
    
    /// <summary>
    ///將字串裡的數字轉換成國字
    /// </summary>
    /// <param name="replaceStr">String</param>
    /// <returns>轉換後的字串</returns>
    public static String ToChineseNum(String replaceStr)
    {
        switch (replaceStr)
        {
            case "1":
                replaceStr = "一";
                break;
            case "2":
                replaceStr = "二";
                break;
            case "3":
                replaceStr = "三";
                break;
            case "4":
                replaceStr = "四";
                break;
            case "5":
                replaceStr = "五";
                break;
            case "6":
                replaceStr = "六";
                break;
            case "7":
                replaceStr = "七";
                break;
            case "8":
                replaceStr = "八";
                break;
            case "9":
                replaceStr = "九";
                break;
            case "10":
                replaceStr = "十";
                break;
            case "11":
                replaceStr = "十一";
                break;
            case "12":
                replaceStr = "十二";
                break;
            case "13":
                replaceStr = "十三";
                break;
            case "14":
                replaceStr = "十四";
                break;
            case "15":
                replaceStr = "十五";
                break;
            case "16":
                replaceStr = "十六";
                break;
            case "17":
                replaceStr = "十七";
                break;
            case "18":
                replaceStr = "十八";
                break;
            case "19":
                replaceStr = "十九";
                break;
        }
        return replaceStr;
    }
   
    /// <summary>
    /// 字串前面補零
    /// </summary>
    /// <param name="input">要補零的字串</param>
    /// <param name="num">補0至num位</param>    
    /// <returns>補零後的字串</returns> 
    public static String addZero(String input, int num)
    {
        String str = "";

        if (!input.Equals("")) 
        {
            str = input;
            int length = str.Length;
            for (int i = 0; i < num - length; i++) {
                str = "0" + str;
            }
        }

        return str;
    }

    /// <summary>
    /// 判別字串是否是數字
    /// </summary>
    /// <param name="strNumber">要處理的字串</param>   
    /// <returns>是否是數字</returns> 
    public static bool isNumeric(String strNumber)
    {
        Regex NumberPattern = new Regex("^[0-9]*[0-9][0-9]*$");
        return NumberPattern.IsMatch(strNumber);
    }
    
    /// <summary>
    /// 將小數點後面的0移除，成本統計用，如0.100 -> 0.1
    /// </summary>
    /// <param name="str">要處理的字串</param>   
    /// <returns>處理後的字串</returns> 
    public static String numberFormat(String str)
    {                 
        try
        {  
            if(str.IndexOf(".")!=-1){

                int dp = 0;
                int sub = 0;

                dp = str.Length - str.IndexOf(".")-1;

                for (int i = 1; i <= dp; i++)
                {
                    if (str.Substring(str.Length - i, 1).IndexOf("0") != -1)
                    {
                        sub = i;
                    }
                    else
                    {
                        break;
                    }
                }
                if (sub == dp)
                {
                    sub = dp+1;
                }
                str = str.Substring(0,str.Length - sub);
            }
        }
        catch (Exception)
        {
            
        }         
        return str;
    }
  
    /// <summary>
    ///將字串裡不必要的符號去除
    /// </summary>
    /// <param name="replaceStr">String</param>
    /// <returns>去除不必要符號後的字串</returns>
    public static String replaceSymbol(String replaceStr)
    {
        replaceStr = replaceStr.Replace("*", "");
        replaceStr = replaceStr.Replace("(", "");
        replaceStr = replaceStr.Replace(")", "");
        replaceStr = replaceStr.Replace(";", "");
        replaceStr = replaceStr.Replace("null", "");
        return replaceStr;
    }

    /// <summary>
    /// 檢核密碼是否有需過濾的關鍵詞
    /// </summary>
    /// <param name="str">String</param>
    public static String CheckFilter(string str)
    {
        String errmsg = string.Empty;
        for (int i = 0; i < HandleParam.filterChars().Length; i++)
        {
            if (str.Contains(HandleParam.filterChars()[i]))
            {
                errmsg = "密碼不可輸入" + HandleParam.filterChars()[i];
            }
        }
        return errmsg;
    }
}
