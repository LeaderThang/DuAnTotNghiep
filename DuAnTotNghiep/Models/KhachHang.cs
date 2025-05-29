using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[PrimaryKey("Email", "HoTen")]
[Table("KhachHang")]
public partial class KhachHang
{
    [Key]
    [StringLength(30)]
    public string HoTen { get; set; } = null!;

    [StringLength(10)]
    public string Sdt { get; set; } = null!;

    [Key]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string? DiaChi { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    [StringLength(10)]
    public string TrangThai { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime NgayDangKy { get; set; }

    public int DiemTichLuy { get; set; }

    [StringLength(20)]
    public string LoaiKhachHang { get; set; } = null!;

    [StringLength(30)]
    public string? HoTenAdmin { get; set; }

    [StringLength(30)]
    public string UserName { get; set; } = null!;

    [ForeignKey("HoTenAdmin")]
    [InverseProperty("KhachHangs")]
    public virtual Admin? HoTenAdminNavigation { get; set; }

    [InverseProperty("KhachHang")]
    public virtual ICollection<UserKhachHang> UserKhachHangs { get; set; } = new List<UserKhachHang>();
}
