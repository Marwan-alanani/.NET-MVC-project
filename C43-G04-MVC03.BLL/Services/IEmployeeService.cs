global using C43_G04_MVC03.BLL.DataTrasferObjects.Employees;

namespace C43_G04_MVC03.BLL.Services;

public interface IEmployeeService
{
    int Add(EmployeeRequest request);
    IEnumerable<EmployeeResponse> GetAll(string? SearchValue);
    EmployeeDetailsResponse? GetById(int id);
    int Update(EmployeeUpdateRequest request);
    bool Delete(int id);
}