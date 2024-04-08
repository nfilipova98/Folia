﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false, comment: "Profile tier"),
                    TierPoints = table.Column<int>(type: "int", nullable: false, comment: "Profile tier points"),
                    UsersConfigurationId = table.Column<int>(type: "int", nullable: true, comment: "Additional profile configuration"),
                    UserConfigurationIsNull = table.Column<bool>(type: "bit", nullable: false),
                    IsFirstTimeLogin = table.Column<bool>(type: "bit", nullable: false),
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Country name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Pet type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Plant common name"),
                    ScientificName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Plant scientific name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Plant image"),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Lifestyle = table.Column<int>(type: "int", nullable: false),
                    KidSafe = table.Column<bool>(type: "bit", nullable: false),
                    Outdoor = table.Column<bool>(type: "bit", nullable: false),
                    IsTrending = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(165)", maxLength: 165, nullable: false, comment: "City name"),
                    Humidity = table.Column<int>(type: "int", nullable: true, comment: "City humidity"),
                    CountryId = table.Column<int>(type: "int", nullable: false, comment: "Country identifier")
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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false, comment: "Comment content"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    PlantId = table.Column<int>(type: "int", nullable: false, comment: "Plant identifier")
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
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    CityId = table.Column<int>(type: "int", nullable: true, comment: "City identifier"),
                    Kids = table.Column<bool>(type: "bit", nullable: false),
                    UserPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Profile picture"),
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
                    UsersId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Description", "Difficulty", "Humidity", "ImageUrl", "IsTrending", "KidSafe", "Lifestyle", "Name", "Outdoor", "ScientificName" },
                values: new object[,]
                {
                    { 1, "Buddhist Pine, scientifically known as Podocarpus Macrophyllus, is an easy-care evergreen shrub that delights gardeners and plant enthusiasts alike. With its lush green foliage and graceful, upright growth habit, this plant adds a touch of elegance to any outdoor space. Its botanical name, Podocarpus Macrophyllus, reflects its large, glossy leaves that bring a refreshing aesthetic to gardens and landscapes. Thriving in moderate humidity levels, the Buddhist Pine is a versatile plant that adapts well to various environmental conditions, making it suitable for a wide range of climates. Its low maintenance nature makes it an excellent choice for both novice and experienced gardeners seeking a hassle-free addition to their outdoor greenery. One of the notable features of the Buddhist Pine is its child-friendly nature, making it a safe and worry-free option for households with children or pets. Its non-toxic properties ensure peace of mind for parents and pet owners alike. Embracing a traveler lifestyle, this plant is perfect for those who frequently find themselves on the move. Its adaptability to different outdoor settings and minimal care requirements make it an ideal companion for globetrotters and outdoor enthusiasts seeking a touch of greenery wherever they go. As an outdoor plant, the Buddhist Pine thrives in natural sunlight, flourishing under open skies and gentle breezes. Whether planted as a standalone specimen or incorporated into garden beds and borders, its presence adds a timeless charm to any outdoor setting. In line with current trends, the Buddhist Pine has gained popularity among gardening enthusiasts and landscape designers alike. Its classic appeal and easygoing nature make it a sought-after choice for those looking to enhance their outdoor spaces with a touch of understated elegance.", 0, 1, "https://softuniproject.blob.core.windows.net/publicimages/0.jpg", true, true, 2, "Buddhist Pine", true, "Podocarpus Macrophyllus" },
                    { 2, "The Spider Plant, scientifically known as Chlorophytum comosum, is a resilient and popular choice for both beginner and seasoned plant enthusiasts alike. True to its name, its slender, arching leaves resemble spider legs, lending an elegant and distinctive appearance to any indoor space. Thriving in moderate humidity levels, the Spider Plant is relatively undemanding when it comes to care, making it an ideal addition to households with varying environmental conditions. Its preference for moderate humidity levels makes it adaptable to a wide range of indoor environments. One of its standout features is its suitability for homes with children, as it is considered safe for kids and pets. This characteristic, combined with its easy care requirements, makes it a top choice for families looking to introduce greenery into their living spaces without worry. For individuals with active lifestyles or frequent travelers, the Spider Plant is particularly appealing. Its easygoing nature means it can withstand periods of neglect and irregular watering, making it a reliable companion for those who may be away from home frequently. Although the Spider Plant is primarily an indoor plant, its versatility allows it to thrive in a variety of indoor settings, from bright, well-lit rooms to those with lower light conditions. Its adaptability further enhances its appeal, as it can easily find a place in different areas of the home, bringing a touch of natural beauty wherever it's placed.", 0, 1, "https://softuniproject.blob.core.windows.net/publicimages/13.jpg", false, true, 2, "Spider plant", false, "Chlorophytum comosum" },
                    { 3, "The Rubber Fig, scientifically known as Ficus elastica, is a stunning addition to any indoor garden. With its glossy, deep green leaves and sturdy, upright growth habit, it adds a touch of elegance to any room it inhabits. This plant is a perfect choice for both novice and experienced plant parents due to its easy-care nature. Its resilience and adaptability make it an excellent option for those new to plant care or those seeking low-maintenance greenery. Thriving in environments with high humidity levels, the Rubber Fig is ideal for spaces where moisture levels can be easily controlled, such as bathrooms or kitchens. Its preference for high humidity ensures that it remains healthy and vibrant even in dry indoor environments. Families with children or pets will appreciate the Rubber Fig's safe nature, as it is non-toxic and considered kid-friendly. This characteristic allows it to be placed in any room of the house without concern for the safety of curious little ones or furry friends. For individuals leading busy lives or frequent travelers, the Rubber Fig is an excellent companion. Its ability to tolerate occasional neglect and irregular watering makes it a resilient choice for those who may not always have time to devote to plant care. While primarily an indoor plant, the Rubber Fig can be placed in a variety of indoor settings, from bright, sunlit rooms to areas with lower light levels. Its versatility in light requirements allows it to thrive in different environments, making it a versatile addition to any indoor space.", 0, 2, "https://softuniproject.blob.core.windows.net/publicimages/10.jpg", false, true, 2, "Rubber fig", false, "Ficus elastica" },
                    { 4, "The Areca Palm, scientifically known as Dypsis lutescens, brings a touch of tropical elegance to both indoor and outdoor spaces. With its graceful fronds and slender, bamboo-like stems, it adds a sense of lushness and tranquility to any environment it graces. This palm species is an excellent choice for plant enthusiasts of all levels, as it is relatively easy to care for and maintain. Its adaptable nature allows it to thrive in various conditions, making it a popular option for both beginners and seasoned gardeners alike.Preferring moderate humidity levels, the Areca Palm is well-suited to indoor environments where humidity can be controlled. However, its versatility also extends to outdoor settings, where it can flourish in mild climates with moderate humidity levels. Families with children and pets will appreciate the Areca Palm's non-toxic nature, as it poses no harm if accidentally ingested. Its safety makes it a fantastic choice for households with curious little ones or furry companions. For individuals with active lifestyles or frequent travelers, the Areca Palm is an ideal companion. Its low-maintenance requirements and resilience to occasional neglect make it a reliable option for those who may not always have time to devote to plant care. While it can thrive both indoors and outdoors, the Areca Palm truly shines when given the opportunity to bask in natural sunlight. Its ability to flourish in outdoor settings makes it a versatile choice for landscaping, adding a touch of tropical beauty to gardens, patios, and balconies alike.", 0, 1, "https://softuniproject.blob.core.windows.net/publicimages/12.jpg", false, true, 2, "Areca palm", true, "Dypsis lutescens" },
                    { 5, "The Watermelon Peperomia, scientifically known as Peperomia argyreia, is a charming and distinctive houseplant that adds a pop of color and personality to any indoor space. With its striking foliage resembling the rind of a watermelon, this plant is sure to capture attention and become a favorite among plant enthusiasts. Caring for the Watermelon Peperomia is a delight, as it falls under the category of easy-care plants. Its low-maintenance nature makes it an excellent choice for both novice and experienced plant parents alike. With just a little attention, it will thrive and continue to display its vibrant beauty. This plant thrives in environments with high humidity levels, making it well-suited for areas such as bathrooms or kitchens where moisture levels tend to be higher. Its preference for humidity ensures that its lush leaves remain healthy and vibrant, adding a refreshing touch to indoor spaces. Families with children and pets can enjoy the Watermelon Peperomia worry-free, as it is considered safe for both humans and animals. Its non-toxic properties make it a fantastic choice for households with curious little ones or furry companions. The Watermelon Peperomia fits seamlessly into the lifestyle of those who fall in between busy and laid-back. Its moderate care requirements mean that it can thrive with regular but not overly demanding attention, making it an ideal choice for individuals with varied schedules and commitments. While primarily an indoor plant, the Watermelon Peperomia does not thrive in outdoor settings. Its preference for stable indoor conditions makes it unsuitable for placement outside, but its captivating beauty ensures that it will become a cherished addition to any indoor garden or plant collection.", 0, 2, "https://softuniproject.blob.core.windows.net/publicimages/11.jpg", false, true, 1, "Watermelon Peperomia", false, "Peperomia argyreia" },
                    { 6, "The Snake Plant, scientifically known as Dracaena trifasciata, is a hardy and visually striking addition to any indoor space. With its upright, sword-shaped leaves featuring distinctive variegated patterns, this plant adds a touch of modern elegance to both contemporary and traditional settings. Renowned for its easy-care nature, the Snake Plant is an ideal choice for plant enthusiasts of all levels, including beginners. Its tolerance to neglect and ability to thrive in various conditions make it a popular option for those seeking low-maintenance greenery. Thriving in environments with high humidity levels, the Snake Plant is well-suited for placement in areas such as bathrooms or kitchens where moisture levels are naturally elevated. Its preference for humidity ensures that its foliage remains healthy and vibrant, even in indoor environments. Families with children and pets can safely enjoy the presence of the Snake Plant, as it is considered non-toxic and safe for both humans and animals. Its sturdy leaves and robust growth habit make it a resilient choice for households with curious little ones or furry companions. For individuals with busy lifestyles or frequent travelers, the Snake Plant is an excellent companion. Its ability to tolerate occasional neglect and survive with infrequent watering makes it an ideal choice for those who may not always have time to dedicate to plant care. While primarily an indoor plant, the Snake Plant does not thrive in outdoor settings and is best suited for indoor cultivation. Its adaptability to various light conditions, including low light, further enhances its versatility, making it a versatile addition to any indoor garden or plant collection.", 0, 2, "https://softuniproject.blob.core.windows.net/publicimages/1.jpg", true, true, 2, "Snake Plant", false, "Dracaena Trifasciata" },
                    { 7, "The Swiss Cheese Plant, scientifically known as Monstera minima, is a captivating tropical species that brings an exotic touch to both indoor and outdoor spaces. With its unique fenestrated leaves resembling Swiss cheese, this plant is sure to become a focal point in any botanical collection. Known for its ease of care, the Swiss Cheese Plant is an excellent choice for plant enthusiasts of all levels. Its low-maintenance requirements make it particularly appealing to beginners seeking a visually striking yet undemanding plant to adorn their living spaces. Thriving in environments with high humidity levels, the Swiss Cheese Plant is well-suited for placement in areas where moisture levels are naturally elevated, such as bathrooms or kitchens. Its preference for humidity ensures that its lush foliage remains healthy and vibrant, even in indoor environments. While its striking appearance may attract the attention of children and pets, it's essential to note that the Swiss Cheese Plant is not considered safe for consumption and should be kept out of reach of curious little ones and pets. For individuals with active lifestyles or frequent travelers, the Swiss Cheese Plant is an excellent option. Its ability to tolerate occasional neglect and survive with infrequent watering makes it an ideal choice for those who may not always have time to devote to plant care. Additionally, the Swiss Cheese Plant's adaptability extends beyond indoor environments, as it can also thrive outdoors in suitable climates. Its versatility allows it to be incorporated into garden landscapes or patio settings, where its tropical allure can be fully appreciated. Whether gracing indoor living spaces or outdoor retreats, the Swiss Cheese Plant adds a touch of exotic beauty and intrigue, making it a cherished addition to any botanical collection or garden landscape.", 0, 2, "https://softuniproject.blob.core.windows.net/publicimages/8.jpg", true, false, 2, "Swiss cheese plant", true, "Monstera minima" },
                    { 8, "The Cherry Laurel Novita, scientifically known as Prunus laurocerasus 'Novita', is a versatile and ornamental evergreen shrub that adds both beauty and functionality to outdoor landscapes. With its dense foliage and upright growth habit, this plant serves as an excellent choice for hedges, borders, or as a standalone specimen in garden settings. Caring for the Cherry Laurel Novita requires a moderate level of attention, placing it in the medium difficulty category. While not overly demanding, it benefits from regular pruning to maintain its desired shape and size, making it suitable for gardeners with some experience in plant care. Thriving in environments with moderate humidity levels, the Cherry Laurel Novita is well-suited for outdoor cultivation in various climates. Its tolerance to a wide range of environmental conditions, including moderate humidity, ensures its adaptability to different garden settings. While its lush foliage and vibrant berries may add visual interest to outdoor landscapes, it's important to note that the Cherry Laurel Novita is not considered safe for consumption, particularly for children and pets. Caution should be exercised to prevent accidental ingestion. For individuals with active lifestyles or frequent travelers, the Cherry Laurel Novita is an excellent choice for outdoor landscaping. Its resilience to occasional neglect and ability to withstand fluctuating weather conditions make it a reliable option for those who may not always have time for intensive garden maintenance. Whether used as a hedge, accent plant, or focal point in garden designs, the Cherry Laurel Novita adds year-round beauty and structure to outdoor spaces, making it a valuable addition to any landscape design scheme.", 1, 1, "https://softuniproject.blob.core.windows.net/publicimages/2.jpg", true, false, 2, "Cherry Laurel Novita", true, "Prunus Laurocerasus Novita" },
                    { 9, "The Vanuatu Fan Palm, scientifically known as Licuala grandis, is a captivating palm species native to the tropical regions of Vanuatu and surrounding areas. With its large, round, fan-shaped leaves and graceful, arching stems, this palm adds a touch of exotic beauty to outdoor landscapes. Caring for the Vanuatu Fan Palm requires a moderate level of attention, placing it in the medium difficulty category. While not overly demanding, it benefits from regular watering, protection from harsh sunlight, and occasional fertilization to maintain its lush appearance and overall health. Thriving in environments with high humidity levels, the Vanuatu Fan Palm is well-suited for outdoor cultivation in tropical or subtropical climates. Its preference for humidity ensures that it remains vibrant and healthy, even in outdoor settings where moisture levels may fluctuate. Families with children can enjoy the presence of the Vanuatu Fan Palm, as it is considered safe and non-toxic. Its sturdy growth habit and kid-friendly nature make it a suitable addition to outdoor landscapes where children may play and explore. For individuals with active lifestyles or frequent travelers, the Vanuatu Fan Palm is a wonderful choice for outdoor landscaping. Its resilience to occasional neglect and ability to thrive in various environmental conditions make it a reliable option for those who may not always have time for intensive garden maintenance. Whether planted as a focal point in garden designs, incorporated into tropical-themed landscapes, or used to provide shade and visual interest in outdoor spaces, the Vanuatu Fan Palm adds an element of natural beauty and tranquility to any outdoor environment.", 1, 2, "https://softuniproject.blob.core.windows.net/publicimages/3.jpg", true, true, 2, "Vanuatu Fan Palm", true, "Licuala grandis" },
                    { 10, "The Peruvian Apple Cactus, scientifically known as Cereus peruvianus, is a striking and low-maintenance succulent that adds a touch of desert charm to outdoor landscapes. With its tall, columnar stems adorned with spiny ridges and occasional blooms, this cactus species brings a unique aesthetic to gardens and arid landscapes. Caring for the Peruvian Apple Cactus is a breeze, as it falls under the category of easy-care plants. Its drought-tolerant nature and minimal water requirements make it an excellent choice for gardeners of all levels, including beginners looking to add a touch of exotic flair to their outdoor spaces. Thriving in environments with low humidity levels, the Peruvian Apple Cactus is well-suited for outdoor cultivation in arid or semi-arid regions. Its ability to withstand dry conditions ensures that it remains healthy and vibrant, even in landscapes where rainfall is scarce. Families with children can enjoy the presence of the Peruvian Apple Cactus, as it is considered safe and non-toxic. However, caution should be exercised due to its spiny exterior, particularly with young children who may be prone to touching or exploring the garden. For individuals with active lifestyles or frequent travelers, the Peruvian Apple Cactus is an ideal choice for outdoor landscaping. Its resilience to neglect and ability to thrive in harsh environmental conditions make it a reliable option for those who may not always have time for intensive garden maintenance. Whether planted as a focal point in xeriscapes, used to create natural barriers or borders, or simply allowed to flourish in its natural habitat, the Peruvian Apple Cactus adds an element of rugged beauty and resilience to any outdoor environment.", 0, 0, "https://softuniproject.blob.core.windows.net/publicimages/4.jpg", true, true, 2, "Peruvian apple cactus", true, "Cereus Peruvianus" },
                    { 11, "The Boston Fern, scientifically known as Nephrolepis exaltata, is a classic and elegant fern species renowned for its lush, arching fronds and delicate appearance. With its graceful foliage cascading from hanging baskets or adorning garden beds, this fern adds a touch of timeless beauty to both indoor and outdoor spaces. Caring for the Boston Fern requires a moderate level of attention, placing it in the medium difficulty category. While not overly demanding, it thrives in environments with high humidity levels and consistent moisture. Regular watering, protection from direct sunlight, and occasional fertilization contribute to its health and vitality. Thriving in environments with high humidity levels, the Boston Fern is well-suited for outdoor cultivation in shaded or partially shaded areas where moisture levels are naturally elevated. Its preference for humidity ensures that it remains lush and vibrant, even in outdoor landscapes where rainfall may be sporadic. Families with children can enjoy the presence of the Boston Fern, as it is considered safe and non-toxic. Its soft, feathery fronds make it a charming addition to gardens and outdoor spaces where children may play and explore. For individuals with active lifestyles or frequent travelers, the Boston Fern is a suitable choice for outdoor landscaping. While it may require regular watering and attention to humidity levels, its resilience to occasional neglect and ability to thrive in shaded environments make it a reliable option for those who may not always have time for intensive garden maintenance. Whether planted in shaded garden beds, displayed in hanging baskets on porches or patios, or incorporated into outdoor living spaces to add a touch of natural beauty, the Boston Fern brings a sense of tranquility and elegance to any outdoor environment.", 1, 2, "https://softuniproject.blob.core.windows.net/publicimages/5.jpg", true, true, 2, "Boston Fern", true, "Nephrolepis exaltata" },
                    { 12, "The Kentia Palm, scientifically known as Howea forsteriana, is a majestic and iconic palm species that adds a touch of tropical elegance to outdoor landscapes. With its graceful fronds and slender, upright trunk, this palm exudes timeless beauty and sophistication, making it a cherished addition to gardens, patios, and outdoor living spaces. Caring for the Kentia Palm requires a moderate level of attention, placing it in the medium difficulty category. While not overly demanding, it thrives in environments with high humidity levels and consistent moisture. Regular watering, protection from direct sunlight, and occasional fertilization contribute to its health and vitality. Thriving in environments with high humidity levels, the Kentia Palm is well-suited for outdoor cultivation in tropical or subtropical climates. Its preference for humidity ensures that it remains lush and vibrant, even in outdoor landscapes where moisture levels may fluctuate. Families with children can enjoy the presence of the Kentia Palm, as it is considered safe and non-toxic. Its sturdy growth habit and graceful foliage make it a delightful addition to outdoor spaces where children may play and explore. For individuals with active lifestyles or frequent travelers, the Kentia Palm is a suitable choice for outdoor landscaping. While it may require regular watering and attention to humidity levels, its resilience to occasional neglect and ability to thrive in shaded environments make it a reliable option for those who may not always have time for intensive garden maintenance. Whether planted as a focal point in garden designs, incorporated into tropical-themed landscapes, or used to create natural shade and privacy in outdoor settings, the Kentia Palm brings a sense of tranquility and tropical allure to any outdoor environment.", 1, 2, "https://softuniproject.blob.core.windows.net/publicimages/6.jpg", true, true, 2, "Kentia Palm", true, "Howea forsteriana" },
                    { 13, "The ZZ Plant, scientifically known as Zamioculcas, is a resilient and versatile houseplant that effortlessly enhances both indoor and outdoor spaces with its striking appearance and minimal care requirements. With its glossy, dark green foliage and architectural silhouette, this plant adds a touch of contemporary elegance to any environment. Caring for the ZZ Plant is a breeze, as it falls under the category of easy-care plants. Its ability to thrive in low light conditions and tolerate infrequent watering makes it an ideal choice for busy individuals or those new to plant care. Thriving in environments with moderate humidity levels, the ZZ Plant is well-suited for placement both indoors and outdoors where moisture levels are relatively stable. Its adaptability to different humidity levels ensures that it remains healthy and vibrant in a variety of environments. Families with children can enjoy the presence of the ZZ Plant, as it is considered safe and non-toxic. Its sturdy growth habit and resilient nature make it a worry-free addition to indoor and outdoor spaces where children may be present. For individuals with active lifestyles or frequent travelers, the ZZ Plant is an excellent choice for both indoor and outdoor settings. Its ability to tolerate neglect and survive with minimal maintenance makes it a reliable option for those who may not always have time to dedicate to plant care. Whether placed as a potted specimen on patios, balconies, or used to create a lush, green backdrop in outdoor landscapes, the ZZ Plant adds a touch of modern sophistication and natural beauty to any outdoor environment.", 0, 1, "https://softuniproject.blob.core.windows.net/publicimages/7.jpg", true, true, 2, "ZZ Plant", true, "Zamioculcas" },
                    { 14, "The Heart of Jesus, scientifically known as Caladium bicolor, is a captivating and ornamental plant prized for its vibrant and colorful foliage. With its heart-shaped leaves splashed with hues of green, pink, red, and white, this plant adds a pop of tropical flair to indoor environments. Caring for the Heart of Jesus requires a moderate level of attention, placing it in the medium difficulty category. While not overly demanding, it thrives in environments with high humidity levels and consistent moisture. Providing adequate humidity through regular misting or placing the plant on a pebble tray can help maintain its lush foliage. Thriving in environments with high humidity levels, the Heart of Jesus is best suited for indoor cultivation, where humidity levels can be controlled more easily. Its preference for humidity ensures that it remains vibrant and healthy, even in indoor environments with drier air. While the Heart of Jesus adds beauty to indoor spaces, it's important to note that it is not considered safe for consumption and may cause irritation if ingested. Therefore, caution should be exercised, particularly in households with young children or pets. For individuals with active lifestyles or frequent travelers, the Heart of Jesus may require additional attention to humidity levels to thrive indoors. While it may not be the most suitable choice for those who travel frequently, its stunning foliage makes it a worthwhile addition to indoor environments for those willing to provide the necessary care. Whether displayed as a centerpiece on tabletops, shelves, or used to add color and texture to indoor gardens, the Heart of Jesus brings a touch of tropical beauty and sophistication to any indoor space.", 1, 2, "https://softuniproject.blob.core.windows.net/publicimages/9.jpg", true, false, 2, "Heart of Jesus", false, "Caladium Bicolour" }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsersLikedPlants");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PetPlant");

            migrationBuilder.DropTable(
                name: "PetUserConfiguration");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
        }
    }
}
