using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class InitialCreateV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Project_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Budget = table.Column<int>(nullable: false),
                    Company_ID = table.Column<int>(nullable: false),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Employer_ID = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Freelance_ID = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: false),
                    ProjectPrice = table.Column<int>(nullable: false),
                    ProjectStatus = table.Column<bool>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    Timelength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Project_ID);
                    table.ForeignKey(
                        name: "FK_Project_Company_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Company",
                        principalColumn: "Company_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Employer_Employer_ID",
                        column: x => x.Employer_ID,
                        principalTable: "Employer",
                        principalColumn: "Employer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Freelance_Freelance_ID",
                        column: x => x.Freelance_ID,
                        principalTable: "Freelance",
                        principalColumn: "Freelance_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkill",
                columns: table => new
                {
                    ProjectSkill_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Project_ID = table.Column<int>(nullable: false),
                    Skill_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkill", x => x.ProjectSkill_ID);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Project_Project_ID",
                        column: x => x.Project_ID,
                        principalTable: "Project",
                        principalColumn: "Project_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Skill_Skill_ID",
                        column: x => x.Skill_ID,
                        principalTable: "Skill",
                        principalColumn: "Skill_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_Company_ID",
                table: "Project",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Employer_ID",
                table: "Project",
                column: "Employer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Freelance_ID",
                table: "Project",
                column: "Freelance_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_Project_ID",
                table: "ProjectSkill",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_Skill_ID",
                table: "ProjectSkill",
                column: "Skill_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
