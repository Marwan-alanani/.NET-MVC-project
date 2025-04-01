namespace C43_G04_MVC03.BLL.Services;
public class EmployeeService(IUnitOfWork unitOfWork,
    IMapper mapper ,
    IAttachmentService attachmentService) : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IAttachmentService _attachmentService = attachmentService; 


    // Get All
    public IEnumerable<EmployeeResponse> GetAll(string? SearchValue)
    {
        // var employees = _repository.GetAll();
        // return _mapper.Map<IEnumerable<EmployeeResponse>>(employees);


        // Filtration => Remote
        // Projection => Remote
        // var employees = _repository.GetAllQueryable().Select(e =>
        //     new EmployeeResponse()
        //     {
        //         Id = e.Id,
        //         Name = e.Name,
        //         Email = e.Email,
        //         Age = e.Age,
        //         Gender = e.Gender.ToString(),
        //         Salary = e.Salary,
        //         EmployeeType = e.EmployeeType.ToString(),
        //         IsActive = e.IsActive,
        //     });
        // return employees;

        if (string.IsNullOrEmpty(SearchValue))
        {
            return _unitOfWork.Employees.GetAll(e => new EmployeeResponse()
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Age = e.Age,
                Gender = e.Gender.ToString(),
                Salary = e.Salary,
                EmployeeType = e.EmployeeType.ToString(),
                IsActive = e.IsActive,
                Department = e.Department.Name
            }, e => !e.IsDeleted, e => e.Department);
        }
        else
        {
            return _unitOfWork.Employees.GetAll(e => new EmployeeResponse()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Age = e.Age,
                    Gender = e.Gender.ToString(),
                    Salary = e.Salary,
                    EmployeeType = e.EmployeeType.ToString(),
                    IsActive = e.IsActive,
                    Department = e.Department.Name
                },
                e => !e.IsDeleted && e.Name.ToLower().Contains(SearchValue.ToLower()),
                e => e.Department);
        }
    }

    // Get
    public EmployeeDetailsResponse? GetById(int id)
    {
        var employee = _unitOfWork.Employees.GetById(id);

        return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsResponse>(employee);
    }

    // Add
    public int Add(EmployeeRequest request)
    {
         _unitOfWork.Employees.Add(_mapper.Map<Employee>(request));
         return _unitOfWork.SaveChanges();
    }

    // Update
    public int Update(EmployeeUpdateRequest request)
    {
        _unitOfWork.Employees.Update(_mapper.Map<Employee>(request));
        return _unitOfWork.SaveChanges();
    }

    // Delete
    public bool Delete(int id)
    {
        var employee = _unitOfWork.Employees.GetById(id);
        if (employee is null) return false;
        employee.IsDeleted = true;
        _unitOfWork.Employees.Update(employee);
        return _unitOfWork.SaveChanges() > 0 ? true : false;
    }
}