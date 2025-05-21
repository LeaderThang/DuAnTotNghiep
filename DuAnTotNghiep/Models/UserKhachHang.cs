using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class UserKhachHang
{
    public Guid IdUser { get; set; }

    public string HoTen { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<HoTroKhachHang> HoTroKhachHangs { get; set; } = new List<HoTroKhachHang>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual KhachHang KhachHang { get; set; } = null!;

    public virtual ICollection<SanPhamYeuThich> SanPhamYeuThiches { get; set; } = new List<SanPhamYeuThich>();

    public virtual User UserNameNavigation { get; set; } = null!;
}
