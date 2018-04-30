using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class InitialCreateV9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "FreelanceSkill");

            migrationBuilder.DropColumn(
                name: "Date_Update",
                table: "FreelanceSkill");

            migrationBuilder.DropColumn(
                name: "DelStatus",
                table: "FreelanceSkill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "FreelanceSkill",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Update",
                table: "FreelanceSkill",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "DelStatus",
                table: "FreelanceSkill",
                nullable: false,
                defaultValue: false);
        }
    }
}
