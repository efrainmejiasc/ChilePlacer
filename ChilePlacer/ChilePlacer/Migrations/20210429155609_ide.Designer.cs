﻿// <auto-generated />
using System;
using ChilePlacer.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChilePlacer.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20210429155609_ide")]
    partial class ide
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChilePlacer.DataModels.ChangePassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("ChangePassword");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.GaleriaGirls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("Identidad")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Img64")
                        .HasColumnType("VARCHAR(8000)");

                    b.Property<string>("PathImagen")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id");

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

                    b.HasKey("Id");

                    b.ToTable("Girls");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.PortadaGirls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdGirls")
                        .HasColumnType("INT");

                    b.Property<string>("Img64")
                        .HasColumnType("VARCHAR(8000)");

                    b.Property<string>("PathImagen")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Texto")
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("PortadaGirls");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.ProfileGirls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Dni")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("Identidad")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Img64")
                        .HasColumnType("VARCHAR(8000)");

                    b.Property<string>("Nombre")
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Path")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Telefono")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("ProfileGirls");
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
#pragma warning restore 612, 618
        }
    }
}
