using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class KhuyenMai
{
    public Guid MaKm { get; set; }

    public string TenKm { get; set; } = null!;

    public string? MoTa { get; set; }

    public string LoaiKm { get; set; } = null!;

    public decimal GiaTriKm { get; set; }

    public DateTime NgayBd { get; set; }

    public DateTime NgayKt { get; set; }

    public int? SoLuong { get; set; }

    public int? SoLuong1Ng { get; set; }

    public string HoTenAdmin { get; set; } = null!;

    public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; } = new List<GioHangChiTiet>();

    public virtual Admin HoTenAdminNavigation { get; set; } = null!;

    public virtual ICollection<SanPhamMua> SanPhamMuas { get; set; } = new List<SanPhamMua>();
}
