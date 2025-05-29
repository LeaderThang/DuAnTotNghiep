using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("ChatLieu")]
public partial class ChatLieu
{
    [Key]
    [Column("ID_ChatLieu")]
    public Guid IdChatLieu { get; set; }

    [Column("ChatLieu")]
    [StringLength(30)]
    public string ChatLieu1 { get; set; } = null!;

    [InverseProperty("IdChatLieuNavigation")]
    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
