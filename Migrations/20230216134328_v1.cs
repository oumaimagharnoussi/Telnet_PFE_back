using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activite_users_userId",
                table: "Activite");

            migrationBuilder.DropForeignKey(
                name: "FK_Groupe_users_userId",
                table: "Groupe");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_users_userId",
                table: "Site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groupe",
                table: "Groupe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activite",
                table: "Activite");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "Sites");

            migrationBuilder.RenameTable(
                name: "Groupe",
                newName: "Groupes");

            migrationBuilder.RenameTable(
                name: "Activite",
                newName: "Activites");

            migrationBuilder.RenameIndex(
                name: "IX_Site_userId",
                table: "Sites",
                newName: "IX_Sites_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Groupe_userId",
                table: "Groupes",
                newName: "IX_Groupes_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Activite_userId",
                table: "Activites",
                newName: "IX_Activites_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sites",
                table: "Sites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groupes",
                table: "Groupes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activites",
                table: "Activites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activites_users_userId",
                table: "Activites",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_users_userId",
                table: "Groupes",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_users_userId",
                table: "Sites",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activites_users_userId",
                table: "Activites");

            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_users_userId",
                table: "Groupes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_users_userId",
                table: "Sites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sites",
                table: "Sites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groupes",
                table: "Groupes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activites",
                table: "Activites");

            migrationBuilder.RenameTable(
                name: "Sites",
                newName: "Site");

            migrationBuilder.RenameTable(
                name: "Groupes",
                newName: "Groupe");

            migrationBuilder.RenameTable(
                name: "Activites",
                newName: "Activite");

            migrationBuilder.RenameIndex(
                name: "IX_Sites_userId",
                table: "Site",
                newName: "IX_Site_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Groupes_userId",
                table: "Groupe",
                newName: "IX_Groupe_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Activites_userId",
                table: "Activite",
                newName: "IX_Activite_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groupe",
                table: "Groupe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activite",
                table: "Activite",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activite_users_userId",
                table: "Activite",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groupe_users_userId",
                table: "Groupe",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_users_userId",
                table: "Site",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
