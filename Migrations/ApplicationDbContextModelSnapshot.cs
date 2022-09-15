﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripTravel.Data;

#nullable disable

namespace TripTravel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TripTravel.Entidades.ContratoSucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoSucursal")
                        .HasColumnType("int");

                    b.Property<int>("CodigoTurista")
                        .HasColumnType("int");

                    b.Property<int?>("SucursalId")
                        .HasColumnType("int");

                    b.Property<int?>("TuristaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SucursalId");

                    b.HasIndex("TuristaId");

                    b.ToTable("ContratoSucursal");
                });

            modelBuilder.Entity("TripTravel.Entidades.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ciudad")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CodigoHotel")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumeroPlazas")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("TripTravel.Entidades.ReservaHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoHotel")
                        .HasColumnType("int");

                    b.Property<int>("CodigoTurista")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaLlegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPartida")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Regimen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TuristaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TuristaId");

                    b.ToTable("ReservaHotel");
                });

            modelBuilder.Entity("TripTravel.Entidades.ReservaVuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Clase")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CodigoTurista")
                        .HasColumnType("int");

                    b.Property<int>("NumeroVuelo")
                        .HasColumnType("int");

                    b.Property<int?>("TuristaId")
                        .HasColumnType("int");

                    b.Property<int?>("VueloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TuristaId");

                    b.HasIndex("VueloId");

                    b.ToTable("ReservaVuelo");
                });

            modelBuilder.Entity("TripTravel.Entidades.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoSucursal")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("TripTravel.Entidades.Turista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("CodigoTurista")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Foto")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombres")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Turista");
                });

            modelBuilder.Entity("TripTravel.Entidades.Vuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Destino")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hora")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("NumeroVuelo")
                        .HasColumnType("int");

                    b.Property<string>("Origen")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PlazaTotal")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PlazaTurista")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Vuelo");
                });

            modelBuilder.Entity("TripTravel.Entidades.ContratoSucursal", b =>
                {
                    b.HasOne("TripTravel.Entidades.Sucursal", "Sucursal")
                        .WithMany("ContratoSucursal")
                        .HasForeignKey("SucursalId");

                    b.HasOne("TripTravel.Entidades.Turista", "Turista")
                        .WithMany("ContratoSucursal")
                        .HasForeignKey("TuristaId");

                    b.Navigation("Sucursal");

                    b.Navigation("Turista");
                });

            modelBuilder.Entity("TripTravel.Entidades.ReservaHotel", b =>
                {
                    b.HasOne("TripTravel.Entidades.Hotel", "Hotel")
                        .WithMany("ReservaHotel")
                        .HasForeignKey("HotelId");

                    b.HasOne("TripTravel.Entidades.Turista", "Turista")
                        .WithMany("ReservaHotel")
                        .HasForeignKey("TuristaId");

                    b.Navigation("Hotel");

                    b.Navigation("Turista");
                });

            modelBuilder.Entity("TripTravel.Entidades.ReservaVuelo", b =>
                {
                    b.HasOne("TripTravel.Entidades.Turista", null)
                        .WithMany("ReservaVuelo")
                        .HasForeignKey("TuristaId");

                    b.HasOne("TripTravel.Entidades.Vuelo", "Vuelo")
                        .WithMany("ReservaVuelo")
                        .HasForeignKey("VueloId");

                    b.Navigation("Vuelo");
                });

            modelBuilder.Entity("TripTravel.Entidades.Hotel", b =>
                {
                    b.Navigation("ReservaHotel");
                });

            modelBuilder.Entity("TripTravel.Entidades.Sucursal", b =>
                {
                    b.Navigation("ContratoSucursal");
                });

            modelBuilder.Entity("TripTravel.Entidades.Turista", b =>
                {
                    b.Navigation("ContratoSucursal");

                    b.Navigation("ReservaHotel");

                    b.Navigation("ReservaVuelo");
                });

            modelBuilder.Entity("TripTravel.Entidades.Vuelo", b =>
                {
                    b.Navigation("ReservaVuelo");
                });
#pragma warning restore 612, 618
        }
    }
}
