using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class Video
{
    public Guid IdVideo { get; set; }

    public Guid IdDanhGiaNhanXet { get; set; }

    public string Video1 { get; set; } = null!;

    public virtual DanhGiaNhanXet IdDanhGiaNhanXetNavigation { get; set; } = null!;
}
