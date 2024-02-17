﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Servis.Data;

#nullable disable

namespace Servis.Migrations
{
    [DbContext(typeof(ServisContext))]
    partial class ServisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Servis.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MecanicID")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Revizie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MecanicID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Servis.Models.CarOrigine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("OrigineID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("OrigineID");

                    b.ToTable("CarOrigine");
                });

            modelBuilder.Entity("Servis.Models.Mecanic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("MecanicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Mecanic");
                });

            modelBuilder.Entity("Servis.Models.Origine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("OrigineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Origine");
                });

            modelBuilder.Entity("Servis.Models.Car", b =>
                {
                    b.HasOne("Servis.Models.Mecanic", "Mecanic")
                        .WithMany("Cars")
                        .HasForeignKey("MecanicID");

                    b.Navigation("Mecanic");
                });

            modelBuilder.Entity("Servis.Models.CarOrigine", b =>
                {
                    b.HasOne("Servis.Models.Car", "Car")
                        .WithMany("CarOrigines")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Servis.Models.Origine", "Origine")
                        .WithMany("CarOrigines")
                        .HasForeignKey("OrigineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Origine");
                });

            modelBuilder.Entity("Servis.Models.Car", b =>
                {
                    b.Navigation("CarOrigines");
                });

            modelBuilder.Entity("Servis.Models.Mecanic", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Servis.Models.Origine", b =>
                {
                    b.Navigation("CarOrigines");
                });
#pragma warning restore 612, 618
        }
    }
}
