using LA.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LA.DAO
{
    public class NHHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory sessionFactory;

        static NHHelper()
        {
            string path = HttpContext.Current.Server.MapPath("/Config/hibernate.cfg.xml");
            var cfg = new NHibernate.Cfg.Configuration().Configure(path);
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            sessionFactory = cfg.BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                currentSession = sessionFactory.OpenSession(new SQLWatcher());
                context.Items[CurrentSessionKey] = currentSession;

            }
            return currentSession;
        }

        public static void CloseSession()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }

        public static DataSet ExecuteDataset(string sql, List<QueryField> qlist)
        {
            ISession session = null;
            DataSet ds = new DataSet();
            try
            {
                session = GetCurrentSession();
                IDbCommand command = session.Connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                foreach (QueryField field in qlist)
                {

                    SqlParameter parm = new SqlParameter();
                    parm.Value = field.Value;
                    parm.ParameterName = field.Name;
                    parm.DbType = ConvertDbType(field.Type);
                    command.Parameters.Add(parm);
                }
                IDataReader reader = command.ExecuteReader();
                DataTable result = new DataTable();
                DataTable schemaTable = reader.GetSchemaTable();
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    string columnName = schemaTable.Rows[i][0].ToString();
                    result.Columns.Add(columnName);
                }
                while (reader.Read())
                {
                    int fieldCount = reader.FieldCount;
                    object[] values = new Object[fieldCount];
                    for (int i = 0; i < fieldCount; i++)
                    {
                        values[i] = reader.GetValue(i);
                    }
                    result.Rows.Add(values);
                }
                ds.Tables.Add(result);
                reader.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            return ds;
        }

        public static IList<dynamic> GetData(string sql)
        {
            ISession session = GetCurrentSession();
            return session.CreateSQLQuery(sql).DynamicList();
        }






        private static DbType ConvertDbType(QueryFieldType qfType)
        {
            switch (qfType)
            {
                case QueryFieldType.Boolean:
                    return DbType.Boolean;
                case QueryFieldType.DateTime:
                    return DbType.DateTime;
                case QueryFieldType.Numeric:
                    return DbType.Decimal;
                case QueryFieldType.String:
                    return DbType.String;
                default:
                    return DbType.String;
            }
        }

    }

    public class SQLWatcher : EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            System.Diagnostics.Debug.WriteLine("sql语句:" + sql);
            return base.OnPrepareStatement(sql);
        }
    }
}
