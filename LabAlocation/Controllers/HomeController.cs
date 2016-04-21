using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LA.Domain;
using NHibernate;

namespace LabAlocation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

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

        public ActionResult Demo() {
            return View();
        }

    }
}
