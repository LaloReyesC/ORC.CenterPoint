namespace ORC.CenterPoint.API.Application.Configurations;

public class EmployeeBuilder
    : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("Employee")
            .HasKey(p => p.Id)
            .HasName("PK_Employee_Id");

        builder
            .Property(p => p.Id)
            .UseIdentityColumn();

        builder
            .HasOne(p => p.Status)
            .WithMany(p => p.Employees)
            .HasForeignKey(p => p.StatusId)
            .HasConstraintName("FK_Employee_StatusId")
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder
            .Property(p => p.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder
            .Property(p => p.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.MaternalSurname)
            .HasMaxLength(50);

        builder
            .Property(p => p.BornDate)
            .IsRequired();

        builder
            .Property(p => p.RegistrationDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
    }
}