﻿// <auto-generated />
using System;
using BibliotecaDaDudu.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaDaDudu.API.Persistence.Migrations
{
    [DbContext(typeof(BibibliotecaDaDuduDbContext))]
    [Migration("20231220050642_AdicionandoTabelas")]
    partial class AdicionandoTabelas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotecaDaDudu.API.Entities.ImagemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("BibliotecaDaDudu.API.Entities.MangaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Avaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal")
                        .HasDefaultValue(0m);

                    b.Property<Guid>("CapaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Concluido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sinopse")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("StatusLeitura")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TotalVolumes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CapaId");

                    b.ToTable("Mangas");
                });

            modelBuilder.Entity("BibliotecaDaDudu.API.Entities.VolumeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Avaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal")
                        .HasDefaultValue(0m);

                    b.Property<Guid>("CapaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid?>("MangaEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MangaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Sinopse")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("StatusCompra")
                        .HasColumnType("int");

                    b.Property<int>("StatusLeitura")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CapaId");

                    b.HasIndex("MangaEntityId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("BibliotecaDaDudu.API.Entities.MangaEntity", b =>
                {
                    b.HasOne("BibliotecaDaDudu.API.Entities.ImagemEntity", null)
                        .WithMany()
                        .HasForeignKey("CapaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibliotecaDaDudu.API.Entities.VolumeEntity", b =>
                {
                    b.HasOne("BibliotecaDaDudu.API.Entities.ImagemEntity", null)
                        .WithMany()
                        .HasForeignKey("CapaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaDaDudu.API.Entities.MangaEntity", null)
                        .WithMany("Volumes")
                        .HasForeignKey("MangaEntityId");
                });

            modelBuilder.Entity("BibliotecaDaDudu.API.Entities.MangaEntity", b =>
                {
                    b.Navigation("Volumes");
                });
#pragma warning restore 612, 618
        }
    }
}
