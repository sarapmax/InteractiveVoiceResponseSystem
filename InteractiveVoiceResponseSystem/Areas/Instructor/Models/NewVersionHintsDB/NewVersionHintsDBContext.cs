using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB
{
    public partial class NewVersionHintsDBContext : DbContext
    {
        public NewVersionHintsDBContext()
        {
        }

        public NewVersionHintsDBContext(DbContextOptions<NewVersionHintsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ivrsprofession> Ivrsprofession { get; set; }
        public virtual DbSet<IvrsselectionQuestion> IvrsselectionQuestion { get; set; }
        public virtual DbSet<IvrsvpAnswer> IvrsvpAnswers { get; set; }
        public virtual DbSet<QuestionGroupTree> QuestionGroupTree { get; set; }
        public virtual DbSet<QuestionIndex> QuestionIndex { get; set; }
        public virtual DbSet<QuestionList> QuestionList { get; set; }
        public virtual DbSet<QuestionMode> QuestionMode { get; set; }
        public virtual DbSet<QuestionSelectionIndex> QuestionSelectionIndex { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=140.116.72.21;Database=NewVersionHintsDB;User Id=Max;Password=IamMax");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Ivrsprofession>(entity =>
            {
                entity.HasKey(e => e.CProfessionId);

                entity.ToTable("IVRSProfession");

                entity.Property(e => e.CProfessionId).HasColumnName("cProfessionID");

                entity.Property(e => e.CCourseId)
                    .HasColumnName("cCourseID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NodeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IvrsselectionQuestion>(entity =>
            {
                entity.HasKey(e => e.CSelectionQuestionId);

                entity.ToTable("IVRSSelectionQuestion");

                entity.Property(e => e.CSelectionQuestionId).HasColumnName("cSelectionQuestionID");

                entity.Property(e => e.CNodeId)
                    .HasColumnName("cNodeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CQid)
                    .HasColumnName("cQID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IvrsvpAnswer>(entity =>
            {
                entity.HasKey(e => e.CVPAnswerID);

                entity.ToTable("IVRSVPAnswer");
                
                entity.Property(e => e.CVPAnswerID).HasColumnName("cVPAnswerID");

                entity.Property(e => e.CSelectionQuestionID)
                    .HasColumnName("cSelectionQuestionID");

                entity.Property(e => e.Answer)
                    .HasColumnName("Answer")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionGroupTree>(entity =>
            {
                entity.HasKey(e => new { e.CNodeId, e.CParentId })
                    .HasName("PK_QuestionGroupTree_1");

                entity.Property(e => e.CNodeId)
                    .HasColumnName("cNodeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CParentId)
                    .HasColumnName("cParentID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CAuthor)
                    .HasColumnName("cAuthor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNodeName)
                    .HasColumnName("cNodeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CNodeType)
                    .HasColumnName("cNodeType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ISerialNum)
                    .HasColumnName("iSerialNum")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.QId)
                    .HasColumnName("qId")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<QuestionIndex>(entity =>
            {
                entity.HasKey(e => e.CQid)
                    .HasName("PK_QuestionIndex_1");

                entity.Property(e => e.CQid)
                    .HasColumnName("cQID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CAnswer)
                    .HasColumnName("cAnswer")
                    .HasColumnType("text");

                entity.Property(e => e.CKeyWords)
                    .HasColumnName("cKeyWords")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CQuestion)
                    .HasColumnName("cQuestion")
                    .HasColumnType("text");

                entity.Property(e => e.SLevel).HasColumnName("sLevel");
            });

            modelBuilder.Entity<QuestionList>(entity =>
            {
                entity.HasKey(e => e.QId);

                entity.Property(e => e.QId)
                    .HasColumnName("qId")
                    .ValueGeneratedNever();

                entity.Property(e => e.IFeatureSetId).HasColumnName("iFeatureSetID");

                entity.Property(e => e.QName)
                    .IsRequired()
                    .HasColumnName("qName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QRootName)
                    .HasColumnName("qRootName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionMode>(entity =>
            {
                entity.HasKey(e => e.CQid);

                entity.Property(e => e.CQid)
                    .HasColumnName("cQID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CDivisionId)
                    .HasColumnName("cDivisionID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CPaperId)
                    .HasColumnName("cPaperID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CQuestionGroupId)
                    .HasColumnName("cQuestionGroupID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CQuestionGroupName)
                    .HasColumnName("cQuestionGroupName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CQuestionMode)
                    .HasColumnName("cQuestionMode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CQuestionType)
                    .HasColumnName("cQuestionType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SimilarId)
                    .HasColumnName("similarID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionSelectionIndex>(entity =>
            {
                entity.HasKey(e => e.CSelectionId);

                entity.Property(e => e.CSelectionId)
                    .HasColumnName("cSelectionID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BCaseSelect).HasColumnName("bCaseSelect");

                entity.Property(e => e.CQid)
                    .IsRequired()
                    .HasColumnName("cQID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CResponse)
                    .HasColumnName("cResponse")
                    .HasColumnType("text");

                entity.Property(e => e.CSelection)
                    .HasColumnName("cSelection")
                    .HasColumnType("text");

                entity.Property(e => e.SSeq).HasColumnName("sSeq");
            });
        }
    }
}
