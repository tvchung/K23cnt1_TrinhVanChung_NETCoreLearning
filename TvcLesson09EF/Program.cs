using Microsoft.EntityFrameworkCore;
using TvcLesson09EF.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("TvcBookStore");
builder.Services.AddDbContext<TvcBookStoreContext>(x => x.UseSqlServer(connectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/TvcHome/TvcError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TvcHome}/{action=TvcIndex}/{tvcId?}");

app.Run();
