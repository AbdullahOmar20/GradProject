﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.BenchmarkMigrations
{
    [DbContext(typeof(BenchmarkDbContext))]
    partial class BenchmarkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entites.Benchmark.CPUBenchmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("BaseClock")
                        .HasColumnType("float");

                    b.Property<int?>("Cores")
                        .HasColumnType("int");

                    b.Property<string>("CpuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MultiScore")
                        .HasColumnType("int");

                    b.Property<int?>("SingleScore")
                        .HasColumnType("int");

                    b.Property<int?>("Threads")
                        .HasColumnType("int");

                    b.Property<double?>("TurboClock")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CPUsbenchmark");
                });

            modelBuilder.Entity("Core.Entites.Benchmark.GPUBenchmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("G2DMark")
                        .HasColumnType("int");

                    b.Property<int?>("G3DMark")
                        .HasColumnType("int");

                    b.Property<string>("GpuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("GpuValue")
                        .HasColumnType("float");

                    b.Property<double?>("PowerPerformance")
                        .HasColumnType("float");

                    b.Property<int?>("TDP")
                        .HasColumnType("int");

                    b.Property<int?>("TestDate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GPUsbenchmark");
                });
#pragma warning restore 612, 618
        }
    }
}
