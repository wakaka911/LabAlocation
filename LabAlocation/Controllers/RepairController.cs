using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers
{
    public class RepairController : Controller
    {
        //
        // GET: /Repair/
        [Authorize]
        public ActionResult Repair()
        {
            return View();
        }
        [Authorize]
        public ActionResult RepairList() {
            return View();
        }
        [Authorize]
        public ActionResult YearRepair() {
            return View();
        }
    }
}
