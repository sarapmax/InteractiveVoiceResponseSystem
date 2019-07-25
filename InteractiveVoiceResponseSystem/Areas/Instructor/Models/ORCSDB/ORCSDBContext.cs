using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.ORCSDB
{
    public partial class ORCSDBContext : DbContext
    {
        public ORCSDBContext()
        {
        }

        public ORCSDBContext(DbContextOptions<ORCSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrcsMemberCourseTeacher> OrcsMemberCourseTeacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=140.116.72.21;Database=ORCSDB;User Id=Max;Password=IamMax");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<OrcsMemberCourseTeacher>(entity =>
            {
                entity.HasKey(e => new { e.CUserId, e.IGroupId });

                entity.ToTable("ORCS_MemberCourseTeacher");

                entity.Property(e => e.CUserId)
                    .HasColumnName("cUserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IGroupId).HasColumnName("iGroupID");
            });
        }
    }
}
