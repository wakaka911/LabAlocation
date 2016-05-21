using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult StudentAdd()
        {
            return View();
        }

    }
}
