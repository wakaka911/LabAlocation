using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class Lesson : PersistenceEntity
    {
        //课程名字
        public virtual string lessonName { get; set; }

        //课程编号
        public virtual string lessonNo { get; set; }

        //授课教师
        public virtual string lessonTeacher { get; set; }

        //周几上课
        public virtual int lessonWeekday { get; set; }
        //当天第几节课
        public virtual int lessonArrange { get; set; }

        //课程备注，用于标注班级，或者其他
        public virtual string lessonRemark { get; set; }

        //课程选用的实验室
        public virtual string lessonLab { get; set; }
        //教师名称，不用于数据库交互
        public virtual string teacherName { get; set; }
    }
}
