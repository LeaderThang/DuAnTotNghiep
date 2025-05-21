using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class DanhGiaNhanXet
{
    public Guid IdDanhGiaNhanXet { get; set; }

    public Guid IdDonHoanThanh { get; set; }

    public string HoTen { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public DateOnly? Ngay { get; set; }

    public virtual ICollection<Anh> Anhs { get; set; } = new List<Anh>();

    public virtual DonHoanThanh IdDonHoanThanhNavigation { get; set; } = null!;

    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
