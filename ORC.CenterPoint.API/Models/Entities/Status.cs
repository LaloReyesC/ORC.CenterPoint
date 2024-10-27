namespace ORC.CenterPoint.API.Models.Entities;

public class Status
{
    #region Properties
    /// <summary>
    /// Constains status identifier
    /// </summary>
    public short Id { get; set; }

    /// <summary>
    /// Contains status name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Entry registration date
    /// </summary>
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Navigational property that represents all employees on same status
    /// </summary>
    public IList<Employee> Employees { get; set; } = [];
    #endregion
}