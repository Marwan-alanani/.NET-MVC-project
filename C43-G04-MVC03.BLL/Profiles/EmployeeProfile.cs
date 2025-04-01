namespace C43_G04_MVC03.BLL.Profiles;

internal class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        // source => destination
        CreateMap<Employee, EmployeeDetailsResponse>()
            .ForMember(d => d.Department,
                options =>
                    options.MapFrom(src => src.Department.Name))
            .ForMember(d => d.Image,
                options =>
                    options.MapFrom(src => src.ImageName));

        CreateMap<Employee, EmployeeResponse>()
            .ForMember(d => d.Department,
                options =>
                    options.MapFrom(src => src.Department.Name))
            .ForMember(e => e.Image,
                options =>
                    options.MapFrom(src => src.ImageName));


        CreateMap<EmployeeRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();
    }
}