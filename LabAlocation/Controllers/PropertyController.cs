using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers
{
    public class PropertyController : Controller
    {
        //
        // GET: /Property/
        [Authorize]
        public ActionResult PropertyTake()
        {
            
            return View();
        }

        public ActionResult PropertyReg() {
            return View();
        }

    }
}
