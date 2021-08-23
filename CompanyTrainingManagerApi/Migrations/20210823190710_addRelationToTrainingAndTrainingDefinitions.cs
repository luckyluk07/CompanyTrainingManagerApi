using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyTrainingManagerApi.Migrations
{
    public partial class addRelationToTrainingAndTrainingDefinitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingDefinitionId",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingDefinitionId",
                table: "Trainings",
                column: "TrainingDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingsDefinitions_TrainingDefinitionId",
                table: "Trainings",
                column: "TrainingDefinitionId",
                principalTable: "TrainingsDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingsDefinitions_TrainingDefinitionId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_TrainingDefinitionId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingDefinitionId",
                table: "Trainings");
        }
    }
}
