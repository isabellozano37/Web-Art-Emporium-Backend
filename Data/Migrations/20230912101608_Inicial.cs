﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id_Categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pintura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Escultura = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "DetallesCompras",
                columns: table => new
                {
                    Id_DetallesCompras = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdProductos = table.Column<int>(type: "int", nullable: false),
                    IdCompras = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCompras", x => x.Id_DetallesCompras);
                });

            migrationBuilder.CreateTable(
                name: "Roll",
                columns: table => new
                {
                    IdRoll = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Roll = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roll", x => x.IdRoll);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    IdTipos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oleo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acuarela = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bustos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ceramicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    categoriaId_Categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.IdTipos);
                    table.ForeignKey(
                        name: "FK_Tipos_Categoria_categoriaId_Categoria",
                        column: x => x.categoriaId_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "Id_Categoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRoll = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Roll_IdRoll",
                        column: x => x.IdRoll,
                        principalTable: "Roll",
                        principalColumn: "IdRoll",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id_Compras = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProductos = table.Column<int>(type: "int", nullable: false),
                    ComprasId_Compras = table.Column<int>(type: "int", nullable: true),
                    UsuarioId_Usuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id_Compras);
                    table.ForeignKey(
                        name: "FK_Compras_Compras_ComprasId_Compras",
                        column: x => x.ComprasId_Compras,
                        principalTable: "Compras",
                        principalColumn: "Id_Compras");
                    table.ForeignKey(
                        name: "FK_Compras_Usuario_UsuarioId_Usuario",
                        column: x => x.UsuarioId_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario");
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    Id_Solicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.Id_Solicitud);
                    table.ForeignKey(
                        name: "FK_Solicitud_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProductos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false),
                    IdCategorias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProductos);
                    table.ForeignKey(
                        name: "FK_Productos_Categoria_IdCategorias",
                        column: x => x.IdCategorias,
                        principalTable: "Categoria",
                        principalColumn: "Id_Categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Solicitud_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "Solicitud",
                        principalColumn: "Id_Solicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ComprasId_Compras",
                table: "Compras",
                column: "ComprasId_Compras");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId_Usuario",
                table: "Compras",
                column: "UsuarioId_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategorias",
                table: "Productos",
                column: "IdCategorias");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdSolicitud",
                table: "Productos",
                column: "IdSolicitud",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_IdUsuario",
                table: "Solicitud",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_categoriaId_Categoria",
                table: "Tipos",
                column: "categoriaId_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRoll",
                table: "Usuario",
                column: "IdRoll");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "DetallesCompras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Roll");
        }
    }
}
