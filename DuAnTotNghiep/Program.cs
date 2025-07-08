//using DuAnTotNghiep.Models;
//using Microsoft.EntityFrameworkCore;

//namespace DuAnTotNghiep
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Đăng ký DbContext
//            builder.Services.AddDbContext<DuAnTotNghiepDbContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//            // Add services to the container.
//            builder.Services.AddControllersWithViews();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.MapControllerRoute(
//            name: "areas",
//            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//            app.MapControllerRoute(
//            name: "default",
//            pattern: "{controller=Home}/{action=Index}/{id?}");


//            app.Run();
//        }
//    }
//}
using DuAnTotNghiep.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Đăng ký DbContext
            builder.Services.AddDbContext<DuAnTotNghiepDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Cấu hình Session: THÊM ĐOẠN NÀY
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian session hết hạn sau 30 phút không hoạt động
                options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập qua HTTP, không phải JavaScript
                options.Cookie.IsEssential = true; // Đánh dấu cookie session là thiết yếu để nó được chấp nhận theo GDPR
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Sử dụng Session Middleware: THÊM DÒNG NÀY VÀO ĐÂY (trước app.UseRouting())
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication(); // Đảm bảo dòng này nếu bạn có xác thực
            app.UseAuthorization(); // Đảm bảo dòng này nếu bạn có phân quyền

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
