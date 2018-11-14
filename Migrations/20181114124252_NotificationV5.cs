using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class NotificationV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Project_ID",
                table: "Notification",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Project_ID",
                table: "Notification",
                column: "Project_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Project_Project_ID",
                table: "Notification",
                column: "Project_ID",
                principalTable: "Project",
                principalColumn: "Project_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Project_Project_ID",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_Project_ID",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Project_ID",
                table: "Notification");
        }
    }
}
