using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marine.Migrations
{
    /// <summary>
    /// migracion para la creacion de productos
    /// </summary>
    public partial class Productos : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36fd17b9-9034-47de-9f8f-f42c9fc70d3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c7f1b20-e385-47e4-bbc6-3ea00c246c04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4df2f790-4c17-4508-a42b-0c07f71629e8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8a7c427f-c478-4dd7-99e3-e4caca1178ce", "259ac90f-f3cb-4064-b9c2-2d20325d2b6d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a7c427f-c478-4dd7-99e3-e4caca1178ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "259ac90f-f3cb-4064-b9c2-2d20325d2b6d");

            migrationBuilder.CreateTable(
                name: "Calibres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empaquetados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empaquetados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mariscos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mariscos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiposProduccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProduccion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    act = table.Column<bool>(type: "bit", nullable: false),
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    TipoProduccionid = table.Column<int>(type: "int", nullable: false),
                    Calibreid = table.Column<int>(type: "int", nullable: false),
                    Empaquetadoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productos_Calibres_Calibreid",
                        column: x => x.Calibreid,
                        principalTable: "Calibres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Empaquetados_Empaquetadoid",
                        column: x => x.Empaquetadoid,
                        principalTable: "Empaquetados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Mariscos_Mariscoid",
                        column: x => x.Mariscoid,
                        principalTable: "Mariscos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_TiposProduccion_TipoProduccionid",
                        column: x => x.TipoProduccionid,
                        principalTable: "TiposProduccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9", "ef92cc8f-eeb9-41fb-9eec-42fac02ad5c9", "AdmoSistema", "ADMOSISTEMA" },
                    { "6e1b4175-cf9c-4fd2-ab0d-987f5af67434", "92e57ab3-0323-4a69-995f-16cb9a1ec67e", "Cliente", "CLIENTE" },
                    { "8f36838c-81ae-4d20-83a0-b867fd489771", "77f57024-f937-4d52-861e-033f4ea38328", "Gerenteplanta", "GERENTEPLANTA" },
                    { "a6b2b621-d728-428e-a2be-bc8d30aed151", "9f6550cf-0d6d-4193-b18f-0f47651da3b1", "Superv", "SUPERV" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "445f6fc1-5dd4-4c32-af61-19a91b8f1367", 0, "51d5320f-a671-4d49-ab39-67d16635ebd1", "hikdul.dev@gmail.com", true, false, null, "HIKDUL.DEV@GMAIL.COM", "HIKDUL.DEV@GMAIL.COM", "AQAAAAEAACcQAAAAEEyTscWJhUDIoOg7sZbidaUBN/bmIKbPBiefPHXqI9BG/oa76GrvHsgsS3wVMJD7wg==", "+51 931 084 717", true, "32c0a7ad-fe4c-4a0d-81a0-88d4789fa06a", false, "hikdul.dev@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9", "445f6fc1-5dd4-4c32-af61-19a91b8f1367" });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Calibreid",
                table: "Productos",
                column: "Calibreid");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Empaquetadoid",
                table: "Productos",
                column: "Empaquetadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Mariscoid",
                table: "Productos",
                column: "Mariscoid");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProduccionid",
                table: "Productos",
                column: "TipoProduccionid");
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Calibres");

            migrationBuilder.DropTable(
                name: "Empaquetados");

            migrationBuilder.DropTable(
                name: "Mariscos");

            migrationBuilder.DropTable(
                name: "TiposProduccion");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e1b4175-cf9c-4fd2-ab0d-987f5af67434");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f36838c-81ae-4d20-83a0-b867fd489771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b2b621-d728-428e-a2be-bc8d30aed151");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9", "445f6fc1-5dd4-4c32-af61-19a91b8f1367" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "445f6fc1-5dd4-4c32-af61-19a91b8f1367");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36fd17b9-9034-47de-9f8f-f42c9fc70d3e", "0e82aab9-4f87-49f8-9e4b-6c089108d213", "Superv", "SUPERV" },
                    { "3c7f1b20-e385-47e4-bbc6-3ea00c246c04", "047d2e93-74ae-4509-9fda-9136da21db2e", "Cliente", "CLIENTE" },
                    { "4df2f790-4c17-4508-a42b-0c07f71629e8", "e9c053fd-2266-4f1d-aba3-fa8340ed5666", "Gerenteplanta", "GERENTEPLANTA" },
                    { "8a7c427f-c478-4dd7-99e3-e4caca1178ce", "b60e1f06-f6a5-4687-bdf8-eee913d85d62", "AdmoSistema", "ADMOSISTEMA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "259ac90f-f3cb-4064-b9c2-2d20325d2b6d", 0, "5e5a1bf0-e5bc-444d-a7e4-659fff576ffc", "hikdul.dev@gmail.com", true, false, null, "HIKDUL.DEV@GMAIL.COM", "HIKDUL.DEV@GMAIL.COM", "AQAAAAEAACcQAAAAEH0Ee8+upF7pWzVGWaC3D/MWZvBuIgTpWedtCRxnsSTCt9a2ikkRSnLVU6dzhlX5cQ==", "+51 931 084 717", true, "3b28e317-81e2-40fb-90b3-71cd230a2e5a", false, "hikdul.dev@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8a7c427f-c478-4dd7-99e3-e4caca1178ce", "259ac90f-f3cb-4064-b9c2-2d20325d2b6d" });
        }
    }
}
