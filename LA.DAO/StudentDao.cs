using LA.Common;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.DAO
{
    public class StudentDAO
    {
        //增加学生
        public MsgBox insertStudent(Student s,account_info a)
        {
            MsgBox mb = new MsgBox();
            mb.status = false;
            if (string.IsNullOrEmpty(s.ID))
            {
                s.ID = Guid.NewGuid().ToString();
            }

            try
            {
                new Repository<Student>().Insert(s);
                new Repository<account_info>().Insert(a);
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
