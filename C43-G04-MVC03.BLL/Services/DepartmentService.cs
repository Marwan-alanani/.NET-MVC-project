global using C43_G04_MVC03.Presentation.DAL.Repositories;

namespace C43_G04_MVC03.BLL.Services;
public class DepartmentService(IUnitOfWork unitOfWork) :  IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    // private readonly IDepartmentRepository _unitOfWork = repository;
    

    // Get All
    public IEnumerable<DepartmentResponse> GetAll()
    {
        var departments = _unitOfWork.Departments.GetAll();
        return departments.Select(d => d.ToResponse());
    }

    // Get
    public DepartmentDetailsResponse? GetById(int id)
    {
        var department = _unitOfWork.Departments.GetById(id);

        return department is null ? null : department.ToDetailsResponse();
    }

    // Add
    public int Add(DepartmentRequest request)
    {
        _unitOfWork.Departments.Add(request.ToEntity());
        return _unitOfWork.SaveChanges();
    }
   
    // Update
    public int Update(DepartmentUpdateRequest request)
    {
        _unitOfWork.Departments.Update(request.ToEntity());
        return _unitOfWork.SaveChanges();
    }
    
    // Delete
    public bool Delete(int id)
    {
       var department = _unitOfWork.Departments.GetById(id); 
       if (department is null) return false;
       _unitOfWork.Departments.Delete(department);
       return _unitOfWork.SaveChanges() > 0 ? true : false;
    }
}