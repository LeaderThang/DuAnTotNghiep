using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DuAnTotNghiep.Models;

namespace DuAnTotNghiep.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly DuAnTotNghiepDbContext _context;

        public NhanVienController(DuAnTotNghiepDbContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {

            var nhanViens = _context.NhanViens.ToList();
            return View(nhanViens);
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var nhanVien = await _context.NhanViens
                .Include(nv => nv.UserNameNavigation)
                .Include(nv => nv.HoTenAdminNavigation)
                .FirstOrDefaultAsync(m => m.MaNv == id);

            if (nhanVien == null) return NotFound();

            return View(nhanVien);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoTenNv,HoTenAdmin,Sdt,Email,DiaChi,NgaySinh,GioiTinh,TrangThai,NgayVaoLam,ChucVu,LuongCoBan,SoGioLamViec,UserName")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                nhanVien.MaNv = Guid.NewGuid();
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null) return NotFound();
            return View(nhanVien);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaNv,HoTenNv,HoTenAdmin,Sdt,Email,DiaChi,NgaySinh,GioiTinh,TrangThai,NgayVaoLam,ChucVu,LuongCoBan,SoGioLamViec,UserName")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNv) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.NhanViens.Any(e => e.MaNv == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nhanVien == null) return NotFound();

            return View(nhanVien);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
