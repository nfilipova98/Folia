namespace Plants.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class PlantSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Difficulty", "Humidity", "ImageUrl", "KidSafe", "Lifestyle", "Name", "Outdoor", "ScientificName" },
                values: new object[,]
                {
                    { 1, 0, 2, "", false, 2, "Swiss cheese plant", true, "Monstera" },
                    { 2, 0, 1, "", true, 2, "Spider plant", false, "Chlorophytum comosum" },
                    { 3, 0, 2, "", true, 2, "Rubber fig", false, "Ficus elastica" },
                    { 4, 0, 1, "", true, 2, "Areca palm", true, "Dypsis lutescens" },
                    { 5, 0, 2, "", true, 1, "Watermelon Peperomia", false, "Peperomia argyreia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
