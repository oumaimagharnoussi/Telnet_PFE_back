using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class pass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activityId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "userPassword",
                table: "users",
                newName: "password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "userPassword");

            migrationBuilder.AddColumn<int>(
                name: "activityId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
