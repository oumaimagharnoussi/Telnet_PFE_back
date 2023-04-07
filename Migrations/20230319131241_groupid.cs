using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class groupid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Activites_ActivitiesactivityId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Group",
                table: "users",
                newName: "groupId");

            migrationBuilder.RenameColumn(
                name: "ActivitiesactivityId",
                table: "users",
                newName: "activityId1");

            migrationBuilder.RenameIndex(
                name: "IX_users_ActivitiesactivityId",
                table: "users",
                newName: "IX_users_activityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Activites_activityId1",
                table: "users",
                column: "activityId1",
                principalTable: "Activites",
                principalColumn: "activityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Activites_activityId1",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "groupId",
                table: "users",
                newName: "Group");

            migrationBuilder.RenameColumn(
                name: "activityId1",
                table: "users",
                newName: "ActivitiesactivityId");

            migrationBuilder.RenameIndex(
                name: "IX_users_activityId1",
                table: "users",
                newName: "IX_users_ActivitiesactivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Activites_ActivitiesactivityId",
                table: "users",
                column: "ActivitiesactivityId",
                principalTable: "Activites",
                principalColumn: "activityId");
        }
    }
}
