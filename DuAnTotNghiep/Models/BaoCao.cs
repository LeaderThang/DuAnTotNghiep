using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class BaoCao
{
    public Guid IdBaoCao { get; set; }

    public DateTime NgayBaoCao { get; set; }

    public string LoaiBaoCao { get; set; } = null!;

    public decimal? DoanhThu { get; set; }

    public int? SoLuongHangBanRa { get; set; }

    public int? SoLuongHangTon { get; set; }

    public int? TongSoDonHang { get; set; }

    public int? SoLuongDonHangHoanThanh { get; set; }

    public int? SoLuongDonHangDangXuLy { get; set; }

    public int? SoLuongDonHangBiHuy { get; set; }

    public int? TongSoKhachHang { get; set; }

    public int? SoKhachHangMoi { get; set; }

    public int? SoKhachHangTroLai { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhap { get; set; }

    public string HoTenAdmin { get; set; } = null!;

    public virtual Admin HoTenAdminNavigation { get; set; } = null!;
}
