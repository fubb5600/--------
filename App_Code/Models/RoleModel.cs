using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;
/// <summary>
/// RoleModel 的摘要描述

/// </summary>
public class RoleModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
    }

    /// <summary>
    /// 使用者權限設定瀏覽查詢
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select role_id, role_name, b.id_name as status from a_role_mst a " +
            "left join a_sysparam_data b on a.status = b.param_id and b.param_type ='USE_STA'";

        String where = "where 1=1 ";

        if (!form.getValue("role_id").Equals(""))
        {
            where += " and a.role_id like @role_id";
            pb.setParam("@role_id", "%" + form.getValue("role_id") + "%");
        }

        if (!form.getValue("role_name").Equals(""))
        {
            where += " and a.role_name like @role_name";
            pb.setParam("@role_name", "%" + form.getValue("role_name") + "%");
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and a.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "role_id";
    }
    /// <summary>
    /// 群組下拉
    /// </summary>
    /// <returns></returns>
    public ArrayList selectRoleOption()
    {
        String sql = "select role_id as PVALUE, role_name as PTEXT " +
            "from a_role_mst " +
            "where status = 'O' " +
            "order by role_id";

        dao.CommandSQL = sql;
        return dao.search();
    }


    /// <summary>
    /// 新增群組
    /// </summary>
    /// <param name="form"></param>
    public void insertRole(Form form)
    {
        String sql = "insert into a_role_mst (role_id, role_name, status, memo, create_date, create_user, update_date, update_user) " +
            "values (@role_id, @role_name, @status, @memo, GETDATE(), @create_user, GETDATE(), @update_user)";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));
        dao.setParam("@role_name", form.getValue("role_name"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@create_user", form.getValue("create_user"));
        dao.setParam("@update_user", form.getValue("create_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 新增角色群組使用
    /// </summary>
    /// <returns></returns>
    public ArrayList selectRoleFuctionOption()
    {
        String sql = "select layer , COUNT(layer) as count from a_task_function a left join a_task_mst b on a.task_id = b.task_id " +
            "where task_type='T' group by layer order by layer";

        dao.CommandSQL = sql;
        return dao.search();
    }

    public void insertStock(Form form)
    {
        String sql = "insert into [Stock] ([Thing],[Count],[User1],[Work_no],[Memo] ,[Car],[status],[No],[Update_Time]  ,[Use_Time]) " +

            "values ( @Thing, @Count ,@crs_org,@Work_no,@Memo,@car_no,'O',@component_no,GETDATE() ,'1900-01-01 00:00:00.000')";

        dao.CommandSQL = sql;
        dao.setParam("@Thing", form.getValue("Thing"));
        dao.setParam("@Count", form.getValue("Count"));
        dao.setParam("@component_no", form.getValue("component_no"));

        
        dao.setParam("@crs_org", form.getValue("crs_org"));
        dao.setParam("@Work_no", form.getValue("Work_no"));
        dao.setParam("@Memo", form.getValue("Memo"));
        dao.setParam("@notify_date", form.getValue("notify_date"));
        dao.setParam("@car_no", form.getValue("car_no"));

        dao.executeModify();

    }


    public void UseStock(Form form)
    {
        String sql = "insert into [Stock] ([Thing],[Count],[User1],[Work_no],[Memo] ,[Car],[status],[No],[Update_Time]  ,[Use_Time]) " +

            "values ( @Thing, @Count ,@crs_org,@Work_no,@Memo,@car_no,'O',@component_no,GETDATE() ,'1900-01-01 00:00:00.000')";

        dao.CommandSQL = sql;
        dao.setParam("@Thing", form.getValue("Thing"));
        dao.setParam("@Count", form.getValue("Count"));
        dao.setParam("@component_no", form.getValue("component_no"));


        dao.setParam("@crs_org", form.getValue("crs_org"));
        dao.setParam("@Work_no", form.getValue("Work_no"));
        dao.setParam("@Memo", form.getValue("Memo"));
        dao.setParam("@notify_date", form.getValue("notify_date"));
        dao.setParam("@car_no", form.getValue("car_no"));

        dao.executeModify();

    }
    public void deleteStock(Form form)
    {
        String sql = "delete  FROM [TDOS].[dbo].[Stock]  where ID= @repair_id";

            

        dao.CommandSQL = sql;
        dao.setParam("@repair_id", form.getValue("repair_id"));
        
        dao.executeModify();

    }
    

         public void InsertStock(Form form)
    {
        String sql = "INSERT INTO [TDOS].[dbo].[Stock]([Thing],[Count],[Car],[Memo],[Work_no],[date],[User1],[status],[No],[Use_Car],[Use_No],[Update_Time],[Use_Time]) " +
            "VALUES (@Thing,@Count,@Car,@Memo,@Work_no,@date,@User1,'O',@No,@Use_Car,@Use_No,@datetime,@Use_Time)";



        dao.CommandSQL = sql;
        dao.setParam("@Use_Car", form.getValue("Use_Car"));
        dao.setParam("@Use_No", form.getValue("Use_No"));
        dao.setParam("@Count", form.getValue("Count"));
        dao.setParam("@Thing", form.getValue("Thing"));
        dao.setParam("@datetime", form.getValue("datetime"));
        dao.setParam("@Use_Time", form.getValue("Use_Time"));

        dao.setParam("@Car", form.getValue("Car"));
        dao.setParam("@Work_no", form.getValue("Work_no"));
        dao.setParam("@date", form.getValue("date"));
        dao.setParam("@User1", form.getValue("User1"));
        dao.setParam("@Memo", form.getValue("Memo"));
        dao.setParam("@No", form.getValue("No"));

        dao.executeModify();

    }

    public void UpdateStock(Form form)
    {
        String sql = "update   [TDOS].[dbo].[Stock] set status='X'    where ID= @repair_id";



        dao.CommandSQL = sql;
        dao.setParam("@repair_id", form.getValue("repair_id"));
        dao.setParam("@Count", form.getValue("Count"));




        dao.executeModify();

    }
    /// <summary>
    /// 新增群組權限
    /// </summary>
    /// <param name="form"></param>
    public void insertRoleFuntion(Form form)
    {
        String sql = "insert into a_role_function (role_id, task_id, button_type, status, create_date, create_user, update_date, update_user) " +
            "values (@role_id, @task_id, @button_type, @status, GETDATE(), @create_user, GETDATE(), @update_user)";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));
        dao.setParam("@task_id", form.getValue("task_id"));
        dao.setParam("@button_type", form.getValue("button_type"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@create_user", form.getValue("create_user"));
        dao.setParam("@update_user", form.getValue("create_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 新增帳號群組
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="role_id"></param>
    public void insertRoleForUser(String user_id, String role_id)
    {
        String sql = "insert into a_user_role (user_id, role_id, status) values (@user_id, @role_id, 'O')";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        dao.setParam("@role_id", role_id);
        dao.executeModify();
    }

    public void deleteGroup(Form form)
    {
        String sql = "DELETE [a_role_mst] WHERE   role_id= @user_role";

           

        dao.CommandSQL = sql;
        dao.setParam("@user_role", form.getValue("user_role"));

        dao.executeModify();



    }

    public void deleteGroup1(Form form)
    {
        String sql = "DELETE [a_role_function] WHERE   role_id= @user_role ";

          

        dao.CommandSQL = sql;
        dao.setParam("@user_role", form.getValue("user_role"));


        dao.executeModify();


    }

    public void insertGroup(Form form)
    {
        String sql = "insert into [a_role_mst] (role_id,role_name,status,memo,create_date,create_user,update_date,update_user,[group]) " +

            "values (@role_id, @role_name, 'O', @role_name, GETDATE(), 'admin', GETDATE(), 'admin',@keep_org )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));
        dao.setParam("@role_name", form.getValue("role_name"));
        dao.setParam("@keep_org", form.getValue("keep_org"));

        dao.executeModify();



    }

    public void insertTDOSa001_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa001', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

    public void TDOSa001_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa001', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }
    public void TDOSa001_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa001', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }
    public void TDOSa001_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa001', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }



    public void TDOSa002_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa002', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

   
    public void TDOSa002_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa002', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }
    public void TDOSa002_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa002', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }

    public void TDOSa003_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa003', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }


    public void TDOSa004_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa004', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }
    public void TDOSa007_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa007', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }
    public void TDOSa008_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa008', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }

    
    public void TDOSb001_audit(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb001', 'audit', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }




    public void TDOSb001_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb001', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }


    public void TDOSb001_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb001', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }
    public void TDOSb001_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb001', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }
    public void TDOSb001_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb001', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }


    public void TDOSa001_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSa001', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();



    }
    public void TDOSb002_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb002', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSb002_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb002', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSb002_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb002', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSb002_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSb002', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc001_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc001', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

    public void TDOSc001_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc001', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc001_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc001', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc001_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc001', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc001_Allinsert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc001', 'Allinsert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc002_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc002', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc002_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc002', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc002_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc002', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc002_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc002', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc003_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc003', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc003_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc003', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc003_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc003', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc003_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc003', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc004_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc004', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSc004_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc004', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }


    public void TDOSc005_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc005', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }


    public void TDOSc005_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc005', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

    public void TDOSc005_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc005', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }


    public void TDOSc005_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSc005', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

    public void TDOSd001_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd001', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSd001_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd001', 'update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSd002_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd002', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

    public void TDOSd003_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd003', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSd008_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd008', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSd009_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd009', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

    public void TDOSd008_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd008', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSd007_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd007', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSd004_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd004', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSd005_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd005', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSd006_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSd006', 'query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSe001_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSe001', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSe001_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSe001', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSe001_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSe001','query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSe001_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSe001','update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSe002_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSe002', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSe002_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSe002', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSe002_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSe002','query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSe002_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSe002','update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSf001_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf001', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSf001_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf001', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSf001_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf001','query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSf001_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf001','update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

    public void TDOSf001_print(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf001','print', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSf002_delete(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf002', 'delete', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSf002_insert(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf002', 'insert', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSf002_query(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf002','query', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    public void TDOSf002_update(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf002','update', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }

    public void TDOSf002_print(Form form)
    {
        String sql = "insert into [a_role_function] ([role_id],[task_id],[button_type],[status],[create_date],[create_user],[update_date],[update_user]) " +

            "values (@role_id, 'TDOSf002','print', 'O', GETDATE(), 'admin', GETDATE(), 'admin' )";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));


        dao.executeModify();

    }
    /// <summary>
    /// 修改帳號群組
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="role_id"></param>
    public void updateRoleForUser(String user_id, String role_id)
    {
        String sql = "update a_user_role set role_id=@role_id where user_id=@user_id";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        dao.setParam("@role_id", role_id);
        dao.executeModify();
    }

    /// <summary>
    /// 刪除帳號群組
    /// </summary>
    /// <param name="user_id"></param>
    public void deleteRoleForUser(String user_id)
    {
        String sql = "delete a_user_role where user_id=@user_id";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        dao.executeModify();
    }


    /// <summary>
    /// 作業名稱樹狀圖
    /// </summary>
    /// <returns></returns>
    public ArrayList selectFunctionOption(String role_id)
    {
        String sql = "select distinct a.task_id, a.task_name, a.parent, a.layer, b.button_type, c.button_type  as check_type, " +
            "b.function_name as button_name, a.task_type from a_task_mst a left join (select distinct task_id, button_type, function_name " +
            "from a_task_function) b on a.task_id = b.task_id left join (select distinct task_id, button_type from a_role_function " +
            "where role_id=@role_id) c on b.task_id = c.task_id and b.button_type = c.button_type where a.status = 'O' order by a.layer, b.function_name";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", role_id);
        return dao.search();
    }


    /// <summary>
    /// 刪除角色群組
    /// </summary>
    /// <param name="form"></param>
    public void deleteRole(String role_id)
    {
        String sql = "delete a_role_mst where role_id = @role_id";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", role_id);

        dao.executeModify();
    }


    /// <summary>
    /// 刪除角色群組權限
    /// </summary>
    /// <param name="form"></param>
    public void deleteRoleFuntion(String role_id)
    {
        String sql = "delete a_role_function where role_id = @role_id";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", role_id);

        dao.executeModify();
    }

    /// <summary>
    /// 查詢角色群組明細
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns></returns>
    public ArrayList selectRole(String role_id)
    {
        String sql = "select role_id, role_name, status, memo " +
            "from a_role_mst where role_id=@role_id ";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", role_id);
        return dao.search();
    }


    /// <summary>
    /// 修改角色群組
    /// </summary>
    /// <param name="form"></param>
    public void updateRole(Form form)
    {
        String sql = "update a_role_mst set role_name=@role_name, status=@status, memo=@memo, update_date=GETDATE(), " +
            "update_user=@update_user";

        sql = sql + " where role_id=@role_id";

        dao.CommandSQL = sql;
        dao.setParam("@role_id", form.getValue("role_id"));
        dao.setParam("@role_name", form.getValue("role_name"));
        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@update_user", form.getValue("update_user"));

        dao.executeModify();
    }
}