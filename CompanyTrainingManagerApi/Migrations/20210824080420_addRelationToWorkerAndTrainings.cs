using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyTrainingManagerApi.Migrations
{
    public partial class addRelationToWorkerAndTrainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingWorker",
                columns: table => new
                {
                    TrainingsId = table.Column<int>(type: "int", nullable: false),
                    WorkersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingWorker", x => new { x.TrainingsId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_TrainingWorker_Trainings_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingWorker_WorkersId",
                table: "TrainingWorker",
                column: "WorkersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingWorker");
        }
    }
}
