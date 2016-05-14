using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class low_value : PersistenceEntity
    {
        public virtual int sheetNo { get; set; }
        public virtual string takeUnit { get; set; }
        public virtual DateTime? checkTime { get; set; }

        public virtual string no1 { get; set; }
        public virtual string name1 { get; set; }
        public virtual string model1 { get; set; }
        public virtual string unit1 { get; set; }
        public virtual string qty1 { get; set; }
        public virtual string price1 { get; set; }
        public virtual string totalPrice1 { get; set; }
        public virtual string no2 { get; set; }
        public virtual string name2 { get; set; }
        public virtual string model2 { get; set; }
        public virtual string unit2 { get; set; }
        public virtual string qty2 { get; set; }
        public virtual string price2 { get; set; }
        public virtual string totalPrice2 { get; set; }
        public virtual string no3 { get; set; }
        public virtual string name3 { get; set; }
        public virtual string model3 { get; set; }
        public virtual string unit3 { get; set; }
        public virtual string qty3 { get; set; }
        public virtual string price3 { get; set; }
        public virtual string totalPrice3 { get; set; }
        public virtual string no4 { get; set; }
        public virtual string name4 { get; set; }
        public virtual string model4 { get; set; }
        public virtual string unit4 { get; set; }
        public virtual string qty4 { get; set; }
        public virtual string price4 { get; set; }
        public virtual string totalPrice4 { get; set; }

        public virtual string sumPrice { get; set; }
        public virtual string attachmentTotalPrice { get; set; }
        public virtual string chairman { get; set; }
        public virtual string buyer { get; set; }
        public virtual string taker { get; set; }
        public virtual string checker { get; set; }
    }
}
