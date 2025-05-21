using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class TonKho
{
    public Guid IdTonKho { get; set; }

    public Guid IdSpct { get; set; }

    public int SoLuongTonKho { get; set; }

    public DateTime? NgayCapNhap { get; set; }

    public virtual SanPhamChiTiet IdSpctNavigation { get; set; } = null!;
}
