using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LA.Domain;
using LA.Common;
namespace LA.DAO
{
     public class DemoDAO
    {
         public MsgBox saveDemo(test ts) {
             MsgBox mb = new MsgBox();
             mb.status = false;
             if (string.IsNullOrEmpty(ts.ID))
             {
                 ts.ID = Guid.NewGuid().ToString();
             }
             try
             {
                 new Repository<test>().Insert(ts);
                 mb.msg = "保存成功！";
                 mb.status = true;
             }
             catch (Exception e)
             {
                 mb.status = false;
                 mb.msg = "保存失败。";
                
             }
             return mb;
         }
    }
}
