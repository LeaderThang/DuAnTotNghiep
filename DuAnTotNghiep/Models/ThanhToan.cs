using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("ThanhToan")]
public partial class ThanhToan
{
    [Key]
    [Column("ID_ThanhToan")]
    public Guid IdThanhToan { get; set; }

    [Column("ID_HoaDon")]
    public Guid IdHoaDon { get; set; }

    [StringLength(50)]
    public string PhuongThucThanhToan { get; set; } = null!;

    [StringLength(30)]
    public string Status { get; set; } = null!;

    public double SoTienThanhToan { get; set; }

    [StringLength(30)]
    public string? DiaChi { get; set; }

    [Column("SDT")]
    [StringLength(15)]
    public string? Sdt { get; set; }

    [StringLength(20)]
    public string? HoTen { get; set; }

    [StringLength(255)]
    public string? GhiChu { get; set; }

    [InverseProperty("IdThanhToanNavigation")]
    public virtual ICollection<DonHangThanhToan> DonHangThanhToans { get; set; } = new List<DonHangThanhToan>();

    [InverseProperty("IdThanhToanNavigation")]
    public virtual ICollection<GiaoHang> GiaoHangs { get; set; } = new List<GiaoHang>();

    [ForeignKey("IdHoaDon")]
    [InverseProperty("ThanhToans")]
    public virtual HoaDon IdHoaDonNavigation { get; set; } = null!;

    [InverseProperty("IdThanhToanNavigation")]
    public virtual ICollection<SanPhamThanhToan> SanPhamThanhToans { get; set; } = new List<SanPhamThanhToan>();
}
