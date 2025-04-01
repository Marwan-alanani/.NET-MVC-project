using C43_G04_MVC03.Presentation.DAL.Data.Context.Configurations;
using C43_G04_MVC03.Presentation.DAL.Models;

namespace C43_G04_MVC03.Presentation.DAL.Data.Context;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfigurations).Assembly);
    }

}