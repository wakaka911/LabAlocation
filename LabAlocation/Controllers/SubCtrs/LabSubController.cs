using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LA.BLL;
using LA.Common;

namespace LabAlocation.Controllers.SubCtrs
{
    public class LabSubController : Controller
    {
        //
        // GET: /LabSub/

        public ActionResult labAdd()
        {
            MsgBox mb = new MsgBox();
            string lab_name = Request["lab_name"] == null ? "" : Request["lab_name"].ToString();
            if (!String.IsNullOrEmpty(lab_name))
            { 
               // mb=new LabManager()
            }
            else
            {
                mb.status = false;
                mb.msg = "实验室名称不能为空。";
            }
            return Json(mb);
        }

    }
}
