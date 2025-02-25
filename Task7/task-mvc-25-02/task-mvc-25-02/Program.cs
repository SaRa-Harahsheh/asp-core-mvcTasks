using Microsoft.EntityFrameworkCore;
using task_mvc_25_02.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //??? ???? ????? ??????? ??? ?? ??? ???? ?????? ???????? 
    options.IdleTimeout = TimeSpan.FromSeconds(500);
    //???? JavaScript ?? ?????? ???? ??????? ?????? ??????? ???? ??????? ?? ?????
    options.Cookie.HttpOnly = true;
    //?????? ?????? ??????? ?????? ???? ???????? ??? ?? ??? ???????? ???? ??????? ??????????.
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));



var app = builder.Build();

app.UseSession();

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
