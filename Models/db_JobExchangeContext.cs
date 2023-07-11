using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobExchange.Models
{
    public partial class db_JobExchangeContext : DbContext
    {
        public db_JobExchangeContext()
        {
        }

        public db_JobExchangeContext(DbContextOptions<db_JobExchangeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Award> Awards { get; set; } = null!;
        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        public virtual DbSet<CandidateRecruitment> CandidateRecruitments { get; set; } = null!;
        public virtual DbSet<Certification> Certifications { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Experience> Experiences { get; set; } = null!;
        public virtual DbSet<Industry> Industries { get; set; } = null!;
        public virtual DbSet<Interest> Interests { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Recruitment> Recruitments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SaveRecruitment> SaveRecruitments { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__RoleID__267ABA7A");
            });

            modelBuilder.Entity<Award>(entity =>
            {
                entity.ToTable("Award");

                entity.Property(e => e.AwardId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AwardID");

                entity.Property(e => e.AwardName).HasMaxLength(255);

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Organization).HasMaxLength(255);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Awards)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Award__Candidate__5535A963");
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Candidate__Accou__398D8EEE");
            });

            modelBuilder.Entity<CandidateRecruitment>(entity =>
            {
                entity.HasKey(e => new { e.RecruitmentId, e.CandidateId })
                    .HasName("PK__Candidat__34CF3334F3A5EDBA");

                entity.ToTable("CandidateRecruitment");

                entity.Property(e => e.RecruitmentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RecruitmentID");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.ApplicationStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UrlCv)
                    .IsUnicode(false)
                    .HasColumnName("UrlCV");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidateRecruitments)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__Candi__52593CB8");

                entity.HasOne(d => d.Recruitment)
                    .WithMany(p => p.CandidateRecruitments)
                    .HasForeignKey(d => d.RecruitmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__Recru__5165187F");
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("Certification");

                entity.Property(e => e.CertificationId).HasColumnName("CertificationID");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.CertificationName).HasMaxLength(255);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Organization).HasMaxLength(255);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Certifica__Candi__47DBAE45");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CompanyID");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Scale)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CoverImage).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Company__Account__4AB81AF0");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.IndustryId)
                    .HasConstraintName("FK__Company__Industr__4BAC3F29");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.EducationId).HasColumnName("EducationID");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.Major).HasMaxLength(255);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Education__Candi__3C69FB99");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience");

                entity.Property(e => e.ExperienceId).HasColumnName("ExperienceID");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Position).HasMaxLength(255);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Experienc__Candi__3F466844");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("Industry");

                entity.Property(e => e.IndustryId)
                    .ValueGeneratedNever()
                    .HasColumnName("IndustryID");

                entity.Property(e => e.IndustryName).HasMaxLength(255);
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.ToTable("Interest");

                entity.Property(e => e.InterestId).HasColumnName("InterestID");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.InterestName).HasMaxLength(255);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Interests)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Interest__Candid__44FF419A");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.ManagerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ManagerID");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Manager__Account__34C8D9D1");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.Position).HasMaxLength(255);

                entity.Property(e => e.ProjectName).HasMaxLength(255);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Project__Candida__5812160E");
            });

            modelBuilder.Entity<Recruitment>(entity =>
            {
                entity.ToTable("Recruitment");

                entity.Property(e => e.RecruitmentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RecruitmentID");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CompanyID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.GenderRequirement)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PositionLevel).HasMaxLength(50);

                entity.Property(e => e.Slug).IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.WorkType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Recruitments)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Recruitme__Compa__4E88ABD4");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SaveRecruitment>(entity =>
            {
                entity.HasKey(e => new { e.RecruitmentId, e.CandidateId })
                    .HasName("PK__SaveRecr__34CF33347210ED47");

                entity.ToTable("SaveRecruitment");

                entity.Property(e => e.RecruitmentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RecruitmentID");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.SaveRecruitments)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SaveRecru__Candi__619B8048");

                entity.HasOne(d => d.Recruitment)
                    .WithMany(p => p.SaveRecruitments)
                    .HasForeignKey(d => d.RecruitmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SaveRecru__Recru__60A75C0F");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.SkillName).HasMaxLength(255);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Skill__Candidate__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
