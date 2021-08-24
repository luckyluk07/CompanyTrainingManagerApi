using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyTrainingManagerApi.Migrations
{
    public partial class addIsOnlineAttributeToTrainingDefinitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsDefinitions_Addresses_AddressId",
                table: "TrainingsDefinitions");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "TrainingsDefinitions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "TrainingsDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsDefinitions_Addresses_AddressId",
                table: "TrainingsDefinitions",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingsDefinitions_Addresses_AddressId",
                table: "TrainingsDefinitions");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "TrainingsDefinitions");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "TrainingsDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingsDefinitions_Addresses_AddressId",
                table: "TrainingsDefinitions",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
