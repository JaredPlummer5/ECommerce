using System.Text.Json;
using System.Text.Json.Serialization;
using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddCors();

builder.Services
    .AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

builder.Services.AddMvc();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
      // Tell the authenticaion scheme "how/where" to validate the token + secret
      //   options.Authority = "https://dev-r742ze820hyqp132.us.auth0.com/";
      //   options.Audience = "https://localhost:44401/";
        options.SaveToken = true;
        options.TokenValidationParameters = JwtTokenService.GetValidationParameters(builder.Configuration);
    });
builder.Services.AddAuthorization(options =>
    {

        // Add "Name of Policy", and the Lambda returns a definition
        options.AddPolicy("Admin", policy =>
            policy.RequireClaim("permissions", "create", "update", "delete", "read")
                .RequireRole("Admin"));

        options.AddPolicy("Editor", policy =>
            policy.RequireClaim("permissions", "create", "update")
                .RequireRole("Editor"));
    });

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ECommerceDbContext>()
.AddRoleManager<RoleManager<IdentityRole>>()
.AddUserManager<UserManager<ApplicationUser>>()
.AddSignInManager<SignInManager<ApplicationUser>>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<JwtTokenService>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(builder =>
    builder.WithOrigins("https://localhost:44401")
           .AllowAnyMethod()
           .AllowAnyHeader());
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
