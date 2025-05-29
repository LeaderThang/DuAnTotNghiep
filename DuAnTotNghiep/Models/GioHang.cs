using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("Gio_Hang")]
public partial class GioHang
{
    [Key]
    [Column("ID_Gio_Hang")]
    public Guid IdGioHang { get; set; }

    [Column("ID_User")]
    public Guid IdUser { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("GioHangs")]
    public virtual UserKhachHang IdUserNavigation { get; set; } = null!;
}
