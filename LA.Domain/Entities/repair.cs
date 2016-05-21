using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class repair:PersistenceEntity
    {
        public virtual string labName { get; set; }
        public virtual string repairName { get; set; }
        public virtual string account { get; set; }

        public virtual int isDone { get; set; }
    }
}
