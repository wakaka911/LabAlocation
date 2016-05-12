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
    public class LabManager
    {
        public MsgBox labAdd(string lab_name) {
            MsgBox mb = new MsgBox();
            lab_info lb = new lab_info();
            lb.ID = Guid.NewGuid().ToString();
            lb.lab_name = lab_name;
            mb = new LabDAO().saveLab(lb);            
            return mb;
        }
        public MsgBox labDel(string lab_id) {
            MsgBox mb = new MsgBox();
            try
            {
                new Repository<lab_info>().Delete(lab_id);
                mb.status = true;
                mb.msg = "实验室已删除。";
            }
            catch(Exception e) {
                mb.status = false;
                mb.msg = e.ToString();
            }
            return mb;
        }
        public GridData getLabList(int pageIndex,int pageSize) {
            GridData gd = new GridData();
            StringBuilder sql = new StringBuilder();
            List<QueryField> qf = new List<QueryField>();
            MsgBox mb = new MsgBox();
            sql.Append("select ROW_NUMBER() over(order by a.CREATED desc) as rn, a.* from lab_info a ");
            int total = 0;
            gd.rows = new ADOHelper().pageSplit(pageIndex, pageSize, sql.ToString(), qf, out total, ref mb);
            gd.total = total;
            return gd;
        }

        public List<EasyUISelection> getLabSelection() {
            List<lab_info> li = new List<lab_info>();
            li = new Repository<lab_info>().GetAll() as List<lab_info>;
            List<EasyUISelection> le = new List<EasyUISelection>();
            foreach (lab_info l in li)
            {
                le.Add(new EasyUISelection() { text = l.lab_name, value = l.ID });
            }
            return le;
        }
    }
}
