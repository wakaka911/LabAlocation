using LA.Common;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.DAO
{
    public class TeacherDAO
    {

        public MsgBox insertTeacher(Teacher t) {

            MsgBox mb = new MsgBox();
            mb.status = false;

            if (string.IsNullOrEmpty(t.ID))
            {
                t.ID = Guid.NewGuid().ToString();
            }

            try
            {
                new Repository<Teacher>().Insert(t);
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
