﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webbshopen.SQL;

#nullable disable

namespace Webbshopen.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Antal")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KategorierId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("levrantör")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pris")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategorierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Webbshopen.SQL.Profiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<int?>("ProfilerId")
                        .HasColumnType("int");

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("efterNamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("forNamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("losenord")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProfilerId");

                    b.ToTable("Profiler");
                });

            modelBuilder.Entity("Webbshopen.SQL.Products", b =>
                {
                    b.HasOne("Webbshopen.SQL.Kategorier", "Kategorier")
                        .WithMany("Products")
                        .HasForeignKey("KategorierId");

                    b.Navigation("Kategorier");
                });

            modelBuilder.Entity("Webbshopen.SQL.Profiler", b =>
                {
                    b.HasOne("Webbshopen.SQL.Profiler", null)
                        .WithMany("Konton")
                        .HasForeignKey("ProfilerId");
                });

            modelBuilder.Entity("Webbshopen.SQL.Kategorier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Webbshopen.SQL.Profiler", b =>
                {
                    b.Navigation("Konton");
                });
#pragma warning restore 612, 618
        }
    }
}
