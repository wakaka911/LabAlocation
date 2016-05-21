
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
            //帐户密码
            string account = Request["account"] == null ? "" : Request["account"].ToString();
            string password = Request["password"] == null ? "" : Request["password"].ToString();
            string _role=Request["role"]==null?"-1":Request["role"].ToString();
            int role=-1;
            if(!int.TryParse(_role,out role))
                role=-1;
            account_info a = new account_info();
            a.account = account;
            a.password = password;
            a.role = role;

            Teacher t = new Teacher();

            t.teacherName = teacherName;
            t.teacherNo = teacherNo;
            t.teacherSex = teacherSex;
            t.teacherDep = teacherDep;
            t.account = account;

            MsgBox mb = new TeacherManager().teacherAdd(t,a);

            return Json(mb);

        }

        public ActionResult getTeacherList()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new TeacherManager().getTeacherList(pageIndex, pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }

        public ActionResult teacherDel()
        {
            string teacherId = Request["teacher_id"] == null ? "" : Request["teacher_id"].ToString();
            string account = Request["account"] == null ? "" : Request["account"].ToString();
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(teacherId))
            {
                mb.status = false;
                mb.msg = "找不到要删除的老师";
            }
            else
            {
                mb = new TeacherManager().teacherDel(teacherId, account);
            }
            return Json(mb);
        }
        

    }
}
