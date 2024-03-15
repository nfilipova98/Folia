﻿namespace Plants.Data.Migrations
{
	using Plants.Data;

	using System;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Infrastructure;

	[DbContext(typeof(PlantsDbContext))]
	partial class PlantsDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.2")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("ApplicationUserPlant", b =>
				{
					b.Property<int>("LikedPlantsId")
						.HasColumnType("int");

					b.Property<string>("UsersLikedPlantId")
						.HasColumnType("nvarchar(450)");

					b.HasKey("LikedPlantsId", "UsersLikedPlantId");

					b.HasIndex("UsersLikedPlantId");

					b.ToTable("ApplicationUsersLikedPlants", (string)null);
				});

			modelBuilder.Entity("ApplicationUserPlant1", b =>
				{
					b.Property<string>("OwnersId")
						.HasColumnType("nvarchar(450)");

					b.Property<int>("PlantsOwnedId")
						.HasColumnType("int");

					b.HasKey("OwnersId", "PlantsOwnedId");

					b.HasIndex("PlantsOwnedId");

					b.ToTable("ApplicationUsersOwnedPlants", (string)null);
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
				{
					b.Property<string>("Id")
						.HasColumnType("nvarchar(450)");

					b.Property<string>("ConcurrencyStamp")
						.IsConcurrencyToken()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("Name")
						.HasMaxLength(256)
						.HasColumnType("nvarchar(256)");

					b.Property<string>("NormalizedName")
						.HasMaxLength(256)
						.HasColumnType("nvarchar(256)");

					b.HasKey("Id");

					b.HasIndex("NormalizedName")
						.IsUnique()
						.HasDatabaseName("RoleNameIndex")
						.HasFilter("[NormalizedName] IS NOT NULL");

					b.ToTable("AspNetRoles", (string)null);
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("ClaimType")
						.HasColumnType("nvarchar(max)");

					b.Property<string>("ClaimValue")
						.HasColumnType("nvarchar(max)");

					b.Property<string>("RoleId")
						.IsRequired()
						.HasColumnType("nvarchar(450)");

					b.HasKey("Id");

					b.HasIndex("RoleId");

					b.ToTable("AspNetRoleClaims", (string)null);
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("ClaimType")
						.HasColumnType("nvarchar(max)");

					b.Property<string>("ClaimValue")
						.HasColumnType("nvarchar(max)");

					b.Property<string>("UserId")
						.IsRequired()
						.HasColumnType("nvarchar(450)");

					b.HasKey("Id");

					b.HasIndex("UserId");

					b.ToTable("AspNetUserClaims", (string)null);
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
				{
					b.Property<string>("LoginProvider")
						.HasMaxLength(128)
						.HasColumnType("nvarchar(128)");

					b.Property<string>("ProviderKey")
						.HasMaxLength(128)
						.HasColumnType("nvarchar(128)");

					b.Property<string>("ProviderDisplayName")
						.HasColumnType("nvarchar(max)");

					b.Property<string>("UserId")
						.IsRequired()
						.HasColumnType("nvarchar(450)");

					b.HasKey("LoginProvider", "ProviderKey");

					b.HasIndex("UserId");

					b.ToTable("AspNetUserLogins", (string)null);
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
				{
					b.Property<string>("UserId")
						.HasColumnType("nvarchar(450)");

					b.Property<string>("RoleId")
						.HasColumnType("nvarchar(450)");

					b.HasKey("UserId", "RoleId");

					b.HasIndex("RoleId");

					b.ToTable("AspNetUserRoles", (string)null);
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
				{
					b.Property<string>("UserId")
						.HasColumnType("nvarchar(450)");

					b.Property<string>("LoginProvider")
						.HasMaxLength(128)
						.HasColumnType("nvarchar(128)");

					b.Property<string>("Name")
						.HasMaxLength(128)
						.HasColumnType("nvarchar(128)");

					b.Property<string>("Value")
						.HasColumnType("nvarchar(max)");

					b.HasKey("UserId", "LoginProvider", "Name");

					b.ToTable("AspNetUserTokens", (string)null);
				});

			modelBuilder.Entity("PetPlant", b =>
				{
					b.Property<int>("PetsId")
						.HasColumnType("int");

					b.Property<int>("PlantsId")
						.HasColumnType("int");

					b.HasKey("PetsId", "PlantsId");

					b.HasIndex("PlantsId");

					b.ToTable("PetPlant");
				});

			modelBuilder.Entity("PetUserConfiguration", b =>
				{
					b.Property<int>("PetsId")
						.HasColumnType("int");

					b.Property<string>("UsersId")
						.HasColumnType("nvarchar(450)");

					b.HasKey("PetsId", "UsersId");

					b.HasIndex("UsersId");

					b.ToTable("PetUserConfiguration");
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.ApplicationUser", b =>
				{
					b.Property<string>("Id")
						.HasColumnType("nvarchar(450)");

					b.Property<int>("AccessFailedCount")
						.HasColumnType("int");

					b.Property<string>("ConcurrencyStamp")
						.IsConcurrencyToken()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("Email")
						.HasMaxLength(256)
						.HasColumnType("nvarchar(256)");

					b.Property<bool>("EmailConfirmed")
						.HasColumnType("bit");

					b.Property<bool>("IsFirstTimeLogin")
						.HasColumnType("bit");

					b.Property<bool>("LockoutEnabled")
						.HasColumnType("bit");

					b.Property<DateTimeOffset?>("LockoutEnd")
						.HasColumnType("datetimeoffset");

					b.Property<string>("NormalizedEmail")
						.HasMaxLength(256)
						.HasColumnType("nvarchar(256)");

					b.Property<string>("NormalizedUserName")
						.HasMaxLength(256)
						.HasColumnType("nvarchar(256)");

					b.Property<string>("PasswordHash")
						.HasColumnType("nvarchar(max)");

					b.Property<string>("PhoneNumber")
						.HasColumnType("nvarchar(max)");

					b.Property<bool>("PhoneNumberConfirmed")
						.HasColumnType("bit");

					b.Property<string>("SecurityStamp")
						.HasColumnType("nvarchar(max)");

					b.Property<int>("Tier")
						.HasColumnType("int")
						.HasComment("Profile tier");

					b.Property<int>("TierPoints")
						.HasColumnType("int")
						.HasComment("Profile tier points");

					b.Property<bool>("TwoFactorEnabled")
						.HasColumnType("bit");

					b.Property<bool>("UserConfigurationIsNull")
						.HasColumnType("bit");

					b.Property<string>("UserName")
						.HasMaxLength(256)
						.HasColumnType("nvarchar(256)");

					b.Property<string>("UserPictureUrl")
						.HasColumnType("nvarchar(max)")
						.HasComment("Profile picture");

					b.Property<string>("UsersConfigurationId")
						.HasColumnType("nvarchar(max)")
						.HasComment("Additional profile configuration");

					b.HasKey("Id");

					b.HasIndex("NormalizedEmail")
						.HasDatabaseName("EmailIndex");

					b.HasIndex("NormalizedUserName")
						.IsUnique()
						.HasDatabaseName("UserNameIndex")
						.HasFilter("[NormalizedUserName] IS NOT NULL");

					b.ToTable("ApplicationUsers", (string)null);
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.City", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int")
						.HasComment("Identifier");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<int>("CountryId")
						.HasColumnType("int")
						.HasComment("Country identifier");

					b.Property<int?>("Humidity")
						.HasColumnType("int")
						.HasComment("City humidity");

					b.Property<string>("Name")
						.IsRequired()
						.HasMaxLength(165)
						.HasColumnType("nvarchar(165)")
						.HasComment("City name");

					b.HasKey("Id");

					b.HasIndex("CountryId");

					b.ToTable("Cities");
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.Country", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int")
						.HasComment("Identifier");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("Name")
						.IsRequired()
						.HasMaxLength(60)
						.HasColumnType("nvarchar(60)")
						.HasComment("Country name");

					b.HasKey("Id");

					b.ToTable("Countries");
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.UserConfiguration", b =>
				{
					b.Property<string>("Id")
						.HasColumnType("nvarchar(450)")
						.HasComment("Identifier");

					b.Property<string>("ApplicationUserId")
						.IsRequired()
						.HasColumnType("nvarchar(450)")
						.HasComment("User identifier");

					b.Property<int?>("CityId")
						.HasColumnType("int")
						.HasComment("City identifier");

					b.Property<int>("Direction")
						.HasColumnType("int");

					b.Property<bool>("Kids")
						.HasColumnType("bit");

					b.Property<int>("Lifestyle")
						.HasColumnType("int");

					b.HasKey("Id");

					b.HasIndex("ApplicationUserId")
						.IsUnique();

					b.HasIndex("CityId");

					b.ToTable("UserConfigurations");
				});

			modelBuilder.Entity("Plants.Data.Models.Comment.Comment", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int")
						.HasComment("Identifier");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("ApplicationUserId")
						.IsRequired()
						.HasColumnType("nvarchar(450)")
						.HasComment("User identifier");

					b.Property<string>("Content")
						.IsRequired()
						.HasMaxLength(350)
						.HasColumnType("nvarchar(350)")
						.HasComment("Comment content");

					b.Property<DateTime>("CreatedOn")
						.HasColumnType("datetime2");

					b.Property<int>("PlantId")
						.HasColumnType("int")
						.HasComment("Plant identifier");

					b.Property<DateTime?>("UpdatedOn")
						.HasColumnType("datetime2");

					b.HasKey("Id");

					b.HasIndex("ApplicationUserId");

					b.HasIndex("PlantId");

					b.ToTable("Comments");
				});

			modelBuilder.Entity("Plants.Data.Models.Pet.Pet", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int")
						.HasComment("Identifier");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("Name")
						.IsRequired()
						.HasMaxLength(50)
						.HasColumnType("nvarchar(50)")
						.HasComment("Pet type");

					b.HasKey("Id");

					b.ToTable("Pets");

					b.HasData(
						new
						{
							Id = 1,
							Name = "Cat"
						},
						new
						{
							Id = 2,
							Name = "Dog"
						});
				});

			modelBuilder.Entity("Plants.Data.Models.Plant.Plant", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int")
						.HasComment("Identifier");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<int>("Difficulty")
						.HasColumnType("int");

					b.Property<int>("Humidity")
						.HasColumnType("int");

					b.Property<string>("ImageUrl")
						.IsRequired()
						.HasColumnType("nvarchar(max)")
						.HasComment("Plant image");

					b.Property<bool>("IsTrending")
						.HasColumnType("bit");

					b.Property<bool>("KidSafe")
						.HasColumnType("bit");

					b.Property<int>("Lifestyle")
						.HasColumnType("int");

					b.Property<string>("Name")
						.IsRequired()
						.HasMaxLength(70)
						.HasColumnType("nvarchar(70)")
						.HasComment("Plant common name");

					b.Property<bool>("Outdoor")
						.HasColumnType("bit");

					b.Property<string>("ScientificName")
						.HasMaxLength(100)
						.HasColumnType("nvarchar(100)")
						.HasComment("Plant scientific name");

					b.HasKey("Id");

					b.ToTable("Plants");

					b.HasData(
						new
						{
							Id = 1,
							Difficulty = 0,
							Humidity = 1,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/0.jpg",
							IsTrending = true,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Buddhist Pine",
							Outdoor = true,
							ScientificName = "Podocarpus Macrophyllus"
						},
						new
						{
							Id = 2,
							Difficulty = 0,
							Humidity = 1,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/13.jpg",
							IsTrending = false,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Spider plant",
							Outdoor = false,
							ScientificName = "Chlorophytum comosum"
						},
						new
						{
							Id = 3,
							Difficulty = 0,
							Humidity = 2,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/10.jpg",
							IsTrending = false,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Rubber fig",
							Outdoor = false,
							ScientificName = "Ficus elastica"
						},
						new
						{
							Id = 4,
							Difficulty = 0,
							Humidity = 1,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/12.jpg",
							IsTrending = false,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Areca palm",
							Outdoor = true,
							ScientificName = "Dypsis lutescens"
						},
						new
						{
							Id = 5,
							Difficulty = 0,
							Humidity = 2,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/11.jpg",
							IsTrending = false,
							KidSafe = true,
							Lifestyle = 1,
							Name = "Watermelon Peperomia",
							Outdoor = false,
							ScientificName = "Peperomia argyreia"
						},
						new
						{
							Id = 6,
							Difficulty = 0,
							Humidity = 2,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/1.jpg",
							IsTrending = true,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Snake Plant",
							Outdoor = false,
							ScientificName = "Dracaena Trifasciata"
						},
						new
						{
							Id = 7,
							Difficulty = 0,
							Humidity = 2,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/8.jpg",
							IsTrending = true,
							KidSafe = false,
							Lifestyle = 2,
							Name = "Swiss cheese plant",
							Outdoor = true,
							ScientificName = "Monstera minima"
						},
						new
						{
							Id = 8,
							Difficulty = 1,
							Humidity = 1,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/2.jpg",
							IsTrending = true,
							KidSafe = false,
							Lifestyle = 2,
							Name = "Cherry Laurel Novita",
							Outdoor = true,
							ScientificName = "Prunus Laurocerasus Novita"
						},
						new
						{
							Id = 9,
							Difficulty = 1,
							Humidity = 2,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/3.jpg",
							IsTrending = true,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Vanuatu Fan Palm",
							Outdoor = true,
							ScientificName = "Licuala grandis"
						},
						new
						{
							Id = 10,
							Difficulty = 0,
							Humidity = 0,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/4.jpg",
							IsTrending = true,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Peruvian apple cactus",
							Outdoor = true,
							ScientificName = "Cereus Peruvianus"
						},
						new
						{
							Id = 11,
							Difficulty = 1,
							Humidity = 2,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/5.jpg",
							IsTrending = true,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Boston Fern",
							Outdoor = true,
							ScientificName = "Nephrolepis exaltata"
						},
						new
						{
							Id = 12,
							Difficulty = 1,
							Humidity = 2,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/6.jpg",
							IsTrending = true,
							KidSafe = true,
							Lifestyle = 2,
							Name = "Kentia Palm",
							Outdoor = true,
							ScientificName = "Howea forsteriana"
						},
						new
						{
							Id = 13,
							Difficulty = 0,
							Humidity = 1,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/7.jpg",
							IsTrending = true,
							KidSafe = true,
							Lifestyle = 2,
							Name = "ZZ Plant",
							Outdoor = true,
							ScientificName = "Zamioculcas"
						},
						new
						{
							Id = 14,
							Difficulty = 1,
							Humidity = 2,
							ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/9.jpg",
							IsTrending = true,
							KidSafe = false,
							Lifestyle = 2,
							Name = "Heart of Jesus",
							Outdoor = false,
							ScientificName = "Caladium Bicolour"
						});
				});

			modelBuilder.Entity("ApplicationUserPlant", b =>
				{
					b.HasOne("Plants.Data.Models.Plant.Plant", null)
						.WithMany()
						.HasForeignKey("LikedPlantsId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("Plants.Data.Models.ApplicationUser.ApplicationUser", null)
						.WithMany()
						.HasForeignKey("UsersLikedPlantId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("ApplicationUserPlant1", b =>
				{
					b.HasOne("Plants.Data.Models.ApplicationUser.ApplicationUser", null)
						.WithMany()
						.HasForeignKey("OwnersId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("Plants.Data.Models.Plant.Plant", null)
						.WithMany()
						.HasForeignKey("PlantsOwnedId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
				{
					b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
						.WithMany()
						.HasForeignKey("RoleId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
				{
					b.HasOne("Plants.Data.Models.ApplicationUser.ApplicationUser", null)
						.WithMany()
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
				{
					b.HasOne("Plants.Data.Models.ApplicationUser.ApplicationUser", null)
						.WithMany()
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
				{
					b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
						.WithMany()
						.HasForeignKey("RoleId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("Plants.Data.Models.ApplicationUser.ApplicationUser", null)
						.WithMany()
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
				{
					b.HasOne("Plants.Data.Models.ApplicationUser.ApplicationUser", null)
						.WithMany()
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("PetPlant", b =>
				{
					b.HasOne("Plants.Data.Models.Pet.Pet", null)
						.WithMany()
						.HasForeignKey("PetsId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("Plants.Data.Models.Plant.Plant", null)
						.WithMany()
						.HasForeignKey("PlantsId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("PetUserConfiguration", b =>
				{
					b.HasOne("Plants.Data.Models.Pet.Pet", null)
						.WithMany()
						.HasForeignKey("PetsId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("Plants.Data.Models.ApplicationUser.UserConfiguration", null)
						.WithMany()
						.HasForeignKey("UsersId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.City", b =>
				{
					b.HasOne("Plants.Data.Models.ApplicationUser.Country", "Country")
						.WithMany("Cities")
						.HasForeignKey("CountryId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("Country");
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.UserConfiguration", b =>
				{
					b.HasOne("Plants.Data.Models.ApplicationUser.ApplicationUser", "ApplicationUser")
						.WithOne("UserConfiguration")
						.HasForeignKey("Plants.Data.Models.ApplicationUser.UserConfiguration", "ApplicationUserId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("Plants.Data.Models.ApplicationUser.City", "City")
						.WithMany("Users")
						.HasForeignKey("CityId");

					b.Navigation("ApplicationUser");

					b.Navigation("City");
				});

			modelBuilder.Entity("Plants.Data.Models.Comment.Comment", b =>
				{
					b.HasOne("Plants.Data.Models.ApplicationUser.ApplicationUser", "User")
						.WithMany("Comments")
						.HasForeignKey("ApplicationUserId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("Plants.Data.Models.Plant.Plant", "Plant")
						.WithMany("Comments")
						.HasForeignKey("PlantId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("Plant");

					b.Navigation("User");
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.ApplicationUser", b =>
				{
					b.Navigation("Comments");

					b.Navigation("UserConfiguration");
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.City", b =>
				{
					b.Navigation("Users");
				});

			modelBuilder.Entity("Plants.Data.Models.ApplicationUser.Country", b =>
				{
					b.Navigation("Cities");
				});

			modelBuilder.Entity("Plants.Data.Models.Plant.Plant", b =>
				{
					b.Navigation("Comments");
				});
#pragma warning restore 612, 618
		}
	}
}
