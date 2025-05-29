using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("DonHang")]
public partial class DonHang
{
    [Key]
    [Column("ID_Don_Hang")]
    public Guid IdDonHang { get; set; }

    [Column("MaNV")]
    public Guid MaNv { get; set; }

    [InverseProperty("IdDonHangNavigation")]
    public virtual ICollection<DonHangThanhToan> DonHangThanhToans { get; set; } = new List<DonHangThanhToan>();

    [InverseProperty("IdDonHangNavigation")]
    public virtual ICollection<GiaoHang> GiaoHangs { get; set; } = new List<GiaoHang>();

    [ForeignKey("MaNv")]
    [InverseProperty("DonHangs")]
    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
