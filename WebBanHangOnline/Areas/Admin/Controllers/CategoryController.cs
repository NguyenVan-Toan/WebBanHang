using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        public ActionResult Index()
        {
            var items = _dbConnect.Categories;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Commons.Filter.FilterChar(model.Title);
                _dbConnect.Categories.Add(model);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConnect.Categories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _dbConnect.Categories.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Commons.Filter.FilterChar(model.Title);
                _dbConnect.Entry(model).Property(x=>x.Title).IsModified = true;
                _dbConnect.Entry(model).Property(x=>x.Descriptions).IsModified = true;
                _dbConnect.Entry(model).Property(x=>x.Alias).IsModified = true;
                _dbConnect.Entry(model).Property(x=>x.SeoKeywords).IsModified = true;
                _dbConnect.Entry(model).Property(x=>x.SeoDescription).IsModified = true;
                _dbConnect.Entry(model).Property(x=>x.SeoTitle).IsModified = true;
                _dbConnect.Entry(model).Property(x=>x.Position).IsModified = true;
                _dbConnect.Entry(model).Property(x=>x.ModifiedBy).IsModified = true;
                _dbConnect.Entry(model).Property(x=>x.ModifiedDate).IsModified = true;
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConnect.Categories.Find(id);
            if(item != null)
            {
                //var DeleteItem = _dbConnect.Categories.Attach(item);
                _dbConnect.Categories.Remove(item);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json( new { success = false });
        }
    }
}