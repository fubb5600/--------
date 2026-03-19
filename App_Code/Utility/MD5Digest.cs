using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// MD5加密
/// </summary>
public class MD5Digest
{
	public MD5Digest()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
 
    /// <summary>
    /// MD5加密
    /// </summary>     
    /// <param name="str">要加密的字串</param>  
    /// <returns>MD5加密後的字串</returns>   
    public static string GetMD5(string str)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        return BitConverter.ToString(b).Replace("-", string.Empty);
    }
}
