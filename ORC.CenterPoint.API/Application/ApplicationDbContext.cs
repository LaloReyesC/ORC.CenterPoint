namespace ORC.CenterPoint.API.Application;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    #region Properties
    /// <summary>
    /// Accesor for restaurant tables on database
    /// </summary>
    public DbSet<RestaurantTable> Tables { get; set; }

    /// <summary>
    /// Accesor for employees on database
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Accesor for system status on database
    /// </summary>
    public DbSet<Status> Status { get; set; }
    #endregion

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}