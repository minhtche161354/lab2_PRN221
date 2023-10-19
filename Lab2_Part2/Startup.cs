//using Lab2_Part2.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Builder;
//namespace Lab2_Part2
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddRazorPages();

//            services.AddDbContext<SchoolContext>(options =>
//            options.UseSqlServer(Configuration.GetConnectionString("SchoolContext")));


//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();

//                app.UseDeveloperExceptionPage();
//               // app.UseMigrationsEndPoint();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapRazorPages();
//            });
//        }
//    }

//}
