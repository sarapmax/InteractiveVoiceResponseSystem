using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.MLASDB
{
    public partial class MLASDBContext : DbContext
    {
        public MLASDBContext()
        {
        }

        public MLASDBContext(DbContextOptions<MLASDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MlasCourseInfo> MlasCourseInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=140.116.72.21;Database=MLASDB;User Id=Max;Password=IamMax");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<MlasCourseInfo>(entity =>
            {
                entity.HasKey(e => new { e.CCourseId, e.CCourseName });

                entity.ToTable("MLAS_CourseInfo");

                entity.Property(e => e.CCourseId)
                    .HasColumnName("cCourseID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CCourseName)
                    .HasColumnName("cCourseName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CCourseBelongUnitId)
                    .HasColumnName("cCourseBelongUnitID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CCourseBelongUnitName)
                    .HasColumnName("cCourseBelongUnitName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CCourseDescription)
                    .HasColumnName("cCourseDescription")
                    .HasColumnType("text");

                entity.Property(e => e.CCourseDivision)
                    .HasColumnName("cCourseDivision")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CCourseSubDivision)
                    .HasColumnName("cCourseSubDivision")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CCourseType)
                    .HasColumnName("cCourseType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CCourseViewMode)
                    .HasColumnName("cCourseViewMode")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
