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

/// <summary>
/// AES加解密
/// </summary>
public class AES
{
	public AES()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    /// <summary>
    ///資料加密
    /// </summary>
    /// <param name="key">32位金鑰，不足者會自動補滿</param>
    /// <param name="input">加密資料</param>
    public static String Encrypt(String key, String input)
    {
        key = make32word(key);

        Byte[] keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(key);
        Byte[] toEncryptArray = System.Text.UTF8Encoding.UTF8.GetBytes(input);

        System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
        rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

        System.Security.Cryptography.ICryptoTransform cTransform = rDel.CreateEncryptor();
        Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    /// <summary>
    ///資料解密
    /// </summary>
    /// <param name="key">32位金鑰，不足者會自動補滿</param>
    /// <param name="input">解密資料</param>
    public static String Decrypt(String key, String input)
    {
        key = make32word(key);

        Byte[] keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(key);
        Byte[] toEncryptArray = Convert.FromBase64String(input);

        System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
        rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

        System.Security.Cryptography.ICryptoTransform cTransform = rDel.CreateDecryptor();
        Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return System.Text.UTF8Encoding.UTF8.GetString(resultArray);
    }

    /// <summary>
    ///確認金鑰長度，不滿者補足，過長者截短
    /// </summary>
    /// <param name="input">32位金鑰</param>
    private static String make32word(String input)
    {
        String str = "";

        if (input.Length > 32)
        {
            str = input.Substring(0, 32);
        }
        else
        {
            str = input;
            for (int i = 0; i < 32 - input.Length; i++)
            {
                str = str + "0";
            }
        }

        return str;
    }
}
