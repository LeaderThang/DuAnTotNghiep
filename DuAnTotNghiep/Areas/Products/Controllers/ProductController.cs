using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DuAnTotNghiep.Models; // Đảm bảo namespace này đúng // Đảm bảo namespace này đúng

namespace POS_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly DuAnTotNghiepDbContext _dbManager;

        // Constructor này nhận DbManager thông qua Dependency Injection.
        // Điều này có nghĩa là ASP.NET Core runtime sẽ tự động cung cấp một thể hiện của DbManager
        // khi một thể hiện của ProductController được tạo.
        // Đảm bảo bạn đã cấu hình DbManager trong Startup.cs để sử dụng Dependency Injection.
        public ProductController(Du dbManager)
        {
            _dbManager = dbManager;
        }

        // GET: /Product/Index
        // Phương thức action này được gọi khi người dùng truy cập URL /Product hoặc /Product/Index.
        // Mục đích: Hiển thị danh sách tất cả sản phẩm có sẵn.
        public IActionResult Index()
        {
            // Gọi phương thức LoadProducts() từ DbManager để lấy danh sách tất cả sản phẩm từ cơ sở dữ liệu.
            var products = _dbManager.LoadProducts();
            // Trả về View tương ứng (Views/Product/Index.cshtml) và truyền danh sách sản phẩm làm Model cho View.
            return View(products);
        }

        // GET: /Product/Search?searchTerm=giay
        // Phương thức action này được gọi khi người dùng gửi yêu cầu tìm kiếm (thường là từ form tìm kiếm).
        // Mục đích: Tìm kiếm sản phẩm theo tên hoặc một phần của ID sản phẩm.
        [HttpGet] // Chỉ định rằng action này chỉ phản hồi cho các yêu cầu HTTP GET.
        public IActionResult Search(string searchTerm)
        {
            // Lấy tất cả sản phẩm từ cơ sở dữ liệu.
            var allProducts = _dbManager.LoadProducts();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Nếu từ khóa tìm kiếm rỗng hoặc chỉ chứa khoảng trắng, coi như không có tìm kiếm
                // và hiển thị lại tất cả sản phẩm trên cùng View "Index".
                return View("Index", allProducts);
            }

            // Lọc danh sách sản phẩm dựa trên từ khóa tìm kiếm.
            // Tìm kiếm khớp với TenSp (không phân biệt hoa thường) hoặc 8 ký tự đầu của IdSpct.
            var foundProducts = allProducts.Where(p =>
                p.TenSp.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.IdSpct.ToString().StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            // Sử dụng ViewBag để truyền từ khóa tìm kiếm trở lại View.
            // Điều này hữu ích để hiển thị lại từ khóa trong ô tìm kiếm trên giao diện người dùng.
            ViewBag.SearchTerm = searchTerm;
            // Trả về cùng View "Index" nhưng chỉ với danh sách sản phẩm đã được lọc.
            return View("Index", foundProducts);
        }
    }
}