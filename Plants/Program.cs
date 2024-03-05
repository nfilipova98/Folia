using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plants.Data;
namespace Plants.Web
{
	using Data;
	using Data.Models.ApplicationUser;
	using Data.Seeding;
	using Services.BlobService;
	using Services.BlobService.Interfaces;
	using Services.EmailSenderService;

	using Azure.Storage.Blobs;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.UI.Services;
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

		//AutoMapper
		//builder.Services.AddAutoMapper(typeof(Program));

		//var mapperConfig = new MapperConfiguration(mc =>
		//{
		//	mc.AddProfile(new AutoMapperProfile());
		//});

		//IMapper mapper = mapperConfig.CreateMapper();
		//builder.Services.AddSingleton(mapper);

		private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			//Db context
			services.AddDbContext<PlantsDbContext>(
			   options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			//Identity service
			services.AddDefaultIdentity<ApplicationUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = true;
			})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<PlantsDbContext>();

			//Email Sender service
			services.AddTransient<IEmailSender, EmailSender>();
			services.Configure<AuthMessageSenderOptions>(configuration);

			//Login Services
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

			//Blob service
			string blobString = configuration["BlobConnectionString"];

			services.AddSingleton(x => new BlobServiceClient(blobString));
			services.AddSingleton<IBlobService, BlobService>();

			//Filters
			services.AddDatabaseDeveloperPageExceptionFilter();

			//Validation AntiForgery Filter
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

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();
		}
	}
}