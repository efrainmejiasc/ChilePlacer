﻿// <auto-generated />
using System;
using ChilePlacer.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChilePlacer.Migrations
{
    [DbContext(typeof(MyAppContext))]
    partial class MyAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChilePlacer.DataModels.GaleriaGirls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<int?>("GirlsId")
                        .HasColumnType("INT");

                    b.Property<string>("PathImagen")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id");

                    b.HasIndex("GirlsId");

                    b.ToTable("GaleriaGirls");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.Girls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("Identidad")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Girls");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeGirls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TypeGirls");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeSex", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Sexo")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TypeSex");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.GaleriaGirls", b =>
                {
                    b.HasOne("ChilePlacer.DataModels.Girls", "Girls")
                        .WithMany()
                        .HasForeignKey("GirlsId");

                    b.Navigation("Girls");
                });
#pragma warning restore 612, 618
        }
    }
}
