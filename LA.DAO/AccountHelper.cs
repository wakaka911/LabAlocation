using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LA.Domain;
using LA.Domain.Entities;
using LA.Common;

namespace LA.DAO
{
    public static class AccountHelper
    {
        public static account_info GetAccountInfo(string account)
        {
            List<QueryField> qf = new List<QueryField>();
            qf.Add(new QueryField() { Name = "account", Type = QueryFieldType.String, Value = account });
            List<account_info> ai = new Repository<account_info>().GetList(qf, null) as List<account_info>;
            if (ai.Count > 0)
                return ai[0];
            else
                return new account_info();
            
            //StringBuilder sql = new StringBuilder();
            //sql.Append("select * from account_info where account=@account ");
            //sql.Append("and password=@password ");
            //Dictionary<string, object> sp = new Dictionary<string, object>();
            //sp.Add("@account",account);
            //sp.Add("@password",password);
            //DataTable dt = new ADOHelper().Select(sp, sql);
            //return dt;
        }
    }
}
