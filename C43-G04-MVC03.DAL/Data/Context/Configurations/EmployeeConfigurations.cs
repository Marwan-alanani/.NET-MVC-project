namespace C43_G04_MVC03.Presentation.DAL.Data.Context.Configurations;

internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(e => e.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(e => e.Address)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(e => e.Salary)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(e => e.Gender)
            .HasConversion(
                gender => gender.ToString(),
                gender => Enum.Parse<Gender>(gender)
            );

        builder.Property(e => e.EmployeeType)
            .HasConversion(
                eType => eType.ToString(),
                eType => Enum.Parse<EmployeeType>(eType)
            );
        
        builder.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull); 
    }
}