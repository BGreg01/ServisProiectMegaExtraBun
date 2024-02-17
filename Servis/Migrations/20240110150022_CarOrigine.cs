using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servis.Migrations
{
    /// <inheritdoc />
    public partial class CarOrigine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Origine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarOrigine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    OrigineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOrigine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarOrigine_Car_CarID",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarOrigine_Origine_OrigineID",
                        column: x => x.OrigineID,
                        principalTable: "Origine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOrigine_CarID",
                table: "CarOrigine",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarOrigine_OrigineID",
                table: "CarOrigine",
                column: "OrigineID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOrigine");

            migrationBuilder.DropTable(
                name: "Origine");
        }
    }
}
