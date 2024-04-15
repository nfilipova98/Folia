namespace Plants.Web
{
	using Areas.Identity.Pages.Account;
	using Data;
	using Data.Models.ApplicationUser;
	using Data.Seeding;
	using Services.AboutService;
	using Services.APIs.EmailSenderService;
	using Services.RegionService;
	using Services.CommentService;
	using Services.ContactsService;
	using Services.LayoutService;
	using Services.Mapping;
	using Services.PetService;
	using Services.PlantService;
	using Services.RepositoryService;
	using Services.UserService;
	using ViewModels;

	using Azure.Storage.Blobs;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			ConfigureServices(builder.Services, builder.Configuration);
			var app = builder.Build();
			Configure(app);
			app.Run();
		}

		private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<PlantsDbContext>(
			   options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<ApplicationUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = true;
			})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<PlantsDbContext>();

			services.AddAutoMapper(typeof(AutoMapperProfile));

			services.AddScoped<IRepositoryService, Repository>();

			services.AddTransient<IPlantService, PlantService>();
			services.AddTransient<IRegionService, RegionService>();
			services.AddTransient<IAboutService, AboutService>();
			services.AddTransient<IPetService, PetService>();
			services.AddTransient<ICommentService, CommentService>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<FirstLoginHelper>();
			services.AddTransient<IContactsService, ContactsService>();
			services.AddTransient<ILayoutService, LayoutService>();

			services.AddTransient<ICustomEmailSender, EmailSender>();
			services.Configure<AuthMessageSenderOptions>(configuration);

			services.AddAuthentication()
			.AddFacebook(facebookOptions =>
			{
				facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
				facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
			})
			.AddGoogle(googleOptions =>
			{
				googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
				googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
			});

			string blobString = configuration["BlobConnectionString"];
			services.AddSingleton(x => new BlobServiceClient(blobString));

			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddControllersWithViews(options =>
				options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
		}
		private static void Configure(WebApplication app)
		{
			using (var serviceScope = app.Services.CreateScope())
			{
				var dbContext = serviceScope.ServiceProvider.GetRequiredService<PlantsDbContext>();
				dbContext.Database.Migrate();
				new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
			}

			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapAreaControllerRoute(
			name: "Identity",
			areaName: "Identity",
			pattern: "Identity/{controller=Home}/{action=Index}/{id?}");

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.MapRazorPages();
		}
	}
}