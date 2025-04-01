namespace C43_G04_MVC03.Presentation.DAL.Repositories;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
   public IEnumerable<Employee> GetAll(string name); 
}