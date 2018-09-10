using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class dbV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeProject_ID",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeProject",
                columns: table => new
                {
                    TypeProject_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date_Create = table.Column<DateTime>(nullable: false),
                    Date_Update = table.Column<DateTime>(nullable: false),
                    DelStatus = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TypeProjectDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProject", x => x.TypeProject_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_TypeProject_ID",
                table: "Project",
                column: "TypeProject_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_TypeProject_TypeProject_ID",
                table: "Project",
                column: "TypeProject_ID",
                principalTable: "TypeProject",
                principalColumn: "TypeProject_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_TypeProject_TypeProject_ID",
                table: "Project");

            migrationBuilder.DropTable(
                name: "TypeProject");

            migrationBuilder.DropIndex(
                name: "IX_Project_TypeProject_ID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TypeProject_ID",
                table: "Project");
        }
    }
}
