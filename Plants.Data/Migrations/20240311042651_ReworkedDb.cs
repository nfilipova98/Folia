using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReworkedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Humidity", "ImageUrl", "KidSafe", "Name", "ScientificName" },
                values: new object[] { 1, "https://softuniproject.blob.core.windows.net/publicimages/0.jpg", true, "Buddhist Pine", "Podocarpus Macrophyllus" });

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/13.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/10.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/12.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/11.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/1.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Humidity", "ImageUrl", "KidSafe", "Name", "ScientificName" },
                values: new object[] { 2, "https://softuniproject.blob.core.windows.net/publicimages/8.jpg", false, "Swiss cheese plant", "Monstera minima" });

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/2.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/3.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/4.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/5.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/6.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/7.jpg");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://softuniproject.blob.core.windows.net/publicimages/9.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Humidity", "ImageUrl", "KidSafe", "Name", "ScientificName" },
                values: new object[] { 2, "", false, "Swiss cheese plant", "Monstera minima" });

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Humidity", "ImageUrl", "KidSafe", "Name", "ScientificName" },
                values: new object[] { 1, "", true, "Buddhist Pine", "Podocarpus Macrophyllus" });

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "");
        }
    }
}
