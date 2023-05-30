using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using UniRate.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UniRateContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UniRateContext") ?? throw new InvalidOperationException("Connection string 'UniRateContext' not found.")));


// Add services to the container.
//builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("Database"));
builder.Services.AddControllersWithViews();

//Add authentication cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "LoginCookie"; //Name of the cookie
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); //After 20 minutes the cookie will expire and the user will be logged out
        options.SlidingExpiration = true; // The logout window reset after every request
        options.AccessDeniedPath = "/Forbidden/";
    });


builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Home}/{action=HomePage}/{id?}");

app.Run();
