using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExam.Data.Migrations
{
    public partial class FixedPermissionTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permision_PermissionType_FPermisionType",
                table: "Permision");

            migrationBuilder.DropIndex(
                name: "IX_Permision_FPermisionType",
                table: "Permision");

            migrationBuilder.DropColumn(
                name: "FPermisionType",
                table: "Permision");

            migrationBuilder.AddColumn<int>(
                name: "FPermissionType",
                table: "Permision",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Permision_FPermissionType",
                table: "Permision",
                column: "FPermissionType");

            migrationBuilder.AddForeignKey(
                name: "FK_Permision_PermissionType_FPermissionType",
                table: "Permision",
                column: "FPermissionType",
                principalTable: "PermissionType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permision_PermissionType_FPermissionType",
                table: "Permision");

            migrationBuilder.DropIndex(
                name: "IX_Permision_FPermissionType",
                table: "Permision");

            migrationBuilder.DropColumn(
                name: "FPermissionType",
                table: "Permision");

            migrationBuilder.AddColumn<int>(
                name: "FPermisionType",
                table: "Permision",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Permision_FPermisionType",
                table: "Permision",
                column: "FPermisionType");

            migrationBuilder.AddForeignKey(
                name: "FK_Permision_PermissionType_FPermisionType",
                table: "Permision",
                column: "FPermisionType",
                principalTable: "PermissionType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
