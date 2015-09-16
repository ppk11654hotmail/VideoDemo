using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoDemo.Models;

namespace VideoDemo.Controllers
{
    public class HomeController : Controller
    {
        private VideoContext db = new VideoContext();
        public ActionResult Index()
        {
            //1. 維護完的影片 ， 需要依所設定的日期期限 LINQ 語法隨機取出一部合於日期期限的影片 在首頁顯示 
            //   提示 : 條件直接寫在控制器方法中， 這樣的寫法耦合度太高不利於將來的單元測試
            var model =
            db.Videos
                .Where(e => e.StartDate <= DateTime.Today &&
                        e.EndDate >= DateTime.Today)
                .OrderBy(e => Guid.NewGuid()).FirstOrDefault();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}