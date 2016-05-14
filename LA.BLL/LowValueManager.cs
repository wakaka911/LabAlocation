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
    public class LowValueManager
    {
        public GridData getLowValueList(int pageIndex, int pageSize)
        {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by a.CREATED desc) as rn, right('0000000'+ cast(a.sheetNo as varchar),7) as sheet_No, a.* from low_value a ");
            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }

        public MsgBox saveLowValue(low_value lv) {
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(lv.ID))
                lv.ID = Guid.NewGuid().ToString();
            try
            {
                new Repository<low_value>().Insert(lv);
                mb.status = true;
                mb.msg = "保存成功。";
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
