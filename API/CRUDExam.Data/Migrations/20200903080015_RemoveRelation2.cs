using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExam.Data.Migrations
{
    public partial class RemoveRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionTypeID",
                table: "Permission",
                type: "int",
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
    }
}
