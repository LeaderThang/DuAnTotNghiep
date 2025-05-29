using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("NhanVien")]
public partial class NhanVien
{
    [Key]
    [Column("MaNV")]
    public Guid MaNv { get; set; }

    [Column("HoTenNV")]
    [StringLength(30)]
    public string HoTenNv { get; set; } = null!;

    [StringLength(30)]
    public string HoTenAdmin { get; set; } = null!;

    [StringLength(20)]
    public string Sdt { get; set; } = null!;

    [StringLength(30)]
    public string? Email { get; set; }

    [StringLength(30)]
    public string? DiaChi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgaySinh { get; set; }

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    [StringLength(30)]
    public string TrangThai { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime NgayVaoLam { get; set; }

    [StringLength(50)]
    public string ChucVu { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal LuongCoBan { get; set; }

    public int SoGioLamViec { get; set; }

    [StringLength(30)]
    public string UserName { get; set; } = null!;

    [InverseProperty("MaNvNavigation")]
    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    [ForeignKey("HoTenAdmin")]
    [InverseProperty("NhanViens")]
    public virtual Admin HoTenAdminNavigation { get; set; } = null!;

    [ForeignKey("UserName")]
    [InverseProperty("NhanViens")]
    public virtual User UserNameNavigation { get; set; } = null!;
}
