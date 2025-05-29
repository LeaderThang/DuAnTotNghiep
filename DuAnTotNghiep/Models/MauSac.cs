using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("MauSac")]
public partial class MauSac
{
    [Key]
    [Column("ID_MauSac")]
    public Guid IdMauSac { get; set; }

    [Column("MauSac")]
    [StringLength(30)]
    public string MauSac1 { get; set; } = null!;

    [InverseProperty("IdMauSacNavigation")]
    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
