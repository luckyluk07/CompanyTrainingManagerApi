using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyTrainingManagerApi.Migrations
{
    public partial class addRelationToUserAndWorkers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsAUserId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_IsAUserId",
                table: "Workers",
                column: "IsAUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Users_IsAUserId",
                table: "Workers",
                column: "IsAUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Users_IsAUserId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_IsAUserId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "IsAUserId",
                table: "Workers");
        }
    }
}
