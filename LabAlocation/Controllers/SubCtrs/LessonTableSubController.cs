﻿using LA.BLL;
using LA.Common;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabAlocation.Controllers.SubCtrs
{
    public class LessonTableSubController : Controller
    {
        //
        // GET: /LessonTableSub/

        public ActionResult LessonAdd()
        {
            //前台接收数据
            string lessonName = Request["lesson_name"] == null ? "" : Request["lesson_name"].ToString();
            string lessonNo = Request["lesson_no"] == null ? "" : Request["lesson_no"].ToString();
            string lessonTeacher = Request["lesson_teacher"] == null ? "" : Request["lesson_teacher"].ToString();
            string lesson_Weekday = Request["lesson_weekday"] == null ? "" : Request["lesson_weekday"].ToString();
            string lesson_Arrange = Request["lesson_arrange"] == null ? "" : Request["lesson_arrange"].ToString();
            string lessonRemark = Request["lesson_remark"] == null ? "" : Request["lesson_remark"].ToString();
            string lessonLab = Request["lessonLab"] == null ? "" : Request["lessonLab"].ToString();
            int lessonWeekday;
            int lessonArrange;
            MsgBox mb = new MsgBox();
            if ((int.TryParse(lesson_Weekday, out lessonWeekday) && int.TryParse(lesson_Arrange, out lessonArrange)))
            {
                //赋值给lesson(可以用构造函数的)
                Lesson ls = new Lesson();
                ls.lessonName = lessonName;
                ls.lessonNo = lessonNo;
                ls.lessonTeacher = lessonTeacher;
                ls.lessonWeekday = lessonWeekday;
                ls.lessonArrange = lessonArrange;
                ls.lessonRemark = lessonRemark;
                ls.lessonLab = lessonLab;
                //传到逻辑业务层
                mb = new LessonManager().lessonAdd(ls);
            }
            else
            {
                mb.status = false;
                mb.msg = "上课时间设置错误！";
            }
           
            return Json(mb);
        }

        public ActionResult LessonDel() {
            string lessonID = Request["lesson_id"] == null ? "" : Request["lesson_id"].ToString();
            MsgBox mb=new MsgBox();
            if (string.IsNullOrEmpty(lessonID))
            {
                mb.status = false;
                mb.msg = "待删除课程ID不能为空。";
            }
            else
                mb = new LessonManager().lessonDel(lessonID);
            return Json(mb);

        }
        //查询课程列表
        public ActionResult getLessonList() {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new LessonManager().getLessonList(pageIndex, pageSize);
            string s = JsonHelper.JsonDllSerializeEntity<GridData>(gd);
            return Content(s);
        }
        //保存临时申请课程以及实验室
        public ActionResult saveTempLesson() {
            string lessonName = Request["lessonName"] == null ? "" : Request["lessonName"].ToString();
            string lessonNo = Request["lessonNo"] == null ? "" : Request["lessonNo"].ToString();
            string lessonTeacher = Request["lessonTeacher"] == null ? "" : Request["lessonTeacher"].ToString();
            string lesson_Arrange = Request["lessonArrange"] == null ? "" : Request["lessonArrange"].ToString();
            string lessonRemark = Request["lessonRemark"] == null ? "" : Request["lessonRemark"].ToString();
            string lessonLab = Request["lessonLab"] == null ? "" : Request["lessonLab"].ToString();
            string lesson_Day = Request["lessonDay"] == null ? "" : Request["lessonDay"].ToString();
            int lessonArrange;
            DateTime lessonDay;
            temp_lesson tl = new temp_lesson();
            MsgBox mb = new MsgBox();
            if (int.TryParse(lesson_Arrange, out lessonArrange) && DateTime.TryParse(lesson_Day, out lessonDay))
            {
                tl.ID = Guid.NewGuid().ToString();
                tl.lessonName = lessonName;
                tl.lessonNo = lessonNo;
                tl.lessonTeacher = lessonTeacher;
                tl.lessonArrange = lessonArrange;
                tl.lessonRemark = lessonRemark;
                tl.lessonLab = lessonLab;
                tl.lessonDay = lessonDay;
                mb = new LessonManager().saveTempLesson(tl);
            }
            else {
                mb.status = false;
                mb.msg = "上课时间段选择错误或者时间输入错误。";
            }
            return Json(mb);
        }

        //删除临时申请课程以及实验室
        public ActionResult delTempLesson() {
            string lessonID = Request["lesson_id"] == null ? "" : Request["lesson_id"].ToString();
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(lessonID))
            {
                mb.status = false;
                mb.msg = "待删除申请ID不能为空。";
            }
            else
                mb = new LessonManager().tempLessonDel(lessonID);
            return Json(mb);
        }
        //查询临时申请课程以及实验室列表
        public ActionResult getTempLessonList() {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            GridData gd = new LessonManager().getTempLessonList(pageIndex, pageSize);
            string s = JsonHelper.JsonDllSerializeSingle<GridData>(gd);
            return Content(s);
        }
        //根据实验室id查询实验室一周课表
        public ActionResult labSchedule() {
            string labID = Request["lab_id"] == null ? "" : Request["lab_id"].ToString();
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(labID))
            {
                mb.status = false;
                mb.msg = "实验室ID不能为空！";
            }
            else
            {
                
                mb.obj = new LessonManager().getLabSchedule(labID);
                mb.status = true;
            }
            return Json(mb);
        }
    }
}
