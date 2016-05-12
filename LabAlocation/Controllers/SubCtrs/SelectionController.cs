using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LA.BLL;
using LA.Common;

namespace LabAlocation.Controllers.SubCtrs
{
    public class SelectionController : Controller
    {
        //
        // GET: /Selection/

        public ActionResult getLabs()
        {
            List<EasyUISelection> le = new List<EasyUISelection>();
            le = new LabManager().getLabSelection();
            return Json(le);
        }

    }
}
