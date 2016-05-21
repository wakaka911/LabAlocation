using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class property_take : PersistenceEntity
    {
        public virtual string account{get;set;}
        public virtual int type { get; set; }
        public virtual string takeUnit { get; set; }

        public virtual DateTime? takeTime { get; set; }
        public virtual string propertyName { get; set; }
        public virtual int qty { get; set; }

        public virtual int status { get; set; }
    }
}
