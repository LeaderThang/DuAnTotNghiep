using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class HoaDon
{
    public Guid IdHoaDon { get; set; }

    public Guid IdUser { get; set; }

    public virtual UserKhachHang IdUserNavigation { get; set; } = null!;

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
