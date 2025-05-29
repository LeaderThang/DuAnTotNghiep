using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("Size")]
public partial class Size
{
    [Key]
    [Column("ID_Size")]
    public Guid IdSize { get; set; }

    [Column("Size")]
    [StringLength(30)]
    public string Size1 { get; set; } = null!;

    [InverseProperty("IdSizeNavigation")]
    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
