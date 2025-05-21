using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<SanPhamMua> SanPhamMuas { get; set; } = new List<SanPhamMua>();

    public virtual ICollection<UserKhachHang> UserKhachHangs { get; set; } = new List<UserKhachHang>();
}
