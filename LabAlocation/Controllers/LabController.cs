using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers
{
    public class LabController : Controller
    {
        //
        // GET: /Lab/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lab() {

            return View();
        }

        public ActionResult labBook() {
            return View();
        }

    }
}
