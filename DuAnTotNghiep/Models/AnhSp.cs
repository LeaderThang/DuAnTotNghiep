using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("AnhSp")]
public partial class AnhSp
{
    [Key]
    [Column("ID_AnhSp")]
    public Guid IdAnhSp { get; set; }

    [StringLength(30)]
    public string FileAnh { get; set; } = null!;

    [Column("ID_Spct")]
    public Guid? IdSpct { get; set; }

    [ForeignKey("IdSpct")]
    [InverseProperty("AnhSps")]
    public virtual SanPhamChiTiet? IdSpctNavigation { get; set; }
}
