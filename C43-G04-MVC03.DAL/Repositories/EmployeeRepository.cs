namespace C43_G04_MVC03.Presentation.DAL.Repositories;

public class EmployeeRepository(ApplicationDbContext context) : GenericRepository<Employee>(context),
    IEmployeeRepository
{
    public IEnumerable<Employee> GetAll(string name)
    {
        return context.Employees.Where(e => e.Name == name);
    }
}