using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Common;
using LA.DAO;
using LA.Domain;

namespace LA.BLL
{
    public class DemoManager
    {
        test ts = new test();
        public MsgBox DemoTest(string insertData) {
            ts.ID = Guid.NewGuid().ToString();
            ts.testField = insertData;
            MsgBox mb = new DemoDAO().saveDemo(ts);

            return mb;
        }


    }
}
