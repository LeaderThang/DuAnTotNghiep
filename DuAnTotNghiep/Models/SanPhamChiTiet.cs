using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("SanPhamChiTiet")]
public partial class SanPhamChiTiet
{
    [Key]
    [Column("ID_Spct")]
    public Guid IdSpct { get; set; }

    [Column("ID_Sp")]
    public Guid IdSp { get; set; }

    [StringLength(30)]
    public string TenSp { get; set; } = null!;

    [StringLength(500)]
    public string MoTa { get; set; } = null!;

    public int SoLuongBan { get; set; }

    public double Gia { get; set; }

    [StringLength(30)]
    public string AnhDaiDien { get; set; } = null!;

    [StringLength(30)]
    public string? DanhGia { get; set; }

    [Column("ID_ChatLieu")]
    public Guid? IdChatLieu { get; set; }

    [Column("ID_Hang")]
    public Guid? IdHang { get; set; }

    [Column("ID_MauSac")]
    public Guid? IdMauSac { get; set; }

    [Column("ID_Size")]
    public Guid? IdSize { get; set; }

    [InverseProperty("IdSpctNavigation")]
    public virtual ICollection<AnhSp> AnhSps { get; set; } = new List<AnhSp>();

    [ForeignKey("IdChatLieu")]
    [InverseProperty("SanPhamChiTiets")]
    public virtual ChatLieu? IdChatLieuNavigation { get; set; }

    [ForeignKey("IdHang")]
    [InverseProperty("SanPhamChiTiets")]
    public virtual HangSx? IdHangNavigation { get; set; }

    [ForeignKey("IdMauSac")]
    [InverseProperty("SanPhamChiTiets")]
    public virtual MauSac? IdMauSacNavigation { get; set; }

    [ForeignKey("IdSize")]
    [InverseProperty("SanPhamChiTiets")]
    public virtual Size? IdSizeNavigation { get; set; }

    [ForeignKey("IdSp")]
    [InverseProperty("SanPhamChiTiets")]
    public virtual SanPham IdSpNavigation { get; set; } = null!;

    [InverseProperty("IdSpctNavigation")]
    public virtual ICollection<SanPhamThanhToan> SanPhamThanhToans { get; set; } = new List<SanPhamThanhToan>();

    [InverseProperty("IdSpctNavigation")]
    public virtual ICollection<SanPhamYeuThichChiTiet> SanPhamYeuThichChiTiets { get; set; } = new List<SanPhamYeuThichChiTiet>();

    [InverseProperty("IdSpctNavigation")]
    public virtual ICollection<TonKho> TonKhos { get; set; } = new List<TonKho>();
}
