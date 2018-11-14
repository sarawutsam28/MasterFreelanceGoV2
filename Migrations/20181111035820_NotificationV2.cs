using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class NotificationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Company_Company_ID",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Employer_Employer_ID",
                table: "Notification");

            migrationBuilder.AlterColumn<int>(
                name: "Employer_ID",
                table: "Notification",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Company_ID",
                table: "Notification",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Company_Company_ID",
                table: "Notification",
                column: "Company_ID",
                principalTable: "Company",
                principalColumn: "Company_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Employer_Employer_ID",
                table: "Notification",
                column: "Employer_ID",
                principalTable: "Employer",
                principalColumn: "Employer_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Company_Company_ID",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Employer_Employer_ID",
                table: "Notification");

            migrationBuilder.AlterColumn<int>(
                name: "Employer_ID",
                table: "Notification",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Company_ID",
                table: "Notification",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Company_Company_ID",
                table: "Notification",
                column: "Company_ID",
                principalTable: "Company",
                principalColumn: "Company_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Employer_Employer_ID",
                table: "Notification",
                column: "Employer_ID",
                principalTable: "Employer",
                principalColumn: "Employer_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
