﻿// <auto-generated />
using System;
using FootballersCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballersCatalog.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballersCatalog.Domain.Core.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Russia"
                        },
                        new
                        {
                            Id = 2,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Italy"
                        });
                });

            modelBuilder.Entity("FootballersCatalog.Domain.Core.Entities.Footballer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("TeamId");

                    b.ToTable("Footballers");
                });

            modelBuilder.Entity("FootballersCatalog.Domain.Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Barsa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sparta"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Arka"
                        });
                });

            modelBuilder.Entity("FootballersCatalog.Domain.Core.Entities.Footballer", b =>
                {
                    b.HasOne("FootballersCatalog.Domain.Core.Entities.Country", "Country")
                        .WithMany("Footballers")
                        .HasForeignKey("CountryId");

                    b.HasOne("FootballersCatalog.Domain.Core.Entities.Team", "Team")
                        .WithMany("Footballers")
                        .HasForeignKey("TeamId");

                    b.Navigation("Country");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FootballersCatalog.Domain.Core.Entities.Country", b =>
                {
                    b.Navigation("Footballers");
                });

            modelBuilder.Entity("FootballersCatalog.Domain.Core.Entities.Team", b =>
                {
                    b.Navigation("Footballers");
                });
#pragma warning restore 612, 618
        }
    }
}