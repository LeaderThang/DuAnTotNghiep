using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("KhuyenMai")]
public partial class KhuyenMai
{
    [Key]
    [Column("Ma_Km")]
    public Guid MaKm { get; set; }

    [StringLength(100)]
    public string TenKm { get; set; } = null!;

    [StringLength(300)]
    public string? MoTa { get; set; }

    [StringLength(50)]
    public string LoaiKm { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal GiaTriKm { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NgayBd { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NgayKt { get; set; }

    public int? SoLuong { get; set; }

    public int? SoLuong1Ng { get; set; }

    [StringLength(30)]
    public string HoTenAdmin { get; set; } = null!;

    [ForeignKey("HoTenAdmin")]
    [InverseProperty("KhuyenMais")]
    public virtual Admin HoTenAdminNavigation { get; set; } = null!;
}
