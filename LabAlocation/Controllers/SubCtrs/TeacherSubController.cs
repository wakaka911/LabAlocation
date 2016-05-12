
using LA.BLL;
using LA.Common;
using LA.Domain;
using System.Web.Mvc;

namespace LabAlocation.Controllers.SubCtrs
{
    public class TeacherSubController : Controller
    {
        //
        // GET: /TeacherSub/

        public ActionResult teacherAdd()
        {
            //前台接收的数据
            string teacherName = Request["teacherName"] == null ? "" : Request["teacherName"].ToString();
            string teacherNo = Request["teacherNo"] == null ? "" : Request["teacherNo"].ToString();
            int teacherSex = Request["teacherSex"] == null ? 1 : int.Parse(Request["teacherSex"]);
            string teacherDep = Request["teacherDep"] == null ? "" : Request["teacherDep"].ToString();

            Teacher t = new Teacher();

            t.teacherName = teacherName;
            t.teacherNo = teacherNo;
            t.teacherSex = teacherSex;
            t.teacherDep = teacherDep;

            MsgBox mb = new TeacherManager().teacherAdd(t);

            return Json(mb);

        }

    }
}
