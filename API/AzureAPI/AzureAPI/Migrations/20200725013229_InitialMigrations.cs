using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureAPI.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    location = table.Column<string>(maxLength: 150, nullable: true),
                    password = table.Column<string>(maxLength: 128, nullable: false),
                    salt = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserID", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserID");
        }
    }
}
