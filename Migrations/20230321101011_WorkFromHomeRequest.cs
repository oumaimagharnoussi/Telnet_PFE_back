using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class WorkFromHomeRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Activites_activityId1",
                table: "users");

            migrationBuilder.DropTable(
                name: "Activites");

            migrationBuilder.DropIndex(
                name: "IX_users_activityId1",
                table: "users");

            migrationBuilder.DropColumn(
                name: "activityId1",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "activityId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkFromHomeRequests",
                columns: table => new
                {
                    workHomeRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    activityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false),
                    dayNumber = table.Column<int>(type: "int", nullable: false),
                    halfDay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFromHomeRequests", x => x.workHomeRequestId);
                    table.ForeignKey(
                        name: "FK_WorkFromHomeRequests_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkFromHomeRequests_userId",
                table: "WorkFromHomeRequests",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkFromHomeRequests");

            migrationBuilder.DropColumn(
                name: "activityId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "activityId1",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    activityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.activityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_activityId1",
                table: "users",
                column: "activityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Activites_activityId1",
                table: "users",
                column: "activityId1",
                principalTable: "Activites",
                principalColumn: "activityId");
        }
    }
}
