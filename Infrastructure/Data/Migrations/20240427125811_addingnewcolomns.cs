using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingnewcolomns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "PowerSupplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Efficiency",
                table: "PowerSupplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modular",
                table: "PowerSupplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PowerSupplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wattage",
                table: "PowerSupplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CPUCoolers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Noise_Level",
                table: "CPUCoolers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rpm",
                table: "CPUCoolers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "CPUCoolers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Side_Panel",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "Efficiency",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "Modular",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "Wattage",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "CPUCoolers");

            migrationBuilder.DropColumn(
                name: "Noise_Level",
                table: "CPUCoolers");

            migrationBuilder.DropColumn(
                name: "Rpm",
                table: "CPUCoolers");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "CPUCoolers");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Side_Panel",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cases");
        }
    }
}
