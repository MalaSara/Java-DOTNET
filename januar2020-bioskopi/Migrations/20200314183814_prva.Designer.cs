﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using januar2020_bioskopi.Models;

namespace januar2020_bioskopi.Migrations
{
    [DbContext(typeof(BioskopContext))]
    [Migration("20200314183814_prva")]
    partial class prva
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("januar2020_bioskopi.Models.Bioskop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojMesta")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Red")
                        .HasColumnType("int");

                    b.Property<int>("Rezervisanih")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bioskopi");
                });

            modelBuilder.Entity("januar2020_bioskopi.Models.Stolica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BioskopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BioskopId");

                    b.ToTable("Stolice");
                });

            modelBuilder.Entity("januar2020_bioskopi.Models.Stolica", b =>
                {
                    b.HasOne("januar2020_bioskopi.Models.Bioskop", "Bioskop")
                        .WithMany("Stolice")
                        .HasForeignKey("BioskopId");
                });
#pragma warning restore 612, 618
        }
    }
}