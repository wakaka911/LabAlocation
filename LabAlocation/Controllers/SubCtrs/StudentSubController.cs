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

            Student s = new Student();
            s.studentName = studentName;
            s.studentNo = studentNo;
            s.studentSex = studentSex;
            s.studentSession = studentSession;
            s.studentProfession = studentProfession;
            s.studentClass = studentClass;

            MsgBox mb = new StudentManager().studentAdd(s);

            return Json(mb);
        }

    }
}
