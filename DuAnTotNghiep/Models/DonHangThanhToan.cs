using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class DonHangThanhToan
{
    public Guid IdDonHangThanhToan { get; set; }

    public Guid IdThanhToan { get; set; }

    public Guid IdDonHang { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? NgayTt { get; set; }

    public string KieuTt { get; set; } = null!;

    public virtual DonHang IdDonHangNavigation { get; set; } = null!;

    public virtual ThanhToan IdThanhToanNavigation { get; set; } = null!;
}
