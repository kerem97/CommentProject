﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentProject.DataAccessLayer.Migrations
{
    public partial class mig_add_appuser_title_rela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_AppUserID",
                table: "Titles",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_AspNetUsers_AppUserID",
                table: "Titles",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_AspNetUsers_AppUserID",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_AppUserID",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Titles");
        }
    }
}
