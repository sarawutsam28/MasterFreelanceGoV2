using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class dbV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceSkill_Freelance_Freelance_ID",
                table: "FreelanceSkill");

            migrationBuilder.AlterColumn<int>(
                name: "Freelance_ID",
                table: "FreelanceSkill",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FreelanceSkill_Freelance_Freelance_ID",
                table: "FreelanceSkill",
                column: "Freelance_ID",
                principalTable: "Freelance",
                principalColumn: "Freelance_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelanceSkill_Freelance_Freelance_ID",
                table: "FreelanceSkill");

            migrationBuilder.AlterColumn<int>(
                name: "Freelance_ID",
                table: "FreelanceSkill",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FreelanceSkill_Freelance_Freelance_ID",
                table: "FreelanceSkill",
                column: "Freelance_ID",
                principalTable: "Freelance",
                principalColumn: "Freelance_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
