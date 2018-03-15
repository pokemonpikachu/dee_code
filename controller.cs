using leaveapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace leaveapp.Controllers
{
    public class leaveController : Controller
    {
        // GET: leave
        public ActionResult login()
        {
            return View();
        }
        DB01TEST01Entities db = new DB01TEST01Entities();
        [HttpPost]
        public ActionResult login(tblemp_328 e)
        {
            var obj1 = db.tblemp_328.Where(a => a.name.Equals(e.name) && a.pwd.Equals(e.pwd)).FirstOrDefault();
            var obj2 = db.tblemp_328.ToList();           
            if (obj1 != null)
            {
                foreach(var v in obj2)
                {
                    if(obj1.empid==v.supid)
                    {
                        return RedirectToAction("viewleave");
                    }
                }
            }
            Response.Write("<script>alert('access denied')</script>");
            return View(e);
        }

        public ActionResult viewleave()
        {
            var v=db.sp_tblemp2_328().ToList();
            ViewBag.Table = v;
            return View();
        }

        public ActionResult viewid(int id)
        {
            var v=db.sp_tblemp_viewall2_328(id).ToList();
            ViewBag.Table = v;
            return View();
        }

        public ActionResult update(tblleave_328 l)
        {
            var v = 0;
            v=db.sp_tblemp_update2_328(l.stat, l.remark, l.lid);           
            db.SaveChanges();
            if(v>0)
               return RedirectToAction("viewleave");
            return View();
        }
        public ActionResult logout()
        {
            return RedirectToAction("login");
        }
    }
}
