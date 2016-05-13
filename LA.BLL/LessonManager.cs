using LA.Common;
using LA.DAO;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.BLL
{
    public class LessonManager
    {
        

        public MsgBox lessonAdd(Lesson ls) {

            //建立主键
            ls.ID = Guid.NewGuid().ToString();
            //传到Dao层处理
            MsgBox mb = new LessonDAO().insertLesson(ls);

            return mb;
        }


        public MsgBox lessonDel(string ID)
        {
            MsgBox mb = new MsgBox();
            try
            {
                new Repository<Lesson>().Delete(ID);
                mb.status = true;
                mb.msg = "课程删除成功。";
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return mb;

        }

        public MsgBox tempLessonDel(string ID)
        {
            MsgBox mb = new MsgBox();
            try
            {
                new Repository<temp_lesson>().Delete(ID);
                mb.status = true;
                mb.msg = "删除成功。";
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return mb;

        }

        public MsgBox approveTempLesson(string ID)
        {
            MsgBox mb = new MsgBox();
            try
            {
                temp_lesson tl = new Repository<temp_lesson>().Get(ID);
                tl.status = 1;
                new Repository<temp_lesson>().Update(tl);
                mb.status = true;
                mb.msg = "审核通过，请至相应实验室课表查看。";
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return mb;
        }
        public GridData getLessonList(int pageIndex, int pageSize)
        {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by a.CREATED desc) as rn, a.*,t.teacherName from lesson a ");
            sql.Append("left join teacher t on a.lessonTeacher=t.teacherNo ");
            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }

        public GridData getTempLessonList(int pageIndex, int pageSize) {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by tl.CREATED desc) as rn, tl.*,t.teacherName,li.lab_name as labName from temp_lesson tl ");
            sql.Append("left join teacher t on tl.lessonTeacher=t.teacherNo ");
            sql.Append("left join lab_info li on li.ID=tl.lessonLab ");
            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }

        public List<Lesson> getLabSchedule(string labID) {
            List<QueryField>qf=new List<QueryField>();
            qf.Add(new QueryField(){Name="lessonLab",Type=QueryFieldType.String,Value=labID});
            List<Lesson> l = new Repository<Lesson>().GetList(qf, null) as List<Lesson>;
            foreach (Lesson ls in l)
            { 
                List<QueryField> qf2=new List<QueryField>();
                qf2.Add(new QueryField(){Name="teacherNo",Type=QueryFieldType.String,Value=ls.lessonTeacher});
                List<Teacher> t= new Repository<Teacher>().GetList(qf2, null) as List<Teacher>;
                if (t.Count > 0)
                    ls.teacherName = t[0].teacherName;
                else
                    ls.teacherName = "";
            }
            return l;
        }

        public List<temp_lesson> getTempLabSchedule(string labID, List<DateTime> ld)
        {
            List<QueryField> qf = new List<QueryField>();
            qf.Add(new QueryField() { Name = "lessonDay", Type = QueryFieldType.DateTime, Comparison = QueryFieldComparison.ge, Value = ld[0] });
            qf.Add(new QueryField() { Name = "lessonDay", Type = QueryFieldType.DateTime, Comparison = QueryFieldComparison.le, Value = ld[1] });
            qf.Add(new QueryField() { Name = "lessonLab", Type = QueryFieldType.String, Value = labID });
            qf.Add(new QueryField() { Name = "status", Type = QueryFieldType.Numeric, Value = 1 });
            List<temp_lesson> lt = new Repository<temp_lesson>().GetList(qf, null) as List<temp_lesson>;
            foreach (temp_lesson t_l in lt)
            {
                List<QueryField> qf2 = new List<QueryField>();
                qf2.Add(new QueryField() { Name = "teacherNo", Type = QueryFieldType.String, Value = t_l.lessonTeacher });
                List<Teacher> t = new Repository<Teacher>().GetList(qf2, null) as List<Teacher>;
                if (t.Count > 0)
                    t_l.teacherName = t[0].teacherName;
                else
                    t_l.teacherName = "";
            }
            return lt;
        }

        public MsgBox saveTempLesson(temp_lesson tl)
        {
            MsgBox mb = new MsgBox();
            tl.lessonWeekday = (int)tl.lessonDay.DayOfWeek==0?7:(int)tl.lessonDay.DayOfWeek;
            tl.status = 0;//0未审核；
            //判断当前是否与其他课程冲突
            if (lessonConflict(tl))
            {
                mb.status = false;
                mb.msg = "与其他课程冲突！";
            }
            else
            {
                try
                {
                    new Repository<temp_lesson>().Insert(tl);
                    mb.status = true;
                    mb.msg = "保存成功。";
                }
                catch (Exception e)
                {
                    mb.status = false;
                    mb.msg = e.Message;
                }
            }
            return mb;
        }


        //判断临时课程冲突,返回true表示有冲突，false表示无冲突
        public bool lessonConflict(temp_lesson tl) {
            bool result = false;
            int conflicts = 0;
            //判断与临时课程的冲突
            List<QueryField> qf=new List<QueryField>();
            qf.Add(new QueryField(){Name="lessonDay",Type=QueryFieldType.DateTime,Value=tl.lessonDay});
            qf.Add(new QueryField() { Name = "lessonArrange", Type = QueryFieldType.Numeric, Value = tl.lessonArrange });
            qf.Add(new QueryField() { Name = "lessonLab", Type = QueryFieldType.String, Value = tl.lessonLab });
            List<temp_lesson> list1 = new Repository<temp_lesson>().GetList(qf, null) as List<temp_lesson>; 

            //判断与课表冲突
            qf.Clear();
            qf.Add(new QueryField() { Name = "lessonWeekday", Type = QueryFieldType.Numeric, Value = tl.lessonWeekday });
            qf.Add(new QueryField() { Name = "lessonArrange", Type = QueryFieldType.Numeric, Value = tl.lessonArrange });
            qf.Add(new QueryField() { Name = "lessonLab", Type = QueryFieldType.String, Value = tl.lessonLab });
            List<Lesson> list2 = new Repository<Lesson>().GetList(qf, null) as List<Lesson>;
            conflicts = list1.Count + list2.Count;
            if (conflicts > 0)
                result = true;
            return result;


        }
    }
}
