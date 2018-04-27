using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class InitialCreateV4 : Migration
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
                name: "FreelanceSkill",
                columns: table => new
                {
                    FreelanceSkill_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceSkill_Freelance_ID",
                table: "FreelanceSkill",
                column: "Freelance_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FreelanceSkill_Skill_ID",
                table: "FreelanceSkill",
                column: "Skill_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "FreelanceSkill");

            migrationBuilder.DropTable(
                name: "Freelance");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
