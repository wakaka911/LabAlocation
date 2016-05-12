using LA.Common;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.DAO
{
    public class StorageDAO
    {
        //用来检索是不是存在
        public Boolean checkExist(Storage s)
        {
            //有返回真
            return false;
        }

        //插入操作
        public MsgBox insertStorage(Storage s)
        {
            MsgBox mb = new MsgBox();
            mb.status = false;
            return mb;
        }

        //更新操作
        public MsgBox updateStorage(Storage s)
        {

            //判断是不是覆盖备注s
            MsgBox mb = new MsgBox();
            mb.status = false;
            return mb;
        }
    }
}
