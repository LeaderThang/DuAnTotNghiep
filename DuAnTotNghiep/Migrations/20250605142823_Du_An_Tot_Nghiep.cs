using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DuAnTotNghiep.Migrations
{
    /// <inheritdoc />
    public partial class Du_An_Tot_Nghiep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatLieu",
                columns: table => new
                {
                    ID_ChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatLieu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieu", x => x.ID_ChatLieu);
                });

            migrationBuilder.CreateTable(
                name: "HangSX",
                columns: table => new
                {
                    ID_Hang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HangSX = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangSX", x => x.ID_Hang);
                });

            migrationBuilder.CreateTable(
                name: "MauSac",
                columns: table => new
                {
                    ID_MauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MauSac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x.ID_MauSac);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    ID_Sp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten_Sp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoLuongTong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.ID_Sp);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    ID_Size = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.ID_Size);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamChiTiet",
                columns: table => new
                {
                    ID_Spct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Sp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SoLuongBan = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DanhGia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ID_ChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ID_Hang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ID_MauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ID_Size = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamChiTiet", x => x.ID_Spct);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_ChatLieu",
                        column: x => x.ID_ChatLieu,
                        principalTable: "ChatLieu",
                        principalColumn: "ID_ChatLieu");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_HangSX",
                        column: x => x.ID_Hang,
                        principalTable: "HangSX",
                        principalColumn: "ID_Hang");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_MauSac",
                        column: x => x.ID_MauSac,
                        principalTable: "MauSac",
                        principalColumn: "ID_MauSac");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_SanPham",
                        column: x => x.ID_Sp,
                        principalTable: "SanPham",
                        principalColumn: "ID_Sp");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_Size",
                        column: x => x.ID_Size,
                        principalTable: "Size",
                        principalColumn: "ID_Size");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    HoTenAdmin = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.HoTenAdmin);
                    table.ForeignKey(
                        name: "FK_Admins_Users",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "AnhSp",
                columns: table => new
                {
                    ID_AnhSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileAnh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ID_Spct = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhSp", x => x.ID_AnhSp);
                    table.ForeignKey(
                        name: "FK_AnhSp_SanPhamChiTiet",
                        column: x => x.ID_Spct,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "ID_Spct");
                });

            migrationBuilder.CreateTable(
                name: "TonKho",
                columns: table => new
                {
                    ID_TonKho = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Spct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuongTonKho = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonKho", x => x.ID_TonKho);
                    table.ForeignKey(
                        name: "FK_TonKho_SanPhamChiTiet",
                        column: x => x.ID_Spct,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "ID_Spct");
                });

            migrationBuilder.CreateTable(
                name: "BaoCao",
                columns: table => new
                {
                    ID_BaoCao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayBaoCao = table.Column<DateTime>(type: "datetime", nullable: false),
                    LoaiBaoCao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoanhThu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SoLuongHangBanRa = table.Column<int>(type: "int", nullable: true),
                    SoLuongHangTon = table.Column<int>(type: "int", nullable: true),
                    TongSoDonHang = table.Column<int>(type: "int", nullable: true),
                    SoLuongDonHangHoanThanh = table.Column<int>(type: "int", nullable: true),
                    SoLuongDonHangDangXuLy = table.Column<int>(type: "int", nullable: true),
                    SoLuongDonHangBiHuy = table.Column<int>(type: "int", nullable: true),
                    TongSoKhachHang = table.Column<int>(type: "int", nullable: true),
                    SoKhachHangMoi = table.Column<int>(type: "int", nullable: true),
                    SoKhachHangTroLai = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    HoTenAdmin = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCao", x => x.ID_BaoCao);
                    table.ForeignKey(
                        name: "FK_BaoCao_Admins",
                        column: x => x.HoTenAdmin,
                        principalTable: "Admins",
                        principalColumn: "HoTenAdmin");
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    HoTen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DiemTichLuy = table.Column<int>(type: "int", nullable: false),
                    LoaiKhachHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoTenAdmin = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => new { x.Email, x.HoTen });
                    table.ForeignKey(
                        name: "FK_KhachHang_Admins",
                        column: x => x.HoTenAdmin,
                        principalTable: "Admins",
                        principalColumn: "HoTenAdmin");
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    Ma_Km = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LoaiKm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GiaTriKm = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NgayBd = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayKt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    SoLuong1Ng = table.Column<int>(type: "int", nullable: true),
                    HoTenAdmin = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.Ma_Km);
                    table.ForeignKey(
                        name: "FK_KhuyenMai_Admins",
                        column: x => x.HoTenAdmin,
                        principalTable: "Admins",
                        principalColumn: "HoTenAdmin");
                });

            migrationBuilder.CreateTable(
                name: "NCC",
                columns: table => new
                {
                    Ma_NCC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameNCC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameNLH = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThanhPho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    HoTenAdmin = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCC", x => x.Ma_NCC);
                    table.ForeignKey(
                        name: "FK_NCC_Admins",
                        column: x => x.HoTenAdmin,
                        principalTable: "Admins",
                        principalColumn: "HoTenAdmin");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTenNV = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HoTenAdmin = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgayVaoLam = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoGioLamViec = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanVien_Admins",
                        column: x => x.HoTenAdmin,
                        principalTable: "Admins",
                        principalColumn: "HoTenAdmin");
                    table.ForeignKey(
                        name: "FK_NhanVien_Users",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "User_KhachHang",
                columns: table => new
                {
                    ID_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_KhachHang", x => x.ID_User);
                    table.ForeignKey(
                        name: "FK_User_KhachHang_KhachHang",
                        columns: x => new { x.Email, x.HoTen },
                        principalTable: "KhachHang",
                        principalColumns: new[] { "Email", "HoTen" });
                    table.ForeignKey(
                        name: "FK_User_KhachHang_Users",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    ID_Don_Hang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.ID_Don_Hang);
                    table.ForeignKey(
                        name: "FK_Orders_NhanVien",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "Gio_Hang",
                columns: table => new
                {
                    ID_Gio_Hang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gio_Hang", x => x.ID_Gio_Hang);
                    table.ForeignKey(
                        name: "FK_Gio_Hang_User_KhachHang",
                        column: x => x.ID_User,
                        principalTable: "User_KhachHang",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    ID_HoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.ID_HoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_User_KhachHang",
                        column: x => x.ID_User,
                        principalTable: "User_KhachHang",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "SanPhamYeuThich",
                columns: table => new
                {
                    ID_Spyt = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamYeuThich", x => x.ID_Spyt);
                    table.ForeignKey(
                        name: "FK_SanPhamYeuThich_User_KhachHang",
                        column: x => x.ID_User,
                        principalTable: "User_KhachHang",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "ThanhToan",
                columns: table => new
                {
                    ID_ThanhToan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_HoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SoTienThanhToan = table.Column<double>(type: "float", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToan", x => x.ID_ThanhToan);
                    table.ForeignKey(
                        name: "FK_ThanhToan_HoaDon",
                        column: x => x.ID_HoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "ID_HoaDon");
                });

            migrationBuilder.CreateTable(
                name: "SanPhamYeuThichChiTiet",
                columns: table => new
                {
                    ID_Spyt_Chi_Tiet = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Spyt = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Spct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamYeuThichChiTiet", x => x.ID_Spyt_Chi_Tiet);
                    table.ForeignKey(
                        name: "FK_SanPhamYeuThichChiTiet_SanPhamChiTiet",
                        column: x => x.ID_Spct,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "ID_Spct");
                    table.ForeignKey(
                        name: "FK_SanPhamYeuThichChiTiet_SanPhamYeuThich",
                        column: x => x.ID_Spyt,
                        principalTable: "SanPhamYeuThich",
                        principalColumn: "ID_Spyt");
                });

            migrationBuilder.CreateTable(
                name: "Don_Hang_Thanh_Toan",
                columns: table => new
                {
                    ID_Don_Hang_Thanh_Toan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_ThanhToan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Don_Hang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgayTT = table.Column<DateOnly>(type: "date", nullable: true),
                    KieuTT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Don_Hang_Thanh_Toan", x => x.ID_Don_Hang_Thanh_Toan);
                    table.ForeignKey(
                        name: "FK_Don_Hang_Thanh_Toan_Don_Hang",
                        column: x => x.ID_Don_Hang,
                        principalTable: "DonHang",
                        principalColumn: "ID_Don_Hang");
                    table.ForeignKey(
                        name: "FK_Don_Hang_Thanh_Toan_ThanhToan",
                        column: x => x.ID_ThanhToan,
                        principalTable: "ThanhToan",
                        principalColumn: "ID_ThanhToan");
                });

            migrationBuilder.CreateTable(
                name: "GiaoHang",
                columns: table => new
                {
                    ID_GiaoHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_ThanhToan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Don_Hang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayPhanCongGiaoHang = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ThoiGianDuKienGiaoHang = table.Column<DateTime>(type: "datetime", nullable: false),
                    ThoiGianThucTeGiaoHang = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThaiGiaoHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoHang", x => x.ID_GiaoHang);
                    table.ForeignKey(
                        name: "FK_GiaoHang_DonHang",
                        column: x => x.ID_Don_Hang,
                        principalTable: "DonHang",
                        principalColumn: "ID_Don_Hang");
                    table.ForeignKey(
                        name: "FK_GiaoHang_ThanhToan",
                        column: x => x.ID_ThanhToan,
                        principalTable: "ThanhToan",
                        principalColumn: "ID_ThanhToan");
                });

            migrationBuilder.CreateTable(
                name: "SanPham_ThanhToan",
                columns: table => new
                {
                    ID_Sp_ThanhToan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_ThanhToan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Spct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham_ThanhToan", x => x.ID_Sp_ThanhToan);
                    table.ForeignKey(
                        name: "FK_SanPham_ThanhToan_SanPhamChiTiet",
                        column: x => x.ID_Spct,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "ID_Spct");
                    table.ForeignKey(
                        name: "FK_SanPham_ThanhToan_ThanhToan",
                        column: x => x.ID_ThanhToan,
                        principalTable: "ThanhToan",
                        principalColumn: "ID_ThanhToan");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserName",
                table: "Admins",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_AnhSp_ID_Spct",
                table: "AnhSp",
                column: "ID_Spct");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCao_HoTenAdmin",
                table: "BaoCao",
                column: "HoTenAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_Don_Hang_Thanh_Toan_ID_Don_Hang",
                table: "Don_Hang_Thanh_Toan",
                column: "ID_Don_Hang");

            migrationBuilder.CreateIndex(
                name: "IX_Don_Hang_Thanh_Toan_ID_ThanhToan",
                table: "Don_Hang_Thanh_Toan",
                column: "ID_ThanhToan");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaNV",
                table: "DonHang",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoHang_ID_Don_Hang",
                table: "GiaoHang",
                column: "ID_Don_Hang");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoHang_ID_ThanhToan",
                table: "GiaoHang",
                column: "ID_ThanhToan");

            migrationBuilder.CreateIndex(
                name: "IX_Gio_Hang_ID_User",
                table: "Gio_Hang",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ID_User",
                table: "HoaDon",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_HoTenAdmin",
                table: "KhachHang",
                column: "HoTenAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMai_HoTenAdmin",
                table: "KhuyenMai",
                column: "HoTenAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_NCC_HoTenAdmin",
                table: "NCC",
                column: "HoTenAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_HoTenAdmin",
                table: "NhanVien",
                column: "HoTenAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_UserName",
                table: "NhanVien",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ThanhToan_ID_Spct",
                table: "SanPham_ThanhToan",
                column: "ID_Spct");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ThanhToan_ID_ThanhToan",
                table: "SanPham_ThanhToan",
                column: "ID_ThanhToan");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_ID_ChatLieu",
                table: "SanPhamChiTiet",
                column: "ID_ChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_ID_Hang",
                table: "SanPhamChiTiet",
                column: "ID_Hang");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_ID_MauSac",
                table: "SanPhamChiTiet",
                column: "ID_MauSac");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_ID_Size",
                table: "SanPhamChiTiet",
                column: "ID_Size");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_ID_Sp",
                table: "SanPhamChiTiet",
                column: "ID_Sp");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamYeuThich_ID_User",
                table: "SanPhamYeuThich",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamYeuThichChiTiet_ID_Spct",
                table: "SanPhamYeuThichChiTiet",
                column: "ID_Spct");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamYeuThichChiTiet_ID_Spyt",
                table: "SanPhamYeuThichChiTiet",
                column: "ID_Spyt");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_ID_HoaDon",
                table: "ThanhToan",
                column: "ID_HoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_TonKho_ID_Spct",
                table: "TonKho",
                column: "ID_Spct");

            migrationBuilder.CreateIndex(
                name: "IX_User_KhachHang_Email_HoTen",
                table: "User_KhachHang",
                columns: new[] { "Email", "HoTen" });

            migrationBuilder.CreateIndex(
                name: "IX_User_KhachHang_UserName",
                table: "User_KhachHang",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhSp");

            migrationBuilder.DropTable(
                name: "BaoCao");

            migrationBuilder.DropTable(
                name: "Don_Hang_Thanh_Toan");

            migrationBuilder.DropTable(
                name: "GiaoHang");

            migrationBuilder.DropTable(
                name: "Gio_Hang");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "NCC");

            migrationBuilder.DropTable(
                name: "SanPham_ThanhToan");

            migrationBuilder.DropTable(
                name: "SanPhamYeuThichChiTiet");

            migrationBuilder.DropTable(
                name: "TonKho");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "ThanhToan");

            migrationBuilder.DropTable(
                name: "SanPhamYeuThich");

            migrationBuilder.DropTable(
                name: "SanPhamChiTiet");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "ChatLieu");

            migrationBuilder.DropTable(
                name: "HangSX");

            migrationBuilder.DropTable(
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "User_KhachHang");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
