using System.Security.Claims;
using FirstProject.Data;
using FirstProject.Data.Repositories;
using FirstProject.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region Db Context

builder.Services.AddDbContext<FirstProjectContext>(options =>
{
    options.UseSqlServer("Data source=.\\SQL2019;initial Catalog=First_Shop_DB;Integrated Security=True");
});

#endregion

#region Ioc
// dirty
//service.AddScoped<IGroupRepository, GroupRepository>();
//service.AddScoped<IUserRepository, UserRepository>();

// Clean
//Make Class in Model and ....
DependencyContainer.RegisterDependency(builder.Services);

#endregion

#region Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Account/Login";
        option.LogoutPath = "/Account/Logout";
        option.ExpireTimeSpan = TimeSpan.FromDays(10);   //man ra 10 roz be khater dashte bash
    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



//app.UseStatusCodePagesWithRedirects("/StatusCode/{0}");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    // Do work that doesn't write to the Response.
    if (context.Request.Path.StartsWithSegments("/Admin"))
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Account/Login");
        }
        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
        {
            context.Response.Redirect("/Account/Login");
        }
    }
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
