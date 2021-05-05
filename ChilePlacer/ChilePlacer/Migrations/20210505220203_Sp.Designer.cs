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
    [Migration("20210505220203_Sp")]
    partial class Sp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChilePlacer.DataModels.AppLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Error")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Metodo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("AppLog");
                });

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
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("PathImagen")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Texto")
                        .HasColumnType("VARCHAR(500)");

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
                        .HasColumnType("VARCHAR(MAX)");

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

                    b.Property<string>("Atencion")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Contextura")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Country")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Depilacion")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Dni")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Drink")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Estatura")
                        .HasColumnType("DECIMAL");

                    b.Property<string>("Eyes")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Hair")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("Identidad")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Img64")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Location")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Medidas")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nombre")
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Path")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("DECIMAL");

                    b.Property<string>("Piel")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Presentacion")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Sexo")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Smoke")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Telefono")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("DECIMAL");

                    b.Property<decimal>("ValorMediaHora")
                        .HasColumnType("DECIMAL");

                    b.Property<string>("WhatsApp")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("ProfileGirls");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeAtencion", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Atencion")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Ide");

                    b.ToTable("TypeAtencion");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeAtencionGirl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Identidad")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("TypeAtencion")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("TypeAtencionGirl");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeContextura", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Contextura")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Ide");

                    b.ToTable("TypeContextura");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeDepilacion", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Depilacion")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Ide");

                    b.ToTable("TypeDepilacion");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeDrink", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Drink")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Ide");

                    b.ToTable("TypeDrink");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeEscort", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Categoria")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Ide");

                    b.ToTable("TypeEscort");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeEyes", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ojos")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Ide");

                    b.ToTable("TypeEyes");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeGirlServices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Identidad")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("TypeServices")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("TypeGirlServices");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeGirls", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Ide");

                    b.ToTable("TypeGirls");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeHair", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("ColorCabello")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Ide");

                    b.ToTable("TypeHair");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypePiel", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Piel")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Ide");

                    b.ToTable("TypePiel");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeServicesSex", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Servicio")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Ide");

                    b.ToTable("TypeServicesSex");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeSex", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Sexo")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Ide");

                    b.ToTable("TypeSex");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeSmoke", b =>
                {
                    b.Property<string>("Ide")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Smoke")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Ide");

                    b.ToTable("TypeSmoke");
                });
#pragma warning restore 612, 618
        }
    }
}
