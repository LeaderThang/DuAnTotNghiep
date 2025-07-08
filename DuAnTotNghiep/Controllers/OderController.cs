using DuAnTotNghiep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Controllers
{
    public class OderController : Controller
    {
        // GET: OderControllerController1
        private readonly DuAnTotNghiepDbContext _dbContext;
        private readonly UserManager<Admin> _userManager;
        public ActionResult Index()
        {
            return View();
        }
        //public OrderController(DuanTotNghiepDbContext context, UserManager<Admin> userManager)
        //{
        //    _context = context;
        //    _userManager = userManager;
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] AdminCreateOrderViewModel model)
        //{
        //    if (!ModelState.IsValid || model.CartItems == null || !model.CartItems.Any())
        //    {
        //        return Json(new { success = false, message = "Dữ liệu không hợp lệ hoặc giỏ hàng trống." });
        //    }

        //    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            // 1. Xử lý khách hàng (ApplicationUser)
        //            var customer = await _dbContext.Admins.FirstOrDefaultAsync(u => u.PhoneNumber == model.CustomerPhone);
        //            if (customer == null)
        //            {
        //                // Nếu không tìm thấy, bạn có thể cân nhắc tạo một user mới
        //                // Tuy nhiên, trong luồng bán hàng tại quầy, thường sẽ yêu cầu khách hàng đã có tài khoản
        //                // hoặc chỉ lưu thông tin dạng text.
        //                // Ở đây, chúng ta sẽ báo lỗi nếu không tìm thấy SĐT.
        //                await transaction.RollbackAsync();
        //                return Json(new { success = false, message = $"Không tìm thấy khách hàng với SĐT: {model.CustomerPhone}." });
        //            }
        //            customer.FullName = model.CustomerName; // Cập nhật lại tên và địa chỉ nếu có thay đổi
        //            customer.Address = model.ShippingAddress;

        //            // 2. Tạo đối tượng Order
        //            var order = new DonHang
        //            {
        //                ApplicationUserId = customer.Id,
        //                CreateDate = DateTime.Now,
        //                ShippingAddress = model.ShippingAddress,
        //                ShippingFee = model.ShippingFee,
        //                Discount = model.Discount,
        //                PaymentMethod = model.PaymentMethod,
        //                Note = model.Note,
        //                Status = "Pending" // Trạng thái ban đầu
        //            };

        //            // 3. Tạo OrderDetail và tính tổng tiền
        //            decimal totalProductPrice = 0;
        //            foreach (var item in model.CartItems)
        //            {
        //                var product = await _dbContext.SanPhams.FindAsync(item.ProductId);
        //                if (product == null || product.Quantity < item.Quantity)
        //                {
        //                    await transaction.RollbackAsync();
        //                    return Json(new { success = false, message = $"Sản phẩm '{product?.Name}' không đủ số lượng." });
        //                }

        //                var orderDetail = new 
        //                {
        //                    Order = order,
        //                    ProductId = item.ProductId,
        //                    Quantity = item.Quantity,
        //                    Price = product.Price // Lấy giá từ CSDL để đảm bảo an toàn
        //                };
        //                _context.OrderDetails.Add(orderDetail);

        //                product.Quantity -= item.Quantity; // Trừ tồn kho
        //                totalProductPrice += orderDetail.Price * orderDetail.Quantity;
        //            }

        //            order.TotalAmount = totalProductPrice + model.ShippingFee - model.Discount;
        //            _context.Orders.Add(order);

        //            await _context.SaveChangesAsync();
        //            await transaction.CommitAsync();

        //            return Json(new { success = true, message = "Tạo đơn hàng thành công!", orderId = order.Id });
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            // Ghi log lỗi tại đây
        //            return Json(new { success = false, message = "Lỗi hệ thống: " + ex.Message });
        //        }
        //    }
        //}



    }
}
