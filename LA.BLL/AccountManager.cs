using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Common;
using LA.DAO;
using LA.Domain;

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

        public static MsgBox changePassword(string account, string pwd)
        {
            MsgBox mb = new MsgBox();
            account_info ai = AccountHelper.GetAccountInfo(account);
            ai.password = pwd;
            try
            {
                new Repository<account_info>().Update(ai);
                mb.status = true;
                mb.msg = "密码修改成功。";
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return mb;
        }

        public static string getMenu(string account)
        {
            account_info ai = AccountHelper.GetAccountInfo(account);
            StringBuilder m = new StringBuilder();
            if (!string.IsNullOrEmpty(ai.ID))
            {
                if (ai.role == -2 || ai.role == 1 || ai.role == 2 || ai.role == 3 || ai.role == 4)
                    m.Append("<br/><a href='#' id='lessonsForLabs' onclick='LessonTable()'>实验室课表查询</a><hr/>");
                if (ai.role == -2 || ai.role == 1 || ai.role == 2)
                    m.Append("<br /><a href='#' id='labAdd' onclick='Lab()'>实验室管理</a><hr />");
                if (ai.role == -2 || ai.role == 1 || ai.role == 2)
                    m.Append("<br /><a href='#' id='lessonAdd' onclick='LessonAdd()'>实验室课程管理</a><hr />");
                if (ai.role == -2 || ai.role == 1 || ai.role == 2 || ai.role == 3)
                    m.Append("<br/><a href='#' id='labBook' onclick='labBook()'>预约实验室</a><hr/>");
                if (ai.role == -2 || ai.role == 1)
                    m.Append("<br/><a href='#'id='labBookApprove' onclick='labBookApprove()'>预约实验室审核</a><hr/>");
                if (ai.role == -2 || ai.role == 1)
                    m.Append("<br/><a href='#' id='lowValue' onclick='LowValue()'>低值耐用品登记</a><hr/>");
                if (ai.role == -2 || ai.role == 1 || ai.role == 2)
                    m.Append("<br/><a href='#' id='propertyTake' onclick='PropertyTake()'>实验室物品领用</a><hr/>");
                if (ai.role == -2 || ai.role == 1 || ai.role == 2 || ai.role == 3 || ai.role == 4 || ai.role == 5)
                    m.Append("<br/><a href='#' id='repair' onclick='Repair()'>实验室报修</a><hr/>");
                if (ai.role == -2 || ai.role == 1 || ai.role == 2 || ai.role == 4)
                    m.Append("<br /><a href='#' id='repairList' onclick='RepairList()'>实验室维修情况报告</a><hr />");
                if (ai.role == -2)
                    m.Append("<br /><a href='#' id='yearRepair' onclick='YearRepair()'>实验室维修绩效</a><hr />");
                if (ai.role == -2)
                    m.Append("<br /><a href='#' id='teacherAdd' onclick='TeacherAdd()'>教师账户管理</a><hr />");
                if (ai.role == -2)
                    m.Append("<br /><a href='#' id='studentAdd' onclick='StudentAdd()'>学生账户管理</a><hr />");
                if (ai.role == -2 || ai.role == 1)
                    m.Append("<br /><a href='#' id='propertyReg' onclick='PropertyReg()'>固定资产登记表</a><hr />");
                m.Append("<br /><a href='#' id='changePassword' onclick='PasswordChange()'>修改密码</a><hr />");
            }
            else
                m.Append("登陆账户出错。");
                return m.ToString();
        }
    }
}
