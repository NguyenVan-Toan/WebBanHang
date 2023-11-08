using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private ApplicationDbContext db = new ApplicationDbContext();
        //public ActionResult Index(int? page)
        public ActionResult Index()
        {
            var item = db.Products.OrderByDescending(x => x.id);
            //var pageSize = 10;
            //if(page != null)
            //{
            //    page = 1;
            //}
            //var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            //item = item.ToPagedList(pageIndex, pageSize);
            return View(item);
        }
    }
}