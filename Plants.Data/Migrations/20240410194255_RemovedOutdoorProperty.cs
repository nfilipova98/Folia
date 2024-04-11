using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOutdoorProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Outdoor",
                table: "Plants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Outdoor",
                table: "Plants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 2,
                column: "Outdoor",
                value: false);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 3,
                column: "Outdoor",
                value: false);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 4,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 5,
                column: "Outdoor",
                value: false);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 6,
                column: "Outdoor",
                value: false);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 7,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 8,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 9,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 10,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 11,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 12,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 13,
                column: "Outdoor",
                value: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 14,
                column: "Outdoor",
                value: false);
        }
    }
}
