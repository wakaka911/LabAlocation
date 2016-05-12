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
    public class LabSubController : Controller
    {
        //
        // GET: /LabSub/
        //增加实验室
        public ActionResult labAdd()
        {
            MsgBox mb = new MsgBox();
            string lab_name = Request["lab_name"] == null ? "" : Request["lab_name"].ToString();
            if (!string.IsNullOrEmpty(lab_name))
            {
                mb = new LabManager().labAdd(lab_name);
            }
            else
            {
                mb.status = false;
                mb.msg = "实验室名称不能为空。";
            }
            return Json(mb);
        }
        //删除实验室
        public ActionResult labDel() {
            MsgBox mb = new MsgBox();
            string lab_id = Request["lab_id"] == null ? "" : Request["lab_id"].ToString();
            if (!string.IsNullOrEmpty(lab_id))
                mb = new LabManager().labDel(lab_id);
            else
            {
                mb.status = false;
                mb.msg = "实验室编号不能为空。";
            }
            return Json(mb);
        }

        //获取现有实验室列表
        public ActionResult getLabList() {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new LabManager().getLabList(pageIndex, pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }

    }
}
