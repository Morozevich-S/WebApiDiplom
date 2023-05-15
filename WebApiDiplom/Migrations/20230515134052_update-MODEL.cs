using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDiplom.Migrations
{
    public partial class updateMODEL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientBrandCars",
                table: "ClientBrandCars");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClientBrandCars",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientBrandCars",
                table: "ClientBrandCars",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBrandCars_ClientId",
                table: "ClientBrandCars",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientBrandCars",
                table: "ClientBrandCars");

            migrationBuilder.DropIndex(
                name: "IX_ClientBrandCars_ClientId",
                table: "ClientBrandCars");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClientBrandCars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientBrandCars",
                table: "ClientBrandCars",
                columns: new[] { "ClientId", "BrandCarId" });
        }
    }
}
