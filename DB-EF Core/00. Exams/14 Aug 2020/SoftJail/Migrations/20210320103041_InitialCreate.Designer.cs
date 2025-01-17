﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftJail.Data;

namespace SoftJail.Migrations
{
    [DbContext(typeof(SoftJailDbContext))]
    [Migration("20210320103041_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoftJail.Data.Models.Cell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CellNumber");

                    b.Property<int>("DepartmentId");

                    b.Property<bool>("HasWindow");

                    b.Property<int>("MyProperty");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("PrisonerId");

                    b.Property<string>("Sender")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PrisonerId");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Officer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Position");

                    b.Property<decimal>("Salary");

                    b.Property<int>("Weapon");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Officers");
                });

            modelBuilder.Entity("SoftJail.Data.Models.OfficerPrisoner", b =>
                {
                    b.Property<int>("PrisonerId");

                    b.Property<int>("OfficerId");

                    b.HasKey("PrisonerId", "OfficerId");

                    b.HasIndex("OfficerId");

                    b.ToTable("OfficersPrisoners");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Prisoner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<decimal?>("Bail");

                    b.Property<int>("CellId");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("IncarcerationDate");

                    b.Property<string>("NickName")
                        .IsRequired();

                    b.Property<DateTime?>("ReleaseDate");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.ToTable("Prisoners");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Cell", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Department", "Department")
                        .WithMany("Cells")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoftJail.Data.Models.Mail", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Prisoner", "Prisoner")
                        .WithMany("Mails")
                        .HasForeignKey("PrisonerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoftJail.Data.Models.Officer", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoftJail.Data.Models.OfficerPrisoner", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Officer", "Officer")
                        .WithMany("OfficerPrisoners")
                        .HasForeignKey("OfficerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SoftJail.Data.Models.Prisoner", "Prisoner")
                        .WithMany("PrisonerOfficers")
                        .HasForeignKey("PrisonerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SoftJail.Data.Models.Prisoner", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Cell", "Cell")
                        .WithMany("Prisoners")
                        .HasForeignKey("CellId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
