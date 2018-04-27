using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelanceGoMasterV2.Migrations
{
    public partial class InitialCreateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "skill",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Employer");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Employer",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "telephoneNumber",
                table: "Employer",
                newName: "TelephoneNumber");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Employer",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "line",
                table: "Employer",
                newName: "Line");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Employer",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "facebook",
                table: "Employer",
                newName: "Facebook");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Employer",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "uersTypes",
                table: "Employer",
                newName: "ID_Card");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Employer",
                newName: "Employer_ID");

            migrationBuilder.AddColumn<bool>(
                name: "DelStatus",
                table: "Employer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employer",
                table: "Employer",
                column: "Employer_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employer",
                table: "Employer");

            migrationBuilder.DropColumn(
                name: "DelStatus",
                table: "Employer");

            migrationBuilder.RenameTable(
                name: "Employer",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "Users",
                newName: "telephoneNumber");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Line",
                table: "Users",
                newName: "line");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "Facebook",
                table: "Users",
                newName: "facebook");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "ID_Card",
                table: "Users",
                newName: "uersTypes");

            migrationBuilder.RenameColumn(
                name: "Employer_ID",
                table: "Users",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "skill",
                table: "Users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");
        }
    }
}
