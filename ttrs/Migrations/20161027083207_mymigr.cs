using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ttrs.Migrations
{
    public partial class mymigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "computer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    macaddress = table.Column<byte[]>(type: "binary(8)", nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "software",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 511, nullable: false),
                    productivity_level = table.Column<int>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_software", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usage",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    software_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    computer_id = table.Column<int>(nullable: false),
                    seconds_spent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usage", x => new { x.id, x.software_id, x.date, x.computer_id });
                });

            migrationBuilder.CreateTable(
                name: "usage_buffer",
                columns: table => new
                {
                    computer_id = table.Column<int>(nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    used_program = table.Column<string>(maxLength: 511, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usage_buffer", x => new { x.computer_id, x.timestamp });
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_uid = table.Column<Guid>(nullable: false),
                    password = table.Column<byte[]>(type: "binary(64)", nullable: false),
                    username = table.Column<string>(maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_uid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computer");

            migrationBuilder.DropTable(
                name: "software");

            migrationBuilder.DropTable(
                name: "usage");

            migrationBuilder.DropTable(
                name: "usage_buffer");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
