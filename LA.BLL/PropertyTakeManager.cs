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
    public class PropertyTakeManager
    {
        public GridData getTakeList(int pageIndex, int pageSize)
        {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by pt.CREATED desc) as rn, pt.*,(isnull(t.teacherName,'')+isnull( s.studentName,'')) as takePeople, case pt.type when 0 then '低值易耗品' when 1 then '实验室设备、密钥' end as typecn from property_take pt ");
            sql.Append("left join teacher t on t.account=pt.account ");
            sql.Append("left join student s on s.account=pt.account ");
            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }
        public GridData getRegList(int pageIndex, int pageSize)
        {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by p.CREATED desc) as rn,p.* from property_info p ");

            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }

        public MsgBox saveTake(property_take pt)
        {
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(pt.ID))
                pt.ID = Guid.NewGuid().ToString();

            try
            {
                new Repository<property_take>().Insert(pt);
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
        public MsgBox saveReg(property_info pi) {
            MsgBox mb = new MsgBox();
            if (string.IsNullOrEmpty(pi.ID))
                pi.ID = Guid.NewGuid().ToString();
            try
            {
                new Repository<property_info>().Insert(pi);
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
        public MsgBox returnTake(string propertyID)
        {
            MsgBox mb = new MsgBox();
            try
            {
                property_take pt = new Repository<property_take>().Get(propertyID);
                pt.status = 2;
                new Repository<property_take>().Update(pt);
                mb.status = true;
                mb.msg = "归还成功。";
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
