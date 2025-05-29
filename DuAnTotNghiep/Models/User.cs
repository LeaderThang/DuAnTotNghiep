using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

public partial class User
{
    [Key]
    [StringLength(30)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    [StringLength(30)]
    public string Role { get; set; } = null!;

    [InverseProperty("UserNameNavigation")]
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    [InverseProperty("UserNameNavigation")]
    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    [InverseProperty("UserNameNavigation")]
    public virtual ICollection<UserKhachHang> UserKhachHangs { get; set; } = new List<UserKhachHang>();
}
