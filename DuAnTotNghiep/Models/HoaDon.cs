using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("HoaDon")]
public partial class HoaDon
{
    [Key]
    [Column("ID_HoaDon")]
    public Guid IdHoaDon { get; set; }

    [Column("ID_User")]
    public Guid IdUser { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("HoaDons")]
    public virtual UserKhachHang IdUserNavigation { get; set; } = null!;

    [InverseProperty("IdHoaDonNavigation")]
    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
