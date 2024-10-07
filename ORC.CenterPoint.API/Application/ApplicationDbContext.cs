namespace ORC.CenterPoint.API.Application;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    #region Properties
    public DbSet<RestaurantTable> Tables { get; set; }
    #endregion
}