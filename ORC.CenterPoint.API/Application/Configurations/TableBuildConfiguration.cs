namespace ORC.CenterPoint.API.Application.Configurations;

public class TableBuildConfiguration
    : IEntityTypeConfiguration<RestaurantTable>
{
    public void Configure(EntityTypeBuilder<RestaurantTable> builder)
    {
        builder
            .ToTable("RestaurantTable")
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .UseIdentityColumn()
            .IsRequired();

        builder
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .HasIndex(p => p.Name, "IX_RestaurantTable_Name");

        builder
            .Property(p => p.RoomName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasIndex(p => p.RoomName, "IX_RestaurantTable_RoomName");

        builder
            .Property(p => p.AllowedDinersNumber)
            .IsRequired();

        builder
            .Property(p => p.RegistrationDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
    }
}