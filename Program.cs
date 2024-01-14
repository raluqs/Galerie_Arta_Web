using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Galerie_Arta_Web.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(
    options =>
    {
        options.Conventions.AuthorizeFolder("/Tablouri");
        options.Conventions.AllowAnonymousToPage("/Tablouri/Index");
        options.Conventions.AllowAnonymousToPage("/Tablouri/Details");
        options.Conventions.AuthorizeFolder("/Utilizatori", "AdminPolicy");
        options.Conventions.AuthorizeFolder("/Artisti");
        options.Conventions.AllowAnonymousToPage("/Artisti/Index");
        options.Conventions.AllowAnonymousToPage("/Artisti/Details");
        options.Conventions.AuthorizeFolder("/Programari");
      
        


    }
    );
builder.Services.AddDbContext<Galerie_Arta_WebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Galerie_Arta_WebContext") ?? throw new InvalidOperationException("Connection string 'Galerie_Arta_WebContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Galerie_Arta_WebContext") ?? throw new InvalidOperationException("Connection string 'Galerie_Arta_WebContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
