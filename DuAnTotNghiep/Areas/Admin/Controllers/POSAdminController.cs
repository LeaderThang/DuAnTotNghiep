using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DuAnTotNghiep.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace DuAnTotNghiep.Controllers
{
    public class POSAdminController : Controller
    {
        private readonly DuAnTotNghiepDbContext _context;

        public POSAdminController(DuAnTotNghiepDbContext context)
        {
            _context = context;
        }

        // Lớp đại diện cho một mặt hàng trong giỏ hàng để lưu trữ trong session
        public class CartItem
        {
            public Guid ProductDetailId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public string Image { get; set; }
            public double TotalItemPrice => Price * Quantity;
        }

        // Lấy giỏ hàng từ session
        private List<CartItem> GetCart()
        {
            if (HttpContext.Session.TryGetValue("Cart", out byte[] cartBytes))
            {
                string cartJson = System.Text.Encoding.UTF8.GetString(cartBytes);
                return System.Text.Json.JsonSerializer.Deserialize<List<CartItem>>(cartJson);
            }
            return new List<CartItem>();
        }

        // Lưu giỏ hàng vào session
        private void SaveCart(List<CartItem> cart)
        {
            string cartJson = System.Text.Json.JsonSerializer.Serialize(cart);
            HttpContext.Session.Set("Cart", System.Text.Encoding.UTF8.GetBytes(cartJson));
        }

        // GET: SanPhamTaiQuayController
        // Hiển thị giỏ hàng hiện tại và tổng giá tiền
        public ActionResult Index()
        {
            List<CartItem> cart = GetCart();
            ViewBag.TotalPrice = cart.Sum(item => item.TotalItemPrice);
            return View(cart);
        }

        // GET: SanPhamTaiQuayController/Search
        // Tìm kiếm sản phẩm theo tên hoặc ID chi tiết sản phẩm
        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(new List<SanPhamChiTiet>());
            }

            var products = await _context.SanPhamChiTiets
                                        .Include(spct => spct.IdSpNavigation)
                                        .Where(spct => spct.TenSp.Contains(query) || spct.IdSpct.ToString().Contains(query))
                                        .ToListAsync();

            return View(products);
        }

        // POST: SanPhamTaiQuayController/AddToCart
        // Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productDetailId, int quantity = 1)
        {
            var productDetail = await _context.SanPhamChiTiets
                                            .Include(spct => spct.IdSpNavigation)
                                            .FirstOrDefaultAsync(spct => spct.IdSpct == productDetailId);

            if (productDetail == null)
            {
                return NotFound();
            }

            List<CartItem> cart = GetCart();
            var existingItem = cart.FirstOrDefault(item => item.ProductDetailId == productDetailId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductDetailId = productDetail.IdSpct,
                    ProductName = productDetail.TenSp,
                    Price = productDetail.Gia,
                    Quantity = quantity,
                    Image = productDetail.AnhDaiDien // Giả sử AnhDaiDien lưu đường dẫn/tên ảnh
                });
            }

            SaveCart(cart);
            return RedirectToAction(nameof(Index));
        }

        // POST: SanPhamTaiQuayController/UpdateCartQuantity
        // Cập nhật số lượng sản phẩm trong giỏ hàng
        [HttpPost]
        public IActionResult UpdateCartQuantity(Guid productDetailId, int newQuantity)
        {
            List<CartItem> cart = GetCart();
            var itemToUpdate = cart.FirstOrDefault(item => item.ProductDetailId == productDetailId);

            if (itemToUpdate != null)
            {
                if (newQuantity > 0)
                {
                    itemToUpdate.Quantity = newQuantity;
                }
                else
                {
                    cart.Remove(itemToUpdate); // Xóa nếu số lượng là 0 hoặc ít hơn
                }
                SaveCart(cart);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: SanPhamTaiQuayController/RemoveFromCart
        // Xóa sản phẩm khỏi giỏ hàng
        [HttpPost]
        public IActionResult RemoveFromCart(Guid productDetailId)
        {
            List<CartItem> cart = GetCart();
            var itemToRemove = cart.FirstOrDefault(item => item.ProductDetailId == productDetailId);

            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                SaveCart(cart);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SanPhamTaiQuayController/Checkout
        // Hiển thị trang thanh toán
        [HttpGet]
        public IActionResult Checkout()
        {
            List<CartItem> cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction(nameof(Index)); // Giỏ hàng trống
            }

            ViewBag.TotalPrice = cart.Sum(item => item.TotalItemPrice);
            // Bạn có thể truyền một CheckoutViewModel ở đây với các tùy chọn thanh toán
            return View();
        }

        // POST: SanPhamTaiQuayController/ProcessPayment
        // Xử lý quá trình thanh toán
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(string paymentMethod, string customerName, string customerPhone, string customerAddress, string notes)
        {
            List<CartItem> cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction(nameof(Index)); // Giỏ hàng trống, không thể thanh toán
            }

            double totalAmount = cart.Sum(item => item.TotalItemPrice);

            // Tạo hoặc lấy UserKhachHang mặc định cho bán tại quầy
            var defaultUserId = Guid.Parse("00000000-0000-0000-0000-000000000001"); // ID mặc định
            var existingUserKhachHang = await _context.UserKhachHangs.FirstOrDefaultAsync(u => u.IdUser == defaultUserId);
            if (existingUserKhachHang == null)
            {
                //existingUserKhachHang = new UserKhachHang { IdUser = defaultUserId, UserName = "GuestPOS", Email = "pos@example.com", Sdt = "0000000000", DiaChi = "Unknown" }; // Cần điền đầy đủ các trường bắt buộc khác nếu có
                _context.UserKhachHangs.Add(existingUserKhachHang);
                await _context.SaveChangesAsync();
            }

            // Tạo HoaDon
            var hoaDon = new HoaDon
            {
                IdHoaDon = Guid.NewGuid(),
                IdUser = existingUserKhachHang.IdUser
            };
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            // Tạo ThanhToan
            var thanhToan = new ThanhToan
            {
                IdThanhToan = Guid.NewGuid(),
                IdHoaDon = hoaDon.IdHoaDon,
                PhuongThucThanhToan = paymentMethod,
                Status = "Completed", // Hoặc "Pending" tùy thuộc vào cổng thanh toán
                SoTienThanhToan = totalAmount,
                HoTen = customerName,
                Sdt = customerPhone,
                DiaChi = customerAddress,
                GhiChu = notes
            };
            _context.ThanhToans.Add(thanhToan);
            await _context.SaveChangesAsync();

            // Tạo SanPhamThanhToan và cập nhật TonKho
            foreach (var item in cart)
            {
                var sanPhamThanhToan = new SanPhamThanhToan
                {
                    IdSpThanhToan = Guid.NewGuid(),
                    IdSpct = item.ProductDetailId,
                    IdThanhToan = thanhToan.IdThanhToan,
                    SoLuong = item.Quantity,
                    //DonGia = item.Price
                };
                _context.SanPhamThanhToans.Add(sanPhamThanhToan);

                // Cập nhật TonKho (số lượng tồn kho)
                var tonKho = await _context.TonKhos.FirstOrDefaultAsync(tk => tk.IdSpct == item.ProductDetailId);
                if (tonKho != null)
                {
                    tonKho.SoLuongTonKho -= item.Quantity; // Giảm số lượng tồn kho
                    tonKho.NgayCapNhap = DateTime.Now;
                    _context.TonKhos.Update(tonKho);
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy TonKho (ví dụ: tạo mới hoặc ghi log lỗi)
                    // Ở đây, tôi sẽ thêm một mục mới với số lượng âm để cho thấy sự giảm số lượng từ ban đầu là 0.
                    _context.TonKhos.Add(new TonKho
                    {
                        IdTonKho = Guid.NewGuid(),
                        IdSpct = item.ProductDetailId,
                        SoLuongTonKho = -item.Quantity, // Giảm từ 0 nếu không tìm thấy
                        NgayCapNhap = DateTime.Now,                        
                        //Status = "Inactive" // Hoặc trạng thái phù hợp hơn
                    });
                }
            }
            await _context.SaveChangesAsync();

            // Xóa giỏ hàng sau khi thanh toán thành công
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Receipt", new { invoiceId = hoaDon.IdHoaDon });
        }

        // GET: SanPhamTaiQuayController/Receipt/{invoiceId}
        // Hiển thị hóa đơn sau khi thanh toán
        public async Task<IActionResult> Receipt(Guid invoiceId)
        {
            var invoice = await _context.HoaDons
                                        .Include(hd => hd.ThanhToans)
                                            .ThenInclude(tt => tt.SanPhamThanhToans)
                                                .ThenInclude(sptt => sptt.IdSpctNavigation)
                                        .FirstOrDefaultAsync(hd => hd.IdHoaDon == invoiceId);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // Các hành động CRUD gốc của controller (có thể giữ lại, xóa hoặc sửa đổi tùy theo nhu cầu thực tế)
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