﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExam.Data.Migrations
{
    public partial class AddRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FPermissionType",
                table: "Permission",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
