using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiThuBangLaiOnline.Models;

namespace WebThiThuBangLaiOnline.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _dbConnect=new ApplicationDbContext();
        public ActionResult Index()
        {
            var items=_dbConnect.Menus.ToList();
            return View(items);
        }
    }
}