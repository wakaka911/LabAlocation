using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LA.BLL;
using LA.Common;
using LA.Domain;
using NHibernate;


namespace LabAlocation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       
        public ActionResult Index()
        {
            //ISession session = NHHelper.GetCurrentSession();

            //ITransaction tx = session.BeginTransaction();

            //test princess = new test();
            //princess.id = "Princess";
            //princess.testField = "asdfasdfad";

            //session.Save(princess);
            //tx.Commit();

            //NHHelper.CloseSession();
            return View();
        }
        [Authorize]
        public ActionResult Demo() {

            return View();
        }
        [Authorize]
        public ActionResult Home() {
            return View();
        }





        [HttpPost]
        public ActionResult Login(string account, string password)
        {
            MsgBox mb = new MsgBox();
            bool flag = false;
            flag = AccountManager.getAI(account, password);
            //AccountManager.GetAccountInfo(account);
            if (account != null && password != null && flag)
            {
                FormsAuthentication.SetAuthCookie(account, false);
                mb.status = true;
                mb.msg = "登陆成功。";
            }
            else
            {
                mb.status = false;
                mb.msg = "登陆失败，用户名或密码错误。";
            }
                return Json(mb);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Home");
        }

    }
}
