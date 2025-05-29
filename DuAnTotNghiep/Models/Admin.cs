using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

public partial class Admin
{
    [Key]
    [StringLength(30)]
    public string HoTenAdmin { get; set; } = null!;

    [StringLength(30)]
    public string AnhDaiDien { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? NgaySinh { get; set; }

    [StringLength(30)]
    public string Email { get; set; } = null!;

    [StringLength(10)]
    public string Sdt { get; set; } = null!;

    [StringLength(30)]
    public string DiaChi { get; set; } = null!;

    [StringLength(30)]
    public string UserName { get; set; } = null!;

    [InverseProperty("HoTenAdminNavigation")]
    public virtual ICollection<BaoCao> BaoCaos { get; set; } = new List<BaoCao>();

    [InverseProperty("HoTenAdminNavigation")]
    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    [InverseProperty("HoTenAdminNavigation")]
    public virtual ICollection<KhuyenMai> KhuyenMais { get; set; } = new List<KhuyenMai>();

    [InverseProperty("HoTenAdminNavigation")]
    public virtual ICollection<Ncc> Nccs { get; set; } = new List<Ncc>();

    [InverseProperty("HoTenAdminNavigation")]
    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    [ForeignKey("UserName")]
    [InverseProperty("Admins")]
    public virtual User UserNameNavigation { get; set; } = null!;
}
