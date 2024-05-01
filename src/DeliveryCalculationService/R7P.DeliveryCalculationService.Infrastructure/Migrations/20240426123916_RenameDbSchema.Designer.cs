﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using R7P.DeliveryCalculationService.Infrastructure;

#nullable disable

namespace R7P.DeliveryCalculationService.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240426123916_RenameDbSchema")]
    partial class RenameDbSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("R7P.DeliveryCalculationService.Domain.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AddressInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("AddressInfo");

                    b.ToTable("Address", "dbo");
                });

            modelBuilder.Entity("R7P.DeliveryCalculationService.Domain.Entities.Calculation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("CargoSize")
                        .HasColumnType("double precision");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<TimeSpan>("DeliveryTime")
                        .HasColumnType("interval");

                    b.Property<long>("DepartureAddressId")
                        .HasColumnType("bigint");

                    b.Property<long>("DestinationAddressId")
                        .HasColumnType("bigint");

                    b.Property<long>("MachineId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DepartureAddressId");

                    b.HasIndex("DestinationAddressId");

                    b.ToTable("Calculations", "dbo");
                });

            modelBuilder.Entity("R7P.DeliveryCalculationService.Domain.Entities.Segment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("DepartureAddressId")
                        .HasColumnType("bigint");

                    b.Property<long>("DestinationAddressId")
                        .HasColumnType("bigint");

                    b.Property<double>("Distance")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasAlternateKey("DepartureAddressId", "DestinationAddressId");

                    b.HasIndex("DestinationAddressId");

                    b.ToTable("Segments", "dbo");
                });

            modelBuilder.Entity("R7P.DeliveryCalculationService.Domain.Entities.Calculation", b =>
                {
                    b.HasOne("R7P.DeliveryCalculationService.Domain.Entities.Address", "DepartureAddress")
                        .WithMany()
                        .HasForeignKey("DepartureAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("R7P.DeliveryCalculationService.Domain.Entities.Address", "DestinationAddress")
                        .WithMany()
                        .HasForeignKey("DestinationAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartureAddress");

                    b.Navigation("DestinationAddress");
                });

            modelBuilder.Entity("R7P.DeliveryCalculationService.Domain.Entities.Segment", b =>
                {
                    b.HasOne("R7P.DeliveryCalculationService.Domain.Entities.Address", "DepartureAddress")
                        .WithMany()
                        .HasForeignKey("DepartureAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("R7P.DeliveryCalculationService.Domain.Entities.Address", "DestinationAddress")
                        .WithMany()
                        .HasForeignKey("DestinationAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartureAddress");

                    b.Navigation("DestinationAddress");
                });
#pragma warning restore 612, 618
        }
    }
}