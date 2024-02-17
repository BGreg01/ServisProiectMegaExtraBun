using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servis.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MecanicID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mecanic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MecanicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanic", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_MecanicID",
                table: "Car",
                column: "MecanicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Mecanic_MecanicID",
                table: "Car",
                column: "MecanicID",
                principalTable: "Mecanic",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Mecanic_MecanicID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Mecanic");

            migrationBuilder.DropIndex(
                name: "IX_Car_MecanicID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "MecanicID",
                table: "Car");
        }
    }
}
