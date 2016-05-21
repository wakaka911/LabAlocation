using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers
{
    public class StorageController : Controller
    {
        //
        // GET: /Storage/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult StorageAdd()
        {
            return View();
        }
    }
}
