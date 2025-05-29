using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("HangSX")]
public partial class HangSx
{
    [Key]
    [Column("ID_Hang")]
    public Guid IdHang { get; set; }

    [Column("HangSX")]
    [StringLength(30)]
    public string HangSx1 { get; set; } = null!;

    [InverseProperty("IdHangNavigation")]
    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
