using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebCongNghe.Models.Entities
{
    public partial class ShopCongNgheContext : DbContext
    {
        public ShopCongNgheContext()
        {
        }

        public ShopCongNgheContext(DbContextOptions<ShopCongNgheContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DanhMucCon> DanhMucCons { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Nsx> Nsxes { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-87B5C0TG\\SQLEXPRESS;Initial Catalog=ShopCongNghe;Persist Security Info=True;User ID=sa;Password=Minhquang2001@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.MaAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Tk)
                    .HasMaxLength(50)
                    .HasColumnName("TK")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDm);

                entity.ToTable("DanhMuc");

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.TenDm)
                    .HasMaxLength(10)
                    .HasColumnName("TenDM")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<DanhMucCon>(entity =>
            {
                entity.HasKey(e => e.MaDmcon);

                entity.ToTable("DanhMucCon");

                entity.Property(e => e.MaDmcon).HasColumnName("MaDMCon");

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.TenDmcon)
                    .HasMaxLength(100)
                    .HasColumnName("TenDMCon");

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.DanhMucCons)
                    .HasForeignKey(d => d.MaDm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DanhMucCon_DanhMuc");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DonHang");

                entity.Property(e => e.MaDh)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MaDH");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_DonHang_KhachHang1");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_DonHang_SanPham1");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.MaGh)
                    .HasName("PK_DonHang");

                entity.ToTable("GioHang");

                entity.Property(e => e.MaGh).HasColumnName("MaGH");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_DonHang_KhachHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_DonHang_SanPham");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.AnhDaiDien).HasMaxLength(255);

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.GioiTinh).HasMaxLength(3);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Nsx>(entity =>
            {
                entity.HasKey(e => e.MaNsx);

                entity.ToTable("NSX");

                entity.Property(e => e.MaNsx).HasColumnName("MaNSX");

                entity.Property(e => e.TenNsx)
                    .HasMaxLength(200)
                    .HasColumnName("TenNSX");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.Anh1).HasMaxLength(300);

                entity.Property(e => e.Anh2).HasMaxLength(300);

                entity.Property(e => e.Anh3).HasMaxLength(300);

                entity.Property(e => e.Anh4).HasMaxLength(300);

                entity.Property(e => e.ChiTiet).HasMaxLength(1000);

                entity.Property(e => e.MaDmcon).HasColumnName("MaDMCon");

                entity.Property(e => e.MaNsx).HasColumnName("MaNSX");

                entity.Property(e => e.Mau).HasMaxLength(20);

                entity.Property(e => e.NgayCapNhat).HasColumnType("date");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(300)
                    .HasColumnName("TenSP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
