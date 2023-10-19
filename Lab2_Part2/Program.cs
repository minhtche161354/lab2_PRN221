using Lab2_Part2.Data;
using Microsoft.EntityFrameworkCore;
using RazorPagesLab.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options => {
    options.Conventions.AddPageRoute("/Students/Index", "");
});
builder.Services.AddDbContext<SchoolContext>(options =>
     options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<SchoolContext>();
    dbContext.Database.Migrate();
    try
    {
        DbInitializer.Initialize(dbContext);
    }
    catch (Exception ex)
    {
        // Handle any exceptions during initialization (e.g., logging).
    }
}
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

//using Lab2_Part2.Data;
//using Lab2_Part2;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        var host = CreateHostBuilder(args).Build();
//        CreateDbIfNotExists(host);
//        host.Run();
//    }

//    private static void CreateDbIfNotExists(IHost host)
//    {
//        using (var scope = host.Services.CreateScope())
//        {
//            var services = scope.ServiceProvider;
//            try
//            {
//                var context = services.GetRequiredService<SchoolContext>();
//                context.Database.EnsureCreated();
//                // DbInitializer.Initialize(context);
//            }
//            catch (Exception ex)
//            {
//                var logger = services.GetRequiredService<ILogger<Program>>();
//                logger.LogError(ex, "An error occurred creating the DB.");
//            }
//        }
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.UseStartup<Startup>();
//            });
//}
