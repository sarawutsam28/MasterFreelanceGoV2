using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class InitialCreateV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FreelanceRating_Project_ID",
                table: "FreelanceRating");

            migrationBuilder.DropIndex(
                name: "IX_EmployerRating_Project_ID",
                table: "EmployerRating");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceRating_Project_ID",
                table: "FreelanceRating",
                column: "Project_ID",
                unique: true,
                filter: "[Project_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerRating_Project_ID",
                table: "EmployerRating",
                column: "Project_ID",
                unique: true,
                filter: "[Project_ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FreelanceRating_Project_ID",
                table: "FreelanceRating");

            migrationBuilder.DropIndex(
                name: "IX_EmployerRating_Project_ID",
                table: "EmployerRating");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceRating_Project_ID",
                table: "FreelanceRating",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerRating_Project_ID",
                table: "EmployerRating",
                column: "Project_ID");
        }
    }
}
