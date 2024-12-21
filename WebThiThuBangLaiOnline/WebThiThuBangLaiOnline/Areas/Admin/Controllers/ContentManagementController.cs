using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiThuBangLaiOnline.Models;
using WebThiThuBangLaiOnline.Models.Entity;
using static System.Net.Mime.MediaTypeNames;

namespace WebThiThuBangLaiOnline.Areas.Admin.Controllers
{
    public class ContentManagementController : Controller
    {
        // GET: Admin/ContentManagement
        private readonly ApplicationDbContext _dbConnect = new ApplicationDbContext();
        public ActionResult Index()
        {
            var items = _dbConnect.Tests.ToList();
            return View(items);
        }
        public ActionResult AddTest()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTest(Test test)
        {
            if (ModelState.IsValid)
            {
                test.Alias = Models.Common.Filter.FilterChar(test.Name);
                _dbConnect.Tests.Add(test);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        public ActionResult EditTest(string ID)
        {
            if (ID != null)
            {
                var test = _dbConnect.Tests.Include("Questions").FirstOrDefault(q => q.TestID == ID);
                if (test != null)
                {
                    return View(test);
                }
                else return HttpNotFound("Error while loading data");
            }
            else
                return RedirectToAction("Index");
        }
        public ActionResult AddQuestion(string testID)
        {
            var model = new Question
            {
                Type = 0,
                TestID = testID
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestion(Question question, int questionType, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    // Generate a unique file name to prevent collisions
                    var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    var extension = Path.GetExtension(ImageFile.FileName);
                    var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                    // Define the path to save the image
                    var path = Path.Combine(Server.MapPath("~/Sources/ImageQuestion"), uniqueFileName);

                    // Save the file to the server
                    ImageFile.SaveAs(path);

                    // Save the file path or name in the model
                    question.Image = uniqueFileName;
                }
                else
                {
                    question.Image = "";
                    System.Diagnostics.Debug.WriteLine("No file uploaded.");
                }

                    question.Alias = Models.Common.Filter.FilterChar(question.ID);
                question.Type = questionType;
                _dbConnect.Questions.Add(question);
                _dbConnect.SaveChanges();
                return RedirectToAction("EditTest", new { ID = question.TestID });
            }
            return View(question);
        }

        [HttpPost]
        public ActionResult EditTestName(Test modifiedTest) //Đang lỗi
        {
            if (ModelState.IsValid)
            {
                _dbConnect.Tests.Attach(modifiedTest);
                _dbConnect.Entry(modifiedTest).Property(x => x.Name).IsModified = true;
                _dbConnect.SaveChanges();
                TempData["Edit"] = ("Cập nhật thành công!");
                return RedirectToAction("Index");
            }
            return RedirectToAction("EditTest", modifiedTest.TestID);
        }
        public ActionResult EditQuestion(string ID, string testID)
        {
            if (ID != null)
            {
                var question = _dbConnect.Questions.Find(ID);
                return View(question);
            }
            else return RedirectToAction("EditTest", new { ID = testID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestion(Question question, int questionType)
        {
            if (ModelState.IsValid)
            {
                _dbConnect.Questions.Attach(question);
                question.Alias = Models.Common.Filter.FilterChar(question.ID);
                question.Image = "";
                question.Type = questionType;
                _dbConnect.Entry(question).Property(x => x.DetailQuestion).IsModified = true;
                _dbConnect.Entry(question).Property(x => x.OptionA).IsModified = true;
                _dbConnect.Entry(question).Property(x => x.OptionB).IsModified = true;
                _dbConnect.Entry(question).Property(x => x.OptionC).IsModified = true;
                _dbConnect.Entry(question).Property(x => x.Answer).IsModified = true;
                _dbConnect.Entry(question).Property(x => x.Explain).IsModified = true;
                _dbConnect.SaveChanges();
                return RedirectToAction("EditTest", new { ID = question.TestID });
            }
            return View(question);
        }
        [HttpPost]
        public ActionResult DeleteQuestion(string id)
        {
            if (id != null)
            {
                var question = _dbConnect.Questions.Find(id);
                _dbConnect.Questions.Remove(question);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}