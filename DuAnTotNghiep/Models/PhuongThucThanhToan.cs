using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class PhuongThucThanhToan
{
    public Guid IdPhuongThucThanhToan { get; set; }

    public string PhuongThuc { get; set; } = null!;

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
