using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class SanPhamMua
{
    public Guid IdSpMua { get; set; }

    public Guid IdSpct { get; set; }

    public string UserName { get; set; } = null!;

    public double SoLuong { get; set; }

    public double Gia { get; set; }

    public Guid MaKm { get; set; }

    public virtual SanPhamChiTiet IdSpctNavigation { get; set; } = null!;

    public virtual KhuyenMai MaKmNavigation { get; set; } = null!;

    public virtual User UserNameNavigation { get; set; } = null!;
}
