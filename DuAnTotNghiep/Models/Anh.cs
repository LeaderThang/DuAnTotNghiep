using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class Anh
{
    public Guid IdAnh { get; set; }

    public Guid IdDanhGiaNhanXet { get; set; }

    public string HinhAnh { get; set; } = null!;

    public virtual DanhGiaNhanXet IdDanhGiaNhanXetNavigation { get; set; } = null!;
}
