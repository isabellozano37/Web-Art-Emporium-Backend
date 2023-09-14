using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Nombre_Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id_Categoria);
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
                    Nombre_Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.IdTipos);
                    table.ForeignKey(
                        name: "FK_Tipos_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
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
                name: "AuditLog",
                columns: table => new
                {
                    IdLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.IdLog);
                    table.ForeignKey(
                        name: "FK_AuditLog_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
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
                    UsuarioId_Usuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id_Compras);
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
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipos = table.Column<int>(type: "int", nullable: false)
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
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false),
                    IdTipos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProductos);
                    table.ForeignKey(
                        name: "FK_Productos_Solicitud_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "Solicitud",
                        principalColumn: "Id_Solicitud",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Tipos_IdTipos",
                        column: x => x.IdTipos,
                        principalTable: "Tipos",
                        principalColumn: "IdTipos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesCompras",
                columns: table => new
                {
                    Id_DetallesCompras = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Precio_Total = table.Column<int>(type: "int", nullable: false),
                    IdProductos = table.Column<int>(type: "int", nullable: false),
                    IdCompras = table.Column<int>(type: "int", nullable: false),
                    ComprasId_Compras = table.Column<int>(type: "int", nullable: true),
                    ProductosIdProductos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCompras", x => x.Id_DetallesCompras);
                    table.ForeignKey(
                        name: "FK_DetallesCompras_Compras_ComprasId_Compras",
                        column: x => x.ComprasId_Compras,
                        principalTable: "Compras",
                        principalColumn: "Id_Compras");
                    table.ForeignKey(
                        name: "FK_DetallesCompras_Productos_ProductosIdProductos",
                        column: x => x.ProductosIdProductos,
                        principalTable: "Productos",
                        principalColumn: "IdProductos");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_UserId",
                table: "AuditLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId_Usuario",
                table: "Compras",
                column: "UsuarioId_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompras_ComprasId_Compras",
                table: "DetallesCompras",
                column: "ComprasId_Compras");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompras_ProductosIdProductos",
                table: "DetallesCompras",
                column: "ProductosIdProductos");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdSolicitud",
                table: "Productos",
                column: "IdSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdTipos",
                table: "Productos",
                column: "IdTipos");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_IdUsuario",
                table: "Solicitud",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_IdCategoria",
                table: "Tipos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRoll",
                table: "Usuario",
                column: "IdRoll");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "DetallesCompras");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Roll");
        }
    }
}
