using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExam.Data.Migrations
{
    public partial class FixedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 1, "Enfermedad" });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 2, "Diligencias" });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "ID", "Description" },
                values: new object[] { 3, "Descanso" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PermissionType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PermissionType",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
