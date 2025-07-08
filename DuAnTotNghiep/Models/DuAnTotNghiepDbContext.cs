using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Models;

public partial class DuAnTotNghiepDbContext : DbContext
{
    public DuAnTotNghiepDbContext()
    {
    }

    public DuAnTotNghiepDbContext(DbContextOptions<DuAnTotNghiepDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AnhSp> AnhSps { get; set; }

    public virtual DbSet<BaoCao> BaoCaos { get; set; }

    public virtual DbSet<ChatLieu> ChatLieus { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<DonHangThanhToan> DonHangThanhToans { get; set; }

    public virtual DbSet<GiaoHang> GiaoHangs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HangSx> HangSxes { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<Ncc> Nccs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; }

    public virtual DbSet<SanPhamThanhToan> SanPhamThanhToans { get; set; }

    public virtual DbSet<SanPhamYeuThich> SanPhamYeuThiches { get; set; }

    public virtual DbSet<SanPhamYeuThichChiTiet> SanPhamYeuThichChiTiets { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<TonKho> TonKhos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserKhachHang> UserKhachHangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4SRBB78\\MSSQLSERVER01;Database=Du_an_tot_nghiep_2025;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Admins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admins_Users");
        });

        modelBuilder.Entity<AnhSp>(entity =>
        {
            entity.Property(e => e.IdAnhSp).ValueGeneratedNever();

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.AnhSps).HasConstraintName("FK_AnhSp_SanPhamChiTiet");
        });

        modelBuilder.Entity<BaoCao>(entity =>
        {
            entity.Property(e => e.IdBaoCao).ValueGeneratedNever();
            entity.Property(e => e.NgayCapNhap).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.BaoCaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BaoCao_Admins");
        });

        modelBuilder.Entity<ChatLieu>(entity =>
        {
            entity.Property(e => e.IdChatLieu).ValueGeneratedNever();
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.Property(e => e.IdDonHang).ValueGeneratedNever();

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.DonHangs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_NhanVien");
        });

        modelBuilder.Entity<DonHangThanhToan>(entity =>
        {
            entity.Property(e => e.IdDonHangThanhToan).ValueGeneratedNever();

            entity.HasOne(d => d.IdDonHangNavigation).WithMany(p => p.DonHangThanhToans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Don_Hang_Thanh_Toan_Don_Hang");

            entity.HasOne(d => d.IdThanhToanNavigation).WithMany(p => p.DonHangThanhToans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Don_Hang_Thanh_Toan_ThanhToan");
        });

        modelBuilder.Entity<GiaoHang>(entity =>
        {
            entity.Property(e => e.IdGiaoHang).ValueGeneratedNever();
            entity.Property(e => e.NgayCapNhap).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayPhanCongGiaoHang).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdDonHangNavigation).WithMany(p => p.GiaoHangs).HasConstraintName("FK_GiaoHang_DonHang");

            entity.HasOne(d => d.IdThanhToanNavigation).WithMany(p => p.GiaoHangs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GiaoHang_ThanhToan");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.Property(e => e.IdGioHang).ValueGeneratedNever();

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.GioHangs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gio_Hang_User_KhachHang");
        });

        modelBuilder.Entity<HangSx>(entity =>
        {
            entity.Property(e => e.IdHang).ValueGeneratedNever();
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.Property(e => e.IdHoaDon).ValueGeneratedNever();

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.HoaDons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_User_KhachHang");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.Property(e => e.NgayDangKy).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.KhachHangs).HasConstraintName("FK_KhachHang_Admins");
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.Property(e => e.MaKm).ValueGeneratedNever();

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.KhuyenMais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KhuyenMai_Admins");
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.Property(e => e.IdMauSac).ValueGeneratedNever();
        });

        modelBuilder.Entity<Ncc>(entity =>
        {
            entity.Property(e => e.MaNcc).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.Nccs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NCC_Admins");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.Property(e => e.MaNv).ValueGeneratedNever();
            entity.Property(e => e.NgayVaoLam).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.HoTenAdminNavigation).WithMany(p => p.NhanViens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_Admins");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.NhanViens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_Users");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.Property(e => e.IdSp).ValueGeneratedNever();
        });

        modelBuilder.Entity<SanPhamChiTiet>(entity =>
        {
            entity.Property(e => e.IdSpct).ValueGeneratedNever();

            entity.HasOne(d => d.IdChatLieuNavigation).WithMany(p => p.SanPhamChiTiets).HasConstraintName("FK_SanPhamChiTiet_ChatLieu");

            entity.HasOne(d => d.IdHangNavigation).WithMany(p => p.SanPhamChiTiets).HasConstraintName("FK_SanPhamChiTiet_HangSX");

            entity.HasOne(d => d.IdMauSacNavigation).WithMany(p => p.SanPhamChiTiets).HasConstraintName("FK_SanPhamChiTiet_MauSac");

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.SanPhamChiTiets).HasConstraintName("FK_SanPhamChiTiet_Size");

            entity.HasOne(d => d.IdSpNavigation).WithMany(p => p.SanPhamChiTiets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPhamChiTiet_SanPham");
        });

        modelBuilder.Entity<SanPhamThanhToan>(entity =>
        {
            entity.Property(e => e.IdSpThanhToan).ValueGeneratedNever();

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.SanPhamThanhToans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_ThanhToan_SanPhamChiTiet");

            entity.HasOne(d => d.IdThanhToanNavigation).WithMany(p => p.SanPhamThanhToans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_ThanhToan_ThanhToan");
        });

        modelBuilder.Entity<SanPhamYeuThich>(entity =>
        {
            entity.Property(e => e.IdSpyt).ValueGeneratedNever();

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.SanPhamYeuThiches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPhamYeuThich_User_KhachHang");
        });

        modelBuilder.Entity<SanPhamYeuThichChiTiet>(entity =>
        {
            entity.Property(e => e.IdSpytChiTiet).ValueGeneratedNever();

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.SanPhamYeuThichChiTiets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPhamYeuThichChiTiet_SanPhamChiTiet");

            entity.HasOne(d => d.IdSpytNavigation).WithMany(p => p.SanPhamYeuThichChiTiets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPhamYeuThichChiTiet_SanPhamYeuThich");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.Property(e => e.IdSize).ValueGeneratedNever();
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.Property(e => e.IdThanhToan).ValueGeneratedNever();

            entity.HasOne(d => d.IdHoaDonNavigation).WithMany(p => p.ThanhToans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThanhToan_HoaDon");
        });

        modelBuilder.Entity<TonKho>(entity =>
        {
            entity.Property(e => e.IdTonKho).ValueGeneratedNever();
            entity.Property(e => e.NgayCapNhap).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdSpctNavigation).WithMany(p => p.TonKhos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TonKho_SanPhamChiTiet");
        });

        modelBuilder.Entity<UserKhachHang>(entity =>
        {
            entity.Property(e => e.IdUser).ValueGeneratedNever();

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.UserKhachHangs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_KhachHang_Users");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.UserKhachHangs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_KhachHang_KhachHang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
