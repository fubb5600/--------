using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;


/// <summary>
/// CarInspectionModel 的摘要描述
/// </summary>
public class CarInspectionModel : Model
{
    public override void doPageBreak(PageBreak pb, Form form, String pbKey)
    {
        if (pbKey.Equals("browse1"))
        {
            browse(pb, form);
        }
    }
    /// <summary>
    /// 車輛檢驗記錄資料瀏覽
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="form"></param>
    private void browse(PageBreak pb, Form form)
    {
        String sql = "select Row_Number () over (order by inspection_date desc) as row_num " +
                                 " ,a.inspect_id" +
                                 " ,a.car_id " +
                                 " ,dbo.chineseDate(a.regular_date) as regular_date " +
                                 " ,dbo.chineseDate(a.inspection_date) as inspection_date " +
                                 " ,a.memo " +
                                 " ,a.create_user " +
                                 " ,dbo.chineseDate(a.create_date) as create_date " +
            //" ,a.update_user " +
                                 " ,a.update_user+'('+upper(b.UserName)+')' as update_user " +
                                 " ,dbo.chineseDate(a.update_date) as update_date " +
                                 " from c_inspection_mst a " +
                                 " inner join " + dao.DepDB() + " ..Users b " +
                                 " on a.update_user=b.UserId ";
        String where = " where 1=1 ";

        if (!form.getValue("car_id").Equals(""))
        {
            pb.setParam("@car_id", form.getValue("car_id"));
            where += " and a.car_id=@car_id";
        }

        sql = sql + where;

        pb.CommandSQL = sql;
        pb.OrderSQL = "inspection_date desc ";
    }

    /// <summary>
    /// 在車輛異動記錄修改頁顯示該車輛過去的檢驗日期及狀態
    /// </summary>
    /// <param name="form"></param>
    public DataSet select(Form form)
    {
        //String sql = "select  " +//Row_Number () over (order by inspection_date desc) as row_num, 
        //                        " a.inspect_id" +
        //String sql = "select  Row_Number () over (order by inspection_date desc) as row_num , " +
        //                         " a.inspect_id" +
        //                         " ,a.car_id " +
        //                         " ,dbo.chineseDate(a.regular_date) as regular_date " +
        //                         " ,dbo.chineseDate(a.inspection_date) as inspection_date " +
        //                         " ,a.memo " +
        //                         " ,a.create_user " +
        //                         " ,dbo.chineseDate(a.create_date) as create_date " +
        //    //" ,a.update_user " +
        //                         " ,a.update_user+'('+upper(b.UserName)+')' as update_user " +
        //                         " ,dbo.chineseDate(a.update_date) as update_date " +
        //                         " from c_inspection_mst a " +
        //                         " inner join " + dao.DepDB() + "..Users b " +
        //                         " on a.update_user=b.UserId ";

        String sql = "select  Row_Number () over (order by inspection_date desc) as row_num , " +
                         " inspect_id" +
                         " ,car_id " +
                         " ,dbo.chineseDate(regular_date) as regular_date " +
                         " ,dbo.chineseDate(inspection_date) as inspection_date " +
                         " ,memo " +
                         " ,create_user " +
                         " ,dbo.chineseDate(create_date) as create_date " +
                         //" ,a.update_user " +
                         " ,update_user" +
                         " ,dbo.chineseDate(update_date) as update_date " +
                         " from c_inspection_mst";

        String where = " where 1=1 ";

        if (!form.getValue("car_id").Equals(""))
        {
            dao.setParam("@car_id", form.getValue("car_id"));
            where += " and car_id=@car_id";
        }

        sql = sql + where;

        dao.CommandSQL = sql;

        return dao.searchForDS();
    }


    public void insert(Form form)
    {
        String sql = "insert into c_inspection_mst(car_id, regular_date, inspection_date, memo, create_user, " +
            "create_date, update_user, update_date) values(@car_id, @regular_date, @inspection_date, @memo, " +
            "@create_user, getdate(), @create_user, getdate()) ";

        dao.CommandSQL = sql;

        //下次定檢日
        if (!form.getValue("regular_date").Equals(""))
        {
            dao.setParam("@regular_date", form.getValue("regular_date"));
        }
        else
        {
            dao.setParam("@regular_date", DBNull.Value);
        }

        //檢驗完成日
        if (!form.getValue("inspection_date").Equals(""))
        {
            dao.setParam("@inspection_date", form.getValue("inspection_date"));
        }
        else
        {
            dao.setParam("@inspection_date", DBNull.Value);
        }

        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@create_user", form.getValue("create_user"));
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.insertForSEQ();


    }


    /// <summary>
    /// 變更檢驗紀錄
    /// </summary>
    /// <param name="form"></param>
    public void update(Form form)
    {
        String sql = "update c_inspection_mst " +
                                " set regular_date = @regular_date" +
                                "  , inspection_date=@inspection_date" +
                                "  , memo =@memo" +
                                "  , update_user=@update_user" +
                                "  , update_date=getdate()" +
                                "  where car_id=@car_id";

        dao.CommandSQL = sql;

        //下次定檢日
        if (!form.getValue("regular_date").Equals(""))
        {
            dao.setParam("@regular_date", form.getValue("regular_date"));
        }
        else
        {
            dao.setParam("@regular_date", DBNull.Value);
        }

        //檢驗完成日
        if (!form.getValue("inspection_date").Equals(""))
        {
            dao.setParam("@inspection_date", form.getValue("inspection_date"));
        }
        else
        {
            dao.setParam("@inspection_date", DBNull.Value);
        }

        dao.setParam("@memo", form.getValue("memo"));
        dao.setParam("@update_user", form.getValue("update_user"));
        dao.setParam("@update_date", form.getValue("update_date"));
        dao.setParam("@car_id", form.getValue("car_id"));
        dao.executeModify();
    }
    /// <summary>
    /// 刪除檢驗紀錄
    /// </summary>
    /// <param name="form"></param>
    public void delete(Form form)
    {
        String sql = "delete c_inspection_mst " +
            //" set regular_date = @regular_date" +
            //"  , inspection_date=@inspection_date" +
            //"  , memo =@memo" +
            //"  , update_user=@update_user" +
            //"  , update_date=getdate()" +
                                "  where inspect_id=@inspect_id";

        dao.CommandSQL = sql;

        ////下次定檢日
        //if (!form.getValue("regular_date").Equals(""))
        //{
        //    dao.setParam("@regular_date", form.getValue("regular_date"));
        //}
        //else
        //{
        //    dao.setParam("@regular_date", DBNull.Value);
        //}

        ////檢驗完成日
        //if (!form.getValue("inspection_date").Equals(""))
        //{
        //    dao.setParam("@inspection_date", form.getValue("inspection_date"));
        //}
        //else
        //{
        //    dao.setParam("@inspection_date", DBNull.Value);
        //}

        //dao.setParam("@memo", form.getValue("memo"));
        //dao.setParam("@update_user", form.getValue("update_user"));
        //dao.setParam("@update_date", form.getValue("update_date"));
        dao.setParam("@inspect_id", form.getValue("inspect_id"));
        dao.executeModify();
    }



    /// <summary>
    /// 查詢未檢驗車輛
    /// </summary>
    /// <returns>本日前後30日內，未於應驗日期前後30日內檢驗之車輛</returns>
//    public DataSet selectUnInspectCar()
//    {
//        String sql = @"select * from (
//            select Row_Number() over (order by c.keep_org, c.dep_no) as row_num, a.car_id, a.next_inspection 
//            ,CONVERT(datetime,CONVERT(CHAR(4),GETDATE(),112)+Right(CONVERT(CHAR(8),a.next_inspection,112),4)) as must_inspect_date 
//            ,CONVERT(datetime,CONVERT(CHAR(4),GETDATE(),112)+Right(CONVERT(CHAR(8),a.next_inspection,112),4))-30 as inspect_start 
//            ,CONVERT(datetime,CONVERT(CHAR(4),GETDATE(),112)+Right(CONVERT(CHAR(8),a.next_inspection,112),4))+30 as inspect_end 
//            ,b.inspection_date ,c.keep_org, c.car_no, c.dep_no from dbo.c_car_mst a left join 
//            (select car_id,MAX(inspection_date) as inspection_date from c_inspection_mst group by car_id) b on a.car_id=b.car_id 
//            left join (select car_id,keep_org ,car_no ,dep_no ,status from v_car ) c on a.car_id=c.car_id and c.status='O') d 
//            --inspection_date檢驗完成日若不為NULL 則要多加判斷inspection_date是否落在應檢起迄日
//            where (case when inspection_date is not null then case when inspection_date <= inspect_start and inspection_date >= inspect_end then 1 end 
//            --inspection_date若為NULL 則視為真
//            else 1 end)> 0  --首頁要的條件：應檢日期落在Server系統日期+-30天
//            and must_inspect_date <= CONVERT(CHAR(8),GETDATE()+30,112) 
//            and must_inspect_date >= CONVERT(CHAR(8),GETDATE()-30,112) 
//            and inspection_date is NULL and next_inspection is not NULL";

//        dao.CommandSQL = sql;
//        return dao.searchForDS();
//    }

    /// <summary>
    /// 查詢未檢驗車輛
    /// </summary>
    /// <returns>本日前後30日內，未於應驗日期前後30日內檢驗之車輛</returns>
    public DataSet selectUnInspectCar()
    {
        String sql = @"select Row_Number() over (order by keep_org, dep_no) as row_num, * from
	                            (
		                            select a.car_id, a.next_inspection
		                            ,CONVERT(datetime,CONVERT(CHAR(4),GETDATE(),112)+Right(CONVERT(CHAR(8),a.next_inspection,112),4)) as must_inspect_date
		                            ,CONVERT(datetime,CONVERT(CHAR(4),GETDATE(),112)+Right(CONVERT(CHAR(8),a.next_inspection,112),4))-30 as inspect_start
		                            ,CONVERT(datetime,CONVERT(CHAR(4),GETDATE(),112)+Right(CONVERT(CHAR(8),a.next_inspection,112),4))+30 as inspect_end
		                            ,b.inspection_date
		                            ,c.keep_org
		                            ,c.car_no
		                            ,c.dep_no
                                    ,c.status
		                            from dbo.c_car_mst a
		                            left join
		                            (select car_id,MAX(inspection_date) as inspection_date from c_inspection_mst group by car_id) b
		                            on a.car_id=b.car_id
		                            left join
		                            (select car_id,keep_org ,car_no ,dep_no ,status from v_car ) c
		                            on a.car_id=c.car_id
	                            )d
	                              /* inspection_date檢驗完成日若不為NULL 則要多加判斷inspection_date是否落在應檢起迄日*/
	                            where
	                            (case when inspection_date is not null then
	                            case when inspection_date <= inspect_start and inspection_date >= inspect_end then 1 end
	                             /* inspection_date若為NULL 則視為真*/
	                            else 1
	                            end)> 0
	                            /*首頁要的條件：應檢日期落在Server系統日期+-30天*/
	                            and must_inspect_date <= CONVERT(CHAR(8),GETDATE()+30,112) 
	                            --and must_inspect_date >= CONVERT(CHAR(8),GETDATE()-30,112) 
	                            and inspection_date is NULL and next_inspection is not NULL
	                            /*下次定檢日 前30天仍為未來日期者，須排除*/
	                            and not(DATEADD(DAY,-30,d.next_inspection)>GETDATE()) 
                                and status='O'";
        dao.CommandSQL = sql;
        return dao.searchForDS();
    }
}