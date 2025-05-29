using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("SanPhamYeuThich")]
public partial class SanPhamYeuThich
{
    [Key]
    [Column("ID_Spyt")]
    public Guid IdSpyt { get; set; }

    [Column("ID_User")]
    public Guid IdUser { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("SanPhamYeuThiches")]
    public virtual UserKhachHang IdUserNavigation { get; set; } = null!;

    [InverseProperty("IdSpytNavigation")]
    public virtual ICollection<SanPhamYeuThichChiTiet> SanPhamYeuThichChiTiets { get; set; } = new List<SanPhamYeuThichChiTiet>();
}
