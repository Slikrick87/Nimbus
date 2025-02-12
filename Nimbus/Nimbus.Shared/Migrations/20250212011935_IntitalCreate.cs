using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus.Shared.Migrations
{
    /// <inheritdoc />
    public partial class IntitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RouteId = table.Column<int>(type: "INTEGER", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    StreetNumber = table.Column<int>(name: "Street Number", type: "INTEGER", nullable: false),
                    ZipCode = table.Column<int>(name: "Zip Code", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    truckId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mileage = table.Column<int>(type: "INTEGER", nullable: false),
                    routeId = table.Column<int>(type: "INTEGER", nullable: false),
                    tireFD = table.Column<int>(type: "INTEGER", nullable: false),
                    tireFP = table.Column<int>(type: "INTEGER", nullable: false),
                    tireRD = table.Column<int>(type: "INTEGER", nullable: false),
                    tireRP = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trucks_Routes_routeId",
                        column: x => x.routeId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_RouteId",
                table: "Addresses",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_truckId",
                table: "Routes",
                column: "truckId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_routeId",
                table: "Trucks",
                column: "routeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_RouteId",
                table: "Addresses",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trucks_truckId",
                table: "Routes",
                column: "truckId",
                principalTable: "Trucks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Routes_routeId",
                table: "Trucks");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
