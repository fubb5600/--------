using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// UserModel 的摘要描述

/// </summary>
public class UserModel : Model
{
    public String muti_user_id = string.Empty;

    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
        //wenny_test_排序
        //正排
        else if (pbKey.Equals("browse1user_name"))
        {
            browse1user_name(pb, form);
        }
        else if (pbKey.Equals("browse1status"))
        {
            browse1status(pb, form);
        }
        else if (pbKey.Equals("browse1DepName"))
        {
            browse1DepName(pb, form);
        }
        else if (pbKey.Equals("browse1Department"))
        {
            browse1Department(pb, form);
        }
        else if (pbKey.Equals("browse1Professional"))
        {
            browse1Professional(pb, form);
        }
        else if (pbKey.Equals("browse1role_name"))
        {
            browse1role_name(pb, form);
        }
        //反排
        if (pbKey.Equals("browse1d"))
        {
            browse1d(pb, form);
        }
        else if (pbKey.Equals("browse1user_named"))
        {
            browse1user_named(pb, form);
        }
        else if (pbKey.Equals("browse1statusd"))
        {
            browse1statusd(pb, form);
        }
        else if (pbKey.Equals("browse1DepNamed"))
        {
            browse1DepNamed(pb, form);
        }
        else if (pbKey.Equals("browse1Departmentd"))
        {
            browse1Departmentd(pb, form);
        }
        else if (pbKey.Equals("browse1Professionald"))
        {
            browse1Professionald(pb, form);
        }
        else if (pbKey.Equals("browse1role_named"))
        {
            browse1role_named(pb, form);
        }
        //wenny_test_排序
    }

    /// <summary>
    /// 使用者管理瀏覽查詢
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB()  + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB()  + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB()  + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "user_id";
    }
    //wenny_test_排序
    //正排
    private void browse1user_name(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "user_name";
    }
    private void browse1status(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "status";
    }
    private void browse1DepName(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "DepName";
    }
    private void browse1Department(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "Department";
    }
    private void browse1Professional(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "Professional";
    }
    private void browse1role_name(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "role_name";
    }
    //反排
    private void browse1d(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "user_id desc";
    }
    private void browse1user_named(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "user_name desc";
    }
    private void browse1statusd(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "status desc";
    }
    private void browse1DepNamed(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "DepName desc";
    }
    private void browse1Departmentd(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "Department desc";
    }
    private void browse1Professionald(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "Professional desc";
    }
    private void browse1role_named(PageBreak pb, Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, c.role_name, b.role_id, " +
            "DepName = " + dao.DepDB() + ".dbo.F_GetDepNameById(DepId), " +
            "Department, Professional= " + dao.DepDB() + ".dbo.F_GetTypeName('1',Professional), " +
            "e.id_name as status from " + dao.DepDB() + "..Users a " +
            "left join " + dao.TDOSDB() + "..a_user_role b on a.UserId = b.user_id " +
            "left join " + dao.TDOSDB() + "..a_role_mst c on b.role_id = c.role_id " +
            "left join " + dao.TDOSDB() + "..a_user_mst d on a.UserId = d.user_id " +
            "left join " + dao.TDOSDB() + "..a_sysparam_data e on d.status = e.param_id and e.param_type='USE_STS' ";

        String where = "where 1=1";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and a.UserId like @user_id";
            pb.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and a.UserName like @user_name";
            pb.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and a.DepId like @user_dep";
            pb.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and a.DepId = @sub_dep";
            pb.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals(""))
        {
            where += " and a.Professional = @user_title";
            pb.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("user_role").Equals(""))
        {
            where += " and b.role_id = @user_role";
            pb.setParam("@user_role", form.getValue("user_role"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and d.status in (" + handleMultiData("status", form.getValue("status"), pb) + ")";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "role_name desc";
    }
    //wenny_test_排序




    public DataSet getDEPUser(Form form)
    {
        String sql = "select UserNo, UserId as user_id, UserName as user_name, " +
            "DepName = dbo.F_GetDepNameById(DepId), " +
            "Department, Professional=dbo.F_GetTypeName('1',Professional), " +
            "convert(varchar,State) as status from Users ";

        String where = " where 1=1 ";

        if (!form.getValue("user_id").Equals(""))
        {
            where += " and UserId like @user_id";
            dao.setParam("@user_id", "%" + form.getValue("user_id") + "%");
        }

        if (!form.getValue("user_name").Equals(""))
        {
            where += " and UserName like @user_name";
            dao.setParam("@user_name", "%" + form.getValue("user_name") + "%");
        }

        if (!form.getValue("user_dep").Equals(""))
        {
            where += " and DepId like @user_dep";
            dao.setParam("@user_dep", form.getValue("user_dep").Substring(0, 1) + "%");
        }

        if (!form.getValue("sub_dep").Equals(""))
        {
            where += " and DepId = @sub_dep";
            dao.setParam("@sub_dep", form.getValue("sub_dep"));
        }

        if (!form.getValue("user_title").Equals("請選擇"))
        {
            where += " and Professional = @user_title";
            dao.setParam("@user_title", form.getValue("user_title"));
        }

        if (!form.getValue("status").Equals(""))
        {
            where += " and State in (" + handleMultiData("status", form.getValue("status")) + ")";
        }

        dao.CommandSQL = sql + where;
        DataSet ds = dao.searchForDS();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow dr = ds.Tables[0].Rows[i];
            muti_user_id += dr["user_id"].ToString() + ",";
        }

        if (muti_user_id.Length > 1)
        {
            muti_user_id = muti_user_id.Substring(0, muti_user_id.Length - 1);
        }

        return ds;
    }

    /// <summary>
    /// 新增使用者
    /// </summary>
    /// <param name="form"></param>
    public void insertUser(Form form)
    {
        String user_id = form.getValue("user_id");
        String passwd = MD5Digest.GetMD5(form.getValue("passwd") + user_id);
        passwd = passwd.ToUpper();

        String sql = "insert into a_user_mst (user_id, user_name, status, user_passwd, user_org, sub_org, " +
            "user_read, create_date, create_user, update_date, update_user) " +
            "values (@user_id, @user_name, @status, @user_passwd, @user_org, @sub_org, @user_read, " +
            "GETDATE(), @create_user, GETDATE(), @create_user)";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        dao.setParam("@user_name", form.getValue("user_name"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@user_passwd", passwd);
        dao.setParam("@user_org", form.getValue("user_org"));
        dao.setParam("@sub_org", form.getValue("sub_org"));
        dao.setParam("@user_read", form.getValue("user_read"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }
    /// <summary>
    /// 新增使用者資訊
    /// </summary>
    /// <param name="form"></param>
    public void insertUser1(Form form)
    {
        String user_id = form.getValue("user_id");
        String passwd = form.getValue("passwd");

        String sql = @"insert into [DEP_2016].[dbo].[Users]  ([UserId],[Password],[UserName],[Professional],[UserNo],[Department],[Phone],[ExPhone],[Phone2],[ExPhone2],[Fax],
                                                             [Mobile],[Address],[Email],[DepId],[State],[PWModifyDate]) values 
                                                             (@user_id,@user_passwd,@user_name,@user_title,@user_no,@user_department,@user_cont1,@ExPhone,@user_cont2,@ExPhone2,@user_fax,
                                                             @user_mobile,@user_address,@user_email,@sub_dep,'1', GETDATE())";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        dao.setParam("@user_name", form.getValue("user_name"));
        dao.setParam("user_no", form.getValue("user_no"));

        dao.setParam("@user_title", form.getValue("user_title"));
        dao.setParam("@user_department", form.getValue("user_department"));
        dao.setParam("@user_cont1", form.getValue("user_cont1"));
        dao.setParam("@user_cont2", form.getValue("user_cont2"));
        dao.setParam("@ExPhone", form.getValue("ExPhone"));
        dao.setParam("@ExPhone2", form.getValue("ExPhone2"));
        dao.setParam("@user_fax", form.getValue("user_fax"));

        dao.setParam("@user_mobile", form.getValue("user_mobile"));
        dao.setParam("@user_address", form.getValue("user_address"));
        dao.setParam("@user_email", form.getValue("user_email"));

        dao.setParam("@user_dep", form.getValue("user_dep"));
        dao.setParam("@sub_dep", form.getValue("sub_dep"));

        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@user_passwd", passwd);
        dao.setParam("@user_org", form.getValue("user_org"));
        dao.setParam("@sub_org", form.getValue("sub_org"));
        dao.setParam("@user_read", form.getValue("user_read"));
        dao.setParam("@create_user", form.getValue("create_user"));

        dao.executeModify();
    }
    /// <summary>
    /// 修改使用者
    /// </summary>
    /// <param name="form"></param>
    public void updateUser(Form form)
    {
        String user_id = form.getValue("user_id");
        bool hasPW = !form.getValue("passwd").Equals("");
        String sql = "update a_user_mst set user_name=@user_name, status=@status, user_org=@user_org, " +
            "sub_org=@sub_org, user_read=@user_read, update_date=GETDATE(), update_user=@update_user";

        if (hasPW)
        {
            sql = sql + ", user_passwd=@user_passwd";
        }

        sql = sql + " where user_id=@user_id";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        dao.setParam("@user_name", form.getValue("user_name"));
        dao.setParam("@status", form.getValue("status"));
        dao.setParam("@user_org", form.getValue("user_org"));
        dao.setParam("@sub_org", form.getValue("sub_org"));
        dao.setParam("@user_read", form.getValue("user_read"));
        if (hasPW)
        {
            String passwd = MD5Digest.GetMD5(form.getValue("passwd") + user_id);
            dao.setParam("@user_passwd", passwd);
        }
        dao.setParam("@update_user", form.getValue("create_user"));

        dao.executeModify();
    }


    /// <summary>
    /// 取得密碼
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns></returns>
    public String getUserPwd(String user_id)
    {
        String sql = "select user_passwd a_user_mst where user_id = @user_id";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        ArrayList al = dao.search();
        Hashtable ht = (Hashtable)al[0];
        return ht["USER_PASSWD"].ToString();
    }


    /// <summary>
    /// 取得使用者姓名
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="type">0:僅顯示姓名，其他則顯示帳號＋姓名</param>
    /// <returns></returns>
    public String getUserName(String user_id, int type)
    {
        String str = string.Empty;
        String sql = "select user_name from a_user_mst where user_id = @user_id";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        ArrayList al = dao.search();
        Hashtable ht = (Hashtable)al[0];
        if (type == 0)
        {
            str = ht["USER_NAME"].ToString();
        }
        else
        {
            str = user_id.ToUpper() + "(" + ht["USER_NAME"].ToString() + ")";
        }


        return str;
    }


    /// <summary>
    /// 修改登入密碼
    /// </summary>
    /// <param name="form"></param>
    public void updateUserPwd(Form form)
    {
        String user_id = form.getValue("user_id");
        String sql = "update a_user_mst set user_passwd=@user_passwd, update_date=GETDATE(), update_user=@update_user";

        sql = sql + " where user_id=@user_id";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        String passwd = MD5Digest.GetMD5(form.getValue("passwd") + user_id);
        dao.setParam("@user_passwd", passwd);
        dao.setParam("@update_user", form.getValue("create_user"));

        dao.executeModify();
    }

    /// <summary>
    /// 刪除使用者
    /// </summary>
    /// <param name="user_id"></param>
    public void deleteUser(String user_id)
    {
        String sql = "delete a_user_mst where user_id=@user_id";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        dao.executeModify();
    }
    /// <summary>
    /// 刪除使用者
    /// </summary>
    /// <param name="user_id"></param>
    public void deleteUser1(String user_id)
    {
        String sql = "delete [DEP_2016].[dbo].[Users] where UserId=@user_id";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        dao.executeModify();
    }
    /// <summary>
    /// 查詢使用者明細
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns></returns>
    public ArrayList selectUser(String user_id)
    {
        String sql = "select a.user_id, a.user_name, a.status, a.user_org, a.sub_org, a.user_read, b.role_id " +
            "from a_user_mst a " +
            "left join a_user_role b on a.user_id = b.user_id " +
            "where a.user_id=@user_id ";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        return dao.search();
    }


    /// <summary>
    /// 取得DEP_2010帳號資料
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns></returns>
    public DataSet selectDepUser(String user_id)
    {
        String sql = "SELECT UserId, UserName, b.TypeName as user_title, UserNo, Department, Phone, Phone2, " +
            "ExPhone, ExPhone2, Fax, Mobile, Address, Email, c.DepName as user_dep, d.DepName as sub_dep, " +
            "c.DepId, e.status, f.role_id FROM " + dao.DepDB()  + "..Users a " +
            "left join " + dao.DepDB()  + "..ItemType b on a.Professional = b.TypeNo and b.ParentNo = '1' " +
            "left join " + dao.DepDB()  + "..Department c on SUBSTRING(a.DepId, 1, 1) + '0' = c.DepId and c.UpDep is null " +
            "left join " + dao.DepDB()  + "..Department d on a.DepId = d.DepId " +
            "left join " + dao.TDOSDB() + "..a_user_mst e on a.UserId = e.user_id " +
            "left join " + dao.TDOSDB() + "..a_user_role f on a.UserId = f.user_id " +
            "where UserId = @user_id ";

        dao.CommandSQL = sql;
        dao.setParam("@user_id", user_id);
        return dao.searchForDS();
    }


    public ArrayList selectRole()
    {
        String sql = "select role_id as pvalue, role_name as ptext from a_role_mst " +
            "where status = 'O'";

        dao.CommandSQL = sql;

        return dao.search();
    }


    public DataSet selectUserRole()
    {
        String sql = "select a.user_id, a.role_id, b.role_name from a_user_role a " +
            "left join a_role_mst b on a.role_id = b.role_id order by a.user_id";

        dao.CommandSQL = sql;

        return dao.searchForDS();
    }

    /// <summary>
    /// 取得單位第一層
    /// </summary>
    /// <returns></returns>
    public ArrayList selectUserDep()
    {
        String sql = "select DepId as pvalue, DepName as ptext from " + dao.DepDB() + "..Department " +
            "where UpDep is null";

        dao.CommandSQL = sql;

        return dao.search();
    }



    /// <summary>
    /// 取得單位第二層
    /// </summary>
    /// <param name="UpDep"></param>
    /// <returns></returns>
    public ArrayList selectUserSubDep(String UpDep)
    {
        String sql = "select DepId as pvalue, DepName as ptext from " + dao.DepDB() + "..Department " +
            "where UpDep = @UpDep";

        dao.CommandSQL = sql;
        dao.setParam("@UpDep", UpDep);

        return dao.search();
    }



    /// <summary>
    /// 依單位取得使用中的使用者
    /// </summary>
    /// <returns></returns>
    public ArrayList selectUserbyDep(String user_org)
    {
        String sql = "select a.user_id as pvalue, b.username as ptext from " + dao.TDOSDB() + "..a_user_mst a " +
            "left join " + dao.DepDB() + "..Users b on a.user_id = b.userid " +
            "where a.user_org =@user_org and a.status = 'O' ";

        dao.CommandSQL = sql;
        dao.setParam("@user_org", user_org);

        return dao.search();
    }


    /// <summary>
    /// 取得職稱
    /// </summary>
    /// <returns></returns>
    public ArrayList selectUserTitle()
    {
        String sql = "select TypeNo as pvalue, TYPENAME as ptext from " + dao.DepDB() + "..Itemtype " +
            "where parentno = '1'";

        dao.CommandSQL = sql;

        return dao.search();
    }


    /// <summary>
    /// 依角色群組取出所屬使用者下拉
    /// </summary>
    /// <param name="role_id"></param>
    /// <returns></returns>
    public ArrayList selectUserOption(String role_id)
    {
        String sql = "select a.user_id as PVALUE, a.user_name as PTEXT " +
            "from a_user_mst a left join a_user_role b on a.user_id = b.user_id " +
            "where a.status = 'O' ";

        if (role_id != string.Empty)
        {
            sql += "and b.role_id = @role_id ";
            dao.setParam("@role_id", role_id);
        }

        sql += "order by a.user_name";

        dao.CommandSQL = sql;
        return dao.search();
    }


    /// <summary>
    /// DEP資料庫的單位與本系統單位對應
    /// </summary>
    /// <param name="DepId"></param>
    /// <returns></returns>
    public String getLocalOrgId(String DepId)
    {
        String Dep_Id = string.Empty;
        switch (DepId)
        {
            case "BA":
                Dep_Id = "18"; //直屬區隊
                break;
            case "BB":
                Dep_Id = "3"; //中正區隊
                break;
            case "BC":
                Dep_Id = "7"; //中山區隊
                break;
            case "BD":
                Dep_Id = "10"; //文山區隊
                break;
            case "BE":
                Dep_Id = "3"; //大同區隊
                break;
            case "BF":
                Dep_Id = "11"; //萬華區隊
                break;
            case "BG":
                Dep_Id = "2"; //松山區隊
                break;
            case "BH":
                Dep_Id = "5"; //大安區隊
                break;
            case "BI":
                Dep_Id = "1"; //信義區隊
                break;
            case "BJ":
                Dep_Id = "8"; //內湖區隊
                break;
            case "BK":
                Dep_Id = "9"; //南港區隊
                break;
            case "BL":
                Dep_Id = "6"; //士林區隊
                break;
            case "BM":
                Dep_Id = "12"; //北投區隊
                break;
            case "BN":
                Dep_Id = "14"; //溝渠一隊
                break;
            case "BO":
                Dep_Id = "15"; //溝渠二隊
                break;
            case "BP":
                Dep_Id = ""; //環保專線
                break;
            case "BQ":
                Dep_Id = "13"; //水肥處理隊
                break;
            case "BR":
                Dep_Id = "20"; //資收隊
                break;
        }

        return Dep_Id;
    }
}