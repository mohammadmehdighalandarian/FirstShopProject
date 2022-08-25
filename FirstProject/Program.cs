using FirstProject.Data;
using FirstProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Db Context

builder.Services.AddDbContext<FirstProjectContext>(options =>
{
    options.UseSqlServer("Data source=.\\SQL2019;initial Catalog=First_Shop_DB;Integrated Security=True");
});

#endregion

#region Ioc

builder.Services.AddScoped<IGroupRepository, GroupRepository>();

#endregion

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
