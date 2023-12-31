﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApiRest;

#nullable disable

namespace TestApiRest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestApiRest.Domain.Entities.DetallePedido", b =>
                {
                    b.Property<int>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalle"));

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("date");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("Idlibro")
                        .HasColumnType("int");

                    b.HasKey("IdDetalle");

                    b.HasIndex("IdPedido");

                    b.HasIndex("Idlibro");

                    b.ToTable("DetallesPedidos");
                });

            modelBuilder.Entity("TestApiRest.Domain.Entities.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibro"));

                    b.Property<string>("Editorial")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdLibro");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("TestApiRest.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"));

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("TestApiRest.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumeroDocumento")
                        .HasColumnType("int");

                    b.Property<int>("TipoDocumento")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TestApiRest.Domain.Entities.DetallePedido", b =>
                {
                    b.HasOne("TestApiRest.Domain.Entities.Pedido", "Pedido")
                        .WithMany("ListaDetallePedidos")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestApiRest.Domain.Entities.Libro", "Libro")
                        .WithMany()
                        .HasForeignKey("Idlibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libro");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("TestApiRest.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("TestApiRest.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TestApiRest.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("ListaDetallePedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
