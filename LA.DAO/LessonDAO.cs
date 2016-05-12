using LA.Common;
using LA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.DAO
{
    public class LessonDAO
    {
        public MsgBox insertLesson(Lesson l) {

            MsgBox mb = new MsgBox();
            mb.status = false;

            if (string.IsNullOrEmpty(l.ID))
            {
                l.ID = Guid.NewGuid().ToString();
            }

            try
            {
                new Repository<Lesson>().Insert(l);
                mb.msg = "保存成功！";
                mb.status = true;
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
