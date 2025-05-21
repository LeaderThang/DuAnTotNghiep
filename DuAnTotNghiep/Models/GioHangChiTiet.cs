using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class GioHangChiTiet
{
    public Guid IdGioHangChiTiet { get; set; }

    public Guid IdGioHang { get; set; }

    public Guid IdSpct { get; set; }

    public Guid? MaKm { get; set; }

    public double SoLuong { get; set; }

    public double Gia { get; set; }

    public virtual GioHang IdGioHangNavigation { get; set; } = null!;

    public virtual SanPhamChiTiet IdSpctNavigation { get; set; } = null!;

    public virtual KhuyenMai? MaKmNavigation { get; set; }
}
