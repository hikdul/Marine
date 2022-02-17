using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marine.Migrations
{
    /// <summary>
    /// para agregar la tabla de almacen
    /// </summary>
    public partial class almacen : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Productoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.id);
                    table.ForeignKey(
                        name: "FK_Almacen_Productos_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9",
                column: "ConcurrencyStamp",
                value: "a857662a-95ea-418a-9b17-27a2fd2215f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e1b4175-cf9c-4fd2-ab0d-987f5af67434",
                column: "ConcurrencyStamp",
                value: "a87f1248-58ab-409b-8aac-7a1054cea2c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f36838c-81ae-4d20-83a0-b867fd489771",
                column: "ConcurrencyStamp",
                value: "c97d1d1f-08f3-43a2-acb5-25b5045fc195");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b2b621-d728-428e-a2be-bc8d30aed151",
                column: "ConcurrencyStamp",
                value: "14e646b9-4073-4317-9d32-6d6b0f8924a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "445f6fc1-5dd4-4c32-af61-19a91b8f1367",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c76aa8f-390a-4602-aba7-2b7039e235fe", "AQAAAAEAACcQAAAAEBnCSVusp8GP3tDb+WWTgCL8mIDjtnH7Scr6+PrD0vORfN87i7vFZunsP12uEBu8Lg==", "5883f220-c3b8-4c63-b0c6-175649f4694c" });

            migrationBuilder.CreateIndex(
                name: "IX_Almacen_Productoid",
                table: "Almacen",
                column: "Productoid");
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Almacen");

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
        }
    }
}
