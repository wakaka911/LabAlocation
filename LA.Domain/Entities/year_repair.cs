using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class year_repair : PersistenceEntity
    {
        public virtual string year { get; set; }
        public virtual int qty { get; set; }
    }
}
