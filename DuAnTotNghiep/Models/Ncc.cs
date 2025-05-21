using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class Ncc
{
    public Guid MaNcc { get; set; }

    public string NameNcc { get; set; } = null!;

    public string? NameNlh { get; set; }

    public string Sdt { get; set; } = null!;

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public string? ThanhPho { get; set; }

    public string? QuocGia { get; set; }

    public string? MoTa { get; set; }

    public string TrangThai { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string HoTenAdmin { get; set; } = null!;

    public virtual Admin HoTenAdminNavigation { get; set; } = null!;
}
