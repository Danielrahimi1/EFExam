﻿// <auto-generated />
using System;
using EFExam.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFExam.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240917085850_build_domain")]
    partial class build_domain
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFExam.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Animals", (string)null);
                });

            modelBuilder.Entity("EFExam.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalCount")
                        .HasColumnType("int");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("TicketId")
                        .HasMaxLength(500)
                        .HasColumnType("int");

                    b.Property<int?>("ZooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("TicketId")
                        .IsUnique()
                        .HasFilter("[TicketId] IS NOT NULL");

                    b.HasIndex("ZooId");

                    b.ToTable("Sections", (string)null);
                });

            modelBuilder.Entity("EFExam.Entities.SoldTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SoldTickets", (string)null);
                });

            modelBuilder.Entity("EFExam.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(7, 2)");

                    b.HasKey("Id");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("EFExam.Entities.Zoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Zoos", (string)null);
                });

            modelBuilder.Entity("EFExam.Entities.Section", b =>
                {
                    b.HasOne("EFExam.Entities.Animal", "Animal")
                        .WithMany("Sections")
                        .HasForeignKey("AnimalId");

                    b.HasOne("EFExam.Entities.Ticket", "Ticket")
                        .WithOne("Section")
                        .HasForeignKey("EFExam.Entities.Section", "TicketId");

                    b.HasOne("EFExam.Entities.Zoo", "Zoo")
                        .WithMany("Sections")
                        .HasForeignKey("ZooId");

                    b.Navigation("Animal");

                    b.Navigation("Ticket");

                    b.Navigation("Zoo");
                });

            modelBuilder.Entity("EFExam.Entities.Animal", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("EFExam.Entities.Ticket", b =>
                {
                    b.Navigation("Section")
                        .IsRequired();
                });

            modelBuilder.Entity("EFExam.Entities.Zoo", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
