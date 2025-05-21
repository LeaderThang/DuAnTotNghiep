using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class SanPham
{
    public Guid IdSp { get; set; }

    public string TenSp { get; set; } = null!;

    public int SoLuongTong { get; set; }

    public string MoTa { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
