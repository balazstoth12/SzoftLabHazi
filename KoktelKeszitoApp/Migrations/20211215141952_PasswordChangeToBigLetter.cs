using Microsoft.EntityFrameworkCore.Migrations;

namespace KoktelKeszitoApp.Migrations
{
    public partial class PasswordChangeToBigLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");
        }
    }
}
