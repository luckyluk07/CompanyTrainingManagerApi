using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyTrainingManagerApi.Migrations
{
    public partial class addRelationToCoachAndTrainingDefinitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "TrainingsDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingsDefinitions_CoachId",
                table: "TrainingsDefinitions",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsDefinitions_Coaches_CoachId",
                table: "TrainingsDefinitions",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsDefinitions_Coaches_CoachId",
                table: "TrainingsDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_TrainingsDefinitions_CoachId",
                table: "TrainingsDefinitions");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "TrainingsDefinitions");
        }
    }
}
