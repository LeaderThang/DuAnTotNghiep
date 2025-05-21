using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class GiaoHang
{
    public Guid IdGiaoHang { get; set; }

    public Guid IdThanhToan { get; set; }

    public Guid? IdDonHang { get; set; }

    public DateTime? NgayPhanCongGiaoHang { get; set; }

    public DateTime ThoiGianDuKienGiaoHang { get; set; }

    public DateTime? ThoiGianThucTeGiaoHang { get; set; }

    public string TrangThaiGiaoHang { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhap { get; set; }

    public virtual DonHang? IdDonHangNavigation { get; set; }

    public virtual ThanhToan IdThanhToanNavigation { get; set; } = null!;
}
