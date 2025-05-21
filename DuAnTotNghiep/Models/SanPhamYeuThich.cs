using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class SanPhamYeuThich
{
    public Guid IdSpyt { get; set; }

    public Guid IdUser { get; set; }

    public virtual UserKhachHang IdUserNavigation { get; set; } = null!;

    public virtual ICollection<SanPhamYeuThichChiTiet> SanPhamYeuThichChiTiets { get; set; } = new List<SanPhamYeuThichChiTiet>();
}
