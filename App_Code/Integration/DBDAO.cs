using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// 建立與資料庫的連結，並且使用各種SQL語法進行資料庫工作，以及處理查詢結果。


/// </summary>
public class DBDAO
{
    private SqlConnection conn = null;
    private SqlCommand cmd = new SqlCommand();
    private SqlTransaction trans = null;

    private Boolean openFlag = false;
    private Boolean commitFlag = true;

    //執行SQL
    private String sql_instruction = "";
    private String cmdSQL = "";
    //Order By For MSSQL分頁
    private String odrSQL = "";
    //Param
    private Hashtable htParam = new Hashtable();

    public DBDAO()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebConnectionString"].ConnectionString);
    }

    /// <summary>
    /// 執行SQL
    /// </summary>
    public String CommandSQL
    {
        get
        {
            return cmdSQL;
        }
        set
        {
            cmdSQL = value;
        }
    }

    /// <summary>
    /// 排序SQL
    /// PS：欄位要在select field裡，否則會因無此欄位而發生錯誤

    /// </summary>
    public String OrderSQL
    {
        get
        {
            return odrSQL;
        }
        set
        {
            odrSQL = value;
        }
    }
    //wenny_test_start

    //wenny_test_end



    /// <summary>
    /// 設定SQL參數
    /// </summary>
    /// <param name="key"></param>
    /// <param name="obj"></param>
    public void setParam(String key, Object obj)
    {
        if (isOpen())
        {
            cmd.Parameters.Add(key, obj);
            htParam.Add(key, obj);
        }
        else
        {
            throw new Exception("Connection尚未開啟");
        }
    }

    /// <summary>
    /// 清除相關設定
    /// </summary>
    public void clear()
    {
        if (isOpen())
        {
            cmd.Parameters.Clear();
            htParam.Clear();

            cmdSQL = "";
            odrSQL = "";
        }
        else
        {
            throw new Exception("Connection尚未開啟");
        }
    }

    /// <summary>
    ///查詢
    /// </summary>
    /// <returns>ArrayList</returns>
    public ArrayList search()
    {
        sql_instruction = "";
        ArrayList al;

        try
        {
            sql_instruction = getRealSQL(cmdSQL);
            cmd.CommandText = cmdSQL;
            cmd.CommandTimeout = 300;

            SqlDataReader dr = cmd.ExecuteReader();
            al = makeAL(dr);
            dr.Dispose();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            clear();
        }

        return al;
    }

    /// <summary>
    ///查詢
    /// </summary>
    /// <returns>DataSet</returns>
    public DataSet searchForDS()
    {
        sql_instruction = "";
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            sql_instruction = getRealSQL(cmdSQL);
            cmd.CommandText = cmdSQL;
            cmd.CommandTimeout = 300;

            sda.SelectCommand = cmd;
            sda.Fill(ds, "myDS");
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            clear();
        }

        return ds;
    }

    /// <summary>
    ///查詢，分頁用
    /// </summary>
    /// <returns>DataSet</returns>
    public DataSet search(int pageRecords, int pageNumber)
    {
        return searchMSSQL(pageRecords, pageNumber);
    }

    /// <summary>
    ///查詢，分頁用
    /// </summary>
    /// <returns>DataSet</returns>
    public DataSet searchMSSQL(int pageRecords, int pageNumber)
    {
        sql_instruction = "";
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            if (odrSQL.Equals(""))
            {
                throw new Exception("未設定Order By");
            }

            int start = pageRecords * (pageNumber - 1);
            int end = pageRecords * pageNumber;

            String selectSQL = "select pb2.* from ( " +
                    "select ROW_NUMBER() OVER ( order by " + odrSQL + " ) as ROW_NUM, pb.* " +
                    "from ( " + cmdSQL + " ) pb ) pb2 where pb2.ROW_NUM > " + start + " and pb2.ROW_NUM <= " + end;

            sql_instruction = getRealSQL(cmdSQL); ;
            cmd.CommandText = selectSQL;

            sda.SelectCommand = cmd;
            sda.Fill(ds, "myDS");
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            clear();
        }

        return ds;
    }

    /// <summary>
    ///查詢，分頁用
    /// </summary>
    /// <returns>DataSet</returns>
    public DataSet searchMSSQL(int pageRecords, int pageNumber, String otherField)
    {
        sql_instruction = "";
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            if (odrSQL.Equals(""))
            {
                throw new Exception("未設定Order By");
            }

            int start = pageRecords * (pageNumber - 1);
            int end = pageRecords * pageNumber;

            String selectSQL = "select pb2.*";
            if (!otherField.Equals(""))
            {
                selectSQL = selectSQL + ", " + otherField;
            }
            selectSQL = selectSQL + " from ( " +
                    "select ROW_NUMBER() OVER ( order by " + odrSQL + " ) as ROW_NUM, pb.* " +
                    "from ( " + cmdSQL + " ) pb ) pb2 where pb2.ROW_NUM > " + start + " and pb2.ROW_NUM <= " + end;

            sql_instruction = getRealSQL(cmdSQL); ;
            cmd.CommandText = selectSQL;

            sda.SelectCommand = cmd;
            sda.Fill(ds, "myDS");
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            clear();
        }

        return ds;
    }

    /// <summary>
    /// 執行Modify SQL
    /// </summary>
    /// <returns>Boolean</returns>
    public Boolean executeModify()
    {
        Boolean flag = true;
        sql_instruction = "";

        try
        {
            sql_instruction = getRealSQL(cmdSQL);
            cmd.CommandText = cmdSQL;
            cmd.ExecuteNonQuery();

            this.hasCommit(false);
        }
        catch (Exception e)
        {
            flag = false;
            throw e;
        }
        finally
        {
            clear();
        }

        return flag;
    }

    /// <summary>
    /// 新增(回傳流水號)
    /// </summary>
    /// <returns>流水號</returns>
    public Decimal insertForSEQ()
    {
        Decimal seq = 0;
        sql_instruction = "";

        try
        {
            String insertSQL = cmdSQL + ";SELECT SCOPE_IDENTITY()";

            sql_instruction = getRealSQL(cmdSQL);
            cmd.CommandText = insertSQL;
            seq = (Decimal)cmd.ExecuteScalar();

            this.hasCommit(false);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            clear();
        }

        return seq;
    }

    /// <summary>
    /// 執行SP用

    /// </summary>   
    /// <returns>Boolean</returns>
    public Boolean executeSP()
    {
        Boolean flag = true;
        sql_instruction = "";

        try
        {
            sql_instruction = getRealSQL(cmdSQL);
            cmd.CommandText = cmdSQL;
            cmd.ExecuteNonQuery();

            this.hasCommit(false);
        }
        catch (Exception e)
        {
            flag = false;
            throw e;
        }
        finally
        {
            clear();
        }

        return flag;
    }

    /// <summary>
    /// 將search回來的SqlDataReader轉換為ArrayList
    /// </summary>   
    /// <param name="dr">SqlDataReader</param>
    /// <returns>ArrayList</returns>
    public ArrayList makeAL(SqlDataReader dr)
    {
        ArrayList al = new ArrayList();

        DataTable dt = dr.GetSchemaTable();
        while (dr.Read())
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                String key = dt.Rows[i].ItemArray.GetValue(0).ToString().ToUpper();
                String value = Convert.ToString(dr.GetValue(i));
                ht.Add(key, value);
            }
            al.Add(ht);
        }

        return al;
    }

    /// <summary>
    ///  Connection是否開啟
    /// </summary>   
    /// <returns>Boolean</returns>
    public Boolean isOpen()
    {
        return openFlag;
    }

    /// <summary>
    /// 開啟Connection
    /// </summary>   
    public void open()
    {
        try
        {
            if (!isOpen())
            {
                conn.Open();
                cmd.Connection = conn;

                openFlag = true;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    /// <summary>
    /// 關閉Connection
    /// </summary>   
    public void close()
    {
        try
        {
            if (isOpen())
            {
                //若未commit，則先執行rollback
                //System.out.println("DBDAOCon.closeConnection");
                rollback();

                conn.Close();
                conn.Dispose();

                if (trans != null)
                {
                    trans.Dispose();
                }

                cmd.Dispose();

                openFlag = false;


            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    /// <summary>
    /// 開啟Transaction
    /// </summary>   
    public void beginTransaction()
    {
        trans = conn.BeginTransaction();
        cmd.Transaction = trans;
    }

    /// <summary>
    /// 執行commit
    /// </summary> 
    public void commit()
    {
        try
        {
            if (isOpen() && !isCommit())
            {
                if (trans != null)
                {
                    trans.Commit();
                }

                hasCommit(true);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    /// <summary>
    /// 執行rollback
    /// </summary> 
    public void rollback()
    {
        try
        {
            if (!isCommit())
            {
                if (trans != null)
                {
                    trans.Rollback();
                }

                hasCommit(true);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    /// <summary>
    /// 設定commit狀態


    /// </summary> 
    public void hasCommit(Boolean flag)
    {
        this.commitFlag = flag;
    }

    /// <summary>
    /// 是否已commit
    /// </summary> 
    /// <returns>Boolean</returns>
    public Boolean isCommit()
    {
        return this.commitFlag;
    }

    /// <summary>
    /// 取得目前設定的SQL指令
    /// </summary> 
    /// <returns>目前設定的SQL指令</returns>
    public String getSQL()
    {
        if (sql_instruction.Equals(""))
        {
            return "SQL指令未設定";
        }
        else
        {
            return sql_instruction;
        }
    }

    /// <summary>
    /// 取得設定參數後的SQL
    /// </summary>
    /// <returns></returns>
    private String getRealSQL(String sql)
    {
        String str = sql;

        if (htParam.Count > 0)
        {
            foreach (string key in htParam.Keys)
            {
                Object obj = htParam[key];

                String value = "";
                if (obj == DBNull.Value)
                {
                    value = "null";
                }
                else
                {
                    value = "'" + obj.ToString() + "'";
                }

                str = str.Replace(key, value);
            }
        }

        return str;
    }

    protected void finalize()
    {
        if (!isOpen())
        {

        }
        else
        {
            close();
        }
    }

    public void UseDepConn(Boolean flag)
    {
        if (flag)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DepConnectionString"].ConnectionString);
        }
        else
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebConnectionString"].ConnectionString);
        }
    }

    /// <summary>
    /// 取得DEP SQL Connection的db name
    /// </summary>
    /// <returns></returns>
    public String DepDB()
    {
        SqlConnection sqlDepConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DepConnectionString"].ConnectionString);
        return sqlDepConn.Database;
    }


    public String TDOSDB()
    {
        SqlConnection sqlDepConn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebConnectionString"].ConnectionString);
        return sqlDepConn.Database;
    }
}
