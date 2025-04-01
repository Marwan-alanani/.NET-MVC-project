namespace C43_G04_MVC03.Presentation.DAL.Repositories;

public interface IUnitOfWork
{
    public IEmployeeRepository Employees { get;  } 
    public IDepartmentRepository Departments { get;  } 
    int SaveChanges();
}