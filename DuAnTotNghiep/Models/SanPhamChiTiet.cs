using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class SanPhamChiTiet
{
    public Guid IdSpct { get; set; }

    public Guid IdSp { get; set; }

    public string TenSp { get; set; } = null!;

    public string MoTa { get; set; } = null!;

    public int SoLuongBan { get; set; }

    public double Gia { get; set; }

    public string AnhDaiDien { get; set; } = null!;

    public string? DanhGia { get; set; }

    public Guid? IdChatLieu { get; set; }

    public Guid? IdHang { get; set; }

    public Guid? IdMauSac { get; set; }

    public Guid? IdSize { get; set; }

    public virtual ICollection<AnhSp> AnhSps { get; set; } = new List<AnhSp>();

    public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; } = new List<GioHangChiTiet>();

    public virtual ChatLieu? IdChatLieuNavigation { get; set; }

    public virtual HangSx? IdHangNavigation { get; set; }

    public virtual Size? IdSizeNavigation { get; set; }

    public virtual SanPham IdSpNavigation { get; set; } = null!;

    public virtual ICollection<SanPhamMua> SanPhamMuas { get; set; } = new List<SanPhamMua>();

    public virtual ICollection<SanPhamThanhToan> SanPhamThanhToans { get; set; } = new List<SanPhamThanhToan>();

    public virtual ICollection<SanPhamYeuThichChiTiet> SanPhamYeuThichChiTiets { get; set; } = new List<SanPhamYeuThichChiTiet>();

    public virtual ICollection<TonKho> TonKhos { get; set; } = new List<TonKho>();
}
