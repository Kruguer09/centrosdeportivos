using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFconASPyMVC.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentrosDeportivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosDeportivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empleados = table.Column<int>(type: "int", nullable: false),
                    CentroDeportivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directores_CentrosDeportivos_CentroDeportivoId",
                        column: x => x.CentroDeportivoId,
                        principalTable: "CentrosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aforo = table.Column<int>(type: "int", nullable: false),
                    CentroDeportivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pistas_CentrosDeportivos_CentroDeportivoId",
                        column: x => x.CentroDeportivoId,
                        principalTable: "CentrosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentrosUsuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CentroDeportivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosUsuarios", x => new { x.UsuarioId, x.CentroDeportivoId });
                    table.ForeignKey(
                        name: "FK_CentrosUsuarios_CentrosDeportivos_CentroDeportivoId",
                        column: x => x.CentroDeportivoId,
                        principalTable: "CentrosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CentrosUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentrosUsuarios_CentroDeportivoId",
                table: "CentrosUsuarios",
                column: "CentroDeportivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Directores_CentroDeportivoId",
                table: "Directores",
                column: "CentroDeportivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pistas_CentroDeportivoId",
                table: "Pistas",
                column: "CentroDeportivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CentrosUsuarios");

            migrationBuilder.DropTable(
                name: "Directores");

            migrationBuilder.DropTable(
                name: "Pistas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CentrosDeportivos");
        }
    }
}
