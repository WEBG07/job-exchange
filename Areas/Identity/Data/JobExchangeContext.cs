﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobExchange.Models
{
    public partial class JobExchangeContext : IdentityDbContext<IdentityUser>
    {
        public JobExchangeContext()
        {
        }

        public JobExchangeContext(DbContextOptions<JobExchangeContext> options)
            : base(options)
        {
        }
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
        public virtual DbSet<SaveRecruitment> SaveRecruitments { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Sử dụng DeleteBehavior.Restrict thay cho mặc định là DeleteBehavior.Cascade
            // Khi có dữ liệu bảng phụ không cho xóa bảng chính

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
