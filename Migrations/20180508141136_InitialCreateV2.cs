using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class InitialCreateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Company_Company_ID",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employer_Employer_ID",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Freelance_Freelance_ID",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "Freelance_ID",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Employer_ID",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Company_ID",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Company_Company_ID",
                table: "Project",
                column: "Company_ID",
                principalTable: "Company",
                principalColumn: "Company_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employer_Employer_ID",
                table: "Project",
                column: "Employer_ID",
                principalTable: "Employer",
                principalColumn: "Employer_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Freelance_Freelance_ID",
                table: "Project",
                column: "Freelance_ID",
                principalTable: "Freelance",
                principalColumn: "Freelance_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Company_Company_ID",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employer_Employer_ID",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Freelance_Freelance_ID",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "Freelance_ID",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Employer_ID",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Company_ID",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Company_Company_ID",
                table: "Project",
                column: "Company_ID",
                principalTable: "Company",
                principalColumn: "Company_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employer_Employer_ID",
                table: "Project",
                column: "Employer_ID",
                principalTable: "Employer",
                principalColumn: "Employer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Freelance_Freelance_ID",
                table: "Project",
                column: "Freelance_ID",
                principalTable: "Freelance",
                principalColumn: "Freelance_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
