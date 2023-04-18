using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDiplom.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientBrandCars_BrandCars_BrandId",
                table: "ClientBrandCars");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "CarModels");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "ClientBrandCars",
                newName: "BrandCarId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientBrandCars_BrandId",
                table: "ClientBrandCars",
                newName: "IX_ClientBrandCars_BrandCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientBrandCars_BrandCars_BrandCarId",
                table: "ClientBrandCars",
                column: "BrandCarId",
                principalTable: "BrandCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientBrandCars_BrandCars_BrandCarId",
                table: "ClientBrandCars");

            migrationBuilder.RenameColumn(
                name: "BrandCarId",
                table: "ClientBrandCars",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientBrandCars_BrandCarId",
                table: "ClientBrandCars",
                newName: "IX_ClientBrandCars_BrandId");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "CarModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "CarModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientBrandCars_BrandCars_BrandId",
                table: "ClientBrandCars",
                column: "BrandId",
                principalTable: "BrandCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
