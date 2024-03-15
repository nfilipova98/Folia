namespace Plants.Data.Migrations
{
	using Microsoft.EntityFrameworkCore.Migrations;

	/// <inheritdoc />
	public partial class TierPointsAdded : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "CityId",
				table: "UserConfigurations",
				type: "int",
				nullable: true,
				comment: "City identifier",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "ApplicationUserId",
				table: "UserConfigurations",
				type: "nvarchar(450)",
				nullable: false,
				comment: "User identifier",
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

			migrationBuilder.AlterColumn<string>(
				name: "Id",
				table: "UserConfigurations",
				type: "nvarchar(450)",
				nullable: false,
				comment: "Identifier",
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

			migrationBuilder.AlterColumn<string>(
				name: "ScientificName",
				table: "Plants",
				type: "nvarchar(100)",
				maxLength: 100,
				nullable: true,
				comment: "Plant scientific name",
				oldClrType: typeof(string),
				oldType: "nvarchar(70)",
				oldMaxLength: 70,
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Plants",
				type: "nvarchar(70)",
				maxLength: 70,
				nullable: false,
				comment: "Plant common name",
				oldClrType: typeof(string),
				oldType: "nvarchar(70)",
				oldMaxLength: 70);

			migrationBuilder.AlterColumn<string>(
				name: "ImageUrl",
				table: "Plants",
				type: "nvarchar(max)",
				nullable: false,
				comment: "Plant image",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Plants",
				type: "int",
				nullable: false,
				comment: "Identifier",
				oldClrType: typeof(int),
				oldType: "int")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Pets",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: false,
				comment: "Pet type",
				oldClrType: typeof(string),
				oldType: "nvarchar(50)",
				oldMaxLength: 50);

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Pets",
				type: "int",
				nullable: false,
				comment: "Identifier",
				oldClrType: typeof(int),
				oldType: "int")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Countries",
				type: "nvarchar(60)",
				maxLength: 60,
				nullable: false,
				comment: "Country name",
				oldClrType: typeof(string),
				oldType: "nvarchar(60)",
				oldMaxLength: 60);

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Countries",
				type: "int",
				nullable: false,
				comment: "Identifier",
				oldClrType: typeof(int),
				oldType: "int")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<int>(
				name: "PlantId",
				table: "Comments",
				type: "int",
				nullable: false,
				comment: "Plant identifier",
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AlterColumn<string>(
				name: "Content",
				table: "Comments",
				type: "nvarchar(350)",
				maxLength: 350,
				nullable: false,
				comment: "Comment content",
				oldClrType: typeof(string),
				oldType: "nvarchar(350)",
				oldMaxLength: 350);

			migrationBuilder.AlterColumn<string>(
				name: "ApplicationUserId",
				table: "Comments",
				type: "nvarchar(450)",
				nullable: false,
				comment: "User identifier",
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Comments",
				type: "int",
				nullable: false,
				comment: "Identifier",
				oldClrType: typeof(int),
				oldType: "int")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Cities",
				type: "nvarchar(165)",
				maxLength: 165,
				nullable: false,
				comment: "City name",
				oldClrType: typeof(string),
				oldType: "nvarchar(165)",
				oldMaxLength: 165);

			migrationBuilder.AlterColumn<int>(
				name: "Humidity",
				table: "Cities",
				type: "int",
				nullable: true,
				comment: "City humidity",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "CountryId",
				table: "Cities",
				type: "int",
				nullable: false,
				comment: "Country identifier",
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Cities",
				type: "int",
				nullable: false,
				comment: "Identifier",
				oldClrType: typeof(int),
				oldType: "int")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<string>(
				name: "UsersConfigurationId",
				table: "ApplicationUsers",
				type: "nvarchar(max)",
				nullable: true,
				comment: "Additional profile configuration",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "UserPictureUrl",
				table: "ApplicationUsers",
				type: "nvarchar(max)",
				nullable: true,
				comment: "Profile picture",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "Tier",
				table: "ApplicationUsers",
				type: "int",
				nullable: false,
				comment: "Profile tier",
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AddColumn<int>(
				name: "TierPoints",
				table: "ApplicationUsers",
				type: "int",
				nullable: false,
				defaultValue: 0,
				comment: "Profile tier points");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "TierPoints",
				table: "ApplicationUsers");

			migrationBuilder.AlterColumn<int>(
				name: "CityId",
				table: "UserConfigurations",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true,
				oldComment: "City identifier");

			migrationBuilder.AlterColumn<string>(
				name: "ApplicationUserId",
				table: "UserConfigurations",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)",
				oldComment: "User identifier");

			migrationBuilder.AlterColumn<string>(
				name: "Id",
				table: "UserConfigurations",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)",
				oldComment: "Identifier");

			migrationBuilder.AlterColumn<string>(
				name: "ScientificName",
				table: "Plants",
				type: "nvarchar(70)",
				maxLength: 70,
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(100)",
				oldMaxLength: 100,
				oldNullable: true,
				oldComment: "Plant scientific name");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Plants",
				type: "nvarchar(70)",
				maxLength: 70,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(70)",
				oldMaxLength: 70,
				oldComment: "Plant common name");

			migrationBuilder.AlterColumn<string>(
				name: "ImageUrl",
				table: "Plants",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldComment: "Plant image");

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Plants",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Identifier")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Pets",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(50)",
				oldMaxLength: 50,
				oldComment: "Pet type");

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Pets",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Identifier")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Countries",
				type: "nvarchar(60)",
				maxLength: 60,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(60)",
				oldMaxLength: 60,
				oldComment: "Country name");

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Countries",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Identifier")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<int>(
				name: "PlantId",
				table: "Comments",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Plant identifier");

			migrationBuilder.AlterColumn<string>(
				name: "Content",
				table: "Comments",
				type: "nvarchar(350)",
				maxLength: 350,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(350)",
				oldMaxLength: 350,
				oldComment: "Comment content");

			migrationBuilder.AlterColumn<string>(
				name: "ApplicationUserId",
				table: "Comments",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)",
				oldComment: "User identifier");

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Comments",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Identifier")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Cities",
				type: "nvarchar(165)",
				maxLength: 165,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(165)",
				oldMaxLength: 165,
				oldComment: "City name");

			migrationBuilder.AlterColumn<int>(
				name: "Humidity",
				table: "Cities",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true,
				oldComment: "City humidity");

			migrationBuilder.AlterColumn<int>(
				name: "CountryId",
				table: "Cities",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Country identifier");

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "Cities",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Identifier")
				.Annotation("SqlServer:Identity", "1, 1")
				.OldAnnotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<string>(
				name: "UsersConfigurationId",
				table: "ApplicationUsers",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true,
				oldComment: "Additional profile configuration");

			migrationBuilder.AlterColumn<string>(
				name: "UserPictureUrl",
				table: "ApplicationUsers",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true,
				oldComment: "Profile picture");

			migrationBuilder.AlterColumn<int>(
				name: "Tier",
				table: "ApplicationUsers",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Profile tier");
		}
	}
}
