using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyTrainingManagerApi.Migrations
{
    public partial class addRelationToAddressAndTrainingDefinitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "TrainingsDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingsDefinitions_AddressId",
                table: "TrainingsDefinitions",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsDefinitions_Addresses_AddressId",
                table: "TrainingsDefinitions",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsDefinitions_Addresses_AddressId",
                table: "TrainingsDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_TrainingsDefinitions_AddressId",
                table: "TrainingsDefinitions");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "TrainingsDefinitions");
        }
    }
}
