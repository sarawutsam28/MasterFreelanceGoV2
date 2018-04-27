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
    [Migration("20180427075446_InitialCreateV1")]
    partial class InitialCreateV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreelanceGo_MasterV2.Models.Employer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("facebook");

                    b.Property<string>("fullName")
                        .IsRequired();

                    b.Property<string>("imgName");

                    b.Property<string>("line");

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<string>("skill");

                    b.Property<string>("telephoneNumber");

                    b.Property<string>("uersTypes")
                        .IsRequired();

                    b.Property<string>("userName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
