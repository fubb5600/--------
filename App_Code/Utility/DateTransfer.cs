using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// DateTransfer 的摘要描述

/// </summary>
public class DateTransfer
{
    public const String YYYY_M_D = "1";
    public const String YYY_M_D = "2";
    public const String YYYY_MM_DD = "3";
    public const String YYY_MM_DD = "4";
    //public const String YYYY_M = "5";
    //public const String YYYY_MM = "6";
    //public const String YYY_M = "7";
    public const String YYY_MM = "8";
    public const String YYYY = "9";
    public const String YYY = "10";
    public const String YYY_MM_DD_HHMM = "23";
    public const String HHMI = "24";
    public const String YYYyMMmDDd = "5";

	public DateTransfer()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public static String getNow(String outSplit, String dateFormate)
    {
        string outStr = "";

        DateTime now = DateTime.Now;
        outStr = transferFormate(now, outSplit, dateFormate);
        
        return outStr;
    }


    /// <summary>
    ///將民國日期時間轉換成DateTime
    ///例: 099/05/02 01:01  ->  DateTime
    /// </summary>
    /// <param name="input">String</param>
    /// <param name="split">String</param>
    /// <returns>DateTime</returns>
    public static DateTime to_datetime(String date)
    {
        date = date.Replace("/", "");
        date = date.Replace(":", "");

        if (!date.Substring(8, 2).Equals("24"))
        {
            DateTime ret = new DateTime((Convert.ToInt16(date.Substring(0, 3)) + 1911), Convert.ToInt16(date.Substring(3, 2)), Convert.ToInt16(date.Substring(5, 2)), Convert.ToInt16(date.Substring(8, 2)), Convert.ToInt16(date.Substring(10, 2)), 0);
            return ret;
        }
        else
        {
            DateTime ret = new DateTime((Convert.ToInt16(date.Substring(0, 3)) + 1911), Convert.ToInt16(date.Substring(3, 2)), Convert.ToInt16(date.Substring(5, 2)), 0 , Convert.ToInt16(date.Substring(10, 2)), 0).AddDays(1);
            return ret;
        }
    }
    
    /// <summary>
    ///將民國日期格式轉西元日期格式
    ///例: 99/5/2  ->  2010/05/02
    /// </summary>
    /// <param name="input">String</param>
    /// <param name="split">String</param>
    /// <returns>String</returns>
    public static String c_date_trans(String cdate)
    {
        String yy, mm, dd;
        yy = cdate.Substring(0, cdate.IndexOf("/"));
        mm = cdate.Substring(cdate.IndexOf("/") + 1, cdate.LastIndexOf("/") - cdate.IndexOf("/") - 1);
        dd = cdate.Substring(cdate.LastIndexOf("/") + 1, cdate.Length - cdate.LastIndexOf("/") - 1);
        mm = addZero(mm, 2);
        dd = addZero(dd, 2);
        yy = Convert.ToString(Convert.ToInt32(yy) + 1911);
        return yy + "/" + mm + "/" + dd;
    }

    /// <summary>
    ///將民國日期格式正規化 
    ///例:98/3/2 -> 098/03/02
    /// </summary>
    /// <param name="input">String</param>
    /// <param name="split">String</param>
    /// <returns>String</returns>
    public static String c_date_Normal(String cdate)
    {
        String yy, mm, dd;
        yy = cdate.Substring(0, cdate.IndexOf("/"));
        mm = cdate.Substring(cdate.IndexOf("/") + 1, cdate.LastIndexOf("/") - cdate.IndexOf("/") - 1);
        dd = cdate.Substring(cdate.LastIndexOf("/") + 1, cdate.Length - cdate.LastIndexOf("/") - 1);
        mm = addZero(mm, 2);
        dd = addZero(dd, 2);
        yy = addZero(yy, 3);
        return yy + "/" + mm + "/" + dd;
    }
    /// <summary>
    ///將民國日期格式 加N小時
    /// </summary>
    /// <param name="input">String</param>
    /// <param name="split">String</param>
    /// <returns>String</returns>
    public static String c_date_add(String cdate, int n)
    {
        String yy, mm, dd, min, hh;
        yy = cdate.Substring(0, cdate.IndexOf("/"));
        mm = cdate.Substring(cdate.IndexOf("/") + 1, 2);
        dd = cdate.Substring(cdate.LastIndexOf("/") + 1, 2);
        hh = cdate.Substring(cdate.LastIndexOf("/") + 4, 2);
        min = cdate.Substring(cdate.Length - 2, 2);
        hh = "" + ((Convert.ToInt16(hh) + n) % 24);
        dd = "" + (Convert.ToInt16(dd) + ((Convert.ToInt16(hh) + n) / 24));
        if (cdate.Substring(cdate.Length - 3, 1).Equals(":"))
        {
            return yy + "/" + mm + "/" + dd + " " + hh + ":" + min;
        }
        else
        {
            return yy + "/" + mm + "/" + dd + " " + hh + "" + min;
        }
    }
    /// <summary>
    ///將西元日期格式轉民國日期格式
    ///例: 2010/05/02 -> 099/5/2  
    /// </summary>
    /// <param name="input">String</param>
    /// <param name="split">String</param>
    /// <returns>String</returns>
    public static String c_date_intrans(String cdate)
    {
        String yy, mm, dd;
        yy = cdate.Substring(0, cdate.IndexOf("/"));
        mm = cdate.Substring(cdate.IndexOf("/") + 1, cdate.LastIndexOf("/") - cdate.IndexOf("/") - 1);
        dd = cdate.Substring(cdate.LastIndexOf("/") + 1, cdate.Length - cdate.LastIndexOf("/") - 1);
        mm = DateTransfer.addZero(mm, 2);
        dd = DateTransfer.addZero(dd, 2);
        yy = Convert.ToString(Convert.ToInt32(yy) - 1911);
        for (int i = 1; i <= 3 - yy.Length; i++)
        {
            yy = "0" + yy;
        }
        return yy + "/" + mm + "/" + dd;
    }
     /// <summary>
    /// 資料庫日期轉換(西元->民國, 或其他格式)
    /// </summary>
    /// <param name="input">DateTime</param>
    /// <param name="split">String</param>
    /// <returns>String</returns>
    /// <author>Lucy</author>
    public static string transferFormate(string input, String outSplit, String dateFormate)
    {
        string outStr = "";
        if (input != "")
        {
            DateTime inputDT = Convert.ToDateTime(input);
            outStr = transferFormate(inputDT, outSplit, dateFormate);
        }
        return outStr;
    }

   /// <summary>
    /// 資料庫日期轉換(西元->民國, 或其他格式)
    /// </summary>
    /// <param name="input">DateTime</param>
    /// <param name="split">String</param>
    /// <returns>String</returns>
    /// <author>Lucy</author>
    public static string transferFormate(DateTime input, String outSplit, String dateFormate)
    {
        String inputDate = input.ToString("yyyy/MM/dd");
        String outDate = "";

        if (inputDate != "")
        {
            String[] inDate = inputDate.Split(char.Parse("/"));
            String year = inDate[0];
            String TWyear = addZero(Convert.ToString(Convert.ToInt32(inDate[0]) - 1911), 3);
            String MM = inDate[1];
            String DD = inDate[2];

            String inputDate2 = input.ToString("yyyy/M/d");
            String[] inDate2 = inputDate2.Split(char.Parse("/"));
            String M = inDate2[1];
            String D = inDate2[2];

            String inputTime = input.ToString("HH:mm:ss");
            String[] inTime = inputTime.Split(char.Parse(":"));
            string HH = inTime[0];
            string mm = inTime[1];
            string ss = inTime[2];

            switch (dateFormate)
            {
                case YYYY_MM_DD:
                    return year + outSplit + MM + outSplit + DD;
                case YYY_MM_DD:
                    return TWyear + outSplit + MM + outSplit + DD;
                case YYYY_M_D:
                    return year + outSplit + M + outSplit + D;
                case YYY_M_D:
                    return TWyear + outSplit + M + outSplit + D;
                //case YYYY_M:
                //    return year + outSplit + M;
                //case YYYY_MM:
                //    return year + outSplit + MM;
                //case YYY_M:
                //    return TWyear + outSplit + M;
                case YYYY:
                    return year;                    
                case YYY:
                    return TWyear;
                case YYY_MM:
                    return TWyear + outSplit + MM;
                case YYY_MM_DD_HHMM:
                    return TWyear + outSplit + MM + outSplit + DD + " " + HH + ":" + mm + ":" + ss;
                case HHMI:
                    return HH + mm;
                case YYYyMMmDDd:
                    return TWyear + "年" + MM + "月" + DD + "日";
                    break;
            }
        }
        return outDate;
    }
    
    public static String addZero(String input, int num)
    {
        String str = "";

        if (!input.Equals(""))
        {
            str = input;
            int length = str.Length;
            for (int i = 0; i < num - length; i++)
            {
                str = "0" + str;
            }
        }

        return str;
    }

    public static String GetDayOfWeek(String str){
         String returnStr = "";
        if (str.Equals("0"))
        {
            returnStr = "日";
        }
        else if (str.Equals("1"))
        {
            returnStr = "一";
        }
        else if (str.Equals("2"))
        {
            returnStr = "二";
        }
        else if (str.Equals("3"))
        {
            returnStr = "三";
        }
        else if (str.Equals("4"))
        {
            returnStr = "四";
        }
        else if (str.Equals("5"))
        {
            returnStr = "五";
        }
        else if (str.Equals("6"))
        {
            returnStr = "六";
        }
        return returnStr;
    }

    //找每月第一天是星期幾(year為西元年)
    //回傳結果為0-6,0代表星期天

    public static int GetDayOfMonth(String year,String month)
    {
        DateTime dt = Convert.ToDateTime(year+"-"+month+"-1");

        return dt.DayOfWeek.GetHashCode();
    }

    //找某年某月有幾天(year為西元年)
    public static int GetDaysInMonth(String year, String month)
    {
        DateTime dt = Convert.ToDateTime(year + "-" + month + "-1");

        return DateTime.DaysInMonth(dt.Year, dt.Month);
    }

    //取得某年某月份相關資料(year為西元年)
    //dom 此月第一天是星期幾,回傳結果為0-6,0代表星期天

    //dim 此月有幾天

    //wim 此月有幾周

    public static Hashtable GetMonthData(String year, String month)
    {
        Hashtable ht = new Hashtable();

        int dom = DateTransfer.GetDayOfMonth(year, month);
        int dim = DateTransfer.GetDaysInMonth(year, month);
        double weeks = double.Parse((dim - (7 - dom)).ToString())/ 7;
        int wim = int.Parse(Math.Ceiling(weeks).ToString()) + 1;

        ht.Add("dom", dom);
        ht.Add("dim", dim);
        ht.Add("wim", wim);

        return ht;
    }

    /// <summary>
    /// 計算2日期時間的時數，
    /// </summary>
    /// <param name="start_date">yyy/MM/dd</param>
    /// <param name="end_date">yyy/MM/dd</param>
    /// <param name="start_time">hhmi</param>
    /// <param name="end_time">hhmi</param>
    /// <param name="workHr">每日工作時數</param>
    /// <returns></returns>
    /// <author>Lucy</author>
    public static double cntHours(string start_date, string end_date, string start_time, string end_time, int workHr)
    {
        double hours = 0.0;

        string startDTs = DateTransfer.c_date_trans(start_date) + " " + start_time.Substring(0, 2) + ":" + start_time.Substring(2, 2);
        DateTime startDT = Convert.ToDateTime(startDTs);
        string endDTs = DateTransfer.c_date_trans(end_date) + " " + end_time.Substring(0, 2) + ":" + end_time.Substring(2, 2);
        DateTime endDT = Convert.ToDateTime(endDTs);

        TimeSpan diff = endDT - startDT;

        //int workHr = 8;
        hours = (diff.Days * workHr + diff.Hours + double.Parse(diff.Minutes.ToString()) / 60.0);

        return hours;
    }

    /// <summary>
    /// 計算2日期時間的時數，
    /// </summary>
    /// <param name="start_date">yyy/MM/dd</param>
    /// <param name="start_time">hhmi</param>
    /// <param name="end_time">hhmi</param>
    /// <param name="workHr">每日工作時數</param>
    /// <returns></returns>
    /// <author>Lucy</author>
    public static double cntHours(string start_date, string start_time, string end_time, int workHr)
    {

        string end_date = start_date;
        if (start_time.CompareTo(end_time) > 0)
        {
            DateTime endDT = Convert.ToDateTime(DateTransfer.c_date_trans(end_date));
            end_date = DateTransfer.transferFormate(endDT.AddDays(1).ToString("yyyy/MM/dd"), IniValue.dateTag, IniValue.dateFormat);
        }

        return cntHours(start_date, end_date, start_time, end_time, workHr);
    }

    /// <summary>
    /// 計算2日期間的天數
    /// </summary>
    /// <param name="start_date">yyy/MM/dd</param>
    /// <param name="end_date">yyy/MM/dd</param>
    /// 例：1/1~1/3 = 2天

    /// <returns></returns>
    /// <author>Alex</author>
    public static int cntDays(string start_date, string end_date)
    {
        TimeSpan ts1 = new TimeSpan(DateTransfer.to_datetime(start_date + " 00:00").Ticks);
        TimeSpan ts2 = new TimeSpan(DateTransfer.to_datetime(end_date + " 00:00").Ticks);
        TimeSpan ts = ts1.Subtract(ts2).Duration();

        return ts.Days;
    }

    /// <summary>
    /// 計算2日期間的月數(有包含頭尾)
    /// </summary>
    /// <param name="start_date">yyyy/MM/dd</param>
    /// <param name="end_date">yyyy/MM/dd</param>
    /// <returns></returns>
    /// <author>Alex</author>
    public static int cntMonths(string start_date, string end_date)
    {
        DateTime sDate = DateTime.Parse(start_date);
        DateTime eDate = DateTime.Parse(end_date);

        int months = (eDate.Year - sDate.Year) * 12 + (eDate.Month - sDate.Month) + 1;

        return months;
    }

    /// <summary>
    /// 計算2日期區間交集的天數(期尾也算一整天)
    /// </summary>
    /// <param name="start_date1">yyyy/MM/dd</param>
    /// <param name="end_date1">yyyy/MM/dd</param>
    /// <param name="start_date2">yyyy/MM/dd</param>
    /// <param name="end_date2">yyyy/MM/dd</param>
    /// <returns></returns>
    /// <author>Alex</author>
    public static int cntCrossDays(string start_date1, string end_date1, string start_date2, string end_date2)
    {
        DateTime SD1 = DateTime.Parse(start_date1);
        DateTime ED1 = DateTime.Parse(end_date1).AddDays(1);

        DateTime SD2 = DateTime.Parse(start_date2);
        DateTime ED2 = DateTime.Parse(end_date2).AddDays(1);

        int days = 0;

        //P1 完全包含P2 ==> 交集為P2
        if (SD1 <= SD2 && ED1 >= ED2)
        {
            TimeSpan ts1 = new TimeSpan(SD2.Ticks);
            TimeSpan ts2 = new TimeSpan(ED2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            days = ts.Days;
        }
        else 
        //P2 完全包含P1 ==> 交集為P1
        if (SD2 <= SD1 && ED2 >= ED1)
        {
            TimeSpan ts1 = new TimeSpan(SD1.Ticks);
            TimeSpan ts2 = new TimeSpan(ED1.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            days = ts.Days;
        }
        else
        //交集
        if (SD1 < SD2 && ED1 > SD2)
        {
            TimeSpan ts1 = new TimeSpan(SD2.Ticks);
            TimeSpan ts2 = new TimeSpan(ED1.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            days = ts.Days;
        }
        else
        if (SD1 > SD2 && ED2 > SD1)
        {
            TimeSpan ts1 = new TimeSpan(SD1.Ticks);
            TimeSpan ts2 = new TimeSpan(ED2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            days = ts.Days;
        }

        return days;
    }
}
