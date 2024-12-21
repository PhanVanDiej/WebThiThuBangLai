using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiThuBangLaiOnline.Models;

namespace WebThiThuBangLaiOnline.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Customer/Home
        private readonly ApplicationDbContext _dbContext= new ApplicationDbContext();
        public ActionResult Index()
        {
            var items = _dbContext.Tests.ToList();
            return View(items);
        }
    }
}