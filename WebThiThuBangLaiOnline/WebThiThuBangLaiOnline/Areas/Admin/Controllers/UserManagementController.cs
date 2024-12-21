using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiThuBangLaiOnline.Models;
using WebThiThuBangLaiOnline.Models.Entity;

namespace WebThiThuBangLaiOnline.Areas.Admin.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: Admin/UserManagement
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            var items = _dbContext.Users;
            return View(items);
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(User model)
        {
            if (ModelState.IsValid)
            {
                model.Alias = Models.Common.Filter.FilterChar(model.Name);
                model.Birthday=model.Birthday.Date;
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult EditUser(string ID)
        {
            if (ID != null)
            {
                var user = _dbContext.Users.Find(ID);
                return View(user);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Attach(user);
                _dbContext.Entry(user).Property(x => x.Name).IsModified = true;
                _dbContext.Entry(user).Property(x => x.Email).IsModified = true;
                _dbContext.Entry(user).Property(x => x.Birthday).IsModified = true;
                _dbContext.Entry(user).Property(x => x.UserName).IsModified = true;
                _dbContext.Entry(user).Property(x => x.Password).IsModified = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(string id)
        {
            if (id != null)
            {
                var user = _dbContext.Users.Find(id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return Json(new { success = true });
                
            }
            return Json(new { success = false });
        }
    }
}