using C43_G04_MVC03.Presentation.DAL.Models;

namespace C43_G04_MVC03.BLL.DataTrasferObjects.Departments;

public static class DepartmentFactory
{
    public static DepartmentResponse ToResponse(this Department department) =>
        new DepartmentResponse()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
            Code = department.Code
        };

    public static DepartmentDetailsResponse ToDetailsResponse(this Department department) =>
        new DepartmentDetailsResponse()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            CreatedOn = department.CreatedOn,
            Code = department.Code,
            CreatedBy = department.CreatedBy,
            IsDeleted = department.IsDeleted,
            LastModifiedBy = department.LastModified,
            LastModifiedOn = department.LastModifiedOn
        };

    public static Department ToEntity(this DepartmentRequest d) => new()
    {
        Name = d.Name,
        Description = d.Description,
        CreatedOn = d.CreatedOn,
        Code = d.Code,
    };

    public static Department ToEntity(this DepartmentUpdateRequest d) => new()
    {
        Id = d.Id,
        Name = d.Name,
        Description = d.Description,
        CreatedOn = d.CreatedOn.ToDateTime(TimeOnly.Parse("10:00 PM")), 
        Code = d.Code,
    };

    public static DepartmentUpdateRequest ToUpdateRequest(this DepartmentDetailsResponse department)
    {
        return new DepartmentUpdateRequest()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
            Code = department.Code,
        };
    }

    public static DepartmentRequest ToRequest(this DepartmentUpdateRequest department)
    {
        return new DepartmentRequest()
        {
            Code = department.Code,
            Name = department.Name,
            Description = department.Description,
        };
    }
}