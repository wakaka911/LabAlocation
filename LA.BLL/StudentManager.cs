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
    public class StudentManager
    {

        public MsgBox studentAdd(Student s)
        {
            //建立主键
            s.ID = Guid.NewGuid().ToString();
            //传到Dao层处理
            MsgBox mb = new StudentDAO().insertStudent(s);

            return mb;
        }
    }
}
