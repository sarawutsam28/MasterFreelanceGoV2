using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class Notification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Notification_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company_ID = table.Column<int>(nullable: false),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Employer_ID = table.Column<int>(nullable: false),
                    Freelance_ID = table.Column<int>(nullable: false),
                    NotificationCode = table.Column<int>(nullable: false),
                    NotificationText = table.Column<string>(nullable: false),
                    ReadStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Notification_ID);
                    table.ForeignKey(
                        name: "FK_Notification_Company_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Company",
                        principalColumn: "Company_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_Employer_Employer_ID",
                        column: x => x.Employer_ID,
                        principalTable: "Employer",
                        principalColumn: "Employer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_Freelance_Freelance_ID",
                        column: x => x.Freelance_ID,
                        principalTable: "Freelance",
                        principalColumn: "Freelance_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Company_ID",
                table: "Notification",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Employer_ID",
                table: "Notification",
                column: "Employer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Freelance_ID",
                table: "Notification",
                column: "Freelance_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");
        }
    }
}
