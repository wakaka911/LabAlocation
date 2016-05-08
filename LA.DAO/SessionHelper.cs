using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LA.Domain;

namespace LA.DAO
{
    public static class SessionHelper
    {
        public static void SetSession(string account, string pwd)
        {
            HttpContext.Current.Session["account"] = account;
            HttpContext.Current.Session["pwd"] = pwd;
        }

        public static account_info GetCurrentAccount()
        {
            account_info ai=new account_info();
            if(HttpContext.Current.Session["account"]!=null)
            ai = AccountHelper.GetAccountInfo(HttpContext.Current.Session["account"].ToString());
                
            return ai;
        }
    }
}
