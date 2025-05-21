using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class Size
{
    public Guid IdSize { get; set; }

    public string Size1 { get; set; } = null!;

    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
