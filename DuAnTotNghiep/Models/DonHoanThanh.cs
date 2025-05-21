using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class DonHoanThanh
{
    public Guid IdDonHoanThanh { get; set; }

    public string IdDonHangThanhToan { get; set; } = null!;

    public virtual ICollection<DanhGiaNhanXet> DanhGiaNhanXets { get; set; } = new List<DanhGiaNhanXet>();

    public virtual ICollection<LichSuDonHang> LichSuDonHangs { get; set; } = new List<LichSuDonHang>();
}
