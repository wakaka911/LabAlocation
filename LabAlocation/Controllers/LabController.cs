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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Lab() {

            return View();
        }
        [Authorize]
        public ActionResult labBook() {
            return View();
        }
        [Authorize]
        public ActionResult labBookApprove() {
            return View();
        }

    }
}
