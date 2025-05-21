using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class HangSx
{
    public Guid IdHang { get; set; }

    public string HangSx1 { get; set; } = null!;

    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
