using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.DAO;
using LA.Domain.Entities;

namespace LA.BLL
{
    public static class AccountManager
    {
        public static account_info GetAccountInfo(string account)
        {
            return AccountHelper.GetAccountInfo(account);
            //account_info ac = new account_info();

            //DataTable dt = new AccountHelper().GetAccountInfo(account, password);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    ac.ID = dt.Rows[0]["ID"].ToString();
            //    ac.account = dt.Rows[0]["account"];
            //}
        }

        public static bool getAI(string account, string password)
        {
            bool flag = false;  
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from account_info where account=@account ");
            sql.Append("and password=@password ");
            Dictionary<string, object> sp = new Dictionary<string, object>();
            sp.Add("@account", account);
            sp.Add("@password", password);
            DataTable dt = new ADOHelper().Select(sp, sql);
            if (dt != null && dt.Rows.Count > 0)
                flag = true;
            return flag;
        }
    }
}
