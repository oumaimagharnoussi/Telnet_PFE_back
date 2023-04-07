using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class enumgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Groupss_GroupsgroupId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Groupss");

            migrationBuilder.DropIndex(
                name: "IX_users_GroupsgroupId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "GroupsgroupId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "GroupsgroupId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groupss",
                columns: table => new
                {
                    groupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupss", x => x.groupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_GroupsgroupId",
                table: "users",
                column: "GroupsgroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Groupss_GroupsgroupId",
                table: "users",
                column: "GroupsgroupId",
                principalTable: "Groupss",
                principalColumn: "groupId");
        }
    }
}
