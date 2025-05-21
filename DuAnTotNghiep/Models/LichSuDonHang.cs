using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class LichSuDonHang
{
    public Guid IdLichSuDonHang { get; set; }

    public Guid IdDonHoanThanh { get; set; }

    public DateOnly? NgayThang { get; set; }

    public virtual DonHoanThanh IdDonHoanThanhNavigation { get; set; } = null!;
}
