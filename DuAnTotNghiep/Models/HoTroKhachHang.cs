using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class HoTroKhachHang
{
    public Guid IdHoTroKhachHang { get; set; }

    public Guid MaNv { get; set; }

    public Guid IdUser { get; set; }

    public string LoaiHt { get; set; } = null!;

    public string PtlienLac { get; set; } = null!;

    public virtual UserKhachHang IdUserNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
