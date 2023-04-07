using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class WorkFromHomeRequest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkFromHomeRequests_users_userId",
                table: "WorkFromHomeRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkFromHomeRequests_userId",
                table: "WorkFromHomeRequests");

            migrationBuilder.AlterColumn<int>(
                name: "state",
                table: "WorkFromHomeRequests",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "halfDay",
                table: "WorkFromHomeRequests",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "dayNumber",
                table: "WorkFromHomeRequests",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "activityName",
                table: "WorkFromHomeRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkFromHomeRequests_userId_startDate_endDate",
                table: "WorkFromHomeRequests",
                columns: new[] { "userId", "startDate", "endDate" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFromHomeRequests_Users",
                table: "WorkFromHomeRequests",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkFromHomeRequests_Users",
                table: "WorkFromHomeRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkFromHomeRequests_userId_startDate_endDate",
                table: "WorkFromHomeRequests");

            migrationBuilder.AlterColumn<int>(
                name: "state",
                table: "WorkFromHomeRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "halfDay",
                table: "WorkFromHomeRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "dayNumber",
                table: "WorkFromHomeRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "activityName",
                table: "WorkFromHomeRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFromHomeRequests_userId",
                table: "WorkFromHomeRequests",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFromHomeRequests_users_userId",
                table: "WorkFromHomeRequests",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
