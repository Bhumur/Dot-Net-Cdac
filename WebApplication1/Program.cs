namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.Add

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                                //pattern: "{controller=Default}/{action=Index}/{id?}/{a?}/{b?}/{c?}")
                                //https://localhost:7037/Default/Index/55565?a=122&c=21&b=2
                                pattern: "{controller=Default}/{action=Coustom}/{EmpNo?}")//QueryString

                .WithStaticAssets();

            app.Run();
        }
    }
}
