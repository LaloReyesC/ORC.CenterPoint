namespace ORC.CenterPoint.API.Application.Configurations;

public class StatusBuilder
    : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder
            .ToTable("Status")
            .HasKey(p => p.Id)
            .HasName("PK_Status_Id");

        builder
            .Property(p => p.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .HasMany(p => p.Employees)
            .WithOne(p => p.Status);

        builder
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.RegistrationDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
    }
}