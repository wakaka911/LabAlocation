using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LA.Domain;
using LA.BLL;
using LA.Common;

namespace LabAlocation.Controllers.SubCtrs
{
    public class StudentSubController : Controller
    {
        //
        // GET: /StudentSub/

        public ActionResult studentAdd()
        {
            //前台接收的数据
            string studentName = Request["studentName"] == null ? "" : Request["studentName"].ToString();
            string studentNo = Request["studentNo"] == null ? "" : Request["studentNo"].ToString();
            int studentSex = Request["studentSex"] == null ? 1 : int.Parse(Request["studentSex"]);
            string studentSession = Request["studentSession"] == null ? "" : Request["studentSession"].ToString();
            string studentProfession = Request["studentProfession"] == null ? "" : Request["studentProfession"].ToString();
            string studentClass = Request["studentClass"] == null ? "" : Request["studentClass"].ToString();
           //帐户密码
            string account = Request["account"] == null ? "" : Request["account"].ToString();
            string password = Request["password"] == null ? "" : Request["password"].ToString();
            string _role = Request["role"] == null ? "-1" : Request["role"].ToString();
            int role = -1;
            if (!int.TryParse(_role, out role))
                role = -1;
            account_info a = new account_info();
            a.account = account;
            a.password = password;
            a.role = role;


            Student s = new Student();
            s.studentName = studentName;
            s.studentNo = studentNo;
            s.studentSex = studentSex;
            s.studentSession = studentSession;
            s.studentProfession = studentProfession;
            s.studentClass = studentClass;
            s.account = account;




            MsgBox mb = new StudentManager().studentAdd(s,a);

            return Json(mb);
        }


        public ActionResult getStudentList()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new StudentManager().getStudentList(pageIndex, pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }


        public ActionResult studentDel()
        {
            string studentId = Request["student_id"] == null ? "" : Request["student_id"].ToString();
            string account = Request["account"] == null ? "" : Request["account"].ToString();
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(studentId))
            {
                mb.status = false;
                mb.msg = "找不到要删除的学生";
            }
            else
            {
                mb = new StudentManager().studentDel(studentId, account);
            }
            return Json(mb);
        }
    }
}
