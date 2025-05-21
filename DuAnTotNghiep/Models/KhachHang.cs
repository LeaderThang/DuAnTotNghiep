using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class KhachHang
{
    public string HoTen { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? DiaChi { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string TrangThai { get; set; } = null!;

    public DateTime NgayDangKy { get; set; }

    public int DiemTichLuy { get; set; }

    public string LoaiKhachHang { get; set; } = null!;

    public string? HoTenAdmin { get; set; }

    public string UserName { get; set; } = null!;

    public virtual Admin? HoTenAdminNavigation { get; set; }

    public virtual ICollection<UserKhachHang> UserKhachHangs { get; set; } = new List<UserKhachHang>();
}
