using System;
using System.Collections;

/// <summary>
/// UserID 的摘要描述


/// </summary>
[Serializable]
public class UserID
{
    private String userID;
    private String userName;
    private String userOrg;
	private String userOrg1;
    private String role_name;

    private String userRead;
    private ArrayList tasks, funcs; //,mngs;
    public ArrayList roles;  //Open出來給權限設定時使用
    private String userSys;
    private String crsOrgCode;
    private Int32 crsArea;

    public UserID()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
        roles = new ArrayList();
        tasks = new ArrayList();
        funcs = new ArrayList();
        //mngs = new ArrayList();

    }
    public String getUserID()
    {
        return userID;
    }
    public void setUserID(String userID)
    {
        this.userID = userID;
    }
  
   public String getrole_name()
    {
        return role_name;
    }
    public void setrole_name(String role_name)
    {
        this.role_name = role_name;
    }
    public String getUserName()
    {
        return userName;
    }
    public void setUserName(String userName)
    {
        this.userName = userName;
    }

    public String getUserOrg()
    {
        return userOrg;
    }
    public void setUserOrg(String userOrg)
    {
        this.userOrg = userOrg;
    }
	public String getUserOrg1()
	{
		return userOrg1;
	}
	public void setUserOrg1(String userOrg1)
	{
		this.userOrg1 = userOrg1;
	}
	public String getUserRead()
    {
        return userRead;
    }
    public void setUserRead(String userRead)
    {
        this.userRead = userRead;
    }

    public void setUserSys(String userSys)
    {
        this.userSys = userSys;
    }

    public String getUserSys()
    {
        return userSys;
    }

    public void setCRSOrgCode(String crsOrgCode)
    {
        this.crsOrgCode = crsOrgCode;
    }

    public String getCRSOrgCode()
    {
        return crsOrgCode;
    }

    public void setCRSArea(Int32 iCRSArea)
    {
        this.crsArea = iCRSArea;
    }
    public Int32 getCRSArea()
    {
        return this.crsArea;
        //Int32 iRetValue = 0;

        //switch (this.userOrg)
        //{
        //    //第一區 士林、北投、大同、溝一、溝二
        //    case "TT002I591":
        //    case "TT002I599":
        //    case "TT002I592":
        //    case "TT002I612":
        //    case "TT002I613":
        //        iRetValue = 1;
        //        break;

        //    //第三區 南港、內湖、文山、直屬 
        //    case "TT002I604":    
        //    case "TT002I596":
        //    case "TT002I597":
        //    case "TT002I602":
        //        iRetValue = 3;
        //        break;

        //    //第四區 大安、中正、水肥、掩埋場、萬華、資回
        //    case "TT002I593":
        //    case "TT002I595":     
        //    case "TT002I598":
        //    case "TT002I608":
        //    case "TT002I614":
        //    case "TT002I615":
        //        iRetValue = 4;
        //        break;

        //    //第二區 松山、中山、信義、局本部(所有未包含者)
        //    case "TT002I601":  
        //    case "TT002I594":
        //    case "TT002I603":
        //    default:
        //        iRetValue = 2;
        //        break;
        //}


        //return iRetValue;
    }

    public void addRole(String role)
    {
        if (!roles.Contains(role)) roles.Add(role);
    }
    public void removeRole(String role)
    {
        int index = roles.IndexOf(role);
        if (index >= 0) roles.Remove(index);
    }

    public Boolean hasRole(String role)
    {
        return roles.Contains(role);
    }

    public void addTask(String task)
    {
        if (!tasks.Contains(task)) tasks.Add(task);
    }

    public void removeTask(String task)
    {
        int index = tasks.IndexOf(task);
        if (index >= 0) tasks.Remove(index);
    }

    public Boolean hasTask(String task)
    {
        return tasks.Contains(task);
    }

    public void addFunc(String func)
    {
        if (!funcs.Contains(func)) funcs.Add(func);
    }

    public void removeFunc(String func)
    {
        int index = funcs.IndexOf(func);
        if (index >= 0) funcs.Remove(index);
    }

    public Boolean hasFunc(String func)
    {
        return funcs.Contains(func);
    }
}
