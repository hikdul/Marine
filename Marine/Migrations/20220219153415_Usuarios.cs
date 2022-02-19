using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marine.Migrations
{
    /// <summary>
    /// para generar los datos de usuario
    /// </summary>
    public partial class Usuarios : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rut = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Userid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_AspNetUsuario_AspNetUsers_Userid",
                        column: x => x.Userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsuario_Userid",
                table: "AspNetUsuario",
                column: "Userid");
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUsuario");

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
        }
    }
}
