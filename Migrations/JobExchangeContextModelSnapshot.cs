﻿// <auto-generated />
using System;
using JobExchange.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobExchange.Migrations
{
    [DbContext(typeof(JobExchangeContext))]
    partial class JobExchangeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobExchange.Models.Award", b =>
                {
                    b.Property<string>("AwardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AwardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceivedMonth")
                        .HasColumnType("int");

                    b.Property<int?>("ReceivedYear")
                        .HasColumnType("int");

                    b.HasKey("AwardId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("JobExchange.Models.Candidate", b =>
                {
                    b.Property<string>("CandidateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CandidateId");

                    b.HasIndex("AccountId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("JobExchange.Models.CandidateRecruitment", b =>
                {
                    b.Property<int>("CandidateRecruitmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateRecruitmentId"));

                    b.Property<string>("ApplicationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CandidateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecruitmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UrlCv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CandidateRecruitmentId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("RecruitmentId");

                    b.ToTable("CandidateRecruitments");
                });

            modelBuilder.Entity("JobExchange.Models.Certification", b =>
                {
                    b.Property<int>("CertificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CertificationId"));

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CertificationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExpirationMonth")
                        .HasColumnType("int");

                    b.Property<int?>("ExpirationYear")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceivedMonth")
                        .HasColumnType("int");

                    b.Property<int?>("ReceivedYear")
                        .HasColumnType("int");

                    b.HasKey("CertificationId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("JobExchange.Models.Company", b =>
                {
                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IndustryId")
                        .HasColumnType("int");

                    b.Property<string>("Introduce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("AccountId");

                    b.HasIndex("IndustryId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("JobExchange.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationId"));

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EndMonth")
                        .HasColumnType("int");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Major")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StartMonth")
                        .HasColumnType("int");

                    b.Property<int?>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("EducationId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("JobExchange.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceId"));

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EndMonth")
                        .HasColumnType("int");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StartMonth")
                        .HasColumnType("int");

                    b.Property<int?>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("ExperienceId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("JobExchange.Models.Industry", b =>
                {
                    b.Property<int>("IndustryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndustryId"));

                    b.Property<string>("IndustryImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndustryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IndustryId");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("JobExchange.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InterestName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("JobExchange.Models.Manager", b =>
                {
                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerId");

                    b.HasIndex("AccountId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("JobExchange.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EndMonth")
                        .HasColumnType("int");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberMember")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StartMonth")
                        .HasColumnType("int");

                    b.Property<int?>("StartYear")
                        .HasColumnType("int");

                    b.Property<string>("Technology")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("JobExchange.Models.Recruitment", b =>
                {
                    b.Property<string>("RecruitmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Benefits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CandidateRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenderRequirement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HiringCount")
                        .HasColumnType("int");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecruitmentId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Recruitments");
                });

            modelBuilder.Entity("JobExchange.Models.SaveRecruitment", b =>
                {
                    b.Property<int>("SaveRecruitmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaveRecruitmentId"));

                    b.Property<string>("CandidateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecruitmentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SaveRecruitmentId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("RecruitmentId");

                    b.ToTable("SaveRecruitments");
                });

            modelBuilder.Entity("JobExchange.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JobExchange.Areas.Identity.Data.JobExchangeUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("JobExchangeUser");
                });

            modelBuilder.Entity("JobExchange.Models.Award", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("JobExchange.Models.Candidate", b =>
                {
                    b.HasOne("JobExchange.Areas.Identity.Data.JobExchangeUser", "JobExchangeUser")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobExchangeUser");
                });

            modelBuilder.Entity("JobExchange.Models.CandidateRecruitment", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId");

                    b.HasOne("JobExchange.Models.Recruitment", "Recruitment")
                        .WithMany()
                        .HasForeignKey("RecruitmentId");

                    b.Navigation("Candidate");

                    b.Navigation("Recruitment");
                });

            modelBuilder.Entity("JobExchange.Models.Certification", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("JobExchange.Models.Company", b =>
                {
                    b.HasOne("JobExchange.Areas.Identity.Data.JobExchangeUser", "JobExchangeUser")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobExchange.Models.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Industry");

                    b.Navigation("JobExchangeUser");
                });

            modelBuilder.Entity("JobExchange.Models.Education", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("JobExchange.Models.Experience", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("JobExchange.Models.Interest", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("JobExchange.Models.Manager", b =>
                {
                    b.HasOne("JobExchange.Areas.Identity.Data.JobExchangeUser", "JobExchangeUser")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobExchangeUser");
                });

            modelBuilder.Entity("JobExchange.Models.Project", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("JobExchange.Models.Recruitment", b =>
                {
                    b.HasOne("JobExchange.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobExchange.Models.SaveRecruitment", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId");

                    b.HasOne("JobExchange.Models.Recruitment", "Recruitment")
                        .WithMany()
                        .HasForeignKey("RecruitmentId");

                    b.Navigation("Candidate");

                    b.Navigation("Recruitment");
                });

            modelBuilder.Entity("JobExchange.Models.Skill", b =>
                {
                    b.HasOne("JobExchange.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
