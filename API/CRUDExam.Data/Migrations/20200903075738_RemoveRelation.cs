using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExam.Data.Migrations
{
    public partial class RemoveRelation : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "PermissionTypeID",
                table: "Permission",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionTypeID",
                table: "Permission",
                column: "PermissionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_PermissionType_PermissionTypeID",
                table: "Permission",
                column: "PermissionTypeID",
                principalTable: "PermissionType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_PermissionType_PermissionTypeID",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_PermissionTypeID",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "PermissionTypeID",
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
