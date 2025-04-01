namespace C43_G04_MVC03.BLL.DataTrasferObjects.Departments;

public class DepartmentResponse
{
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public string? Description { get; set; }
   public string Code { get; set; } = string.Empty;
   public DateOnly CreatedOn { get; set; }
}