using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class GioHang
{
    public Guid IdGioHang { get; set; }

    public Guid IdUser { get; set; }

    public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; } = new List<GioHangChiTiet>();

    public virtual UserKhachHang IdUserNavigation { get; set; } = null!;
}
