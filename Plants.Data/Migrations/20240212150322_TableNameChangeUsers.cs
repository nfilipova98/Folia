namespace Plants.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class TableNameChangeUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetPlant_PetsPlants_PetsId",
                table: "PetPlant");

            migrationBuilder.DropForeignKey(
                name: "FK_PetUserConfiguration_PetsPlants_PetsId",
                table: "PetUserConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetsPlants",
                table: "PetsPlants");

            migrationBuilder.RenameTable(
                name: "PetsPlants",
                newName: "Pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetPlant_Pets_PetsId",
                table: "PetPlant",
                column: "PetsId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetUserConfiguration_Pets_PetsId",
                table: "PetUserConfiguration",
                column: "PetsId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetPlant_Pets_PetsId",
                table: "PetPlant");

            migrationBuilder.DropForeignKey(
                name: "FK_PetUserConfiguration_Pets_PetsId",
                table: "PetUserConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "PetsPlants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetsPlants",
                table: "PetsPlants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetPlant_PetsPlants_PetsId",
                table: "PetPlant",
                column: "PetsId",
                principalTable: "PetsPlants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetUserConfiguration_PetsPlants_PetsId",
                table: "PetUserConfiguration",
                column: "PetsId",
                principalTable: "PetsPlants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
