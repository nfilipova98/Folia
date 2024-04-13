using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedHumidityFromRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "Regions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Humidity",
                table: "Regions",
                type: "int",
                nullable: true,
                comment: "Region humidity");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 22,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 23,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 24,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 25,
                column: "Humidity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 26,
                column: "Humidity",
                value: null);
        }
    }
}
