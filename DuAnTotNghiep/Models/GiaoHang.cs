using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("GiaoHang")]
public partial class GiaoHang
{
    [Key]
    [Column("ID_GiaoHang")]
    public Guid IdGiaoHang { get; set; }

    [Column("ID_ThanhToan")]
    public Guid IdThanhToan { get; set; }

    [Column("ID_Don_Hang")]
    public Guid? IdDonHang { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayPhanCongGiaoHang { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ThoiGianDuKienGiaoHang { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ThoiGianThucTeGiaoHang { get; set; }

    [StringLength(50)]
    public string TrangThaiGiaoHang { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? NgayTao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayCapNhap { get; set; }

    [ForeignKey("IdDonHang")]
    [InverseProperty("GiaoHangs")]
    public virtual DonHang? IdDonHangNavigation { get; set; }

    [ForeignKey("IdThanhToan")]
    [InverseProperty("GiaoHangs")]
    public virtual ThanhToan IdThanhToanNavigation { get; set; } = null!;
}
