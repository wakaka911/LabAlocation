using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers
{
    public class LowValueController : Controller
    {
        //
        // GET: /LowValue/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult LowValue()
        {

            return View();
        }

    }
}
