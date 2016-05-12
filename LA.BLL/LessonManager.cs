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
    }
}
