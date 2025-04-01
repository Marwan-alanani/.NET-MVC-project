namespace C43_G04_MVC03.Presentation.DAL.Repositories;

public class DepartmentRepository(ApplicationDbContext context) : GenericRepository<Department>(context),
    IDepartmentRepository
{
}