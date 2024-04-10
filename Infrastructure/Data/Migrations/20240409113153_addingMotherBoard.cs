using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingMotherBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "motherboards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChipSet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamSlot = table.Column<int>(type: "int", nullable: false),
                    Wifi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motherboards", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "motherboards");
        }
    }
}
