using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        [Authorize]
        public ActionResult Index()
        {
            //ISession session = NHHelper.GetCurrentSession();

            //ITransaction tx = session.BeginTransaction();

            //test princess = new test();
            //princess.id = "Princess";
            //princess.testField = "asdfasdfad";

            //session.Save(princess);
            //tx.Commit();

            //NHHelper.CloseSession();
            return View();
        }
        [Authorize]
        public ActionResult TeacherAdd() {
            return View();
        }

    }
}
