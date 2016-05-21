using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Common;
using LA.DAO;
using LA.Domain;

namespace LA.BLL
{
    public class RepairManager
    {
        public MsgBox saveRepair(repair r) {
            MsgBox mb = new MsgBox();
            if(string.IsNullOrEmpty( r.ID))
                r.ID=Guid.NewGuid().ToString();
            try
            {
                lab_info li = new Repository<lab_info>().Get(r.labName);
                r.labName = li.lab_name;
                new Repository<repair>().Insert(r);
                mb.status = true;
                mb.msg = "报修成功。";
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return mb;
        }

        public GridData getRepairList(int pageIndex,int pageSize) {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by a.CREATED desc) as rn, (isnull(t.teacherName,'')+isnull( s.studentName,'')) as whoPost, a.* from repair a ");
            sql.Append("left join teacher t on t.account=a.account ");
            sql.Append("left join student s on s.account=a.account ");
            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }
        public GridData getYearList(int pageIndex, int pageSize)
        {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by a.CREATED desc) as rn, a.* from year_repair a ");
            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }
        public MsgBox setRepairFinished(string id)
        {
            MsgBox mb = new MsgBox();
            repair r = new Repository<repair>().Get(id);
            r.isDone = 1;
            try
            {
                new Repository<repair>().Update(r);
                mb.status = true;
                mb.msg = "维修记录更新成功。";
            }
            catch (Exception e)
            {
                mb.status = false;
                mb.msg = e.Message;
            }
            return mb;
        }


        public MsgBox caculate() {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            DateTime st = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            DateTime et = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);
            qf.Add(new QueryField() {Name="st",Type=QueryFieldType.DateTime,Value=st });
            qf.Add(new QueryField() { Name = "et", Type = QueryFieldType.DateTime, Value = et });
            MsgBox mb = new MsgBox();
            sql.Append("select COUNT(*) as qty from repair r ");
            sql.Append("where r.isDone=1 ");
            sql.Append("and r.UPDATED>@st ");
            sql.Append("and r.UPDATED<@et ");
            try
            {
                dt = NHHelper.ExecuteDataset(sql.ToString(), qf).Tables[0];
                int qty = int.Parse(dt.Rows[0]["qty"].ToString());
                year_repair yr = new year_repair();
                yr.ID = Guid.NewGuid().ToString();
                yr.qty = qty;
                yr.year = DateTime.Now.Year.ToString();
                new Repository<year_repair>().Insert(yr);
                mb.status = true;
                mb.msg = "计算完成。";
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
