using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LA.BLL;
using LA.Common;
using LA.Domain;

namespace LabAlocation.Controllers.SubCtrs
{
    public class HomeSubController : Controller
    {
        //
        // GET: /HomeSub/
        [Authorize]
        public ActionResult Demo()
        {
            string testField = Request["testField"] == null ? "" : Request["testField"].ToString();

            MsgBox mb = new DemoManager().DemoTest(testField);

            return Json(mb);
        }
        [Authorize]
        public ActionResult PasswordChange() {
            string pwd = Request["pwd"] == null ? "" : Request["pwd"].ToString();
            string account=Session["account"].ToString();
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(pwd))
            {
                mb.msg = "密码不能为空。";
                mb.status = false;
            }
            else
            mb = AccountManager.changePassword(account,pwd);
            return Json(mb);
        }

        [Authorize]

        public ActionResult GetMenu()
        {
            MsgBox mb = new MsgBox();
            string account=Session["account"].ToString();
            mb.obj = AccountManager.getMenu(account);
            return Json(mb);
        }

    }
}
