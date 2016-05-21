using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class account_info : PersistenceEntity
    {
        public virtual string account { get; set; }
        public virtual string password { get; set; }

        public virtual int role { get; set; }
    }
}
