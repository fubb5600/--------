using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;


/// <summary>
/// IniValue 的摘要描述
/// </summary>
public class IniValue
{
    //網頁名稱
    public const String WebName = "秘書室油料管理系統";
    public const String CRSWebName = "車輛維修作業系統";

    //日期驗證設定
    public const String dateFormat = DateTransfer.YYY_MM_DD;
    public const String dateTag = "/";
    //分頁設定
    public const int PB_COUNT = 2;
    //系統訊息設定
    public const Boolean isAlertMsg = false;

    public const String sysCRS = "CRS";

    public const String ChgRsnR1 = "R1";
    public const String ChgRsnR2 = "R2";
    public const String ChgRsnR4 = "R4";
    public const String ChgRsnR5 = "R5";
    public const String ChgRsnR6 = "R6";

    //public const String CRSChgRsn = "R4";

    //不要儲存資料的識別字串
    public const String noSave = "NoSave";

	public IniValue()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    //特殊情況使用
    public static void getInstance()
    {

    }


}
