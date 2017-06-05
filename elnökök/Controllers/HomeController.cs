using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elnökök.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Login obj = new Login();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Index(Login objuserlogin)
        {
            var display = Userloginvalues().Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword).FirstOrDefault();
            if (display != null)
            {
                ViewBag.Status = "CORRECT UserName and Password";
                Response.Redirect("~/pres.html");
            }
            else
            {
                ViewBag.Status = "INCORRECT UserName or Password";
            }
            return View(objuserlogin);
        }
        public List<Login> Userloginvalues()
        {
            List<Login> objModel = new List<Login>();
            objModel.Add(new Login { UserName = "george", UserPassword = "pres1" });
            objModel.Add(new Login { UserName = "donald", UserPassword = "pres45" });
            objModel.Add(new Login { UserName = "jamesmon", UserPassword = "pres5" });
            objModel.Add(new Login { UserName = "lbj", UserPassword = "pres36" });
            objModel.Add(new Login { UserName = "jfk", UserPassword = "pres35" });
            return objModel;
        }
    }
}