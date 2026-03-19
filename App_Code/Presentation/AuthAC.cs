using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;

/// <summary>
/// AuthAC 的摘要描述
/// </summary>
public class AuthAC
{
    public AuthAC()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public UserID authUserData(String userName, String userPasswd)
    {
        UserID userbean = null;
        DBDAO dao = new DBDAO();
        Boolean flag = true;
        TDOS tdos = new TDOS();
        try
        {
            //flag = IsAuthenticatedNt(userName, userPasswd);

            if (flag)
            {
                dao.open();

                String sql = "select  a.user_id as USER_ID,role_name, Password as user_passwd, UserName as user_name,d.[group] as user_org,user_org as user_org1, " +
                    "user_read   ,a.[create_user] as [create_user] ,c.[role_id]  from a_user_mst a " +
                    "left join " + dao.DepDB() + "..Users b on a.user_id = b.UserId and b.state = '1'   left join [a_user_role] C on   a.user_id = c.user_id left join [a_role_mst] D   on c.[role_id]=d.[role_id]" +
                    "where a.user_id = @user_id and a.status='O'";
                
                //string table = "a_user_mst";
                //string sql = string.Format("select [user_id],[user_passwd],[user_name],[user_org],[user_read] from {0} where [user_id] = @user_id and status = @status",table);
                dao.CommandSQL = sql;
                dao.setParam("@user_id", userName);
                //dao.setParam("@status", 'O');
                ArrayList al = dao.search();               
                dao.getSQL();
                int i = al.Count;

                if (al.Count == 0)
                {
                    //帳號錯誤
                }
                else
                {

                    Hashtable ht = (Hashtable)al[0];

                    userName = userName.ToUpper();
                    
                    if (userPasswd.ToUpper().Equals(ht["USER_PASSWD"].ToString().ToUpper()))
                    {
                        userbean = new UserID();

					if(ht["USER_READ"].ToString()=="ALL")
                        {
							ht["USER_ORG"] = "TT002I591,TT002I592,TT002I593,TT002I594,TT002I595,TT002I596,TT002I597,TT002I598,TT002I599,TT002I600,TT002I601,TT002I602,TT002I603,TT002I604,TT002I605,TT002I606,TT002I607,TT002I608,TT002I609,TT002I610,TT002I611,TT002I612,TT002I613,TT002I614,TT002I615,TT002I617,TT002I619,TT002I620,TT002I621,TT002I622,TT002I623";


						}

						if (ht["USER_READ"].ToString() == "SELF")
						{
							ht["USER_ORG"] = ht["USER_ORG1"].ToString();


						}



						userbean.setUserID(ht["USER_ID"].ToString());    //人員編號(帳號)
                        userbean.setUserName(ht["USER_NAME"].ToString().ToUpper()); //人員姓名
                        userbean.setUserOrg(ht["USER_ORG"].ToString());
						userbean.setUserOrg1(ht["USER_ORG1"].ToString());

						userbean.setUserRead(ht["USER_READ"].ToString().TrimEnd());
                        userbean.setCRSArea(tdos.getCRSArea(ht["USER_ORG"].ToString()));
                        //加入權限
                    }
                    else
                    {
                        userbean = null;
                        //密碼錯誤
                    }
                }
            }
        }
        catch (Exception e)
        {
            //使用者不存在
            Console.WriteLine("ERROR: 連線失敗 " + e.ToString());
        }
        finally
        {
            dao.close();
        }
        return userbean;
    }

    public UserID makeUserBean(UserID userbean)
    {
        DBDAO dao = new DBDAO();

        try
        {
            dao.open();
            String sql = "select e.* " +
                "from a_user_role e " +
                "left join a_role_mst b on e.role_id = b.role_id " +
                "where e.user_id = @user_id and e.status='O' and b.status = 'O'";
            dao.CommandSQL = sql;
            dao.setParam("@user_id", userbean.getUserID());

            ArrayList al = dao.search();
            int x = al.Count;
            if (al.Count != 0)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Hashtable ht = (Hashtable)al[i];
                    userbean.addRole(ht["ROLE_ID"].ToString());

                    try
                    {
                        sql = "select a.task_id,a.button_type " +
                            "from a_role_function a " +
                            "left join a_task_function b on a.task_id = b.task_id and a.button_type = b.button_type " +
                            "where a.role_id = @role_id and a.status='O' and b.status='O'";
                        dao.CommandSQL = sql;
                        dao.setParam("@role_id", ht["ROLE_ID"].ToString());

                        ArrayList al2 = dao.search();
                        if (al2.Count != 0)
                        {
                            for (int j = 0; j < al2.Count; j++)
                            {
                                Hashtable ht2 = (Hashtable)al2[j];
                                userbean.addTask(ht2["TASK_ID"].ToString());
                                userbean.addFunc(ht2["TASK_ID"].ToString() + "_" + ht2["BUTTON_TYPE"].ToString());
                            }
                        }
                        else
                        {
                            new Exception("Table (a_role_function) Data is Empty");
                        }
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine("Table (a_role_function) Data Error");
                        throw ee;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Table (a_role_data) Data Error ");
            throw e;
        }
        finally
        {
            dao.close();
        }
        return userbean;
    }
}
