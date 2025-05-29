using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("User_KhachHang")]
public partial class UserKhachHang
{
    [Key]
    [Column("ID_User")]
    public Guid IdUser { get; set; }

    [StringLength(30)]
    public string HoTen { get; set; } = null!;

    [StringLength(30)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    [ForeignKey("Email, HoTen")]
    [InverseProperty("UserKhachHangs")]
    public virtual KhachHang KhachHang { get; set; } = null!;

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<SanPhamYeuThich> SanPhamYeuThiches { get; set; } = new List<SanPhamYeuThich>();

    [ForeignKey("UserName")]
    [InverseProperty("UserKhachHangs")]
    public virtual User UserNameNavigation { get; set; } = null!;
}
