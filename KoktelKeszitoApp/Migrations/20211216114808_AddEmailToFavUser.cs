using Microsoft.EntityFrameworkCore.Migrations;

namespace KoktelKeszitoApp.Migrations
{
    public partial class AddEmailToFavUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "FavouriteUser",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FavouriteUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "FavouriteUser");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "FavouriteUser",
                newName: "password");
        }
    }
}
