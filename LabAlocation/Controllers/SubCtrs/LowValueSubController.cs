using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LA.BLL;
using LA.Common;
using LA.Domain;

namespace LabAlocation.Controllers.SubCtrs
{
    public class LowValueSubController : Controller
    {
        //
        // GET: /LowValueSub/

        public ActionResult getLowValueList()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new LowValueManager().getLowValueList(pageIndex, pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }

        public ActionResult saveLowValue() {
            MsgBox mb=new MsgBox();
            low_value lv = new low_value();
            lv.ID=Guid.NewGuid().ToString();
            lv.sheetNo=int.Parse(Request["sheetNo"].ToString());
            lv.takeUnit=Request["takeUnit"].ToString();
            lv.checkTime = DateTime.Parse(Request["checkTime"].ToString());
            lv.attachmentTotalPrice=Request["attachmentTotalPrice"].ToString();
            lv.sumPrice=Request["sumPrice"].ToString();
            lv.chairman=Request["chairman"].ToString();
            lv.buyer=Request["buyer"].ToString();
            lv.taker=Request["taker"].ToString();
            lv.checker=Request["checker"].ToString();
            

            lv.model1=Request["model1"].ToString();
            lv.name1=Request["name1"].ToString();
            lv.no1=Request["no1"].ToString();
            lv.price1=Request["price1"].ToString();
            lv.qty1=Request["qty1"].ToString();
            lv.totalPrice1=Request["totalPrice1"].ToString();
            lv.unit1=Request["unit1"].ToString();

            lv.model2 = Request["model2"].ToString();
            lv.name2 = Request["name2"].ToString();
            lv.no2 = Request["no2"].ToString();
            lv.price2 = Request["price2"].ToString();
            lv.qty2 = Request["qty2"].ToString();
            lv.totalPrice2 = Request["totalPrice2"].ToString();
            lv.unit2 = Request["unit2"].ToString();

            lv.model3 = Request["model3"].ToString();
            lv.name3 = Request["name3"].ToString();
            lv.no3 = Request["no3"].ToString();
            lv.price3 = Request["price3"].ToString();
            lv.qty3 = Request["qty3"].ToString();
            lv.totalPrice3 = Request["totalPrice3"].ToString();
            lv.unit3 = Request["unit3"].ToString();

            lv.model4 = Request["model4"].ToString();
            lv.name4 = Request["name4"].ToString();
            lv.no4 = Request["no4"].ToString();
            lv.price4 = Request["price4"].ToString();
            lv.qty4 = Request["qty4"].ToString();
            lv.totalPrice4 = Request["totalPrice4"].ToString();
            lv.unit4 = Request["unit4"].ToString();

            mb = new LowValueManager().saveLowValue(lv);
            return Json(mb);
        }

        public ActionResult getSheetNo() {
            MsgBox mb = new MsgBox();
            try
            {
                mb.obj = new LowValueManager().getSheetNo();
                mb.status = true;
                mb.msg = "获取编号成功。";
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return Json(mb);
        }

        public FileResult getExport() {
            DataTable dt = new LowValueManager().getExcel();
            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
            List<string> ttls = new List<string> { "数据库记录ID","单据编号", "领物单位", "验收日期", "编号1", "名称1", "规格型号1", "单位1", "数量1", "单价1", "金额1（元）", "编号2", "名称2", "规格型号2", "单位2", "数量2", "单价2", "金额2（元）", "编号3", "名称3", "规格型号3", "单位3", "数量3", "单价3", "金额3（元）", "编号4", "名称4", "规格型号4", "单位4", "数量4", "单价4", "金额4（元）", "其他总额合计（元）", "合计", "部门负责人", "采购人", "领用人", "验收人","更新日期","创建日期"};
            List<int> cols = new List<int>();
            for (int i = 0; i < 40; i++)
                cols.Add(i);
            ExportHelper.CreateExcel(workbook, ttls, cols, dt, "低值耐用品及耗材验收单", "低值耐用品及耗材验收单", "");
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                var buffer = ms.GetBuffer();
                ms.Close();
                return File(buffer, "application/ms-excel", "验收单.xlsx");
            }
        }
    }
}
