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
    public class PropertySubController : Controller
    {
        //
        // GET: /PropertySub/

        public ActionResult savePropertyTake()
        {
            string account = System.Web.HttpContext.Current.Session["account"].ToString();
            property_take pt = new property_take();
            pt.ID = Guid.NewGuid().ToString();
            pt.propertyName = Request["propertyName"] == null ? "" : Request["propertyName"].ToString();
            pt.qty = int.Parse(Request["qty"] == null ? "0" : Request["qty"].ToString());
            pt.status = 0;
            pt.takeTime = DateTime.Now;
            pt.takeUnit = Request["takeUnit"] == null ? "" : Request["takeUnit"].ToString();
            pt.type = int.Parse(Request["type"] == null ? "" : Request["type"].ToString());
            pt.account = account;
            MsgBox mb = new PropertyTakeManager().saveTake(pt);
            return Json(mb);
        }

        public ActionResult savePropertyReg() {
            property_info pi = new property_info();
            pi.ID = Guid.NewGuid().ToString();
            pi.guige = Request["guige"] == null ? "" : Request["guige"].ToString();
            pi.invoiceNo = Request["invoiceNo"] == null ? "" : Request["invoiceNo"].ToString();
            pi.model = Request["model"] == null ? "" : Request["model"].ToString();
            pi.name = Request["name"] == null ? "" : Request["name"].ToString();
            pi.passer = Request["passer"] == null ? "" : Request["passer"].ToString();
            pi.perPrice = Request["perPrice"] == null ? "" : Request["perPrice"].ToString();
            pi.producer = Request["producer"] == null ? "" : Request["producer"].ToString();
            pi.taker = Request["taker"] == null ? "" : Request["taker"].ToString();
            pi.takeUnit = Request["takeUnit"] == null ? "" : Request["takeUnit"].ToString();
            DateTime buyTime=DateTime.Parse(Request["buyTime"].ToString());
            DateTime chuchangTime=DateTime.Parse(Request["chuchangTime"].ToString());
            pi.buyTime=buyTime;
            pi.chuchangTime = chuchangTime;
            MsgBox mb = new PropertyTakeManager().saveReg(pi);
            return Json(mb);
            
        }

        public ActionResult getTakeList() {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new GridData();
            gd = new PropertyTakeManager().getTakeList(pageIndex,pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }

        public ActionResult getRegList()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new GridData();
            gd = new PropertyTakeManager().getRegList(pageIndex, pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }
        public ActionResult returnTake() {
            string propertyTakeID = Request["propertyID"] == null ? "" : Request["propertyID"].ToString();
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(propertyTakeID))
            {
                mb.status = false;
                mb.msg = "待归还物品ID不能为空！";
            }
            else
                mb = new PropertyTakeManager().returnTake(propertyTakeID);
            return Json(mb);
        }
    }
}
