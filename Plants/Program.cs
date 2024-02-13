using Plants.Data;
using Plants.Data.Models.ApplicationUser;
using Plants.Services.BlobService;
using Plants.Services.BlobService.Interfaces;
using Plants.Services.EmailSenderService;

using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Plants.Services.AutoMapperService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Db context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
	?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<PlantsDbContext>(options =>
	options.UseSqlServer(connectionString));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var mapperConfig = new MapperConfiguration(mc =>
{
	mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//Identity service
builder.Services.AddDefaultIdentity<ApplicationUser>
	(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<PlantsDbContext>();

//Email Sender service
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

//Login Services
var services = builder.Services;
var configuration = builder.Configuration;

builder.Services.AddAuthentication()
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

builder.Services.AddSingleton(x => new BlobServiceClient(blobString));
builder.Services.AddSingleton<IBlobService, BlobService>();

//Filters
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Validation AntiForgery Filter
builder.Services.AddControllersWithViews(options =>
	options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
