using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LA.Common;
using LA.Domain;

namespace LA.DAO
{
    public class ADOHelper
    {
        string conStr = ConfigurationManager.AppSettings["conStr"].ToString();
        string tableName;
        //StringBuilder sql = new StringBuilder();
    //    public ADOHelper(string table_name,StringBuilder _sql){
    //        tableName = table_name;
    //        sql = _sql;
    //}
        //查询
        public DataTable Select(Dictionary<string, object> sp, StringBuilder sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;
            SqlCommand comm = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            comm.CommandText = sql.ToString();
            foreach (KeyValuePair<string, object> kvp in sp)
            {
                comm.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            comm.Connection = conn;
            da.SelectCommand = comm;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0];
            else return new DataTable();
        }

        //增删改
        public MsgBox IDU(Dictionary<string, object> sp, StringBuilder sql)
        {
            MsgBox mb = new MsgBox();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = sql.ToString();
            foreach (KeyValuePair<string, object> kvp in sp)
            {
                comm.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            conn.Open();
            int i=comm.ExecuteNonQuery();
            conn.Close();
            if (i < 0)
            {
                mb.status = false;
                mb.msg = "数据库操作失败。";
            }
            else
            {
                mb.status = true;
                mb.msg = "数据库操作成功。";
            }
            return mb;

        }

        public DataTable pageSplit(int pageIndex, int pageSize, string sql, List<QueryField> conditions, out int total, ref MsgBox mb)
        {
            DataSet ds = NHHelper.ExecuteDataset(sql, conditions);
            if (ds != null && ds.Tables[0] != null)
            {
                total = ds.Tables[0].Rows.Count;
                string pageSql = string.Format("select temp.* from ({0}) temp where temp.rn between {1} and {2} ", sql, (pageIndex - 1) * pageSize + 1, pageIndex * pageSize);
                DataTable dt = NHHelper.ExecuteDataset(pageSql, conditions).Tables[0];
                return dt;
            }
            else
            {
                total = 0;
                mb.status = false;
                mb.msg = "未查询到相关数据.";
                return new DataTable();
            }
        }
    }
}
