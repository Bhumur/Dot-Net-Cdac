namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Default}/{action=Index}/{id:int?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-9.0

//localhost:1234/MyCtrl/MyAction1/123

//localhost:1234/Employees/Display/123
//localhost:1234/Employees/Edit/123

//localhost:1234/Employees/DisplayAll
//localhost:1234/Employees/Create

//localhost:1234/Employees ----> Employees,Index
//localhost:1234 ----> Home,Index


