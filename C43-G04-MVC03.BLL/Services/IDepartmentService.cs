global using C43_G04_MVC03.BLL.DataTrasferObjects.Departments;

namespace C43_G04_MVC03.BLL.Services;

public interface IDepartmentService
{
    IEnumerable<DepartmentResponse> GetAll();
    DepartmentDetailsResponse? GetById(int id);
    int Add(DepartmentRequest request);
    int Update(DepartmentUpdateRequest request);
    bool Delete(int id);
}