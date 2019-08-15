﻿// <auto-generated />
using System;
using BMP280API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BMP280API.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BMP280API.Models.Module", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("Guid");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("BMP280API.Models.ModuleData", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<Guid>("ModuleGuid");

                    b.Property<int>("Pression");

                    b.Property<float>("Temperature");

                    b.HasKey("Guid");

                    b.HasIndex("ModuleGuid");

                    b.ToTable("ModuleDatas");
                });

            modelBuilder.Entity("BMP280API.Models.ModuleData", b =>
                {
                    b.HasOne("BMP280API.Models.Module")
                        .WithMany("ModuleDatas")
                        .HasForeignKey("ModuleGuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
