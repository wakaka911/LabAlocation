using LA.Common;
using LA.DAO;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.BLL
{
    public class StudentManager
    {

        public MsgBox studentAdd(Student s,account_info a)
        {
            //建立主键
            s.ID = Guid.NewGuid().ToString();
            a.ID = Guid.NewGuid().ToString();

            MsgBox mb = new MsgBox();
            if (!AccountHelper.isExist(a.account))
                mb = new StudentDAO().insertStudent(s,a);
            else
            {
                mb.status = false;
                mb.msg = "账号不可用，请更换账号。";
            }
            return mb;
        }

        public GridData getStudentList(int pageIndex, int pageSize)
        {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by CREATED desc) as rn, ");
            sql.Append("studentName,studentNo,studentSex,studentSession,studentClass,studentProfession,account,ID,UPDATED,CREATED from student ");
            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }

        public MsgBox studentDel(string ID, string account)
        {
            MsgBox mb = new MsgBox();
            try
            {
                new Repository<Student>().Delete(ID);
               // new Repository<account_info>().Delete(account);
                //以下是删除账户操作
                StringBuilder sql = new StringBuilder();
                sql.Append("delete from account_info where account=@account");
                Dictionary<string, object> sp = new Dictionary<string, object>();
                sp.Add("@account", account);

                //删除成功
                if (new ADOHelper().IDU(sp, sql).status)
                {
                    mb.status = true;
                    mb.msg = "删除学生成功。";
                }
                else {
                    mb.status = false;
                    mb.msg = "学生删除成功，账户删除失败。";
                }
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return mb;
        }

    }
}
