﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Working.Models.DataModel;

namespace Working.Migrations
{
    [DbContext(typeof(WorkingDbContext))]
    [Migration("20171018063556_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Working.Models.DataModel.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartMentName");

                    b.Property<int>("PID");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Working.Models.DataModel.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentID");

                    b.Property<bool>("IsDeparmentLeader");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Working.Models.DataModel.WorkItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("CreateUserID");

                    b.Property<string>("Memos");

                    b.Property<DateTime>("RecordDate");

                    b.Property<string>("WorkContent");

                    b.HasKey("ID");

                    b.HasIndex("CreateUserID");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("Working.Models.DataModel.User", b =>
                {
                    b.HasOne("Working.Models.DataModel.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Working.Models.DataModel.WorkItem", b =>
                {
                    b.HasOne("Working.Models.DataModel.User", "CreateUser")
                        .WithMany("WorkItems")
                        .HasForeignKey("CreateUserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
