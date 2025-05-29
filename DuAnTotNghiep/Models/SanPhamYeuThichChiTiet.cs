using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("SanPhamYeuThichChiTiet")]
public partial class SanPhamYeuThichChiTiet
{
    [Key]
    [Column("ID_Spyt_Chi_Tiet")]
    public Guid IdSpytChiTiet { get; set; }

    [Column("ID_Spyt")]
    public Guid IdSpyt { get; set; }

    [Column("ID_Spct")]
    public Guid IdSpct { get; set; }

    public double Gia { get; set; }

    [ForeignKey("IdSpct")]
    [InverseProperty("SanPhamYeuThichChiTiets")]
    public virtual SanPhamChiTiet IdSpctNavigation { get; set; } = null!;

    [ForeignKey("IdSpyt")]
    [InverseProperty("SanPhamYeuThichChiTiets")]
    public virtual SanPhamYeuThich IdSpytNavigation { get; set; } = null!;
}
