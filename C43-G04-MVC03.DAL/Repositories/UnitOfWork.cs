namespace C43_G04_MVC03.Presentation.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    // Lazy loading doesn't depend on dependency injection
    // private Lazy<IEmployeeRepository> _employeeRepository;
    // private Lazy<IDepartmentRepository> _departmentRepository;
    
    private readonly Func<IEmployeeRepository> _employeerepositoryFactory;
    private readonly Func<IDepartmentRepository> _departmentrepositoryFactory;

    public UnitOfWork(ApplicationDbContext context,
        Func<IEmployeeRepository> employeerepositoryFactory,
        Func<IDepartmentRepository> departmentrepositoryFactory)
    {
        _context = context;
        _employeerepositoryFactory = employeerepositoryFactory;
        _departmentrepositoryFactory = departmentrepositoryFactory;
    }

    // public IEmployeeRepository Employees => _employeeRepository.Value; // Calls value factory upon retrieval 
    // public IDepartmentRepository Departments => _departmentRepository.Value;// Calls value factory upon retrieval 
    
    private IEmployeeRepository _employeeRepository;
    private IDepartmentRepository _departmentRepository;
    
    // Like lazy loading except this decouples the classes or uses dependency injection
    public IEmployeeRepository Employees => _employeeRepository ??= _employeerepositoryFactory.Invoke();
    public IDepartmentRepository Departments => _departmentRepository ??= _departmentrepositoryFactory.Invoke();
    public int SaveChanges() => _context.SaveChanges();

    // Gets called by Default from the clr with the end of the lifetime of the object
    // public void Dispose()
    // {
    //     throw new NotImplementedException();
    // }
}