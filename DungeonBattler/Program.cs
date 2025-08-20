using DungeonBattler.Data;
using DungeonBattler.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GameContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GameDatabase")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<GameContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GameContext>();
    context.Database.EnsureCreated();

    if (!context.NonPlayerChar.Any())
    {
        context.NonPlayerChar.AddRange(
            new NonPlayerChar { Name = "Goblin", Health = 30, Attack = 5, BaseHealth = 30, BaseAttack = 5 },
            new NonPlayerChar { Name = "Orc", Health = 50, Attack = 8, BaseHealth = 50, BaseAttack = 8 },
            new NonPlayerChar { Name = "Elf Archer", Health = 25, Attack = 10, BaseHealth = 25, BaseAttack = 10 }
        );
        context.SaveChanges();
    }

    if (!context.PlayerChar.Any())
    {
        context.PlayerChar.AddRange(
            new PlayerChar { Name = "Swordsman", Health = 80, Attack = 10, Strength = 10 , Dexterity = 4, Inteligence=1, BaseHealth = 60, BaseAttack = 10, BaseStrength = 10, BaseDexterity = 4, BaseInteligence = 1 }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapRazorPages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
