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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StorageAdd()
        {
            return View();
        }
    }
}
