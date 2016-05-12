using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Domain
{
    public class Storage : PersistenceEntity
    {
        //名称
        public virtual string goodsName { get; set; }

        //类型
        public virtual string goodsType { get; set; }

        //数量
        public virtual int goodsNum { get; set; }

        //备注
        public virtual string goodsText { get; set; }

        //是否更新备注信息
        public virtual Boolean textUpdate { get; set; }

    }

}
