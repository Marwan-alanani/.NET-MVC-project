namespace C43_G04_MVC03.Presentation.Controllers;

public class DepartmentsController(
    IDepartmentService departmentService,
    IWebHostEnvironment webHostEnvironment,
    ILogger<DepartmentsController> logger) : Controller
{
    private readonly IDepartmentService _departmentService = departmentService;
    private readonly IWebHostEnvironment _env = webHostEnvironment;
    private readonly ILogger<DepartmentsController> _logger = logger;

    [HttpGet]
    // Send Data From Action to View
    // 1. ViewData => ViewDataDictionary <String,object>
    // 2. ViewBag  => ViewDataDictionary <String,object> dynamic
    // Send Data from action to view
    // Send Data from view to partial view
    // Send Data from view to Layout
    // View data and View bag reference the same object in memory
    // ViewData["key"] == ViewBag.key is True
    
    // 3. TempData
    // Send data from action to another action or
    // Send Data from an action to the view of the next request
    public IActionResult Index()
    {
        var departments = departmentService.GetAll();
        return View(departments); // Send Data From Action To View
    }

    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]  // => Action Filter
    public IActionResult Create(DepartmentRequest request)
    {
        if (!ModelState.IsValid) return View(request); // Server Side Validation
        string message;
        try
        {
            var result = _departmentService.Add(request);
            if (result > 0) message = $"Department {request.Name} created";
            else message = "Can't create Department";
            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
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
        var department = _departmentService.GetById(id.Value);
        return View(department);
    }

    #endregion

    #region Edit

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (!id.HasValue) return BadRequest();
        var department = _departmentService.GetById(id.Value);
        return View(department.ToUpdateRequest());
    }

    [HttpPost]
    public IActionResult Edit( [FromRoute]int id ,DepartmentUpdateRequest request)
    {
        if(id != request.Id) return BadRequest();
        try
        {
            var result = _departmentService.Update(request);
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
        var department = _departmentService.GetById(id.Value);
        return View(department);
    }

    [HttpPost]
    public IActionResult Delete([FromRoute] int? id)
    {
        if(!id.HasValue) return BadRequest();
        string message;
        try
        {
            var result =  _departmentService.Delete(id.Value);
            if (result)
            {
                message = "Successfully deleted department";
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