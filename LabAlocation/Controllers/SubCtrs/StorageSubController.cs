using LA.BLL;
using LA.Common;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers.SubCtrs
{
    public class StorageSubController : Controller
    {
        //
        // GET: /StorageSub/

        public ActionResult StorageAdd()
        {
            //前台接收的数据
            string goodsName = Request["studentName"] == null ? "" : Request["studentName"].ToString();
            string goodsType = Request["studentName"] == null ? "" : Request["studentName"].ToString();
            int goodsNum = Request["studentSex"] == null ? 1 : int.Parse(Request["studentSex"]);
            string goodsText = Request["studentName"] == null ? "" : Request["studentName"].ToString();
            Boolean textUpdate = Request["check"].Equals("1") ? true : false;

            Storage s = new Storage();

            s.goodsName = goodsName;
            s.goodsType = goodsType;
            s.goodsNum = goodsNum;
            s.goodsText = goodsText;
            s.textUpdate = textUpdate;

            MsgBox mb = new StorageManager().storageAdd(s);

            return Json(mb);
        }

    }
}
