using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marine.Migrations
{
    /// <summary>
    /// para ingresar la tablo de hs materia prima
    /// </summary>
    public partial class HSMateriaPrima : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialMateriaPrima",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuarioid = table.Column<int>(type: "int", nullable: false),
                    Ingreso = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMateriaPrima", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistorialMateriaPrima_AspNetUsuario_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "AspNetUsuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialMateriaPrima_Mariscos_Mariscoid",
                        column: x => x.Mariscoid,
                        principalTable: "Mariscos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9",
                column: "ConcurrencyStamp",
                value: "fcb290f6-0b2b-46cc-8a83-3b939015b58d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e1b4175-cf9c-4fd2-ab0d-987f5af67434",
                column: "ConcurrencyStamp",
                value: "bc54b599-b7a4-42cb-b9b2-3b2a8c667344");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f36838c-81ae-4d20-83a0-b867fd489771",
                column: "ConcurrencyStamp",
                value: "7ac96483-18f8-4358-824d-7b29195dc2cc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b2b621-d728-428e-a2be-bc8d30aed151",
                column: "ConcurrencyStamp",
                value: "cb237477-a96d-44c3-b5f7-1158b61974e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "445f6fc1-5dd4-4c32-af61-19a91b8f1367",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5aed1e9-e9ea-4ab1-bcbc-796490251752", "AQAAAAEAACcQAAAAEBfV/Hfd3FD6BUJUwLZz1gB4qW4olmwN5sMqH5Uu3RX9WVNuwvvVVSvsAMQ5+Qmgkw==", "8d4e6eea-cf1f-4215-8c1d-c9b6393732f5" });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialMateriaPrima_Mariscoid",
                table: "HistorialMateriaPrima",
                column: "Mariscoid");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialMateriaPrima_Usuarioid",
                table: "HistorialMateriaPrima",
                column: "Usuarioid");
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialMateriaPrima");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9",
                column: "ConcurrencyStamp",
                value: "7ad1f9f8-9853-460f-a50e-d3e93e819b6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e1b4175-cf9c-4fd2-ab0d-987f5af67434",
                column: "ConcurrencyStamp",
                value: "9bd3b80e-c7ab-4080-b48c-4228b7b1a014");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f36838c-81ae-4d20-83a0-b867fd489771",
                column: "ConcurrencyStamp",
                value: "0dc65129-681e-4cd0-b324-60e32c10eda4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b2b621-d728-428e-a2be-bc8d30aed151",
                column: "ConcurrencyStamp",
                value: "799fc9f9-4e02-44fe-93e5-9f5f845a1f64");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "445f6fc1-5dd4-4c32-af61-19a91b8f1367",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f268e0f-53e9-4899-a773-86331a0eef8a", "AQAAAAEAACcQAAAAEKr3MNp/39PZlmrXFrAOHEz03czFsGkU7jiNBv5kgtbqo52sJ5tX8qtIeWAUo005DA==", "c066a6ee-83d2-4d81-9deb-6f97edbeb0d7" });
        }
    }
}
