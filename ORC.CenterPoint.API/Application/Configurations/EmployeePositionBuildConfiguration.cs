namespace ORC.CenterPoint.API.Application.Configurations;

public class EmployeePositionBuildConfiguration
    : IEntityTypeConfiguration<EmployeePosition>
{
    public void Configure(EntityTypeBuilder<EmployeePosition> builder)
    {
        builder
            .ToTable("EmployeePosition")
            .HasKey(p => p.Id)
            .HasName("PK_EmployeePosition_Id");

        builder
            .Property(p => p.Id)
            .UseIdentityColumn()
            .IsRequired();

        builder
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(p => p.RegistrationDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.HasData(PositionsConstants.GeneralEmployee);
    }
}