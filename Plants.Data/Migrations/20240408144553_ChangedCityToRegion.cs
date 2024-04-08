using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCityToRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConfigurations_Cities_CityId",
                table: "UserConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_UserConfigurations_CityId",
                table: "UserConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UserConfigurations");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "Regions");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Regions",
                newName: "IX_Regions_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "UserConfigurations",
                type: "int",
                nullable: true,
                comment: "Region identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(165)",
                maxLength: 165,
                nullable: false,
                comment: "Region name",
                oldClrType: typeof(string),
                oldType: "nvarchar(165)",
                oldMaxLength: 165,
                oldComment: "City name");

            migrationBuilder.AlterColumn<int>(
                name: "Humidity",
                table: "Regions",
                type: "int",
                nullable: true,
                comment: "Region humidity",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "City humidity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserConfigurations_RegionId",
                table: "UserConfigurations",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Countries_CountryId",
                table: "Regions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConfigurations_Regions_RegionId",
                table: "UserConfigurations",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Countries_CountryId",
                table: "Regions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConfigurations_Regions_RegionId",
                table: "UserConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_UserConfigurations_RegionId",
                table: "UserConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "UserConfigurations");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_CountryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "UserConfigurations",
                type: "int",
                nullable: true,
                comment: "City identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(165)",
                maxLength: 165,
                nullable: false,
                comment: "City name",
                oldClrType: typeof(string),
                oldType: "nvarchar(165)",
                oldMaxLength: 165,
                oldComment: "Region name");

            migrationBuilder.AlterColumn<int>(
                name: "Humidity",
                table: "Cities",
                type: "int",
                nullable: true,
                comment: "City humidity",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Region humidity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserConfigurations_CityId",
                table: "UserConfigurations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConfigurations_Cities_CityId",
                table: "UserConfigurations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
