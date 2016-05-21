using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class Student : PersistenceEntity
    {


        public virtual string studentName { get; set; }

        public virtual string studentNo { get; set; }

        public virtual int studentSex { get; set; }

        public virtual string studentSession { get; set; }

        public virtual string studentProfession { get; set; }

        public virtual string studentClass { get; set; }

        public virtual string account { get; set; }
    }
}
