namespace C43_G04_MVC03.BLL.DataTrasferObjects.Departments;

public class DepartmentUpdateRequest
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; }
    public DateOnly CreatedOn { get; set; }
}