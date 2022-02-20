using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marine.Migrations
{
    /// <summary>
    /// para agregar el costo a los equipos
    /// </summary>
    public partial class equipo2 : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CostoOperario",
                table: "Equipos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoOperario",
                table: "Equipos");
        }
    }
}
