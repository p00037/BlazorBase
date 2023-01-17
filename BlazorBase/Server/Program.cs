using BlazorBase.Server.Data;
using BlazorBase.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlazorBase.Infrastructure.Contexts;
using BlazorBase.Domain.Models;
using BlazorBase.Domain.Framework;
using BlazorBase.Infrastructure.Repository;
using BlazorBase.Infrastructure;
using BlazorBase.Application.UseCases;
using BlazorBase.Domain.Models.LoginUser;
using BlazorBase.Server.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
var blazorBaseConnectionString = builder.Configuration.GetConnectionString("BlazorBaseContextConnection");
builder.Services.AddDbContext<BlazorBaseContext>(options => options.UseSqlServer(blazorBaseConnectionString));

builder.Services.AddScoped<IM_事業所Repository, M_事業所Repository>();
builder.Services.AddScoped<IM_事業所明細Repository, M_事業所明細Repository>();
builder.Services.AddScoped<IM_ログインユーザーRepository, M_ログインユーザーRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<MstOfficeUseCase>();
builder.Services.AddScoped<IIdentityUserManager, IdentityUserManager>();
builder.Services.AddScoped<MstLoginUserUseCase>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

//データベースの更新
using (IServiceScope scope = app.Services.CreateScope())
{
    using BlazorBaseContext context = scope.ServiceProvider.GetRequiredService<BlazorBaseContext>();
    context.Database.Migrate();
}

//データベースの更新
using (IServiceScope scope = app.Services.CreateScope())
{
    using ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.Run();
