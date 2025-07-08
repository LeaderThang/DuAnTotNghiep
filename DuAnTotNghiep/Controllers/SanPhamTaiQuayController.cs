using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnTotNghiep.Controllers
{
    public class SanPhamTaiQuayController : Controller
    {
        // GET: SanPhamTaiQuayController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SanPhamTaiQuayController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SanPhamTaiQuayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhamTaiQuayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPhamTaiQuayController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanPhamTaiQuayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPhamTaiQuayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanPhamTaiQuayController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
