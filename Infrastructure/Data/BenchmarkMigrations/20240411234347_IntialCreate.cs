using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.BenchmarkMigrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPUsbenchmark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CpuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingleScore = table.Column<int>(type: "int", nullable: true),
                    MultiScore = table.Column<int>(type: "int", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Threads = table.Column<int>(type: "int", nullable: true),
                    BaseClock = table.Column<double>(type: "float", nullable: true),
                    TurboClock = table.Column<double>(type: "float", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUsbenchmark", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPUsbenchmark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GpuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    G3DMark = table.Column<int>(type: "int", nullable: true),
                    G2DMark = table.Column<int>(type: "int", nullable: true),
                    GpuValue = table.Column<double>(type: "float", nullable: true),
                    TDP = table.Column<int>(type: "int", nullable: true),
                    PowerPerformance = table.Column<double>(type: "float", nullable: true),
                    TestDate = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUsbenchmark", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPUsbenchmark");

            migrationBuilder.DropTable(
                name: "GPUsbenchmark");
        }
    }
}
