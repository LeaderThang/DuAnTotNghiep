using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class Admin
{
    public string HoTenAdmin { get; set; } = null!;

    public string AnhDaiDien { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public string Email { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public virtual ICollection<BaoCao> BaoCaos { get; set; } = new List<BaoCao>();

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<KhuyenMai> KhuyenMais { get; set; } = new List<KhuyenMai>();

    public virtual ICollection<Ncc> Nccs { get; set; } = new List<Ncc>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual User UserNameNavigation { get; set; } = null!;
}
