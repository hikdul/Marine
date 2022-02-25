using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marine.Migrations
{
    /// <summary>
    /// para generar la tabla
    /// </summary>
    public partial class CostosMensuales : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostosMes",
                columns: table => new
                {
                    Equipoid = table.Column<int>(type: "int", nullable: false),
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    Calibreid = table.Column<int>(type: "int", nullable: false),
                    TipoProduccionid = table.Column<int>(type: "int", nullable: false),
                    NumOperadores = table.Column<double>(type: "float", nullable: false),
                    PorcentajeOperadoresCubiertos = table.Column<double>(type: "float", nullable: false),
                    CostoPromedioEquipoPorDia = table.Column<double>(type: "float", nullable: false),
                    KgProductoPromedioPorDia = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    EquipoTurnoid = table.Column<int>(type: "int", nullable: false),
                    EquipoCargoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostosMes", x => new { x.Equipoid, x.Mariscoid, x.TipoProduccionid, x.Calibreid });
                    table.ForeignKey(
                        name: "FK_CostosMes_Calibres_Calibreid",
                        column: x => x.Calibreid,
                        principalTable: "Calibres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostosMes_Equipos_EquipoTurnoid_EquipoCargoid",
                        columns: x => new { x.EquipoTurnoid, x.EquipoCargoid },
                        principalTable: "Equipos",
                        principalColumns: new[] { "Turnoid", "Cargoid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostosMes_Mariscos_Mariscoid",
                        column: x => x.Mariscoid,
                        principalTable: "Mariscos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostosMes_TiposProduccion_TipoProduccionid",
                        column: x => x.TipoProduccionid,
                        principalTable: "TiposProduccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostosMes_Calibreid",
                table: "CostosMes",
                column: "Calibreid");

            migrationBuilder.CreateIndex(
                name: "IX_CostosMes_EquipoTurnoid_EquipoCargoid",
                table: "CostosMes",
                columns: new[] { "EquipoTurnoid", "EquipoCargoid" });

            migrationBuilder.CreateIndex(
                name: "IX_CostosMes_Mariscoid",
                table: "CostosMes",
                column: "Mariscoid");

            migrationBuilder.CreateIndex(
                name: "IX_CostosMes_TipoProduccionid",
                table: "CostosMes",
                column: "TipoProduccionid");
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostosMes");
        }
    }
}
