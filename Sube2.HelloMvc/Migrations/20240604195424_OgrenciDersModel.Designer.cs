﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sube2.HelloMvc.Models;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    [DbContext(typeof(OkulDbContext))]
    [Migration("20240604195424_OgrenciDersModel")]
    partial class OgrenciDersModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sube2.HelloMvc.Models.Ders", b =>
                {
                    b.Property<int>("Dersid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dersid"));

                    b.Property<string>("Dersad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<byte>("Kredi")
                        .HasColumnType("tinyint");

                    b.HasKey("Dersid");

                    b.ToTable("tblDersler", (string)null);
                });

            modelBuilder.Entity("Sube2.HelloMvc.Models.Ogrenci", b =>
                {
                    b.Property<int>("Ogrenciid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ogrenciid"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<int>("Numara")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.HasKey("Ogrenciid");

                    b.ToTable("tblOgrenciler", (string)null);
                });

            modelBuilder.Entity("Sube2.HelloMvc.Models.OgrenciDers", b =>
                {
                    b.Property<int>("Ogrenciid")
                        .HasColumnType("int");

                    b.Property<int>("Dersid")
                        .HasColumnType("int");

                    b.HasKey("Ogrenciid", "Dersid");

                    b.HasIndex("Dersid");

                    b.ToTable("OgrenciDersler");
                });

            modelBuilder.Entity("Sube2.HelloMvc.Models.OgrenciDers", b =>
                {
                    b.HasOne("Sube2.HelloMvc.Models.Ders", "Ders")
                        .WithMany("OgrenciDersler")
                        .HasForeignKey("Dersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sube2.HelloMvc.Models.Ogrenci", "Ogrenci")
                        .WithMany("OgrenciDersler")
                        .HasForeignKey("Ogrenciid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("Sube2.HelloMvc.Models.Ders", b =>
                {
                    b.Navigation("OgrenciDersler");
                });

            modelBuilder.Entity("Sube2.HelloMvc.Models.Ogrenci", b =>
                {
                    b.Navigation("OgrenciDersler");
                });
#pragma warning restore 612, 618
        }
    }
}
