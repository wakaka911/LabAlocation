using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers
{
    public class LessonTableController : Controller
    {
        //
        // GET: /LessonTable/
        [Authorize]
        public ActionResult LessonTable()
        {
            return View();
        }
        [Authorize]
        public ActionResult LessonAdd()
        {
            return View();
        }

    }
}
