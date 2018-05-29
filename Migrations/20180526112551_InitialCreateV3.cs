using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class InitialCreateV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployerRating",
                columns: table => new
                {
                    Rating_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company_ID = table.Column<int>(nullable: true),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Employer_ID = table.Column<int>(nullable: true),
                    Freelance_ID = table.Column<int>(nullable: false),
                    Project_ID = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    TextReview = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerRating", x => x.Rating_ID);
                    table.ForeignKey(
                        name: "FK_EmployerRating_Company_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Company",
                        principalColumn: "Company_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployerRating_Employer_Employer_ID",
                        column: x => x.Employer_ID,
                        principalTable: "Employer",
                        principalColumn: "Employer_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployerRating_Freelance_Freelance_ID",
                        column: x => x.Freelance_ID,
                        principalTable: "Freelance",
                        principalColumn: "Freelance_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployerRating_Project_Project_ID",
                        column: x => x.Project_ID,
                        principalTable: "Project",
                        principalColumn: "Project_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployerRating_Company_ID",
                table: "EmployerRating",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerRating_Employer_ID",
                table: "EmployerRating",
                column: "Employer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerRating_Freelance_ID",
                table: "EmployerRating",
                column: "Freelance_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerRating_Project_ID",
                table: "EmployerRating",
                column: "Project_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployerRating");
        }
    }
}
