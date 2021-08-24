using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyTrainingManagerApi.Migrations
{
    public partial class addRelationToAddressAndWorkers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_AddressId",
                table: "Workers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Addresses_AddressId",
                table: "Workers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Addresses_AddressId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_AddressId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Workers");
        }
    }
}
