using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// TDOS 的摘要描述
/// </summary>
public class TDOS
{
    public ArrayList keep_org;

    public TDOS()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }


    /// <summary>
    /// 判斷加油資料資料登打是否鎖定
    /// </summary>
    /// <param name="deal_date"></param>
    /// <returns></returns>
    public Boolean IsKeyDateLock(String target_date, String user_id, String unlock_type)
    {
        Boolean flag = true;
        DBDAO dao = new DBDAO();
        Int32 key_date = 1;
        try
        {
            dao.open();

            ParamModel model = new ParamModel();
            model.dao = dao;
            DataSet ds = model.selectBasicParam();
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                key_date = Convert.ToInt32(dr["key_date"].ToString()) + 1;
            }
            DateTime deal_dt = Convert.ToDateTime(DateTransfer.c_date_trans(target_date));
            DateTime lock_date = deal_dt.AddMonths(1);
            if (lock_date.Month == 2)
            {
                try
                { lock_date = new DateTime(lock_date.Year, lock_date.Month, key_date); }
                catch
                {
                    lock_date = new DateTime(lock_date.Year, 3, 1);
                    lock_date = lock_date.AddDays(-1);
                }
            }
            else
            {
                lock_date = new DateTime(lock_date.Year, lock_date.Month, key_date);
            }
            if (lock_date <= DateTime.Now)
            {
                flag = false;
            }

            #region
            if (flag == false) //已鎖定時確認有無授權解鎖資料
            {
                Form form = new Form();
                form.setValue("user_id", user_id);
                form.setValue("unlock_type", unlock_type);
                form.setValue("target_date", DateTransfer.c_date_trans(target_date));
                flag = model.IsUnlock(form);
            }
            #endregion
        }
        catch { flag = false; }
        finally
        {
            dao.close();
        }

        return flag;

    }

    /// <summary>
    /// 單位代碼的英文簡碼
    /// </summary>
    /// <param name="dep_org"></param>
    /// <returns></returns>
    public String getSimpleDepNo(String dep_org)
    {
        string simple_dep = "";

        switch (dep_org)
        {
            case "TT002I591": // 士林區清潔隊
                simple_dep = "A";
                break;
            case "TT002I592": // 大同區清潔隊
                simple_dep = "B";
                break;
            case "TT002I593": // 大安區清潔隊
                simple_dep = "C";
                break;
            case "TT002I594": // 中山區清潔隊
                simple_dep = "D";
                break;
            case "TT002I595": // 中正區清潔隊
                simple_dep = "E";
                break;
            case "TT002I596": //	內湖區清潔隊
                simple_dep = "F";
                break;
            case "TT002I597": //	文山區清潔隊
                simple_dep = "G";
                break;
            case "TT002I598": //	水肥隊
                simple_dep = "H";
                break;
            case "TT002I599": //	北投區清潔隊
                simple_dep = "I";
                break;
            case "TT002I601": //	松山區清潔隊
                simple_dep = "K";
                break;
            case "TT002I602": //	直屬清潔隊
                simple_dep = "L";
                break;
            case "TT002I603": //	信義區清潔隊
                simple_dep = "M";
                break;
            case "TT002I604": //	南港區清潔隊
                simple_dep = "N";
                break;
            case "TT002I608": //	掩埋場
                simple_dep = "O";
                break;
            case "TT002I612": //	溝渠一隊
                simple_dep = "P";
                break;
            case "TT002I613": //	溝渠二隊
                simple_dep = "Q";
                break;
            case "TT002I614": //	萬華區清潔隊
                simple_dep = "R";
                break;
            case "TT002I615": //	資源回收隊
                simple_dep = "S";
                break;
            default:
                simple_dep = "J";
                break;
        }
        return simple_dep;
    }

    /// <summary>
    /// 轉換成區域代碼
    /// </summary>
    /// <param name="dep_org"></param>
    /// <returns></returns>
    public Int32 getCRSArea(String dep_org)
    {
        Int32 iRetValue = 0;

        switch (dep_org)
        {
            //第一區 士林、北投、大同、溝一、溝二
            case "TT002I591":
            case "TT002I599":
            case "TT002I592":
            case "TT002I612":
            case "TT002I613":
                iRetValue = 1;
                break;

            //第三區 南港、內湖、文山、直屬 
            case "TT002I604":
            case "TT002I596":
            case "TT002I597":
            case "TT002I602":
                iRetValue = 3;
                break;

            //第四區 大安、中正、水肥、掩埋場、萬華、資回
            case "TT002I593":
            case "TT002I595":
            case "TT002I598":
            case "TT002I608":
            case "TT002I614":
            case "TT002I615":
                iRetValue = 4;
                break;

            //第二區 松山、中山、信義、局本部(所有未包含者)
            case "TT002I601":
            case "TT002I594":
            case "TT002I603":
            default:
                iRetValue = 2;
                break;
        }


        return iRetValue;
    }

    public static string formatDateTimeForm(string v)
    {
        throw new NotImplementedException();
    }



    /// <summary>
    /// 日期時分輸出一個西元年字串
    /// </summary>
    /// <param name="strDate"></param>
    /// <param name="strHH"></param>
    /// <param name="strMM"></param>
    /// <returns></returns>
    public static String formatDateTimeForm(String strDate, String strHH, String strMM)
    {
        String retValue = "";
        strDate = strDate.Trim();
        strHH = strHH.Trim();
        strMM = strMM.Trim();

        if (strDate != string.Empty && strHH != string.Empty && strMM != string.Empty)
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(strDate.Trim()) + " " +
              HandleParam.addZero(strHH.Trim(), 2) + ":" + HandleParam.addZero(strMM.Trim(), 2) + ":00");
            retValue = dt.ToString("yyyy/MM/dd HH:mm:ss");
        }
        else if (strDate != string.Empty && (strHH == string.Empty || strMM == string.Empty))
        {
            DateTime dt = Convert.ToDateTime(DateTransfer.c_date_trans(strDate.Trim()) + " 00:00:00");
            retValue = dt.ToString("yyyy/MM/dd HH:mm:ss");
        }

        return retValue;
    }
}