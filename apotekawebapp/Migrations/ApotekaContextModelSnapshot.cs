﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apotekawebapp.Models;

namespace apotekawebapp.Migrations
{
    [DbContext(typeof(ApotekaContext))]
    partial class ApotekaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apotekawebapp.Models.Apoteka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivApoteke")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Apoteke");
                });

            modelBuilder.Entity("apotekawebapp.Models.Lek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApotekaId")
                        .HasColumnType("int");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("NazivLeka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegBroj")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApotekaId");

                    b.ToTable("Lekovi");
                });

            modelBuilder.Entity("apotekawebapp.Models.Lek", b =>
                {
                    b.HasOne("apotekawebapp.Models.Apoteka", "Apoteka")
                        .WithMany("Lekovi")
                        .HasForeignKey("ApotekaId");
                });
#pragma warning restore 612, 618
        }
    }
}
