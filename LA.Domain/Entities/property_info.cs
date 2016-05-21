using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class property_info : PersistenceEntity
    {
        public virtual string takeUnit { get; set; }
        public virtual string perPrice { get; set; }
        public virtual string name { get; set; }
        public virtual string model { get; set; }
        public virtual string guige { get; set; }
        public virtual string producer { get; set; }
        public virtual DateTime buyTime { get; set; }
        public virtual DateTime chuchangTime { get; set; }
        public virtual string invoiceNo { get; set; }
        public virtual string taker { get; set; }
        public virtual string passer { get; set; }
        public virtual string path { get; set; }
    }
}
