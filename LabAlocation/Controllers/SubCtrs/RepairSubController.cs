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
    public class RepairSubController : Controller
    {
        //
        // GET: /RepairSub/

        public ActionResult saveRepair()
        {
            MsgBox mb = new MsgBox();
            repair r = new repair();
            r.ID = Guid.NewGuid().ToString();
            r.labName = Request["labName"] == null ? "" : Request["labName"].ToString();
            r.repairName = Request["repairName"] == null ? "" : Request["repairName"].ToString();
            r.account = System.Web.HttpContext.Current.Session["account"].ToString();
            r.isDone = 0;
            mb = new RepairManager().saveRepair(r);
            return Json(mb);
        }

        public ActionResult getRepairList() {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new RepairManager().getRepairList(pageIndex,pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }

        public ActionResult repairFinished() {
            string id = Request["ID"] == null ? "" : Request["ID"].ToString();
            MsgBox mb=new MsgBox();
            if (string.IsNullOrEmpty(id))
            {
                mb.status = false;
                mb.msg = "待维修ID不能为空。";
            }
            else
             mb= new RepairManager().setRepairFinished(id);
            return Json(mb);
        }

        public ActionResult getYearList() {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new RepairManager().getYearList(pageIndex, pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }

        public ActionResult caculate() {
            MsgBox mb = new RepairManager().caculate();
            return Json(mb);
        }
    }
}
