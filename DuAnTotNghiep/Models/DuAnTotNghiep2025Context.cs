using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

public partial class DuAnTotNghiep2025Context : DbContext
{
    public DuAnTotNghiep2025Context()
    {
    }

    public DuAnTotNghiep2025Context(DbContextOptions<DuAnTotNghiep2025Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Anh> Anhs { get; set; }

    public virtual DbSet<AnhSp> AnhSps { get; set; }

    public virtual DbSet<BaoCao> BaoCaos { get; set; }

    public virtual DbSet<ChatLieu> ChatLieus { get; set; }

    public virtual DbSet<DanhGiaNhanXet> DanhGiaNhanXets { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<DonHangThanhToan> DonHangThanhToans { get; set; }

    public virtual DbSet<DonHoanThanh> DonHoanThanhs { get; set; }

    public virtual DbSet<GiaoHang> GiaoHangs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }

    public virtual DbSet<HangSx> HangSxes { get; set; }

    public virtual DbSet<HoTroKhachHang> HoTroKhachHangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<LichSuDonHang> LichSuDonHangs { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<Ncc> Nccs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; }

    public virtual DbSet<SanPhamMua> SanPhamMuas { get; set; }

    public virtual DbSet<SanPhamThanhToan> SanPhamThanhToans { get; set; }

    public virtual DbSet<SanPhamYeuThich> SanPhamYeuThiches { get; set; }

    public virtual DbSet<SanPhamYeuThichChiTiet> SanPhamYeuThichChiTiets { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<TonKho> TonKhos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserKhachHang> UserKhachHangs { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-606FI0J;Database=Du_an_tot_nghiep_2025;Trusted_Connection=True; TrustServerCertificate =True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.HoTenAdmin);

            entity.Property(e => e.HoTenAdmin).HasMaxLength(30);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(30);
            entity.Property(e => e.DiaChi).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt).HasMaxLength(10);
            entity.Property(e => e.UserName).HasMaxLength(30);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admins_Users");
        });

        modelBuilder.Entity<Anh>(entity =>
        {
            entity.HasKey(e => e.IdAnh);

            entity.ToTable("Anh");

            entity.Property(e => e.IdAnh)
                .ValueGeneratedNever()
                .HasColumnName("ID_Anh");
            entity.Property(e => e.HinhAnh).HasMaxLength(50);
            entity.Property(e => e.IdDanhGiaNhanXet).HasColumnName("ID_DanhGia_NhanXet");

            entity.HasOne(d => d.IdDanhGiaNhanXetNavigation).WithMany(p => p.Anhs)
                .HasForeignKey(d => d.IdDanhGiaNhanXet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Anh_DanhGia_NhanXet");
        });

        modelBuilder.Entity<AnhSp>(entity =>
        {
            entity.HasKey(e => e.IdAnhSp);

            entity.ToTable("AnhSp");

            entity.Property(e => e.IdAnhSp)
                .ValueGeneratedNever()
                .HasColumnName("ID_AnhSp");
            entity.Property(e => e.FileAnh).HasMaxLength(30);
            entity.Property(e => e.IdSpct).HasColumnName("ID_Spct");

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.AnhSps)
                .HasForeignKey(d => d.IdSpct)
                .HasConstraintName("FK_AnhSp_SanPhamChiTiet");
        });

        modelBuilder.Entity<BaoCao>(entity =>
        {
            entity.HasKey(e => e.IdBaoCao);

            entity.ToTable("BaoCao");

            entity.Property(e => e.IdBaoCao)
                .ValueGeneratedNever()
                .HasColumnName("ID_BaoCao");
            entity.Property(e => e.DoanhThu).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoTenAdmin).HasMaxLength(30);
            entity.Property(e => e.LoaiBaoCao).HasMaxLength(50);
            entity.Property(e => e.NgayBaoCao).HasColumnType("datetime");
            entity.Property(e => e.NgayCapNhap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.BaoCaos)
                .HasForeignKey(d => d.HoTenAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BaoCao_Admins");
        });

        modelBuilder.Entity<ChatLieu>(entity =>
        {
            entity.HasKey(e => e.IdChatLieu);

            entity.ToTable("ChatLieu");

            entity.Property(e => e.IdChatLieu)
                .ValueGeneratedNever()
                .HasColumnName("ID_ChatLieu");
            entity.Property(e => e.ChatLieu1)
                .HasMaxLength(30)
                .HasColumnName("ChatLieu");
        });

        modelBuilder.Entity<DanhGiaNhanXet>(entity =>
        {
            entity.HasKey(e => e.IdDanhGiaNhanXet);

            entity.ToTable("DanhGia_NhanXet");

            entity.Property(e => e.IdDanhGiaNhanXet)
                .ValueGeneratedNever()
                .HasColumnName("ID_DanhGia_NhanXet");
            entity.Property(e => e.HoTen).HasMaxLength(30);
            entity.Property(e => e.IdDonHoanThanh).HasColumnName("ID_Don_Hoan_Thanh");
            entity.Property(e => e.NoiDung).HasMaxLength(30);

            entity.HasOne(d => d.IdDonHoanThanhNavigation).WithMany(p => p.DanhGiaNhanXets)
                .HasForeignKey(d => d.IdDonHoanThanh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DanhGia_NhanXet_Don_Hoan_Thanh");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.IdDonHang);

            entity.ToTable("DonHang");

            entity.Property(e => e.IdDonHang)
                .ValueGeneratedNever()
                .HasColumnName("ID_Don_Hang");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_NhanVien");
        });

        modelBuilder.Entity<DonHangThanhToan>(entity =>
        {
            entity.HasKey(e => e.IdDonHangThanhToan);

            entity.ToTable("Don_Hang_Thanh_Toan");

            entity.Property(e => e.IdDonHangThanhToan)
                .ValueGeneratedNever()
                .HasColumnName("ID_Don_Hang_Thanh_Toan");
            entity.Property(e => e.IdDonHang).HasColumnName("ID_Don_Hang");
            entity.Property(e => e.IdThanhToan).HasColumnName("ID_ThanhToan");
            entity.Property(e => e.KieuTt)
                .HasMaxLength(50)
                .HasColumnName("KieuTT");
            entity.Property(e => e.NgayTt).HasColumnName("NgayTT");
            entity.Property(e => e.Status).HasMaxLength(30);

            entity.HasOne(d => d.IdDonHangNavigation).WithMany(p => p.DonHangThanhToans)
                .HasForeignKey(d => d.IdDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Don_Hang_Thanh_Toan_Don_Hang");

            entity.HasOne(d => d.IdThanhToanNavigation).WithMany(p => p.DonHangThanhToans)
                .HasForeignKey(d => d.IdThanhToan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Don_Hang_Thanh_Toan_ThanhToan");
        });

        modelBuilder.Entity<DonHoanThanh>(entity =>
        {
            entity.HasKey(e => e.IdDonHoanThanh);

            entity.ToTable("Don_Hoan_Thanh");

            entity.Property(e => e.IdDonHoanThanh)
                .ValueGeneratedNever()
                .HasColumnName("ID_Don_Hoan_Thanh");
            entity.Property(e => e.IdDonHangThanhToan)
                .HasMaxLength(30)
                .HasColumnName("ID_Don_Hang_Thanh_Toan");
        });

        modelBuilder.Entity<GiaoHang>(entity =>
        {
            entity.HasKey(e => e.IdGiaoHang);

            entity.ToTable("GiaoHang");

            entity.Property(e => e.IdGiaoHang)
                .ValueGeneratedNever()
                .HasColumnName("ID_GiaoHang");
            entity.Property(e => e.IdDonHang).HasColumnName("ID_Don_Hang");
            entity.Property(e => e.IdThanhToan).HasColumnName("ID_ThanhToan");
            entity.Property(e => e.NgayCapNhap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayPhanCongGiaoHang)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ThoiGianDuKienGiaoHang).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianThucTeGiaoHang).HasColumnType("datetime");
            entity.Property(e => e.TrangThaiGiaoHang).HasMaxLength(50);

            entity.HasOne(d => d.IdDonHangNavigation).WithMany(p => p.GiaoHangs)
                .HasForeignKey(d => d.IdDonHang)
                .HasConstraintName("FK_GiaoHang_DonHang");

            entity.HasOne(d => d.IdThanhToanNavigation).WithMany(p => p.GiaoHangs)
                .HasForeignKey(d => d.IdThanhToan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiaoHang_ThanhToan");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.IdGioHang);

            entity.ToTable("Gio_Hang");

            entity.Property(e => e.IdGioHang)
                .ValueGeneratedNever()
                .HasColumnName("ID_Gio_Hang");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gio_Hang_User_KhachHang");
        });

        modelBuilder.Entity<GioHangChiTiet>(entity =>
        {
            entity.HasKey(e => e.IdGioHangChiTiet);

            entity.ToTable("Gio_Hang_Chi_Tiet");

            entity.Property(e => e.IdGioHangChiTiet)
                .ValueGeneratedNever()
                .HasColumnName("ID_Gio_Hang_Chi_Tiet");
            entity.Property(e => e.IdGioHang).HasColumnName("ID_Gio_Hang");
            entity.Property(e => e.IdSpct).HasColumnName("ID_Spct");
            entity.Property(e => e.MaKm).HasColumnName("Ma_Km");

            entity.HasOne(d => d.IdGioHangNavigation).WithMany(p => p.GioHangChiTiets)
                .HasForeignKey(d => d.IdGioHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gio_Hang_Chi_Tiet_GioHang");

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.GioHangChiTiets)
                .HasForeignKey(d => d.IdSpct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gio_Hang_Chi_Tiet_SanPhamChiTiet");

            entity.HasOne(d => d.MaKmNavigation).WithMany(p => p.GioHangChiTiets)
                .HasForeignKey(d => d.MaKm)
                .HasConstraintName("FK_Gio_Hang_Chi_Tiet_KhuyenMai");
        });

        modelBuilder.Entity<HangSx>(entity =>
        {
            entity.HasKey(e => e.IdHang);

            entity.ToTable("HangSX");

            entity.Property(e => e.IdHang)
                .ValueGeneratedNever()
                .HasColumnName("ID_Hang");
            entity.Property(e => e.HangSx1)
                .HasMaxLength(30)
                .HasColumnName("HangSX");
        });

        modelBuilder.Entity<HoTroKhachHang>(entity =>
        {
            entity.HasKey(e => e.IdHoTroKhachHang);

            entity.ToTable("HoTroKhachHang");

            entity.Property(e => e.IdHoTroKhachHang)
                .ValueGeneratedNever()
                .HasColumnName("ID_HoTroKhachHang");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.LoaiHt)
                .HasMaxLength(50)
                .HasColumnName("LoaiHT");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.PtlienLac)
                .HasMaxLength(50)
                .HasColumnName("PTLienLac");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.HoTroKhachHangs)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoTroKhachHang_User_KhachHang");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoTroKhachHangs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoTroKhachHang_NhanVien");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.IdHoaDon);

            entity.ToTable("HoaDon");

            entity.Property(e => e.IdHoaDon)
                .ValueGeneratedNever()
                .HasColumnName("ID_HoaDon");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_User_KhachHang");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => new { e.Email, e.HoTen });

            entity.ToTable("KhachHang");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(30);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTenAdmin).HasMaxLength(30);
            entity.Property(e => e.LoaiKhachHang).HasMaxLength(20);
            entity.Property(e => e.NgayDangKy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Sdt).HasMaxLength(10);
            entity.Property(e => e.TrangThai).HasMaxLength(10);
            entity.Property(e => e.UserName).HasMaxLength(30);

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.HoTenAdmin)
                .HasConstraintName("FK_KhachHang_Admins");
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKm);

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKm)
                .ValueGeneratedNever()
                .HasColumnName("Ma_Km");
            entity.Property(e => e.GiaTriKm).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HoTenAdmin).HasMaxLength(30);
            entity.Property(e => e.LoaiKm).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(300);
            entity.Property(e => e.NgayBd).HasColumnType("datetime");
            entity.Property(e => e.NgayKt).HasColumnType("datetime");
            entity.Property(e => e.TenKm).HasMaxLength(100);

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.KhuyenMais)
                .HasForeignKey(d => d.HoTenAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KhuyenMai_Admins");
        });

        modelBuilder.Entity<LichSuDonHang>(entity =>
        {
            entity.HasKey(e => e.IdLichSuDonHang);

            entity.ToTable("LichSuDonHang");

            entity.Property(e => e.IdLichSuDonHang)
                .ValueGeneratedNever()
                .HasColumnName("ID_LichSuDonHang");
            entity.Property(e => e.IdDonHoanThanh).HasColumnName("ID_Don_Hoan_Thanh");

            entity.HasOne(d => d.IdDonHoanThanhNavigation).WithMany(p => p.LichSuDonHangs)
                .HasForeignKey(d => d.IdDonHoanThanh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LichSuDonHang_Don_Hoan_Thanh");
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.HasKey(e => e.IdMauSac);

            entity.ToTable("MauSac");

            entity.Property(e => e.IdMauSac)
                .ValueGeneratedNever()
                .HasColumnName("ID_MauSac");
            entity.Property(e => e.MauSac1)
                .HasMaxLength(30)
                .HasColumnName("MauSac");
        });

        modelBuilder.Entity<Ncc>(entity =>
        {
            entity.HasKey(e => e.MaNcc);

            entity.ToTable("NCC");

            entity.Property(e => e.MaNcc)
                .ValueGeneratedNever()
                .HasColumnName("Ma_NCC");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.HoTenAdmin).HasMaxLength(30);
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.NameNcc)
                .HasMaxLength(30)
                .HasColumnName("NameNCC");
            entity.Property(e => e.NameNlh)
                .HasMaxLength(30)
                .HasColumnName("NameNLH");
            entity.Property(e => e.QuocGia).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
            entity.Property(e => e.ThanhPho).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(30);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.Nccs)
                .HasForeignKey(d => d.HoTenAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NCC_Admins");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv);

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .ValueGeneratedNever()
                .HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTenAdmin).HasMaxLength(30);
            entity.Property(e => e.HoTenNv)
                .HasMaxLength(30)
                .HasColumnName("HoTenNV");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.NgayVaoLam)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Sdt).HasMaxLength(20);
            entity.Property(e => e.TrangThai).HasMaxLength(30);
            entity.Property(e => e.UserName).HasMaxLength(30);

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.HoTenAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_Admins");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_Users");
        });

        modelBuilder.Entity<PhuongThucThanhToan>(entity =>
        {
            entity.HasKey(e => e.IdPhuongThucThanhToan);

            entity.ToTable("PhuongThucThanhToan");

            entity.Property(e => e.IdPhuongThucThanhToan)
                .ValueGeneratedNever()
                .HasColumnName("ID_PhuongThucThanhToan");
            entity.Property(e => e.PhuongThuc).HasMaxLength(50);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.IdSp);

            entity.ToTable("SanPham");

            entity.Property(e => e.IdSp)
                .ValueGeneratedNever()
                .HasColumnName("ID_Sp");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("Ten_Sp");
            entity.Property(e => e.TrangThai).HasMaxLength(255);
        });

        modelBuilder.Entity<SanPhamChiTiet>(entity =>
        {
            entity.HasKey(e => e.IdSpct);

            entity.ToTable("SanPhamChiTiet");

            entity.Property(e => e.IdSpct)
                .ValueGeneratedNever()
                .HasColumnName("ID_Spct");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(30);
            entity.Property(e => e.DanhGia).HasMaxLength(30);
            entity.Property(e => e.IdChatLieu).HasColumnName("ID_ChatLieu");
            entity.Property(e => e.IdHang).HasColumnName("ID_Hang");
            entity.Property(e => e.IdMauSac).HasColumnName("ID_MauSac");
            entity.Property(e => e.IdSize).HasColumnName("ID_Size");
            entity.Property(e => e.IdSp).HasColumnName("ID_Sp");
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenSp).HasMaxLength(30);

            entity.HasOne(d => d.IdChatLieuNavigation).WithMany(p => p.SanPhamChiTiets)
                .HasForeignKey(d => d.IdChatLieu)
                .HasConstraintName("FK_SanPhamChiTiet_ChatLieu");

            entity.HasOne(d => d.IdHangNavigation).WithMany(p => p.SanPhamChiTiets)
                .HasForeignKey(d => d.IdHang)
                .HasConstraintName("FK_SanPhamChiTiet_HangSX");

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.SanPhamChiTiets)
                .HasForeignKey(d => d.IdSize)
                .HasConstraintName("FK_SanPhamChiTiet_Size");

            entity.HasOne(d => d.IdSpNavigation).WithMany(p => p.SanPhamChiTiets)
                .HasForeignKey(d => d.IdSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPhamChiTiet_SanPham");
        });

        modelBuilder.Entity<SanPhamMua>(entity =>
        {
            entity.HasKey(e => e.IdSpMua);

            entity.ToTable("SanPham_Mua");

            entity.Property(e => e.IdSpMua)
                .ValueGeneratedNever()
                .HasColumnName("ID_SP_Mua");
            entity.Property(e => e.IdSpct).HasColumnName("ID_Spct");
            entity.Property(e => e.MaKm).HasColumnName("Ma_Km");
            entity.Property(e => e.UserName).HasMaxLength(30);

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.SanPhamMuas)
                .HasForeignKey(d => d.IdSpct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_Mua_SanPhamChiTiet");

            entity.HasOne(d => d.MaKmNavigation).WithMany(p => p.SanPhamMuas)
                .HasForeignKey(d => d.MaKm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_Mua_KhuyenMai");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.SanPhamMuas)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_Mua_Users");
        });

        modelBuilder.Entity<SanPhamThanhToan>(entity =>
        {
            entity.HasKey(e => e.IdSpThanhToan);

            entity.ToTable("SanPham_ThanhToan");

            entity.Property(e => e.IdSpThanhToan)
                .ValueGeneratedNever()
                .HasColumnName("ID_Sp_ThanhToan");
            entity.Property(e => e.IdSpct).HasColumnName("ID_Spct");
            entity.Property(e => e.IdThanhToan).HasColumnName("ID_ThanhToan");

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.SanPhamThanhToans)
                .HasForeignKey(d => d.IdSpct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_ThanhToan_SanPhamChiTiet");

            entity.HasOne(d => d.IdThanhToanNavigation).WithMany(p => p.SanPhamThanhToans)
                .HasForeignKey(d => d.IdThanhToan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_ThanhToan_ThanhToan");
        });

        modelBuilder.Entity<SanPhamYeuThich>(entity =>
        {
            entity.HasKey(e => e.IdSpyt);

            entity.ToTable("SanPhamYeuThich");

            entity.Property(e => e.IdSpyt)
                .ValueGeneratedNever()
                .HasColumnName("ID_Spyt");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.SanPhamYeuThiches)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPhamYeuThich_User_KhachHang");
        });

        modelBuilder.Entity<SanPhamYeuThichChiTiet>(entity =>
        {
            entity.HasKey(e => e.IdSpytChiTiet);

            entity.ToTable("SanPhamYeuThichChiTiet");

            entity.Property(e => e.IdSpytChiTiet)
                .ValueGeneratedNever()
                .HasColumnName("ID_Spyt_Chi_Tiet");
            entity.Property(e => e.IdSpct).HasColumnName("ID_Spct");
            entity.Property(e => e.IdSpyt).HasColumnName("ID_Spyt");

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.SanPhamYeuThichChiTiets)
                .HasForeignKey(d => d.IdSpct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPhamYeuThichChiTiet_SanPhamChiTiet");

            entity.HasOne(d => d.IdSpytNavigation).WithMany(p => p.SanPhamYeuThichChiTiets)
                .HasForeignKey(d => d.IdSpyt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPhamYeuThichChiTiet_SanPhamYeuThich");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.IdSize);

            entity.ToTable("Size");

            entity.Property(e => e.IdSize)
                .ValueGeneratedNever()
                .HasColumnName("ID_Size");
            entity.Property(e => e.Size1)
                .HasMaxLength(30)
                .HasColumnName("Size");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.IdThanhToan);

            entity.ToTable("ThanhToan");

            entity.Property(e => e.IdThanhToan)
                .ValueGeneratedNever()
                .HasColumnName("ID_ThanhToan");
            entity.Property(e => e.DiaChi).HasMaxLength(30);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(20);
            entity.Property(e => e.IdHoaDon).HasColumnName("ID_HoaDon");
            entity.Property(e => e.IdPhuongThucThanhToan).HasColumnName("ID_PhuongThucThanhToan");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");
            entity.Property(e => e.Status).HasMaxLength(30);

            entity.HasOne(d => d.IdHoaDonNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.IdHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThanhToan_HoaDon");

            entity.HasOne(d => d.IdPhuongThucThanhToanNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.IdPhuongThucThanhToan)
                .HasConstraintName("FK_ThanhToan_PT_TT");
        });

        modelBuilder.Entity<TonKho>(entity =>
        {
            entity.HasKey(e => e.IdTonKho);

            entity.ToTable("TonKho");

            entity.Property(e => e.IdTonKho)
                .ValueGeneratedNever()
                .HasColumnName("ID_TonKho");
            entity.Property(e => e.IdSpct).HasColumnName("ID_Spct");
            entity.Property(e => e.NgayCapNhap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.TonKhos)
                .HasForeignKey(d => d.IdSpct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TonKho_SanPhamChiTiet");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.Property(e => e.UserName).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(30);
        });

        modelBuilder.Entity<UserKhachHang>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User_KhachHang");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("ID_User");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(30);
            entity.Property(e => e.UserName).HasMaxLength(30);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.UserKhachHangs)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_KhachHang_Users");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.UserKhachHangs)
                .HasForeignKey(d => new { d.Email, d.HoTen })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_KhachHang_KhachHang");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.IdVideo);

            entity.ToTable("Video");

            entity.Property(e => e.IdVideo)
                .ValueGeneratedNever()
                .HasColumnName("ID_Video");
            entity.Property(e => e.IdDanhGiaNhanXet).HasColumnName("ID_DanhGia_NhanXet");
            entity.Property(e => e.Video1)
                .HasMaxLength(50)
                .HasColumnName("Video");

            entity.HasOne(d => d.IdDanhGiaNhanXetNavigation).WithMany(p => p.Videos)
                .HasForeignKey(d => d.IdDanhGiaNhanXet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Video_DanhGia_NhanXet");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
