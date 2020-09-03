using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExam.Data.Migrations
{
    public partial class AddRelationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_PermissionType_FPermissionType",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_FPermissionType",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "FPermissionType",
                table: "Permission");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Permission_Type",
                table: "Permission",
                column: "Permission_Type");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_PermissionType_Permission_Type",
                table: "Permission",
                column: "Permission_Type",
                principalTable: "PermissionType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_PermissionType_Permission_Type",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_Permission_Type",
                table: "Permission");

            migrationBuilder.AddColumn<int>(
                name: "FPermissionType",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_FPermissionType",
                table: "Permission",
                column: "FPermissionType");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_PermissionType_FPermissionType",
                table: "Permission",
                column: "FPermissionType",
                principalTable: "PermissionType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
