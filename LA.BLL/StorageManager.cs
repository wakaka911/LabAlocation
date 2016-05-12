using LA.Common;
using LA.DAO;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.BLL
{
    public class StorageManager
    {

        public MsgBox storageAdd(Storage s)
        {
            //建立主键
            s.ID = Guid.NewGuid().ToString();

            MsgBox mb = null;

            //传到Dao层处理
            //存在的情况下，更新
            if (new StorageDAO().checkExist(s))
            {
                mb = new StorageDAO().updateStorage(s);
            }
                //否则就新增一条
            else {
                mb = new StorageDAO().insertStorage(s);
            }

            return mb;
        }
    }
}
