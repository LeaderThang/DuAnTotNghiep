using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("BaoCao")]
public partial class BaoCao
{
    [Key]
    [Column("ID_BaoCao")]
    public Guid IdBaoCao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NgayBaoCao { get; set; }

    [StringLength(50)]
    public string LoaiBaoCao { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DoanhThu { get; set; }

    public int? SoLuongHangBanRa { get; set; }

    public int? SoLuongHangTon { get; set; }

    public int? TongSoDonHang { get; set; }

    public int? SoLuongDonHangHoanThanh { get; set; }

    public int? SoLuongDonHangDangXuLy { get; set; }

    public int? SoLuongDonHangBiHuy { get; set; }

    public int? TongSoKhachHang { get; set; }

    public int? SoKhachHangMoi { get; set; }

    public int? SoKhachHangTroLai { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayTao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayCapNhap { get; set; }

    [StringLength(30)]
    public string HoTenAdmin { get; set; } = null!;

    [ForeignKey("HoTenAdmin")]
    [InverseProperty("BaoCaos")]
    public virtual Admin HoTenAdminNavigation { get; set; } = null!;
}
