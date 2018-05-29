﻿// <auto-generated />
using FreelanceGo_MasterV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FreelanceGoMasterV2.Migrations
{
    [DbContext(typeof(dDbContext))]
    [Migration("20180526130445_InitialCreateV4")]
    partial class InitialCreateV4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Auction", b =>
                {
                    b.Property<int>("Auction_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuctionTime");

                    b.Property<DateTime>("Date_Create");

                    b.Property<int>("Freelance_ID");

                    b.Property<int>("Price");

                    b.Property<int>("Project_ID");

                    b.HasKey("Auction_ID");

                    b.HasIndex("Freelance_ID");

                    b.HasIndex("Project_ID");

                    b.ToTable("Auction");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Company", b =>
                {
                    b.Property<int>("Company_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company_Address");

                    b.Property<string>("Company_Name")
                        .IsRequired();

                    b.Property<string>("Company_TaxID");

                    b.Property<string>("Company_Tel");

                    b.Property<DateTime>("Date_Create");

                    b.Property<DateTime>("Date_Update");

                    b.Property<bool>("DelStatus");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Facebook");

                    b.Property<string>("Fax");

                    b.Property<string>("Line");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Rating");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("imgName");

                    b.HasKey("Company_ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Employer", b =>
                {
                    b.Property<int>("Employer_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Date_Create");

                    b.Property<DateTime>("Date_Update");

                    b.Property<bool>("DelStatus");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Facebook");

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("ID_Card")
                        .IsRequired();

                    b.Property<string>("Line");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Rating");

                    b.Property<string>("TelephoneNumber");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("imgName");

                    b.HasKey("Employer_ID");

                    b.ToTable("Employer");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.EmployerRating", b =>
                {
                    b.Property<int>("Rating_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Company_ID");

                    b.Property<DateTime>("Date_Create");

                    b.Property<bool>("DelStatus");

                    b.Property<int?>("Employer_ID");

                    b.Property<int?>("Freelance_ID")
                        .IsRequired();

                    b.Property<int?>("Project_ID");

                    b.Property<int>("Score");

                    b.Property<string>("TextReview");

                    b.HasKey("Rating_ID");

                    b.HasIndex("Company_ID");

                    b.HasIndex("Employer_ID");

                    b.HasIndex("Freelance_ID");

                    b.HasIndex("Project_ID")
                        .IsUnique()
                        .HasFilter("[Project_ID] IS NOT NULL");

                    b.ToTable("EmployerRating");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Freelance", b =>
                {
                    b.Property<int>("Freelance_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Date_Create");

                    b.Property<DateTime>("Date_Update");

                    b.Property<bool>("DelStatus");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Facebook");

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("ID_Card")
                        .IsRequired();

                    b.Property<string>("ImgName");

                    b.Property<string>("Line");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Rating");

                    b.Property<string>("TelephoneNumber");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Freelance_ID");

                    b.HasIndex("UserName", "Email")
                        .IsUnique();

                    b.ToTable("Freelance");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.FreelanceRating", b =>
                {
                    b.Property<int>("Rating_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Company_ID");

                    b.Property<DateTime>("Date_Create");

                    b.Property<bool>("DelStatus");

                    b.Property<int?>("Employer_ID");

                    b.Property<int?>("Freelance_ID")
                        .IsRequired();

                    b.Property<int?>("Project_ID");

                    b.Property<int>("Score");

                    b.Property<string>("TextReview");

                    b.HasKey("Rating_ID");

                    b.HasIndex("Company_ID");

                    b.HasIndex("Employer_ID");

                    b.HasIndex("Freelance_ID");

                    b.HasIndex("Project_ID")
                        .IsUnique()
                        .HasFilter("[Project_ID] IS NOT NULL");

                    b.ToTable("FreelanceRating");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.FreelanceSkill", b =>
                {
                    b.Property<int>("FreelanceSkill_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date_Create");

                    b.Property<DateTime>("Date_Update");

                    b.Property<bool>("DelStatus");

                    b.Property<int>("Freelance_ID");

                    b.Property<int>("Skill_ID");

                    b.HasKey("FreelanceSkill_ID");

                    b.HasIndex("Freelance_ID");

                    b.HasIndex("Skill_ID");

                    b.ToTable("FreelanceSkill");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Project", b =>
                {
                    b.Property<int>("Project_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Budget");

                    b.Property<int?>("Company_ID");

                    b.Property<DateTime>("Date_Create");

                    b.Property<DateTime>("Date_Update");

                    b.Property<bool>("DelStatus");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("Employer_ID");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("FreelanceSuccessStatus");

                    b.Property<int?>("Freelance_ID");

                    b.Property<string>("ProjectName")
                        .IsRequired();

                    b.Property<int>("ProjectPrice");

                    b.Property<bool>("ProjectStatus");

                    b.Property<DateTime>("ProjectTimeOut");

                    b.Property<int>("ProjectTimelength");

                    b.Property<DateTime>("StartingDate");

                    b.Property<bool>("SuccessStatus");

                    b.Property<int>("Timelength");

                    b.HasKey("Project_ID");

                    b.HasIndex("Company_ID");

                    b.HasIndex("Employer_ID");

                    b.HasIndex("Freelance_ID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.ProjectSkill", b =>
                {
                    b.Property<int>("ProjectSkill_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date_Create");

                    b.Property<DateTime>("Date_Update");

                    b.Property<bool>("DelStatus");

                    b.Property<int>("Project_ID");

                    b.Property<int>("Skill_ID");

                    b.HasKey("ProjectSkill_ID");

                    b.HasIndex("Project_ID");

                    b.HasIndex("Skill_ID");

                    b.ToTable("ProjectSkill");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Skill", b =>
                {
                    b.Property<int>("Skill_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date_Create");

                    b.Property<DateTime>("Date_Update");

                    b.Property<bool>("DelStatus");

                    b.Property<string>("Name");

                    b.Property<string>("Skill_Description");

                    b.HasKey("Skill_ID");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Auction", b =>
                {
                    b.HasOne("FreelanceGo_MasterV2.Models.Freelance", "Freelance")
                        .WithMany("Auction")
                        .HasForeignKey("Freelance_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FreelanceGo_MasterV2.Models.Project", "Project")
                        .WithMany("Auction")
                        .HasForeignKey("Project_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.EmployerRating", b =>
                {
                    b.HasOne("FreelanceGo_MasterV2.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Company_ID");

                    b.HasOne("FreelanceGo_MasterV2.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("Employer_ID");

                    b.HasOne("FreelanceGo_MasterV2.Models.Freelance", "Freelance")
                        .WithMany()
                        .HasForeignKey("Freelance_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FreelanceGo_MasterV2.Models.Project", "Project")
                        .WithOne("EmployerRating")
                        .HasForeignKey("FreelanceGo_MasterV2.Models.EmployerRating", "Project_ID");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.FreelanceRating", b =>
                {
                    b.HasOne("FreelanceGo_MasterV2.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Company_ID");

                    b.HasOne("FreelanceGo_MasterV2.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("Employer_ID");

                    b.HasOne("FreelanceGo_MasterV2.Models.Freelance", "Freelance")
                        .WithMany()
                        .HasForeignKey("Freelance_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FreelanceGo_MasterV2.Models.Project", "Project")
                        .WithOne("FreelanceRating")
                        .HasForeignKey("FreelanceGo_MasterV2.Models.FreelanceRating", "Project_ID");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.FreelanceSkill", b =>
                {
                    b.HasOne("FreelanceGo_MasterV2.Models.Freelance", "Freelance")
                        .WithMany("FreelanceSkill")
                        .HasForeignKey("Freelance_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FreelanceGo_MasterV2.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("Skill_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Project", b =>
                {
                    b.HasOne("FreelanceGo_MasterV2.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Company_ID");

                    b.HasOne("FreelanceGo_MasterV2.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("Employer_ID");

                    b.HasOne("FreelanceGo_MasterV2.Models.Freelance", "Freelance")
                        .WithMany()
                        .HasForeignKey("Freelance_ID");
                });

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.ProjectSkill", b =>
                {
                    b.HasOne("FreelanceGo_MasterV2.Models.Project", "Project")
                        .WithMany("ProjectSkill")
                        .HasForeignKey("Project_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FreelanceGo_MasterV2.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("Skill_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
