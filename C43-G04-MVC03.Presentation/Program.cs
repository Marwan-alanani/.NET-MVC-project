
using C43_G04_MVC03.Presentation.Services;

namespace C43_G04_MVC03.Presentation;

public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });
        
        // builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        // builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);
        
        
        // LifeTime services
        builder.Services.AddSingleton<ISingletonSerivce, SingletonService>(); // Creates one instance per application
        builder.Services.AddScoped<IScopedService, ScopedService>(); // Creates one instance per request
        builder.Services.AddTransient<ITransientService, TransientService>(); // Creates one instance per operation

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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
    }
}