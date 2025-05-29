using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

[Table("NCC")]
public partial class Ncc
{
    [Key]
    [Column("Ma_NCC")]
    public Guid MaNcc { get; set; }

    [Column("NameNCC")]
    [StringLength(30)]
    public string NameNcc { get; set; } = null!;

    [Column("NameNLH")]
    [StringLength(30)]
    public string? NameNlh { get; set; }

    [Column("SDT")]
    [StringLength(20)]
    public string Sdt { get; set; } = null!;

    [StringLength(30)]
    public string? Email { get; set; }

    [StringLength(100)]
    public string? DiaChi { get; set; }

    [StringLength(50)]
    public string? ThanhPho { get; set; }

    [StringLength(50)]
    public string? QuocGia { get; set; }

    [StringLength(200)]
    public string? MoTa { get; set; }

    [StringLength(30)]
    public string TrangThai { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [StringLength(30)]
    public string HoTenAdmin { get; set; } = null!;

    [ForeignKey("HoTenAdmin")]
    [InverseProperty("Nccs")]
    public virtual Admin HoTenAdminNavigation { get; set; } = null!;
}
