namespace C43_G04_MVC03.Presentation.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    // Lazy loading doesn't depend on dependency injection
    private Lazy<IEmployeeRepository> _employeeRepository;
    private Lazy<IDepartmentRepository> _departmentRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _departmentRepository =
            new Lazy<IDepartmentRepository>(() => new DepartmentRepository(context)); // Lazy loads dependencies
        
        _employeeRepository =
            new Lazy<IEmployeeRepository>(() => new EmployeeRepository(context)); // Lazy loads dependencies
    }

    public IEmployeeRepository Employees => _employeeRepository.Value; // Calls value factory upon retrieval 
    public IDepartmentRepository Departments => _departmentRepository.Value;// Calls value factory upon retrieval 
    public int SaveChanges() => _context.SaveChanges();

    // Gets called by Default from the clr with the end of the lifetime of the object
    // public void Dispose()
    // {
    //     throw new NotImplementedException();
    // }
}