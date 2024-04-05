using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOwnersRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersOwnedPlants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsersOwnedPlants",
                columns: table => new
                {
                    OwnersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlantsOwnedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersOwnedPlants", x => new { x.OwnersId, x.PlantsOwnedId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersOwnedPlants_ApplicationUsers_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersOwnedPlants_Plants_PlantsOwnedId",
                        column: x => x.PlantsOwnedId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersOwnedPlants_PlantsOwnedId",
                table: "ApplicationUsersOwnedPlants",
                column: "PlantsOwnedId");
        }
    }
}
