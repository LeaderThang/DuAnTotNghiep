using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DuAnTotNghiep.Models;
using DuAnTotNghiep.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace DuAnTotNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = "Admin,NhanVien")]
    public class HoaDonController : Controller
    {
        private readonly DuAnTotNghiepDbContext _context;

        public HoaDonController(DuAnTotNghiepDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sanPhamChiTietList = _context.SanPhamChiTiets
                .Include(sp => sp.TonKhos) // Load tồn kho nếu cần
                .ToList();

            return View(sanPhamChiTietList);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminCreateHoaDonViewModel model)
        {
            if (!ModelState.IsValid || model.CartItems == null || !model.CartItems.Any())
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ hoặc giỏ hàng trống." });
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                   
                    var userKhachHang = await FindOrCreateCustomerUserAsync(model);
                    if (userKhachHang == null)
                    {
                        throw new Exception("Không thể tạo hoặc tìm thấy thông tin khách hàng.");
                    }

                    
                    var hoaDon = new HoaDon { IdHoaDon = Guid.NewGuid(), IdUser = userKhachHang.IdUser };
                    _context.HoaDons.Add(hoaDon);

                    double totalProductPrice = await CalculateTotalProductPriceAsync(model.CartItems);
                    var thanhToan = new ThanhToan
                    {
                        IdThanhToan = Guid.NewGuid(),
                        IdHoaDon = hoaDon.IdHoaDon,
                        PhuongThucThanhToan = model.PaymentMethod,
                        Status = "Chờ thanh toán",
                        SoTienThanhToan = totalProductPrice + model.ShippingFee - model.Discount,
                        DiaChi = model.ShippingAddress,
                        Sdt = model.CustomerPhone,
                        HoTen = model.CustomerName,
                        GhiChu = model.Note
                    };
                    _context.ThanhToans.Add(thanhToan);

                    
                    await ProcessOrderDetailsAndUpdateStockAsync(model.CartItems, thanhToan.IdThanhToan);

                    
                    var maNv = GetLoggedInEmployeeId(); // Lấy mã nhân viên đang thực hiện
                    var donHang = new DonHang { IdDonHang = Guid.NewGuid(), MaNv = maNv };
                    _context.DonHangs.Add(donHang);

                    var donHangThanhToan = new DonHangThanhToan
                    {
                        IdDonHangThanhToan = Guid.NewGuid(),
                        IdThanhToan = thanhToan.IdThanhToan,
                        IdDonHang = donHang.IdDonHang,
                        Status = "Đang xử lý",
                       
                        NgayTt = DateOnly.FromDateTime(DateTime.Now),
                        KieuTt = model.PaymentMethod
                    };
                    _context.DonHangThanhToans.Add(donHangThanhToan);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Json(new { success = true, message = "Tạo hóa đơn thành công!", hoaDonId = hoaDon.IdHoaDon });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Json(new { success = false, message = "Lỗi hệ thống: " + ex.Message });
                }
            }
        }

   

        private async Task<double> CalculateTotalProductPriceAsync(List<CartItemViewModel> cartItems)
        {
            double total = 0;
            var productIds = cartItems.Select(c => c.ProductDetailId).ToList();
            var products = await _context.SanPhamChiTiets.Where(p => productIds.Contains(p.IdSpct)).ToListAsync();

            foreach (var item in cartItems)
            {
                var product = products.FirstOrDefault(p => p.IdSpct == item.ProductDetailId);
                total += (product?.Gia ?? 0) * item.Quantity;
            }
            return total;
        }

        private async Task ProcessOrderDetailsAndUpdateStockAsync(List<CartItemViewModel> cartItems, Guid thanhToanId)
        {
            foreach (var item in cartItems)
            {
                var tonKho = await _context.TonKhos.FirstOrDefaultAsync(tk => tk.IdSpct == item.ProductDetailId);
                var sanPhamChiTiet = await _context.SanPhamChiTiets.FindAsync(item.ProductDetailId);

                if (tonKho == null || sanPhamChiTiet == null || tonKho.SoLuongTonKho < item.Quantity)
                {
                    throw new Exception($"Sản phẩm '{sanPhamChiTiet?.TenSp ?? "Unknown"}' không đủ số lượng trong kho.");
                }

                tonKho.SoLuongTonKho -= item.Quantity;
                tonKho.NgayCapNhap = DateTime.Now;

                var spThanhToan = new SanPhamThanhToan
                {
                    IdSpThanhToan = Guid.NewGuid(),
                    IdThanhToan = thanhToanId,
                    IdSpct = item.ProductDetailId,
                    SoLuong = item.Quantity
                };
                _context.SanPhamThanhToans.Add(spThanhToan);
            }
        }

        private async Task<UserKhachHang> FindOrCreateCustomerUserAsync(AdminCreateHoaDonViewModel model)
        {
            var khachHang = await _context.KhachHangs.FirstOrDefaultAsync(kh => kh.Sdt == model.CustomerPhone);
            if (khachHang == null)
            {
                
                var newUser = new User
                {
                    UserName = model.CustomerEmail,
                    Password = "DefaultPassword123@",
                    Role = "KhachHang"
                };
                _context.Users.Add(newUser);

                khachHang = new KhachHang
                {
                    HoTen = model.CustomerName,
                    Email = model.CustomerEmail,
                    Sdt = model.CustomerPhone,
                    DiaChi = model.ShippingAddress,
                    TrangThai = "Hoạt động",
                    LoaiKhachHang = "Mới",
                    NgayDangKy = DateTime.Now,
                    DiemTichLuy = 0,
                    UserName = newUser.UserName 
                };
                _context.KhachHangs.Add(khachHang);

                var newUserKhachHang = new UserKhachHang
                {
                    IdUser = Guid.NewGuid(),
                    HoTen = khachHang.HoTen,
                    UserName = newUser.UserName,
                    Email = khachHang.Email
                };
                _context.UserKhachHangs.Add(newUserKhachHang);

                await _context.SaveChangesAsync();
                return newUserKhachHang;
            }

            return await _context.UserKhachHangs.FirstOrDefaultAsync(uk => uk.Email == khachHang.Email);
        }

        private Guid GetLoggedInEmployeeId()
        {
            var userName = User.Identity.Name;

            // Nếu chưa có đăng nhập, trả về một Guid tạm
            if (string.IsNullOrEmpty(userName))
            {
                // Lấy tạm nhân viên đầu tiên trong DB để test.
                // KHI CHẠY THẬT, BẠN PHẢI BỎ DÒNG NÀY VÀ YÊU CẦU ĐĂNG NHẬP
                var firstEmployee = _context.NhanViens.FirstOrDefault();
                if (firstEmployee != null) return firstEmployee.MaNv;

                throw new Exception("Không tìm thấy nhân viên nào trong hệ thống và không có nhân viên nào đăng nhập.");
            }

            var employee = _context.NhanViens.FirstOrDefault(nv => nv.UserName == userName);
            if (employee == null)
            {
                throw new Exception("Tài khoản đăng nhập không phải là nhân viên hợp lệ.");
            }
            return employee.MaNv;
        }

        #region API_CALLS
        [HttpGet]
        public async Task<IActionResult> SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return Json(new List<object>());

            var products = await _context.SanPhamChiTiets
                .Where(p => p.TenSp.Contains(keyword))
                .Join(_context.TonKhos, spct => spct.IdSpct, tonkho => tonkho.IdSpct,
                      (spct, tonkho) => new { spct, tonkho })
                .Where(x => x.tonkho.SoLuongTonKho > 0)
                .Select(x => new {
                    Id = x.spct.IdSpct,
                    Name = x.spct.TenSp,
                    Price = x.spct.Gia,
                    Stock = x.tonkho.SoLuongTonKho,
                    ImageUrl = x.spct.AnhDaiDien ?? "default.jpg"
                })
                .Take(10)
                .ToListAsync();

            return Json(products);
        }

        [HttpGet]
        public async Task<IActionResult> SearchCustomer(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return Json(null);
            var customer = await _context.KhachHangs
                .Where(u => u.Sdt.Contains(phone))
                .Select(u => new { u.HoTen, u.Sdt, u.Email, u.DiaChi })
                .FirstOrDefaultAsync();
            return Json(customer);
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> SearchProduct(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return Json(new List<object>());

            var products = await _context.SanPhamChiTiets
                .Where(p => p.TenSp.Contains(keyword))
                .Join(_context.TonKhos, spct => spct.IdSpct, tonkho => tonkho.IdSpct,
                      (spct, tonkho) => new { spct, tonkho })
                .Where(x => x.tonkho.SoLuongTonKho > 0)
                .Select(x => new {
                    id = x.spct.IdSpct,
                    name = x.spct.TenSp,
                    price = x.spct.Gia,
                    stock = x.tonkho.SoLuongTonKho,
                    imageUrl = x.spct.AnhDaiDien ?? "default.jpg"
                })
                .Take(10)
                .ToListAsync();

            return Json(products);
        }
        [HttpGet]
        public async Task<IActionResult> LoadAllProducts()
        {
            var products = await _context.SanPhamChiTiets
                .Include(spct => spct.TonKhos)
                .Where(spct => spct.TonKhos.Any(tk => tk.SoLuongTonKho > 0))
                .Select(spct => new
                {
                    id = spct.IdSpct,
                    name = spct.TenSp,
                    price = spct.Gia,
                    stock = spct.TonKhos.FirstOrDefault().SoLuongTonKho,
                    imageUrl = spct.AnhDaiDien ?? "default.jpg"
                })
                .ToListAsync();

            return Json(products);
        }

    }
}
