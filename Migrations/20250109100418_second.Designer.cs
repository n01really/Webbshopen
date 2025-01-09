﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webbshopen.SQL;

#nullable disable

namespace Webbshopen.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20250109100418_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Webbshopen.SQL.Kategorier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorier");
                });

            modelBuilder.Entity("Webbshopen.SQL.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int?>("KategorierId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("pris")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategorierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Webbshopen.SQL.Products", b =>
                {
                    b.HasOne("Webbshopen.SQL.Kategorier", "Kategorier")
                        .WithMany("Products")
                        .HasForeignKey("KategorierId");

                    b.Navigation("Kategorier");
                });

            modelBuilder.Entity("Webbshopen.SQL.Kategorier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
