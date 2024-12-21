using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebThiThuBangLaiOnline.Models;
using WebThiThuBangLaiOnline.Models.Entity;

namespace WebThiThuBangLaiOnline.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _dbConnect=new ApplicationDbContext();
        public ActionResult Index()
        {
            var items=_dbConnect.Menus.ToList();
            return View(items);
        }
        public ActionResult AddMenu()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMenu(Menu model) 
        {
            if (ModelState.IsValid) 
            {
                model.Alias = Models.Common.Filter.FilterChar(model.Title);
                _dbConnect.Menus.Add(model);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult EditMenu(int ID) 
        {
            if (ID != null)
            {
                var item = _dbConnect.Menus.Find(ID);
                return View(item);
            }
            else
            {
               return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMenu(Menu model)
        {
            if (ModelState.IsValid)
            {
                _dbConnect.Menus.Attach(model);
                model.Alias = Models.Common.Filter.FilterChar(model.Title);
                _dbConnect.Entry(model).Property(x=>x.Title).IsModified=true;
                _dbConnect.Entry(model).Property(x=>x.Position).IsModified=true;
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteMenu(int ID)
        {
            var item= _dbConnect.Menus.Find(ID);
            if (item != null)
            {
                _dbConnect.Menus.Remove(item);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}