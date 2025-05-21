using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class SanPhamThanhToan
{
    public Guid IdSpThanhToan { get; set; }

    public Guid IdThanhToan { get; set; }

    public Guid IdSpct { get; set; }

    public double SoLuong { get; set; }

    public virtual SanPhamChiTiet IdSpctNavigation { get; set; } = null!;

    public virtual ThanhToan IdThanhToanNavigation { get; set; } = null!;
}
