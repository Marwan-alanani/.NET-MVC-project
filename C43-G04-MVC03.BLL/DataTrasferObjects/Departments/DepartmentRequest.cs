namespace C43_G04_MVC03.BLL.DataTrasferObjects.Departments;

public class DepartmentRequest
{
    [Required(ErrorMessage = "Name is required!!!")]
    [StringLength(maximumLength: 50, MinimumLength = 5)]
    public string Name { get; set; }

    [MinLength(10)] public string? Description { get; set; }
    public string Code { get; set; }
    public DateTime CreatedOn { get; set; }
}