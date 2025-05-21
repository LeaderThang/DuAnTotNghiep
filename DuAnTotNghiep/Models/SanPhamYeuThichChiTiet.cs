using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class SanPhamYeuThichChiTiet
{
    public Guid IdSpytChiTiet { get; set; }

    public Guid IdSpyt { get; set; }

    public Guid IdSpct { get; set; }

    public double Gia { get; set; }

    public virtual SanPhamChiTiet IdSpctNavigation { get; set; } = null!;

    public virtual SanPhamYeuThich IdSpytNavigation { get; set; } = null!;
}
