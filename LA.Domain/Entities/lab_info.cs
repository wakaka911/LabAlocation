using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class lab_info : PersistenceEntity
    {
        public virtual string lab_name { get; set; }
    }
}
