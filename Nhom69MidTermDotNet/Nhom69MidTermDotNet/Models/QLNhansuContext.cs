using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Nhom69MidTermDotNet.Models
{
    public partial class QLNhansuContext : DbContext
    {
        public QLNhansuContext()
        {
        }

        public QLNhansuContext(DbContextOptions<QLNhansuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BangChamCong> BangChamCong { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhongBan> PhongBan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9GM6R5U\\SQLEXPRESS; Database=QLNhansu;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BangChamCong>(entity =>
            {
                entity.HasKey(e => e.MaCc);

                entity.Property(e => e.MaCc).HasColumnName("MaCC");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.BangChamCong)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("fk1_PhongBan");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.Diachi).HasMaxLength(255);

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LuongCb).HasColumnName("LuongCB");

                entity.Property(e => e.MaPb).HasColumnName("MaPB");

                entity.HasOne(d => d.MaPbNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.MaPb)
                    .HasConstraintName("fk_PhongBan");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.MaPb);

                entity.Property(e => e.MaPb).HasColumnName("MaPB");

                entity.Property(e => e.TenPb)
                    .IsRequired()
                    .HasColumnName("TenPB")
                    .HasMaxLength(30);
            });
        }
    }
}
