using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("SanPham_ThanhToan")]
public partial class SanPhamThanhToan
{
    [Key]
    [Column("ID_Sp_ThanhToan")]
    public Guid IdSpThanhToan { get; set; }

    [Column("ID_ThanhToan")]
    public Guid IdThanhToan { get; set; }

    [Column("ID_Spct")]
    public Guid IdSpct { get; set; }

    public double SoLuong { get; set; }

    [ForeignKey("IdSpct")]
    [InverseProperty("SanPhamThanhToans")]
    public virtual SanPhamChiTiet IdSpctNavigation { get; set; } = null!;

    [ForeignKey("IdThanhToan")]
    [InverseProperty("SanPhamThanhToans")]
    public virtual ThanhToan IdThanhToanNavigation { get; set; } = null!;
}
