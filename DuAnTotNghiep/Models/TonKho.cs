using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("TonKho")]
public partial class TonKho
{
    [Key]
    [Column("ID_TonKho")]
    public Guid IdTonKho { get; set; }

    [Column("ID_Spct")]
    public Guid IdSpct { get; set; }

    public int SoLuongTonKho { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayCapNhap { get; set; }

    [ForeignKey("IdSpct")]
    [InverseProperty("TonKhos")]
    public virtual SanPhamChiTiet IdSpctNavigation { get; set; } = null!;
}
