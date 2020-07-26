using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureAPI.Migrations
{
    public partial class InitalMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interaction",
                columns: table => new
                {
                    Interaction_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inter_date = table.Column<DateTime>(type: "date", nullable: false),
                    id1 = table.Column<int>(nullable: false),
                    id2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaction", x => x.Interaction_id);
                });

            migrationBuilder.CreateTable(
                name: "UserID",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(maxLength: 20, nullable: false),
                    lname = table.Column<string>(maxLength: 20, nullable: false),
                    phone = table.Column<string>(maxLength: 14, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    location = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserID", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interaction");

            migrationBuilder.DropTable(
                name: "UserID");
        }
    }
}
