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
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: false),
                    facebook = table.Column<string>(nullable: true),
                    fullName = table.Column<string>(nullable: false),
                    imgName = table.Column<string>(nullable: true),
                    line = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false),
                    skill = table.Column<string>(nullable: true),
                    telephoneNumber = table.Column<string>(nullable: true),
                    uersTypes = table.Column<string>(nullable: false),
                    userName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
