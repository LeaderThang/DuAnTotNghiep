using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("Don_Hang_Thanh_Toan")]
public partial class DonHangThanhToan
{
    [Key]
    [Column("ID_Don_Hang_Thanh_Toan")]
    public Guid IdDonHangThanhToan { get; set; }

    [Column("ID_ThanhToan")]
    public Guid IdThanhToan { get; set; }

    [Column("ID_Don_Hang")]
    public Guid IdDonHang { get; set; }

    [StringLength(30)]
    public string Status { get; set; } = null!;

    [Column("NgayTT")]
    public DateOnly? NgayTt { get; set; }

    [Column("KieuTT")]
    [StringLength(50)]
    public string KieuTt { get; set; } = null!;

    [ForeignKey("IdDonHang")]
    [InverseProperty("DonHangThanhToans")]
    public virtual DonHang IdDonHangNavigation { get; set; } = null!;

    [ForeignKey("IdThanhToan")]
    [InverseProperty("DonHangThanhToans")]
    public virtual ThanhToan IdThanhToanNavigation { get; set; } = null!;
}
