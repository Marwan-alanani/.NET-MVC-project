using Microsoft.AspNetCore.Mvc.Rendering;

namespace C43_G04_MVC03.Presentation.Controllers;

public class EmployeesController(
    IEmployeeService employeeService,
    IWebHostEnvironment webHostEnvironment,
    ILogger<DepartmentsController> logger) : Controller
{
    private readonly IEmployeeService _employeeService = employeeService;
    private readonly IWebHostEnvironment _env = webHostEnvironment;

    private readonly ILogger<DepartmentsController> _logger = logger;

    // GET
    [HttpGet]
    public IActionResult Index(string? SearchValue)
    {
        var employees = _employeeService.GetAll(SearchValue);
        return View(employees); // Send Data From Action To View
    }

    #region Create

    [HttpGet]
    public IActionResult Create([FromServices] IDepartmentService departmentService)
    {
        var departments = departmentService.GetAll();
        var items = new SelectList(departments,
            nameof(DepartmentResponse.Id) , 
            nameof(DepartmentResponse.Name));
        ViewBag.Departments = items;
        return View();
    }

    [HttpPost]
    public IActionResult Create(EmployeeRequest request)
    {
        if (!ModelState.IsValid) return View(request); // Server Side Validation
        try
        {
            var result = _employeeService.Add(request);
            if (result > 0) return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "Failed to add department");

            return View(request);
        }
        catch (Exception e)
        {
            if (_env.IsDevelopment()) ModelState.AddModelError(string.Empty, e.Message);
            else _logger.LogError(e, e.Message);

            return View(request);
        }
    }

    #endregion

    #region Details

    [HttpGet]
    public IActionResult Details(int? id)
    {
        if (!id.HasValue) return BadRequest();
        var employee = _employeeService.GetById(id.Value);
        return View(employee);
    }

    #endregion

    #region Edit

    [HttpGet]
    public IActionResult Edit(int? id, [FromServices] IDepartmentService departmentService)
    {
        if (!id.HasValue) return BadRequest();
        var employee = _employeeService.GetById(id.Value);
        var employeeUpdateRequest = new EmployeeUpdateRequest()
        {
            Id = employee.Id,
            Address = employee.Address,
            Email = employee.Email,
            Name = employee.Name,
            Age = employee.Age,
            Gender = Enum.Parse<Gender>(employee.Gender),
            Salary = employee.Salary,
            EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
            HiringDate = employee.HiringDate,
            IsActive = employee.IsActive,
            PhoneNumber = employee.PhoneNumber,
        };
        var departments = departmentService.GetAll();
        var items = new SelectList(departments,
            nameof(DepartmentResponse.Id) , 
            nameof(DepartmentResponse.Name));
        ViewBag.Departments = items;
        return View(employeeUpdateRequest);
    }

    [HttpPost]
    public IActionResult Edit([FromRoute] int id, EmployeeUpdateRequest request)
    {
        if (id != request.Id) return BadRequest();
        try
        {
            var result = _employeeService.Update(request);
            if (result > 0) return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "Failed to Update department");

            return View(request);
        }
        catch (Exception e)
        {
            if (_env.IsDevelopment()) ModelState.AddModelError(string.Empty, e.Message);
            else _logger.LogError(e, e.Message);

            return View(request);
        }
    }

    #endregion

    #region Delete

    [HttpGet]
    [ActionName("Delete")]
    public IActionResult ConfirmDelete(int? id)
    {
        if (!id.HasValue) return BadRequest();
        var employee = _employeeService.GetById(id.Value);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Delete([FromRoute] int? id)
    {
        if (!id.HasValue) return BadRequest();
        string message;
        try
        {
            var result = _employeeService.Delete(id.Value);
            if (result)
            {
                message = "Successfully deleted employee";
            }
            else
            {
                message = $"Failed to delete department with id {id.Value}";
            }

            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            if (_env.IsDevelopment()) ModelState.AddModelError(string.Empty, e.Message);
            else _logger.LogError(e, e.Message);
        }

        return RedirectToAction(nameof(Index));
    }

    #endregion
}