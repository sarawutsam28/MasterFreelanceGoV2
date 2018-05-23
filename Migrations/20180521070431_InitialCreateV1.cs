using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class InitialCreateV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Company_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company_Address = table.Column<string>(nullable: true),
                    Company_Name = table.Column<string>(nullable: false),
                    Company_TaxID = table.Column<string>(nullable: true),
                    Company_Tel = table.Column<string>(nullable: true),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Facebook = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    imgName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Company_ID);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Employer_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Facebook = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: false),
                    ID_Card = table.Column<string>(nullable: false),
                    Line = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    imgName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Employer_ID);
                });

            migrationBuilder.CreateTable(
                name: "Freelance",
                columns: table => new
                {
                    Freelance_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Facebook = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: false),
                    ID_Card = table.Column<string>(nullable: false),
                    ImgName = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelance", x => x.Freelance_ID);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Skill_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Skill_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Skill_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Project_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Budget = table.Column<int>(nullable: false),
                    Company_ID = table.Column<int>(nullable: true),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Employer_ID = table.Column<int>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Freelance_ID = table.Column<int>(nullable: true),
                    ProjectName = table.Column<string>(nullable: false),
                    ProjectPrice = table.Column<int>(nullable: false),
                    ProjectStatus = table.Column<bool>(nullable: false),
                    ProjectTimeOut = table.Column<DateTime>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Employer_Employer_ID",
                        column: x => x.Employer_ID,
                        principalTable: "Employer",
                        principalColumn: "Employer_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Freelance_Freelance_ID",
                        column: x => x.Freelance_ID,
                        principalTable: "Freelance",
                        principalColumn: "Freelance_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FreelanceSkill",
                columns: table => new
                {
                    FreelanceSkill_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Freelance_ID = table.Column<int>(nullable: false),
                    Skill_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelanceSkill", x => x.FreelanceSkill_ID);
                    table.ForeignKey(
                        name: "FK_FreelanceSkill_Freelance_Freelance_ID",
                        column: x => x.Freelance_ID,
                        principalTable: "Freelance",
                        principalColumn: "Freelance_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelanceSkill_Skill_Skill_ID",
                        column: x => x.Skill_ID,
                        principalTable: "Skill",
                        principalColumn: "Skill_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    Auction_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuctionTime = table.Column<int>(nullable: false),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Freelance_ID = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Project_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.Auction_ID);
                    table.ForeignKey(
                        name: "FK_Auction_Freelance_Freelance_ID",
                        column: x => x.Freelance_ID,
                        principalTable: "Freelance",
                        principalColumn: "Freelance_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_Project_Project_ID",
                        column: x => x.Project_ID,
                        principalTable: "Project",
                        principalColumn: "Project_ID",
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
                name: "IX_Auction_Freelance_ID",
                table: "Auction",
                column: "Freelance_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_Project_ID",
                table: "Auction",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Freelance_UserName_Email",
                table: "Freelance",
                columns: new[] { "UserName", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceSkill_Freelance_ID",
                table: "FreelanceSkill",
                column: "Freelance_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceSkill_Skill_ID",
                table: "FreelanceSkill",
                column: "Skill_ID");

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
                name: "Auction");

            migrationBuilder.DropTable(
                name: "FreelanceSkill");

            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "Freelance");
        }
    }
}
