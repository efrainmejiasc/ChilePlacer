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
    [Migration("20210410233932_ForeKey2")]
    partial class ForeKey2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("IdGirls")
                        .HasColumnType("INT");

                    b.Property<string>("PathImagen")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<int>("TypeGirlsId")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("TypeGirlsId");

                    b.ToTable("GaleriaGirls");
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

            modelBuilder.Entity("ChilePlacer.DataModels.GaleriaGirls", b =>
                {
                    b.HasOne("ChilePlacer.DataModels.TypeGirls", "TypeGirls")
                        .WithMany("GaleriaGirls")
                        .HasForeignKey("TypeGirlsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeGirls");
                });

            modelBuilder.Entity("ChilePlacer.DataModels.TypeGirls", b =>
                {
                    b.Navigation("GaleriaGirls");
                });
#pragma warning restore 612, 618
        }
    }
}
