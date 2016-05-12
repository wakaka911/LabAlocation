using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class Teacher : PersistenceEntity
    {
         //教师名称
         public virtual string teacherName { get; set; }

        //教师工号
         public virtual string teacherNo { get; set; }

        //教师性别（1：男，2：女）
         public virtual int teacherSex { get; set; }

        //教师部门
         public virtual string teacherDep { get; set; }

        //教师的账户
         public virtual string account { get; set; }

    }
}
