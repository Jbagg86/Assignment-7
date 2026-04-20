using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assignment9A.Data;
using Assignment9A.Models;
using Assignment9A.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Movies", "AdminPolicy");
});

builder.Services.AddDbContext<Assignment9AContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RazorPagesMovieContext")
        ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Assignment9AContext>();

builder.Services.AddHttpClient<IMovieRepo, MovieRepoApi>(client =>
{
    var baseUrl = builder.Configuration["ApiSettings:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl!);
});
// builder.Services.AddSingleton<IMovieRepo, MovieRepoList>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireRole("Admin");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    await AdminHelper.SeedAdminAsync(scope.ServiceProvider);
}

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "test@test.com";
    string password = "#Password123";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();