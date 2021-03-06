﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using frizerskisalon.Models;

namespace frizerskisalon.Migrations
{
    [DbContext(typeof(FrizerskiSalonContext))]
    [Migration("20200823174944_prva")]
    partial class prva
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("frizerskisalon.Models.Frizerskisalon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imesalona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Saloni");
                });

            modelBuilder.Entity("frizerskisalon.Models.Radnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FrizerskisalonId")
                        .HasColumnType("int");

                    b.Property<string>("Imeradnik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vreme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FrizerskisalonId");

                    b.ToTable("Radnici");
                });

            modelBuilder.Entity("frizerskisalon.Models.Radnik", b =>
                {
                    b.HasOne("frizerskisalon.Models.Frizerskisalon", "Frizerskisalon")
                        .WithMany("Radnici")
                        .HasForeignKey("FrizerskisalonId");
                });
#pragma warning restore 612, 618
        }
    }
}
