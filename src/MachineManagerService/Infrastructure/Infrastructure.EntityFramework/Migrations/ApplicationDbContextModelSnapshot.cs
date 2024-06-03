﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using R7P.MachineManagerService.Infrastructure.EntityFramework;

#nullable disable

namespace R7P.MachineManagerService.Infrastructure.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("R7P.MachineManagerService.Domain.Entities.Cargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Destination")
                        .HasColumnType("text");

                    b.Property<long>("MachineId")
                        .HasColumnType("bigint");

                    b.Property<double>("Volume")
                        .HasColumnType("double precision");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("Cargoes");
                });

            modelBuilder.Entity("R7P.MachineManagerService.Domain.Entities.Machine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("CostPerDistance")
                        .HasColumnType("numeric");

                    b.Property<double>("MaxSpeed")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("VolumeCapacity")
                        .HasColumnType("double precision");

                    b.Property<double>("WeightCapacity")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("R7P.MachineManagerService.Domain.Entities.MachineTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Departure")
                        .HasColumnType("text");

                    b.Property<string>("Destination")
                        .HasColumnType("text");

                    b.Property<long>("MachineId")
                        .HasColumnType("bigint");

                    b.Property<double>("Progress")
                        .HasColumnType("double precision");

                    b.Property<int>("TaskOrder")
                        .HasColumnType("integer");

                    b.Property<int>("TaskType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("MachineTasks");
                });

            modelBuilder.Entity("R7P.MachineManagerService.Domain.Entities.Cargo", b =>
                {
                    b.HasOne("R7P.MachineManagerService.Domain.Entities.Machine", "Machine")
                        .WithMany("Сargoes")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("R7P.MachineManagerService.Domain.Entities.MachineTask", b =>
                {
                    b.HasOne("R7P.MachineManagerService.Domain.Entities.Machine", "Machine")
                        .WithMany("Tasks")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("R7P.MachineManagerService.Domain.Entities.Machine", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Сargoes");
                });
#pragma warning restore 612, 618
        }
    }
}
