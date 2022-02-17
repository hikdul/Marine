using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marine.Migrations
{
    /// <summary>
    /// para generar tabla de materias primas
    /// </summary>
    public partial class MateriasPrimas : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MateriasPrimas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasPrimas", x => x.id);
                    table.ForeignKey(
                        name: "FK_MateriasPrimas_Mariscos_Mariscoid",
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
                value: "2735f11c-7520-4281-b3b2-58e0bfa141ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e1b4175-cf9c-4fd2-ab0d-987f5af67434",
                column: "ConcurrencyStamp",
                value: "1d20e686-26e5-4e16-92d2-fab28973dffb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f36838c-81ae-4d20-83a0-b867fd489771",
                column: "ConcurrencyStamp",
                value: "19300c99-d42d-4aee-b738-6432cb826fc6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b2b621-d728-428e-a2be-bc8d30aed151",
                column: "ConcurrencyStamp",
                value: "5aaf050c-ada6-4e77-8dfc-2d3a8843e42a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "445f6fc1-5dd4-4c32-af61-19a91b8f1367",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14b2fe0b-204c-4a32-ad4b-f6839e68b301", "AQAAAAEAACcQAAAAELOAZLfZhlJ6iIOhg7lmJI5K/7TNi3WPHnoz8aIPThd6WjWeIZ70G8Bms7CK2lCQTA==", "ebc343fb-b7aa-443f-84d9-fb0c77fe7799" });

            migrationBuilder.CreateIndex(
                name: "IX_MateriasPrimas_Mariscoid",
                table: "MateriasPrimas",
                column: "Mariscoid");
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriasPrimas");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9",
                column: "ConcurrencyStamp",
                value: "ef92cc8f-eeb9-41fb-9eec-42fac02ad5c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e1b4175-cf9c-4fd2-ab0d-987f5af67434",
                column: "ConcurrencyStamp",
                value: "92e57ab3-0323-4a69-995f-16cb9a1ec67e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f36838c-81ae-4d20-83a0-b867fd489771",
                column: "ConcurrencyStamp",
                value: "77f57024-f937-4d52-861e-033f4ea38328");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b2b621-d728-428e-a2be-bc8d30aed151",
                column: "ConcurrencyStamp",
                value: "9f6550cf-0d6d-4193-b18f-0f47651da3b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "445f6fc1-5dd4-4c32-af61-19a91b8f1367",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51d5320f-a671-4d49-ab39-67d16635ebd1", "AQAAAAEAACcQAAAAEEyTscWJhUDIoOg7sZbidaUBN/bmIKbPBiefPHXqI9BG/oa76GrvHsgsS3wVMJD7wg==", "32c0a7ad-fe4c-4a0d-81a0-88d4789fa06a" });
        }
    }
}
