using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LA.BLL;
using LA.Common;
using LA.Domain;

namespace LabAlocation.Controllers.SubCtrs
{
    public class HomeSubController : Controller
    {
        //
        // GET: /HomeSub/

        public ActionResult Demo()
        {
            string testField = Request["testField"] == null ? "" : Request["testField"].ToString();

            MsgBox mb = new DemoManager().DemoTest(testField);

            return Json(mb);
        }

    }
}
