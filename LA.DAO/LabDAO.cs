using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Common;
using LA.Domain;

namespace LA.DAO
{
    public class LabDAO
    {
        public MsgBox saveLab(lab_info lb) {
            MsgBox mb = new MsgBox();
            mb.status = false;
            if (string.IsNullOrEmpty(lb.ID))
                lb.ID = Guid.NewGuid().ToString();
            try
            {
                new Repository<lab_info>().Insert(lb);
                mb.status = true;
                mb.msg = "实验室新增成功。";
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return mb;
        }
    }
}
