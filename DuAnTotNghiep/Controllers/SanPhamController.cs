using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuAnTotNghiep.Models; // Đảm bảo có dòng này để truy cập SanPham và DbContext

namespace DuAnTotNghiep.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly DuAnTotNghiepDbContext _context;

        public SanPhamController(DuAnTotNghiepDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPham
        // Hiển thị danh sách tất cả sản phẩm
        public async Task<IActionResult> Index()
        {
            return View(await _context.SanPhams.ToListAsync());
        }

        // GET: Admin/SanPham/Details/5
        // Hiển thị chi tiết một sản phẩm
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.IdSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        // Hiển thị form tạo sản phẩm mới
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SanPham/Create
        // Xử lý việc tạo sản phẩm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSp,TenSp,SoLuongTong,MoTa,TrangThai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.IdSp = Guid.NewGuid(); // Gán một GUID mới cho sản phẩm
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Edit/5
        // Hiển thị form chỉnh sửa sản phẩm
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Edit/5
        // Xử lý việc chỉnh sửa sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdSp,TenSp,SoLuongTong,MoTa,TrangThai")] SanPham sanPham)
        {
            if (id != sanPham.IdSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.IdSp))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Delete/5
        // Hiển thị trang xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.IdSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        // Xử lý việc xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(Guid id)
        {
            return _context.SanPhams.Any(e => e.IdSp == id);
        }
    }
}