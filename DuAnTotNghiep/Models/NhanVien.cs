using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class NhanVien
{
    public Guid MaNv { get; set; }

    public string HoTenNv { get; set; } = null!;

    public string HoTenAdmin { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string TrangThai { get; set; } = null!;

    public DateTime NgayVaoLam { get; set; }

    public string ChucVu { get; set; } = null!;

    public decimal LuongCoBan { get; set; }

    public int SoGioLamViec { get; set; }

    public string UserName { get; set; } = null!;

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual Admin HoTenAdminNavigation { get; set; } = null!;

    public virtual ICollection<HoTroKhachHang> HoTroKhachHangs { get; set; } = new List<HoTroKhachHang>();

    public virtual User UserNameNavigation { get; set; } = null!;
}
