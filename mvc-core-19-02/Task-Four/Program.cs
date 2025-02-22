var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();  // //it found mean your project run in mvc system
     


builder.Services.AddDistributedMemoryCache();      //*** to make space to store session 
builder.Services.AddSession(options =>             //*** register session
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();




var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();             //***Let me use session in the project

app.UseAuthorization();
     

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
