using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DuAnTotNghiep.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace DuAnTotNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class POSAdminController : Controller // Đảm bảo tên Controller là POSAdminController
    {
        private readonly DuAnTotNghiepDbContext _context;

        public POSAdminController(DuAnTotNghiepDbContext context)
        {
            _context = context;
        }

        public class CartItem
        {
            public Guid ProductDetailId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public string Image { get; set; }
            public double TotalItemPrice => Price * Quantity;
        }

        private List<CartItem> GetCart()
        {
            if (HttpContext.Session.TryGetValue("Cart", out byte[] cartBytes))
            {
                string cartJson = System.Text.Encoding.UTF8.GetString(cartBytes);
                return System.Text.Json.JsonSerializer.Deserialize<List<CartItem>>(cartJson);
            }
            return new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            string cartJson = System.Text.Json.JsonSerializer.Serialize(cart);
            HttpContext.Session.Set("Cart", System.Text.Encoding.UTF8.GetBytes(cartJson));
        }

        // GET: POSAdmin/Index
        // Trang chính hiển thị giỏ hàng và các phần khác
        public ActionResult Index()
        {
            List<CartItem> cart = GetCart();
            ViewBag.TotalPrice = cart.Sum(item => item.TotalItemPrice);
            return View(cart); // Truyền giỏ hàng sang View
        }

        // GET: POSAdmin/Search
        // Tìm kiếm sản phẩm, TRẢ VỀ PARTIAL VIEW
        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            List<SanPhamChiTiet> products = new List<SanPhamChiTiet>();
            if (!string.IsNullOrEmpty(query))
            {
                products = await _context.SanPhamChiTiets
                                        .Include(spct => spct.IdSpNavigation)
                                        .Where(spct => spct.TenSp.Contains(query) || spct.IdSpct.ToString().Contains(query))
                                        .ToListAsync();
            }
            ViewBag.SearchQuery = query; // Để giữ lại từ khóa tìm kiếm trên giao diện
            return PartialView("_SearchResultsPartial", products); // Trả về Partial View
        }

        // POST: POSAdmin/AddToCart
        // Thêm sản phẩm vào giỏ hàng, CẬP NHẬT GIỎ HÀNG TRẢ VỀ PARTIAL VIEW CỦA GIỎ
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productDetailId, int quantity = 1)
        {
            var productDetail = await _context.SanPhamChiTiets
                                            .Include(spct => spct.IdSpNavigation)
                                            .FirstOrDefaultAsync(spct => spct.IdSpct == productDetailId);

            if (productDetail == null)
            {
                // Có thể trả về lỗi JSON hoặc PartialView rỗng
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
                    Image = productDetail.AnhDaiDien
                });
            }

            SaveCart(cart);
            ViewBag.TotalPrice = cart.Sum(item => item.TotalItemPrice); // Cập nhật tổng giá
            return PartialView("_CartTablePartial", cart); // Trả về Partial View của giỏ hàng
        }

        // POST: POSAdmin/UpdateCartQuantity
        // Cập nhật số lượng sản phẩm trong giỏ hàng, CẬP NHẬT GIỎ HÀNG TRẢ VỀ PARTIAL VIEW CỦA GIỎ
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
                    cart.Remove(itemToUpdate);
                }
                SaveCart(cart);
            }
            ViewBag.TotalPrice = cart.Sum(item => item.TotalItemPrice); // Cập nhật tổng giá
            return PartialView("_CartTablePartial", cart); // Trả về Partial View của giỏ hàng
        }

        // POST: POSAdmin/RemoveFromCart
        // Xóa sản phẩm khỏi giỏ hàng, CẬP NHẬT GIỎ HÀNG TRẢ VỀ PARTIAL VIEW CỦA GIỎ
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
            ViewBag.TotalPrice = cart.Sum(item => item.TotalItemPrice); // Cập nhật tổng giá
            return PartialView("_CartTablePartial", cart); // Trả về Partial View của giỏ hàng
        }

        // GET: POSAdmin/Checkout (Bạn có thể bỏ qua Action này nếu Checkout Form đã nằm trong Index View)
        // Tuy nhiên, giữ lại để dễ dàng mở rộng sau này hoặc để Controller truyền data cụ thể cho form Checkout
        [HttpGet]
        public IActionResult Checkout()
        {
            List<CartItem> cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction(nameof(Index)); // Giỏ hàng trống
            }

            ViewBag.TotalPrice = cart.Sum(item => item.TotalItemPrice);
            return View(); // Trả về View Checkout riêng biệt nếu bạn vẫn muốn có
        }


        // POST: POSAdmin/ProcessPayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(string paymentMethod, string customerName, string customerPhone, string customerAddress, string notes)
        {
            List<CartItem> cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction(nameof(Index)); // Cart is empty, cannot checkout
            }

            double totalAmount = cart.Sum(item => item.TotalItemPrice);

            var defaultUserId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var existingUserKhachHang = await _context.UserKhachHangs.FirstOrDefaultAsync(u => u.IdUser == defaultUserId);
            if (existingUserKhachHang == null)
            {
                //// Đảm bảo các trường này có giá trị mặc định hoặc cho phép null trong model UserKhachHang
                //existingUserKhachHang = new UserKhachHang { IdUser = defaultUserId, UserName = "GuestPOS", Email = "pos@example.com", Sdt = "0000000000", DiaChi = "Unknown" };
                _context.UserKhachHangs.Add(existingUserKhachHang);
                await _context.SaveChangesAsync();
            }

            var hoaDon = new HoaDon
            {
                IdHoaDon = Guid.NewGuid(),
                IdUser = existingUserKhachHang.IdUser
            };
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            var thanhToan = new ThanhToan
            {
                IdThanhToan = Guid.NewGuid(),
                IdHoaDon = hoaDon.IdHoaDon,
                PhuongThucThanhToan = paymentMethod,
                Status = "Completed",
                SoTienThanhToan = totalAmount,
                HoTen = customerName,
                Sdt = customerPhone,
                DiaChi = customerAddress,
                GhiChu = notes
            };
            _context.ThanhToans.Add(thanhToan);
            await _context.SaveChangesAsync();

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

                var tonKho = await _context.TonKhos.FirstOrDefaultAsync(tk => tk.IdSpct == item.ProductDetailId);
                if (tonKho != null)
                {
                    tonKho.SoLuongTonKho -= item.Quantity;
                    tonKho.NgayCapNhap = DateTime.Now;
                    _context.TonKhos.Update(tonKho);
                }
                else
                {
                    _context.TonKhos.Add(new TonKho
                    {
                        IdTonKho = Guid.NewGuid(),
                        IdSpct = item.ProductDetailId,
                        SoLuongTonKho = -item.Quantity,
                        NgayCapNhap = DateTime.Now,
                        //NgayTao = DateTime.Now,
                        //Status = "Inactive"
                    });
                }
            }
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Receipt", new { invoiceId = hoaDon.IdHoaDon });
        }

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

        // Các Action CRUD cũ có thể được giữ hoặc xóa tùy nhu cầu
        public ActionResult Details(int id) { return View(); }
        public ActionResult Create() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) { try { return RedirectToAction(nameof(Index)); } catch { return View(); } }
        public ActionResult Edit(int id) { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) { try { return RedirectToAction(nameof(Index)); } catch { return View(); } }
        public ActionResult Delete(int id) { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) { try { return RedirectToAction(nameof(Index)); } catch { return View(); } }
    }
}