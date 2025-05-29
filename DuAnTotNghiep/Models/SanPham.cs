using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("SanPham")]
public partial class SanPham
{
    [Key]
    [Column("ID_Sp")]
    public Guid IdSp { get; set; }

    [Column("Ten_Sp")]
    [StringLength(50)]
    public string TenSp { get; set; } = null!;

    public int SoLuongTong { get; set; }

    [StringLength(255)]
    public string MoTa { get; set; } = null!;

    [StringLength(255)]
    public string TrangThai { get; set; } = null!;

    [InverseProperty("IdSpNavigation")]
    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
