using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Common;

namespace LA.BLL
{
    public class LabManager
    {
        public MsgBox labAdd(string lab_name) {
            MsgBox mb = new MsgBox();
            StringBuilder sql = new StringBuilder();
            Dictionary<string, object> sp = new Dictionary<string, object>();
            sp.Add("@lab_name", lab_name);
            sql.Append("insert into ");
            return mb;
        }
    }
}
