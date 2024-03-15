namespace Plants.Data.Migrations
{
	using System;
	using Microsoft.EntityFrameworkCore.Migrations;

	/// <inheritdoc />
	public partial class Initial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUserClaims_AspNetUsers_UserId",
				table: "AspNetUserClaims");

			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUserLogins_AspNetUsers_UserId",
				table: "AspNetUserLogins");

			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUserRoles_AspNetUsers_UserId",
				table: "AspNetUserRoles");

			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUserTokens_AspNetUsers_UserId",
				table: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.CreateTable(
				name: "ApplicationUsers",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Tier = table.Column<int>(type: "int", nullable: false),
					UserPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UsersConfigurationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserConfigurationIsNull = table.Column<bool>(type: "bit", nullable: false),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Countries",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Countries", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Pets",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Pets", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Plants",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
					ScientificName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
					ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Humidity = table.Column<int>(type: "int", nullable: false),
					Difficulty = table.Column<int>(type: "int", nullable: false),
					Lifestyle = table.Column<int>(type: "int", nullable: false),
					KidSafe = table.Column<bool>(type: "bit", nullable: false),
					Outdoor = table.Column<bool>(type: "bit", nullable: false),
					IsTrending = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Plants", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Cities",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(165)", maxLength: 165, nullable: false),
					Humidity = table.Column<int>(type: "int", nullable: true),
					CountryId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Cities", x => x.Id);
					table.ForeignKey(
						name: "FK_Cities_Countries_CountryId",
						column: x => x.CountryId,
						principalTable: "Countries",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ApplicationUsersLikedPlants",
				columns: table => new
				{
					LikedPlantsId = table.Column<int>(type: "int", nullable: false),
					UsersLikedPlantId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ApplicationUsersLikedPlants", x => new { x.LikedPlantsId, x.UsersLikedPlantId });
					table.ForeignKey(
						name: "FK_ApplicationUsersLikedPlants_ApplicationUsers_UsersLikedPlantId",
						column: x => x.UsersLikedPlantId,
						principalTable: "ApplicationUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ApplicationUsersLikedPlants_Plants_LikedPlantsId",
						column: x => x.LikedPlantsId,
						principalTable: "Plants",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

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

			migrationBuilder.CreateTable(
				name: "Comments",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Content = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
					ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					PlantId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Comments", x => x.Id);
					table.ForeignKey(
						name: "FK_Comments_ApplicationUsers_ApplicationUserId",
						column: x => x.ApplicationUserId,
						principalTable: "ApplicationUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Comments_Plants_PlantId",
						column: x => x.PlantId,
						principalTable: "Plants",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "PetPlant",
				columns: table => new
				{
					PetsId = table.Column<int>(type: "int", nullable: false),
					PlantsId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PetPlant", x => new { x.PetsId, x.PlantsId });
					table.ForeignKey(
						name: "FK_PetPlant_Pets_PetsId",
						column: x => x.PetsId,
						principalTable: "Pets",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_PetPlant_Plants_PlantsId",
						column: x => x.PlantsId,
						principalTable: "Plants",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserConfigurations",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					CityId = table.Column<int>(type: "int", nullable: true),
					Kids = table.Column<bool>(type: "bit", nullable: false),
					Direction = table.Column<int>(type: "int", nullable: false),
					Lifestyle = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserConfigurations", x => x.Id);
					table.ForeignKey(
						name: "FK_UserConfigurations_ApplicationUsers_ApplicationUserId",
						column: x => x.ApplicationUserId,
						principalTable: "ApplicationUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserConfigurations_Cities_CityId",
						column: x => x.CityId,
						principalTable: "Cities",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "PetUserConfiguration",
				columns: table => new
				{
					PetsId = table.Column<int>(type: "int", nullable: false),
					UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PetUserConfiguration", x => new { x.PetsId, x.UsersId });
					table.ForeignKey(
						name: "FK_PetUserConfiguration_Pets_PetsId",
						column: x => x.PetsId,
						principalTable: "Pets",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_PetUserConfiguration_UserConfigurations_UsersId",
						column: x => x.UsersId,
						principalTable: "UserConfigurations",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Pets",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ 1, "Cat" },
					{ 2, "Dog" }
				});

			migrationBuilder.InsertData(
				table: "Plants",
				columns: new[] { "Id", "Difficulty", "Humidity", "ImageUrl", "IsTrending", "KidSafe", "Lifestyle", "Name", "Outdoor", "ScientificName" },
				values: new object[,]
				{
					{ 1, 0, 2, "", true, false, 2, "Swiss cheese plant", true, "Monstera minima" },
					{ 2, 0, 1, "", false, true, 2, "Spider plant", false, "Chlorophytum comosum" },
					{ 3, 0, 2, "", false, true, 2, "Rubber fig", false, "Ficus elastica" },
					{ 4, 0, 1, "", false, true, 2, "Areca palm", true, "Dypsis lutescens" },
					{ 5, 0, 2, "", false, true, 1, "Watermelon Peperomia", false, "Peperomia argyreia" },
					{ 6, 0, 2, "", true, true, 2, "Snake Plant", false, "Dracaena Trifasciata" },
					{ 7, 0, 1, "", true, true, 2, "Buddhist Pine", true, "Podocarpus Macrophyllus" },
					{ 8, 1, 1, "", true, false, 2, "Cherry Laurel Novita", true, "Prunus Laurocerasus Novita" },
					{ 9, 1, 2, "", true, true, 2, "Vanuatu Fan Palm", true, "Licuala grandis" },
					{ 10, 0, 0, "", true, true, 2, "Peruvian apple cactus", true, "Cereus Peruvianus" },
					{ 11, 1, 2, "", true, true, 2, "Boston Fern", true, "Nephrolepis exaltata" },
					{ 12, 1, 2, "", true, true, 2, "Kentia Palm", true, "Howea forsteriana" },
					{ 13, 0, 1, "", true, true, 2, "ZZ Plant", true, "Zamioculcas" },
					{ 14, 1, 2, "", true, false, 2, "Heart of Jesus", false, "Caladium Bicolour" }
				});

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "ApplicationUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "ApplicationUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_ApplicationUsersLikedPlants_UsersLikedPlantId",
				table: "ApplicationUsersLikedPlants",
				column: "UsersLikedPlantId");

			migrationBuilder.CreateIndex(
				name: "IX_ApplicationUsersOwnedPlants_PlantsOwnedId",
				table: "ApplicationUsersOwnedPlants",
				column: "PlantsOwnedId");

			migrationBuilder.CreateIndex(
				name: "IX_Cities_CountryId",
				table: "Cities",
				column: "CountryId");

			migrationBuilder.CreateIndex(
				name: "IX_Comments_ApplicationUserId",
				table: "Comments",
				column: "ApplicationUserId");

			migrationBuilder.CreateIndex(
				name: "IX_Comments_PlantId",
				table: "Comments",
				column: "PlantId");

			migrationBuilder.CreateIndex(
				name: "IX_PetPlant_PlantsId",
				table: "PetPlant",
				column: "PlantsId");

			migrationBuilder.CreateIndex(
				name: "IX_PetUserConfiguration_UsersId",
				table: "PetUserConfiguration",
				column: "UsersId");

			migrationBuilder.CreateIndex(
				name: "IX_UserConfigurations_ApplicationUserId",
				table: "UserConfigurations",
				column: "ApplicationUserId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_UserConfigurations_CityId",
				table: "UserConfigurations",
				column: "CityId");

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUserClaims_ApplicationUsers_UserId",
				table: "AspNetUserClaims",
				column: "UserId",
				principalTable: "ApplicationUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUserLogins_ApplicationUsers_UserId",
				table: "AspNetUserLogins",
				column: "UserId",
				principalTable: "ApplicationUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUserRoles_ApplicationUsers_UserId",
				table: "AspNetUserRoles",
				column: "UserId",
				principalTable: "ApplicationUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUserTokens_ApplicationUsers_UserId",
				table: "AspNetUserTokens",
				column: "UserId",
				principalTable: "ApplicationUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUserClaims_ApplicationUsers_UserId",
				table: "AspNetUserClaims");

			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUserLogins_ApplicationUsers_UserId",
				table: "AspNetUserLogins");

			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUserRoles_ApplicationUsers_UserId",
				table: "AspNetUserRoles");

			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUserTokens_ApplicationUsers_UserId",
				table: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "ApplicationUsersLikedPlants");

			migrationBuilder.DropTable(
				name: "ApplicationUsersOwnedPlants");

			migrationBuilder.DropTable(
				name: "Comments");

			migrationBuilder.DropTable(
				name: "PetPlant");

			migrationBuilder.DropTable(
				name: "PetUserConfiguration");

			migrationBuilder.DropTable(
				name: "Plants");

			migrationBuilder.DropTable(
				name: "Pets");

			migrationBuilder.DropTable(
				name: "UserConfigurations");

			migrationBuilder.DropTable(
				name: "ApplicationUsers");

			migrationBuilder.DropTable(
				name: "Cities");

			migrationBuilder.DropTable(
				name: "Countries");

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUserClaims_AspNetUsers_UserId",
				table: "AspNetUserClaims",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUserLogins_AspNetUsers_UserId",
				table: "AspNetUserLogins",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUserRoles_AspNetUsers_UserId",
				table: "AspNetUserRoles",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUserTokens_AspNetUsers_UserId",
				table: "AspNetUserTokens",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
