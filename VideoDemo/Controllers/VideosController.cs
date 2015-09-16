using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VideoDemo.Models;
using Kendo.Mvc.Extensions;//1.using Kendo.Mvc.Extensions; 的參考引用， 這是 Telerik UI for ASP.NET MVC 的擴充功能， 加入後可以擴充 Controller 的功能

namespace VideoDemo.Controllers
{
    public class VideosController : Controller
    {
        private VideoContext db = new VideoContext();//2. 開啟資料庫連線， 以供後續的方法中使用 對應 3. 關閉資料庫

        //4. 由資料庫讀取資料， 並傳給先前實作的 Index.cshtml 檢視， 以之用來呈現數據資料。
        public ActionResult Index()
        {
            return View(db.Videos.ToList());
        }

        //5. 請對照先前在 Index.cshtml 中所實作的， 當使用者新增資料後， 就會被送來這裡處理， 首先會以 if (ModelState.IsValid) 檢查送過來的資料是否符合驗證規
        //則， 合格就存入資料庫， 不合格就退回重填。
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Title,StartDate,EndDate")] Video video)
        {
            if (ModelState.IsValid)//檢查送過來的資料是否符合驗證
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index", this.GridRouteValues());
            }

            return View("Index", db.Videos.ToList());
        }
        //6. 同樣地， 也請對照先前在 Index.cshtml 中所實作的， 當使用者修改完資料後， 就會被送來這裡處理， 首先會以 if (ModelState.IsValid) 檢查送過來的資料是否
        //符合驗證規則， 合格就存入資料庫， 不合格就退回重填。
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,StartDate,EndDate")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", this.GridRouteValues());
            }
            return View("Index", db.Videos.ToList());
        }

        //7. 同樣地， 也請對照先前在 Index.cshtml 中所實作的， 以資料的主鍵值送來這裡處理， 首先由資料庫中找到該筆資料， 接著將其從資料庫中移除。
        [HttpPost]
        public ActionResult Delete(string id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Index", this.GridRouteValues());
        }

        //3.資料庫連線被開啟，使用完後當然就要關閉
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
