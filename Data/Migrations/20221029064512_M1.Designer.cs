﻿// <auto-generated />
using CitiesAndProvince.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitiesAndProvince.Data.Migrations
{
    [DbContext(typeof(CitiesProvinceDbContext))]
    [Migration("20221029064512_M1")]
    partial class M1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CitiesAndProvince.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.Property<string>("ProvinceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceCode1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CityId");

                    b.HasIndex("ProvinceCode1");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "Vancouver",
                            Population = 0,
                            ProvinceCode = "BC"
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Richmond",
                            Population = 0,
                            ProvinceCode = "BC"
                        },
                        new
                        {
                            CityId = 3,
                            CityName = "Toronto",
                            Population = 0,
                            ProvinceCode = "ON"
                        },
                        new
                        {
                            CityId = 4,
                            CityName = "Calgary",
                            Population = 0,
                            ProvinceCode = "AB"
                        });
                });

            modelBuilder.Entity("CitiesAndProvince.Models.Province", b =>
                {
                    b.Property<string>("ProvinceCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceCode");

                    b.ToTable("Team", (string)null);

                    b.HasData(
                        new
                        {
                            ProvinceCode = "BC",
                            ProvinceName = "British Columbia"
                        },
                        new
                        {
                            ProvinceCode = "ON",
                            ProvinceName = "Ontario"
                        },
                        new
                        {
                            ProvinceCode = "AB",
                            ProvinceName = "Alberta"
                        });
                });

            modelBuilder.Entity("CitiesAndProvince.Models.City", b =>
                {
                    b.HasOne("CitiesAndProvince.Models.Province", null)
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceCode1");
                });

            modelBuilder.Entity("CitiesAndProvince.Models.Province", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
