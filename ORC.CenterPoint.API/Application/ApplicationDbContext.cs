namespace ORC.CenterPoint.API.Application;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    #region Properties
    /// <summary>
    /// Database Accesor for restaurant tables
    /// </summary>
    public DbSet<RestaurantTable> Tables { get; set; }

    /// <summary>
    /// Database accesor for employees
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Database accesor for status catalog
    /// </summary>
    public DbSet<Status> Status { get; set; }
    #endregion

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeBuildConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}