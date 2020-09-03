using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExam.Data.Migrations
{
    public partial class FixedPermissionTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permision_PermissionType_FPermissionType",
                table: "Permision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permision",
                table: "Permision");

            migrationBuilder.RenameTable(
                name: "Permision",
                newName: "Permission");

            migrationBuilder.RenameIndex(
                name: "IX_Permision_FPermissionType",
                table: "Permission",
                newName: "IX_Permission_FPermissionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_PermissionType_FPermissionType",
                table: "Permission",
                column: "FPermissionType",
                principalTable: "PermissionType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_PermissionType_FPermissionType",
                table: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permision");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_FPermissionType",
                table: "Permision",
                newName: "IX_Permision_FPermissionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permision",
                table: "Permision",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permision_PermissionType_FPermissionType",
                table: "Permision",
                column: "FPermissionType",
                principalTable: "PermissionType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
