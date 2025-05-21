using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class DonHang
{
    public Guid IdDonHang { get; set; }

    public Guid MaNv { get; set; }

    public virtual ICollection<DonHangThanhToan> DonHangThanhToans { get; set; } = new List<DonHangThanhToan>();

    public virtual ICollection<GiaoHang> GiaoHangs { get; set; } = new List<GiaoHang>();

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
