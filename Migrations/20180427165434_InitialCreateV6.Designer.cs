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
    [Migration("20180427165434_InitialCreateV6")]
    partial class InitialCreateV6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Company", b =>
                {
                    b.Property<int>("Company_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company_Address");

                    b.Property<string>("Company_Name")
                        .IsRequired();

                    b.Property<int>("Company_TaxID");

                    b.Property<int>("Company_Tel");

                    b.Property<DateTime>("Date_Create");

                    b.Property<DateTime>("Date_Update");

                    b.Property<bool>("DelStatus");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Facebook");

                    b.Property<int>("Fax");

                    b.Property<string>("Line");

                    b.Property<string>("Password")
                        .IsRequired();

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

                    b.Property<bool>("DelStatus");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Facebook");

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<int>("ID_Card");

                    b.Property<string>("Line");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("TelephoneNumber");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("imgName");

                    b.HasKey("Employer_ID");

                    b.ToTable("Employer");
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

                    b.Property<int>("ID_Card");

                    b.Property<string>("ImgName");

                    b.Property<string>("Line");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("TelephoneNumber");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Freelance_ID");

                    b.HasIndex("UserName", "Email")
                        .IsUnique();

                    b.ToTable("Freelance");
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
#pragma warning restore 612, 618
        }
    }
}
